Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class PostSCO
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Public Function particularsload(cd As String) As DataTable
        conn = New SqlConnection(constr)

        Dim rtn As New DataTable

        If cd = "sup" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT SUPP_CODE, SUPP_CBDESC FROM SCO_SUPP", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(rtn)
            cmd.ExecuteNonQuery()
            conn.Close()

        ElseIf cd = "cur" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT CURR_ID, CURR_DEFAULT FROM SCO_CURRENCY", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(rtn)
            cmd.ExecuteNonQuery()
            conn.Close()

        ElseIf cd = "sec" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT SEC_CODE, SEC_DESC FROM SCO_SECTION", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(rtn)
            cmd.ExecuteNonQuery()
            conn.Close()

        ElseIf cd = "mac" Then

            conn.Open()
            Dim cmd As New SqlCommand("SELECT MACH_CODE, MACH_DESC FROM SCO_MACH", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(rtn)
            cmd.ExecuteNonQuery()
            conn.Close()
        End If

        Return rtn

    End Function

    Private Sub PostSCO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)


        Suppliercb.DisplayMember = "SUPP_CBDESC"
        Suppliercb.ValueMember = "SUPP_CODE"
        Suppliercb.DataSource = particularsload("sup")

        Currencycb.DisplayMember = "CURR_ID"
        Currencycb.ValueMember = "CURR_ID"
        Currencycb.DataSource = particularsload("cur")

        Plantcb.DisplayMember = "SEC_DESC"
        Plantcb.ValueMember = "SEC_CODE"
        Plantcb.DataSource = particularsload("sec")

        Machinecb.DisplayMember = "MACH_CODE"
        Machinecb.ValueMember = "MACH_DESC"
        Machinecb.DataSource = particularsload("mac")

        Me.WindowState = FormWindowState.Maximized
        'KeyPreview = True
    End Sub

    Sub resetallparticulars()
        status.Text = ""
        sono.Text = ""
        Suppliercb.SelectedIndex = 0
        Currencycb.SelectedIndex = 0
        purposedgv.Rows.Clear()
        remarksdgv.Rows.Clear()
        stockno.Text = ""
        Machinecb.SelectedIndex = 0
        Plantcb.SelectedIndex = 0
        particulars.Text = ""
        invno.Text = ""
        invdate.Text = ""
        uom.Text = ""
        qty.Text = ""
        unitprice.Text = ""
        amt.Text = ""
        discount.Text = ""
        tax.Text = ""
        total.Text = ""
        stocktotal.Text = ""
        stockdgv.Rows.Clear()

    End Sub

    Sub resetallstockdetails()
        'status.Text = ""
        'sono.Text = ""
        'Suppliercb.SelectedIndex = 0
        'Currencycb.SelectedIndex = 0
        'purposedgv.Rows.Clear()
        'remarksdgv.Rows.Clear()

        stockno.Text = ""
        Machinecb.SelectedIndex = 0
        Plantcb.SelectedIndex = 0
        particulars.Text = ""
        invno.Text = ""
        invdate.Text = ""
        uom.Text = ""
        qty.Text = ""
        unitprice.Text = ""
        amt.Text = ""
        discount.Text = ""
        tax.Text = ""
        total.Text = ""
        stocktotal.Text = ""
        stockdgv.Rows.Clear()

    End Sub

    Sub enabletrueparticulars()
        details.Enabled = True
        purposedgv.Enabled = True
        remarksdgv.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True

    End Sub

    Sub enablefalseparticulars()
        details.Enabled = False
        purposedgv.Enabled = False
        remarksdgv.Enabled = False
        Panel4.Enabled = False
        Panel5.Enabled = False

    End Sub

    Sub sonoauto()
        ' current year
        Dim d As String = DateTime.Now.ToString("yyyy-MM-dd")
        ' MsgBox(d)
        Dim y As String = Mid(d, 1, 4)
        Dim d1 As String = "2021-01-01"
        Dim d2 As String = y & "-12-31"

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
            sono.Text = "0000000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 2 Then
            sono.Text = "000000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 3 Then
            sono.Text = "00000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 4 Then
            sono.Text = "0000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 5 Then
            sono.Text = "000" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 6 Then
            sono.Text = "00" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 7 Then
            sono.Text = "0" & Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        ElseIf index.Length = 8 Then
            sono.Text = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)
        End If

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        btnadd.Enabled = False
        btnedit.Enabled = False
        btnprint.Enabled = False

        scodgv.Enabled = False
        resetallparticulars()
        enabletrueparticulars()
        sonoauto()

        status.Text = "NOT PRINTED"

        Suppliercb.Focus()


    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        resetallparticulars()
        enablefalseparticulars()

        btnadd.Enabled = True
        scodgv.Enabled = True

    End Sub

    Private Sub Suppliercb_KeyDown(sender As Object, e As KeyEventArgs) Handles Suppliercb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Currencycb.Focus()
        End If
    End Sub

    Private Sub Currencycb_KeyDown(sender As Object, e As KeyEventArgs) Handles Currencycb.KeyDown
        If e.KeyCode = Keys.Enter Then
            purpose.Focus()
        End If
    End Sub

    Private Sub purpose_KeyDown(sender As Object, e As KeyEventArgs) Handles purpose.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

            purposedgv.Rows.Add(purpose.Text)

            If result = DialogResult.Yes Then
                purpose.Text = ""
                purpose.Focus()

            Else
                purpose.Text = ""
                Me.TabControl1.SelectedTab = Me.TabPage2
                remarks.Focus()

            End If

        End If
    End Sub

    Private Sub remarks_KeyDown(sender As Object, e As KeyEventArgs) Handles remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim result As Integer = MessageBox.Show("Do you want to add more line?", "Notification", MessageBoxButtons.YesNo)

            remarksdgv.Rows.Add(remarks.Text)

            If result = DialogResult.Yes Then
                remarks.Text = ""
                remarks.Focus()

            Else
                remarks.Text = ""
                resetallstockdetails()
                updatedstockno()
                Machinecb.Focus()

            End If

        End If
    End Sub

    Sub updatedstockno()
        conn = New SqlConnection(constr)

        If stockdgv.Rows.Count = Nothing Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT PO_STOCK, PO_DATE FROM SCO_DATA ORDER BY PO_DATE, PO_STOCK", conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            adapter.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            Dim lastindex As Integer = table.Rows.Count - 1


            If IsNumeric(table.Rows(lastindex)(0).ToString) = True Then
                stockno.Text = Val(Integer.Parse(table.Rows(lastindex)(0).ToString) + 1)

                Machinecb.Focus()
            Else
                stockno.ReadOnly = False
                stockno.Focus()
            End If

        Else
            Dim lastindex As Integer = stockdgv.Rows.Count - 1

            Dim lateststock As String = stockdgv.Rows(lastindex).Cells(0).Value

            Dim checkstock As String = lateststock.Substring(0, 1)

            If IsNumeric(checkstock) Then
                stockno.Text = Val(Integer.Parse(lateststock) + 1)
                Machinecb.Focus()
            Else
                Machinecb.Focus()
            End If
        End If


    End Sub

    Private Sub Machinecb_KeyDown(sender As Object, e As KeyEventArgs) Handles Machinecb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Plantcb.Focus()
        End If
    End Sub

    Private Sub Plantcb_KeyDown(sender As Object, e As KeyEventArgs) Handles Plantcb.KeyDown
        If e.KeyCode = Keys.Enter Then
            particulars.Focus()
        End If
    End Sub

    Private Sub particulars_KeyDown(sender As Object, e As KeyEventArgs) Handles particulars.KeyDown
        If e.KeyCode = Keys.Enter Then
            invno.Focus()
        End If
    End Sub

    Private Sub invno_KeyDown(sender As Object, e As KeyEventArgs) Handles invno.KeyDown
        If e.KeyCode = Keys.Enter Then
            invdate.Focus()
        End If
    End Sub

    Private Sub invdate_KeyDown(sender As Object, e As KeyEventArgs) Handles invdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            uom.Focus()
        End If
    End Sub

    Private Sub uom_KeyDown(sender As Object, e As KeyEventArgs) Handles uom.KeyDown
        If e.KeyCode = Keys.Enter Then
            qty.Focus()
        End If
    End Sub

    Private Sub qty_KeyDown(sender As Object, e As KeyEventArgs) Handles qty.KeyDown
        If e.KeyCode = Keys.Enter Then
            unitprice.Focus()
        End If
    End Sub

    Private Sub unitprice_KeyDown(sender As Object, e As KeyEventArgs) Handles unitprice.KeyDown
        If e.KeyCode = Keys.Enter Then
            amt.Focus()
        End If
    End Sub

    Private Sub amt_KeyDown(sender As Object, e As KeyEventArgs) Handles amt.KeyDown
        If e.KeyCode = Keys.Enter Then
            discount.Focus()
        End If
    End Sub

    Private Sub discount_KeyDown(sender As Object, e As KeyEventArgs) Handles discount.KeyDown
        If e.KeyCode = Keys.Enter Then
            tax.Focus()
        End If
    End Sub

    Private Sub tax_KeyDown(sender As Object, e As KeyEventArgs) Handles tax.KeyDown
        If e.KeyCode = Keys.Enter Then
            total.Focus()
        End If
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim result As Integer = MessageBox.Show("Do you want to add stock?", "Notification", MessageBoxButtons.YesNo)

        stockdgv.Rows.Add(stockno.Text, particulars.Text, Plantcb.SelectedValue, Machinecb.Text, invdate.Text, invno.Text, uom.Text, qty.Text, unitprice.Text, amt.Text, discount.Text, tax.Text, total.Text)

        resetallstockdetails()

        If result = DialogResult.Yes Then
            updatedstockno()

            Dim ttl As Decimal = 0

            For i = 0 To stockdgv.Rows.Count - 1
                ttl += Val(stockdgv.Item(12, i).Value)
            Next

            stocktotal.Text = ttl
        Else

        End If
    End Sub

    Private Sub stockdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stockdgv.CellClick
        Dim i As Integer = 0
        i = stockdgv.CurrentRow.Index

        stockno.Text = stockdgv.Item(0, i).Value
        'Machinecb.SelectedIndex = 0
        'Plantcb.SelectedIndex = 0
        particulars.Text = stockdgv.Item(1, i).Value
        invno.Text = stockdgv.Item(5, i).Value
        invdate.Text = stockdgv.Item(4, i).Value
        uom.Text = stockdgv.Item(6, i).Value
        qty.Text = stockdgv.Item(7, i).Value
        unitprice.Text = stockdgv.Item(8, i).Value
        amt.Text = stockdgv.Item(9, i).Value
        discount.Text = stockdgv.Item(10, i).Value
        tax.Text = stockdgv.Item(11, i).Value
        'total.Text = ""
        'stocktotal.Text = ""
        stockdgv.Rows.Clear()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetallstockdetails()

    End Sub

    Private Sub btnaddstock_Click(sender As Object, e As EventArgs) Handles btnaddstock.Click
        resetallstockdetails()
        updatedstockno()

        Machinecb.Focus()
    End Sub
End Class