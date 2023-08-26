Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Configuration

Public Class MainMenu
    Dim constr As String = System.Configuration.ConfigurationManager.ConnectionStrings("SERVICE_ODERS.My.MySettings.SCOConnectionString").ConnectionString
    ' Dim constr As String = "Data Source=GTP-ANDY\SQLEXPRESS;Initial Catalog=WCP;User ID=WCP; Password=WCP" ' SQL data source
    Dim conn As SqlConnection = New SqlConnection  'sql connection 
    Dim comm As SqlCommand = New SqlCommand ' sql command
    Dim dr As SqlDataReader
    Dim save_type As String
    Dim Query As String
    Dim value_int As Integer

    Private Sub MainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        AmendmentFormToolStripMenuItem.Visible = False
        TestPreviewToolStripMenuItem.Visible = False
        Login.Close()
    End Sub

    Private Sub PostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostingToolStripMenuItem.Click

        If Application.OpenForms().OfType(Of PostingForm).Any Then
            MsgBox("Import form already open.")
        Else
            Dim newform As New PostingForm

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 0)
            newform.Show()
        End If
    End Sub

    Private Sub ServiceOrderEnquiriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceOrderEnquiriesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of EnquiriesForm).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New EnquiriesForm

            newform.MdiParent = Me
            newform.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If Application.OpenForms().OfType(Of Supplier).Any Then
            MsgBox("Import form already open.")
        Else
            '  Dim newform As New Supplier

            ' newform.MdiParent = Me
            ' newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 10)
            Supplier.Show()
        End If
    End Sub

    Private Sub SectionFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SectionFileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Section).Any Then
            MsgBox("Import form already open.")
        Else
            '  Dim newform As New Supplier

            ' newform.MdiParent = Me
            ' newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 10)
            Section.Show()
        End If
    End Sub

    Private Sub TaxFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaxFileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Tax).Any Then
            MsgBox("Import form already open.")
        Else
            '  Dim newform As New Supplier

            ' newform.MdiParent = Me
            ' newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 10)
            Tax.Show()
        End If
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of SCOReports).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New SCOReports

            newform.MdiParent = Me
            newform.Show()
        End If
    End Sub

    Private Sub ServiceOrderInvoiceUpdateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ServiceOrderInvoiceUpdateToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of InvoiceUpdate).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New InvoiceUpdate

            newform.MdiParent = Me
            newform.Show()
        End If
    End Sub

    Private Sub BackupAndRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupAndRestoreToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of BackupRestore).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New BackupRestore

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub CurrencyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrencyFileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Currency).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New Currency

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ToolStripStatusLabel1.Text = "LOGIN AS: ADMINISTRATOR" Then
            AmendmentFormToolStripMenuItem.Visible = True
            TestPreviewToolStripMenuItem.Visible = True
           
        End If
    End Sub

    Private Sub MachineFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MachineFileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Machine).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New Machine

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click

        AmendmentFormToolStripMenuItem.Visible = False
        TestPreviewToolStripMenuItem.Visible = False
        Me.Hide()
        Login.Show()
        Login.TextBox1.Text = ""
        Login.TextBox2.Text = ""
        Login.TextBox1.Focus()
    End Sub

    Private Sub ExportToAccToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToAccToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of ExportToAcc).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New ExportToAcc

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub CompanyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanyFileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of CompanyFile).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New CompanyFile

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub FILEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FILEToolStripMenuItem.Click

    End Sub

    Private Sub AmendmentFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmendmentFormToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of SOAmend).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New SOAmend

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub TestPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestPreviewToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Preview).Any Then
            ' MsgBox("Import form already open.")
        Else
            Preview.ShowDialog()
        End If
    End Sub

    Private Sub UserMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserMaintenanceToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of User).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New User

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of exporttoexcel).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New ExportToExcel

            newform.MdiParent = Me
            newform.Show()
        End If
    End Sub

    Private Sub Posting2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Posting2ToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of PostingF).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New PostingF

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub EnquiriesAmendmentFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnquiriesAmendmentFormToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of AmdForm).Any Then
            ' MsgBox("Import form already open.")
        Else
            Dim newform As New AmdForm

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 20)
            newform.Show()
        End If
    End Sub

    Private Sub PostingTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostingTestToolStripMenuItem.Click

        If Application.OpenForms().OfType(Of PostSCO).Any Then
            MsgBox("Import form already open.")
        Else
            Dim newform As New PostSCO

            newform.MdiParent = Me
            newform.Location = New Point(Me.Width / 2 - newform.Width / 2, 0)
            newform.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub
End Class