Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Login
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim coname As String = AppConfigReader.COName

        Label3.Text = coname

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            'conn.ConnectionString = constr 'copy the connection data source to sqlcontr
            conn = New SqlConnection(constr)
            conn.Open() ' open connection/connect sql database to our vs project
            If conn.State = ConnectionState.Closed Then
                MessageBox.Show("Database has failed to connect, system will now terminate.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End 'terminate/close program
            Else
                ' MsgBox(conn.ConnectionString)
            End If

        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        comm = New SqlCommand("SELECT SCO_ID, SCO_PASSWORD, SCO_DESCRIPTION FROM SCO_USER WHERE SCO_ID = @id AND SCO_PASSWORD = @pw", conn)
        comm.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox1.Text
        comm.Parameters.Add("@pw", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(comm)
        Dim table As New DataTable
        adapter.Fill(table)
        comm.ExecuteNonQuery()

        If table.Rows.Count = Nothing Then
            MsgBox("Login unsuccessful.")
            TextBox1.Focus()
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            MsgBox("Login successfully.")
            Me.Hide()
            MainMenu.ToolStripStatusLabel1.Text = "LOGIN AS: " & table.Rows(0)(2).ToString
            MainMenu.Text = Label3.Text & " - " & "Main Menu"
            MainMenu.MainMenu_Load(sender, e)
            MainMenu.Show()

        End If

        conn.Close()

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.Focus()
        End If
    End Sub
End Class
