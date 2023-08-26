Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Supplier
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

            f1.loadParticular("1")
        Else

        End If

    End Sub

    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SCO_SUPPDataGridView.Rows.Clear()

        conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT [SUPP_CODE],[SUPP_DESC],[SUPP_ADDRESS],[SUPP_SSTNO],[SUPP_BRN],[SUPP_TEL],[SUPP_FAX],[SUPP_EMAIL],[SUPP_ACCNO] FROM SCO_SUPP", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            SCO_SUPPDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, table.Rows(i)(2).ToString, table.Rows(i)(3).ToString, table.Rows(i)(4).ToString, table.Rows(i)(5).ToString, table.Rows(i)(6).ToString, table.Rows(i)(7).ToString, table.Rows(i)(8).ToString)
        Next

    End Sub

    Private Sub SCO_SUPPDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SCO_SUPPDataGridView.CellClick
        Dim i As Integer = 0
        i = SCO_SUPPDataGridView.CurrentRow.Index

        TextBox2.Text = SCO_SUPPDataGridView.Item(0, i).Value
        TextBox3.Text = SCO_SUPPDataGridView.Item(1, i).Value
        TextBox4.Text = SCO_SUPPDataGridView.Item(2, i).Value
        TextBox5.Text = SCO_SUPPDataGridView.Item(5, i).Value
        TextBox6.Text = SCO_SUPPDataGridView.Item(6, i).Value
        TextBox7.Text = SCO_SUPPDataGridView.Item(7, i).Value
        TextBox8.Text = SCO_SUPPDataGridView.Item(3, i).Value
        TextBox9.Text = SCO_SUPPDataGridView.Item(4, i).Value
        TextBox10.Text = SCO_SUPPDataGridView.Item(8, i).Value

        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = False
        btnSave.Enabled = False
        GroupBox1.Enabled = False

    End Sub

    Private Sub SearchBtn_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        SCO_SUPPDataGridView.Rows.Clear()
        If CheckBox1.CheckState = CheckState.Checked Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT [SUPP_CODE],[SUPP_DESC],[SUPP_ADDRESS],[SUPP_SSTNO],[SUPP_BRN],[SUPP_TEL],[SUPP_FAX],[SUPP_EMAIL],[SUPP_ACCNO] FROM SCO_SUPP WHERE SUPP_CODE LIKE '" & TextBox1.Text & "%'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            For i As Integer = 0 To table.Rows.Count - 1
                SCO_SUPPDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, table.Rows(i)(2).ToString, table.Rows(i)(3).ToString, table.Rows(i)(4).ToString, table.Rows(i)(5).ToString, table.Rows(i)(6).ToString, table.Rows(i)(7).ToString, table.Rows(i)(8).ToString)
            Next

        ElseIf CheckBox2.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT [SUPP_CODE],[SUPP_DESC],[SUPP_ADDRESS],[SUPP_SSTNO],[SUPP_BRN],[SUPP_TEL],[SUPP_FAX],[SUPP_EMAIL],[SUPP_ACCNO] FROM SCO_SUPP WHERE SUPP_DESC LIKE '" & TextBox1.Text & "%'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            For i As Integer = 0 To table.Rows.Count - 1
                SCO_SUPPDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, table.Rows(i)(2).ToString, table.Rows(i)(3).ToString, table.Rows(i)(4).ToString, table.Rows(i)(5).ToString, table.Rows(i)(6).ToString, table.Rows(i)(7).ToString, table.Rows(i)(8).ToString)
            Next

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SCO_SUPPDataGridView.Rows.Clear()

        conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT [SUPP_CODE],[SUPP_DESC],[SUPP_ADDRESS],[SUPP_SSTNO],[SUPP_BRN],[SUPP_TEL],[SUPP_FAX],[SUPP_EMAIL],[SUPP_ACCNO] FROM SCO_SUPP", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            SCO_SUPPDataGridView.Rows.Add(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, table.Rows(i)(2).ToString, table.Rows(i)(3).ToString, table.Rows(i)(4).ToString, table.Rows(i)(5).ToString, table.Rows(i)(6).ToString, table.Rows(i)(7).ToString, table.Rows(i)(8).ToString)
        Next

        TextBox1.Text = ""

        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = "A"
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True
        GroupBox1.Enabled = True
        SCO_SUPPDataGridView.Enabled = False

        TextBox2.Focus()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If TextBox11.Text = "A" Then
            ' Me.SCO_SUPPTableAdapter.Insert(TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox8.Text, TextBox9.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox10.Text, TextBox3.Text & " - " & TextBox2.Text)
            conn.Open()
            Dim cmd As New SqlCommand("INSERT INTO SCO_SUPP ([SUPP_CODE],[SUPP_DESC],[SUPP_CBDESC],[SUPP_ADDRESS],[SUPP_SSTNO],[SUPP_BRN],[SUPP_TEL],[SUPP_FAX],[SUPP_EMAIL],[SUPP_ACCNO]) VALUES (@code, @desc, @cd, @add, @sst, @brn, @tel, @fax, @email, @acc)", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@cd", SqlDbType.VarChar).Value = TextBox3.Text & " - " & TextBox2.Text
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = TextBox4.Text
            cmd.Parameters.Add("@sst", SqlDbType.VarChar).Value = TextBox8.Text
            cmd.Parameters.Add("@brn", SqlDbType.VarChar).Value = TextBox9.Text
            cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = TextBox6.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@acc", SqlDbType.VarChar).Value = TextBox10.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully added.")

        ElseIf TextBox11.Text = "E" Then
            ' Me.SCO_SUPPTableAdapter.UpdateQuerySupplier(TextBox3.Text, TextBox4.Text, TextBox8.Text, TextBox9.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox10.Text, TextBox2.Text)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_SUPP SET SUPP_DESC = @desc, SUPP_ADDRESS = @add, SUPP_SSTNO = @sst, SUPP_BRN = @brn, SUPP_TEL = @tel, SUPP_FAX = @fax, SUPP_EMAIL = @email, SUPP_ACCNO = @acc WHERE SUPP_CODE = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@cd", SqlDbType.VarChar).Value = TextBox3.Text & " - " & TextBox2.Text
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = TextBox4.Text
            cmd.Parameters.Add("@sst", SqlDbType.VarChar).Value = TextBox8.Text
            cmd.Parameters.Add("@brn", SqlDbType.VarChar).Value = TextBox9.Text
            cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = TextBox6.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@acc", SqlDbType.VarChar).Value = TextBox10.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully updated.")
        End If

        Supplier_Load(e, e)
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
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        SCO_SUPPDataGridView.Enabled = True
        reload()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        TextBox11.Text = "E"
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True
        GroupBox1.Enabled = True
        SCO_SUPPDataGridView.Enabled = False

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Do you want to delete?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            'Me.SCO_SUPPTableAdapter.DeleteQuerySuppCode(TextBox2.Text)
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM SCO_SUPP WHERE SUPP_CODE = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully deleted.")
            Supplier_Load(e, e)

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SCO_SUPPDataGridView.Enabled = True
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
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox10.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
End Class