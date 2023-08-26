Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class AmendmentForm
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer
    Dim tab As New DataTable
    Dim currrow As Integer

    Private Sub AmendmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim val As Integer = 0

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_TEMP WHERE SCO_NO = @n", conn)
        cmd.Parameters.Add("@n", SqlDbType.VarChar).Value = ponosearch.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        tab = table
        val = table.Rows.Count - 1
        value_int = val

        btnNext.Enabled = True

        currrow = 0
        currposition.Text = currrow

        filldata(tab, currrow)

        ponosearch.Enabled = False
        btnSearch.Enabled = False
        enableedit()

    End Sub

    Sub enableedit()
        sodate.ReadOnly = False
        sodesc.ReadOnly = False
        soinv.ReadOnly = False
        soinvdt.ReadOnly = False

        sodate.Focus()
    End Sub

    Sub disableedit()
        sodate.ReadOnly = True
        sodesc.ReadOnly = True
        soinv.ReadOnly = True
        soinvdt.ReadOnly = True

        ponosearch.Focus()
    End Sub

    Sub filldata(tb As DataTable, i As Integer)

        sonolabel.Text = tb.Rows(i)(0).ToString
        sodate.Text = tb.Rows(i)(1).ToString
        sosupp.Text = tb.Rows(i)(2).ToString
        sopur.Text = tb.Rows(i)(4).ToString
        sorem.Text = tb.Rows(i)(5).ToString
        sostock.Text = tb.Rows(i)(6).ToString
        somachine.Text = tb.Rows(i)(9).ToString
        sosect.Text = tb.Rows(i)(8).ToString
        sodesc.Text = tb.Rows(i)(10).ToString
        soinv.Text = tb.Rows(i)(11).ToString
        soinvdt.Text = tb.Rows(i)(7).ToString
        souom.Text = tb.Rows(i)(12).ToString
        soqty.Text = tb.Rows(i)(13).ToString
        soup.Text = tb.Rows(i)(14).ToString
        soamt.Text = tb.Rows(i)(15).ToString
        sodisc.Text = tb.Rows(i)(16).ToString
        sotax.Text = tb.Rows(i)(17).ToString
        sostatus.Text = tb.Rows(i)(20).ToString
        currposition.Text = ""

        ' currency
        Label22.Text = tb.Rows(i)(3).ToString
        Label23.Text = tb.Rows(i)(3).ToString
        Label24.Text = tb.Rows(i)(3).ToString
        Label25.Text = tb.Rows(i)(3).ToString
        Label26.Text = tb.Rows(i)(3).ToString
    End Sub

    Private Sub currposition_TextChanged(sender As Object, e As EventArgs) Handles currposition.TextChanged

        If value_int = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
        Else
            If currrow = 0 Then
                btnPrevious.Enabled = False
            ElseIf currrow = value_int Then
                btnNext.Enabled = False
            Else
                btnPrevious.Enabled = True
                btnNext.Enabled = True
            End If

        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        sonolabel.Text = ""
        sodate.Text = ""
        sosupp.Text = ""
        sopur.Text = ""
        sorem.Text = ""
        sostock.Text = ""
        somachine.Text = ""
        sosect.Text = ""
        sodesc.Text = ""
        soinv.Text = ""
        soinvdt.Text = ""
        souom.Text = ""
        soqty.Text = ""
        soup.Text = ""
        soamt.Text = ""
        sodisc.Text = ""
        sotax.Text = ""
        sostatus.Text = ""

        ' currency
        Label22.Text = ""
        Label23.Text = ""
        Label24.Text = ""
        Label25.Text = ""
        Label26.Text = ""

        ' support in terms of hardware technicalities as well as installing software 

        ponosearch.Text = ""
        ponosearch.Enabled = True
        btnSearch.Enabled = True
        disableedit()
        currposition.Text = ""

        tab = Nothing

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        currrow -= 1
        currposition.Text = currrow

        filldata(tab, currrow)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currrow += 1
        currposition.Text = currrow

        filldata(tab, currrow)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For i As Integer = 0 To tab.Rows.Count - 1
            ' update the sco_temp, sco_so, sco_data

            ' sco_so (*update date by sco no)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_SO SET SO_DATE = @date WHERE SO_NO = @no", conn)
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = sodate.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolabel.Text
            cmd.ExecuteNonQuery()
            conn.Close()

        Next
    End Sub

    Private Sub btnCancelSO_Click(sender As Object, e As EventArgs) Handles btnCancelSO.Click

    End Sub
End Class