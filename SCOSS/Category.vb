Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Category
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)


    End Sub

    Private Sub btnADDC_Click(sender As Object, e As EventArgs) Handles btnADDC.Click
        GroupBox1.Enabled = True
        TextBox4.Focus()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' CHECKING IF THE DATA ALREADY EXIST OR NOT
        conn.Open()
        Dim command As New SqlCommand("SELECT * FROM MACH_MAINC WHERE MCAT_ID = @id", conn)
        command.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        command.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
            If DataGridView1.Rows.Count = Nothing Then
                Dim result As Integer = MessageBox.Show("Do you want to save without sub-category?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    conn.Open()
                    Dim cmd As New SqlCommand("INSERT INTO MACH_MAINC (MCAT_ID, MCAT_DESC) VALUES (@mcat_id, @mcat_desc)", conn)
                    cmd.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                    cmd.Parameters.Add("@mcat_desc", SqlDbType.VarChar).Value = TextBox1.Text
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            Else
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO MACH_MAINC (MCAT_ID, MCAT_DESC) VALUES (@mcat_id, @mcat_desc)", conn)
                cmd.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@mcat_desc", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                For i = 0 To DataGridView1.Rows.Count - 1
                    conn.Open()
                    Dim cm As New SqlCommand("INSERT INTO MACH_SUBC (SCAT_ID, SCAT_DESC, MCAT_ID) VALUE (@scat_id, @scat_desc, @mcat_id)", conn)
                    cm.Parameters.Add("@scat_id", SqlDbType.VarChar).Value = DataGridView1.Item(0, i).Value
                    cm.Parameters.Add("@scat_desc", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    cm.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                    cm.ExecuteNonQuery()
                    conn.Close()
                Next

            End If

        Else
            ' edit existing machine code including the main category and the sub-main category
            If DataGridView1.Rows.Count = Nothing Then
                Dim result As Integer = MessageBox.Show("Do you want to save without sub-category?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    ' delete first the existing
                    conn.Open()
                    Dim cmdelete As New SqlCommand("DELETE FROM MACH_MAINC WHERE MCAT_ID = @id", conn)
                    cmdelete.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox2.Text
                    cmdelete.ExecuteNonQuery()
                    conn.Close()

                    ' insert the new one
                    conn.Open()
                    Dim cmd As New SqlCommand("INSERT INTO MACH_MAINC (MCAT_ID, MCAT_DESC) VALUES (@mcat_id, @mcat_desc)", conn)
                    cmd.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                    cmd.Parameters.Add("@mcat_desc", SqlDbType.VarChar).Value = TextBox1.Text
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            Else
                ' delete first the existing main
                conn.Open()
                Dim cmdelete As New SqlCommand("DELETE FROM MACH_MAINC WHERE MCAT_ID = @id", conn)
                cmdelete.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox2.Text
                cmdelete.ExecuteNonQuery()
                conn.Close()

                ' delete first the existing sub main
                conn.Open()
                Dim cmdeletesub As New SqlCommand("DELETE FROM MACH_SUBC WHERE MCAT_ID = @id", conn)
                cmdeletesub.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox2.Text
                cmdeletesub.ExecuteNonQuery()
                conn.Close()

                ' this part will insert the new one into the main and sub category table 
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO MACH_MAINC (MCAT_ID, MCAT_DESC) VALUES (@mcat_id, @mcat_desc)", conn)
                cmd.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@mcat_desc", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                For i = 0 To DataGridView1.Rows.Count - 1
                    conn.Open()
                    Dim cm As New SqlCommand("INSERT INTO MACH_SUBC (SCAT_ID, SCAT_DESC, MCAT_ID) VALUES (@scat_id, @scat_desc, @mcat_id)", conn)
                    cm.Parameters.Add("@scat_id", SqlDbType.VarChar).Value = DataGridView1.Item(0, i).Value
                    cm.Parameters.Add("@scat_desc", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    cm.Parameters.Add("@mcat_id", SqlDbType.VarChar).Value = TextBox2.Text
                    cm.ExecuteNonQuery()
                    conn.Close()
                Next

            End If
        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        GroupBox1.Enabled = False

        DataGridView1.Rows.Clear()

        MsgBox("Success.")

        machinemanager.machinemanager_Load(e, e)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        DataGridView1.Rows.Add(TextBox4.Text, TextBox3.Text)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim i As Integer = 0
        i = DataGridView1.CurrentRow.Index

        Dim result As Integer = MessageBox.Show("Do you want to delete this sub category?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            DataGridView1.Rows.RemoveAt(i)

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataGridView1.Rows.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        GroupBox1.Enabled = False

        TextBox1.Focus()

    End Sub

    Private Sub Category_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub Category_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
   
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        DataGridView1.Rows.Clear()

        'machinemanager.TreeView1.HideSelection = False


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index

        If i = -1 Then
        Else
            TextBox4.Text = DataGridView1.Item(0, i).Value
            TextBox3.Text = DataGridView1.Item(1, i).Value
        End If
    End Sub
End Class