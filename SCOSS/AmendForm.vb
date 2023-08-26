Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class AmendForm
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection '


    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer
    Dim tab As New DataTable
    Dim currrow As Integer

    Private Sub AmendForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)
        particularsCB()
    End Sub

    Sub filldata(i As Integer, t As DataTable)
        If DataGridView1.Rows.Count = Nothing Then
        Else
            sonolabel.Text = t.Rows(i)(0).ToString
            sostatus.Text = t.Rows(i)(1).ToString
            dateMB.Text = t.Rows(i)(2).ToString
            suppCB.SelectedValue = t.Rows(i)(3).ToString

            ' listbox

            machCB.SelectedValue = t.Rows(i)(5).ToString
            sectCB.SelectedValue = t.Rows(i)(6).ToString

            Dim desc As String = t.Rows(i)(7).ToString

            desctxt.Text = desc.Replace(vbLf, "")
            invtxt.Text = t.Rows(i)(8).ToString
            invdate.Text = t.Rows(i)(9).ToString
        End If

    End Sub

    Sub emptydata()
        

        ' listbox
        DataGridView1.Rows.Clear()

        machCB.SelectedValue = ""
        sectCB.SelectedValue = ""
        desctxt.Text = ""
        invtxt.Text = ""
        invdate.Text = ""

        tab = Nothing

    End Sub

    Sub particularsCB()
        conn = New SqlConnection(constr)

        Dim query As String = ""
        Dim dt As New DataTable

        ' supplier
        query = "SELECT * FROM SCO_SUPP"
        dt = Command(query)

        suppCB.DisplayMember = "SUPP_DESC"
        suppCB.ValueMember = "SUPP_CODE"
        suppCB.DataSource = dt

        ' machine
        query = "SELECT * FROM SCO_MACH"
        dt = command(query)

        machCB.DisplayMember = "MACH_DESC"
        machCB.ValueMember = "MACH_CODE"
        machCB.DataSource = dt

        ' section
        query = "SELECT * FROM SCO_SECTION"
        dt = command(query)

        sectCB.DisplayMember = "SEC_DESC"
        sectCB.ValueMember = "SEC_CODE"
        sectCB.DataSource = dt

    End Sub

    Public Function command(query As String) As DataTable
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        Return table
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ' stocklist.DataSource = Nothing
            DataGridView1.Rows.Clear()

            conn.Open()
            Dim cmd As New SqlCommand("SELECT PO_NO, PO_STATUS, PO_DATE, PO_SUPP, PO_STOCK, PO_MACHN, PO_SECTION, PO_DESC, PO_INV, ETA_DATE FROM SCO_DATA WHERE PO_NO = @no", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonotxt.Text
            Dim ad As New SqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            cmd.ExecuteNonQuery()
            conn.Close()

            tab = table

            If tab.Rows.Count = Nothing Then
                MsgBox(sonotxt.Text & " does not exist.", MsgBoxStyle.OkOnly, "Warning")
                sonotxt.Text = ""
                sonotxt.Focus()
            Else
                filldata(0, tab)

                For j = 0 To tab.Rows.Count - 1
                    DataGridView1.Rows.Add(tab.Rows(j)(4).ToString)
                Next

                btnEditSO.Enabled = True
                btnCancelSO.Enabled = True

                btnReset.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidateDate(ByVal dateString As String) As Boolean
        Try
            Dim dateParts() As String = dateString.Split("/")

            Dim testDate As New Date(Convert.ToInt32(dateParts(2)), Convert.ToInt32(dateParts(0)), Convert.ToInt32(dateParts(1)))

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub suppCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles suppCB.SelectedIndexChanged
        suppCode.Text = suppCB.SelectedValue
    End Sub

    Private Sub machCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles machCB.SelectedIndexChanged
        machCode.Text = machCB.SelectedValue
    End Sub

    Private Sub sectCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sectCB.SelectedIndexChanged
        sectCode.Text = sectCB.SelectedValue
    End Sub

    'Private Sub stocklist_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    filldata(stocklist.SelectedIndex, tab)
    'End Sub

    Private Sub btnEditSO_Click(sender As Object, e As EventArgs) Handles btnEditSO.Click
        sodetail.Enabled = True
    End Sub

    Private Sub btnSaveSO_Click(sender As Object, e As EventArgs) Handles btnSaveSO.Click
        ' update to SCO_DATA, SCO_TEMP, SCO_SO

        ' date validation
        Dim vd As Boolean
        Dim dt As DateTime = DateTime.Parse(dateMB.Text)

        vd = ValidateDate(dateMB.Text)

        If vd = True Then

            ' update to sco_data
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_DATE = @date, PO_SUPP = @supp WHERE PO_NO = @no", conn)
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = Format(dt, "yyyy-MM-dd")
            cmd.Parameters.Add("@supp", SqlDbType.VarChar).Value = suppCB.SelectedValue
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonotxt.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            ' update to sco_temp
            conn.Open()
            Dim cmd1 As New SqlCommand("UPDATE SCO_TEMP SET SCO_CDATE = @date, SCO_SUPP = @supp WHERE SCO_NO = @no", conn)
            cmd1.Parameters.Add("@date", SqlDbType.VarChar).Value = Format(dt, "yyyy-MM-dd")
            cmd1.Parameters.Add("@supp", SqlDbType.VarChar).Value = suppCB.SelectedValue
            cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = sonotxt.Text
            cmd1.ExecuteNonQuery()
            conn.Close()

            ' update to sco_temp
            conn.Open()
            Dim cmd2 As New SqlCommand("UPDATE SCO_SO SET SO_DATE = @date WHERE SO_NO = @no", conn)
            cmd2.Parameters.Add("@date", SqlDbType.VarChar).Value = Format(dt, "yyyy-MM-dd")
            cmd2.Parameters.Add("@no", SqlDbType.VarChar).Value = sonotxt.Text
            cmd2.ExecuteNonQuery()
            conn.Close()

            MsgBox("Data updated.", MsgBoxStyle.OkOnly, "")

            emptydata()

            sodetail.Enabled = False

            sonotxt.Text = ""
            sonotxt.Focus()

            sonolabel.Text = ""
            sostatus.Text = ""
            dateMB.Text = ""
            suppCB.SelectedValue = -1

            btnReset.Enabled = False
        Else
            MsgBox("Invalid date.", MsgBoxStyle.OkOnly, "")
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'stocklist.DataSource = Nothing
        'stocklist.DisplayMember = ""
        'stocklist.ValueMember = ""
        btnEditSO.Enabled = False
        btnCancelSO.Enabled = False
        btnReset.Enabled = False

        tab.Rows.Clear()
        stocknolabel.Text = ""

        DataGridView1.Rows.Clear()

        emptydata()

        sodetail.Enabled = False

        sonotxt.Text = ""
        sonotxt.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = e.RowIndex

        stocknolabel.Text = DataGridView1.Item(0, i).Value

        filldata(i, tab)
    End Sub

    Private Sub btnSaveStock_Click(sender As Object, e As EventArgs) Handles btnSaveStock.Click
        Try
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_MACHN = @mach, PO_SECTION = @sect, PO_DESC = @desc, PO_INV = @inv, ETA_DATE = @date WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
            cmd.Parameters.Add("@mach", SqlDbType.VarChar).Value = machCB.SelectedValue
            cmd.Parameters.Add("@sect", SqlDbType.VarChar).Value = sectCB.SelectedValue
            cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = desctxt.Text.Replace(vbCrLf, "")
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = invtxt.Text
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = invdate.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolabel.Text
            cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = stocknolabel.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim cmd1 As New SqlCommand("UDPATE SCO_TEMP SET SCO_MACHNO = @mach, SCO_SECTION = @sect, SCO_PART = @desc, SCO_INV = @inv, SCO_ETA = @invd WHERE SCO_NO = @no AND SCO_STOCK = @stock", conn)
            cmd1.Parameters.Add("@mach", SqlDbType.VarChar).Value = machCB.SelectedValue
            cmd1.Parameters.Add("@sect", SqlDbType.VarChar).Value = sectCB.SelectedValue
            cmd1.Parameters.Add("@desc", SqlDbType.VarChar).Value = desctxt.Text.Replace(vbCrLf, "")
            cmd1.Parameters.Add("@inv", SqlDbType.VarChar).Value = invtxt.Text
            cmd1.Parameters.Add("@date", SqlDbType.VarChar).Value = invdate.Text
            cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolabel.Text
            cmd1.Parameters.Add("@stock", SqlDbType.VarChar).Value = stocknolabel.Text
            cmd1.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully updated. ", MsgBoxStyle.OkOnly, "Notification")

            machCB.SelectedValue = ""
            sectCB.SelectedValue = ""
            desctxt.Text = ""
            invtxt.Text = ""
            invdate.Text = ""
            stocknolabel.Text = ""

            GroupBox3.Enabled = False
            DataGridView1.Enabled = True
            btnEditStock.Enabled = True
            btnReset.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEditStock_Click(sender As Object, e As EventArgs) Handles btnEditStock.Click
        Try
            GroupBox3.Enabled = True
            DataGridView1.Enabled = False
            btnEditStock.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelStock_Click(sender As Object, e As EventArgs) Handles btnCancelStock.Click
        Try
            machCB.SelectedValue = ""
            sectCB.SelectedValue = ""
            desctxt.Text = ""
            invtxt.Text = ""
            invdate.Text = ""
            stocknolabel.Text = ""

            GroupBox3.Enabled = False
            DataGridView1.Enabled = True
            btnEditStock.Enabled = True
            btnReset.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.Rows.Count = Nothing Then
        Else
            Dim i As Integer = DataGridView1.CurrentCell.RowIndex

            stocknolabel.Text = DataGridView1.Item(0, i).Value

            filldata(i, tab)
        End If

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        DataGridView1.Rows.Clear()
        btnEditSO.Enabled = False
        btnCancelSO.Enabled = False

        tab.Rows.Clear()
        stocknolabel.Text = ""


        emptydata()

        sodetail.Enabled = False

        sonotxt.Text = ""
        sonotxt.Focus()

        machCB.SelectedValue = ""
        sectCB.SelectedValue = ""
        desctxt.Text = ""
        invtxt.Text = ""
        invdate.Text = ""
        stocknolabel.Text = ""

        GroupBox3.Enabled = False
        DataGridView1.Enabled = True
        btnEditStock.Enabled = True

        tab = Nothing

        btnReset.Enabled = False
        sonolabel.Text = ""
        sostatus.Text = ""
        dateMB.Text = ""
        suppCB.SelectedValue = -1
    End Sub

    Private Sub btnCancelSO_Click(sender As Object, e As EventArgs) Handles btnCancelSO.Click
        Try
            ' cancel the SO 
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_STATUS = @stat WHERE PO_NO = @no", conn)
            cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = "CANCELLED"
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolabel.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim cmd1 As New SqlCommand("UDPATE SCO_TEMP SET SCO_PRINT = @stat WHERE SCO_NO = @no", conn)
            cmd1.Parameters.Add("@stat", SqlDbType.VarChar).Value = "CANCELLED"
            cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolabel.Text
            cmd1.ExecuteNonQuery()
            conn.Close()

            MsgBox("SO NO cancelled.", MsgBoxStyle.OkOnly, "Notification")

            'machCB.SelectedValue = ""
            'sectCB.SelectedValue = ""
            'desctxt.Text = ""
            'invtxt.Text = ""
            'invdate.Text = ""
            'stocknolabel.Text = ""

            'GroupBox3.Enabled = False
            'DataGridView1.Enabled = True
            'btnEditStock.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter


    End Sub
End Class