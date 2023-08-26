Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class Currency
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub Currency_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_CURRENCY ORDER BY CURR_ID", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        SCO_CURRENCYComboBox.DisplayMember = "CURR_DESC"
        SCO_CURRENCYComboBox.ValueMember = "CURR_ID"
        SCO_CURRENCYComboBox.DataSource = table

    End Sub

    Private Sub SCO_CURRENCYComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SCO_CURRENCYComboBox.SelectedIndexChanged
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_CURRENCY WHERE CURR_ID = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = SCO_CURRENCYComboBox.SelectedValue
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
        Else
            CURR_IDTextBox.Text = table.Rows(0)(0).ToString
            CURR_DESCTextBox.Text = table.Rows(0)(1).ToString
            CURR_EXRATETextBox.Text = table.Rows(0)(2).ToString
            CheckBox1.Checked = table.Rows(0)(3).ToString

            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnCancel.Enabled = True

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SCO_CURRENCYComboBox.Enabled = False

        CURR_IDTextBox.Focus()
        CURR_IDTextBox.Text = ""
        CURR_IDTextBox.ReadOnly = False
        CURR_DESCTextBox.Text = ""
        CURR_DESCTextBox.ReadOnly = False
        CURR_EXRATETextBox.Text = ""
        CURR_EXRATETextBox.ReadOnly = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True

        TextBox1.Text = "A"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If TextBox1.Text = "A" Then
            ' validating the default currency
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_CURRENCY WHERE CURR_DEFAULT = 'True'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            If table.Rows.Count = Nothing Then
                conn.Open()
                cmd = New SqlCommand("INSERT INTO SCO_CURRENCY (CURR_ID, CURR_DESC, CURR_EXRATE, CURR_DEFAULT) VALUES (@id, @desc, @rate, @def)", conn)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "True"
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                If CheckBox1.CheckState = CheckState.Checked Then
                    Dim result As Integer = MessageBox.Show("Default currency is " & table.Rows(0)(1).ToString & ". Would you like to overwrite?", "Notification", MessageBoxButtons.YesNo)

                    If result = DialogResult.Yes Then
                        ' update the default currency in database
                        conn.Open()
                        cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DEFAULT = 'False' WHERE CURR_DEFAULT = 'True'", conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()

                        ' added into database
                        conn.Open()
                        cmd = New SqlCommand("INSERT INTO SCO_CURRENCY (CURR_ID, CURR_DESC, CURR_EXRATE, CURR_DEFAULT) VALUES (@id, @desc, @rate, @def)", conn)
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                        cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                        cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "True"
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        CheckBox1.CheckState = CheckState.Unchecked
                        conn.Open()
                        cmd = New SqlCommand("INSERT INTO SCO_CURRENCY (CURR_ID, CURR_DESC, CURR_EXRATE, CURR_DEFAULT) VALUES (@id, @desc, @rate, @def)", conn)
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                        cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                        cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "False"
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                Else
                    conn.Open()
                    cmd = New SqlCommand("INSERT INTO SCO_CURRENCY (CURR_ID, CURR_DESC, CURR_EXRATE, CURR_DEFAULT) VALUES (@id, @desc, @rate, @def)", conn)
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                    cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                    cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "False"
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If

            End If
        ElseIf TextBox1.Text = "E" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_CURRENCY WHERE CURR_DEFAULT = 'True'", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            If table.Rows.Count = Nothing Then
                conn.Open()
                cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DESC = @desc, CURR_EXRATE = @rate, CURR_DEFAULT = @def WHERE CURR_ID = @id", conn)
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "True"
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                If CheckBox1.CheckState = CheckState.Checked Then
                    Dim result As Integer = MessageBox.Show("Default currency is " & table.Rows(0)(1).ToString & ". Would you like to overwrite?", "Notification", MessageBoxButtons.YesNo)

                    If result = DialogResult.Yes Then
                        ' update the default currency in database
                        conn.Open()
                        cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DEFAULT = 'False' WHERE CURR_DEFAULT = 'True'", conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()

                        ' added into database
                        conn.Open()
                        cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DESC = @desc, CURR_EXRATE = @rate, CURR_DEFAULT = @def WHERE CURR_ID = @id", conn)
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                        cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                        cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "False"
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        CheckBox1.CheckState = CheckState.Unchecked
                        conn.Open()
                        cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DESC = @desc, CURR_EXRATE = @rate, CURR_DEFAULT = @def WHERE CURR_ID = @id", conn)
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                        cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                        cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "False"
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                Else
                    conn.Open()
                    cmd = New SqlCommand("UPDATE SCO_CURRENCY SET CURR_DESC = @desc, CURR_EXRATE = @rate, CURR_DEFAULT = @def WHERE CURR_ID = @id", conn)
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = CURR_DESCTextBox.Text
                    cmd.Parameters.Add("@rate", SqlDbType.VarChar).Value = CURR_EXRATETextBox.Text
                    cmd.Parameters.Add("@def", SqlDbType.VarChar).Value = "False"
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If

            End If
        End If

        Currency_Load(e, e)
        SCO_CURRENCYComboBox.Enabled = True
        CURR_IDTextBox.Text = ""
        CURR_IDTextBox.ReadOnly = True
        CURR_DESCTextBox.Text = ""
        CURR_DESCTextBox.ReadOnly = True
        CURR_EXRATETextBox.Text = ""
        CURR_EXRATETextBox.ReadOnly = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
      
    End Sub

    Private Sub CURR_IDTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CURR_IDTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT CURR_ID FROM SCO_CURRENCY WHERE CURR_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            If table.Rows.Count = Nothing Then
                CURR_DESCTextBox.Focus()

            Else
                MsgBox("The currency ID existed. Please try again.")
                CURR_IDTextBox.Text = ""

            End If

        End If
    End Sub

    Private Sub CURR_DESCTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CURR_DESCTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            CURR_EXRATETextBox.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SCO_CURRENCYComboBox.Enabled = True
        CURR_IDTextBox.Text = ""
        CURR_IDTextBox.ReadOnly = True
        CURR_DESCTextBox.Text = ""
        CURR_DESCTextBox.ReadOnly = True
        CURR_EXRATETextBox.Text = ""
        CURR_EXRATETextBox.ReadOnly = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        SCO_CURRENCYComboBox.Enabled = False

        CURR_IDTextBox.Focus()
        ' CURR_IDTextBox.Text = ""
        ' CURR_DESCTextBox.Text = ""
        CURR_DESCTextBox.ReadOnly = False
        ' CURR_EXRATETextBox.Text = ""
        CURR_EXRATETextBox.ReadOnly = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnSave.Enabled = True

        TextBox1.Text = "E"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure to delete?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM SCO_CURRENCY WHERE CURR_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = CURR_IDTextBox.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Deletion completed.")

            Currency_Load(e, e)
            SCO_CURRENCYComboBox.Enabled = True
            CURR_IDTextBox.Text = ""
            CURR_IDTextBox.ReadOnly = True
            CURR_DESCTextBox.Text = ""
            CURR_DESCTextBox.ReadOnly = True
            CURR_EXRATETextBox.Text = ""
            CURR_EXRATETextBox.ReadOnly = True

            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
        Else
            MsgBox("Deletion abort.")

        End If
    End Sub

End Class