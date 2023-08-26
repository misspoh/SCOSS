<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmendForm
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
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnCancelSO = New System.Windows.Forms.Button()
        Me.btnEditSO = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.sonotxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dateMB = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.suppCB = New System.Windows.Forms.ComboBox()
        Me.sodetail = New System.Windows.Forms.GroupBox()
        Me.suppCode = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveSO = New System.Windows.Forms.Button()
        Me.stockdetails = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEditStock = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.stocknolabel = New System.Windows.Forms.Label()
        Me.btnSaveStock = New System.Windows.Forms.Button()
        Me.btnCancelStock = New System.Windows.Forms.Button()
        Me.invdate = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.invtxt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.desctxt = New System.Windows.Forms.TextBox()
        Me.sectCode = New System.Windows.Forms.Label()
        Me.machCode = New System.Windows.Forms.Label()
        Me.sectCB = New System.Windows.Forms.ComboBox()
        Me.machCB = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sostatus = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.sonolabel = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.sodetail.SuspendLayout()
        Me.stockdetails.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.btnCancelSO)
        Me.Panel1.Controls.Add(Me.btnEditSO)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.sonotxt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(806, 57)
        Me.Panel1.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.Enabled = False
        Me.btnReset.Location = New System.Drawing.Point(456, 17)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(96, 22)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnCancelSO
        '
        Me.btnCancelSO.Enabled = False
        Me.btnCancelSO.Location = New System.Drawing.Point(685, 17)
        Me.btnCancelSO.Name = "btnCancelSO"
        Me.btnCancelSO.Size = New System.Drawing.Size(108, 22)
        Me.btnCancelSO.TabIndex = 4
        Me.btnCancelSO.Text = "Cancel SO"
        Me.btnCancelSO.UseVisualStyleBackColor = True
        '
        'btnEditSO
        '
        Me.btnEditSO.Enabled = False
        Me.btnEditSO.Location = New System.Drawing.Point(571, 17)
        Me.btnEditSO.Name = "btnEditSO"
        Me.btnEditSO.Size = New System.Drawing.Size(108, 22)
        Me.btnEditSO.TabIndex = 3
        Me.btnEditSO.Text = "Edit SO NO"
        Me.btnEditSO.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(354, 17)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(96, 22)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'sonotxt
        '
        Me.sonotxt.Location = New System.Drawing.Point(81, 18)
        Me.sonotxt.Name = "sonotxt"
        Me.sonotxt.Size = New System.Drawing.Size(267, 21)
        Me.sonotxt.TabIndex = 1
        Me.sonotxt.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SO NO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date:"
        '
        'dateMB
        '
        Me.dateMB.Location = New System.Drawing.Point(66, 24)
        Me.dateMB.Mask = "00/00/0000"
        Me.dateMB.Name = "dateMB"
        Me.dateMB.Size = New System.Drawing.Size(101, 21)
        Me.dateMB.TabIndex = 2
        Me.dateMB.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Supplier:"
        '
        'suppCB
        '
        Me.suppCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.suppCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.suppCB.FormattingEnabled = True
        Me.suppCB.Location = New System.Drawing.Point(284, 24)
        Me.suppCB.Name = "suppCB"
        Me.suppCB.Size = New System.Drawing.Size(476, 23)
        Me.suppCB.TabIndex = 4
        '
        'sodetail
        '
        Me.sodetail.Controls.Add(Me.suppCode)
        Me.sodetail.Controls.Add(Me.suppCB)
        Me.sodetail.Controls.Add(Me.btnCancel)
        Me.sodetail.Controls.Add(Me.btnSaveSO)
        Me.sodetail.Controls.Add(Me.Label3)
        Me.sodetail.Controls.Add(Me.dateMB)
        Me.sodetail.Controls.Add(Me.Label2)
        Me.sodetail.Enabled = False
        Me.sodetail.Location = New System.Drawing.Point(12, 110)
        Me.sodetail.Name = "sodetail"
        Me.sodetail.Size = New System.Drawing.Size(781, 96)
        Me.sodetail.TabIndex = 5
        Me.sodetail.TabStop = False
        '
        'suppCode
        '
        Me.suppCode.AutoSize = True
        Me.suppCode.BackColor = System.Drawing.SystemColors.Info
        Me.suppCode.ForeColor = System.Drawing.Color.Firebrick
        Me.suppCode.Location = New System.Drawing.Point(281, 60)
        Me.suppCode.Name = "suppCode"
        Me.suppCode.Size = New System.Drawing.Size(86, 15)
        Me.suppCode.TabIndex = 5
        Me.suppCode.Text = "Supplier Code"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(667, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(93, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveSO
        '
        Me.btnSaveSO.Location = New System.Drawing.Point(568, 56)
        Me.btnSaveSO.Name = "btnSaveSO"
        Me.btnSaveSO.Size = New System.Drawing.Size(93, 23)
        Me.btnSaveSO.TabIndex = 15
        Me.btnSaveSO.Text = "Save"
        Me.btnSaveSO.UseVisualStyleBackColor = True
        '
        'stockdetails
        '
        Me.stockdetails.Controls.Add(Me.DataGridView1)
        Me.stockdetails.Controls.Add(Me.btnEditStock)
        Me.stockdetails.Controls.Add(Me.GroupBox3)
        Me.stockdetails.Location = New System.Drawing.Point(12, 212)
        Me.stockdetails.Name = "stockdetails"
        Me.stockdetails.Size = New System.Drawing.Size(781, 247)
        Me.stockdetails.TabIndex = 6
        Me.stockdetails.TabStop = False
        Me.stockdetails.Text = "Stock Details"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(152, 167)
        Me.DataGridView1.TabIndex = 16
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Stock No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'btnEditStock
        '
        Me.btnEditStock.Location = New System.Drawing.Point(15, 205)
        Me.btnEditStock.Name = "btnEditStock"
        Me.btnEditStock.Size = New System.Drawing.Size(152, 23)
        Me.btnEditStock.TabIndex = 2
        Me.btnEditStock.Text = "Edit"
        Me.btnEditStock.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.stocknolabel)
        Me.GroupBox3.Controls.Add(Me.btnSaveStock)
        Me.GroupBox3.Controls.Add(Me.btnCancelStock)
        Me.GroupBox3.Controls.Add(Me.invdate)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.invtxt)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.desctxt)
        Me.GroupBox3.Controls.Add(Me.sectCode)
        Me.GroupBox3.Controls.Add(Me.machCode)
        Me.GroupBox3.Controls.Add(Me.sectCB)
        Me.GroupBox3.Controls.Add(Me.machCB)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(192, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 220)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'stocknolabel
        '
        Me.stocknolabel.AutoSize = True
        Me.stocknolabel.ForeColor = System.Drawing.Color.Brown
        Me.stocknolabel.Location = New System.Drawing.Point(12, 184)
        Me.stocknolabel.Name = "stocknolabel"
        Me.stocknolabel.Size = New System.Drawing.Size(0, 15)
        Me.stocknolabel.TabIndex = 15
        '
        'btnSaveStock
        '
        Me.btnSaveStock.Location = New System.Drawing.Point(358, 184)
        Me.btnSaveStock.Name = "btnSaveStock"
        Me.btnSaveStock.Size = New System.Drawing.Size(93, 23)
        Me.btnSaveStock.TabIndex = 14
        Me.btnSaveStock.Text = "Save Stock"
        Me.btnSaveStock.UseVisualStyleBackColor = True
        '
        'btnCancelStock
        '
        Me.btnCancelStock.Location = New System.Drawing.Point(457, 184)
        Me.btnCancelStock.Name = "btnCancelStock"
        Me.btnCancelStock.Size = New System.Drawing.Size(93, 23)
        Me.btnCancelStock.TabIndex = 13
        Me.btnCancelStock.Text = "Cancel"
        Me.btnCancelStock.UseVisualStyleBackColor = True
        '
        'invdate
        '
        Me.invdate.Location = New System.Drawing.Point(449, 140)
        Me.invdate.Mask = "00/00/0000"
        Me.invdate.Name = "invdate"
        Me.invdate.Size = New System.Drawing.Size(101, 21)
        Me.invdate.TabIndex = 12
        Me.invdate.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(389, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 15)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Inv Date:"
        '
        'invtxt
        '
        Me.invtxt.Location = New System.Drawing.Point(74, 140)
        Me.invtxt.Name = "invtxt"
        Me.invtxt.Size = New System.Drawing.Size(297, 21)
        Me.invtxt.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Inv No:"
        '
        'desctxt
        '
        Me.desctxt.Location = New System.Drawing.Point(74, 77)
        Me.desctxt.Multiline = True
        Me.desctxt.Name = "desctxt"
        Me.desctxt.Size = New System.Drawing.Size(476, 57)
        Me.desctxt.TabIndex = 8
        '
        'sectCode
        '
        Me.sectCode.AutoSize = True
        Me.sectCode.BackColor = System.Drawing.SystemColors.Info
        Me.sectCode.ForeColor = System.Drawing.Color.Firebrick
        Me.sectCode.Location = New System.Drawing.Point(445, 51)
        Me.sectCode.Name = "sectCode"
        Me.sectCode.Size = New System.Drawing.Size(81, 15)
        Me.sectCode.TabIndex = 7
        Me.sectCode.Text = "Section Code"
        '
        'machCode
        '
        Me.machCode.AutoSize = True
        Me.machCode.BackColor = System.Drawing.SystemColors.Info
        Me.machCode.ForeColor = System.Drawing.Color.Firebrick
        Me.machCode.Location = New System.Drawing.Point(445, 22)
        Me.machCode.Name = "machCode"
        Me.machCode.Size = New System.Drawing.Size(86, 15)
        Me.machCode.TabIndex = 6
        Me.machCode.Text = "Machine Code"
        '
        'sectCB
        '
        Me.sectCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.sectCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.sectCB.FormattingEnabled = True
        Me.sectCB.Location = New System.Drawing.Point(74, 48)
        Me.sectCB.Name = "sectCB"
        Me.sectCB.Size = New System.Drawing.Size(365, 23)
        Me.sectCB.TabIndex = 6
        '
        'machCB
        '
        Me.machCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.machCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.machCB.FormattingEnabled = True
        Me.machCB.Location = New System.Drawing.Point(74, 19)
        Me.machCB.Name = "machCB"
        Me.machCB.Size = New System.Drawing.Size(365, 23)
        Me.machCB.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Desc:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Section:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Machine:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 474)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(806, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sostatus
        '
        Me.sostatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sostatus.ForeColor = System.Drawing.Color.Firebrick
        Me.sostatus.Location = New System.Drawing.Point(630, 80)
        Me.sostatus.Name = "sostatus"
        Me.sostatus.Size = New System.Drawing.Size(163, 30)
        Me.sostatus.TabIndex = 47
        Me.sostatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.sonolabel)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(231, 50)
        Me.GroupBox4.TabIndex = 46
        Me.GroupBox4.TabStop = False
        '
        'sonolabel
        '
        Me.sonolabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.sonolabel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sonolabel.ForeColor = System.Drawing.Color.Firebrick
        Me.sonolabel.Location = New System.Drawing.Point(65, 17)
        Me.sonolabel.Name = "sonolabel"
        Me.sonolabel.Size = New System.Drawing.Size(163, 30)
        Me.sonolabel.TabIndex = 1
        Me.sonolabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 15)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "SO NO:"
        '
        'AmendForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(806, 496)
        Me.Controls.Add(Me.sostatus)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.stockdetails)
        Me.Controls.Add(Me.sodetail)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AmendForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Amendment Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.sodetail.ResumeLayout(False)
        Me.sodetail.PerformLayout()
        Me.stockdetails.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents sonotxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateMB As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents suppCB As System.Windows.Forms.ComboBox
    Friend WithEvents sodetail As System.Windows.Forms.GroupBox
    Friend WithEvents suppCode As System.Windows.Forms.Label
    Friend WithEvents stockdetails As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents invdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents invtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents desctxt As System.Windows.Forms.TextBox
    Friend WithEvents sectCode As System.Windows.Forms.Label
    Friend WithEvents machCode As System.Windows.Forms.Label
    Friend WithEvents sectCB As System.Windows.Forms.ComboBox
    Friend WithEvents machCB As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEditStock As System.Windows.Forms.Button
    Friend WithEvents btnSaveStock As System.Windows.Forms.Button
    Friend WithEvents btnCancelStock As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnSaveSO As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEditSO As System.Windows.Forms.Button
    Friend WithEvents btnCancelSO As System.Windows.Forms.Button
    Friend WithEvents sostatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents sonolabel As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stocknolabel As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
End Class
