Imports System.Net
Imports UpdateBLL
Imports System.XML
Public Class Form1
    Private dt As New DataTable
    Private wc As New WebClient
    'Private rs As FtpWebRequest
    'Private rq As FtpWebResponse

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\US.xml") Then
            Dim xl As New XmlDocument
            Dim xn As XmlNodeList
            xl.Load(My.Application.Info.DirectoryPath & "\US.xml")
            xn = xl.SelectNodes("mem")
            ftp.Address = "ftp://" & xn.Item(0).ChildNodes(0).InnerText.Trim() & "/"
            ftp.Ip = xn.Item(0).ChildNodes(0).InnerText.Trim()
            ftp.UserName = xn.Item(0).ChildNodes(1).InnerText.Trim()
            ftp.PassWord = xn.Item(0).ChildNodes(2).InnerText.Trim()
        End If
        wc.Credentials = New Net.NetworkCredential(ftp.UserName, ftp.PassWord)
        DataBindInfo()
    End Sub

    Private Sub DataBindInfo()
        dt = SqlServer.query("")
        Me.CboxSystem.AutoCompleteCustomSource.Clear()
        Me.CboxSystem.Items.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            Me.CboxSystem.Items.Add(dt.Rows(i)("SystemName"))
            Me.CboxSystem.AutoCompleteCustomSource.Add(dt.Rows(i)("SystemName"))
        Next
    End Sub

    Private Sub CboxSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxSystem.SelectedIndexChanged
        If Me.CboxSystem.Text.Trim = "" Then
            Exit Sub
        End If

        dt = SqlServer.query(Me.CboxSystem.Text.Trim)
        If dt.Rows.Count <= 0 Then
            MessageBox.Show("程序名称:" & Me.CboxSystem.Text.Trim & "不存在,请核对...")
            Exit Sub
        End If
        Me.BoxVer.Text = dt.Rows(0)("Version")
        Me.Boxfilename.Text = dt.Rows(0)("fileName")
        Me.BoxRemark.Text = IsNothingOrNull(dt.Rows(0)("Remark"), "")

        If Not DirectoryExist("", dt.Rows(0)("fileName")) Then
            MessageBox.Show("服务器不存在:" & dt.Rows(0)("fileName") & "文件夹或者ftp无法链接!请与管理员联系！", "提示")
            Me.btnadd.Enabled = False
            Me.BtnInsert.Enabled = False
            Me.BtnUlf.Enabled = False
            Me.DgvInfo.Rows.Clear()
            Exit Sub
        End If

        Me.btnadd.Enabled = True
        Me.BtnInsert.Enabled = True
        Me.BtnUlf.Enabled = True

        If IsNothingOrNull(dt.Rows(0)("State"), "") = "N" Then
            Me.RbN.Checked = True
        Else
            Me.RbY.Checked = True
        End If
        Me.BoxVer.Enabled = False
        Me.Boxfilename.Enabled = False

        dt = SqlServer.querydetails(dt.Rows(0)("Id"))

        AddDgv(dt)
    End Sub
    Private Sub AddDgv(ByVal dt As DataTable)
        Me.DgvInfo.Rows.Clear()
        For i As Int32 = 0 To dt.Rows.Count - 1
            Me.DgvInfo.Rows.Add(dt.Rows(i)("Id"), dt.Rows(i)("ServerName"), dt.Rows(i)("paths"))
        Next
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.CboxSystem.Text.Trim = "" OrElse Me.BoxVer.Text.Trim = "" OrElse Me.Boxfilename.Text.Trim = "" Then
            MessageBox.Show("请把资料填写完整!", "提示 ")
            Exit Sub
        End If
        Try
            Dim st As String = "Y"
            Dim model As New UpdateBLL.UpdateServer()
            Dim Str() As String = Nothing

            If Me.RbN.Checked = True Then
                st = "N"
            End If

            Str = Me.BoxVer.Text.Trim.Split(".")
            If Str.Length <> 3 Then
                MessageBox.Show("版本号错误,请与管理员联系！")
                Exit Sub
            End If
            Me.BoxVer.Text = Ver(Convert.ToInt32(Str(0)), Convert.ToInt32(Str(1)), Convert.ToInt32(Str(2)))
            model.SystemName = Me.CboxSystem.Text.Trim
            model.Version = Me.BoxVer.Text.Trim
            model.Remark = Me.BoxRemark.Text.Trim
            model.fileName = Me.Boxfilename.Text.Trim
            model.State = st

            If Me.Boxfilename.Enabled = True Then
                If SqlServer.IsGetYn(model.SystemName) Then
                    MessageBox.Show("程序名称已经存在！不可以重复添加", "提示")
                    Exit Sub
                End If
                SqlServer.Add(model)
                ''判断文件是否存在，如果不存在则创建一个
                If Not DirectoryExist("", Me.Boxfilename.Text.Trim) Then
                    CreateDirectory(Me.Boxfilename.Text.Trim, "")
                End If
            Else
                SqlServer.UpdateServerFile(model)
            End If
            MessageBox.Show("保存成功!")
            Me.Boxfilename.Enabled = False
            Me.BoxVer.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsert.Click
        Me.Boxfilename.Text = ""
        Me.BoxVer.Text = "1.0.0"
        Me.Boxfilename.Enabled = True
        Me.DgvInfo.Rows.Clear()
    End Sub

    Private Sub BtnUlf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUlf.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strfile() As String = Me.OpenFileDialog1.FileNames
            Dim path As String = ""
            Dim strName As String = ""
            Dim str() As String = Nothing
            Dim st As String = "Y"
            Dim model As New UpdateBLL.UpdateServer()
            Try
                If Not DirectoryExist("", Me.Boxfilename.Text.Trim) Then
                    MessageBox.Show("服务器上不存在" & Me.Boxfilename.Text & "文件夹,请手动创建!", "提示")
                    Exit Sub
                End If
                For i As Int32 = 0 To strfile.Length - 1
                    str = strfile(i).Trim.Replace("Debug", "*").Split("*")
                    path = Replace(str(UBound(str)), "\", "/")
                    strName = ftp.Address & Boxfilename.Text.Trim & path '将指定上传路径
                    IsfileCreate(path, Boxfilename.Text.Trim) '判断是否有目录
                    My.Computer.Network.UploadFile(strfile(i), strName, ftp.UserName, ftp.PassWord)
                Next

                'str = Me.BoxVer.Text.Trim.Split(".")
                'If str.Length <> 3 Then
                '    MessageBox.Show("版本号错误,请与管理员联系！")
                '    Exit Sub
                'End If

                'Me.BoxVer.Text = Ver(Convert.ToInt32(str(0)), Convert.ToInt32(str(1)), Convert.ToInt32(str(2)))

                'If RbN.Checked = True Then
                '    st = "N"
                'End If
                'model.Id = Me.CboxSystem.SelectedItem("Id")
                'model.SystemName = Me.CboxSystem.SelectedItem("SystemName")
                'model.fileName = Me.Boxfilename.Text.Trim
                'model.Remark = Me.BoxRemark.Text.Trim
                'model.State = st
                'model.Version = Me.BoxVer.Text.Trim

                'SqlServer.UpdateServerFile(model)
            Catch ex As Exception
                MessageBox.Show("上传失败！" & ex.Message)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' 判断服务器是否存在目录，如果没有则创建
    ''' </summary>          
    ''' <param name="path">上传路径</param>
    ''' <param name="file" >ftp路径</param>
    ''' <remarks></remarks>
    Private Sub IsfileCreate(ByVal path As String, ByVal file As String)
        Dim ss() As String = path.Split("/")
        Dim temp As String = file & "/"

        For i As Int32 = 0 To ss.Length - 2
            If IsNothingOrNull(ss(i), "") <> "" Then
                If Not IsDirectory(ss(i), file) Then
                    CreateDirectory(ss(i), temp)
                    temp &= Trim(ss(i) & "/")
                End If
            End If
        Next
    End Sub

    Function Ver(ByVal A As Int16, ByVal B As Int16, ByVal C As Int16) As String
        C += 1

        If C > 999 Then
            B += 1
            C = 0

        End If
        If B > 999 Then
            A += 1
            B = 0
        End If
        Return A & "." & B & "." & C
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        If Me.CboxSystem.Text.Trim = "" Then Exit Sub
        Dim sh As New ClientDetails(Me.CboxSystem.Text.Trim)
        sh.ShowDialog()
    End Sub

    Private Sub 选择更新文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 选择更新文件ToolStripMenuItem.Click
        If Me.Boxfilename.Text.Trim = "" Then
            Exit Sub
        End If
        dt = SqlServer.query(Me.CboxSystem.Text.Trim)
        If dt.Rows.Count <= 0 Then
            MessageBox.Show(Me.CboxSystem.Text.Trim & "程序不存在,请核对...", "提示")
            Exit Sub
        End If
        Dim f As New fileDetails(Me.Boxfilename.Text.Trim(), dt.Rows(0)("Id"))
        f.ShowDialog()
    End Sub

    Private Sub 清除更新文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除更新文件ToolStripMenuItem.Click
        If Me.DgvInfo.SelectedRows.Count > 0 Then
            Try
                With Me.DgvInfo.SelectedRows(0)
                    dt = SqlServer.query(" and SystemName='" & Me.CboxSystem.Text.Trim & "'")
                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show(Me.CboxSystem.Text.Trim & "程序不存在,请核对...", "提示")
                        Exit Sub
                    End If
                    SqlServer.DeleteUpdateServerDetails(.Cells("Id").Value, dt.Rows(0)("Id"), "")
                    Me.DgvInfo.Rows.Remove(Me.DgvInfo.SelectedRows(0))
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TsbModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CboxSystem.Text.Trim <> "" AndAlso Me.BoxVer.Text.Trim <> "" AndAlso Me.Boxfilename.Text.Trim <> "" Then
            Me.Boxfilename.Enabled = True
        End If
    End Sub
    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub 显示窗体ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 显示窗体ToolStripMenuItem.Click
        Me.ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub 退出系统ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出系统ToolStripMenuItem.Click
        End
    End Sub

    Private Sub TsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbDelete.Click
        If Me.CboxSystem.Text.Trim = "" Then Exit Sub
        Try
            If MessageBox.Show("是否确定要删除" & Me.CboxSystem.Text & "的资料?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                dt = SqlServer.query(Me.CboxSystem.Text.Trim)
                If dt.Rows.Count <= 0 Then
                    MessageBox.Show(Me.CboxSystem.Text.Trim & "程序不存在,请核对...", "提示")
                    Exit Sub
                End If

                SqlServer.DeleteServerInfo(dt.Rows(0)("SystemName"))
                If DirectoryExist("", Me.Boxfilename.Text.Trim) Then
                    DirectoryDelete(Me.Boxfilename.Text.Trim, "文件夹")
                End If
                DataBindInfo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fr As New UpdateInfo
        fr.ShowDialog()
    End Sub

    Private Sub CboxSystem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboxSystem.KeyDown
        If e.KeyCode = Keys.F5 Then
            DataBindInfo()
        End If
    End Sub
End Class
