Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class EnquiriesForm
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Sub stylerow()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue

            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White

            End If

        Next
    End Sub

    Private Sub EnquiriesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT DISTINCT YEAR(PO_DATE) AS YEAR FROM SCO_DATA ORDER BY YEAR(PO_DATE)", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        Yearcb.DisplayMember = "YEAR"
        Yearcb.ValueMember = "YEAR"
        Yearcb.DataSource = table
       
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer

        ' get the index of the selected datagridview row
        index = e.RowIndex

        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)

        PO_DATETextBox.Text = Format(Convert.ToDateTime(selectedRow.Cells(1).Value.ToString()), "dd/MM/yyyy")
        PO_NOTextBox.Text = selectedRow.Cells(0).Value.ToString()
        PO_SUPPTextBox.Text = selectedRow.Cells(2).Value.ToString()
        MaskedTextBox1.Text = selectedRow.Cells(15).Value.ToString()
        PO_SECTIONTextBox.Text = selectedRow.Cells(3).Value.ToString()
        PO_STOCKTextBox.Text = selectedRow.Cells(16).Value.ToString()
        PO_DESCTextBox.Text = selectedRow.Cells(4).Value.ToString()
        PO_QTYTextBox.Text = selectedRow.Cells(8).Value.ToString()
        PO_UOMTextBox.Text = selectedRow.Cells(7).Value.ToString()
        PO_CURRTextBox.Text = selectedRow.Cells(6).Value.ToString()
        PO_UPRICETextBox.Text = selectedRow.Cells(9).Value.ToString()
        PO_AMTTextBox.Text = selectedRow.Cells(10).Value.ToString()
        PO_MACHNTextBox.Text = selectedRow.Cells(5).Value.ToString()
        PO_DISCAMTTextBox.Text = selectedRow.Cells(11).Value.ToString()
        PO_TAXTextBox.Text = selectedRow.Cells(12).Value.ToString()
        PO_INVTextBox.Text = selectedRow.Cells(13).Value.ToString()
        PO_MACHDTextBox.Text = selectedRow.Cells(14).Value.ToString()
        PurposeTextBox.Text = selectedRow.Cells(17).Value.ToString()
        RemarksTextBox.Text = selectedRow.Cells(18).Value.ToString()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            searchcb.DisplayMember = "SEC_DESC"
            searchcb.ValueMember = "SEC_CODE"
            searchcb.DataSource = table

            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
        Else

            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            searchcb.DataSource = Nothing
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            searchcb.DisplayMember = "SUPP_CBDESC"
            searchcb.ValueMember = "SUPP_CODE"
            searchcb.DataSource = table

            CheckBox1.Enabled = False
            CheckBox3.Enabled = False
        Else
            
            CheckBox1.Enabled = True
            CheckBox3.Enabled = True
            searchcb.DataSource = Nothing
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            searchcb.DisplayMember = "MACH_DESC"
            searchcb.ValueMember = "MACH_CODE"
            searchcb.DataSource = table

            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
        Else

            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            searchcb.DataSource = Nothing
        End If
    End Sub

    Sub emptydetails()
        PO_DATETextBox.Text = ""
        PO_NOTextBox.Text = ""
        PO_SUPPTextBox.Text = ""
        MaskedTextBox1.Text = ""
        PO_SECTIONTextBox.Text = ""
        PO_STOCKTextBox.Text = ""
        PO_DESCTextBox.Text = ""
        PO_QTYTextBox.Text = ""
        PO_UOMTextBox.Text = ""
        PO_CURRTextBox.Text = ""
        PO_UPRICETextBox.Text = ""
        PO_AMTTextBox.Text = ""
        PO_MACHNTextBox.Text = ""
        PO_DISCAMTTextBox.Text = ""
        PO_TAXTextBox.Text = ""
        PO_INVTextBox.Text = ""
        PO_MACHDTextBox.Text = ""
        PurposeTextBox.Text = ""
        RemarksTextBox.Text = ""
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If sotxt.Text = "" And stocktxt.Text = "" And fromtxt.MaskCompleted = False And totxt.MaskCompleted = False And invtxt.Text = "" And invdtxt.MaskCompleted = False And searchtxt.Text = "" Then

            MsgBox("Please enter the search particular to proceed.")
        Else
            If sotxt.Text = "" Then
            Else
                findsono(sotxt.Text)
            End If

            If stocktxt.Text = "" Then
            Else
                findstockno(stocktxt.Text)
            End If

            If fromtxt.MaskCompleted = False Then
            Else
                findfromdt(fromtxt.Text, totxt.Text)
            End If

            If invtxt.Text = "" Then
            Else
                findinv(invtxt.Text, invdtxt.Text)
            End If

            If searchtxt.Text = "" Then
            Else
                findsearch(searchtxt.Text)
            End If
        End If
    End Sub

    Sub findsono(sn As String)
        conn = New SqlConnection(constr)

        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_NO = @no ORDER BY SCO_DATA.PO_DATE", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sn
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        DataGridView1.Rows.Clear()
        emptydetails()

        For i As Integer = 0 To table.Rows.Count - 1
            purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
            remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

            Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

            DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

            amount = amount + Val(table.Rows(i)(11).ToString)
            tax = tax + Val(table.Rows(i)(14).ToString)
        Next

        gtotal = amount - tax

        ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
        ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
        ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
        ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
    End Sub

    Sub findstockno(sn As String)

        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_STOCK = @no ORDER BY SCO_DATA.PO_DATE", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sn
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        DataGridView1.Rows.Clear()
        emptydetails()

        For i As Integer = 0 To table.Rows.Count - 1
            purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
            remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

            Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

            DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

            amount = amount + Val(table.Rows(i)(11).ToString)
            tax = tax + Val(table.Rows(i)(14).ToString)
        Next
        gtotal = amount - tax

        ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
        ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
        ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
        ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
    End Sub

    Sub findfromdt(fromdt As String, todt As String)
        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        conn = New SqlConnection(constr)

        If todt = "" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE (CONVERT (DATE, SCO_DATA.PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = fromdt
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            DataGridView1.Rows.Clear()
            emptydetails()

            For i As Integer = 0 To table.Rows.Count - 1
                purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
                remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

                Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

                DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

                amount = amount + Val(table.Rows(i)(11).ToString)
                tax = tax + Val(table.Rows(i)(14).ToString)
            Next
            gtotal = amount - tax

            ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
            ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
            ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
            ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE (CONVERT (DATE, SCO_DATA.PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, SCO_DATA.PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = fromdt
            cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = todt
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            DataGridView1.Rows.Clear()
            emptydetails()

            For i As Integer = 0 To table.Rows.Count - 1
                purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
                remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

                Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

                DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

                amount = amount + Val(table.Rows(i)(11).ToString)
            Next
            gtotal = amount - tax

            ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
            ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
            ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
            ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
        End If
    End Sub

    Sub findinv(inv As String, invd As String)
        conn = New SqlConnection(constr)

        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        If invd = "" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_INV = @inv ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = inv
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            DataGridView1.Rows.Clear()
            emptydetails()

            For i As Integer = 0 To table.Rows.Count - 1
                purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
                remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

                Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

                DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

                amount = amount + Val(table.Rows(i)(11).ToString)
                tax = tax + Val(table.Rows(i)(14).ToString)
            Next
            gtotal = amount - tax

            ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
            ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
            ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
            ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
        ElseIf inv = "" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.ETA_DATE = @inv ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = invd
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            DataGridView1.Rows.Clear()
            emptydetails()

            For i As Integer = 0 To table.Rows.Count - 1
                purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
                remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

                Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

                DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

                amount = amount + Val(table.Rows(i)(11).ToString)
                tax = tax + Val(table.Rows(i)(14).ToString)
            Next
            gtotal = amount - tax

            ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
            ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
            ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
            ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_INV = @inv AND SCO_DATA.ETA_DATE = @invd ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = inv
            cmd.Parameters.Add("@invd", SqlDbType.VarChar).Value = invd
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            DataGridView1.Rows.Clear()
            emptydetails()

            For i As Integer = 0 To table.Rows.Count - 1
                purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
                remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

                Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

                DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

                amount = amount + Val(table.Rows(i)(11).ToString)
                tax = tax + Val(table.Rows(i)(14).ToString)
            Next
            gtotal = amount - tax

            ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
            ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
            ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
            ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
        End If
        
    End Sub

    Sub findsearch(s As String)
        conn = New SqlConnection(constr)

        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        Dim table As New DataTable

        conn.Open()
        If CheckBox1.CheckState = CheckState.Checked Then
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_SECTION = @no ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = s
            Dim adapter As New SqlDataAdapter(cmd)

            adapter.Fill(table)
            cmd.ExecuteNonQuery()
        ElseIf CheckBox2.CheckState = CheckState.Checked Then
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_SUPP = @no ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = s
            Dim adapter As New SqlDataAdapter(cmd)

            adapter.Fill(table)
            cmd.ExecuteNonQuery()
        ElseIf CheckBox3.CheckState = CheckState.Checked Then
            Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE SCO_DATA.PO_MACHN = @no ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = s
            Dim adapter As New SqlDataAdapter(cmd)

            adapter.Fill(table)
            cmd.ExecuteNonQuery()
        End If
       
        conn.Close()

        DataGridView1.Rows.Clear()
        emptydetails()

        For i As Integer = 0 To table.Rows.Count - 1
            purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
            remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

            Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

            DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

            amount = amount + Val(table.Rows(i)(11).ToString)
            tax = tax + Val(table.Rows(i)(14).ToString)
        Next
        gtotal = amount - tax

        ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
        ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
        ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
        ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        DataGridView1.Rows.Clear()
        emptydetails()

        EnquiriesForm_Load(e, e)

        sotxt.Text = ""
        stocktxt.Text = ""
        fromtxt.Text = ""
        totxt.Text = ""
        invtxt.Text = ""
        invdtxt.Text = ""
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
        CheckBox3.CheckState = CheckState.Unchecked
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        searchtxt.Text = ""
        searchcb.DataSource = Nothing

    End Sub

    Private Sub searchcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles searchcb.SelectedIndexChanged
        searchtxt.Text = searchcb.SelectedValue
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Yearcb.SelectedIndexChanged
        DataGridView1.Rows.Clear()

        Dim purpose, remarks As String
        Dim amount As Decimal = 0
        Dim tax As Decimal = 0
        Dim gtotal As Decimal = 0

        conn.Open()
        Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.[PO_DATE],SCO_DATA.[PO_SUPP],SCO_DATA.[ETA_DATE],SCO_DATA.[PO_SECTION],SCO_DATA.[PO_STOCK],SCO_DATA.[PO_DESC],SCO_DATA.[PO_QTY],SCO_DATA.[PO_UOM],SCO_DATA.[PO_CURR],SCO_DATA.[PO_UPRICE],SCO_DATA.[PO_AMT],SCO_DATA.[PO_MACHN],SCO_DATA.[PO_DISCAMT],SCO_DATA.[PO_TAX],SCO_DATA.[PO_INV],SCO_DATA.[PO_MACHD],SCO_DATA.[PO_STATUS],SCO_SO.PURPOSE_1,SCO_SO.PURPOSE_2,SCO_SO.PURPOSE_3,SCO_SO.PURPOSE_4,SCO_SO.PURPOSE_5, SCO_SO.REMARKS_1, SCO_SO.REMARKS_2, SCO_SO.REMARKS_3, SCO_SO.REMARKS_4, SCO_SO.REMARKS_5 FROM [SCO_DATA] INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE YEAR(SCO_DATA.PO_DATE) = @year ORDER BY SCO_DATA.PO_DATE, SCO_DATA.PO_NO", conn)
        cmd.Parameters.Add("@year", SqlDbType.VarChar).Value = Yearcb.SelectedValue
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            purpose = table.Rows(i)(18).ToString & " " & table.Rows(i)(19).ToString & " " & table.Rows(i)(20).ToString & " " & table.Rows(i)(21).ToString & " " & table.Rows(i)(22).ToString
            remarks = table.Rows(i)(23).ToString & " " & table.Rows(i)(24).ToString & " " & table.Rows(i)(25).ToString & " " & table.Rows(i)(26).ToString & " " & table.Rows(i)(27).ToString

            Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)

            DataGridView1.Rows.Add(table.Rows(i)(0).ToString, Format(oDate, "dd/MM/yyyy"), table.Rows(i)(2).ToString, table.Rows(i)(4).ToString, table.Rows(i)(6).ToString, table.Rows(i)(12).ToString, table.Rows(i)(9).ToString, table.Rows(i)(8).ToString, table.Rows(i)(7).ToString, table.Rows(i)(10).ToString, table.Rows(i)(11).ToString, table.Rows(i)(13).ToString, table.Rows(i)(14).ToString, table.Rows(i)(15).ToString, table.Rows(i)(16).ToString, table.Rows(i)(3).ToString, table.Rows(i)(5).ToString, purpose, remarks)

            amount = amount + Val(table.Rows(i)(11).ToString)
            tax = tax + Val(table.Rows(i)(14).ToString)
        Next

        gtotal = amount - tax

        ToolStripStatusLabel1.Text = "Total Service Order: " & Format(table.Rows.Count, "#,##0")
        ToolStripStatusLabel2.Text = "Total Amount: " & Format(amount, "#,##0.00")
        ToolStripStatusLabel3.Text = "Total Tax: " & Format(tax, "#,##0.00")
        ToolStripStatusLabel4.Text = "Grand Total: " & Format(gtotal, "#,##0.00")

    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged

        ' search in combobox 

        If searchtxt.Text = "" Then
        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP WHERE SUPP_CODE LIKE '@code%'", conn)
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = searchtxt.Text
            Dim ad As New SqlDataAdapter(cmd)
            Dim tb As New DataTable
            ad.Fill(tb)
            cmd.ExecuteNonQuery()
            conn.Close()

            searchcb.DisplayMember = "SUPP_CBDESC"
            searchcb.ValueMember = "SUPP_CODE"
            searchcb.DataSource = tb

        End If

    End Sub
End Class