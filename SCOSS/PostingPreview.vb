Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.IO
Imports CrystalDecisions.Shared

Public Class PostingPreview
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer
    Dim ds As New Report
    Dim printstat As Integer = 0
    Dim curr As String

    Private Sub PostingPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        '  conn.Open()
        '  Dim cmd As New SqlCommand("SELECT * FROM SCO_SUMM", conn)
        '  Dim adapter As New SqlDataAdapter(cmd)
        '  Dim table As New DataTable
        '  adapter.Fill(table)
        '  cmd.ExecuteNonQuery()
        '  conn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds.PostingPreview.Clear()

        Dim dt As New DataTable

        ' dt = Me.SCO_TEMPTableAdapter.GetDataBySCONO(TextBox1.Text)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT [SCO_NO],[SCO_CDATE],[SCO_SUPP],[SCO_CURR],[SCO_PURP],[SCO_RE],[SCO_STOCK],[SCO_ETA] ,[SCO_SECTION],[SCO_MACHNO],[SCO_PART],[SCO_INV],[SCO_UOM],[SCO_QTY],[SCO_UPRICE],[SCO_AMOUNT],[SCO_DISC],[SCO_TAX],[SCO_TOTAL],[SCO_CO],[SCO_PRINT] FROM SCO_TEMP WHERE SCO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        Dim adapter As New SqlDataAdapter(cmd)
        'Dim table As New DataTable
        adapter.Fill(dt)
        cmd.ExecuteNonQuery()
        conn.Close()

        '  Label1.Text = dt.Rows(0)(11).ToString.Substring(dt.Rows(0)(11).ToString.Length - 2)
        Dim prdtails As New DataTable

        conn.Open()
        Dim cmd1 As New SqlCommand("SELECT SO_NO, SO_DATE, PURPOSE_1, PURPOSE_2, PURPOSE_3, PURPOSE_4, PURPOSE_5, REMARKS_1, REMARKS_2, REMARKS_3, REMARKS_5, REMARKS_4 FROM SCO_SO WHERE (SO_NO = @no)", conn)
        cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        Dim adapter1 As New SqlDataAdapter(cmd1)
        adapter1.Fill(prdtails)
        cmd1.ExecuteNonQuery()
        conn.Close()

        If Sizecb.SelectedIndex = 0 Then
            MsgBox("Please choose paper size before proceed to ")
        ElseIf Sizecb.SelectedIndex = 1 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim suppadd, suppfax, supptel, suppdesc, machdesc, secdesc As String
                conn.Open()
                Dim cmd2 As New SqlCommand("SELECT SUPP_DESC, SUPP_ADDRESS, SUPP_FAX, SUPP_TEL FROM SCO_SUPP WHERE SUPP_CODE = @code ")
                cmd2.Parameters.Add("@no", SqlDbType.VarChar).Value = dt.Rows(i)(1).ToString
                Dim adapter2 As New SqlDataAdapter(cmd2)
                Dim table2 As New DataTable
                adapter2.Fill(table2)
                cmd2.ExecuteNonQuery()
                conn.Close()

                suppadd = table2.Rows(0)(1).ToString
                suppfax = table2.Rows(0)(2).ToString
                supptel = table2.Rows(0)(3).ToString
                suppdesc = table2.Rows(0)(0).ToString

                conn.Open()
                Dim cmd3 As New SqlCommand("SELECT MACH_DESC FROM SCO_MACH WHERE MACH_CODE = @code", conn)
                cmd3.Parameters.Add("@code", SqlDbType.VarChar).Value = dt.Rows(i)(9).ToString
                Dim adapter3 As New SqlDataAdapter(cmd3)
                Dim table3 As New DataTable
                adapter3.Fill(table3)
                cmd3.ExecuteNonQuery()
                conn.Close()

                machdesc = table3.Rows(0)(0).ToString

                conn.Open()
                Dim cmd4 As New SqlCommand("SELECT SEC_DESC FROM SCO_MACH WHERE SEC_CODE = @code", conn)
                cmd4.Parameters.Add("@code", SqlDbType.VarChar).Value = dt.Rows(i)(8).ToString
                Dim adapter4 As New SqlDataAdapter(cmd4)
                Dim table4 As New DataTable
                adapter4.Fill(table4)
                cmd4.ExecuteNonQuery()
                conn.Close()

                secdesc = table4.Rows(0)(0).ToString

                Dim newdata As DataRow = ds.PostingPreview.NewRow

                newdata("SONo") = dt.Rows(i)(0).ToString
                newdata("SDate") = dt.Rows(i)(1).ToString
                newdata("Supplier") = suppdesc
                newdata("Currency") = dt.Rows(i)(3).ToString
                newdata("Purpose") = dt.Rows(i)(4).ToString
                newdata("Remarks") = dt.Rows(i)(5).ToString
                newdata("StockNo") = dt.Rows(i)(6).ToString
                newdata("ETA") = dt.Rows(i)(7).ToString
                newdata("Section") = secdesc
                newdata("MachNo") = machdesc
                newdata("Part") = dt.Rows(i)(10).ToString
                newdata("Invoice") = dt.Rows(i)(11).ToString
                newdata("UOM") = dt.Rows(i)(12).ToString

                ' doesn't pass the decimals
                Dim d As String = dt.Rows(i)(13).ToString
                Dim j As String = d.Substring(d.Length - 2)

                If j = "00" Then
                    newdata("Qty") = Format(Val(dt.Rows(i)(11).ToString), "0.00")

                Else
                    newdata("Qty") = Format(Val(dt.Rows(i)(11).ToString), "0.0000")

                End If

                Dim d1 As String = dt.Rows(i)(14).ToString
                Dim j1 As String = d1.Substring(d1.Length - 2)

                If j1 = "00" Then
                    newdata("Uprice") = Format(Val(dt.Rows(i)(12).ToString), "0.00")

                Else
                    newdata("Uprice") = Format(Val(dt.Rows(i)(12).ToString), "0.0000")

                End If


                newdata("Amount") = Val(dt.Rows(i)(15).ToString)
                newdata("Discount") = Val(dt.Rows(i)(16).ToString)
                newdata("Tax") = Val(dt.Rows(i)(17).ToString)
                newdata("Total") = Val(dt.Rows(i)(15).ToString) - Val(dt.Rows(i)(16).ToString) - Val(dt.Rows(i)(17).ToString)
                newdata("Address") = suppadd
                newdata("Tel") = "Tel: " & supptel
                newdata("Fax") = "Fax: " & suppfax

                newdata("P1") = prdtails.Rows(0)(2).ToString
                newdata("P2") = prdtails.Rows(0)(3).ToString
                newdata("P3") = prdtails.Rows(0)(4).ToString
                newdata("P4") = prdtails.Rows(0)(5).ToString
                newdata("P5") = prdtails.Rows(0)(6).ToString
                newdata("R1") = prdtails.Rows(0)(7).ToString
                newdata("R2") = prdtails.Rows(0)(8).ToString
                newdata("R3") = prdtails.Rows(0)(9).ToString
                newdata("R4") = prdtails.Rows(0)(10).ToString
                newdata("R5") = prdtails.Rows(0)(11).ToString

                ds.PostingPreview.Rows.Add(newdata)

            Next

            ' a4 size

            ' 9.5" x 12" size
            Dim objrpt As New PreviewSP
            objrpt.SetDataSource(ds)
            '   objrpt.PrintOptions.PaperSize = PkSize
            ' Dim ftdate As String = MaskedTextBox1.Text & " - " & MaskedTextBox2.Text
            'objrpt.SetParameterValue("company", MainMenu.ToolStripStatusLabel3.Text)
            objrpt.SetParameterValue("Currency", dt.Rows(0)(3).ToString)
            'objrpt.SetParameterValue("prepared", PreparedBy.Text)
            'objrpt.SetParameterValue("confirmed", CheckedBy)
            'objrpt.SetParameterValue("authorised", RequestedBy)
            CrystalReportViewer1.ReportSource = objrpt
            CrystalReportViewer1.Refresh()

            printstat = 3

            curr = dt.Rows(0)(3).ToString
            ' curr = dt.Rows(0)(3).ToString
        Else

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim suppadd, supptel, suppfax As String
                Dim suppdesc, machdesc, secdesc As String

                conn.Open()
                Dim cmd2 As New SqlCommand("SELECT SUPP_DESC, SUPP_ADDRESS, SUPP_FAX, SUPP_TEL FROM SCO_SUPP WHERE SUPP_CODE = @code ", conn)
                cmd2.Parameters.Add("@code", SqlDbType.VarChar).Value = dt.Rows(i)(2).ToString
                Dim adapter2 As New SqlDataAdapter(cmd2)
                Dim table2 As New DataTable
                adapter2.Fill(table2)
                cmd2.ExecuteNonQuery()
                conn.Close()

                suppadd = table2.Rows(0)(1).ToString
                suppfax = table2.Rows(0)(2).ToString
                supptel = table2.Rows(0)(3).ToString
                suppdesc = table2.Rows(0)(0).ToString

                conn.Open()
                Dim cmd3 As New SqlCommand("SELECT MACH_DESC FROM SCO_MACH WHERE MACH_CODE = @code", conn)
                cmd3.Parameters.Add("@code", SqlDbType.VarChar).Value = dt.Rows(i)(9).ToString
                Dim adapter3 As New SqlDataAdapter(cmd3)
                Dim table3 As New DataTable
                adapter3.Fill(table3)
                cmd3.ExecuteNonQuery()
                conn.Close()

                machdesc = table3.Rows(0)(0).ToString

                conn.Open()
                Dim cmd4 As New SqlCommand("SELECT SEC_DESC FROM SCO_SECTION WHERE SEC_CODE = @code", conn)
                cmd4.Parameters.Add("@code", SqlDbType.VarChar).Value = dt.Rows(i)(8).ToString
                Dim adapter4 As New SqlDataAdapter(cmd4)
                Dim table4 As New DataTable
                adapter4.Fill(table4)
                cmd4.ExecuteNonQuery()
                conn.Close()

                secdesc = table4.Rows(0)(0).ToString

                Dim newdata As DataRow = ds.PostingPreview.NewRow

                newdata("SONo") = dt.Rows(i)(0).ToString
                newdata("SDate") = dt.Rows(i)(1).ToString
                newdata("Supplier") = suppdesc
                newdata("Currency") = dt.Rows(i)(3).ToString
                newdata("Purpose") = dt.Rows(i)(4).ToString
                newdata("Remarks") = dt.Rows(i)(5).ToString
                newdata("StockNo") = dt.Rows(i)(6).ToString
                newdata("ETA") = dt.Rows(i)(7).ToString
                newdata("Section") = secdesc
                newdata("MachNo") = machdesc
                newdata("Part") = dt.Rows(i)(10).ToString
                newdata("Invoice") = dt.Rows(i)(11).ToString
                newdata("UOM") = dt.Rows(i)(12).ToString

                ' doesn't pass the decimals
                Dim d As String = Format(Val(dt.Rows(i)(13).ToString), "0.0000")
                Dim j As String = d.Substring(d.Length - 2) ' startindex cannot be 

                If j = "00" Then
                    newdata("Qty") = Format(Val(dt.Rows(i)(13).ToString), "0.00")

                Else
                    newdata("Qty") = Format(Val(dt.Rows(i)(13).ToString), "0.0000")

                End If

                Dim d1 As String = dt.Rows(i)(14).ToString
                Dim j1 As String = d1.Substring(d1.Length - 2)

                If j1 = "00" Then
                    newdata("Uprice") = Format(Val(dt.Rows(i)(14).ToString), "0.00")

                Else
                    newdata("Uprice") = Format(Val(dt.Rows(i)(14).ToString), "0.0000")

                End If


                newdata("Amount") = Val(dt.Rows(i)(15).ToString)
                newdata("Discount") = Val(dt.Rows(i)(16).ToString)
                newdata("Tax") = Val(dt.Rows(i)(17).ToString)
                newdata("Total") = Val(dt.Rows(i)(15).ToString) - Val(dt.Rows(i)(16).ToString) - Val(dt.Rows(i)(17).ToString)
                newdata("Address") = suppadd
                newdata("Tel") = "Tel: " & supptel
                newdata("Fax") = "Fax: " & suppfax

                newdata("P1") = prdtails.Rows(0)(2).ToString
                newdata("P2") = prdtails.Rows(0)(3).ToString
                newdata("P3") = prdtails.Rows(0)(4).ToString
                newdata("P4") = prdtails.Rows(0)(5).ToString
                newdata("P5") = prdtails.Rows(0)(6).ToString
                newdata("R1") = prdtails.Rows(0)(7).ToString
                newdata("R2") = prdtails.Rows(0)(8).ToString
                newdata("R3") = prdtails.Rows(0)(9).ToString
                newdata("R4") = prdtails.Rows(0)(10).ToString
                newdata("R5") = prdtails.Rows(0)(11).ToString

                ds.PostingPreview.Rows.Add(newdata)

            Next

            Dim PkSize As New System.Drawing.Printing.PaperSize("9.5x12", 9.5, 12)

            ' 9.5" x 12" size
            Dim objrpt As New PreviewSON
            objrpt.SetDataSource(ds)
            '   objrpt.PrintOptions.PaperSize = PkSize
            ' Dim ftdate As String = MaskedTextBox1.Text & " - " & MaskedTextBox2.Text
            'objrpt.SetParameterValue("company", MainMenu.ToolStripStatusLabel3.Text)
            objrpt.SetParameterValue("Currency", dt.Rows(0)(3).ToString)
            CrystalReportViewer1.ReportSource = objrpt
            CrystalReportViewer1.Refresh()

            printstat = 3

            curr = dt.Rows(0)(3).ToString

        End If

    End Sub

    Private Sub PostingPreview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = ""
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()

        ' Me.Close()
    End Sub

    Private Sub oWindow_PrintButtonClicked(UseDefault As Boolean)
        Dim objectreport = CrystalReportViewer1.ReportSource
        Dim copies() As String = {"SUPPLIER COPY", "PAYMENT / ACCOUNT COPY", "FILE COPY", "STORE COPY"}
        'objectreport.PrintOut(False, 3)

        Dim i As Integer
        For i = 1 To 4

            objectreport.SetParameterValue("Copies", copies(i - 1))
            '...
            CrystalReportViewer1.Refresh()
            objectreport.PrintOut(True, 1)
        Next

        MsgBox("Print")
    End Sub

    Private Sub Frm_stampa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Hide default button
        CrystalReportViewer1.ShowPrintButton = False
        CrystalReportViewer1.ShowPrintButton = False

        ' New print button
        For Each ctrl As Control In CrystalReportViewer1.Controls

            If TypeOf ctrl Is Windows.Forms.ToolStrip Then
                If ctrl.Text = "Print" Then
                Else
                    Dim btnNew As New ToolStripButton

                    btnNew.Text = "Print"
                    btnNew.ToolTipText = "Print"
                    btnNew.Image = My.Resources.printer
                    btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image

                    CType(ctrl, ToolStrip).Items(0).Visible = False

                    CType(ctrl, ToolStrip).Items.Insert(0, btnNew)

                    AddHandler btnNew.Click, AddressOf tsItem_Click
                End If

            End If
        Next

        ' ---------------------------------------------
    End Sub

    Sub printBW()
        ' Put your code here, before print

        Dim PrintDialog As New PrintDialog()
        Dim objrpt As New PreviewSON

        If PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            objrpt.SetDataSource(ds)
            objrpt.SetParameterValue("Currency", curr)
            objrpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
            objrpt.PrintOptions.PaperSize = PaperSize.PaperFanfoldStdGerman
            objrpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)

            '  Me.SCO_TEMPTableAdapter.UpdateQueryPrintStat("PRINTED", TextBox1.Text)
            '  Me.SCO_BWTableAdapter.UpdateQueryPrintStat("PRINTED", TextBox1.Text)

            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_TEMP SET SCO_PRINT = @stat WHERE (SCO_NO = @no)", conn)
            cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = "PRINTED"
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim cmd1 As New SqlCommand("UPDATE SCO_DATA SET PO_STATUS = @stat WHERE PO_NO = @no", conn)
            cmd1.Parameters.Add("@stat", SqlDbType.VarChar).Value = "PRINTED"
            cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            cmd1.ExecuteNonQuery()
            conn.Close()

            PostingForm.emptysodetail()
            PostingForm.emptystockdetails()
            PostingForm.DataGridView1.Rows.Clear()
            reload()
        End If

    End Sub

    Sub printBWA4()
        ' Put your code here, before print

        Dim PrintDialog As New PrintDialog()
        Dim objrpt As New PreviewSO
        Dim copies() As String = {"SUPPLIER COPY", "PAYMENT / ACCOUNT COPY", "FILE COPY", "STORE COPY"}
        'objectreport.PrintOut(False, 3)

        If PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim copy As Integer = PrintDialog.PrinterSettings.Copies
            Dim collate As Boolean = PrintDialog.PrinterSettings.Collate
            Dim frompage As Integer = PrintDialog.PrinterSettings.FromPage
            Dim topage As Integer = PrintDialog.PrinterSettings.ToPage

            '  MsgBox(copy & collate & frompage & topage)

            Dim i As Integer
            For i = 0 To 3

                objrpt.SetDataSource(ds)

                objrpt.SetParameterValue("Copies", copies(i))
                objrpt.SetParameterValue("Currency", curr)

                objrpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                objrpt.PrintToPrinter(copy, collate, frompage, topage)

                '  objrpt.PrintOut(True, 1)
            Next

            ' Me.SCO_TEMPTableAdapter.UpdateQueryPrintStat("PRINTED", TextBox1.Text)
            ' Me.SCO_BWTableAdapter.UpdateQueryPrintStat("PRINTED", TextBox1.Text)

            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_TEMP SET SCO_PRINT = @stat WHERE (SCO_NO = @no)", conn)
            cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = "PRINTED"
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim cmd1 As New SqlCommand("UPDATE SCO_DATA SET PO_STATUS = @stat WHERE PO_NO = @no", conn)
            cmd1.Parameters.Add("@stat", SqlDbType.VarChar).Value = "PRINTED"
            cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            cmd1.ExecuteNonQuery()
            conn.Close()


            reload()

            PostingForm.emptysodetail()
            PostingForm.emptystockdetails()
            PostingForm.DataGridView1.Rows.Clear()
        End If

    End Sub
 
    Private Sub tsItem_Click()
        If printstat = 1 Then

            ' printBWA4()
            printstat = 0

        ElseIf printstat = 2 Then
            ' printGTA4()

            printstat = 0

        ElseIf printstat = 3 Then
            printBW()

            printstat = 0

        ElseIf printstat = 4 Then

            ' printGT()
            printstat = 0

        End If

    End Sub

    Private Sub reload()
        'Dim sender As Object
        Dim e As EventArgs

        Dim f1 As PostingForm = CType(Application.OpenForms("PostingForm"), PostingForm)

        f1.PostingForm_Load(e, e)
        f1.emptysodetail()
        f1.emptystockdetails()
        f1.DataGridView1.Rows.Clear()

        f1.btnPrint.Enabled = False

    End Sub
End Class