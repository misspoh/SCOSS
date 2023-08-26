Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class User
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SCO_ID, SCO_PASSWORD, SCO_DESCRIPTION FROM SCO_USER", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            DataGridView1.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, table.Rows(i)(2).ToString)
        Next

        TextBox2.UseSystemPasswordChar = True
        TextBox3.UseSystemPasswordChar = True
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        CheckBox1.CheckState = CheckState.Unchecked
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' validation on re entering password
        If TextBox3.Text = TextBox2.Text Then

            conn.Open()
            Dim comm As New SqlCommand("SELECT SCO_ID FROM SCO_USER WHERE SCO_ID = @id", conn)
            comm.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox1.Text
            Dim adapter As New SqlDataAdapter(comm)
            Dim table As New DataTable
            adapter.Fill(table)
            comm.ExecuteNonQuery()
            conn.Close()

            If table.Rows.Count = Nothing Then
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO SCO_USER (SCO_ID, SCO_DESCRIPTION, SCO_PASSWORD) VALUES (@id, @details, @pass)", conn)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = TextBox4.Text
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Insert successfully.")
            Else
                conn.Open()
                Dim cmd As New SqlCommand("UPDATE SCO_USER SET SCO_PASSWORD = @pass, SCO_DESCRIPTION = @desc WHERE SCO_ID = @id", conn)
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox4.Text
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Update successfully")
            End If
        Else
            TextBox3.Text = ""
            TextBox3.Focus()
            MsgBox("Password entered is not the same as password assign. Please try again.", MsgBoxStyle.OkOnly, "Warning")

        End If

        User_Load(e, e)
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'DataGridView1.Rows.Clear()

        Dim rowindex As Integer
        rowindex = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(0, rowindex).Value
        TextBox2.Text = DataGridView1.Item(1, rowindex).Value
        TextBox4.Text = DataGridView1.Item(2, rowindex).Value
        btnEdit.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        TextBox4.Focus()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox3.Text = ""
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If TextBox1.Text = "admin" Then
            MsgBox("Admin can't be deleted.")
        Else
            Dim result As Integer = MessageBox.Show("Do you want confirm to delete?", "Notification", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM SCO_USER WHERE SCO_ID = @id", conn)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Delete successfully.")

                User_Load(e, e)
                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True
                TextBox3.ReadOnly = True
                TextBox4.ReadOnly = True
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                btnAdd.Enabled = True
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnCancel.Enabled = False
            End If
        End If
       
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
            TextBox2.SelectAll()

        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If TextBox1.Text = "admin" Then
            If MainMenu.ToolStripStatusLabel1.Text = "LOGIN AS: ADMINISTRATOR" Then
            Else

                CheckBox1.CheckState = CheckState.Unchecked

                MsgBox("Admin password is visible only for administrator only.")
            End If
        End If
      
    End Sub
End Class