Imports System.Net
Imports System.IO
Imports System.Xml
Module Module1

    Public FtpRq As FtpWebRequest
    Public FtpRp As FtpWebResponse
    Dim wc As New WebClient()
    Dim xl As New XmlDocument
    Dim xn As XmlNodeList


    ''' <summary>
    ''' 判断是否为空或者null值
    ''' </summary>
    ''' <param name="obj">判断对象值</param>
    ''' <param name="s">替换值</param>
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
    ''' 判断ftp是否可以连接
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConnection() As Boolean
        Try
            FtpRq = FtpWebRequest.Create(New Uri(UpdateBLL.ftp.Address))
            FtpRq.Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
            FtpRq.UseBinary = True
            FtpRq.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            FtpRp = FtpRq.GetResponse()
            FtpRp.Close()
            GC.Collect()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 得到文件大小
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileSize(ByVal path As String) As Long
        Dim lo As Long = 0
        Try
            FtpRq = FtpWebRequest.Create(New Uri(path))
            FtpRq.Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
            FtpRq.UseBinary = True
            FtpRq.Method = WebRequestMethods.Ftp.GetFileSize
            FtpRp = FtpRq.GetResponse()
            lo = FtpRp.ContentLength

            FtpRp.Close()
            GC.Collect()
        Catch ex As Exception
            Insert_Standard_ErrorLog("得到文件大小", ex.Message)
        End Try

        Return lo
    End Function

    ''' <summary>
    ''' 下载
    ''' </summary>
    ''' <param name="filePath">下载程序的文件夹</param>
    ''' <param name="path">更新的路径</param>
    ''' <remarks></remarks>
    Public Function Download(ByVal filePath As String, ByVal path As String, ByVal pb As ProgressBar) As Boolean

        Dim flr As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read)
        Dim stra As Stream
        Dim rl As Long = 0
        Dim idx As Integer = 2048
        Dim incount As Integer = 0
        Dim by(idx) As Byte
        Dim i As Int32 = 0
        Dim temp As Long = GetFileSize(UpdateBLL.ftp.Address & path)

        Try
            FtpRq = FtpWebRequest.Create(New Uri(UpdateBLL.ftp.Address & path))
            FtpRq.Credentials = New NetworkCredential(UpdateBLL.ftp.UserName, UpdateBLL.ftp.PassWord)
            FtpRq.UseBinary = True
            FtpRq.KeepAlive = False
            FtpRq.Method = WebRequestMethods.Ftp.DownloadFile
            FtpRp = FtpRq.GetResponse
            rl = FtpRp.ContentLength       '得到长度
            stra = FtpRp.GetResponseStream '得到流
            incount = stra.Read(by, 0, idx)
            pb.Maximum = temp
            pb.Value = 0
            While incount > 0
                i += incount
                flr.Write(by, 0, incount)
                My.Application.DoEvents()
                pb.Value = i
                incount = stra.Read(by, 0, idx)
            End While
            stra.Close()
            FtpRp.Close()
            flr.Close()
        Catch ex As Exception
            flr.Close()
            Insert_Standard_ErrorLog("更新文件", ex.Message)
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 错误日志
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <remarks></remarks>
    Public Sub Insert_Standard_ErrorLog(ByVal x As String, ByVal y As String)
        If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\error.text") Then
            IO.File.Create(My.Application.Info.DirectoryPath & "\error.text").Close()
        End If

        IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\error.text", "错误发生的位置:" & x & "___________错误信息:" & y & "__________" & Date.Now.ToString & vbCrLf)
    End Sub

    '''' <summary>
    '''' 查询文件夹是否存在
    '''' </summary>
    '''' <param name="file">ftp路径</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function IsDirectory(ByVal file As String) As Boolean
    '    If IO.Directory.Exists(file) Then
    '        Return True
    '    End If
    '    Return False
    'End Function
End Module
