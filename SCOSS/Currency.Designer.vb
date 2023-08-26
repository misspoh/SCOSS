<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Currency
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
        Dim CURR_IDLabel As System.Windows.Forms.Label
        Dim CURR_DESCLabel As System.Windows.Forms.Label
        Dim CURR_EXRATELabel As System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CURR_IDTextBox = New System.Windows.Forms.TextBox()
        Me.CURR_DESCTextBox = New System.Windows.Forms.TextBox()
        Me.CURR_EXRATETextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SCO_CURRENCYComboBox = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CURR_IDLabel = New System.Windows.Forms.Label()
        CURR_DESCLabel = New System.Windows.Forms.Label()
        CURR_EXRATELabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CURR_IDLabel
        '
        CURR_IDLabel.AutoSize = True
        CURR_IDLabel.Location = New System.Drawing.Point(29, 35)
        CURR_IDLabel.Name = "CURR_IDLabel"
        CURR_IDLabel.Size = New System.Drawing.Size(43, 13)
        CURR_IDLabel.TabIndex = 0
        CURR_IDLabel.Text = "Curr ID:"
        '
        'CURR_DESCLabel
        '
        CURR_DESCLabel.AutoSize = True
        CURR_DESCLabel.Location = New System.Drawing.Point(29, 63)
        CURR_DESCLabel.Name = "CURR_DESCLabel"
        CURR_DESCLabel.Size = New System.Drawing.Size(73, 13)
        CURR_DESCLabel.TabIndex = 2
        CURR_DESCLabel.Text = "CURR DESC:"
        '
        'CURR_EXRATELabel
        '
        CURR_EXRATELabel.AutoSize = True
        CURR_EXRATELabel.Location = New System.Drawing.Point(211, 35)
        CURR_EXRATELabel.Name = "CURR_EXRATELabel"
        CURR_EXRATELabel.Size = New System.Drawing.Size(33, 13)
        CURR_EXRATELabel.TabIndex = 4
        CURR_EXRATELabel.Text = "Rate:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(460, 40)
        Me.Panel1.TabIndex = 11
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
        Me.Panel2.TabIndex = 12
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(CURR_IDLabel)
        Me.GroupBox1.Controls.Add(Me.CURR_IDTextBox)
        Me.GroupBox1.Controls.Add(CURR_DESCLabel)
        Me.GroupBox1.Controls.Add(Me.CURR_DESCTextBox)
        Me.GroupBox1.Controls.Add(CURR_EXRATELabel)
        Me.GroupBox1.Controls.Add(Me.CURR_EXRATETextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(42, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 131)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Currency Details"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(224, 88)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Set as default"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CURR_IDTextBox
        '
        Me.CURR_IDTextBox.Location = New System.Drawing.Point(107, 32)
        Me.CURR_IDTextBox.Name = "CURR_IDTextBox"
        Me.CURR_IDTextBox.ReadOnly = True
        Me.CURR_IDTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CURR_IDTextBox.TabIndex = 1
        '
        'CURR_DESCTextBox
        '
        Me.CURR_DESCTextBox.Location = New System.Drawing.Point(107, 60)
        Me.CURR_DESCTextBox.Name = "CURR_DESCTextBox"
        Me.CURR_DESCTextBox.ReadOnly = True
        Me.CURR_DESCTextBox.Size = New System.Drawing.Size(219, 20)
        Me.CURR_DESCTextBox.TabIndex = 3
        '
        'CURR_EXRATETextBox
        '
        Me.CURR_EXRATETextBox.Location = New System.Drawing.Point(252, 32)
        Me.CURR_EXRATETextBox.Name = "CURR_EXRATETextBox"
        Me.CURR_EXRATETextBox.ReadOnly = True
        Me.CURR_EXRATETextBox.Size = New System.Drawing.Size(74, 20)
        Me.CURR_EXRATETextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Choose:"
        '
        'SCO_CURRENCYComboBox
        '
        Me.SCO_CURRENCYComboBox.DisplayMember = "CURR_ID"
        Me.SCO_CURRENCYComboBox.FormattingEnabled = True
        Me.SCO_CURRENCYComboBox.Location = New System.Drawing.Point(94, 92)
        Me.SCO_CURRENCYComboBox.Name = "SCO_CURRENCYComboBox"
        Me.SCO_CURRENCYComboBox.Size = New System.Drawing.Size(158, 21)
        Me.SCO_CURRENCYComboBox.TabIndex = 14
        Me.SCO_CURRENCYComboBox.ValueMember = "CURR_ID"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(412, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(36, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'Currency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(460, 296)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SCO_CURRENCYComboBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Currency"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Currency"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CURR_IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CURR_DESCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CURR_EXRATETextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SCO_CURRENCYComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
