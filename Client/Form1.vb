Imports System.Xml
Imports UpdateBLL
Public Class Form1
    Private dt As New DataTable
    Private id As Int32   '更新的主键
    Private syname As String = "" '更新后启动的主程序
    Private tempver As String = ""
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Dim xl As New XmlDocument
        Dim xn As XmlNodeList
        Dim sname As String = ""
        Dim strver As String = ""
        Dim cdates As String = ""
        Dim state As String = ""
        Dim id As String = ""

        dt = SqlServer.QueryUpdateInfo()

        If dt.Rows.Count > 0 Then
            ftp.Address = "ftp://" & dt.Rows(0)("FptIp") & "/"
            ftp.Ip = dt.Rows(0)("FptIp")
            ftp.UserName = dt.Rows(0)("UserName")
            ftp.PassWord = dt.Rows(0)("Password")
        End If

        If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\ver.xml") Then
            Insert_Standard_ErrorLog("更新客户端", "不存在配置文件启动更新")
            StartExe()
            Exit Sub
        End If

        xl.Load(My.Application.Info.DirectoryPath & "\ver.xml")
        xn = xl.SelectNodes("mem")
        syname = xn.Item(0).ChildNodes(3).InnerText.Trim() '启动主程序的名称
        sname = xn.Item(0).ChildNodes(1).InnerText.Trim()  '程序名称
        cdates = xn.Item(0).ChildNodes(2).InnerText.Trim() '上次更新时间
        strver = xn.Item(0).ChildNodes(0).InnerText.Trim() '上次更新的版本        


        If Not IsConnection() Then
            Insert_Standard_ErrorLog("更新客户端", "连接不到ftp服务器启动更新")
            StartExe()
            Exit Sub
        End If

        Try
            Me.Text = sname & Me.Text '程序名称
            Me.lblMsg.Text = Me.lblMsg.Text & strver '版本信息
            Me.lbldate.Text = Me.lbldate.Text & cdates '更新日期
            ''查询更新信息
            dt = SqlServer.query(xn.Item(0).ChildNodes(1).InnerText.Trim)
            If dt.Rows.Count <= 0 Then
                Insert_Standard_ErrorLog("更新客户端", "没有更新文件更新启动")
                If Not StartExe() Then
                    Exit Sub
                End If
            Else
                '判断版本是否相同，不相同就更新
                If Trim(dt.Rows(0)("Version")) = Trim(strver) Then
                    Insert_Standard_ErrorLog("更新客户端", "版本相同不需要更新启动")
                    If Not StartExe() Then
                        Exit Sub
                    End If
                End If
                Me.BoxRemark.Text = dt.Rows(0)("Remark")
                Me.lblNewVer.Text = Me.lblNewVer.Text & dt.Rows(0)("Version")
                tempver = dt.Rows(0)("Version")
                id = dt.Rows(0)("Id")

                If Not IsProcess() Then
                    Exit Sub
                End If
                Me.Show()
                dt = SqlServer.querydetails(id)
                If dt.Rows.Count <= 0 Then
                    Me.lblUpMsg.Text = "没有更新的文件！"
                Else
                    Dim IsPar As Boolean = True
                    '记录客户端的信息
                    id = IsNothingOrNull(SqlServer.InsertClientInfo(Net.Dns.GetHostAddresses(My.Computer.Name)(0).ToString(), sname, tempver), "")
                    '删除客户端的ip信息的明细
                    SqlServer.DeleteClientDetailsList(id)
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        My.Application.DoEvents()
                        Me.lblUpMsg.Text = dt.Rows(i)("paths")

                        state = IIf(Download(My.Application.Info.DirectoryPath & "\" & ToStringPath(Replace(dt.Rows(i)("paths"), "/", "\")), dt.Rows(i)("paths"), Me.Pbar), "成功", "失败")

                        If id <> "" Then
                            Try
                                '重新记录客户端的ip信息的明细
                                SqlServer.InsertPathInfo(id, dt.Rows(i)("paths"), state)
                            Catch ex As Exception
                                Insert_Standard_ErrorLog("记录客户端信息", ex.Message)
                            End Try
                        End If
                        If state = "失败" Then
                            IsPar = False
                        End If
                    Next

                    If IsPar Then
                        xn.Item(0).ChildNodes(0).InnerText = tempver  '版本信息
                        xn.Item(0).ChildNodes(2).InnerText = Format(Date.Now, "yyyy-MM-dd") '更新日期
                        xl.Save(My.Application.Info.DirectoryPath & "\ver.xml")
                        Me.lblUpMsg.Text = "更新成功！"
                    End If
                End If
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("系统更新失败！" & ex.Message)
        Finally
            StartExe()
        End Try
    End Sub
    ''' <summary>
    ''' 查询主程序是否在运行
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsProcess() As Boolean
        Dim p() As Process
        p = Process.GetProcessesByName(Replace(syname, ".exe", ""))

        If p.Length > 0 Then
            If MessageBox.Show("主程序已经在运行,请先将系统关闭后更新！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                For Each pr As Process In p
                    pr.Kill()
                Next

                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' 启动主程序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StartExe() As Boolean
        Try
            If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\" & syname) Then
                MessageBox.Show("应用系统没有存在" & vbCrLf & "路径:" & My.Application.Info.DirectoryPath & "\" & syname & vbCrLf & "请与管理员联系！", "提示")
                End
                Return False
            End If
            Me.Hide()
            Process.Start(My.Application.Info.DirectoryPath & "\" & syname)
            End
        Catch ex As Exception
            MessageBox.Show("系统出错,请与管理员联系！", "提示")
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 转换路径,去掉前面的一个文件夹名称
    ''' </summary>
    ''' <param name="ph"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ToStringPath(ByVal ph As String)
        Dim s() As String = ph.Split("\")
        Dim pat As String = ""
        For i As Int32 = 1 To s.Length - 1
            If IsNothingOrNull(s(i), "") <> "" Then
                pat &= IIf(pat = "", s(i), "\" & s(i))
            End If
        Next

        If pat = "" Then
            pat = ph
        End If

        CreateDirectory(pat)

        Return pat
    End Function
    ''' <summary>
    ''' 判断如果没有存在文件夹,则创建
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Private Sub CreateDirectory(ByVal filename As String)
        Dim ph As String = IO.Path.GetDirectoryName(Trim(My.Application.Info.DirectoryPath & "\" & filename))

        If Not IO.Directory.Exists(ph) Then
            IO.Directory.CreateDirectory(ph)
        End If
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim p() As Process
        p = Process.GetProcessesByName(Replace(syname, ".exe", ""))

        If p.Length <= 0 Then
            StartExe()
        End If
    End Sub
End Class
