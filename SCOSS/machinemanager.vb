Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class machinemanager
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Sub machinemanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        maindgv.Rows.Clear()

        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM MACH_MAINC ORDER BY MCAT_ID", conn)
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        For i = 0 To t.Rows.Count - 1
            maindgv.Rows.Add(t.Rows(i)(0).ToString, t.Rows(i)(1).ToString)
        Next

        ' COMBOBOX FOR MAIN CATEGORY AND SUB CATEGORY
        conn.Open()
        Dim maincmd As New SqlCommand("SELECT * FROM MACH_MAINC ORDER BY MCAT_ID", conn)
        Dim mainad As New SqlDataAdapter(maincmd)
        Dim maintable As New DataTable
        mainad.Fill(maintable)
        maincmd.ExecuteNonQuery()
        conn.Close()

        mainc_cb.DataSource = maintable
        mainc_cb.DisplayMember = "MCAT_DESC"
        mainc_cb.ValueMember = "MCAT_ID"

        conn.Open()
        Dim subcmd As New SqlCommand("SELECT * FROM MACH_SUBC ORDER BY SCAT_ID", conn)
        Dim subad As New SqlDataAdapter(subcmd)
        Dim subtable As New DataTable
        subad.Fill(subtable)
        subcmd.ExecuteNonQuery()
        conn.Close()

        subcat_cb.DataSource = subtable
        subcat_cb.DisplayMember = "SCAT_DESC"
        subcat_cb.ValueMember = "SCAT_ID"

        ToolStripStatusLabel2.Text = t.Rows.Count

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Sub countdetaildgv()
        If detaildgv.Rows.Count = Nothing Then

            ToolStripStatusLabel5.Text = ""
        Else
            ToolStripStatusLabel5.Text = detaildgv.Rows.Count
        End If
    End Sub

    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        Category.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox1.Enabled = False
        Panel3.Enabled = True
        btnSave.Visible = True
        btnCancel.Visible = True

        Panel2.Enabled = False
        detaildgv.Enabled = False

        mach_id.Focus()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        GroupBox1.Enabled = True
        Panel3.Enabled = False
        btnSave.Visible = False
        btnCancel.Visible = False
        Panel2.Enabled = True
        mach_id.Enabled = True

        Panel3.Enabled = False
        detaildgv.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If mach_id.Text = "" Then
            MsgBox("No data selected.")
        Else
            GroupBox1.Enabled = False

            Panel3.Enabled = True
            btnSave.Visible = True
            btnCancel.Visible = True
            Panel2.Enabled = False
            detaildgv.Enabled = False

            mach_id.Enabled = False
            mach_desc.Focus()

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If mach_id.Text = "" Then
            MsgBox("No data selected.")
        Else
            Dim result As Integer = MessageBox.Show("Do you want to delete?", "Notification", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                ' Me.SCO_MACHTableAdapter.DeleteQueryMachCode(TextBox2.Text)
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM SCO_MACH WHERE MACH_CODE = @code", conn)
                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = mach_id.Text
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Successfully deleted.")
                machinemanager_Load(e, e)


            End If
        End If

    End Sub

    Private Sub editbtn_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        Dim i As Integer = maindgv.CurrentRow.Index

        If i = -1 Then

        Else

            Category.TextBox2.Text = maindgv.Item(0, i).Value
            Category.TextBox1.Text = maindgv.Item(1, i).Value

            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM MACH_SUBC WHERE MCAT_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = maindgv.Item(0, i).Value
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                For i = 0 To t.Rows.Count - 1
                    Category.DataGridView1.Rows.Add(t.Rows(i)(0).ToString, t.Rows(i)(1).ToString)
                Next


            End If

            Category.ShowDialog()

        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)
        'Select Case (e.Action)
        '    Case TreeViewAction.ByMouse
        '        If TreeView1.SelectedNode.Nodes.Count = 0 Then

        '            Label6.Text = TreeView1.SelectedNode.Parent.Text
        '            Label7.Text = TreeView1.SelectedNode.Text
        '        Else

        '            Label6.Text = TreeView1.SelectedNode.Text
        '            Label7.Text = ""
        '        End If
        'End Select
    End Sub

    Private Sub maindgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles maindgv.CellClick
        detaildgv.Rows.Clear()
        subdgv.Rows.Clear()

        Dim i As Integer = maindgv.CurrentRow.Index

        If i = -1 Then
        Else
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM MACH_SUBC WHERE MCAT_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = maindgv.Item(0, i).Value
            Dim a As New SqlDataAdapter(cmd)
            Dim t As New DataTable
            a.Fill(t)
            cmd.ExecuteNonQuery()
            conn.Close()

            For j = 0 To t.Rows.Count - 1
                subdgv.Rows.Add(t.Rows(j)(0).ToString, t.Rows(j)(1).ToString)
            Next

            ' display from main machine database
            conn.Open()
            Dim cm As New SqlCommand("SELECT * FROM SCO_MACH WHERE MCAT_ID = @id", conn)
            cm.Parameters.Add("@id", SqlDbType.VarChar).Value = maindgv.Item(0, i).Value
            Dim ad As New SqlDataAdapter(cm)
            Dim tb As New DataTable
            ad.Fill(tb)
            cm.ExecuteNonQuery()
            conn.Close()

            If tb.Rows.Count = Nothing Then
            Else
                For x = 0 To tb.Rows.Count - 1
                    detaildgv.Rows.Add(tb.Rows(x)(0).ToString, tb.Rows(x)(1).ToString, tb.Rows(x)(2).ToString, tb.Rows(x)(3).ToString, tb.Rows(x)(4).ToString)
                Next
            End If

            ToolStripStatusLabel4.Text = t.Rows.Count

            countdetaildgv()

        End If
    End Sub

    Private Sub subdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles subdgv.CellClick
        detaildgv.Rows.Clear()

        Dim i As Integer = subdgv.CurrentRow.Index
        Dim j As Integer = maindgv.CurrentRow.Index

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_MACH WHERE SCAT_ID = @id AND MCAT_ID = @mid", conn)
        cmd.Parameters.Add("@mid", SqlDbType.VarChar).Value = maindgv.Item(0, i).Value
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = subdgv.Item(0, i).Value
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        If t.Rows.Count = Nothing Then
        Else
            For x = 0 To t.Rows.Count - 1
                detaildgv.Rows.Add(t.Rows(x)(0).ToString, t.Rows(x)(1).ToString, t.Rows(x)(2).ToString, t.Rows(x)(3).ToString, t.Rows(x)(4).ToString)
            Next

            countdetaildgv()
        End If
    End Sub

    Private Sub detaildgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles detaildgv.CellClick
        Dim i As Integer = detaildgv.CurrentRow.Index

        If i = -1 Then
        Else
            mach_id.Text = detaildgv.Item(0, i).Value
            mach_desc.Text = detaildgv.Item(1, i).Value
            mainc_cb.SelectedValue = detaildgv.Item(2, i).Value
            subcat_cb.SelectedValue = detaildgv.Item(3, i).Value
            ownasset.Text = detaildgv.Item(4, i).Value

        End If
    End Sub

    Private Sub detaildgv_SelectionChanged(sender As Object, e As EventArgs) Handles detaildgv.SelectionChanged
        Dim i As Integer = detaildgv.CurrentRow.Index

        If i = -1 Then
        Else
            mach_id.Text = detaildgv.Item(0, i).Value
            mach_desc.Text = detaildgv.Item(1, i).Value
            mainc_cb.SelectedValue = detaildgv.Item(2, i).Value
            subcat_cb.SelectedValue = detaildgv.Item(3, i).Value
            ownasset.Text = detaildgv.Item(4, i).Value

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' overwrite the data

        ' checking if the data exist in the database
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_MACH WHERE MACH_CODE = @id", conn)
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = mach_id.Text
        Dim ad As New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        ad.Fill(tb)
        cmd.ExecuteNonQuery()
        conn.Close()

        If tb.Rows.Count = Nothing Then
            ' adding new data to the database
            conn.Open()
            Dim cm As New SqlCommand("INSERT INTO SCO_MACH (MACH_CODE, MACH_DESC, MCAT_ID, SCAT_ID, MACH_OWN) VALUES (@code, @desc, @mid, @sid, @own)", conn)
            cm.Parameters.Add("@code", SqlDbType.VarChar).Value = mach_id.Text
            cm.Parameters.Add("@desc", SqlDbType.VarChar).Value = mach_desc.Text
            cm.Parameters.Add("@mid", SqlDbType.VarChar).Value = mainc_cb.SelectedValue
            cm.Parameters.Add("@sid", SqlDbType.VarChar).Value = subcat_cb.SelectedValue
            cm.Parameters.Add("@own", SqlDbType.VarChar).Value = ownasset.Text
            cm.ExecuteNonQuery()
            conn.Close()

            MsgBox("Data added successfully.")
        Else
            ' edit the existing one
            'conn.Open()
            'Dim delcm As New SqlCommand("DELETE FROM SCO_MACH WHERE MACH_ID = @id", conn)
            'delcm.Parameters.Add("@id", SqlDbType.VarChar).Value = mach_id.Text
            'delcm.ExecuteNonQuery()
            'conn.Close()
            ' insert the new updated one

            ' update
            conn.Open()
            Dim cm As New SqlCommand("UPDATE SCO_MACH SET MACH_DESC = @desc, MCAT_ID = @mid, SCAT_ID = @sid, MACH_OWN = @own WHERE MACH_CODE = @code", conn)
            cm.Parameters.Add("@code", SqlDbType.VarChar).Value = mach_id.Text
            cm.Parameters.Add("@desc", SqlDbType.VarChar).Value = mach_desc.Text
            cm.Parameters.Add("@mid", SqlDbType.VarChar).Value = mainc_cb.SelectedValue
            cm.Parameters.Add("@sid", SqlDbType.VarChar).Value = subcat_cb.SelectedValue
            cm.Parameters.Add("@own", SqlDbType.VarChar).Value = ownasset.Text
            cm.ExecuteNonQuery()
            conn.Close()

            MsgBox("Data updated successfully.")

            detaildgv.Rows.Clear()

            Dim i As Integer = subdgv.CurrentRow.Index

            conn.Open()
            Dim dgvcmd As New SqlCommand("SELECT * FROM SCO_MACH WHERE SCAT_ID = @id", conn)
            dgvcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = subdgv.Item(0, i).Value
            Dim a As New SqlDataAdapter(dgvcmd)
            Dim t As New DataTable
            a.Fill(t)
            dgvcmd.ExecuteNonQuery()
            conn.Close()

            If t.Rows.Count = Nothing Then
            Else
                For x = 0 To t.Rows.Count - 1
                    detaildgv.Rows.Add(t.Rows(x)(0).ToString, t.Rows(x)(1).ToString, t.Rows(x)(2).ToString, t.Rows(x)(3).ToString, t.Rows(x)(4).ToString)
                Next
            End If
        End If

        mach_id.Enabled = True

        GroupBox1.Enabled = True
        Panel3.Enabled = False
        Panel2.Enabled = True

        detaildgv.Enabled = True

        countdetaildgv()

    End Sub

    Private Sub machinemanager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GroupBox1.Enabled = True
        Panel3.Enabled = False
        btnSave.Visible = False
        btnCancel.Visible = False
        Panel2.Enabled = True
        mach_id.Enabled = True

        Panel3.Enabled = False
        detaildgv.Enabled = True
        maindgv.Rows.Clear()
        subdgv.Rows.Clear()
        detaildgv.Rows.Clear()

        ToolStripStatusLabel5.Text = ""
    End Sub

    Sub detaildata()
        detaildgv.Rows.Clear()

        Dim i As Integer = subdgv.CurrentRow.Index
        Dim j As Integer = maindgv.CurrentRow.Index

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_MACH WHERE SCAT_ID = @id AND MCAT_ID = @mid", conn)
        cmd.Parameters.Add("@mid", SqlDbType.VarChar).Value = maindgv.Item(0, i).Value
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = subdgv.Item(0, i).Value
        Dim a As New SqlDataAdapter(cmd)
        Dim t As New DataTable
        a.Fill(t)
        cmd.ExecuteNonQuery()
        conn.Close()

        If t.Rows.Count = Nothing Then
        Else
            For x = 0 To t.Rows.Count - 1
                detaildgv.Rows.Add(t.Rows(x)(0).ToString, t.Rows(x)(1).ToString, t.Rows(x)(2).ToString, t.Rows(x)(3).ToString, t.Rows(x)(4).ToString)
            Next

            countdetaildgv()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim midi As Integer = maindgv.CurrentRow.Index
        Dim sidi As Integer = subdgv.CurrentRow.Index

        If TextBox1.Text = "" Then
            detaildata()
            countdetaildgv()
        Else
            detaildgv.Rows.Clear()

            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM SCO_MACH WHERE MCAT_ID = @mid AND SCAT_ID = @sid AND MACH_CODE LIKE '" & TextBox1.Text & "%'", conn)
            cmd.Parameters.Add("@mid", SqlDbType.VarChar).Value = maindgv.Item(0, midi).Value
            cmd.Parameters.Add("@sid", SqlDbType.VarChar).Value = subdgv.Item(0, sidi).Value
            'cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = TextBox1.Text
            Dim ad As New SqlDataAdapter(cmd)
            Dim tb As New DataTable
            ad.Fill(tb)
            cmd.ExecuteNonQuery()
            conn.Close()

            If tb.Rows.Count = Nothing Then
                MsgBox("Data not found.")

                detaildata()
            Else
                For i = 0 To tb.Rows.Count - 1
                    detaildgv.Rows.Add(tb.Rows(i)(0).ToString, tb.Rows(i)(1).ToString, tb.Rows(i)(2).ToString, tb.Rows(i)(3).ToString, tb.Rows(i)(4).ToString)
                Next

            End If

            countdetaildgv()

        End If
    End Sub
End Class