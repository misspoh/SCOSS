Public Class AppConfigReader
    Private Shared aSettingsReader As New System.Configuration.AppSettingsReader

    Private Shared strDBName As String = aSettingsReader.GetValue("DBName", GetType(String))
    Private Shared strSQLServer As String = aSettingsReader.GetValue("SQLServer", GetType(String))
    Private Shared strUser As String = aSettingsReader.GetValue("User", GetType(String))
    Private Shared strPwd As String = aSettingsReader.GetValue("Pwd", GetType(String))
    Private Shared strDSN As String = aSettingsReader.GetValue("DSN", GetType(String))
    Private Shared strCOName As String = aSettingsReader.GetValue("COName", GetType(String))
    Private Shared strCString As String = aSettingsReader.GetValue("CString", GetType(String))
    Private Shared strBPtah As String = aSettingsReader.GetValue("BPath", GetType(String))
    Private Shared strSavePath As String = aSettingsReader.GetValue("SavePath", GetType(String))

    Public Shared ReadOnly Property DBName() As String
        Get
            Return strDBName
        End Get
    End Property

    Public Shared ReadOnly Property SQLServer() As String
        Get
            Return strSQLServer
        End Get
    End Property


    Public Shared ReadOnly Property User() As String
        Get
            Return strUser
        End Get
    End Property

    Public Shared ReadOnly Property Pwd() As String
        Get
            Return strPwd
        End Get
    End Property

    Public Shared ReadOnly Property DSN() As String
        Get
            Return strDSN
        End Get
    End Property

    Public Shared ReadOnly Property COName() As String
        Get
            Return strCOName
        End Get
    End Property

    Public Shared ReadOnly Property CString() As String
        Get
            Return strCString
        End Get
    End Property

    Public Shared ReadOnly Property BPath() As String
        Get
            Return strBPtah
        End Get
    End Property

    Public Shared ReadOnly Property SavePath() As String
        Get
            Return strSavePath
        End Get
    End Property
End Class