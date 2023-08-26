Imports System.Data.SqlClient

Public Class SQLServer_Backup_Restore
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dread As SqlDataReader
    Dim hostName As String = My.Computer.Name
    Dim conn As New SqlConnection With {.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("WCP.My.MySettings.WCPConnectionString").ConnectionString}
    Dim str_action As String

    Private Sub SQLServer_Backup_Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' server(".")
        '  server(".\sqlexpress")

        If hostName = "GT-SERVER01" Or hostName = "WS-ACC" Then
            server(AppConfigReader.SQLServer)
        Else
            NotRunOnServer()
        End If
    End Sub

    Sub server(ByVal str As String)
        con = New SqlConnection("Data Source=" & str & ";Database=Master;integrated security=SSPI;")
        con.Open()
        cmd = New SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con)

        dread = cmd.ExecuteReader
        While dread.Read
            cmbserver.Items.Add(dread(2))
        End While
        dread.Close()

        If cmbserver.Items.Count > 0 Then
            cmbserver.SelectedIndex = 0    ' The first item has index 0 '
        End If

        cmbserver.Enabled = False
    End Sub

    Private Sub NotRunOnServer()
        MessageBox.Show("You are not running the program on server, restore button has been disabled.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btn_restore.Enabled = False
        GroupBox1.Enabled = False
    End Sub

    Sub connection()
        ' con = New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Database=Master;integrated security=SSPI;")
        '  con.Open()
        ' cmbdatabase.Items.Clear()
        ' cmd = New SqlCommand("select * from sysdatabases", con)
        ' dread = cmd.ExecuteReader
        ' While dread.Read
        'cmbdatabase.Items.Add(dread(0))
        '  End While
        '  dread.Close()

        cmbdatabase.Items.Add(AppConfigReader.DBName)
        If cmbdatabase.Items.Count > 0 Then
            cmbdatabase.SelectedIndex = 0    ' The first item has index 0 '
        End If

        cmbdatabase.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            If str_action = "restore" Then
                MessageBox.Show("Restore Successfully, Please Rerun Your Program.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Backup Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ProgressBar1.Visible = False
            If hostName = "GT-SERVER01" Or hostName = "WS-ACC" Then
                btn_backup.Enabled = True
                btn_restore.Enabled = True
            Else
                btn_backup.Enabled = True
                btn_restore.Enabled = False
            End If
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub

    Private Sub cmbserver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbserver.SelectedIndexChanged
        connection()
    End Sub

    Sub query(ByVal que As String)
        On Error Resume Next
        cmd = New SqlCommand(que, con)
        cmd.ExecuteNonQuery()
    End Sub


    Sub blank(ByVal str As String)
        If str = "backup" Then
            'Backup
            str_action = "backup"
            SaveFileDialog1.Title = "Database Backup"
            SaveFileDialog1.FileName = DateAndTime.DateString + "-" + AppConfigReader.DBName
            SaveFileDialog1.Filter = "SQL Server database backup files|*.bak"

            SaveFileDialog1.InitialDirectory = Application.StartupPath + "\db_backup\" + AppConfigReader.DBName

            Dim ofd_result As DialogResult = SaveFileDialog1.ShowDialog()

            If ofd_result = DialogResult.Cancel Then
                MessageBox.Show("Backup has been Abort.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    Dim comm As New SqlCommand("Backup database " + AppConfigReader.DBName + " to disk='" & SaveFileDialog1.FileName & "'", conn)
                    btn_backup.Enabled = False
                    btn_restore.Enabled = False
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Timer1.Enabled = True
                    ProgressBar1.Visible = True
                    conn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    conn.Close()
                End Try

            End If
        ElseIf str = "restore" Then
            ' Restore
            str_action = "restore"
            OpenFileDialog1.InitialDirectory = Application.StartupPath + "\db_backup\" + AppConfigReader.DBName
            OpenFileDialog1.FileName = " "
            OpenFileDialog1.Filter = "SQL Server database backup files|*.bak"
            Dim ofd_result As DialogResult = OpenFileDialog1.ShowDialog

            If ofd_result = DialogResult.Cancel Then
                MessageBox.Show("Restore has been Abort.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    btn_backup.Enabled = False
                    btn_restore.Enabled = False
                    Timer1.Enabled = True
                    ProgressBar1.Visible = True
                    query("ALTER DATABASE " & cmbdatabase.Text & "  set SINGLE_USER WITH ROLLBACK IMMEDIATE")
                    ' query("DROP DATABASE " & cmbdatabase.Text)
                    query("RESTORE DATABASE " & cmbdatabase.Text & " FROM disk='" & OpenFileDialog1.FileName & "'")
                    query("ALTER DATABASE " & cmbdatabase.Text & "   SET MULTI_USER")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

            End If
        End If
    End Sub

    Private Sub btn_backup_Click(sender As Object, e As EventArgs) Handles btn_backup.Click
        blank("backup")
    End Sub

    Private Sub btn_restore_Click(sender As Object, e As EventArgs) Handles btn_restore.Click
        blank("restore")
    End Sub
End Class