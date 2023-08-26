Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class PostingForm
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Sub loaddgv()
        DataGridView2.Rows.Clear()
        conn = New SqlConnection(constr)

        'con.ConnectionString = "Data Source=GT-SERVER01\EDP;Initial Catalog=SCO;Persist Security Info=True;User ID=sa;Password=Admin1"

        conn.Open()
        Dim cmd As New SqlCommand("SELECT DISTINCT SCO_NO,convert(varchar, SCO_CDATE, 103) , SCO_PRINT FROM SCO_TEMP WHERE SCO_PRINT = 'NOT PRINTED'", conn)

        Dim adap As New SqlDataAdapter(cmd)
        Dim datatab As New DataTable
        adap.Fill(datatab)
        cmd.ExecuteNonQuery()
        conn.Close()

        If datatab.Rows.Count = Nothing Then
        Else
            For i As Integer = 0 To datatab.Rows.Count - 1
                DataGridView2.Rows.Add(datatab.Rows(i)(0).ToString, datatab.Rows(i)(1).ToString, datatab.Rows(i)(2).ToString)
            Next
        End If
    End Sub

    Sub emptysodetail()
        Label4.Text = "-"
        SCONO.Text = "-"
        ' Suppliercb.Text = ""
        ' Plantcb.Text = ""
        ' Currencycb.Text = ""
        Purpose1.Text = ""
        Purpose2.Text = ""
        Purpose3.Text = ""
        Purpose4.Text = ""
        Remarks1.Text = ""
        Remarks2.Text = ""
        Remarks3.Text = ""
        Remarks4.Text = ""
        InvoiceNo.Text = ""
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False

    End Sub

    Sub emptystockdetails()
        StockNoTextBox.Text = ""
        EtaDate.Text = ""
        Particulars.Text = ""
        ' InvoiceNo.Text = ""
        UOMTextBox.Text = ""
        QTYTextBox.Text = ""
        UnitPriceTextBox.Text = ""
        AmountTextBox.Text = ""
        DiscountTextBox.Text = ""
        TaxTextBox.Text = ""
        roundTextbox.Text = ""
        TotalTextbox.Text = ""
    End Sub

    Sub prfalse()
        Purpose1.Visible = False
        Purpose2.Visible = False
        Purpose3.Visible = False
        Purpose4.Visible = False
        Purpose5.Visible = False
        Remarks1.Visible = False
        Remarks2.Visible = False
        Remarks3.Visible = False
        Remarks4.Visible = False
        Remarks5.Visible = False
    End Sub

    Sub loadParticular(c As String)

        If c = "" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            Suppliercb.DisplayMember = "SUPP_CBDESC"
            Suppliercb.ValueMember = "SUPP_CODE"
            Suppliercb.DataSource = table

            conn.Open()
            Dim cmd1 As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
            Dim adapter1 As New SqlDataAdapter(cmd1)
            Dim table1 As New DataTable
            adapter1.Fill(table1)
            cmd1.ExecuteNonQuery()
            conn.Close()

            Plantcb.DisplayMember = "SEC_DESC"
            Plantcb.ValueMember = "SEC_CODE"
            Plantcb.DataSource = table1

            conn.Open()
            Dim cmd2 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
            Dim adapter2 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adapter2.Fill(table2)
            cmd2.ExecuteNonQuery()
            conn.Close()

            Machinecb.DisplayMember = "MACH_CODE"
            Machinecb.ValueMember = "MACH_DESC"
            Machinecb.DataSource = table2
        ElseIf c = "1" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            Suppliercb.DisplayMember = "SUPP_CBDESC"
            Suppliercb.ValueMember = "SUPP_CODE"
            Suppliercb.DataSource = table

        ElseIf c = "2" Then
            conn.Open()
            Dim cmd1 As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
            Dim adapter1 As New SqlDataAdapter(cmd1)
            Dim table1 As New DataTable
            adapter1.Fill(table1)
            cmd1.ExecuteNonQuery()
            conn.Close()

            Plantcb.DisplayMember = "SEC_DESC"
            Plantcb.ValueMember = "SEC_CODE"
            Plantcb.DataSource = table1
        ElseIf c = "3" Then
            conn.Open()
            Dim cmd2 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
            Dim adapter2 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adapter2.Fill(table2)
            cmd2.ExecuteNonQuery()
            conn.Close()

            Machinecb.DisplayMember = "MACH_CODE"
            Machinecb.ValueMember = "MACH_DESC"
            Machinecb.DataSource = table2
        End If

    End Sub

    Sub PostingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd")
        loaddgv()

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        Suppliercb.DisplayMember = "SUPP_CBDESC"
        Suppliercb.ValueMember = "SUPP_CODE"
        Suppliercb.DataSource = table

        conn.Open()
        Dim cmd1 As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
        Dim adapter1 As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable
        adapter1.Fill(table1)
        cmd1.ExecuteNonQuery()
        conn.Close()

        Plantcb.DisplayMember = "SEC_DESC"
        Plantcb.ValueMember = "SEC_CODE"
        Plantcb.DataSource = table1

        conn.Open()
        Dim cmd2 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
        Dim adapter2 As New SqlDataAdapter(cmd2)
        Dim table2 As New DataTable
        adapter2.Fill(table2)
        cmd2.ExecuteNonQuery()
        conn.Close()

        Machinecb.DisplayMember = "MACH_CODE"
        Machinecb.ValueMember = "MACH_DESC"
        Machinecb.DataSource = table2

        conn.Open()
        Dim cmd3 As New SqlCommand("SELECT CURR_ID, CURR_DEFAULT FROM SCO_CURRENCY", conn)
        Dim adapter3 As New SqlDataAdapter(cmd3)
        Dim table3 As New DataTable
        adapter3.Fill(table3)
        cmd3.ExecuteNonQuery()
        conn.Close()

        Currencycb.DisplayMember = "CURR_ID"
        Currencycb.ValueMember = "CURR_ID"
        Currencycb.DataSource = table3

        ' default currency
        conn.Open()
        Dim cm As New SqlCommand("SELECT CURR_ID FROM SCO_CURRENCY WHERE CURR_DEFAULT = 'True'", conn)
        Dim a As New SqlDataAdapter(cm)
        Dim t As New DataTable
        a.Fill(t)
        cm.ExecuteNonQuery()
        conn.Close()

        Currencycb.SelectedValue = t.Rows(0)(0).ToString

        Me.WindowState = FormWindowState.Maximized
        KeyPreview = True
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MaskedTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd")
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnPrint.Enabled = False

        emptysodetail()
        emptystockdetails()
        DataGridView1.Rows.Clear()

        TextBox1.Text = "ADD"
        prfalse()

        ' buttons
        btnAddS.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = True
        btnCan.Enabled = True

        DiscountTextBox.ReadOnly = False
        roundTextbox.ReadOnly = False

        grandtotal.Text = ""

        ' current year
        Dim d As String = DateTime.Now.ToString("yyyy-MM-dd")
        ' MsgBox(d)
        Dim y As String = Mid(d, 1, 4)
        Dim d1 As String = "2021-01-01"
        Dim d2 As String = y & "-12-31"

        ' generate so no, increment 1
        conn.Open()
        Dim cmd As New SqlCommand("SELECT PO_NO FROM SCO_DATA WHERE PO_DATE BETWEEN '" & d1 & "' AND '" & d2 & "' ORDER BY PO_NO", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim lastindex As Integer = table.Rows.Count - 1

        Dim index As String = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)

        If index.Length = 1 Then
            SCONO.Text = "0000000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 2 Then
            SCONO.Text = "000000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 3 Then
            SCONO.Text = "00000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 4 Then
            SCONO.Text = "0000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 5 Then
            SCONO.Text = "000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 6 Then
            SCONO.Text = "00" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 7 Then
            SCONO.Text = "0" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 8 Then
            SCONO.Text = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        End If

        ' SCONO.Text = "0000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)

        Label24.Text = SCONO.Text

        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        Suppliercb.Focus()
        Label4.Text = "NOT PRINTED"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnPrint.Enabled = False

        Me.TabControl1.SelectedTab = Me.TabPage1
        Suppliercb.Focus()

        TextBox1.Text = "EDIT"

        GroupBox1.Enabled = False
        GroupBox2.Enabled = True

        ' buttons
        btnAddS.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = True
        btnCan.Enabled = True

    End Sub

    Private Sub Suppliercb_KeyDown(sender As Object, e As KeyEventArgs) Handles Suppliercb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim t As New DataTable

            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE FROM SCO_SUPP WHERE SUPP_CBDESC = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = Suppliercb.Text
            Dim a As New SqlDataAdapter(cmd)
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
                MsgBox("Please choose the right item in Supplier box.", MsgBoxStyle.OkOnly)
                Suppliercb.Focus()
            Else
                Currencycb.Focus()

            End If
        End If
    End Sub

    Private Sub Plantcb_KeyDown(sender As Object, e As KeyEventArgs) Handles Plantcb.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Plantcb.SelectedIndex = -1 Then
                MsgBox("Please choose data correctly.")
            Else
                Dim check As New DataTable

                conn.Open()
                Dim cmd As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM dbo.SCO_SECTION WHERE SEC_CODE = @code", conn)
                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = Plantcb.SelectedValue
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(check)
                cmd.ExecuteNonQuery()
                conn.Close()

                If check.Rows.Count = Nothing Then
                    MsgBox("Data not existed. Please choose existing data.")
                Else
                    EtaDate.Focus()
                End If

            End If
          
        End If
    End Sub

    Private Sub Currencycb_KeyDown(sender As Object, e As KeyEventArgs) Handles Currencycb.KeyDown
        If e.KeyCode = Keys.Enter Then


            Me.TabControl1.SelectedTab = Me.TabPage2
            Purpose1.Visible = True
            Purpose1.Focus()
        End If
    End Sub

    Private Sub Purpose1_KeyDown(sender As Object, e As KeyEventArgs) Handles Purpose1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Purpose2.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Purpose2.Visible = True
                    Purpose2.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage3
                    Remarks1.Visible = True
                    Remarks1.Focus()

                    Label26.Text = Purpose1.Text
                End If
            Else
                Purpose2.Visible = True
                Purpose2.Focus()
            End If

        End If
    End Sub

    Private Sub Purpose2_KeyDown(sender As Object, e As KeyEventArgs) Handles Purpose2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Purpose3.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Purpose3.Visible = True
                    Purpose3.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage3
                    Remarks1.Visible = True
                    Remarks1.Focus()
                    Label26.Text = Purpose1.Text & vbNewLine & Purpose2.Text
                End If
            Else
                Purpose3.Visible = True
                Purpose3.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Purpose FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Purpose2.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Purpose3_KeyDown(sender As Object, e As KeyEventArgs) Handles Purpose3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Purpose4.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Purpose4.Visible = True
                    Purpose4.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage3
                    Remarks1.Visible = True
                    Remarks1.Focus()
                    Label26.Text = Purpose1.Text & vbNewLine & Purpose2.Text & vbNewLine & Purpose3.Text
                End If
            Else
                Purpose4.Visible = True
                Purpose4.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Purpose FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Purpose3.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Purpose4_KeyDown(sender As Object, e As KeyEventArgs) Handles Purpose4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Purpose5.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Purpose5.Visible = True
                    Purpose5.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage3
                    Remarks1.Visible = True
                    Remarks1.Focus()
                    Label26.Text = Purpose1.Text & vbNewLine & Purpose2.Text & vbNewLine & Purpose3.Text & vbNewLine & Purpose4.Text
                End If
            Else
                Purpose5.Visible = True
                Purpose5.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Purpose FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Purpose4.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Purpose5_KeyDown(sender As Object, e As KeyEventArgs) Handles Purpose5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TabControl1.SelectedTab = Me.TabPage3
            Remarks1.Visible = True
            Remarks1.Focus()
            Label26.Text = Purpose1.Text & vbNewLine & Purpose2.Text & vbNewLine & Purpose3.Text & vbNewLine & Purpose4.Text & vbNewLine & Purpose5.Text
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Purpose FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Purpose5.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Remarks1_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Remarks2.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Remarks2.Visible = True
                    Remarks2.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage4
                    btnAddS.Focus()
                    Label27.Text = Remarks1.Text
                End If
            Else
                Remarks2.Visible = True
                Remarks2.Focus()
            End If
        End If
    End Sub

    Private Sub Remarks2_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Remarks3.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Remarks3.Visible = True
                    Remarks3.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage4
                    btnAddS.Focus()
                    Label27.Text = Remarks1.Text & vbNewLine & Remarks2.Text
                End If
            Else
                Remarks3.Visible = True
                Remarks3.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Remarks FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Remarks2.Text = t.Rows(0)(0).ToString

            End If

        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Remarks3_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Remarks4.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Remarks4.Visible = True
                    Remarks4.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage4
                    btnAddS.Focus()
                    Label27.Text = Remarks1.Text & vbNewLine & Remarks2.Text & vbNewLine & Remarks3.Text
                End If
            Else
                Remarks4.Visible = True
                Remarks4.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Remarks FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Remarks3.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Remarks4_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Remarks5.Text = "" Then
                Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Remarks5.Visible = True
                    Remarks5.Focus()
                Else
                    Me.TabControl1.SelectedTab = Me.TabPage4
                    btnAddS.Focus()
                    Label27.Text = Remarks1.Text & vbNewLine & Remarks2.Text & vbNewLine & Remarks3.Text & vbNewLine & Remarks4.Text
                End If
            Else
                Remarks5.Visible = True
                Remarks5.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Remarks FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Remarks4.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Remarks5_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TabControl1.SelectedTab = Me.TabPage4
            btnAddS.Focus()
            Label27.Text = Remarks1.Text & vbNewLine & Remarks2.Text & vbNewLine & Remarks3.Text & vbNewLine & Remarks4.Text & vbNewLine & Remarks5.Text

        ElseIf e.KeyCode = Keys.F1 Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Remarks FROM PR_SK", conn)
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                Remarks5.Text = t.Rows(0)(0).ToString

            End If
        ElseIf e.KeyCode = Keys.F2 Then
            PRCustom.ShowDialog()
        End If
    End Sub

    Private Sub Machinecb_KeyDown(sender As Object, e As KeyEventArgs) Handles Machinecb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim check As New DataTable

            conn.Open()
            Dim cmd As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM dbo.SCO_MACH WHERE MACH_CODE = @code", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = Machinecb.Text
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(check)
            cmd.ExecuteNonQuery()
            conn.Close()

            If check.Rows.Count = Nothing Then
                MsgBox("Data not existed. Please choose existing data.")
            Else
                Plantcb.Focus()
            End If
        End If
    End Sub

    Private Sub EtaDate_KeyDown(sender As Object, e As KeyEventArgs) Handles EtaDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            If EtaDate.MaskCompleted = True Then
            Else
                EtaDate.Text = "00/00/0000"
            End If

            If Particulars.Text = "" Then
                Particulars.Focus()
            Else
                Particulars.Focus()
                Particulars.Select(Particulars.Text.Length - 1, 0)
            End If
        End If
    End Sub

    Private Sub Particulars_KeyDown(sender As Object, e As KeyEventArgs) Handles Particulars.KeyDown
        If e.KeyCode = Keys.Enter Then

            InvoiceNo.Focus()
        End If
    End Sub

    Private Sub InvoiceNo_KeyDown(sender As Object, e As KeyEventArgs) Handles InvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            UOMTextBox.Focus()
        End If
    End Sub

    Private Sub UOMTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UOMTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            QTYTextBox.Focus()
        End If
    End Sub

    Private Sub QTYTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles QTYTextBox.KeyDown
        Dim result As Decimal = 0.0

        If e.KeyCode = Keys.Enter Then
            UnitPriceTextBox.Focus()
            QTYTextBox.Text = Format(Val(QTYTextBox.Text), "0.0000")
        End If
    End Sub

    ' Private Sub Taxcb_KeyDown(sender As Object, e As KeyEventArgs) Handles Taxcb.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '       UnitPriceTextBox.Focus()
    '  End If
    ' End Sub

    Private Sub UnitPriceTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UnitPriceTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            TaxTextBox.Focus()
            ' TaxTextBox .Text = AmountTextBox 
            UnitPriceTextBox.Text = Format(Val(UnitPriceTextBox.Text), "0.0000") * Val(Label29.Text)
        End If
    End Sub

    Private Sub DiscountTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DiscountTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            DiscountTextBox.Text = Format(Val(DiscountTextBox.Text), "0.00")
            roundTextbox.Focus()
        End If
    End Sub

    Private Sub TaxTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaxTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            TaxTextBox.Text = Format(Val(TaxTextBox.Text), "0.00")
            TotalTextbox.Text = Format(Val(AmountTextBox.Text) + Val(TaxTextBox.Text), "0.00")

            btnInsert.Focus()

        End If
    End Sub

    Private Sub roundTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles roundTextbox.KeyDown
        If e.KeyCode = Keys.Enter Then
           
            If Val(grandtotal.Text) = 0 Then
                MsgBox("Total must not be 0.0000. Please enter again.")
                QTYTextBox.Text = ""
                UnitPriceTextBox.Text = ""
                QTYTextBox.Focus()
            Else
                roundTextbox.Text = Format(Val(roundTextbox.Text), "0.00")
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub UnitPriceTextBox_TextChanged(sender As Object, e As EventArgs) Handles UnitPriceTextBox.TextChanged
        AmountTextBox.Text = Format(Val(QTYTextBox.Text) * Val(UnitPriceTextBox.Text), "0.00")
    End Sub

    Private Sub btnAddS_Click(sender As Object, e As EventArgs) Handles btnAddS.Click
        ' auto generate stock no from the latest stock no in database
        emptystockdetails()

        If DataGridView1.Rows.Count = Nothing Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT PO_STOCK, PO_DATE FROM SCO_DATA ORDER BY PO_DATE, PO_STOCK", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            Dim lastindex As Integer = table.Rows.Count - 1


            If IsNumeric(table.Rows(lastindex)(0).ToString) = True Then
                StockNoTextBox.Text = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)

                Machinecb.Focus()
            Else
                StockNoTextBox.ReadOnly = False
                StockNoTextBox.Focus()
            End If

        Else
            If TextBox1.Text = "ADD" Then
                Dim lastindex As Integer = DataGridView1.Rows.Count - 1

                Dim lateststock As String = DataGridView1.Rows(lastindex).Cells(0).Value

                Dim checkstock As String = lateststock.Substring(0, 1)

                If IsNumeric(checkstock) Then
                    StockNoTextBox.Text = Val(Integer.Parse(lateststock) + 1)
                    Machinecb.Focus()
                Else
                    Machinecb.Focus()
                End If
            ElseIf TextBox1.Text = "EDIT" Then
                conn.Open()
                Dim cmd As New SqlCommand("SELECT PO_STOCK, PO_DATE FROM SCO_DATA ORDER BY PO_DATE, PO_STOCK", conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable
                adapter.Fill(table)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim lastindex As Integer = table.Rows.Count - 1

                If IsNumeric(table.Rows(lastindex)(0).ToString) = True Then
                    StockNoTextBox.Text = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)

                    Machinecb.Focus()
                Else
                    StockNoTextBox.ReadOnly = False
                    StockNoTextBox.Focus()
                End If
              
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Do you want to delete the stock?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            DataGridView1.Rows.RemoveAt(i)
            emptystockdetails()
        Else
            MsgBox("Deletion cancelled.", MsgBoxStyle.OkOnly, "Abort")
        End If
      
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim result As Integer = MessageBox.Show("Do you want to add stock?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            If TextBox1.Text = "ADD" Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If StockNoTextBox.Text = DataGridView1.Item(0, i).Value Then
                        ' MsgBox("yes")
                        DataGridView1.Rows.RemoveAt(i)

                        Exit For
                    Else

                    End If
                Next

                ' insert into the datagridview temporarily
                DataGridView1.Rows.Add(StockNoTextBox.Text, Plantcb.SelectedValue, Machinecb.Text, EtaDate.Text, Particulars.Text, InvoiceNo.Text, UOMTextBox.Text, QTYTextBox.Text, UnitPriceTextBox.Text, AmountTextBox.Text, TaxTextBox.Text)
                emptystockdetails()
                btnAddS.Focus()
            ElseIf TextBox1.Text = "EDIT" Then
                ' insert into the datagridview temporarily

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If StockNoTextBox.Text = DataGridView1.Item(0, i).Value Then
                        ' MsgBox("yes")
                        DataGridView1.Rows.RemoveAt(i)

                        Exit For
                    Else

                    End If
                Next

                DataGridView1.Rows.Add(StockNoTextBox.Text, Plantcb.SelectedValue, Machinecb.Text, EtaDate.Text, Particulars.Text, InvoiceNo.Text, UOMTextBox.Text, QTYTextBox.Text, UnitPriceTextBox.Text, AmountTextBox.Text, TaxTextBox.Text)
                emptystockdetails()
                btnAddS.Focus()
            End If
        Else
            If TextBox1.Text = "ADD" Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If StockNoTextBox.Text = DataGridView1.Item(0, i).Value Then
                        ' MsgBox("yes")
                        DataGridView1.Rows.RemoveAt(i)

                        Exit For
                    Else

                    End If
                Next

                ' insert into the datagridview temporarily
                DataGridView1.Rows.Add(StockNoTextBox.Text, Plantcb.SelectedValue, Machinecb.Text, EtaDate.Text, Particulars.Text, InvoiceNo.Text, UOMTextBox.Text, QTYTextBox.Text, UnitPriceTextBox.Text, AmountTextBox.Text, TaxTextBox.Text)
                emptystockdetails()
                DiscountTextBox.Focus()
            ElseIf TextBox1.Text = "EDIT" Then
                ' insert into the datagridview temporarily
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If StockNoTextBox.Text = DataGridView1.Item(0, i).Value Then
                        ' MsgBox("yes")
                        DataGridView1.Rows.RemoveAt(i)

                        Exit For
                    Else

                    End If
                Next
                DataGridView1.Rows.Add(StockNoTextBox.Text, Plantcb.SelectedValue, Machinecb.Text, EtaDate.Text, Particulars.Text, InvoiceNo.Text, UOMTextBox.Text, QTYTextBox.Text, UnitPriceTextBox.Text, AmountTextBox.Text, TaxTextBox.Text)
                emptystockdetails()
                DiscountTextBox.Focus()
            End If
        End If

        DataGridView1.Sort(DataGridView1.Columns(0), ListSortDirection.Ascending)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim comp As String = AppConfigReader.COName

        If DataGridView1.Rows.Count = Nothing Then
            MsgBox("Please insert stock details before saving")
        Else
            If TextBox1.Text = "ADD" Then
                TextBox1.Text = ""
                Dim tempdate As String = DateTime.Now.ToString("yyyy-MM-dd")

                ' INSERT INTO SCO_SO
                conn.Open()
                Dim cmd2 As New SqlCommand("INSERT INTO SCO_SO (SO_NO, SO_DATE, PURPOSE_1, PURPOSE_2, PURPOSE_3, PURPOSE_4, PURPOSE_5, REMARKS_1, REMARKS_2, REMARKS_3, REMARKS_4, REMARKS_5) VALUES ( '" & SCONO.Text & "', '" & tempdate & "', @p1, @p2, @p3, @p4, @p5, @r1, @r2, @r3, @r4, @r5)", conn)
                cmd2.Parameters.Add("@p1", SqlDbType.VarChar).Value = Purpose1.Text
                cmd2.Parameters.Add("@p2", SqlDbType.VarChar).Value = Purpose2.Text
                cmd2.Parameters.Add("@p3", SqlDbType.VarChar).Value = Purpose3.Text
                cmd2.Parameters.Add("@p4", SqlDbType.VarChar).Value = Purpose4.Text
                cmd2.Parameters.Add("@p5", SqlDbType.VarChar).Value = Purpose5.Text
                cmd2.Parameters.Add("@r1", SqlDbType.VarChar).Value = Remarks1.Text
                cmd2.Parameters.Add("@r2", SqlDbType.VarChar).Value = Remarks2.Text
                cmd2.Parameters.Add("@r3", SqlDbType.VarChar).Value = Remarks3.Text
                cmd2.Parameters.Add("@r4", SqlDbType.VarChar).Value = Remarks4.Text
                cmd2.Parameters.Add("@r5", SqlDbType.VarChar).Value = Remarks5.Text
                cmd2.ExecuteNonQuery()
                conn.Close()

                Dim j As Integer = 1

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    ' = Me.SCO_MACHTableAdapter.GetDataByMachDesc()

                    ' searching march description
                    Dim md As String

                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH WHERE MACH_CODE = @code", conn)
                    cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = DataGridView1.Item(2, i).Value
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim ttb As New DataTable
                    adapter.Fill(ttb)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    ' machine description is assigned in this variable
                    md = ttb.Rows(0)(1).ToString

                    'insert into SCO_DATA

                    conn.Open()
                    Dim command As New SqlCommand("INSERT INTO SCO_DATA ([PO_NO],[PO_DATE],[PO_SUPP] ,[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD] ,[PO_STATUS], [PO_ROUND]) VALUES (@no,@date,@supp,@eta,@section,@stock ,@desc,@qty,@uom,@curr ,@uprice,@amt,@machn,@discamt,@tax,@inv,@machd,@stat, @round)", conn)
                    command.Parameters.Add("@no", SqlDbType.VarChar).Value = SCONO.Text
                    command.Parameters.Add("@date", SqlDbType.Date).Value = tempdate
                    command.Parameters.Add("@supp", SqlDbType.VarChar).Value = Suppliercb.SelectedValue
                    command.Parameters.Add("@eta", SqlDbType.VarChar).Value = DataGridView1.Item(3, i).Value
                    command.Parameters.Add("@section", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    command.Parameters.Add("@stock", SqlDbType.VarChar).Value = DataGridView1.Item(0, i).Value
                    command.Parameters.Add("@desc", SqlDbType.VarChar).Value = DataGridView1.Item(4, i).Value
                    command.Parameters.Add("@qty", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(7, i).Value), "0.0000")
                    command.Parameters.Add("@uom", SqlDbType.VarChar).Value = DataGridView1.Item(6, i).Value
                    command.Parameters.Add("@curr", SqlDbType.VarChar).Value = Currencycb.Text
                    command.Parameters.Add("@uprice", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(8, i).Value), "0.0000")
                    command.Parameters.Add("@amt", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(9, i).Value), "0.00")
                    command.Parameters.Add("@machn", SqlDbType.VarChar).Value = DataGridView1.Item(2, i).Value


                    ' different command
                    If i = 0 Then
                        command.Parameters.Add("@discamt", SqlDbType.Decimal).Value = Format(Val(DiscountTextBox.Text), "0.00")
                        command.Parameters.Add("@round", SqlDbType.Decimal).Value = Format(Val(roundTextbox.Text), "0.00")

                    Else
                        command.Parameters.Add("@discamt", SqlDbType.Decimal).Value = Format(Val(0), "0.00")
                        command.Parameters.Add("@round", SqlDbType.Decimal).Value = Format(Val(0), "0.00")

                    End If

                    ' command.Parameters.Add("@discamt", SqlDbType.Decimal).Value = Format(Val(DiscountTextBox.Text), "0.00")
                    command.Parameters.Add("@tax", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(10, i).Value), "0.00")
                    command.Parameters.Add("@inv", SqlDbType.VarChar).Value = DataGridView1.Item(5, i).Value
                    command.Parameters.Add("@machd", SqlDbType.VarChar).Value = md ' machine description is use here
                    command.Parameters.Add("@stat", SqlDbType.VarChar).Value = "NOT PRINTED"
                    'command.Parameters.Add("@round", SqlDbType.Decimal).Value = Format(Val(roundTextbox.Text), "0.00")
                    command.ExecuteNonQuery()
                    conn.Close()

                    ' Me.SCO_BWTableAdapter.Insert(SCONO.Text, Label6.Text, Suppliercb.SelectedValue, DataGridView1.Item(3, i).Value, DataGridView1.Item(1, i).Value, Val(DataGridView1.Item(0, i).Value), DataGridView1.Item(4, i).Value, Val(DataGridView1.Item(7, i).Value), DataGridView1.Item(6, i).Value, Currencycb.Text, Val(DataGridView1.Item(8, i).Value), Val(DataGridView1.Item(9, i).Value), DataGridView1.Item(2, i).Value, Val(DataGridView1.Item(10, i).Value), Val(DataGridView1.Item(11, i).Value), DataGridView1.Item(5, i).Value, md, "NOT PRINTED")

                    ' bhgian tok ja. mun still lama error, ku terpaksa molah cara open and close
                    ' yang atas ya
                    ' INSERT INTO SCO_DAILY
                    ' error sitok 
                    ' Me.SCO_DAILYTableAdapter.Insert(Val(j), SCONO.Text, Label6.Text, Suppliercb.SelectedValue, DataGridView1.Item(2, i).Value, Plantcb.SelectedValue, DataGridView1.Item(0, i).Value, DataGridView1.Item(3, i).Value, DataGridView1.Item(6, i).Value, DataGridView1.Item(5, i).Value, Currencycb.SelectedValue, Val(DataGridView1.Item(7, i).Value), Val(DataGridView1.Item(8, i).Value), DataGridView1.Item(1, i).Value, DataGridView1.Item(9, i).Value, DataGridView1.Item(10, i).Value, InvoiceNo.Text, Machinecb.SelectedValue, "", "", "BW")

                    Dim total As Decimal = Format(Val(DataGridView1.Item(8, i).Value) - Val(DataGridView1.Item(9, i).Value) - Val(DataGridView1.Item(10, i).Value), "0.00")
                    Dim purpose As String = Purpose1.Text & " " & Purpose2.Text & " " & Purpose3.Text & " " & Purpose4.Text & " " & Purpose5.Text
                    Dim remarks As String = Remarks1.Text & " " & Remarks2.Text & " " & Remarks3.Text & " " & Remarks4.Text & " " & Remarks5.Text

                    conn.Open()
                    Dim cmd1 As New SqlCommand("INSERT INTO SCO_TEMP ([SCO_NO],[SCO_CDATE],[SCO_SUPP],[SCO_CURR],[SCO_PURP],[SCO_RE],[SCO_STOCK],[SCO_ETA],[SCO_SECTION],[SCO_MACHNO],[SCO_PART],[SCO_INV],[SCO_UOM],[SCO_QTY],[SCO_UPRICE],[SCO_AMOUNT],[SCO_DISC],[SCO_TAX],[SCO_TOTAL],[SCO_CO],[SCO_PRINT], [SCO_ROUND]) VALUES ('" & SCONO.Text & "','" & tempdate & "','" & Label25.Text & "','" & Currencycb.Text & "',@purpose, @remarks,'" & DataGridView1.Item(0, i).Value & "','" & DataGridView1.Item(3, i).Value & "', @section ,'" & DataGridView1.Item(2, i).Value & "' , @desc,'" & DataGridView1.Item(5, i).Value & "','" & DataGridView1.Item(6, i).Value & "','" & Val(DataGridView1.Item(7, i).Value) & "','" & Val(DataGridView1.Item(8, i).Value) & "','" & Val(DataGridView1.Item(9, i).Value) & "', @discount,'" & Val(DataGridView1.Item(10, i).Value) & "'," & total & ", '" & comp & "' , 'NOT PRINTED',@round )", conn)
                    cmd1.Parameters.Add("@section", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    cmd1.Parameters.Add("@desc", SqlDbType.VarChar).Value = DataGridView1.Item(4, i).Value
                    ' cmd1.Parameters.Add("@desc", SqlDbType.VarChar).Value = 
                    cmd1.Parameters.Add("@purpose", SqlDbType.VarChar).Value = purpose
                    cmd1.Parameters.Add("@remarks", SqlDbType.VarChar).Value = remarks

                    If i = 0 Then
                        cmd1.Parameters.Add("@discount", SqlDbType.Decimal).Value = Val(DiscountTextBox.Text)
                        cmd1.Parameters.Add("@round", SqlDbType.Decimal).Value = Val(roundTextbox.Text)
                    Else
                        cmd1.Parameters.Add("@discount", SqlDbType.Decimal).Value = 0
                        cmd1.Parameters.Add("@round", SqlDbType.Decimal).Value = 0
                    End If
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                    j += 1

                Next

                '  MsgBox(Label6.Text)
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                emptysodetail()
                emptystockdetails()
                DataGridView1.Rows.Clear()
                btnAddS.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnCan.Enabled = False

            ElseIf TextBox1.Text = "EDIT" Then

                ' deleting the existing data in master database = SCO_DATA

                conn.Open()
                Dim comd As New SqlCommand("DELETE FROM SCO_DATA WHERE PO_NO = @no", conn)
                comd.Parameters.Add("@no", SqlDbType.VarChar).Value = SCONO.Text
                'comd.Parameters.Add("@co", SqlDbType.VarChar).Value = MainMenu.ToolStripStatusLabel1.Text
                comd.ExecuteNonQuery()
                conn.Close()

                '  Me.SCO_SOTableAdapter.DeleteQueryByNo(SCONO.Text)
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM [SCO_SO] WHERE SO_NO = @so", conn)
                cmd.Parameters.Add("@so", SqlDbType.VarChar).Value = SCONO.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                conn.Open()
                Dim cmd2 As New SqlCommand("INSERT INTO SCO_SO (SO_NO, SO_DATE, PURPOSE_1, PURPOSE_2, PURPOSE_3, PURPOSE_4, PURPOSE_5, REMARKS_1, REMARKS_2, REMARKS_3, REMARKS_4, REMARKS_5) VALUES ( '" & SCONO.Text & "', '" & MaskedTextBox1.Text & "', @p1, @p2, @p3, @p4, @p5, @r1, @r2, @r3, @r4, @r5)", conn)
                cmd2.Parameters.Add("@p1", SqlDbType.VarChar).Value = Purpose1.Text
                cmd2.Parameters.Add("@p2", SqlDbType.VarChar).Value = Purpose2.Text
                cmd2.Parameters.Add("@p3", SqlDbType.VarChar).Value = Purpose3.Text
                cmd2.Parameters.Add("@p4", SqlDbType.VarChar).Value = Purpose4.Text
                cmd2.Parameters.Add("@p5", SqlDbType.VarChar).Value = Purpose5.Text
                cmd2.Parameters.Add("@r1", SqlDbType.VarChar).Value = Remarks1.Text
                cmd2.Parameters.Add("@r2", SqlDbType.VarChar).Value = Remarks2.Text
                cmd2.Parameters.Add("@r3", SqlDbType.VarChar).Value = Remarks3.Text
                cmd2.Parameters.Add("@r4", SqlDbType.VarChar).Value = Remarks4.Text
                cmd2.Parameters.Add("@r5", SqlDbType.VarChar).Value = Remarks5.Text
                cmd2.ExecuteNonQuery() ' * primary key
                conn.Close()

                ' update if the user edit the data
                ' Me.SCO_TEMPTableAdapter.DeleteQueryStock(SCONO.Text, MainMenu.ToolStripStatusLabel1.Text)
                conn.Open()
                Dim cmd3 As New SqlCommand("DELETE FROM SCO_TEMP WHERE SCO_NO = @no", conn)
                cmd3.Parameters.Add("@no", SqlDbType.VarChar).Value = SCONO.Text
                cmd3.ExecuteNonQuery()
                conn.Close()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1

                    Dim md As String

                    ' Dim dt1 As String = Convert.ToDateTime().ToString("yyyy-MM-dd")
                    Dim total As Decimal = Format(Val(DataGridView1.Item(8, i).Value) - Val(DataGridView1.Item(9, i).Value) - Val(DataGridView1.Item(10, i).Value), "0.00")
                    Dim purpose As String = Purpose1.Text & " " & Purpose2.Text & " " & Purpose3.Text & " " & Purpose4.Text & " " & Purpose5.Text
                    Dim remarks As String = Remarks1.Text & " " & Remarks2.Text & " " & Remarks3.Text & " " & Remarks4.Text & " " & Remarks5.Text

                    conn.Open()
                    Dim cmd5 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM dbo.SCO_MACH WHERE MACH_CODE = @code", conn)
                    cmd5.Parameters.Add("@code", SqlDbType.VarChar).Value = DataGridView1.Item(2, i).Value
                    Dim adapter As New SqlDataAdapter(cmd5)
                    Dim ttb As New DataTable
                    adapter.Fill(ttb)
                    cmd5.ExecuteNonQuery()
                    conn.Close()

                    md = ttb.Rows(0)(1).ToString

                    conn.Open()
                    Dim cmd1 As New SqlCommand("INSERT INTO SCO_TEMP ([SCO_NO],[SCO_CDATE],[SCO_SUPP],[SCO_CURR],[SCO_PURP],[SCO_RE],[SCO_STOCK],[SCO_ETA],[SCO_SECTION],[SCO_MACHNO],[SCO_PART],[SCO_INV],[SCO_UOM],[SCO_QTY],[SCO_UPRICE],[SCO_AMOUNT],[SCO_DISC],[SCO_TAX],[SCO_TOTAL],[SCO_CO],[SCO_PRINT], [SCO_ROUND]) VALUES ('" & SCONO.Text & "','" & MaskedTextBox1.Text & "','" & Suppliercb.SelectedValue & "','" & Currencycb.Text & "',@purpose, @remarks,'" & DataGridView1.Item(0, i).Value & "','" & DataGridView1.Item(3, i).Value & "',@section,'" & DataGridView1.Item(2, i).Value & "',@desc,'" & DataGridView1.Item(5, i).Value & "','" & DataGridView1.Item(6, i).Value & "','" & Val(DataGridView1.Item(7, i).Value) & "','" & Val(DataGridView1.Item(8, i).Value) & "','" & Val(DataGridView1.Item(9, i).Value) & "',@discount,'" & Val(DataGridView1.Item(10, i).Value) & "'," & total & ", '" & comp & "' , 'NOT PRINTED', @round)", conn)
                    cmd1.Parameters.Add("@section", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    cmd1.Parameters.Add("@desc", SqlDbType.VarChar).Value = DataGridView1.Item(4, i).Value
                    cmd1.Parameters.Add("@purpose", SqlDbType.VarChar).Value = purpose
                    cmd1.Parameters.Add("@remarks", SqlDbType.VarChar).Value = remarks
                    If i = 0 Then
                        cmd1.Parameters.Add("@discount", SqlDbType.Decimal).Value = Val(DiscountTextBox.Text)
                        cmd1.Parameters.Add("@round", SqlDbType.Decimal).Value = Val(roundTextbox.Text)
                    Else
                        cmd1.Parameters.Add("@discount", SqlDbType.Decimal).Value = 0
                        cmd1.Parameters.Add("@round", SqlDbType.Decimal).Value = 0
                    End If
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                    '  Me.SCO_TEMPTableAdapter.UpdateQueryPS(DataGridView1.Item(1, i).Value, SCONO.Text)

                    conn.Open()
                    Dim command As New SqlCommand("INSERT INTO SCO_DATA ([PO_NO],[PO_DATE],[PO_SUPP] ,[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD] ,[PO_STATUS], [PO_ROUND]) VALUES (@no,@date,@supp,@eta,@section,@stock ,@desc,@qty,@uom,@curr ,@uprice,@amt,@machn,@discamt,@tax,@inv,@machd,@stat, @round)", conn)
                    command.Parameters.Add("@no", SqlDbType.VarChar).Value = SCONO.Text
                    command.Parameters.Add("@date", SqlDbType.Date).Value = MaskedTextBox1.Text
                    command.Parameters.Add("@supp", SqlDbType.VarChar).Value = Suppliercb.SelectedValue
                    command.Parameters.Add("@eta", SqlDbType.VarChar).Value = DataGridView1.Item(3, i).Value
                    command.Parameters.Add("@section", SqlDbType.VarChar).Value = DataGridView1.Item(1, i).Value
                    command.Parameters.Add("@stock", SqlDbType.VarChar).Value = DataGridView1.Item(0, i).Value
                    command.Parameters.Add("@desc", SqlDbType.VarChar).Value = DataGridView1.Item(4, i).Value
                    command.Parameters.Add("@qty", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(7, i).Value), "0.0000")
                    command.Parameters.Add("@uom", SqlDbType.VarChar).Value = DataGridView1.Item(6, i).Value
                    command.Parameters.Add("@curr", SqlDbType.VarChar).Value = Currencycb.Text
                    command.Parameters.Add("@uprice", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(8, i).Value), "0.0000")
                    command.Parameters.Add("@amt", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(9, i).Value), "0.00")
                    command.Parameters.Add("@machn", SqlDbType.VarChar).Value = DataGridView1.Item(2, i).Value

                    ' different command
                    If i = 0 Then
                        command.Parameters.Add("@discamt", SqlDbType.Decimal).Value = Format(Val(DiscountTextBox.Text), "0.00")
                        command.Parameters.Add("@round", SqlDbType.Decimal).Value = Format(Val(roundTextbox.Text), "0.00")

                    Else
                        command.Parameters.Add("@discamt", SqlDbType.Decimal).Value = Format(Val(0), "0.00")
                        command.Parameters.Add("@round", SqlDbType.Decimal).Value = Format(Val(0), "0.00")

                    End If

                    command.Parameters.Add("@tax", SqlDbType.Decimal).Value = Format(Val(DataGridView1.Item(10, i).Value), "0.00")
                    command.Parameters.Add("@inv", SqlDbType.VarChar).Value = DataGridView1.Item(5, i).Value
                    command.Parameters.Add("@machd", SqlDbType.VarChar).Value = md
                    command.Parameters.Add("@stat", SqlDbType.VarChar).Value = "NOT PRINTED"
                    command.ExecuteNonQuery()
                    conn.Close()

                Next

                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

                emptysodetail()
                emptystockdetails()
                DataGridView1.Rows.Clear()
                btnAddS.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnCan.Enabled = False
            End If

            loaddgv()

            TextBox1.Text = ""
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnPrint.Enabled = False
            DiscountTextBox.ReadOnly = True
            roundTextbox.ReadOnly = True
            grandtotal.Text = ""
        End If

        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub btnCan_Click(sender As Object, e As EventArgs) Handles btnCan.Click
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnPrint.Enabled = False

        TextBox1.Text = ""

        DataGridView1.Rows.Clear()
        purposeremarks()
        emptysodetail()
        emptystockdetails()
        Me.TabControl1.SelectedTab = Me.TabPage1

        btnAddS.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCan.Enabled = False
        DiscountTextBox.ReadOnly = True
        roundTextbox.ReadOnly = True
        grandtotal.Text = ""
    End Sub

    Sub purposeremarks()
        Purpose1.Visible = False
        Purpose2.Visible = False
        Purpose3.Visible = False
        Purpose4.Visible = False
        Remarks1.Visible = False
        Remarks2.Visible = False
        Remarks3.Visible = False
        Remarks4.Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = 0
        i = DataGridView1.CurrentRow.Index
        StockNoTextBox.Text = DataGridView1.Item(0, i).Value
        Plantcb.SelectedValue = DataGridView1.Item(1, i).Value
        Dim t As New DataTable

        conn.Open()
        Dim cmd5 As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM dbo.SCO_MACH WHERE MACH_CODE = @code", conn)
        cmd5.Parameters.Add("@code", SqlDbType.VarChar).Value = DataGridView1.Item(2, i).Value
        Dim adapter As New SqlDataAdapter(cmd5)
        adapter.Fill(t)
        cmd5.ExecuteNonQuery()
        conn.Close()

        Machinecb.SelectedValue = t.Rows(0)(1).ToString
        EtaDate.Text = DataGridView1.Item(3, i).Value
        Particulars.Text = DataGridView1.Item(4, i).Value
        InvoiceNo.Text = DataGridView1.Item(5, i).Value
        UOMTextBox.Text = DataGridView1.Item(6, i).Value
        QTYTextBox.Text = DataGridView1.Item(7, i).Value
        UnitPriceTextBox.Text = DataGridView1.Item(8, i).Value
        AmountTextBox.Text = DataGridView1.Item(9, i).Value
        ' DiscountTextBox.Text = DataGridView1.Item(10, i).Value
        TaxTextBox.Text = DataGridView1.Item(10, i).Value
        ' roundTextbox.Text = DataGridView1.Item(12, i).Value
        TotalTextbox.Text = Format(Val(AmountTextBox.Text) + Val(TaxTextBox.Text), "0.00")

    End Sub

    Sub emptyPR()
        Purpose1.Text = ""
        Purpose2.Text = ""
        Purpose3.Text = ""
        Purpose4.Text = ""
        Purpose5.Text = ""
        Remarks1.Text = ""
        Remarks2.Text = ""
        Remarks3.Text = ""
        Remarks4.Text = ""
        Remarks5.Text = ""

        Purpose1.Visible = False
        Purpose2.Visible = False
        Purpose3.Visible = False
        Purpose4.Visible = False
        Purpose5.Visible = False
        Remarks1.Visible = False
        Remarks2.Visible = False
        Remarks3.Visible = False
        Remarks4.Visible = False
        Remarks5.Visible = False
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        emptyPR()
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnPrint.Enabled = True

        Me.TabControl1.SelectedTab = Me.TabPage1

        DataGridView1.Rows.Clear()

        Dim rowindex As Integer
        rowindex = DataGridView2.CurrentRow.Index

        ' search for the particulars
        conn.Open()
        Dim comm As New SqlCommand("SELECT SCO_NO, SCO_SUPP, SCO_CURR, SCO_PURP, SCO_RE, SCO_STOCK, SCO_ETA, SCO_SECTION, SCO_MACHNO, SCO_INV, SCO_UOM, SCO_QTY, SCO_UPRICE, SCO_AMOUNT, SCO_DISC, SCO_TAX, SCO_TOTAL, SCO_CDATE, SCO_PART, SCO_CO, SCO_PRINT, SCO_ROUND FROM SCO_TEMP WHERE SCO_NO = @no", conn)
        comm.Parameters.Add("@no", SqlDbType.VarChar).Value = DataGridView2.Item(0, rowindex).Value
        Dim ad As New SqlDataAdapter(comm)
        Dim table As New DataTable
        ad.Fill(table)
        comm.ExecuteNonQuery()
        conn.Close()

        Dim datatab As New DataTable

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_SO WHERE SO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = DataGridView2.Item(0, rowindex).Value
        Dim adap As New SqlDataAdapter(cmd)
        adap.Fill(datatab)
        cmd.ExecuteNonQuery()
        conn.Close()

        Label4.Text = table.Rows(0)(20).ToString
        SCONO.Text = table.Rows(0)(0).ToString
        Suppliercb.SelectedValue = table.Rows(0)(1).ToString
        Plantcb.SelectedValue = table.Rows(0)(7).ToString
        Currencycb.Text = table.Rows(0)(2).ToString

        Dim tmp As String = table.Rows(0)(17).ToString
        Dim tmpdt As String = tmp.Substring(0, 10)

        Dim oDate As DateTime = Convert.ToDateTime(table.Rows(0)(17).ToString)

        MaskedTextBox1.Text = oDate.ToString("yyyy-MM-dd")
        ' prtrue()

        If datatab.Rows(0)(2).ToString = "" Then
        Else
            Purpose1.Visible = True
            Purpose1.Text = datatab.Rows(0)(2).ToString
        End If

        If datatab.Rows(0)(3).ToString = "" Then
        Else
            Purpose2.Visible = True
            Purpose2.Text = datatab.Rows(0)(3).ToString
        End If

        If datatab.Rows(0)(4).ToString = "" Then
        Else
            Purpose3.Visible = True
            Purpose3.Text = datatab.Rows(0)(4).ToString
        End If

        If datatab.Rows(0)(5).ToString = "" Then
        Else
            Purpose4.Visible = True
            Purpose4.Text = datatab.Rows(0)(5).ToString
        End If

        If datatab.Rows(0)(6).ToString = "" Then
        Else
            Purpose5.Visible = True
            Purpose5.Text = datatab.Rows(0)(6).ToString
        End If

        If datatab.Rows(0)(7).ToString = "" Then
        Else
            Remarks1.Visible = True
            Remarks1.Text = datatab.Rows(0)(7).ToString
        End If


        If datatab.Rows(0)(8).ToString = "" Then
        Else
            Remarks2.Visible = True
            Remarks2.Text = datatab.Rows(0)(8).ToString
        End If

        If datatab.Rows(0)(9).ToString = "" Then
        Else
            Remarks3.Visible = True
            Remarks3.Text = datatab.Rows(0)(9).ToString
        End If

        If datatab.Rows(0)(10).ToString = "" Then
        Else
            Remarks4.Visible = True
            Remarks4.Text = datatab.Rows(0)(10).ToString
        End If

        If datatab.Rows(0)(11).ToString = "" Then
        Else
            Remarks5.Visible = True
            Remarks5.Text = datatab.Rows(0)(11).ToString
        End If

        conn.Open()
        Dim cmd1 As New SqlCommand("SELECT SCO_STOCK, SCO_SECTION, SCO_MACHNO, SCO_ETA, SCO_PART, SCO_INV, SCO_UOM, SCO_QTY, SCO_UPRICE, SCO_AMOUNT, SCO_DISC, SCO_TAX, SCO_ROUND FROM SCO_TEMP WHERE SCO_NO = @no", conn)
        cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = DataGridView2.Item(0, rowindex).Value
        Dim adapter As New SqlDataAdapter(cmd1)
        Dim dt As New DataTable
        adapter.Fill(dt)
        cmd1.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To dt.Rows.Count - 1
            DataGridView1.Rows.Add(dt.Rows(i)(0).ToString, dt.Rows(i)(1).ToString, dt.Rows(i)(2).ToString, dt.Rows(i)(3).ToString, dt.Rows(i)(4).ToString, dt.Rows(i)(5).ToString, dt.Rows(i)(6).ToString, dt.Rows(i)(7).ToString, dt.Rows(i)(8).ToString, dt.Rows(i)(9).ToString, dt.Rows(i)(11).ToString)

        Next

        DiscountTextBox.Text = dt.Rows(0)(10).ToString
        roundTextbox.Text = dt.Rows(0)(12).ToString

        Dim totalso As Decimal = 0
        Dim totaltax As Decimal = 0

        For i = 0 To DataGridView1.Rows.Count - 1
            totalso += Val(DataGridView1.Item(9, i).Value)
            totaltax += Val(DataGridView1.Item(10, i).Value)
        Next

        grandtotal.Text = Format(totalso + totaltax - Val(DiscountTextBox.Text) + Val(roundTextbox.Text), "0.00")


        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Private Sub Machinecb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Machinecb.SelectedIndexChanged
        ToolStripStatusLabel1.Text = Machinecb.SelectedValue
    End Sub

    Private Sub Suppliercb_SelectedValueChanged(sender As Object, e As EventArgs) Handles Suppliercb.SelectedValueChanged
        If Suppliercb.SelectedValue > 0 Then
            Label25.Text = Suppliercb.SelectedValue
            Label28.Text = Suppliercb.Text
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ChangeStatus.ShowDialog()
    End Sub

    Private Sub PostingForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.W Then
            If Button1.Visible = True Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
        End If
    End Sub

    Sub suppnoti()
        Dim result As Integer = MessageBox.Show("Supplier: " & Suppliercb.Text & vbCrLf & vbCrLf & "Proceed to Print?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Preview.TextBox1.Text = SCONO.Text
            Preview.ShowDialog()
        Else

        End If

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        suppnoti()
    End Sub

    Private Sub QTYTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (Not Char.IsControl(e.KeyChar) _
                     AndAlso (Not Char.IsDigit(e.KeyChar) _
                     AndAlso (e.KeyChar <> Microsoft.VisualBasic.ChrW(46)))) Then
            e.Handled = True
        End If
    End Sub

    Private Sub UnitPriceTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (Not Char.IsControl(e.KeyChar) _
             AndAlso (Not Char.IsDigit(e.KeyChar) _
             AndAlso (e.KeyChar <> Microsoft.VisualBasic.ChrW(46)))) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        Supplier.ShowDialog()
    End Sub

    Private Sub tbnMachine_Click(sender As Object, e As EventArgs) Handles tbnMachine.Click
        Machine.ShowDialog()
    End Sub

    Private Sub btnSection_Click(sender As Object, e As EventArgs) Handles btnSection.Click
        Section.ShowDialog()
    End Sub

    Private Sub StockNoTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles StockNoTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Machinecb.Focus()
        End If
    End Sub

    Private Sub Currencycb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Currencycb.SelectedIndexChanged
        conn.Open()
        Dim cmd As New SqlCommand("SELECT CURR_EXRATE FROM SCO_CURRENCY WHERE CURR_ID = @id", conn)
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Currencycb.SelectedValue
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        Label29.Text = table.Rows(0)(0).ToString
    End Sub

    Private Sub AmountTextBox_TextChanged(sender As Object, e As EventArgs) Handles AmountTextBox.TextChanged
        conn.Open()
        Dim cmd As New SqlCommand("SELECT TAX_RATE FROM SCO_TAX WHERE TAX_STAT = 'True'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        TaxTextBox.Text = Val(AmountTextBox.Text) * Val(table.Rows(0)(0).ToString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Application.OpenForms().OfType(Of Tax).Any Then
            MsgBox("Import form already open.")
        Else
            '  Dim newform As New Supplier

            ' newform.MdiParent = Me
            ' newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 10)
            Tax.Show()
        End If
    End Sub

    Private Sub roundTextbox_TextChanged(sender As Object, e As EventArgs) Handles roundTextbox.TextChanged
        Dim totalso As Decimal = 0
        Dim totaltax As Decimal = 0

        For i = 0 To DataGridView1.Rows.Count - 1
            totalso += Val(DataGridView1.Item(9, i).Value)
            totaltax += Val(DataGridView1.Item(10, i).Value)
        Next

        grandtotal.Text = Format(totalso + totaltax - Val(DiscountTextBox.Text) + Val(roundTextbox.Text), "0.00")

    End Sub
End Class