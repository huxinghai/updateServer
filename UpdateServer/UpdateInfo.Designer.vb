<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateInfo
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.BoxIp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BoxUserName = New System.Windows.Forms.TextBox
        Me.BoxPwd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ip:"
        '
        'BoxIp
        '
        Me.BoxIp.Location = New System.Drawing.Point(74, 20)
        Me.BoxIp.Name = "BoxIp"
        Me.BoxIp.Size = New System.Drawing.Size(251, 21)
        Me.BoxIp.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "用户名:"
        '
        'BoxUserName
        '
        Me.BoxUserName.Location = New System.Drawing.Point(74, 50)
        Me.BoxUserName.Name = "BoxUserName"
        Me.BoxUserName.Size = New System.Drawing.Size(100, 21)
        Me.BoxUserName.TabIndex = 3
        '
        'BoxPwd
        '
        Me.BoxPwd.Location = New System.Drawing.Point(74, 80)
        Me.BoxPwd.Name = "BoxPwd"
        Me.BoxPwd.Size = New System.Drawing.Size(100, 21)
        Me.BoxPwd.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "密码:"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(235, 55)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(63, 34)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "保存"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'UpdateInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 133)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BoxPwd)
        Me.Controls.Add(Me.BoxUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BoxIp)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UpdateInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ftp 服务端设置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BoxIp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BoxUserName As System.Windows.Forms.TextBox
    Friend WithEvents BoxPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
End Class
