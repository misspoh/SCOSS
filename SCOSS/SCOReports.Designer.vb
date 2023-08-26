<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCOReports
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cancelledSO = New System.Windows.Forms.CheckBox()
        Me.listingPOGroup = New System.Windows.Forms.GroupBox()
        Me.rangeCheckBox = New System.Windows.Forms.CheckBox()
        Me.multipleCheckBox = New System.Windows.Forms.CheckBox()
        Me.allCheckBox = New System.Windows.Forms.CheckBox()
        Me.multipleGroup = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MaskedTextBox5 = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox6 = New System.Windows.Forms.MaskedTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.summaryGroup = New System.Windows.Forms.GroupBox()
        Me.summCancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MaskedTextBox3 = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox4 = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.listingGroup = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.RemarksTextbox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.listingCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.listingPOGroup.SuspendLayout()
        Me.multipleGroup.SuspendLayout()
        Me.summaryGroup.SuspendLayout()
        Me.listingGroup.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(789, 34)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "      REPORTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(366, 34)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(423, 456)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.listingPOGroup)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.summaryGroup)
        Me.Panel1.Controls.Add(Me.listingGroup)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 456)
        Me.Panel1.TabIndex = 4
        '
        'cancelledSO
        '
        Me.cancelledSO.AutoSize = True
        Me.cancelledSO.Location = New System.Drawing.Point(179, 52)
        Me.cancelledSO.Name = "cancelledSO"
        Me.cancelledSO.Size = New System.Drawing.Size(128, 18)
        Me.cancelledSO.TabIndex = 30
        Me.cancelledSO.Text = "Include Cancelled SO"
        Me.cancelledSO.UseVisualStyleBackColor = True
        '
        'listingPOGroup
        '
        Me.listingPOGroup.Controls.Add(Me.rangeCheckBox)
        Me.listingPOGroup.Controls.Add(Me.multipleCheckBox)
        Me.listingPOGroup.Controls.Add(Me.allCheckBox)
        Me.listingPOGroup.Controls.Add(Me.multipleGroup)
        Me.listingPOGroup.Controls.Add(Me.Button3)
        Me.listingPOGroup.Controls.Add(Me.Button4)
        Me.listingPOGroup.Controls.Add(Me.Label11)
        Me.listingPOGroup.Controls.Add(Me.Label12)
        Me.listingPOGroup.Controls.Add(Me.Label13)
        Me.listingPOGroup.Controls.Add(Me.MaskedTextBox5)
        Me.listingPOGroup.Controls.Add(Me.MaskedTextBox6)
        Me.listingPOGroup.Enabled = False
        Me.listingPOGroup.Location = New System.Drawing.Point(16, 404)
        Me.listingPOGroup.Name = "listingPOGroup"
        Me.listingPOGroup.Size = New System.Drawing.Size(318, 289)
        Me.listingPOGroup.TabIndex = 29
        Me.listingPOGroup.TabStop = False
        Me.listingPOGroup.Text = "Listing Details By SO"
        '
        'rangeCheckBox
        '
        Me.rangeCheckBox.AutoSize = True
        Me.rangeCheckBox.Location = New System.Drawing.Point(109, 50)
        Me.rangeCheckBox.Name = "rangeCheckBox"
        Me.rangeCheckBox.Size = New System.Drawing.Size(57, 18)
        Me.rangeCheckBox.TabIndex = 42
        Me.rangeCheckBox.Text = "Range"
        Me.rangeCheckBox.UseVisualStyleBackColor = True
        Me.rangeCheckBox.Visible = False
        '
        'multipleCheckBox
        '
        Me.multipleCheckBox.AutoSize = True
        Me.multipleCheckBox.Location = New System.Drawing.Point(176, 50)
        Me.multipleCheckBox.Name = "multipleCheckBox"
        Me.multipleCheckBox.Size = New System.Drawing.Size(61, 18)
        Me.multipleCheckBox.TabIndex = 41
        Me.multipleCheckBox.Text = "Multiple"
        Me.multipleCheckBox.UseVisualStyleBackColor = True
        '
        'allCheckBox
        '
        Me.allCheckBox.AutoSize = True
        Me.allCheckBox.Location = New System.Drawing.Point(243, 50)
        Me.allCheckBox.Name = "allCheckBox"
        Me.allCheckBox.Size = New System.Drawing.Size(38, 18)
        Me.allCheckBox.TabIndex = 40
        Me.allCheckBox.Text = "All"
        Me.allCheckBox.UseVisualStyleBackColor = True
        '
        'multipleGroup
        '
        Me.multipleGroup.Controls.Add(Me.Button6)
        Me.multipleGroup.Controls.Add(Me.Button5)
        Me.multipleGroup.Controls.Add(Me.ListBox2)
        Me.multipleGroup.Controls.Add(Me.ListBox1)
        Me.multipleGroup.Enabled = False
        Me.multipleGroup.Location = New System.Drawing.Point(14, 74)
        Me.multipleGroup.Name = "multipleGroup"
        Me.multipleGroup.Size = New System.Drawing.Size(293, 167)
        Me.multipleGroup.TabIndex = 39
        Me.multipleGroup.TabStop = False
        Me.multipleGroup.Text = "Multiple"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(127, 74)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 29)
        Me.Button6.TabIndex = 38
        Me.Button6.Text = "<<"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(127, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 29)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = ">>"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 14
        Me.ListBox2.Location = New System.Drawing.Point(177, 16)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(103, 144)
        Me.ListBox2.TabIndex = 36
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(14, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(103, 144)
        Me.ListBox1.TabIndex = 35
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(206, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 27)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(123, 248)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 27)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Preview"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(83, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 14)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "From:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Date Report"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(193, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 14)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "To:"
        '
        'MaskedTextBox5
        '
        Me.MaskedTextBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox5.Location = New System.Drawing.Point(214, 26)
        Me.MaskedTextBox5.Mask = "00/00/0000"
        Me.MaskedTextBox5.Name = "MaskedTextBox5"
        Me.MaskedTextBox5.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox5.TabIndex = 24
        Me.MaskedTextBox5.ValidatingType = GetType(Date)
        '
        'MaskedTextBox6
        '
        Me.MaskedTextBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox6.Location = New System.Drawing.Point(123, 26)
        Me.MaskedTextBox6.Mask = "00/00/0000"
        Me.MaskedTextBox6.Name = "MaskedTextBox6"
        Me.MaskedTextBox6.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox6.TabIndex = 23
        Me.MaskedTextBox6.ValidatingType = GetType(Date)
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(222, 674)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 27)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'summaryGroup
        '
        Me.summaryGroup.Controls.Add(Me.summCancel)
        Me.summaryGroup.Controls.Add(Me.Button1)
        Me.summaryGroup.Controls.Add(Me.Label10)
        Me.summaryGroup.Controls.Add(Me.CheckBox1)
        Me.summaryGroup.Controls.Add(Me.Label7)
        Me.summaryGroup.Controls.Add(Me.Label8)
        Me.summaryGroup.Controls.Add(Me.MaskedTextBox3)
        Me.summaryGroup.Controls.Add(Me.MaskedTextBox4)
        Me.summaryGroup.Controls.Add(Me.Label9)
        Me.summaryGroup.Enabled = False
        Me.summaryGroup.Location = New System.Drawing.Point(16, 277)
        Me.summaryGroup.Name = "summaryGroup"
        Me.summaryGroup.Size = New System.Drawing.Size(318, 121)
        Me.summaryGroup.TabIndex = 20
        Me.summaryGroup.TabStop = False
        Me.summaryGroup.Text = " Summary Details "
        '
        'summCancel
        '
        Me.summCancel.Location = New System.Drawing.Point(206, 86)
        Me.summCancel.Name = "summCancel"
        Me.summCancel.Size = New System.Drawing.Size(75, 27)
        Me.summCancel.TabIndex = 21
        Me.summCancel.Text = "Cancel"
        Me.summCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(123, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Preview"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(11, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 28)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Include Machine No: N. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tick ""Exclude"" to exclude N"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(155, 54)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(64, 18)
        Me.CheckBox1.TabIndex = 26
        Me.CheckBox1.Text = "Exclude"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(83, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 14)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "From:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 14)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Date Report"
        '
        'MaskedTextBox3
        '
        Me.MaskedTextBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox3.Location = New System.Drawing.Point(123, 28)
        Me.MaskedTextBox3.Mask = "00/00/0000"
        Me.MaskedTextBox3.Name = "MaskedTextBox3"
        Me.MaskedTextBox3.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox3.TabIndex = 23
        Me.MaskedTextBox3.ValidatingType = GetType(Date)
        '
        'MaskedTextBox4
        '
        Me.MaskedTextBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox4.Location = New System.Drawing.Point(214, 28)
        Me.MaskedTextBox4.Mask = "00/00/0000"
        Me.MaskedTextBox4.Name = "MaskedTextBox4"
        Me.MaskedTextBox4.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox4.TabIndex = 22
        Me.MaskedTextBox4.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(193, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 14)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "To:"
        '
        'listingGroup
        '
        Me.listingGroup.Controls.Add(Me.CheckBox3)
        Me.listingGroup.Controls.Add(Me.RemarksTextbox)
        Me.listingGroup.Controls.Add(Me.Label14)
        Me.listingGroup.Controls.Add(Me.listingCancel)
        Me.listingGroup.Controls.Add(Me.Label6)
        Me.listingGroup.Controls.Add(Me.Label4)
        Me.listingGroup.Controls.Add(Me.btnPreview)
        Me.listingGroup.Controls.Add(Me.MaskedTextBox2)
        Me.listingGroup.Controls.Add(Me.CheckBox2)
        Me.listingGroup.Controls.Add(Me.MaskedTextBox1)
        Me.listingGroup.Controls.Add(Me.ComboBox2)
        Me.listingGroup.Controls.Add(Me.TextBox2)
        Me.listingGroup.Controls.Add(Me.Label3)
        Me.listingGroup.Controls.Add(Me.Label5)
        Me.listingGroup.Controls.Add(Me.TextBox1)
        Me.listingGroup.Enabled = False
        Me.listingGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listingGroup.Location = New System.Drawing.Point(16, 100)
        Me.listingGroup.Name = "listingGroup"
        Me.listingGroup.Size = New System.Drawing.Size(318, 171)
        Me.listingGroup.TabIndex = 19
        Me.listingGroup.TabStop = False
        Me.listingGroup.Text = " Listing Details "
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(130, 78)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(140, 18)
        Me.CheckBox3.TabIndex = 23
        Me.CheckBox3.Text = "Exclude Non-Machinery"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'RemarksTextbox
        '
        Me.RemarksTextbox.Location = New System.Drawing.Point(86, 103)
        Me.RemarksTextbox.Name = "RemarksTextbox"
        Me.RemarksTextbox.Size = New System.Drawing.Size(195, 20)
        Me.RemarksTextbox.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 14)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Purpose"
        '
        'listingCancel
        '
        Me.listingCancel.Location = New System.Drawing.Point(206, 133)
        Me.listingCancel.Name = "listingCancel"
        Me.listingCancel.Size = New System.Drawing.Size(75, 27)
        Me.listingCancel.TabIndex = 20
        Me.listingCancel.Text = "Cancel"
        Me.listingCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(83, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "From:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Date Report"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(123, 133)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 27)
        Me.btnPreview.TabIndex = 7
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox2.Location = New System.Drawing.Point(214, 24)
        Me.MaskedTextBox2.Mask = "00/00/0000"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox2.TabIndex = 18
        Me.MaskedTextBox2.ValidatingType = GetType(Date)
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(86, 78)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(38, 18)
        Me.CheckBox2.TabIndex = 9
        Me.CheckBox2.Text = "All"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox1.Location = New System.Drawing.Point(123, 24)
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(67, 20)
        Me.MaskedTextBox1.TabIndex = 17
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'ComboBox2
        '
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.DisplayMember = "PO_MACHN"
        Me.ComboBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(86, 50)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(195, 22)
        Me.ComboBox2.TabIndex = 6
        Me.ComboBox2.ValueMember = "PO_MACHN"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(86, 178)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(63, 20)
        Me.TextBox2.TabIndex = 16
        Me.TextBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "To:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 14)
        Me.Label5.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(13, 178)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(67, 20)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cancelledSO)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 85)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "  Choose Report  "
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"NA", "Service Order Listing - By Supplier", "Service Order Listing - By Machine No", "Service Order Listing - By SO", "Service Order Summary"})
        Me.ComboBox1.Location = New System.Drawing.Point(88, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(219, 22)
        Me.ComboBox1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Report Name:"
        '
        'SCOReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 490)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SCOReports"
        Me.Text = "Reports"
        Me.Panel1.ResumeLayout(False)
        Me.listingPOGroup.ResumeLayout(False)
        Me.listingPOGroup.PerformLayout()
        Me.multipleGroup.ResumeLayout(False)
        Me.summaryGroup.ResumeLayout(False)
        Me.summaryGroup.PerformLayout()
        Me.listingGroup.ResumeLayout(False)
        Me.listingGroup.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents listingPOGroup As System.Windows.Forms.GroupBox
    Friend WithEvents rangeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents multipleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents allCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents multipleGroup As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents summaryGroup As System.Windows.Forms.GroupBox
    Friend WithEvents summCancel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents listingGroup As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents RemarksTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents listingCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cancelledSO As System.Windows.Forms.CheckBox
End Class
