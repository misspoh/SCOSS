Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class ChangeStatus
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub ChangeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SCO_TEMPDataGridView.Rows.Clear()
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("SELECT DISTINCT SCO_NO FROM SCO_TEMP WHERE SCO_PRINT = 'PRINTED' ORDER BY SCO_NO", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        cmd.ExecuteNonQuery()
        conn.Close()

        If table.Rows.Count = Nothing Then
        Else
            For i As Integer = 0 To table.Rows.Count - 1
                SCO_TEMPDataGridView.Rows.Add(table.Rows(i)(0).ToString)
            Next
        End If
    End Sub

    Private Sub SCO_TEMPDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SCO_TEMPDataGridView.CellClick
        Dim rowindex As Integer
        rowindex = SCO_TEMPDataGridView.CurrentRow.Index

        Label1.Text = SCO_TEMPDataGridView.Item(0, rowindex).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Me.SCO_TEMPTableAdapter.UpdateQueryPrintStat("NOT PRINTED", Label1.Text)
        conn.Open()
        Dim cmd As New SqlCommand("UPDATE SCO_TEMP SET SCO_PRINT = @stat WHERE (SCO_NO = @no)", conn)
        cmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = "NOT PRINTED"
        cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = Label1.Text
        cmd.ExecuteNonQuery()
        conn.Close()

        MsgBox("Successfully updated.")

        ChangeStatus_Load(e, e)
        Label1.Text = ""
        Dim es As EventArgs

        Dim f1 As PostingForm = CType(Application.OpenForms("PostingForm"), PostingForm)

        f1.PostingForm_Load(e, e)
    End Sub
End Class