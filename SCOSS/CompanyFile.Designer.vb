<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.faxtxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.teltxt = New System.Windows.Forms.TextBox()
        Me.notxt = New System.Windows.Forms.TextBox()
        Me.addtxt = New System.Windows.Forms.TextBox()
        Me.nametxt = New System.Windows.Forms.TextBox()
        Me.idtxt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAmend = New System.Windows.Forms.Button()
        Me.gsttxt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(729, 53)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COMPANY DETAILS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CO ID:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gsttxt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.faxtxt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.teltxt)
        Me.GroupBox1.Controls.Add(Me.notxt)
        Me.GroupBox1.Controls.Add(Me.addtxt)
        Me.GroupBox1.Controls.Add(Me.nametxt)
        Me.GroupBox1.Controls.Add(Me.idtxt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(693, 304)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETAILS"
        '
        'faxtxt
        '
        Me.faxtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.faxtxt.Location = New System.Drawing.Point(94, 194)
        Me.faxtxt.Name = "faxtxt"
        Me.faxtxt.ReadOnly = True
        Me.faxtxt.Size = New System.Drawing.Size(572, 22)
        Me.faxtxt.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "FAX:"
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(566, 250)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 36)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(460, 250)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 36)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'teltxt
        '
        Me.teltxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teltxt.Location = New System.Drawing.Point(94, 166)
        Me.teltxt.Name = "teltxt"
        Me.teltxt.ReadOnly = True
        Me.teltxt.Size = New System.Drawing.Size(572, 22)
        Me.teltxt.TabIndex = 11
        '
        'notxt
        '
        Me.notxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.notxt.Location = New System.Drawing.Point(94, 138)
        Me.notxt.Name = "notxt"
        Me.notxt.ReadOnly = True
        Me.notxt.Size = New System.Drawing.Size(572, 22)
        Me.notxt.TabIndex = 10
        '
        'addtxt
        '
        Me.addtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.addtxt.Location = New System.Drawing.Point(94, 60)
        Me.addtxt.Multiline = True
        Me.addtxt.Name = "addtxt"
        Me.addtxt.ReadOnly = True
        Me.addtxt.Size = New System.Drawing.Size(572, 72)
        Me.addtxt.TabIndex = 9
        '
        'nametxt
        '
        Me.nametxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nametxt.Location = New System.Drawing.Point(289, 32)
        Me.nametxt.Name = "nametxt"
        Me.nametxt.ReadOnly = True
        Me.nametxt.Size = New System.Drawing.Size(377, 22)
        Me.nametxt.TabIndex = 8
        '
        'idtxt
        '
        Me.idtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.idtxt.Location = New System.Drawing.Point(94, 32)
        Me.idtxt.Name = "idtxt"
        Me.idtxt.ReadOnly = True
        Me.idtxt.Size = New System.Drawing.Size(115, 22)
        Me.idtxt.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "TEL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "CO NO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "ADDRESS:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "NAME:"
        '
        'btnAmend
        '
        Me.btnAmend.Location = New System.Drawing.Point(17, 59)
        Me.btnAmend.Name = "btnAmend"
        Me.btnAmend.Size = New System.Drawing.Size(100, 36)
        Me.btnAmend.TabIndex = 14
        Me.btnAmend.Text = "Amend"
        Me.btnAmend.UseVisualStyleBackColor = True
        '
        'gsttxt
        '
        Me.gsttxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.gsttxt.Location = New System.Drawing.Point(94, 222)
        Me.gsttxt.Name = "gsttxt"
        Me.gsttxt.ReadOnly = True
        Me.gsttxt.Size = New System.Drawing.Size(572, 22)
        Me.gsttxt.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "GST NO.:"
        '
        'CompanyFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(729, 432)
        Me.Controls.Add(Me.btnAmend)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CompanyFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Company File"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents teltxt As System.Windows.Forms.TextBox
    Friend WithEvents notxt As System.Windows.Forms.TextBox
    Friend WithEvents addtxt As System.Windows.Forms.TextBox
    Friend WithEvents nametxt As System.Windows.Forms.TextBox
    Friend WithEvents idtxt As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAmend As System.Windows.Forms.Button
    Friend WithEvents faxtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gsttxt As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
