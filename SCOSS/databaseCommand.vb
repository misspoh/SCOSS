Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Module databaseCommand
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 


    Sub insert(data() As String, tbname As String)
        conn = New SqlConnection(constr)

        conn.Open()
        Dim cmd As New SqlCommand("INSERT INTO ", conn)

        conn.Close()
    End Sub

    Sub update(data() As String, tbname As String)

    End Sub
End Module
