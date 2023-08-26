<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tax
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
        Dim TAX_IDLabel As System.Windows.Forms.Label
        Dim TAX_DESCLabel As System.Windows.Forms.Label
        Dim TAX_RATELabel As System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TAX_IDTextBox = New System.Windows.Forms.TextBox()
        Me.TAX_DESCTextBox = New System.Windows.Forms.TextBox()
        Me.TAX_RATETextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SCO_TAXComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        TAX_IDLabel = New System.Windows.Forms.Label()
        TAX_DESCLabel = New System.Windows.Forms.Label()
        TAX_RATELabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TAX_IDLabel
        '
        TAX_IDLabel.AutoSize = True
        TAX_IDLabel.Location = New System.Drawing.Point(20, 34)
        TAX_IDLabel.Name = "TAX_IDLabel"
        TAX_IDLabel.Size = New System.Drawing.Size(42, 13)
        TAX_IDLabel.TabIndex = 0
        TAX_IDLabel.Text = "Tax ID:"
        '
        'TAX_DESCLabel
        '
        TAX_DESCLabel.AutoSize = True
        TAX_DESCLabel.Location = New System.Drawing.Point(20, 62)
        TAX_DESCLabel.Name = "TAX_DESCLabel"
        TAX_DESCLabel.Size = New System.Drawing.Size(63, 13)
        TAX_DESCLabel.TabIndex = 2
        TAX_DESCLabel.Text = "Description:"
        '
        'TAX_RATELabel
        '
        TAX_RATELabel.AutoSize = True
        TAX_RATELabel.Location = New System.Drawing.Point(190, 34)
        TAX_RATELabel.Name = "TAX_RATELabel"
        TAX_RATELabel.Size = New System.Drawing.Size(33, 13)
        TAX_RATELabel.TabIndex = 4
        TAX_RATELabel.Text = "Rate:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(TAX_IDLabel)
        Me.GroupBox1.Controls.Add(Me.TAX_IDTextBox)
        Me.GroupBox1.Controls.Add(TAX_DESCLabel)
        Me.GroupBox1.Controls.Add(Me.TAX_DESCTextBox)
        Me.GroupBox1.Controls.Add(TAX_RATELabel)
        Me.GroupBox1.Controls.Add(Me.TAX_RATETextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 134)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tax Details"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(264, 87)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Default"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TAX_IDTextBox
        '
        Me.TAX_IDTextBox.Location = New System.Drawing.Point(100, 31)
        Me.TAX_IDTextBox.Name = "TAX_IDTextBox"
        Me.TAX_IDTextBox.ReadOnly = True
        Me.TAX_IDTextBox.Size = New System.Drawing.Size(83, 20)
        Me.TAX_IDTextBox.TabIndex = 1
        '
        'TAX_DESCTextBox
        '
        Me.TAX_DESCTextBox.Location = New System.Drawing.Point(100, 59)
        Me.TAX_DESCTextBox.Name = "TAX_DESCTextBox"
        Me.TAX_DESCTextBox.ReadOnly = True
        Me.TAX_DESCTextBox.Size = New System.Drawing.Size(231, 20)
        Me.TAX_DESCTextBox.TabIndex = 3
        '
        'TAX_RATETextBox
        '
        Me.TAX_RATETextBox.Location = New System.Drawing.Point(231, 31)
        Me.TAX_RATETextBox.Name = "TAX_RATETextBox"
        Me.TAX_RATETextBox.ReadOnly = True
        Me.TAX_RATETextBox.Size = New System.Drawing.Size(100, 20)
        Me.TAX_RATETextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Choose Tax:"
        '
        'SCO_TAXComboBox
        '
        Me.SCO_TAXComboBox.DisplayMember = "TAX_DESC"
        Me.SCO_TAXComboBox.FormattingEnabled = True
        Me.SCO_TAXComboBox.Location = New System.Drawing.Point(133, 88)
        Me.SCO_TAXComboBox.Name = "SCO_TAXComboBox"
        Me.SCO_TAXComboBox.Size = New System.Drawing.Size(140, 21)
        Me.SCO_TAXComboBox.TabIndex = 13
        Me.SCO_TAXComboBox.ValueMember = "TAX_ID"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(460, 34)
        Me.Panel2.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(412, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(36, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCancel.Enabled = False
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(300, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 34)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Enabled = False
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(225, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 34)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(150, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 34)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.Enabled = False
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(75, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 34)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(0, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 34)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 40)
        Me.Panel1.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.Label2.Location = New System.Drawing.Point(20, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "CURRENCY"
        '
        'Tax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 296)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SCO_TAXComboBox)
        Me.Name = "Tax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TAX_IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TAX_DESCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TAX_RATETextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SCO_TAXComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
