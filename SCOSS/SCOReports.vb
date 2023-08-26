Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class SCOReports
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub SCOReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        Me.WindowState = FormWindowState.Maximized
        ' Me.MinimizeBox = False
        ' Me.MaximizeBox = False

        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If MaskedTextBox1.MaskCompleted = False Or MaskedTextBox2.MaskCompleted = False Then
            MsgBox("Preview invalid. Enter date for the report. ", MsgBoxStyle.OkOnly, "Warning")
            MaskedTextBox1.Focus()
            Exit Sub
        End If

        Dim ds As New Report

        Dim dt As New DataTable

        'Summary.SCO_SUMM.Rows.Clear()
        If ComboBox1.SelectedIndex = 1 Then
            If CheckBox2.CheckState = CheckState.Checked Then
                Dim fdata As New DataTable

                'fdata = Me.SCO_BWTableAdapter.GetDataByListingAllSupp(MaskedTextBox1.Text, MaskedTextBox2.Text)
                If cancelledSO.CheckState = CheckState.Checked Then
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS],[PO_ROUND] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) ORDER BY PO_DATE", conn)
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(fdata)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS], [PO_ROUND] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND PO_STATUS <> 'CANCELLED' ORDER BY PO_DATE", conn)
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(fdata)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If


                ' fdata = Me.SCO_BWTableAdapter.GetDataByListingAllSupp(MaskedTextBox1.Text, MaskedTextBox2.Text)

                For i As Integer = 0 To fdata.Rows.Count - 1
                    ' Dim suppdesc As String = Me.SCO_SUPPTableAdapter.ScalarQueryDesc(fdata.Rows(i)(2).ToString)
                    conn.Open()
                    Dim cmd1 As New SqlCommand("SELECT SUPP_DESC FROM SCO_SUPP WHERE SUPP_CODE = @code", conn)
                    cmd1.Parameters.Add("@code", SqlDbType.VarChar).Value = fdata.Rows(i)(2).ToString
                    Dim adapter1 As New SqlDataAdapter(cmd1)
                    Dim table1 As New DataTable
                    adapter1.Fill(table1)
                    cmd1.ExecuteNonQuery()
                    conn.Close()

                    Dim newdata As DataRow = ds.ListingS.NewRow

                    newdata("PO_NO") = fdata.Rows(i)(0).ToString
                    newdata("PO_DATE") = fdata.Rows(i)(1).ToString
                    newdata("PO_SECTION") = fdata.Rows(i)(4).ToString
                    newdata("PO_STOCK") = fdata.Rows(i)(5).ToString
                    newdata("PO_DESC") = fdata.Rows(i)(6).ToString

                    Dim d As String = Format(Val(fdata.Rows(i)(7).ToString), "0.0000")
                    Dim j As String = d.Substring(d.Length - 2) ' startindex cannot be 

                    If j = "00" Then
                        newdata("PO_QTY") = Format(Val(fdata.Rows(i)(7).ToString), "0.00")

                    Else
                        newdata("PO_QTY") = Format(Val(fdata.Rows(i)(7).ToString), "0.0000")

                    End If

                    newdata("PO_UOM") = fdata.Rows(i)(8).ToString
                    newdata("PO_CURR") = fdata.Rows(i)(9).ToString
                    newdata("PO_UPRICE") = Format(Val(fdata.Rows(i)(10).ToString), "0.0000")
                    newdata("PO_AMT") = Val(fdata.Rows(i)(11).ToString)
                    newdata("PO_MACHN") = fdata.Rows(i)(12).ToString
                    newdata("PO_DISCAMT") = fdata.Rows(i)(13).ToString
                    newdata("PO_TAX") = fdata.Rows(i)(14).ToString
                    newdata("PO_INV") = fdata.Rows(i)(15).ToString
                    newdata("PO_MACHD") = fdata.Rows(i)(16).ToString
                    newdata("PO_SUPP") = fdata.Rows(i)(2).ToString
                    newdata("PO_ROUND") = fdata.Rows(i)(18).ToString


                    If table1.Rows.Count = 0 Then
                        MsgBox("Description for " & fdata.Rows(i)(2).ToString & " not existed. ")
                        Exit Sub
                    Else
                        newdata("SUPP_DESC") = table1.Rows(0)(0).ToString

                    End If

                    newdata("ETA_DATE") = fdata.Rows(i)(3).ToString

                    ds.ListingS.Rows.Add(newdata)

                Next


            Else
                Dim fdata As New DataTable
                ' Dim fdata As DataTable = Me.SCO_BWTableAdapter.GetDataByListingS(ComboBox2.SelectedValue, MaskedTextBox1.Text, MaskedTextBox2.Text)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS],[PO_ROUND] FROM SCO_DATA WHERE PO_SUPP = @supp AND (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) ORDER BY PO_DATE", conn)
                cmd.Parameters.Add("@supp", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(fdata)
                cmd.ExecuteNonQuery()
                conn.Close()

                'Dim suppdesc As String = Me.SCO_SUPPTableAdapter.ScalarQueryDesc(ComboBox2.SelectedValue)
                conn.Open()
                Dim cmd1 As New SqlCommand("SELECT SUPP_DESC FROM SCO_SUPP WHERE SUPP_CODE = @code", conn)
                cmd1.Parameters.Add("@code", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                Dim adapter1 As New SqlDataAdapter(cmd1)
                Dim table1 As New DataTable
                adapter1.Fill(table1)
                cmd1.ExecuteNonQuery()
                conn.Close()
                Dim suppdesc As String = table1.Rows(0)(0).ToString


                For i As Integer = 0 To fdata.Rows.Count - 1
                    'Dim suppdesc As String = Me.SCO_SUPPTableAdapter.ScalarQuerydESC(fdata.Rows(i)(2).ToString)
                    Dim newdata As DataRow = ds.ListingS.NewRow

                    newdata("PO_NO") = fdata.Rows(i)(0).ToString
                    newdata("PO_DATE") = fdata.Rows(i)(1).ToString
                    newdata("PO_SECTION") = fdata.Rows(i)(4).ToString
                    newdata("PO_STOCK") = fdata.Rows(i)(5).ToString
                    newdata("PO_DESC") = fdata.Rows(i)(6).ToString

                    Dim d As String = Format(Val(fdata.Rows(i)(7).ToString), "0.0000")
                    Dim j As String = d.Substring(d.Length - 2) ' startindex cannot be 

                    If j = "00" Then
                        newdata("PO_QTY") = Format(Val(fdata.Rows(i)(7).ToString), "0.00")

                    Else
                        newdata("PO_QTY") = Format(Val(fdata.Rows(i)(7).ToString), "0.0000")

                    End If

                    newdata("PO_UOM") = fdata.Rows(i)(8).ToString
                    newdata("PO_CURR") = fdata.Rows(i)(9).ToString
                    newdata("PO_UPRICE") = Format(Val(fdata.Rows(i)(10).ToString), "0.0000")
                    newdata("PO_AMT") = Val(fdata.Rows(i)(11).ToString)
                    newdata("PO_MACHN") = fdata.Rows(i)(12).ToString
                    newdata("PO_DISCAMT") = fdata.Rows(i)(13).ToString
                    newdata("PO_TAX") = fdata.Rows(i)(14).ToString
                    newdata("PO_INV") = fdata.Rows(i)(15).ToString
                    newdata("PO_MACHD") = fdata.Rows(i)(16).ToString
                    newdata("PO_SUPP") = fdata.Rows(i)(2).ToString
                    newdata("PO_ROUND") = fdata.Rows(i)(18).ToString

                    If table1.Rows.Count = 0 Then
                        MsgBox("Description for " & ComboBox2.SelectedValue & " not existed. ")
                        Exit Sub
                    Else
                        newdata("SUPP_DESC") = suppdesc

                    End If

                    newdata("ETA_DATE") = fdata.Rows(i)(3).ToString

                    ds.ListingS.Rows.Add(newdata)

                Next

            End If
            Dim objrpt As New supplierlisting
            objrpt.SetDataSource(ds)
            ' Dim ftdate As String = & " - " & 
            objrpt.SetParameterValue("company", Login.Label3.Text)
            objrpt.SetParameterValue("fromdate", MaskedTextBox1.Text)
            objrpt.SetParameterValue("todate", MaskedTextBox2.Text)
            CrystalReportViewer1.ReportSource = objrpt
            CrystalReportViewer1.Refresh()

        ElseIf ComboBox1.SelectedIndex = 2 Then
            If CheckBox2.CheckState = CheckState.Checked Then
                If CheckBox3.CheckState = CheckState.Checked Then
                    ' dt = Me.SCO_BWTableAdapter.GetDataByExcNM(MaskedTextBox1.Text, MaskedTextBox2.Text)
                    If cancelledSO.CheckState = CheckState.Checked Then
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND NOT PO_MACHN = 'N' ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND NOT PO_MACHN = 'N' AND PO_STATUS <> 'CANCELLED' ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                   
                Else
                    ' dt = Me.SCO_BWTableAdapter.GetDataByListingAllMach(MaskedTextBox1.Text, MaskedTextBox2.Text)
                    If cancelledSO.CheckState = CheckState.Checked Then
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS],[PO_ROUND] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS], [PO_ROUND] FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND PO_STATUS <> 'CANCELLED' ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                End If

            Else
                If RemarksTextbox.Text = "" Then
                    If cancelledSO.CheckState = CheckState.Checked Then
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS], [PO_ROUND] FROM SCO_DATA WHERE PO_MACHN = @mach AND (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND NOT PO_MACHN = 'N' ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@mach", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        conn.Open()
                        Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS], [PO_ROUND] FROM SCO_DATA WHERE PO_MACHN = @mach AND (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND NOT PO_MACHN = 'N' AND PO_STATUS <> 'CANCELLED' ORDER BY PO_DATE", conn)
                        cmd.Parameters.Add("@mach", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                        Dim adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                    ' dt = Me.SCO_BWTableAdapter.GetDataByListing(ComboBox2.SelectedValue, MaskedTextBox1.Text, MaskedTextBox2.Text)
                    
                Else
                    ' dt = Me.SCO_BWTableAdapter.GetDataByMR(ComboBox2.SelectedValue, MaskedTextBox1.Text, MaskedTextBox2.Text, RemarksTextbox.Text)
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.PO_DATE, SCO_DATA.PO_SUPP, SCO_DATA.ETA_DATE, SCO_DATA.PO_SECTION, SCO_DATA.PO_STOCK, SCO_DATA.PO_DESC, SCO_DATA.PO_QTY, SCO_DATA.PO_UOM, SCO_DATA.PO_CURR, SCO_DATA.PO_UPRICE, SCO_DATA.PO_AMT, SCO_DATA.PO_MACHN, SCO_DATA.PO_DISCAMT, SCO_DATA.PO_TAX, SCO_DATA.PO_INV, SCO_DATA.PO_MACHD, SCO_PO.PO_PURPOSE, SCO_PO.PO_REMARKS FROM SCO_DATA INNER JOIN SCO_PO ON SCO_DATA.PO_NO = SCO_PO.PO_NO WHERE (SCO_DATA.PO_MACHN = @mach) AND (CONVERT(DATE, SCO_DATA.PO_DATE, 103) >= CONVERT(DATE, @newdate, 103)) AND (CONVERT(DATE, SCO_DATA.PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)) AND (SCO_PO.PO_PURPOSE LIKE '%' + @Param3 + '%') ORDER BY SCO_DATA.PO_DATE", conn)
                    cmd.Parameters.Add("@mach", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = RemarksTextbox.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If

            End If

            'Button2.Enabled = True
            Dim objRpt As New machinelisting
            objRpt.SetDataSource(dt)
            'Dim ftdate As String =  & " - " & MaskedTextBox2.Text
            objRpt.SetParameterValue("company", Login.Label3.Text)
            objRpt.SetParameterValue("fromdate", MaskedTextBox1.Text)
            objRpt.SetParameterValue("todate", MaskedTextBox2.Text)
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MaskedTextBox3.MaskCompleted = False Or MaskedTextBox4.MaskCompleted = False Then
            MsgBox("Preview invalid. Enter date for the report. ", MsgBoxStyle.OkOnly, "Warning")
            MaskedTextBox3.Focus()
            Exit Sub
        End If

        Dim dt As New Report
        Dim table As New DataTable

        conn.Open()
        Dim cmd As New SqlCommand("SELECT DISTINCT PO_SECTION, PO_MACHN FROM SCO_DATA WHERE CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)", conn)
        cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox3.Text
        cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox4.Text
        Dim adapter As New SqlDataAdapter(cmd)
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If CheckBox1.CheckState = CheckState.Unchecked Then
            For i As Integer = 0 To table.Rows.Count - 1
                conn.Open()
                Dim comms As New SqlCommand("SELECT SEC_DESC FROM SCO_SECTION WHERE SEC_CODE = @code", conn)
                comms.Parameters.Add("@code", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                Dim ter As New SqlDataAdapter(comms)
                Dim tle As New DataTable
                ter.Fill(tle)
                comms.ExecuteNonQuery()
                conn.Close()

                Dim tb As New DataTable

                If cancelledSO.CheckState = CheckState.Checked Then
                    conn.Open()
                    Dim comm As New SqlCommand("SELECT SUM(CAST(PO_AMT AS DECIMAL(28,2))) AS PO_AMT FROM dbo.SCO_DATA WHERE PO_SECTION = @sect AND PO_MACHN = @mn AND CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)", conn)
                    comm.Parameters.Add("@sect", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                    comm.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                    comm.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox3.Text
                    comm.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox4.Text
                    Dim adap As New SqlDataAdapter(comm)
                    adap.Fill(tb)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    conn.Open()
                    Dim comm As New SqlCommand("SELECT SUM(CAST(PO_AMT AS DECIMAL(28,2))) AS PO_AMT FROM dbo.SCO_DATA WHERE PO_SECTION = @sect AND PO_MACHN = @mn AND CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103) AND PO_STATUS <> 'CANCELLED'", conn)
                    comm.Parameters.Add("@sect", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                    comm.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                    comm.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox3.Text
                    comm.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox4.Text
                    Dim adap As New SqlDataAdapter(comm)
                    adap.Fill(tb)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If
                ' Dim totalAMT As Decimal = Me.SCO_DATATableAdapter.ScalarQueryTotalAmt(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, MaskedTextBox3.Text, MaskedTextBox4.Text)


                Dim totalAMT As Decimal = Val(tb.Rows(0)(0).ToString)

                conn.Open()

                Dim cmd1 As New SqlCommand("SELECT DISTINCT PO_MACHD FROM SCO_DATA WHERE PO_SECTION = @sc AND PO_MACHN = @mn", conn)
                cmd1.Parameters.Add("@sc", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                cmd1.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                Dim adapter1 As New SqlDataAdapter(cmd1)
                Dim table1 As New DataTable
                adapter1.Fill(table1)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim newrow As DataRow = dt.Summary.NewRow

                If table1.Rows.Count > 1 Then
                    newrow("PO_SECTION") = tle.Rows(0)(0).ToString
                    newrow("PO_MACHN") = table.Rows(i)(1).ToString
                    newrow("PO_MACHD") = table1.Rows(1)(0).ToString
                    newrow("PO_AMT") = totalAMT

                Else
                    newrow("PO_SECTION") = tle.Rows(0)(0).ToString
                    newrow("PO_MACHN") = table.Rows(i)(1).ToString
                    newrow("PO_MACHD") = table1.Rows(0)(0).ToString
                    newrow("PO_AMT") = totalAMT

                End If

                dt.Summary.Rows.Add(newrow)

            Next
        Else
            For i As Integer = 0 To table.Rows.Count - 1
                conn.Open()
                Dim comms As New SqlCommand("SELECT SEC_DESC FROM SCO_SECTION WHERE SEC_CODE = @code", conn)
                comms.Parameters.Add("@code", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                Dim ter As New SqlDataAdapter(comms)
                Dim tle As New DataTable
                ter.Fill(tle)
                comms.ExecuteNonQuery()
                conn.Close()


                If table.Rows(i)(1).ToString = "N" Then
                Else
                    Dim tb As New DataTable

                    If cancelledSO.CheckState = CheckState.Checked Then
                        conn.Open()
                        Dim comm As New SqlCommand("SELECT SUM(CAST(PO_AMT AS DECIMAL(28,2))) AS PO_AMT FROM dbo.SCO_DATA WHERE PO_SECTION = @sect AND PO_MACHN = @mn AND CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)", conn)
                        comm.Parameters.Add("@sect", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                        comm.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                        comm.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox3.Text
                        comm.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox4.Text
                        Dim adap As New SqlDataAdapter(comm)
                        adap.Fill(tb)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Else
                        conn.Open()
                        Dim comm As New SqlCommand("SELECT SUM(CAST(PO_AMT AS DECIMAL(28,2))) AS PO_AMT FROM dbo.SCO_DATA WHERE PO_SECTION = @sect AND PO_MACHN = @mn AND CONVERT (DATE, PO_DATE, 103) >= CONVERT(DATE, @newdate, 103) AND  CONVERT (DATE, PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)", conn)
                        comm.Parameters.Add("@sect", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                        comm.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                        comm.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox3.Text
                        comm.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox4.Text
                        Dim adap As New SqlDataAdapter(comm)
                        adap.Fill(tb)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                    'Dim totalAMT As Decimal = Me.SCO_DATATableAdapter.ScalarQueryTotalAmt(table.Rows(i)(0).ToString, table.Rows(i)(1).ToString, MaskedTextBox3.Text, MaskedTextBox4.Text)
                   
                    Dim totalAMT As Decimal = tb.Rows(0)(0).ToString

                    conn.Open()

                    Dim cmd1 As New SqlCommand("SELECT DISTINCT PO_MACHD FROM SCO_DATA WHERE PO_SECTION = @sc AND PO_MACHN = @mn", conn)
                    cmd1.Parameters.Add("@sc", SqlDbType.VarChar).Value = table.Rows(i)(0).ToString
                    cmd1.Parameters.Add("@mn", SqlDbType.VarChar).Value = table.Rows(i)(1).ToString
                    Dim adapter1 As New SqlDataAdapter(cmd1)
                    Dim table1 As New DataTable
                    adapter1.Fill(table1)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    Dim newrow As DataRow = dt.Summary.NewRow

                    If table1.Rows.Count > 1 Then
                        newrow("PO_SECTION") = tle.Rows(0)(0).ToString
                        newrow("PO_MACHN") = table.Rows(i)(1).ToString
                        newrow("PO_MACHD") = table1.Rows(1)(0).ToString
                        newrow("PO_AMT") = totalAMT

                    Else
                        newrow("PO_SECTION") = tle.Rows(0)(0).ToString
                        newrow("PO_MACHN") = table.Rows(i)(1).ToString
                        newrow("PO_MACHD") = table1.Rows(0)(0).ToString
                        newrow("PO_AMT") = totalAMT

                    End If

                    dt.Summary.Rows.Add(newrow)

                End If
            Next
        End If


        Dim objRpt As New SummReports
        objRpt.SetDataSource(dt)
        Dim ftdate As String = MaskedTextBox3.Text & " - " & MaskedTextBox4.Text
        objRpt.SetParameterValue("company", Login.Label3.Text)
        objRpt.SetParameterValue("fromdate", ftdate)
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dt As New DataTable

        If allCheckBox.CheckState = CheckState.Checked Then
            If allCheckBox.CheckState = CheckState.Checked Then
                'dt = Me.SCO_DATATableAdapter.GetDataByListingAllPONo(MaskedTextBox6.Text, MaskedTextBox5.Text)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT SCO_DATA.ETA_DATE, SCO_DATA.PO_AMT, SCO_DATA.PO_CURR, SCO_DATA.PO_DATE, SCO_DATA.PO_DESC, SCO_DATA.PO_DISCAMT, SCO_DATA.PO_INV, SCO_DATA.PO_MACHD, SCO_DATA.PO_MACHN, SCO_DATA.PO_NO, SCO_DATA.PO_QTY, SCO_DATA.PO_SECTION, SCO_DATA.PO_STOCK, SCO_DATA.PO_SUPP, SCO_DATA.PO_TAX, SCO_DATA.PO_UOM, SCO_DATA.PO_UPRICE, SCO_SUPP.SUPP_DESC, SCO_SO.PURPOSE_1 + ' ' + SCO_SO.PURPOSE_2 + ' ' + SCO_SO.PURPOSE_3 + ' ' + SCO_SO.PURPOSE_4 + ' ' + SCO_SO.PURPOSE_5 AS PO_PURPOSE, SCO_SO.REMARKS_1 + ' ' + SCO_SO.REMARKS_2 + ' ' + SCO_SO.REMARKS_3 + ' ' + SCO_SO.REMARKS_4 + ' ' + SCO_SO.REMARKS_5 AS PO_REMARKS FROM SCO_DATA INNER JOIN SCO_SUPP ON SCO_DATA.PO_SUPP = SCO_SUPP.SUPP_CODE INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE (CONVERT(DATE, SCO_DATA.PO_DATE, 103) >= CONVERT(DATE, @newdate, 103)) AND (CONVERT(DATE, SCO_DATA.PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)) ORDER BY SCO_DATA.PO_DATE", conn)
                cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox6.Text
                cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox5.Text
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
                cmd.ExecuteNonQuery 
                conn.Close()
            End If

            'Button2.Enabled = True
            Dim objRpt As New ListingByPO
            objRpt.SetDataSource(dt)
            Dim ftdate As String = MaskedTextBox6.Text & " - " & MaskedTextBox5.Text
            objRpt.SetParameterValue("company", Login.Label3.Text)
            objRpt.SetParameterValue("ftdate", ftdate)
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()

        ElseIf multipleCheckBox.CheckState = CheckState.Checked Then
            Dim tempdt As New DataTable

            If multipleCheckBox.CheckState = CheckState.Checked Then
                For i As Integer = 0 To ListBox2.Items.Count - 1
                    ' tempdt = Me.SCO_DATATableAdapter.GetDataByMultiple(MaskedTextBox6.Text, MaskedTextBox5.Text, ListBox2.Items(i))
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT SCO_DATA.PO_NO, SCO_DATA.PO_DATE, SCO_DATA.PO_SUPP, SCO_DATA.ETA_DATE, SCO_DATA.PO_SECTION, SCO_DATA.PO_STOCK, SCO_DATA.PO_DESC, SCO_DATA.PO_QTY, SCO_DATA.PO_UOM, SCO_DATA.PO_CURR, SCO_DATA.PO_UPRICE, SCO_DATA.PO_AMT, SCO_DATA.PO_MACHN, SCO_DATA.PO_DISCAMT, SCO_DATA.PO_TAX, SCO_DATA.PO_INV, SCO_DATA.PO_MACHD, SCO_SUPP.SUPP_DESC, SCO_SO.PURPOSE_1 + ' ' + SCO_SO.PURPOSE_2 + ' ' + SCO_SO.PURPOSE_3 + ' ' + SCO_SO.PURPOSE_4 + ' ' + SCO_SO.PURPOSE_5 AS PO_PURPOSE, SCO_SO.REMARKS_1 + ' ' + SCO_SO.REMARKS_2 + ' ' + SCO_SO.REMARKS_3 + ' ' + SCO_SO.REMARKS_4 + ' ' + SCO_SO.REMARKS_5 AS PO_REMARKS FROM SCO_DATA INNER JOIN SCO_SUPP ON SCO_DATA.PO_SUPP = SCO_SUPP.SUPP_CODE INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE (CONVERT(DATE, SCO_DATA.PO_DATE, 103) >= CONVERT(DATE, @newdate, 103)) AND (CONVERT(DATE, SCO_DATA.PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)) AND (SCO_DATA.PO_NO = @no) ORDER BY SCO_DATA.PO_DATE", conn)
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox6.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox5.Text
                    cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = ListBox2.Items(i)
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(tempdt)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    dt.Merge(tempdt)
                Next

            End If

            Dim objRpt As New ListingByPO
            objRpt.SetDataSource(dt)
            Dim ftdate As String = MaskedTextBox6.Text & " - " & MaskedTextBox5.Text
            objRpt.SetParameterValue("company", Login.Label3.Text)
            objRpt.SetParameterValue("ftdate", ftdate)
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
        End If
    End Sub

    Private Sub listingCancel_Click(sender As Object, e As EventArgs) Handles listingCancel.Click
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()
        MaskedTextBox1.Text = ""
        MaskedTextBox2.Text = ""
        ComboBox2.DataSource = Nothing
        CheckBox1.CheckState = CheckState.Unchecked
        listingGroup.Enabled = False
        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = True
        ComboBox1.Focus()
    End Sub

    Private Sub summCancel_Click(sender As Object, e As EventArgs) Handles summCancel.Click
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()
        MaskedTextBox3.Text = ""
        MaskedTextBox4.Text = ""
        CheckBox2.CheckState = CheckState.Unchecked
        summaryGroup.Enabled = False
        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = True
        ComboBox1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()
        MaskedTextBox6.Text = ""
        MaskedTextBox5.Text = ""
        multipleCheckBox.CheckState = CheckState.Unchecked
        allCheckBox.CheckState = CheckState.Unchecked
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        listingPOGroup.Enabled = False
        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = True
        ComboBox1.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListBox1.SelectedIndex = -1 Then
            MsgBox("Please select PO_NO.", MsgBoxStyle.OkOnly, "Warning")
        Else

            ListBox2.Items.Add(ListBox1.SelectedItem)
            ListBox1.Items.Remove(ListBox1.SelectedItem)

            ListBox1.SelectedIndex = 0

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListBox2.SelectedIndex = -1 Then
            MsgBox("Please select PO_NO.", MsgBoxStyle.OkOnly, "Warning")
        Else

            ListBox1.Items.Add(ListBox2.SelectedItem)
            ListBox2.Items.Remove(ListBox2.SelectedItem)

            ListBox1.Sorted = True
        End If
    End Sub

    Private Sub MaskedTextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox5.Focus()
        End If
    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As EventArgs) Handles rangeCheckBox.Click
        If rangeCheckBox.CheckState = CheckState.Checked Then
            '  rangeGroup.Enabled = True
            multipleGroup.Enabled = False
            multipleCheckBox.CheckState = CheckState.Unchecked
        Else
            '   rangeGroup.Enabled = False
        End If
    End Sub

    Private Sub multipleCheckBox_Click(sender As Object, e As EventArgs) Handles multipleCheckBox.Click
        If multipleCheckBox.CheckState = CheckState.Checked Then
            multipleGroup.Enabled = True
            ' rangeGroup.Enabled = False

            '   rangeCheckBox.CheckState = CheckState.Unchecked
            allCheckBox.CheckState = CheckState.Unchecked
            Dim dt As New DataTable

            ' dt = Me.SCO_DATATableAdapter.GetDataByListingAllPONo(MaskedTextBox6.Text, MaskedTextBox5.Text)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SCO_DATA.ETA_DATE, SCO_DATA.PO_AMT, SCO_DATA.PO_CURR, SCO_DATA.PO_DATE, SCO_DATA.PO_DESC, SCO_DATA.PO_DISCAMT, SCO_DATA.PO_INV, SCO_DATA.PO_MACHD, SCO_DATA.PO_MACHN, SCO_DATA.PO_NO, SCO_DATA.PO_QTY, SCO_DATA.PO_SECTION, SCO_DATA.PO_STOCK, SCO_DATA.PO_SUPP, SCO_DATA.PO_TAX, SCO_DATA.PO_UOM, SCO_DATA.PO_UPRICE, SCO_SUPP.SUPP_DESC, SCO_SO.PURPOSE_1 + ' ' + SCO_SO.PURPOSE_2 + ' ' + SCO_SO.PURPOSE_3 + ' ' + SCO_SO.PURPOSE_4 + ' ' + SCO_SO.PURPOSE_5 AS PO_PURPOSE, SCO_SO.REMARKS_1 + ' ' + SCO_SO.REMARKS_2 + ' ' + SCO_SO.REMARKS_3 + ' ' + SCO_SO.REMARKS_4 + ' ' + SCO_SO.REMARKS_5 AS PO_REMARKS FROM SCO_DATA INNER JOIN SCO_SUPP ON SCO_DATA.PO_SUPP = SCO_SUPP.SUPP_CODE INNER JOIN SCO_SO ON SCO_DATA.PO_NO = SCO_SO.SO_NO WHERE (CONVERT(DATE, SCO_DATA.PO_DATE, 103) >= CONVERT(DATE, @newdate, 103)) AND (CONVERT(DATE, SCO_DATA.PO_DATE, 103) <= CONVERT(DATE, @newdate2, 103)) ORDER BY SCO_DATA.PO_DATE", conn)
            cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox6.Text
            cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox5.Text
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            cmd.ExecuteNonQuery()
            conn.Close()

            If dt.Rows.Count = Nothing Then
                MsgBox("No existing PO NO between those date. Please enter another date.", MsgBoxStyle.OkOnly, "Warning")
                multipleCheckBox.CheckState = CheckState.Unchecked
            Else
                Dim temp As String = ""

                For i As Integer = 0 To dt.Rows.Count - 1
                    If temp = dt.Rows(i)(9).ToString Then
                    Else

                        ListBox1.Items.Add(dt.Rows(i)(9).ToString)
                        temp = dt.Rows(i)(9).ToString
                    End If
                Next

                If ListBox1.Items.Count > 0 Then
                Else
                    ListBox1.SelectedIndex = 0
                End If
            End If

        Else
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            multipleGroup.Enabled = False
        End If

    End Sub

    Private Sub allCheckBox_Click(sender As Object, e As EventArgs) Handles allCheckBox.Click
        If multipleCheckBox.CheckState = CheckState.Checked Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            multipleGroup.Enabled = False
            'rangeGroup.Enabled = False
            '   rangeCheckBox.CheckState = CheckState.Unchecked
            multipleCheckBox.CheckState = CheckState.Unchecked
        Else
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            ComboBox2.Enabled = False
            'istingReports.TextBox2.Text = "1"
            'MaskedTextBox1.Enabled = False
            'MaskedTextBox2.Enabled = False
        Else
            MaskedTextBox1.Focus()
            ComboBox2.Enabled = True
            'ListingReports.TextBox2.Text = ""
            MaskedTextBox1.Enabled = True
            MaskedTextBox2.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            listingPOGroup.Enabled = False
            listingGroup.Enabled = False
            summaryGroup.Enabled = False
        ElseIf ComboBox1.SelectedIndex = 1 Then
            listingPOGroup.Enabled = False
            listingGroup.Enabled = True
            summaryGroup.Enabled = False
            MaskedTextBox1.Focus()
            Label5.Text = "Supplier Code: "
            ComboBox1.Enabled = False
        ElseIf ComboBox1.SelectedIndex = 2 Then
            listingPOGroup.Enabled = False
            listingGroup.Enabled = True
            summaryGroup.Enabled = False
            MaskedTextBox1.Focus()
            Label5.Text = "Machine No: "
            ComboBox1.Enabled = False
        ElseIf ComboBox1.SelectedIndex = 3 Then
            listingPOGroup.Enabled = True
            listingGroup.Enabled = False
            summaryGroup.Enabled = False
            MaskedTextBox6.Focus()
            Label5.Text = "PO No: "
            ComboBox1.Enabled = False
        Else
            listingPOGroup.Enabled = False
            listingGroup.Enabled = False
            summaryGroup.Enabled = True
            MaskedTextBox3.Focus()
            ComboBox1.Enabled = False

        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPreview.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox4.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBox2.TextChanged
        Dim d As New DataTable

        If MaskedTextBox2.MaskCompleted = True Then
            If ComboBox1.SelectedIndex = 1 Then
                If cancelledSO.CheckState = CheckState.Checked Then
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT DISTINCT PO_SUPP FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) GROUP BY PO_SUPP ORDER BY PO_SUPP", conn)
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(d)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    ComboBox2.DataSource = d
                    ComboBox2.DisplayMember = "PO_SUPP"
                    ComboBox2.ValueMember = "PO_SUPP"
                Else
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT DISTINCT PO_SUPP FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) AND PO_STATUS <> 'CANCELLED' GROUP BY PO_SUPP ORDER BY PO_SUPP", conn)
                    cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                    cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(d)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    ComboBox2.DataSource = d
                    ComboBox2.DisplayMember = "PO_SUPP"
                    ComboBox2.ValueMember = "PO_SUPP"
                End If
               
            ElseIf ComboBox1.SelectedIndex = 2 Then

                ' Dim d As DataTable = Me.SCO_DATATableAdapter.GetDataByMach(MaskedTextBox1.Text, MaskedTextBox2.Text)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT DISTINCT PO_MACHN FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) GROUP BY PO_MACHN ORDER BY PO_MACHN", conn)
                cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(d)
                cmd.ExecuteNonQuery()
                conn.Close()

                ComboBox2.DataSource = d
                ComboBox2.DisplayMember = "PO_MACHN"
                ComboBox2.ValueMember = "PO_MACHN"

            Else

                ' Dim d As DataTable = Me.SCO_DATATableAdapter.GetDataByPONo(MaskedTextBox1.Text, MaskedTextBox2.Text)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT DISTINCT PO_NO FROM SCO_DATA WHERE (CONVERT (DATE, PO_DATE, 103) >= CONVERT (DATE, @newdate, 103)) AND (CONVERT (DATE, PO_DATE, 103) <= CONVERT (DATE, @newdate2, 103)) GROUP BY PO_NO ORDER BY PO_NO", conn)
                cmd.Parameters.Add("@newdate", SqlDbType.VarChar).Value = MaskedTextBox1.Text
                cmd.Parameters.Add("@newdate2", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(d)
                cmd.ExecuteNonQuery()
                conn.Close()

                ComboBox2.DataSource = d
                ComboBox2.DisplayMember = "PO_NO"
                ComboBox2.ValueMember = "PO_NO"


            End If

        End If
    End Sub

End Class