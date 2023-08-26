Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class BackupAndRestore
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub BackupAndRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        GroupBox1.Enabled = True

        TextBox1.Text = AppConfigReader.DBName & ".bak"
        btnRestore.Enabled = False
        btnCancel.Enabled = True

    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        GroupBox2.Enabled = True
        btnBackup.Enabled = False
        btnCancel.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        btnBackup.Enabled = True
        btnRestore.Enabled = True
        btnCancel.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As New SqlCommand
        Dim dbname As String = AppConfigReader.DBName
        Dim path As String = AppConfigReader.BPath
        Dim filename As String = TextBox1.Text & ".bak"
        My.Computer.FileSystem.DeleteFile(path & filename)
        cmd = New SqlCommand("backup database " & dbname & " to disk= N'" & path & filename & "'", conn)

        conn.Open()

        cmd.ExecuteNonQuery()

        conn.Close()

        TextBox1.ReadOnly = True
        Button3.Enabled = False
        ' CheckBox1.Enabled = True
        ' CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        ' CheckBox1.CheckState = CheckState.Unchecked
        ' CheckBox2.CheckState = CheckState.Unchecked
        CheckBox3.CheckState = CheckState.Unchecked
        ToolStripStatusLabel1.Text = "Successfully backup."
        TextBox1.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' OpenFileDialog1.InitialDirectory = "\\gt-server01\Service Order\LOG DATABASE"
        OpenFileDialog1.Filter = "All File|*.*"

        If (OpenFileDialog1.ShowDialog = DialogResult.OK) Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim dbname As String = AppConfigReader.DBName

        conn.Open()
        Dim cmd As New SqlCommand("USE master ALTER DATABASE SCO SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [" & dbname & "] FROM  DISK = @filepath WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10 ", conn)
        cmd.Parameters.Add("@filepath", SqlDbType.VarChar).Value = TextBox2.Text
        cmd.CommandTimeout = 100
        cmd.ExecuteNonQuery()
        conn.Close()

        ToolStripStatusLabel1.Text = "Successfully restored."
        TextBox2.Text = ""

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            TextBox1.ReadOnly = False
            TextBox1.Focus()
        Else
            TextBox1.ReadOnly = True
            TextBox1.Text = ""
        End If
    End Sub

End Class