Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class SOAmend
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub SOAmend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        ComboBox1.DisplayMember = "SUPP_CBDESC"
        ComboBox1.ValueMember = "SUPP_CODE"
        ComboBox1.DataSource = table

        conn.Open()
        Dim cmd1 As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
        Dim adapter1 As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable
        adapter1.Fill(table1)
        cmd1.ExecuteNonQuery()
        conn.Close()

        ComboBox3.DisplayMember = "SEC_DESC"
        ComboBox3.ValueMember = "SEC_CODE"
        ComboBox3.DataSource = table1

        conn.Open()
        Dim cmd2 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
        Dim adapter2 As New SqlDataAdapter(cmd2)
        Dim table2 As New DataTable
        adapter2.Fill(table2)
        cmd2.ExecuteNonQuery()
        conn.Close()

        ComboBox2.DisplayMember = "MACH_CODE"
        ComboBox2.ValueMember = "MACH_DESC"
        ComboBox2.DataSource = table2

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Sub search()
        conn = New SqlConnection(constr)

        DataGridView1.Rows.Clear()
        conn.Open()
        Dim cmd As New SqlCommand("SELECT PO_STOCK, PO_SUPP, PO_DATE FROM SCO_DATA WHERE PO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
            MsgBox("Service order No does not exist. Please try again.")
        Else
            For i As Integer = 0 To table.Rows.Count - 1
                DataGridView1.Rows.Add(table.Rows(i)(0).ToString)
            Next

            ToolStripStatusLabel1.Text = "Total Stock No: " & table.Rows.Count
            TextBox2.Text = TextBox1.Text
            MaskedTextBox3.Text = table.Rows(0)(2).ToString
            ComboBox1.SelectedValue = table.Rows(0)(1).ToString
        End If

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        search()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked
            DataGridView1.Enabled = True
            sodetails.Enabled = True
            btnSave.Enabled = True
            btnCancel.Enabled = True
        Else

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Unchecked
            DataGridView1.Enabled = True
            sodetails.Enabled = True
            stockdetails.Enabled = True
            btnSave.Enabled = True
            btnCancel.Enabled = True
        Else

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        DataGridView1.Enabled = False

        TextBox2.Text = ""
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        MaskedTextBox1.Text = ""
        MaskedTextBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""


        sodetails.Enabled = False
        stockdetails.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' validation stock no
        If CheckBox1.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_DATE = @date, PO_SUPP = @supp WHERE PO_NO = @no", conn)
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = MaskedTextBox3.Text
            cmd.Parameters.Add("@supp", SqlDbType.VarChar).Value = ComboBox1.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.ExecuteNonQuery()
            conn.Close()
        Else
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_DATE = @date, PO_SUPP = @supp, ETA_DATE = @etd, PO_SECTION = @sect, PO_STOCK = @stock, PO_DESC = @desc, PO_QTY = @qty, PO_UOM = @uom, PO_UPRICE = @up, PO_AMT = @amt, PO_MACHN = @mach, PO_DISCAMT = @disc, PO_TAX = @tax, PO_INV = @inv, PO_MACHD = @machd, PO_STATUS = @stat WHERE PO_NO = @no AND PO_STOCK = @stock1", conn)
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = MaskedTextBox3.Text
            cmd.Parameters.Add("@supp", SqlDbType.VarChar).Value = ComboBox1.SelectedValue
            cmd.Parameters.Add("@etd", SqlDbType.VarChar).Value = MaskedTextBox1.Text
            cmd.Parameters.Add("@sect", SqlDbType.VarChar).Value = ComboBox3.SelectedValue
            cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = TextBox3.Text
            cmd.Parameters.Add("@qty", SqlDbType.VarChar).Value = TextBox7.Text
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = TextBox4.Text
            cmd.Parameters.Add("@uom", SqlDbType.VarChar).Value = TextBox6.Text
            'cmd.Parameters.Add("@curr", SqlDbType.VarChar).Value = ComboBox1.Text
            cmd.Parameters.Add("@up", SqlDbType.VarChar).Value = TextBox8.Text
            cmd.Parameters.Add("@amt", SqlDbType.VarChar).Value = TextBox11.Text
            cmd.Parameters.Add("@mach", SqlDbType.VarChar).Value = ComboBox2.Text
            cmd.Parameters.Add("@disc", SqlDbType.VarChar).Value = TextBox10.Text
            cmd.Parameters.Add("@tax", SqlDbType.VarChar).Value = TextBox9.Text
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = TextBox5.Text
            cmd.Parameters.Add("@machd", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
            cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = ComboBox4.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@stock1", SqlDbType.VarChar).Value = TextBox13.Text
            cmd.ExecuteNonQuery()
            conn.Close()
        End If

        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        DataGridView1.Enabled = False

        ' TextBox2.Text = ""
        ' ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        MaskedTextBox1.Text = ""
        ' MaskedTextBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""


        sodetails.Enabled = False
        stockdetails.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = 0
        i = DataGridView1.CurrentRow.Index

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_DATA WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = DataGridView1.Item(0, i).Value
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        ' TextBox2.Text = ""
        '  ComboBox1.SelectedValue = table.Rows(0)(0).ToString
        ComboBox2.SelectedValue = table.Rows(0)(16).ToString
        ComboBox3.SelectedValue = table.Rows(0)(4).ToString
        MaskedTextBox1.Text = table.Rows(0)(3).ToString
        ' MaskedTextBox3.Text = ""
        TextBox3.Text = DataGridView1.Item(0, i).Value
        TextBox13.Text = DataGridView1.Item(0, i).Value
        TextBox4.Text = table.Rows(0)(6).ToString
        TextBox5.Text = table.Rows(0)(15).ToString
        TextBox6.Text = table.Rows(0)(8).ToString
        TextBox7.Text = table.Rows(0)(7).ToString
        TextBox8.Text = table.Rows(0)(10).ToString
        TextBox9.Text = table.Rows(0)(14).ToString
        TextBox10.Text = table.Rows(0)(13).ToString
        TextBox11.Text = table.Rows(0)(11).ToString
        ComboBox4.Text = table.Rows(0)(17).ToString
        TextBox12.Text = Format(Val(table.Rows(0)(11).ToString) - Val(table.Rows(0)(13).ToString) - Val(table.Rows(0)(14).ToString), "0.00")
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchButton.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox4.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox3.Focus()
        End If
    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
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
            MaskedTextBox3.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
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
            TextBox7.Text = Format(Val(TextBox7.Text), "0.0000")
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox8.Text = Format(Val(TextBox8.Text), "0.0000")
            TextBox11.Focus()
        End If
    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox11.Text = Format(Val(TextBox11.Text), "0.00")
            TextBox10.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox10.Text = Format(Val(TextBox10.Text), "0.00")
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox12.Text = Val(TextBox11.Text) - Val(TextBox10.Text) - Val(TextBox9.Text)
            btnSave.Focus()
        End If
    End Sub

    Private Sub ComboBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As Integer = MessageBox.Show("Do you want to delete the stock no?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM SCO_DATA WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
            cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = TextBox13.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            search()
            CheckBox1.CheckState = CheckState.Unchecked
            'CheckBox2.CheckState = CheckState.Unchecked
            'DataGridView1.Enabled = False

            ' TextBox2.Text = ""
            ' ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0
            ComboBox3.SelectedIndex = 0
            MaskedTextBox1.Text = ""
            ' MaskedTextBox3.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""


            sodetails.Enabled = False
            stockdetails.Enabled = False
            btnSave.Enabled = False
            btnCancel.Enabled = False

        Else

        End If
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        Dim cmd As New SqlCommand("SELECT TAX_RATE FROM SCO_TAX WHERE TAX_STAT = 'True'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        TextBox9.Text = Val(TextBox11.Text) * Val(table.Rows(0)(0).ToString)

        TextBox12.Text = Val(TextBox11.Text) - Val(TextBox9.Text)
    End Sub
End Class