Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class PRCustom
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub PRCustom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT Purpose, Remarks FROM PR_SK", conn)
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        If t.Rows.Count = Nothing Then
        Else

            TextBox1.Text = t.Rows(0)(0).ToString
            TextBox2.Text = t.Rows(0)(1).ToString
        End If

        Me.ActiveControl = TextBox1
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        conn.Open()
        Dim cmd1 As New SqlCommand("DELETE FROM PR_SK", conn)
        'cmd.Parameters.Add("@purp", SqlDbType.VarChar).Value = TextBox1.Text
        'cmd.Parameters.Add("@rem", SqlDbType.VarChar).Value = TextBox2.Text
        cmd1.ExecuteNonQuery()
        conn.Close()

        conn.Open()
        Dim cmd As New SqlCommand("INSERT INTO PR_SK (Purpose, Remarks) VALUES (@purp, @rem)", conn)
        cmd.Parameters.Add("@purp", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.Add("@rem", SqlDbType.VarChar).Value = TextBox2.Text
        cmd.ExecuteNonQuery()
        conn.Close()

        MsgBox("Update successful.")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox1.Text = ""
        TextBox2.Text = ""

        conn.Open()
        Dim cmd As New SqlCommand("SELECT Purpose, Remarks FROM PR_SK", conn)
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        If t.Rows.Count = Nothing Then
        Else

            TextBox1.Text = t.Rows(0)(0).ToString
            TextBox2.Text = t.Rows(0)(1).ToString
        End If
    End Sub
End Class