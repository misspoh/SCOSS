Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports Microsoft.Office.Interop.Excel

Public Class ExportToExcel
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub ExportToExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        conn = New SqlConnection(constr)

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        conn.Open()
        '  Dim cmd As New SqlCommand("SELECT  [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD] FROM SCO_DATA WHERE PO_DATE LIKE '" & MaskedTextBox1.Text & "%'", conn)
        Dim cmd As New SqlCommand("SELECT  [PO_NO] as 'P/O No',[PO_DATE] as Date,[PO_SUPP] as Supplier,[ETA_DATE] as 'ETA_Date',[PO_SECTION] as 'Plant',[PO_STOCK] as 'Stock No',[PO_DESC] as 'Description',[PO_QTY] as Qty,[PO_UOM] as UOM,[PO_CURR] as Currency,[PO_UPRICE] as 'U.Cosy',[PO_AMT] as Value,[PO_MACHN] as 'Machine No',[PO_DISCAMT] as 'Ttl Amt Disc',[PO_TAX] as 'Ttl Amt SST',[PO_INV] as 'Ref Inv.',[PO_MACHD] as 'Mach Desc.' FROM SCO_DATA WHERE PO_DATE LIKE '" & MaskedTextBox1.Text & "%'", conn)
        'cmd.Parameters.Add("@my", SqlDbType.VarChar).Value = MaskedTextBox1.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New System.Data.DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
            MsgBox("No data detected. Please try again")
        Else
            DataGridView1.DataSource = table
            ToolStripStatusLabel1.Text = "Total of SO: " & table.Rows.Count
        End If
        'Try

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If DataGridView1.Rows.Count = Nothing Then
            MsgBox("No data to export. Please try again.")
        Else
            '  wSheet.Columns.AutoFit()
            SaveFileDialog1.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls"
            Dim result As DialogResult = SaveFileDialog1.ShowDialog()
            Dim fullpath As String
            Dim strFileName As String

            ' Test result.
            If result = System.Windows.Forms.DialogResult.OK Then
                ' Do something.
                fullpath = SaveFileDialog1.FileName
                strFileName = fullpath

                If System.IO.File.Exists(strFileName) Then
                    System.IO.File.Delete(strFileName)
                End If

                conn.Open()
                'Dim cmd As New SqlCommand("SELECT AC_TICKET, AC_DONO, AC_VEHICLE, AC_CUST, AC_TRANS, AC_LOCA, AC_GROUP, AC_STATUS, AC_DATE, AC_TIMEIN, AC_TIMEOUT, AC_GROSS, AC_TARE, AC_NETT, AC_REMARKS, AC_RPN, AC_BATCH FROM LOG_TRANSACTION WHERE AC_STATUS = 'P' AND " & Filter(), conn)
                Dim cmd As New SqlCommand("SELECT  [PO_NO] as 'P/O No',[PO_DATE] as Date,[PO_SUPP] as Supplier,[ETA_DATE] as 'ETA_Date',[PO_SECTION] as 'Plant',[PO_STOCK] as 'Stock No',[PO_DESC] as 'Description',[PO_QTY] as Qty,[PO_UOM] as UOM,[PO_CURR] as Currency,[PO_UPRICE] as 'U.Cosy',[PO_AMT] as Value,[PO_MACHN] as 'Machine No',[PO_DISCAMT] as 'Ttl Amt Disc',[PO_TAX] as 'Ttl Amt SST',[PO_INV] as 'Ref Inv.',[PO_MACHD] as 'Mach Desc.' FROM SCO_DATA WHERE PO_DATE LIKE '" & MaskedTextBox1.Text & "%'", conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New System.Data.DataTable
                adapter.Fill(table)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim xcel As New Microsoft.Office.Interop.Excel.Application
                Dim wBook As Microsoft.Office.Interop.Excel.Workbook
                Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

                wBook = xcel.Workbooks.Add
                wSheet = wBook.ActiveSheet

                Dim dt As System.Data.DataTable = table
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                ToolStripProgressBar1.Maximum = table.Rows.Count

                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    xcel.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In dt.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0

                    For Each dc In dt.Columns
                        colIndex = colIndex + 1
                        xcel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next

                    ToolStripProgressBar1.Value += 1

                Next

                ' WORKSHEET FORMAT
                wSheet.Columns.WrapText = False
                wSheet.Range("K2:K1000").NumberFormat = "##0.00"
                wSheet.Range("L2:L1000").NumberFormat = "##0.00"

                wBook.SaveAs(strFileName, XlFileFormat.xlWorkbookNormal, Type.Missing, _
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                wBook.Close()
                xcel.Quit()
                ToolStripProgressBar1.Visible = False

                MsgBox("Export successful.")
                DataGridView1.DataSource = Nothing

                ToolStripStatusLabel1.Text = "Total of SO: "
                MaskedTextBox1.Text = ""
                ToolStripProgressBar1.Maximum = 0
            End If
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataGridView1.DataSource = Nothing

        ToolStripStatusLabel1.Text = "Total of SO: "
        MaskedTextBox1.Text = ""

    End Sub
End Class