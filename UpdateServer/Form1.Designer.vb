<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DgvInfo = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.更新文件 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.路径 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.选择更新文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.清除更新文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.CboxSystem = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BoxVer = New System.Windows.Forms.TextBox
        Me.BtnUlf = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TsbDelete = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Boxfilename = New System.Windows.Forms.TextBox
        Me.btnadd = New System.Windows.Forms.Button
        Me.BtnInsert = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RbN = New System.Windows.Forms.RadioButton
        Me.RbY = New System.Windows.Forms.RadioButton
        Me.BoxInfo = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BoxRemark = New System.Windows.Forms.TextBox
        Me.BtnDetails = New System.Windows.Forms.Button
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.显示窗体ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.退出系统ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.DgvInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvInfo
        '
        Me.DgvInfo.AllowUserToAddRows = False
        Me.DgvInfo.AllowUserToDeleteRows = False
        Me.DgvInfo.AllowUserToResizeColumns = False
        Me.DgvInfo.AllowUserToResizeRows = False
        Me.DgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.更新文件, Me.路径})
        Me.DgvInfo.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvInfo.Location = New System.Drawing.Point(0, 29)
        Me.DgvInfo.Name = "DgvInfo"
        Me.DgvInfo.ReadOnly = True
        Me.DgvInfo.RowTemplate.Height = 23
        Me.DgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvInfo.Size = New System.Drawing.Size(435, 189)
        Me.DgvInfo.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 23
        '
        '更新文件
        '
        Me.更新文件.HeaderText = "更新文件"
        Me.更新文件.Name = "更新文件"
        Me.更新文件.ReadOnly = True
        Me.更新文件.Width = 78
        '
        '路径
        '
        Me.路径.HeaderText = "路径"
        Me.路径.Name = "路径"
        Me.路径.ReadOnly = True
        Me.路径.Width = 54
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.选择更新文件ToolStripMenuItem, Me.清除更新文件ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 48)
        '
        '选择更新文件ToolStripMenuItem
        '
        Me.选择更新文件ToolStripMenuItem.Name = "选择更新文件ToolStripMenuItem"
        Me.选择更新文件ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.选择更新文件ToolStripMenuItem.Text = "选择更新文件"
        '
        '清除更新文件ToolStripMenuItem
        '
        Me.清除更新文件ToolStripMenuItem.Name = "清除更新文件ToolStripMenuItem"
        Me.清除更新文件ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.清除更新文件ToolStripMenuItem.Text = "清除更新文件"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(461, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "程序名称:"
        '
        'CboxSystem
        '
        Me.CboxSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboxSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CboxSystem.FormattingEnabled = True
        Me.CboxSystem.Location = New System.Drawing.Point(519, 37)
        Me.CboxSystem.Name = "CboxSystem"
        Me.CboxSystem.Size = New System.Drawing.Size(128, 20)
        Me.CboxSystem.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(473, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "版本号:"
        '
        'BoxVer
        '
        Me.BoxVer.BackColor = System.Drawing.SystemColors.Menu
        Me.BoxVer.Enabled = False
        Me.BoxVer.Location = New System.Drawing.Point(519, 61)
        Me.BoxVer.Name = "BoxVer"
        Me.BoxVer.Size = New System.Drawing.Size(129, 21)
        Me.BoxVer.TabIndex = 4
        '
        'BtnUlf
        '
        Me.BtnUlf.Location = New System.Drawing.Point(563, 158)
        Me.BtnUlf.Name = "BtnUlf"
        Me.BtnUlf.Size = New System.Drawing.Size(68, 23)
        Me.BtnUlf.TabIndex = 5
        Me.BtnUlf.Text = "上传"
        Me.BtnUlf.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.TsbDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(670, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripButton1.Text = "设置"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TsbDelete
        '
        Me.TsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TsbDelete.Image = CType(resources.GetObject("TsbDelete.Image"), System.Drawing.Image)
        Me.TsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbDelete.Name = "TsbDelete"
        Me.TsbDelete.Size = New System.Drawing.Size(33, 22)
        Me.TsbDelete.Text = "删除"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(473, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "路  径:"
        '
        'Boxfilename
        '
        Me.Boxfilename.BackColor = System.Drawing.SystemColors.Info
        Me.Boxfilename.Enabled = False
        Me.Boxfilename.Location = New System.Drawing.Point(519, 86)
        Me.Boxfilename.Name = "Boxfilename"
        Me.Boxfilename.Size = New System.Drawing.Size(129, 21)
        Me.Boxfilename.TabIndex = 8
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(563, 187)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(68, 23)
        Me.btnadd.TabIndex = 9
        Me.btnadd.Text = "保存"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'BtnInsert
        '
        Me.BtnInsert.Location = New System.Drawing.Point(485, 187)
        Me.BtnInsert.Name = "BtnInsert"
        Me.BtnInsert.Size = New System.Drawing.Size(60, 23)
        Me.BtnInsert.TabIndex = 10
        Me.BtnInsert.Text = "新增"
        Me.BtnInsert.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "请选择上传文件"
        Me.OpenFileDialog1.Filter = "所有文件|*.*"
        Me.OpenFileDialog1.Multiselect = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbN)
        Me.GroupBox1.Controls.Add(Me.RbY)
        Me.GroupBox1.Location = New System.Drawing.Point(464, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 33)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "状态"
        '
        'RbN
        '
        Me.RbN.AutoSize = True
        Me.RbN.Location = New System.Drawing.Point(109, 12)
        Me.RbN.Name = "RbN"
        Me.RbN.Size = New System.Drawing.Size(47, 16)
        Me.RbN.TabIndex = 1
        Me.RbN.TabStop = True
        Me.RbN.Text = "禁止"
        Me.RbN.UseVisualStyleBackColor = True
        '
        'RbY
        '
        Me.RbY.AutoSize = True
        Me.RbY.Location = New System.Drawing.Point(41, 12)
        Me.RbY.Name = "RbY"
        Me.RbY.Size = New System.Drawing.Size(47, 16)
        Me.RbY.TabIndex = 0
        Me.RbY.TabStop = True
        Me.RbY.Text = "更新"
        Me.RbY.UseVisualStyleBackColor = True
        '
        'BoxInfo
        '
        Me.BoxInfo.Location = New System.Drawing.Point(1, 224)
        Me.BoxInfo.Multiline = True
        Me.BoxInfo.Name = "BoxInfo"
        Me.BoxInfo.Size = New System.Drawing.Size(434, 212)
        Me.BoxInfo.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BoxRemark)
        Me.GroupBox2.Location = New System.Drawing.Point(438, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 212)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "客户端即时信息"
        '
        'BoxRemark
        '
        Me.BoxRemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BoxRemark.Location = New System.Drawing.Point(3, 17)
        Me.BoxRemark.Multiline = True
        Me.BoxRemark.Name = "BoxRemark"
        Me.BoxRemark.Size = New System.Drawing.Size(223, 192)
        Me.BoxRemark.TabIndex = 0
        '
        'BtnDetails
        '
        Me.BtnDetails.Location = New System.Drawing.Point(485, 158)
        Me.BtnDetails.Name = "BtnDetails"
        Me.BtnDetails.Size = New System.Drawing.Size(60, 23)
        Me.BtnDetails.TabIndex = 14
        Me.BtnDetails.Text = "查看"
        Me.BtnDetails.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.NotifyIcon1.BalloonTipText = "程序更新"
        Me.NotifyIcon1.BalloonTipTitle = "程序更新"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "程序更新系统服务端"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.显示窗体ToolStripMenuItem, Me.退出系统ToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(119, 48)
        '
        '显示窗体ToolStripMenuItem
        '
        Me.显示窗体ToolStripMenuItem.Name = "显示窗体ToolStripMenuItem"
        Me.显示窗体ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.显示窗体ToolStripMenuItem.Text = "显示窗体"
        '
        '退出系统ToolStripMenuItem
        '
        Me.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem"
        Me.退出系统ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.退出系统ToolStripMenuItem.Text = "退出系统"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 438)
        Me.Controls.Add(Me.BoxInfo)
        Me.Controls.Add(Me.BtnDetails)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnInsert)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Boxfilename)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BoxVer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnUlf)
        Me.Controls.Add(Me.CboxSystem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "更新服务端"
        CType(Me.DgvInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvInfo As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboxSystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BoxVer As System.Windows.Forms.TextBox
    Friend WithEvents BtnUlf As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Boxfilename As System.Windows.Forms.TextBox
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents BtnInsert As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbN As System.Windows.Forms.RadioButton
    Friend WithEvents RbY As System.Windows.Forms.RadioButton
    Friend WithEvents BoxInfo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BoxRemark As System.Windows.Forms.TextBox
    Friend WithEvents BtnDetails As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 更新文件 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 路径 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 选择更新文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清除更新文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 显示窗体ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出系统ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsbDelete As System.Windows.Forms.ToolStripButton

End Class
