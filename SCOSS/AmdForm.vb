Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class AmdForm
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

    Private Sub AmdForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)
        DataGridView1.DefaultCellStyle.SelectionBackColor = DataGridView1.DefaultCellStyle.BackColor
        DataGridView1.DefaultCellStyle.SelectionForeColor = DataGridView1.DefaultCellStyle.ForeColor
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_DATA WHERE PO_NO = @po", conn)
        cmd.Parameters.Add("@po", SqlDbType.VarChar).Value = TextBox1.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        adapter.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        If tb.Rows.Count = Nothing Then
            MsgBox("No data detected. Please try again.")
            TextBox1.Text = ""
            TextBox1.Focus()
        Else

            TextBox1.Enabled = False
            btnSearch.Enabled = False

            If tb.Rows(0)(17).ToString = "CANCELLED" Then
                conn.Open()
                Dim comm As New SqlCommand("SELECT * FROM SCO_CANCELLED WHERE CAN_PONO = @po", conn)
                comm.Parameters.Add("@po", SqlDbType.VarChar).Value = TextBox1.Text
                Dim ad As New SqlDataAdapter(comm)
                Dim t As New DataTable
                ad.Fill(t)
                conn.Close()

                TextBox2.ReadOnly = True

                TextBox2.Text = t.Rows(0)(2).ToString

                btnCancel.Enabled = False
            Else
                btnCancel.Enabled = True
                TextBox2.ReadOnly = False

            End If

            btnDelete.Enabled = True
            btnReset.Enabled = True

            supplbl.Text = tb.Rows(0)(2).ToString & " - " & suppdesc(tb.Rows(0)(2).ToString)

            statlbl.Text = tb.Rows(0)(17).ToString
            sonolbl.Text = tb.Rows(0)(0).ToString

            Dim dt As String = tb.Rows(0)(1).ToString

            datelbl.Text = dt.Substring(0, 10)

            totalSTK.Text = tb.Rows.Count & " Stocks"

            Dim amt As Decimal = 0.0

            For i = 0 To tb.Rows.Count - 1
                DataGridView1.Rows.Add(tb.Rows(i)(6).ToString, tb.Rows(i)(15).ToString, tb.Rows(i)(11).ToString)
                amt += tb.Rows(i)(11).ToString

            Next

            totalAMT.Text = tb.Rows(0)(9).ToString & " " & Format(amt, "#,##0.00")

            TextBox2.Focus()
        End If

    End Sub

    Function suppdesc(code As String) As String
        Dim desc As String = ""

        conn.Open()
        Dim cmd As New SqlCommand("SELECT [SUPP_DESC] FROM SCO_SUPP WHERE [SUPP_CODE] = @code", conn)
        cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        desc = tb.Rows(0)(0).ToString

        Return desc

    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        supplbl.Text = "..."
        statlbl.Text = "..."
        sonolbl.Text = "..."
        datelbl.Text = "..."

        totalAMT.Text = "-"
        totalSTK.Text = "-"

        DataGridView1.Rows.Clear()

        TextBox1.Text = ""
        TextBox1.Focus()
        TextBox2.Text = ""
        TextBox2.ReadOnly = True

        btnCancel.Enabled = False
        btnDelete.Enabled = False
        btnReset.Enabled = False
        TextBox1.Enabled = True
        btnSearch.Enabled = True

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        conn.Open()
        Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_STATUS = 'CANCELLED' WHERE PO_NO = @no", conn)
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.ExecuteNonQuery()
        conn.Close()

        conn.Open()
        Dim cmd1 As New SqlCommand("UPDATE SCO_TEMP SET SCO_PRINT = 'CANCELLED' WHERE SCO_NO = @no", conn)
        cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
        cmd1.ExecuteNonQuery()
        conn.Close()

        Dim tm As DateTime = DateTime.Now

        conn.Open()
        Dim comm As New SqlCommand("INSERT INTO SCO_CANCELLED (CAN_PONO, CAN_STAT, CAN_REASON, CAN_DATE) VALUES (@pono, @stat, @reason, @dt)", conn)
        comm.Parameters.Add("@pono", SqlDbType.VarChar).Value = TextBox1.Text
        comm.Parameters.Add("@stat", SqlDbType.VarChar).Value = "CANCELLED"
        comm.Parameters.Add("@reason", SqlDbType.VarChar).Value = TextBox2.Text
        comm.Parameters.Add("@dt", SqlDbType.Date).Value = tm
        comm.ExecuteNonQuery()
        conn.Close()

        MsgBox("SO NO successfully cancelled.")

        TextBox2.Text = ""
        TextBox2.ReadOnly = False

        supplbl.Text = "..."
        statlbl.Text = "..."
        sonolbl.Text = "..."
        datelbl.Text = "..."

        totalAMT.Text = "-"
        totalSTK.Text = "-"

        DataGridView1.Rows.Clear()

        TextBox1.Text = ""
        TextBox1.Focus()

        btnCancel.Enabled = False
        btnDelete.Enabled = False
        btnReset.Enabled = False
        TextBox1.Enabled = True
        btnSearch.Enabled = True

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Do you want to delete this SO NO?", "Notification", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            ' before delete, small particulars will be save 
            conn.Open()
            Dim com As New SqlCommand("INSERT INTO SCO_DELETE(SO_NO, SO_DDEL, SO_REASON, SO_USER) values (@no, @ddel, @reason, @user)", conn)
            com.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolbl.Text
            com.Parameters.Add("@ddel", SqlDbType.Date).Value = Date.Now
            com.Parameters.Add("@reason", SqlDbType.VarChar).Value = ""
            com.Parameters.Add("@user", SqlDbType.VarChar).Value = ""
            com.ExecuteNonQuery()
            conn.Close()

            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM SCO_DATA WHERE PO_NO=@no", conn)
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = sonolbl.Text
            cmd.ExecuteNonQuery()
            conn.Close()
        Else

        End If
    End Sub

End Class