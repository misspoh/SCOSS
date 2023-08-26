Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.IO

Public Class ExportToAcc
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub ExportToAcc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        conn.Open()
        Dim cmd As New SqlCommand("SELECT DISTINCT PO_NO, PO_DATE, PO_SUPP, SUM(PO_AMT), SUM(PO_DISCAMT), SUM(PO_TAX)  FROM SCO_DATA WHERE (CONVERT (DATE, SCO_DATA.PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, SCO_DATA.PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND PO_STATUS <> 'CANCELLED' GROUP BY PO_NO, PO_DATE, PO_SUPP", conn)
        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        ' Dim totalamt As Decimal = val(table.Rows(i)(3).ToString) - val(table.Rows(i)(4).ToString)

        '        con.Open()
        '        Dim comm As New SqlCommand("SELECT PO_SECTION, COUNT([PO_SECTION]) AS TOTAL FROM [SCO].[dbo].[SCO_BW] WHERE PO_NO = @no GROUP BY PO_SECTION ORDER BY COUNT(PO_SECTION) ", con)
        '        comm.Parameters.Add("@no", SqlDbType.VarChar).Value = T.Rows(0)(0).ToString
        '        Dim ad As New SqlDataAdapter(comm)
        '        Dim tb As New DataTable
        '        ad.Fill(tb)
        '        comm.ExecuteNonQuery()
        '        con.Close()

        For i As Integer = 0 To table.Rows.Count - 1
            Dim totalamt As Decimal = Val(table.Rows(i)(3).ToString) - Val(table.Rows(i)(4).ToString) + Val(table.Rows(i)(5).ToString)

            ' check for section
            conn.Open()
            Dim comm As New SqlCommand("SELECT PO_SECTION, COUNT([PO_SECTION]) AS TOTAL FROM [SCO_DATA] WHERE PO_NO = @no GROUP BY PO_SECTION ORDER BY COUNT(PO_SECTION) ", conn)
            comm.Parameters.Add("@no", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
            Dim ad As New SqlDataAdapter(comm)
            Dim tb As New DataTable
            ad.Fill(tb)
            comm.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim comm1 As New SqlCommand("SELECT * FROM SCO_SO WHERE SO_NO = @no", conn)
            comm1.Parameters.Add("@no", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
            Dim ad1 As New SqlDataAdapter(comm1)
            Dim tb1 As New DataTable
            ad1.Fill(tb1)
            comm1.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim comm2 As New SqlCommand("SELECT * FROM SCO_SUPP WHERE SUPP_CODE = @no", conn)
            comm2.Parameters.Add("@no", SqlDbType.VarChar).Value = table.Rows(i)(2).ToString
            Dim ad2 As New SqlDataAdapter(comm2)
            Dim tb2 As New DataTable
            ad2.Fill(tb2)
            comm2.ExecuteNonQuery()
            conn.Close()

            Dim last As Integer = tb.Rows.Count - 1

            Dim oDate As DateTime = Convert.ToDateTime(table.Rows(i)(1).ToString)
            If tb.Rows.Count > 1 Then
                'R("PO_NO") = T.Rows(i)(0).ToString
                'R("PO_DATE") = T.Rows(i)(1).ToString
                'R("PO_SUPP") = T.Rows(i)(2).ToString
                'R("PO_SECTION") = tb.Rows(last)(0).ToString
                'R("PO_AMT") = T.Rows(i)(3).ToString

                DataGridView1.Rows.Add("01", "RM" & table.Rows(i)(0).ToString, tb.Rows(last)(0).ToString, Format(oDate, "dd/MM/yy"), "00/00/00", totalamt, table.Rows(i)(2).ToString, "N", "00/00/00", tb1.Rows(0)(2).ToString, tb1.Rows(0)(7).ToString, "", "", "", "", "00/00/00", "", "00/00/00", tb2.Rows(0)(1).ToString, "0", "", "0", tb2.Rows(0)(3).ToString, tb2.Rows(0)(5).ToString)
            Else
                'R("PO_NO") = T.Rows(i)(0).ToString
                'R("PO_DATE") = T.Rows(i)(1).ToString
                'R("PO_SUPP") = T.Rows(i)(2).ToString
                'R("PO_SECTION") = tb.Rows(last)(0).ToString
                'R("PO_AMT") = T.Rows(i)(3).ToString
                DataGridView1.Rows.Add("01", "RM" & table.Rows(i)(0).ToString, tb.Rows(last)(0).ToString, Format(oDate, "dd/MM/yy"), "00/00/00", totalamt, table.Rows(i)(2).ToString, "N", "00/00/00", tb1.Rows(0)(2).ToString, tb1.Rows(0)(7).ToString, "", "", "", "", "00/00/00", "", "00/00/00", tb2.Rows(0)(1).ToString, "0", "", "0", tb2.Rows(0)(3).ToString, tb2.Rows(0)(5).ToString)
            End If

        Next

        ToolStripStatusLabel1.Text = "Total Service Order: " & table.Rows.Count

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        Dim result As DialogResult = SaveFileDialog1.ShowDialog()

        ' Test result.
        If result = Windows.Forms.DialogResult.OK Then
            ' Do something.
            TextBox1.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim writer As TextWriter = New StreamWriter(TextBox1.Text)
        Dim id As String
        Dim orderno As String

        Dim fPath = TextBox1.Text
        'Dim afile As New IO.StreamWriter(fPath, True)
        ' afile.WriteLine("hello")

        ' Dim file As System.IO.StreamWriter
        Dim plant As String
        Dim dt As String
        Dim dd As String
        Dim amt As String
        Dim suppac As String
        Dim stat As String
        Dim canceld As String
        Dim purpose As String
        Dim remarks As String
        Dim charge As String
        Dim ceaf As String
        Dim autho As String
        Dim creatby As String
        Dim creaton As String
        Dim modifby As String
        Dim modifon As String
        Dim suppname As String
        Dim acctype As String
        Dim accid As String
        Dim gstamt As String
        Dim gstno As String
        Dim brn As String

        ' if mainmenu.toolstripstatuslabel1.text = "BW" then

        ' Dim path As String = OpenFileDialog1.FileName

        Dim sqlquery As String = ""

        'If ComboBox1.Text = "BW" Then
        '    sqlquery = "SELECT DISTINCT [PO_NO],[PO_DATE],[PO_SUPP] ,SUM([PO_AMT]) AS PO_AMT FROM SCO_DATA WHERE CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103) GROUP BY PO_NO, PO_DATE, PO_SUPP"
        'ElseIf ComboBox1.Text = "GT" Then
        '    sqlquery = "SELECT DISTINCT [PO_NO],[PO_DATE],[PO_SUPP] ,SUM([PO_AMT]) AS PO_AMT FROM SCO_DATA WHERE CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103) GROUP BY PO_NO, PO_DATE, PO_SUPP"
        'End If

        'con.Open()
        'Dim cmd As New SqlCommand(sqlquery, con)
        'cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
        'cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
        'Dim adapter As New SqlDataAdapter(cmd)
        'Dim T As New DataTable
        'adapter.Fill(T)
        'cmd.ExecuteNonQuery()
        'con.Close()

        'Dim table As New DataTable
        'table.Columns.Add("PO_NO")
        'table.Columns.Add("PO_DATE")
        'table.Columns.Add("PO_SUPP")
        'table.Columns.Add("PO_SECTION")
        'table.Columns.Add("PO_AMT")


        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    Dim R As DataRow = table.NewRow

        '    conn.Open()
        '    Dim comm As New SqlCommand("SELECT PO_SECTION, COUNT([PO_SECTION]) AS TOTAL FROM SCO_DATA WHERE PO_NO = @no GROUP BY PO_SECTION ORDER BY COUNT(PO_SECTION) ", conn)
        '    comm.Parameters.Add("@no", SqlDbType.VarChar).Value = T.Rows(0)(0).ToString
        '    Dim ad As New SqlDataAdapter(comm)
        '    Dim tb As New DataTable
        '    ad.Fill(tb)
        '    comm.ExecuteNonQuery()
        '    conn.Close()

        '    Dim last As Integer = tb.Rows.Count - 1

        '    If tb.Rows.Count > 1 Then
        '        R("PO_NO") = T.Rows(i)(0).ToString
        '        R("PO_DATE") = T.Rows(i)(1).ToString
        '        R("PO_SUPP") = T.Rows(i)(2).ToString
        '        R("PO_SECTION") = tb.Rows(last)(0).ToString
        '        R("PO_AMT") = T.Rows(i)(3).ToString

        '    Else
        '        R("PO_NO") = T.Rows(i)(0).ToString
        '        R("PO_DATE") = T.Rows(i)(1).ToString
        '        R("PO_SUPP") = T.Rows(i)(2).ToString
        '        R("PO_SECTION") = tb.Rows(last)(0).ToString
        '        R("PO_AMT") = T.Rows(i)(3).ToString
        '    End If

        '    table.Rows.Add(R)

        'Next

        Dim temp As String
        Dim limit As Integer

        '  Using writer As StreamWriter = New StreamWriter(path)

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            id = "01|"

            temp = DataGridView1.Item(1, i).Value
            limit = 25 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "

            Next

            orderno = temp & "|"

            temp = DataGridView1.Item(2, i).Value
            limit = 10 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "

            Next

            plant = temp & "|"

            'temp = 

            dt = DataGridView1.Item(3, i).Value
            Dim datime As DateTime = DateTime.Parse(dt)

            dt = datime.ToString("dd/MM/yy") & "|"
            dd = "00/00/00|"

            temp = DataGridView1.Item(5, i).Value
            limit = 13 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = "0" & temp

            Next

            amt = " " & temp & "|"

            temp = DataGridView1.Item(6, i).Value
            limit = 15 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "

            Next

            suppac = temp & "|"

            stat = "N|"
            canceld = "00/00/00|"

            Dim query As String = ""

            'If ComboBox1.Text = "BW" Then
            '    query = "SELECT * FROM SCO_SO WHERE SO_NO = @no"
            'ElseIf ComboBox1.Text = "GT" Then
            '    query = "SELECT * FROM SCO_SO WHERE SO_NO = @no"
            'End If

            'con.Open()
            'Dim cmd1 As New SqlCommand(query, con)
            'cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
            'Dim adapter1 As New SqlDataAdapter(cmd1)
            'Dim table1 As New DataTable
            'adapter1.Fill(table1)
            'cmd1.ExecuteNonQuery()
            'con.Close()

            temp = DataGridView1.Item(9, i).Value
            limit = 240 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "

            Next

            purpose = temp & "|"

            temp = DataGridView1.Item(10, i).Value

            If temp.Length > 40 Then

                remarks = temp.Substring(0, 40) & "|"
            Else

                limit = 40 - temp.Length


                For j As Integer = 0 To limit - 1
                    temp = temp & " "

                Next

                remarks = temp & "|"
            End If

            charge = " "

            For j As Integer = 0 To 149 - 1
                charge = charge & " "

            Next

            charge = charge & "|"

            ceaf = " "

            For j As Integer = 0 To 14 - 1
                ceaf = ceaf & " "

            Next

            ceaf = ceaf & "|"

            autho = " "

            For j As Integer = 0 To 9 - 1
                autho = autho & " "

            Next

            autho = autho & "|"

            creatby = " "

            For j As Integer = 0 To 9 - 1
                creatby = creatby & " "

            Next

            creatby = creatby & "|"

            creaton = "00/00/00|"

            modifby = "          |"
            modifon = "00/00/00|"

            Dim squery As String = ""

            squery = "SELECT * FROM SCO_SUPP WHERE SUPP_CODE = @no"

            conn.Open()
            Dim cmd2 As New SqlCommand(squery, conn)
            cmd2.Parameters.Add("@no", SqlDbType.VarChar).Value = DataGridView1.Item(6, i).Value
            Dim adapter2 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adapter2.Fill(table2)
            cmd2.ExecuteNonQuery()
            conn.Close()

            If table2.Rows.Count = Nothing Then
                MsgBox("Supplier Code: " & DataGridView1.Item(6, i).Value & " unknown.", MsgBoxStyle.OkOnly)
                'afile.Close()

                My.Computer.FileSystem.DeleteFile(fPath)
                TextBox1.Text = ""
                MaskedTextBox1.Text = ""
                MaskedTextBox2.Text = ""
                Exit Sub

            End If

            temp = table2.Rows(0)(1).ToString.Replace(Environment.NewLine, String.Empty) '  There is no row at position 0.
            limit = 100 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "
            Next

            suppname = temp & "|"

            acctype = "0|"

            accid = " "

            For j As Integer = 0 To 19 - 1
                accid = accid & " "

            Next

            accid = accid & "|"

            gstamt = " 0000000000.00|"

            temp = table2.Rows(0)(4).ToString.Replace(Environment.NewLine, String.Empty)
            limit = 15 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "
            Next

            gstno = temp & "|"

            temp = table2.Rows(0)(5).ToString
            limit = 10 - temp.Length

            For j As Integer = 0 To limit - 1
                temp = temp & " "
            Next

            brn = temp & "|"

            ' plant = ""
            ' dt = ""
            ' amt = ""
            ' suppac = ""
            ' stat = ""
            ' canceld = ""
            ' purpose = ""
            ' remarks = ""
            ' charge = ""
            ' ceaf = ""
            ' autho = ""
            ' creatby = ""
            ' creaton = ""
            ' modifby = ""
            ' modifon = ""
            ' suppname = ""
            ' acctype = ""
            ' accid = ""
            ' gstamt = ""
            ' gstno = ""
            ' brn = ""

            ' My.Computer.FileSystem.WriteAllText(Path & ".txt", id & orderno, True)
            'afile.WriteLine(id & orderno & plant & dt & dd & amt & suppac & stat & canceld & purpose & remarks & charge & ceaf & autho & creatby & creaton & modifby & modifon & suppname & acctype & accid & gstamt & gstno & brn, i)
            writer.WriteLine(id & orderno & plant & dt & dd & amt & suppac & stat & canceld & purpose & remarks & charge & ceaf & autho & creatby & creaton & modifby & modifon & suppname & acctype & accid & gstamt & gstno & brn)

        Next

        writer.Close()

        'afile.Close()


        'If TextBox1.Text = "" Then
        '    MsgBox("Please choose file first.", MsgBoxStyle.OkOnly, "Warning")
        'Else
        '    Dim writer As TextWriter = New StreamWriter(TextBox1.Text)

        '    For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1

        '        For j As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1

        '            writer.Write(DataGridView1.Rows(i).Cells(j).Value.ToString() & vbTab & "|")

        '        Next

        '        writer.WriteLine("")
        '        ' writer.WriteLine("---------------------------------------------")

        '    Next

        DataGridView1.Rows.Clear()
        ToolStripStatusLabel1.Text = "Total Service Order: "
        TextBox1.Text = ""
        MaskedTextBox1.Text = ""
        MaskedTextBox2.Text = ""
        MaskedTextBox1.Focus()
        writer.Close()
        MessageBox.Show("Data Exported")

        'End If

    End Sub
End Class