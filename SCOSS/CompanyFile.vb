Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class CompanyFile
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub CompanyFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_CO", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
        Else
            idtxt.Text = table.Rows(0)(0).ToString
            nametxt.Text = table.Rows(0)(1).ToString
            notxt.Text = table.Rows(0)(2).ToString
            addtxt.Text = table.Rows(0)(3).ToString
            teltxt.Text = table.Rows(0)(4).ToString
            faxtxt.Text = table.Rows(0)(5).ToString
            gsttxt.Text = table.Rows(0)(6).ToString
        End If
    End Sub

    Private Sub btnAmend_Click(sender As Object, e As EventArgs) Handles btnAmend.Click
        idtxt.ReadOnly = False
        nametxt.ReadOnly = False
        notxt.ReadOnly = False
        addtxt.ReadOnly = False
        teltxt.ReadOnly = False
        faxtxt.ReadOnly = False
        gsttxt.ReadOnly = False

        btnAmend.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        conn.Open()
        Dim cmd As New SqlCommand("SELECT * FROM SCO_CO", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
            conn.Open()
            cmd = New SqlCommand("INSERT INTO SCO_CO (CO_ID, CO_NAME, CO_NO, CO_ADDRESS, CO_TEL, CO_FAX, CO_GST) VALUES (@id, @name, @no, @add, @tel, @fax, @gst)", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = idtxt.Text
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = nametxt.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = notxt.Text
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = addtxt.Text
            cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = teltxt.Text
            cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = faxtxt.Text
            cmd.Parameters.Add("@gst", SqlDbType.VarChar).Value = gsttxt.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully saved.")
        Else
            conn.Open()
            cmd = New SqlCommand("UPDATE SCO_CO SET CO_NAME = @name, CO_NO = @no, CO_ADDRESS = @add, CO_TEL = @tel, CO_FAX = @fax, CO_GST = @gst WHERE CO_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = idtxt.Text
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = nametxt.Text
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = notxt.Text
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = addtxt.Text
            cmd.Parameters.Add("@tel", SqlDbType.VarChar).Value = teltxt.Text
            cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = faxtxt.Text
            cmd.Parameters.Add("@gst", SqlDbType.VarChar).Value = gsttxt.Text
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Successfully saved.")
        End If

        idtxt.ReadOnly = True
        nametxt.ReadOnly = True
        notxt.ReadOnly = True
        addtxt.ReadOnly = True
        teltxt.ReadOnly = True
        faxtxt.ReadOnly = True
        gsttxt.ReadOnly = True

        btnAmend.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        idtxt.ReadOnly = True
        nametxt.ReadOnly = True
        notxt.ReadOnly = True
        addtxt.ReadOnly = True
        teltxt.ReadOnly = True
        faxtxt.ReadOnly = True
        gsttxt.ReadOnly = True

        btnAmend.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub idtxt_KeyDown(sender As Object, e As KeyEventArgs) Handles idtxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            nametxt.Focus()
        End If
    End Sub

    Private Sub nametxt_KeyDown(sender As Object, e As KeyEventArgs) Handles nametxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            addtxt.Focus()
        End If
    End Sub

    Private Sub addtxt_KeyDown(sender As Object, e As KeyEventArgs) Handles addtxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            notxt.Focus()
        End If
    End Sub

    Private Sub notxt_KeyDown(sender As Object, e As KeyEventArgs) Handles notxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            teltxt.Focus()
        End If
    End Sub

    Private Sub teltxt_KeyDown(sender As Object, e As KeyEventArgs) Handles teltxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            faxtxt.Focus()
        End If
    End Sub

    Private Sub faxtxt_KeyDown(sender As Object, e As KeyEventArgs) Handles faxtxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            gsttxt.Focus()
        End If
    End Sub

    Private Sub gsttxt_KeyDown(sender As Object, e As KeyEventArgs) Handles gsttxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
End Class