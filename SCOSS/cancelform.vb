Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration
Imports System.ComponentModel

Public Class cancelform
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

    Private Sub cancelform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(constr)

    End Sub
End Class