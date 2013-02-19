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
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNewVer = New System.Windows.Forms.Label
        Me.lbldate = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.BoxRemark = New System.Windows.Forms.TextBox
        Me.Pbar = New System.Windows.Forms.ProgressBar
        Me.lblUpMsg = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblNewVer)
        Me.GroupBox1.Controls.Add(Me.lbldate)
        Me.GroupBox1.Controls.Add(Me.lblMsg)
        Me.GroupBox1.Controls.Add(Me.BoxRemark)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "服务端即时信息"
        '
        'lblNewVer
        '
        Me.lblNewVer.AutoSize = True
        Me.lblNewVer.ForeColor = System.Drawing.Color.Blue
        Me.lblNewVer.Location = New System.Drawing.Point(301, 107)
        Me.lblNewVer.Name = "lblNewVer"
        Me.lblNewVer.Size = New System.Drawing.Size(59, 12)
        Me.lblNewVer.TabIndex = 4
        Me.lblNewVer.Text = "最新版本:"
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.ForeColor = System.Drawing.Color.Blue
        Me.lbldate.Location = New System.Drawing.Point(151, 109)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(59, 12)
        Me.lbldate.TabIndex = 3
        Me.lbldate.Text = "更新日期:"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblMsg.Location = New System.Drawing.Point(19, 109)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(59, 12)
        Me.lblMsg.TabIndex = 2
        Me.lblMsg.Text = "当前版本:"
        '
        'BoxRemark
        '
        Me.BoxRemark.Location = New System.Drawing.Point(3, 13)
        Me.BoxRemark.Multiline = True
        Me.BoxRemark.Name = "BoxRemark"
        Me.BoxRemark.Size = New System.Drawing.Size(448, 83)
        Me.BoxRemark.TabIndex = 0
        '
        'Pbar
        '
        Me.Pbar.Location = New System.Drawing.Point(3, 30)
        Me.Pbar.Name = "Pbar"
        Me.Pbar.Size = New System.Drawing.Size(448, 23)
        Me.Pbar.TabIndex = 1
        '
        'lblUpMsg
        '
        Me.lblUpMsg.AutoSize = True
        Me.lblUpMsg.ForeColor = System.Drawing.Color.Red
        Me.lblUpMsg.Location = New System.Drawing.Point(5, 9)
        Me.lblUpMsg.Name = "lblUpMsg"
        Me.lblUpMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblUpMsg.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 194)
        Me.Controls.Add(Me.lblUpMsg)
        Me.Controls.Add(Me.Pbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "发现更新版本"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BoxRemark As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents lblNewVer As System.Windows.Forms.Label
    Friend WithEvents Pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblUpMsg As System.Windows.Forms.Label

End Class
