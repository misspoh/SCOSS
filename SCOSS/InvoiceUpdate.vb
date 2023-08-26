Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class InvoiceUpdate
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub InvoiceUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)
        Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Me.DataGridView1.DefaultCellStyle.BackColor
        Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Me.DataGridView1.DefaultCellStyle.ForeColor
        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Me.DataGridView1.DefaultCellStyle.BackColor
        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Me.DataGridView1.DefaultCellStyle.ForeColor
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If TextBox1.Text = "" Then
            MsgBox("Please enter the service order no.")
        Else
            conn.Open()
            Dim command As New SqlCommand("SELECT PO_INV FROM SCO_DATA WHERE PO_NO = @no AND PO_INV = ''", conn)
            command.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            Dim a As New SqlDataAdapter(command)
            Dim t As New DataTable
            a.Fill(t)
            command.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
                MsgBox("SO No not existed. Please try again.")
                TextBox1.Focus()
                TextBox1.Text = ""
            Else

                If t.Rows(0)(0).ToString = "" Then
                    GroupBox2.Enabled = True
                    ' get all information from main table according to the company
                    conn.Open()
                    Dim cmd As New SqlCommand("SELECT [PO_NO],[PO_DATE],[PO_SUPP],[ETA_DATE],[PO_SECTION],[PO_STOCK],[PO_DESC],[PO_QTY],[PO_UOM],[PO_CURR],[PO_UPRICE],[PO_AMT],[PO_MACHN],[PO_DISCAMT],[PO_TAX],[PO_INV],[PO_MACHD],[PO_STATUS] FROM SCO_DATA WHERE PO_NO = @no", conn)
                    cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable
                    adapter.Fill(table)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    If table.Rows.Count = Nothing Then
                        MsgBox("Service Order No did not exist. Please enter the existing data.")
                    Else
                        Dim totals As Integer = 0
                        Dim totala As Decimal = 0

                        For i As Integer = 0 To table.Rows.Count - 1

                            conn.Open()
                            Dim suppcmd As New SqlCommand("SELECT [SUPP_CBDESC] FROM SCO_SUPP WHERE SUPP_CODE = @code", conn)
                            suppcmd.Parameters.Add("@code", SqlDbType.VarChar).Value = table.Rows(i)(2).ToString
                            Dim suppad As New SqlDataAdapter(suppcmd)
                            Dim supptb As New DataTable
                            suppad.Fill(supptb)
                            suppcmd.ExecuteNonQuery()
                            conn.Close()

                            conn.Open()
                            Dim machcmd As New SqlCommand("SELECT MACH_DESC FROM SCO_MACH WHERE MACH_CODE = @code", conn)
                            machcmd.Parameters.Add("@code", SqlDbType.VarChar).Value = table.Rows(i)(12).ToString
                            Dim machad As New SqlDataAdapter(machcmd)
                            Dim machtb As New DataTable
                            machad.Fill(machtb)
                            machcmd.ExecuteNonQuery()
                            conn.Close()

                            If table.Rows(i)(15).ToString = "" Then
                                DataGridView3.Rows.Add(table.Rows(i)(5).ToString, table.Rows(i)(6).ToString, table.Rows(i)(11).ToString)

                                totals = totals + 1
                                totala = totala + Val(table.Rows(i)(11).ToString)
                            End If

                            TextBox2.Text = table.Rows(i)(0).ToString
                            MaskedTextBox3.Text = table.Rows(i)(1).ToString
                            TextBox3.Text = supptb.Rows(0)(0).ToString
                            ' TextBox6.Text = table.Rows(i)(5).ToString
                            ' TextBox7.Text = table.Rows(i)(4).ToString
                            ' TextBox8.Text = table.Rows(i)(12).ToString & " - " & machtb.Rows(0)(0).ToString
                            ' TextBox9.Text = table.Rows(i)(6).ToString
                            ' MaskedTextBox1.Text = table.Rows(i)(3).ToString
                            ' TextBox10.Text = table.Rows(i)(15).ToString
                            'TextBox4.Text = table.Rows(i)(8).ToString
                            'TextBox5.Text = Format(Val(table.Rows(i)(10).ToString), "#.0000")
                            'TextBox11.Text = table.Rows(i)(13).ToString
                            'TextBox12.Text = Format(Val(table.Rows(i)(7).ToString), "#.0000")
                            'TextBox13.Text = Format(Val(table.Rows(i)(11).ToString), "#.0000")
                            'TextBox14.Text = table.Rows(i)(14).ToString
                            'TextBox15.Text = Format(Val(table.Rows(i)(11).ToString) - Val(table.Rows(i)(14).ToString) - Val(table.Rows(i)(13).ToString), "###.00")

                            ' MaskedTextBox2.Text = table.Rows(i)(3).ToString
                            'TextBox16.Text = table.Rows(i)(15).ToString


                        Next

                        TextBox4.Text = totals
                        TextBox5.Text = Format(totala, "#,##0.00")

                    End If


                    ' get the information (purpose, remarks) according to the so no keyed in by the user
                    DataGridView1.Rows.Clear()
                    DataGridView2.Rows.Clear()

                    conn.Open()
                    Dim cmd1 As New SqlCommand("SELECT [PURPOSE_1],[PURPOSE_2],[PURPOSE_3],[PURPOSE_4],[PURPOSE_5],[REMARKS_1],[REMARKS_2],[REMARKS_3],[REMARKS_4],[REMARKS_5] FROM SCO_SO WHERE SO_NO = @no", conn)
                    cmd1.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
                    Dim adapter1 As New SqlDataAdapter(cmd1)
                    Dim table1 As New DataTable
                    adapter1.Fill(table1)
                    conn.Close()

                    Dim temp As String = ""

                    If table1.Rows.Count = Nothing Then

                    Else
                        For i As Integer = 0 To table1.Columns.Count - 1
                            temp = table1.Rows(0)(i).ToString

                            If temp = "" Then
                            Else
                                If i < 5 Then
                                    DataGridView1.Rows.Add(table1.Rows(0)(i).ToString)
                                Else
                                    DataGridView2.Rows.Add(table1.Rows(0)(i).ToString)
                                End If
                            End If
                        Next

                    End If
                    MaskedTextBox2.Focus()

                Else
                    MsgBox("Invoice existed for this SO: " & TextBox1.Text)
                    TextBox1.Text = ""

                End If
            End If
        End If


    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If stocktxt.Text = "" Then
            Dim result As Integer = MessageBox.Show("Do you want to update all stock in this stock no with this invoice number?", "Notification", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                conn.Open()
                Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_INV = @inv, ETA_DATE = @eta WHERE PO_NO = @no", conn)
                cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = TextBox16.Text
                cmd.Parameters.Add("@eta", SqlDbType.VarChar).Value = MaskedTextBox2.Text
                cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                conn.Close()
                GroupBox2.Enabled = False

                TextBox2.Text = ""
                TextBox3.Text = ""
                ' TextBox6.Text = ""
                ' TextBox7.Text = ""
                ' TextBox8.Text = ""
                ' TextBox9.Text = ""
                ' MaskedTextBox1.Text = ""
                MaskedTextBox3.Text = ""
                ' TextBox10.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                'TextBox11.Text = ""
                'TextBox12.Text = ""
                'TextBox13.Text = ""
                'TextBox14.Text = ""
                'TextBox15.Text = ""

                MaskedTextBox2.Text = ""
                TextBox16.Text = ""
                DataGridView1.Rows.Clear()
                DataGridView2.Rows.Clear()
                DataGridView3.Rows.Clear()
                TextBox1.Text = ""
                TextBox1.Focus()

            End If
           
        Else
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE SCO_DATA SET PO_INV = @inv, ETA_DATE = @eta WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
            cmd.Parameters.Add("@inv", SqlDbType.VarChar).Value = TextBox16.Text
            cmd.Parameters.Add("@eta", SqlDbType.VarChar).Value = MaskedTextBox2.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox1.Text
            cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = stocktxt.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            Dim i As Integer = DataGridView3.SelectedRows(0).Index
            DataGridView3.Rows.RemoveAt(i)

            MsgBox("Successfully updated.")

            stocktxt.Text = ""
            desctxt.Text = ""
            MaskedTextBox2.Text = ""
            TextBox16.Text = ""
        End If


    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchButton.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox16.Focus()
        End If
    End Sub

    Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox16.KeyDown
        If e.KeyCode = Keys.Enter Then
            UpdateButton.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        GroupBox2.Enabled = False

        TextBox2.Text = ""
        TextBox3.Text = ""
        'TextBox6.Text = ""
        'TextBox7.Text = ""
        'TextBox8.Text = ""
        'TextBox9.Text = ""
        'MaskedTextBox1.Text = ""
        MaskedTextBox3.Text = ""
        'TextBox10.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        'TextBox11.Text = ""
        'TextBox12.Text = ""
        'TextBox13.Text = ""
        'TextBox14.Text = ""
        'TextBox15.Text = ""

        MaskedTextBox2.Text = ""
        TextBox16.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()

        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
       

        Dim index As Integer

        ' get the index of the selected datagridview row
        index = e.RowIndex

        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView3.Rows(index)

        stocktxt.Text = selectedRow.Cells(0).Value.ToString()
        desctxt.Text = selectedRow.Cells(1).Value.ToString()

        'conn.Open()
        'Dim cmd As New SqlCommand("SELECT ETA_DATE, PO_INV FROM SCO_DATA WHERE PO_NO = @no AND PO_STOCK = @stock", conn)
        'cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = TextBox2.Text
        'cmd.Parameters.Add("@stock", SqlDbType.VarChar).Value = stocktxt.Text
        'Dim adapter As New SqlDataAdapter(cmd)
        'Dim table As New DataTable
        'adapter.Fill(table)
        'cmd.ExecuteNonQuery()
        'conn.Close()

        ' invtxt.Text = table.Rows(0)(1).ToString
        ' invdtxt.Text = table.Rows(0)(0).ToString
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' reset the choice 
        stocktxt.Text = ""
        desctxt.Text = ""
    End Sub
End Class