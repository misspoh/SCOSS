Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Tax
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub Tax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT TAX_ID, TAX_DESC FROM SCO_TAX", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        SCO_TAXComboBox.DisplayMember = "TAX_DESC"
        SCO_TAXComboBox.ValueMember = "TAX_ID"
        SCO_TAXComboBox.DataSource = table

    End Sub

    Private Sub SCO_TAXComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SCO_TAXComboBox.SelectedIndexChanged
        If SCO_TAXComboBox.SelectedIndex = -1 Then
        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_TAX WHERE TAX_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = SCO_TAXComboBox.SelectedValue
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            TAX_IDTextBox.Text = SCO_TAXComboBox.SelectedValue
            TAX_DESCTextBox.Text = table.Rows(0)(1).ToString
            TAX_RATETextBox.Text = table.Rows(0)(2).ToString
            CheckBox1.Text = table.Rows(0)(3).ToString
        End If
        
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' TAX_IDTextBox.ReadOnly = False
        TAX_DESCTextBox.ReadOnly = False
        TAX_RATETextBox.ReadOnly = False
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        conn.Open()
        Dim cmd As New SqlCommand("UPDATE SCO_TAX SET TAX_DESC = @desc, TAX_RATE = @rate WHERE TAX_ID = @id", conn)
        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TAX_DESCTextBox.Text
        cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = TAX_RATETextBox.Text
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = TAX_IDTextBox.Text
        cmd.ExecuteNonQuery()
        conn.Close()

        MsgBox("Successfully updated.", MsgBoxStyle.OkOnly, "Success")

        TAX_IDTextBox.ReadOnly = True
        TAX_DESCTextBox.ReadOnly = True
        TAX_RATETextBox.ReadOnly = True
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False

    End Sub

    Private Sub TAX_IDTextBox_TextChanged(sender As Object, e As EventArgs) Handles TAX_IDTextBox.TextChanged
        If TAX_IDTextBox.Text = Nothing Then
        Else
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TAX_IDTextBox.ReadOnly = True
        TAX_DESCTextBox.ReadOnly = True
        TAX_RATETextBox.ReadOnly = True
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub
End Class