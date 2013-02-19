Imports System.Net
Module Module1

    Public Ftprq As FtpWebRequest
    Public Ftprp As FtpWebResponse

    ''' <summary>
    ''' �ж��Ƿ�Ϊ�ջ���nullֵ
    ''' </summary>
    ''' <param name="obj">�ж϶���ֵ</param>
    ''' <param name="s">�滻ֵ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsNothingOrNull(ByVal obj As Object, ByVal s As String)
        If obj Is Nothing OrElse Convert.IsDBNull(obj) = True OrElse obj.ToString = "" Then
            Return s
        Else
            Return obj
        End If
    End Function
    ''' <summary>
    ''' ���ط���
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadUP()
        Ftprq = FtpWebRequest.Create(New Uri(UpdateBLL.ftp.Address))
        Ftprq.Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
        Ftprq.KeepAlive = False
        Ftprq.UseBinary = True
    End Sub
    ''' <summary>
    ''' �ж�Ŀ¼�Ƿ�����ļ�
    ''' </summary>
    ''' <param name="address">����Ŀ¼</param>
    ''' <param name="fname" >�ļ�����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DirectoryExist(ByVal address As String, ByVal fname As String) As Boolean
        Dim str As String
        Dim ss() As String
        str = GetFilesDetailList(address)

        If Not str Is Nothing Then
            ss = str.Split("$")

            For i As Int32 = 0 To ss.Length - 1
                If IsNothingOrNull(ss(i), "") <> "" AndAlso ss(i).Length >= 54 Then
                    If Trim(ss(i).Trim.Substring(54)) = fname Then
                        Return True
                    End If
                End If
            Next
        End If

        Return False
    End Function
    ''' <summary>
    ''' ��ȡĿ¼�µ���ϸ
    ''' </summary>
    ''' <param name="file">ftp·��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFilesDetailList(ByVal file As String) As String

        Try
            Ftprq = FtpWebRequest.Create(New Uri(UpdateBLL.ftp.Address & file))
            Dim strb As String = ""
            Dim sr As String = ""

            With Ftprq
                .Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
                .KeepAlive = False
                .UseBinary = True
                .Method = WebRequestMethods.Ftp.ListDirectoryDetails
                Ftprp = .GetResponse()
                Dim stam As New IO.StreamReader(Ftprp.GetResponseStream(), System.Text.UTF32Encoding.Default)
                strb = stam.ReadLine()
                strb = stam.ReadLine()

                While Not strb Is Nothing
                    If strb <> "" Then
                        sr &= IIf(sr = "", strb, "$" & strb)
                        strb = stam.ReadLine()
                    End If
                End While

            End With
            Ftprp.Close()
            Return sr
        Catch ex As Exception
            Insert_Standard_ErrorLog("��ȡĿ¼�µ���ϸ", ex.Message)
            Return Nothing
        End Try
    End Function
    '''' <summary>
    '''' �õ�һ�������µ������ļ�
    '''' </summary>
    '''' <param name="file"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function GetServerFilesDetailList(ByVal file As String) As String()
    '    Dim str As String = GetFilesDetailList(file)
    '    Dim s As String = ""

    '    Try
    '        Dim strs() As String = str.Split("^^^")
    '        For i As Int32 = 0 To strs.Length - 1
    '            If IsNothingOrNull(strs(i), "") <> "" Then
    '                s &= IIf(s = "", strs(i).Trim, "^^^" & strs(i).Trim)
    '                's &= IIf(s = "", strs(i).Trim.ToString.Substring(54), "^^^" & strs(i).Trim.ToString.Substring(54))
    '            End If
    '        Next

    '        Return s.Split("^^^")
    '    Catch ex As Exception
    '        Insert_Standard_ErrorLog("Module", ex.Message)
    '        Return Nothing
    '    End Try
    'End Function
    ''' <summary>
    ''' ��ȡĿ¼�µ���ϸ�����ļ��У�
    ''' </summary>
    ''' <param name="file">ftp·��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDirectoryList(ByVal file As String) As String()
        Try
            Dim str As String = ""
            Dim ss() As String
            str = GetFilesDetailList(file)
            ss = str.Split("$")

            str = ""
            For i As Int32 = 0 To ss.Length - 1
                If IsNothingOrNull(ss(i), "") <> "" Then
                    If ss(i).Trim.Substring(0, 1).ToUpper = "D" Then
                        str &= IIf(str = "", ss(i).Trim.Substring(54).Trim, ss(i).Trim.Substring(54).Trim & "$")
                    End If
                End If
            Next

            Return str.Split("$")
        Catch ex As Exception
            Insert_Standard_ErrorLog("��ȡĿ¼��ϸ", ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' ��ѯ�ļ����Ƿ����
    ''' </summary>
    ''' <param name="str" >�ȶ��ļ�������</param>
    ''' <param name="file">ftp·��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsDirectory(ByVal str As String, ByVal file As String) As Boolean
        Dim ss() As String = GetDirectoryList(file)

        For i As Int32 = 0 To ss.Length - 1
            If Trim(IsNothingOrNull(ss(i), "")) = str Then
                Return True
            End If
        Next

        Return False
    End Function
    ''' <summary>
    ''' �����ļ���
    ''' </summary>
    ''' <param name="sname" >�ļ�������</param>
    ''' <param name="file">ftp·��</param>
    ''' <remarks></remarks>
    Public Sub CreateDirectory(ByVal sname As String, ByVal file As String)
        Try
            Dim stra As IO.Stream
            Ftprq = FtpWebRequest.Create(New Uri(UpdateBLL.ftp.Address & file & sname))
            With Ftprq
                .KeepAlive = False
                .UseBinary = True
                .Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
                .Method = WebRequestMethods.Ftp.MakeDirectory
                Ftprp = .GetResponse
            End With
            stra = Ftprp.GetResponseStream
            stra.Close()
            Ftprp.Close()
        Catch ex As Exception
            Insert_Standard_ErrorLog("�����ļ���", ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' ������־
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <remarks></remarks>
    Public Sub Insert_Standard_ErrorLog(ByVal x As String, ByVal y As String)
        If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\error.text") Then
            IO.File.Create(My.Application.Info.DirectoryPath & "\error.text").Close()
        End If

        IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\error.text", "��������λ��:" & x & "___________������Ϣ:" & y & "__________" & Date.Now.ToString & vbCrLf)
    End Sub
    ''' <summary>
    ''' ɾ���ļ�
    ''' </summary>
    ''' <param name="path">·��</param>
    ''' <param name="type" >�ļ������ļ���</param>
    ''' <remarks></remarks>
    Public Sub DirectoryDelete(ByVal path As String, ByVal type As String)
        Try
            Ftprq = FtpWebRequest.Create(New Uri(Replace(UpdateBLL.ftp.Address & path, " ", "")))

            With Ftprq
                .Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
                .KeepAlive = True
                If type = "�ļ���" Then
                    .Method = WebRequestMethods.Ftp.RemoveDirectory
                Else
                    .Method = WebRequestMethods.Ftp.DeleteFile
                End If
                Ftprp = Ftprq.GetResponse()
            End With

            Ftprp.Close()
        Catch ex As Exception
            Insert_Standard_ErrorLog("ɾ���ļ�", ex.Message)
        End Try
    End Sub
End Module
