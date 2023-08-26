Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class EnqForm

    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub EnqForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn = New SqlConnection(constr)

        ' this one is for the listbox
        conn.Open()
        Dim cmd As New SqlCommand("SELECT SO_NO FROM SCO_SO ORDER BY SO_DATE", conn)
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        ListBox1.DataSource = tb
        ListBox1.DisplayMember = "SO_NO"
        ListBox1.ValueMember = "SO_NO"

        ' this one is for combobox year
        conn.Open()
        Dim cm As New SqlCommand("SELECT DISTINCT YEAR(SO_DATE) as Yr FROM SCO_SO ORDER BY YEAR(SO_DATE)", conn)
        Dim adp As New SqlDataAdapter(cm)
        Dim table As New DataTable
        adp.Fill(table)
        cm.ExecuteNonQuery()
        conn.Close()

        yearcb.DataSource = table
        yearcb.DisplayMember = "Yr"
        yearcb.ValueMember = "Yr"

        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub yearcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yearcb.SelectedIndexChanged
        If TextBox1.Text = "" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SO_NO FROM SCO_SO WHERE YEAR(SO_DATE) = @yr ORDER BY SO_DATE", conn)
            cmd.Parameters.Add("@yr", SqlDbType.Int).Value = Val(yearcb.Text)
            Dim ad As New SqlDataAdapter(cmd)
            Dim tb As New DataTable
            ad.Fill(tb)
            cmd.ExecuteNonQuery()
            conn.Close()

            ListBox1.DataSource = tb
            ListBox1.DisplayMember = "SO_NO"
            ListBox1.ValueMember = "SO_NO"

            ToolStripStatusLabel1.Text = tb.Rows.Count & " result(s)"

        Else
        End If
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        DataGridView1.Rows.Clear()

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_DATA WHERE PO_NO = @no ORDER BY PO_STOCK", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = ListBox1.SelectedValue.ToString
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        If tb.Rows.Count = Nothing Then
        Else
            Dim tmp As String = tb.Rows(0)(1).ToString

            sonotxt.Text = tb.Rows(0)(0).ToString
            datemb.Text = Format(Convert.ToDateTime(tmp), "dd/MM/yyyy")

            Label20.Text = tb.Rows(0)(2).ToString

            ' find supplier description
            Label5.Text = tb.Rows(0)(17).ToString
            supptxt.Text = suppdesc(tb.Rows(0)(2).ToString)

            ' SCO SO
            purrem(tb.Rows(0)(0).ToString)

            'PurposeTextBox.Text = ""
            'RemarksTextBox.Text = ""

            ' datagridview 
            Dim amt As Decimal = 0

            For i = 0 To tb.Rows.Count - 1
                DataGridView1.Rows.Add(tb.Rows(i)(5).ToString, tb.Rows(i)(2).ToString, tb.Rows(i)(6).ToString, tb.Rows(i)(12).ToString, Format(Val(tb.Rows(i)(11).ToString), "#,##0.00"))

                amt += Val(tb.Rows(i)(11).ToString)
            Next

            stocktxt.Text = tb.Rows.Count

            ' Format(Val(dt.Rows(i)(13).ToString), "0.00")

            TextBox12.Text = Format(amt, "#,##0.00")

        End If


    End Sub

    Sub purrem(no As String)
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_SO WHERE SO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        PurposeTextBox.Text = tb.Rows(0)(2).ToString
        RemarksTextBox.Text = tb.Rows(0)(7).ToString
    End Sub

    Public Function suppdesc(supp As String) As String
        Dim temp As String

        conn.Open()
        Dim cmd As New SqlCommand("SELECT [SUPP_DESC] FROM SCO_SUPP WHERE SUPP_CODE = @cd", conn)
        cmd.Parameters.Add("@cd", SqlDbType.VarChar).Value = supp
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        temp = t.Rows(0)(0).ToString

        Return temp
    End Function

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        ' Dim index As Integer

        ' get the index of the selected datagridview row

        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.CurrentRow

        itemdesc.Text = selectedRow.Cells(2).Value.ToString()

        ' machine description
        conn.Open()
        Dim cm As New SqlCommand("SELECT MACH_DESC FROM SCO_MACH WHERE MACH_CODE = @code", conn)
        cm.Parameters.Add("@code", SqlDbType.VarChar).Value = selectedRow.Cells(3).Value.ToString()
        Dim a As New SqlDataAdapter(cm)
        Dim t As New DataTable
        a.Fill(t)
        cm.ExecuteNonQuery()
        conn.Close()

        If t.Rows.Count = Nothing Then
            machdesc.Text = ""
        Else
            machdesc.Text = selectedRow.Cells(3).Value.ToString() & " - " & t.Rows(0)(0).ToString

        End If

        ' search for the other item details
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_DATA WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonotxt.Text
        cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = selectedRow.Cells(0).Value.ToString()
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        invref.Text = tb.Rows(0)(15).ToString
        itemdate.Text = tb.Rows(0)(3).ToString
        currency.Text = tb.Rows(0)(9).ToString
        uom.Text = tb.Rows(0)(8).ToString
        qtt.Text = tb.Rows(0)(7).ToString
        unitprice.Text = Format(Val(tb.Rows(0)(10).ToString), "#,##0.00")
        discamt.Text = Format(Val(tb.Rows(0)(13).ToString), "#,##0.00")

        taxamt.Text = Format(Val(tb.Rows(0)(14).ToString), "#,##0.00")
        amt.Text = selectedRow.Cells(4).Value.ToString()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SO_NO FROM SCO_SO WHERE YEAR(SO_DATE) = @yr ORDER BY SO_DATE", conn)
            cmd.Parameters.Add("@yr", SqlDbType.Int).Value = Val(yearcb.Text)
            Dim ad As New SqlDataAdapter(cmd)
            Dim tb As New DataTable
            ad.Fill(tb)
            cmd.ExecuteNonQuery()
            conn.Close()

            ListBox1.DataSource = tb
            ListBox1.DisplayMember = "SO_NO"
            ListBox1.ValueMember = "SO_NO"

            ToolStripStatusLabel1.Text = tb.Rows.Count & " result(s)"

        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT SO_NO FROM SCO_SO WHERE SO_NO like '" & TextBox1.Text & "%' ORDER BY SO_DATE", conn)
            ' cmd.Parameters.Add("@no", SqlDbType.Int).Value = TextBox1.Text
            Dim ad As New SqlDataAdapter(cmd)
            Dim tb As New DataTable
            ad.Fill(tb)
            cmd.ExecuteNonQuery()
            conn.Close()

            ListBox1.DataSource = tb
            ListBox1.DisplayMember = "SO_NO"
            ListBox1.ValueMember = "SO_NO"

            ToolStripStatusLabel1.Text = tb.Rows.Count & " result(s)"
        End If
    End Sub

End Class