<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EnqForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.yearcb = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.supptxt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.datemb = New System.Windows.Forms.MaskedTextBox()
        Me.sonotxt = New System.Windows.Forms.TextBox()
        Me.RemarksTextBox = New System.Windows.Forms.TextBox()
        Me.PurposeTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.itemdesc = New System.Windows.Forms.TextBox()
        Me.amt = New System.Windows.Forms.TextBox()
        Me.taxamt = New System.Windows.Forms.TextBox()
        Me.discamt = New System.Windows.Forms.TextBox()
        Me.unitprice = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.currency = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.qtt = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.uom = New System.Windows.Forms.TextBox()
        Me.itemdate = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.invref = New System.Windows.Forms.TextBox()
        Me.machdesc = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.stocktxt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label23 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(391, 83)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(68, 15)
        Label6.TabIndex = 21
        Label6.Text = "REMARKS:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(27, 83)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(69, 15)
        Label7.TabIndex = 19
        Label7.Text = "PURPOSE:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(25, 95)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(88, 15)
        Label9.TabIndex = 20
        Label9.Text = "Machine Desc:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(25, 142)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(47, 15)
        Label10.TabIndex = 25
        Label10.Text = "Inv Ref:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(25, 169)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(37, 15)
        Label13.TabIndex = 29
        Label13.Text = "UOM:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label16.Location = New System.Drawing.Point(376, 168)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(58, 15)
        Label16.TabIndex = 37
        Label16.Text = "Disc Amt:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label17.Location = New System.Drawing.Point(570, 168)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(51, 15)
        Label17.TabIndex = 38
        Label17.Text = "Tax Amt:"
        '
        'Label18
        '
        Label18.AutoSize = True
        Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label18.Location = New System.Drawing.Point(377, 196)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(52, 15)
        Label18.TabIndex = 39
        Label18.Text = "Amount:"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label21.Location = New System.Drawing.Point(25, 25)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(66, 15)
        Label21.TabIndex = 43
        Label21.Text = "Item Desc:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 610)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(989, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.StatusStrip2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(789, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 610)
        Me.Panel1.TabIndex = 1
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(0, 112)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(200, 476)
        Me.ListBox1.TabIndex = 1
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 588)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(200, 22)
        Me.StatusStrip2.TabIndex = 2
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(185, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.yearcb)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 112)
        Me.Panel2.TabIndex = 0
        '
        'yearcb
        '
        Me.yearcb.FormattingEnabled = True
        Me.yearcb.Location = New System.Drawing.Point(64, 44)
        Me.yearcb.Name = "yearcb"
        Me.yearcb.Size = New System.Drawing.Size(114, 23)
        Me.yearcb.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(64, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(114, 21)
        Me.TextBox1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Year:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SO No:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.supptxt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.datemb)
        Me.GroupBox1.Controls.Add(Me.sonotxt)
        Me.GroupBox1.Controls.Add(Me.RemarksTextBox)
        Me.GroupBox1.Controls.Add(Label6)
        Me.GroupBox1.Controls.Add(Me.PurposeTextBox)
        Me.GroupBox1.Controls.Add(Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(789, 200)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PO Details"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Firebrick
        Me.Label20.Location = New System.Drawing.Point(435, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 15)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Supplier Code"
        '
        'supptxt
        '
        Me.supptxt.BackColor = System.Drawing.SystemColors.Info
        Me.supptxt.ForeColor = System.Drawing.Color.Firebrick
        Me.supptxt.Location = New System.Drawing.Point(89, 54)
        Me.supptxt.Name = "supptxt"
        Me.supptxt.ReadOnly = True
        Me.supptxt.Size = New System.Drawing.Size(340, 21)
        Me.supptxt.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Supplier:"
        '
        'datemb
        '
        Me.datemb.BackColor = System.Drawing.SystemColors.Info
        Me.datemb.Location = New System.Drawing.Point(280, 27)
        Me.datemb.Mask = "00/00/0000"
        Me.datemb.Name = "datemb"
        Me.datemb.ReadOnly = True
        Me.datemb.Size = New System.Drawing.Size(149, 21)
        Me.datemb.TabIndex = 24
        Me.datemb.ValidatingType = GetType(Date)
        '
        'sonotxt
        '
        Me.sonotxt.BackColor = System.Drawing.SystemColors.Info
        Me.sonotxt.ForeColor = System.Drawing.Color.Firebrick
        Me.sonotxt.Location = New System.Drawing.Point(89, 27)
        Me.sonotxt.Name = "sonotxt"
        Me.sonotxt.ReadOnly = True
        Me.sonotxt.Size = New System.Drawing.Size(130, 21)
        Me.sonotxt.TabIndex = 23
        Me.sonotxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RemarksTextBox
        '
        Me.RemarksTextBox.BackColor = System.Drawing.Color.Azure
        Me.RemarksTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemarksTextBox.Location = New System.Drawing.Point(392, 100)
        Me.RemarksTextBox.Multiline = True
        Me.RemarksTextBox.Name = "RemarksTextBox"
        Me.RemarksTextBox.ReadOnly = True
        Me.RemarksTextBox.Size = New System.Drawing.Size(349, 72)
        Me.RemarksTextBox.TabIndex = 22
        '
        'PurposeTextBox
        '
        Me.PurposeTextBox.BackColor = System.Drawing.Color.Azure
        Me.PurposeTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurposeTextBox.Location = New System.Drawing.Point(28, 100)
        Me.PurposeTextBox.Multiline = True
        Me.PurposeTextBox.Name = "PurposeTextBox"
        Me.PurposeTextBox.ReadOnly = True
        Me.PurposeTextBox.Size = New System.Drawing.Size(349, 72)
        Me.PurposeTextBox.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Firebrick
        Me.Label5.Location = New System.Drawing.Point(649, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 27)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SO No:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.itemdesc)
        Me.GroupBox2.Controls.Add(Label21)
        Me.GroupBox2.Controls.Add(Me.amt)
        Me.GroupBox2.Controls.Add(Me.taxamt)
        Me.GroupBox2.Controls.Add(Me.discamt)
        Me.GroupBox2.Controls.Add(Label18)
        Me.GroupBox2.Controls.Add(Label17)
        Me.GroupBox2.Controls.Add(Label16)
        Me.GroupBox2.Controls.Add(Me.unitprice)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.currency)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.qtt)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.uom)
        Me.GroupBox2.Controls.Add(Label13)
        Me.GroupBox2.Controls.Add(Me.itemdate)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.invref)
        Me.GroupBox2.Controls.Add(Label10)
        Me.GroupBox2.Controls.Add(Me.machdesc)
        Me.GroupBox2.Controls.Add(Label9)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 372)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(789, 238)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Details"
        '
        'itemdesc
        '
        Me.itemdesc.BackColor = System.Drawing.Color.Azure
        Me.itemdesc.Location = New System.Drawing.Point(119, 22)
        Me.itemdesc.Multiline = True
        Me.itemdesc.Name = "itemdesc"
        Me.itemdesc.ReadOnly = True
        Me.itemdesc.Size = New System.Drawing.Size(611, 64)
        Me.itemdesc.TabIndex = 44
        '
        'amt
        '
        Me.amt.BackColor = System.Drawing.SystemColors.Info
        Me.amt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.amt.ForeColor = System.Drawing.Color.Firebrick
        Me.amt.Location = New System.Drawing.Point(440, 193)
        Me.amt.Name = "amt"
        Me.amt.ReadOnly = True
        Me.amt.Size = New System.Drawing.Size(290, 29)
        Me.amt.TabIndex = 42
        Me.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'taxamt
        '
        Me.taxamt.BackColor = System.Drawing.SystemColors.Info
        Me.taxamt.Location = New System.Drawing.Point(631, 166)
        Me.taxamt.Name = "taxamt"
        Me.taxamt.ReadOnly = True
        Me.taxamt.Size = New System.Drawing.Size(99, 21)
        Me.taxamt.TabIndex = 41
        Me.taxamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'discamt
        '
        Me.discamt.BackColor = System.Drawing.SystemColors.Info
        Me.discamt.Location = New System.Drawing.Point(440, 166)
        Me.discamt.Name = "discamt"
        Me.discamt.ReadOnly = True
        Me.discamt.Size = New System.Drawing.Size(99, 21)
        Me.discamt.TabIndex = 40
        Me.discamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'unitprice
        '
        Me.unitprice.BackColor = System.Drawing.SystemColors.Info
        Me.unitprice.Location = New System.Drawing.Point(119, 193)
        Me.unitprice.Name = "unitprice"
        Me.unitprice.ReadOnly = True
        Me.unitprice.Size = New System.Drawing.Size(240, 21)
        Me.unitprice.TabIndex = 36
        Me.unitprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(25, 196)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 15)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Unit Price:"
        '
        'currency
        '
        Me.currency.BackColor = System.Drawing.Color.Azure
        Me.currency.Location = New System.Drawing.Point(608, 139)
        Me.currency.Name = "currency"
        Me.currency.ReadOnly = True
        Me.currency.Size = New System.Drawing.Size(122, 21)
        Me.currency.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(543, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 15)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Currency:"
        '
        'qtt
        '
        Me.qtt.BackColor = System.Drawing.SystemColors.Info
        Me.qtt.Location = New System.Drawing.Point(269, 166)
        Me.qtt.Name = "qtt"
        Me.qtt.ReadOnly = True
        Me.qtt.Size = New System.Drawing.Size(90, 21)
        Me.qtt.TabIndex = 32
        Me.qtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(238, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 15)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Qtt:"
        '
        'uom
        '
        Me.uom.BackColor = System.Drawing.Color.Azure
        Me.uom.Location = New System.Drawing.Point(119, 166)
        Me.uom.Name = "uom"
        Me.uom.ReadOnly = True
        Me.uom.Size = New System.Drawing.Size(100, 21)
        Me.uom.TabIndex = 30
        '
        'itemdate
        '
        Me.itemdate.BackColor = System.Drawing.Color.Azure
        Me.itemdate.Location = New System.Drawing.Point(365, 139)
        Me.itemdate.Mask = "00/00/0000"
        Me.itemdate.Name = "itemdate"
        Me.itemdate.ReadOnly = True
        Me.itemdate.Size = New System.Drawing.Size(149, 21)
        Me.itemdate.TabIndex = 28
        Me.itemdate.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(323, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 15)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Date:"
        '
        'invref
        '
        Me.invref.BackColor = System.Drawing.Color.Azure
        Me.invref.Location = New System.Drawing.Point(119, 139)
        Me.invref.Name = "invref"
        Me.invref.ReadOnly = True
        Me.invref.Size = New System.Drawing.Size(182, 21)
        Me.invref.TabIndex = 26
        '
        'machdesc
        '
        Me.machdesc.BackColor = System.Drawing.Color.Azure
        Me.machdesc.Location = New System.Drawing.Point(119, 92)
        Me.machdesc.Multiline = True
        Me.machdesc.Name = "machdesc"
        Me.machdesc.ReadOnly = True
        Me.machdesc.Size = New System.Drawing.Size(611, 41)
        Me.machdesc.TabIndex = 24
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.stocktxt)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 326)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(789, 46)
        Me.Panel3.TabIndex = 4
        '
        'stocktxt
        '
        Me.stocktxt.BackColor = System.Drawing.Color.Snow
        Me.stocktxt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stocktxt.ForeColor = System.Drawing.Color.Firebrick
        Me.stocktxt.Location = New System.Drawing.Point(87, 3)
        Me.stocktxt.Name = "stocktxt"
        Me.stocktxt.ReadOnly = True
        Me.stocktxt.Size = New System.Drawing.Size(100, 26)
        Me.stocktxt.TabIndex = 31
        Me.stocktxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(14, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 15)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Total Stock:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.TextBox12)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(527, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(262, 46)
        Me.Panel4.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(43, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 15)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Total Amount:"
        '
        'TextBox12
        '
        Me.TextBox12.BackColor = System.Drawing.Color.Ivory
        Me.TextBox12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.ForeColor = System.Drawing.Color.Firebrick
        Me.TextBox12.Location = New System.Drawing.Point(129, 3)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(130, 25)
        Me.TextBox12.TabIndex = 28
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column5, Me.Column6, Me.Column2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 200)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(789, 126)
        Me.DataGridView1.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Stock No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 81
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Section"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Description"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column6.HeaderText = "Machine No"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 97
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "Amount"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 74
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 83)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 15)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Year:"
        '
        'EnqForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(989, 632)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "EnqForm"
        Me.Text = "Enquiries Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents yearcb As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RemarksTextBox As TextBox
    Friend WithEvents PurposeTextBox As TextBox
    Friend WithEvents datemb As MaskedTextBox
    Friend WithEvents sonotxt As TextBox
    Friend WithEvents supptxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents machdesc As TextBox
    Friend WithEvents itemdate As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents invref As TextBox
    Friend WithEvents currency As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents qtt As MaskedTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents uom As TextBox
    Friend WithEvents unitprice As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents amt As TextBox
    Friend WithEvents taxamt As TextBox
    Friend WithEvents discamt As TextBox
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents itemdesc As TextBox
    Friend WithEvents stocktxt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
End Class
