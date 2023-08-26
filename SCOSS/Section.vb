Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Section
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Sub reload()
        Dim e As EventArgs

        If Application.OpenForms().OfType(Of PostingForm).Any Then

            Dim f1 As PostingForm = CType(Application.OpenForms("PostingForm"), PostingForm)

            f1.loadParticular("2")

        Else

        End If

    End Sub

    Private Sub Section_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SCO_SECTIONDataGridView.Rows.Clear()

        conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_SECTION ORDER BY SEC_CODE", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            SCO_SECTIONDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString)
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SCO_SECTIONDataGridView.Enabled = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = "A"
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True
        GroupBox1.Enabled = True

        TextBox2.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If TextBox4.Text = "A" Then
            ' Me.SCO_SECTIONTableAdapter.Insert(TextBox2.Text, TextBox3.Text)
            conn.Open()
            Dim cmd As New SqlCommand("INSERT INTO SCO_SECTION (SEC_CODE, SEC_DESC) VALUES (@code, @desc)", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully added.")

        ElseIf TextBox4.Text = "E" Then
            ' Me.SCO_SECTIONTableAdapter.UpdateQuerySection(TextBox3.Text, TextBox2.Text)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_SECTION SET SEC_DESC = @desc WHERE SEC_CODE = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully updated.")
        End If

        SCO_SECTIONDataGridView.Enabled = True
        Section_Load(e, e)
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = False
        btnSave.Enabled = False
        GroupBox1.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        reload()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        SCO_SECTIONDataGridView.Enabled = False
        TextBox4.Text = "E"
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True
        GroupBox1.Enabled = True

        TextBox5.Text = TextBox2.Text
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Do you want to delete?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            ' Me.SCO_SECTIONTableAdapter.DeleteQuerySecCode(TextBox2.Text)
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM SCO_SECTION WHERE SEC_CODE = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully deleted.")
            Section_Load(e, e)
            TextBox1.Text = ""

            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""

            reload()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SCO_SECTIONDataGridView.Enabled = True
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
        btnSave.Enabled = False
        GroupBox1.Enabled = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub SearchBtn_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        SCO_SECTIONDataGridView.Rows.Clear()
        If CheckBox1.CheckState = CheckState.Checked Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_SECTION WHERE SEC_CODE LIKE '" & TextBox1.Text & "%'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            For i As Integer = 0 To table.Rows.Count - 1
                SCO_SECTIONDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString)
            Next

        ElseIf CheckBox2.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_SECTION WHERE SEC_DESC LIKE '" & TextBox1.Text & "%'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            For i As Integer = 0 To table.Rows.Count - 1
                SCO_SECTIONDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString)
            Next

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SCO_SECTIONDataGridView.Rows.Clear()

        conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_SECTION", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            SCO_SECTIONDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString)
        Next

        TextBox1.Text = ""

        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub SCO_SECTIONDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SCO_SECTIONDataGridView.CellClick
        Dim i As Integer = 0
        i = SCO_SECTIONDataGridView.CurrentRow.Index

        TextBox2.Text = SCO_SECTIONDataGridView.Item(0, i).Value
        TextBox3.Text = SCO_SECTIONDataGridView.Item(1, i).Value

        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = False
        btnSave.Enabled = False
        GroupBox1.Enabled = False
    End Sub
End Class