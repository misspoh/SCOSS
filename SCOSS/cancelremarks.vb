Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class cancelremarks
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection '

    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer
    Dim tab As New DataTable
    Dim currrow As Integer

    Private Sub cancelremarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        ' CHECKING THE SERVICE ORDER NUMBER TO MAKE SURE IT EXISTS IN THE DATABASE
        conn.Open()
        Dim cmd As New SqlCommand("SELECT PO_NO FROM SCO_DATA WHERE PO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        If tb.Rows.Count = Nothing Then
            MsgBox("PO NO didn't exist.")
        End If

    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        If TextBox1.Text = "" Then
            MsgBox("Reason must be fill.")
        Else
            ' 
            Dim result As Integer = MessageBox.Show("Do you want to cancel this SO NO?", "Notification", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then

                conn.Open()
                Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_STATUS = 'CANCELLED' WHERE PO_NO = @no", conn)
                cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                conn.Open()
                Dim cmd1 As New SqlCommand("UPDATE SCO_TEMP SET SCO_PRINT = 'CANCELLED' WHERE SCO_NO = @no", conn)
                cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
                cmd1.ExecuteNonQuery()
                conn.Close()

                Dim tm As DateTime = DateTime.Now

                ' insert into sco_cancel
                conn.Open()
                Dim cmd2 As New SqlCommand("INSERT INTO SCO_CANCELLED (CAN_PONO, CAN_STAT, CAN_REASON, CAN_DATE) VALUES (@no, @stat, @reason, @date)", conn)
                cmd2.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
                cmd2.Parameters.Add("@stat", SqlDbType.VarChar).Value = "CANCELLED"
                cmd2.Parameters.Add("@reason", SqlDbType.VarChar).Value = TextBox1.Text
                cmd2.Parameters.Add("@date", SqlDbType.Date).Value = tm.ToString("yyyy-MM-dd")
                cmd2.ExecuteNonQuery()
                conn.Close()

                MsgBox("SO NO successfully cancelled.")

                'supplbl.Text = "..."
                'statlbl.Text = "..."
                'sonolbl.Text = "..."
                'datelbl.Text = "..."

                'totalAMT.Text = "-"
                'totalSTK.Text = "-"

                'DataGridView1.Rows.Clear()

                'TextBox1.Text = ""
                'TextBox1.Focus()

                'btnCancel.Enabled = False
                'btnDelete.Enabled = False
                'btnReset.Enabled = False
                'TextBox1.Enabled = True
                'btnSearch.Enabled = True

                Me.Close()
            Else
                MsgBox("Cancellation process is denied.")
            End If
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cancelremarks_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MsgBox("SO cancellation process is terminated.", MsgBoxStyle.OkOnly, "Notification")
        Me.Close()
    End Sub

End Class