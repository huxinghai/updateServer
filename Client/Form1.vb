Imports System.Xml
Imports UpdateBLL
Public Class Form1
    Private dt As New DataTable
    Private id As Int32   '���µ�����
    Private syname As String = "" '���º�������������
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
            Insert_Standard_ErrorLog("���¿ͻ���", "�����������ļ���������")
            StartExe()
            Exit Sub
        End If

        xl.Load(My.Application.Info.DirectoryPath & "\ver.xml")
        xn = xl.SelectNodes("mem")
        syname = xn.Item(0).ChildNodes(3).InnerText.Trim() '���������������
        sname = xn.Item(0).ChildNodes(1).InnerText.Trim()  '��������
        cdates = xn.Item(0).ChildNodes(2).InnerText.Trim() '�ϴθ���ʱ��
        strver = xn.Item(0).ChildNodes(0).InnerText.Trim() '�ϴθ��µİ汾        


        If Not IsConnection() Then
            Insert_Standard_ErrorLog("���¿ͻ���", "���Ӳ���ftp��������������")
            StartExe()
            Exit Sub
        End If

        Try
            Me.Text = sname & Me.Text '��������
            Me.lblMsg.Text = Me.lblMsg.Text & strver '�汾��Ϣ
            Me.lbldate.Text = Me.lbldate.Text & cdates '��������
            ''��ѯ������Ϣ
            dt = SqlServer.query(xn.Item(0).ChildNodes(1).InnerText.Trim)
            If dt.Rows.Count <= 0 Then
                Insert_Standard_ErrorLog("���¿ͻ���", "û�и����ļ���������")
                If Not StartExe() Then
                    Exit Sub
                End If
            Else
                '�жϰ汾�Ƿ���ͬ������ͬ�͸���
                If Trim(dt.Rows(0)("Version")) = Trim(strver) Then
                    Insert_Standard_ErrorLog("���¿ͻ���", "�汾��ͬ����Ҫ��������")
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
                    Me.lblUpMsg.Text = "û�и��µ��ļ���"
                Else
                    Dim IsPar As Boolean = True
                    '��¼�ͻ��˵���Ϣ
                    id = IsNothingOrNull(SqlServer.InsertClientInfo(Net.Dns.GetHostAddresses(My.Computer.Name)(0).ToString(), sname, tempver), "")
                    'ɾ���ͻ��˵�ip��Ϣ����ϸ
                    SqlServer.DeleteClientDetailsList(id)
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        My.Application.DoEvents()
                        Me.lblUpMsg.Text = dt.Rows(i)("paths")

                        state = IIf(Download(My.Application.Info.DirectoryPath & "\" & ToStringPath(Replace(dt.Rows(i)("paths"), "/", "\")), dt.Rows(i)("paths"), Me.Pbar), "�ɹ�", "ʧ��")

                        If id <> "" Then
                            Try
                                '���¼�¼�ͻ��˵�ip��Ϣ����ϸ
                                SqlServer.InsertPathInfo(id, dt.Rows(i)("paths"), state)
                            Catch ex As Exception
                                Insert_Standard_ErrorLog("��¼�ͻ�����Ϣ", ex.Message)
                            End Try
                        End If
                        If state = "ʧ��" Then
                            IsPar = False
                        End If
                    Next

                    If IsPar Then
                        xn.Item(0).ChildNodes(0).InnerText = tempver  '�汾��Ϣ
                        xn.Item(0).ChildNodes(2).InnerText = Format(Date.Now, "yyyy-MM-dd") '��������
                        xl.Save(My.Application.Info.DirectoryPath & "\ver.xml")
                        Me.lblUpMsg.Text = "���³ɹ���"
                    End If
                End If
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("ϵͳ����ʧ�ܣ�" & ex.Message)
        Finally
            StartExe()
        End Try
    End Sub
    ''' <summary>
    ''' ��ѯ�������Ƿ�������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsProcess() As Boolean
        Dim p() As Process
        p = Process.GetProcessesByName(Replace(syname, ".exe", ""))

        If p.Length > 0 Then
            If MessageBox.Show("�������Ѿ�������,���Ƚ�ϵͳ�رպ���£�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
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
    ''' ����������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StartExe() As Boolean
        Try
            If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\" & syname) Then
                MessageBox.Show("Ӧ��ϵͳû�д���" & vbCrLf & "·��:" & My.Application.Info.DirectoryPath & "\" & syname & vbCrLf & "�������Ա��ϵ��", "��ʾ")
                End
                Return False
            End If
            Me.Hide()
            Process.Start(My.Application.Info.DirectoryPath & "\" & syname)
            End
        Catch ex As Exception
            MessageBox.Show("ϵͳ����,�������Ա��ϵ��", "��ʾ")
            Return False
        End Try
    End Function
    ''' <summary>
    ''' ת��·��,ȥ��ǰ���һ���ļ�������
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
    ''' �ж����û�д����ļ���,�򴴽�
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
