Public Class SqlServer

    Private Shared sql As String = ""
    ''' <summary>
    ''' ��ѯ������Ϣ
    ''' </summary>
    ''' <param name="sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function query(ByVal sn As String) As DataTable
        sql = "Exec UserManage..QueryClientInfo '" & sn & "'"

        Return DbHelper.Query(sql)
    End Function
    ''' <summary>
    ''' �жϳ��������Ƿ����
    ''' </summary>
    ''' <param name="Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsGetYn(ByVal Sn As String) As Boolean
        sql = "select *from UserManage..UpdateServer where SystemName='" & Sn & "'"

        Return DbHelper.IsExists(sql)
    End Function
    ''' <summary>
    ''' ��ѯ������ϸ
    ''' </summary>
    ''' <param name="uid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function querydetails(ByVal uid As String)
        sql = "select *from UserManage..UpdateServerDetails where UId='" & uid & "' order by id"

        Return DbHelper.Query(sql)
    End Function
    ''' <summary>
    ''' �ж��ļ��Ƿ����
    ''' </summary>
    ''' <param name="uid"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsDetails(ByVal uid As String, ByVal path As String) As Boolean
        sql = "select *from UserManage..UpdateServerDetails where UId='" & uid & "' and Paths='" & path & "'"

        Return DbHelper.IsExists(sql)
    End Function

    ''' <summary>
    ''' ɾ��������ϸ,������ѡ��
    ''' </summary>
    ''' <param name="id">����</param>
    ''' <param name="uid">�������</param>
    ''' <param name="path">·��</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteUpdateServerDetails(ByVal id As String, ByVal uid As String, ByVal path As String)
        sql = "Delete UserManage..UpdateServerDetails where 1=1 "

        If id <> "" Then
            sql &= " and Id=" & id
        End If

        If uid <> "" Then
            sql &= " and UId='" & uid & "'"
        End If

        If path <> "" Then
            sql &= " and Paths like '" & path & "'"
        End If

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ��Ӹ��³���
    ''' </summary>
    ''' <param name="model" ></param>
    ''' <remarks></remarks>
    Public Shared Sub Add(ByVal model As UpdateServer)
        sql = "Insert into UserManage..UpdateServer([SystemName], [fileName], [Version], [Remark],[State]) values('" & model.SystemName & "','" & model.fileName & "','" & model.Version & "','" & model.Remark & "','Y') "

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ��Ӹ��µ��ļ�
    ''' </summary>
    ''' <param name="Model" >��ϸ���� </param>
    ''' <remarks></remarks>
    Public Shared Function AddULf(ByVal Model As UpdateServerDetails)
        sql = "Insert into UserManage..UpdateServerDetails([UId],[ServerName],[Paths]) values(" & Model.UId & ",'" & Model.ServerName & "','" & Model.Paths & "')" & vbCrLf

        Return sql
    End Function
    ''' <summary>
    ''' �ϴ��ļ�
    ''' </summary>
    ''' <param name="model"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateServerFile(ByVal model As UpdateServer)
        sql = "Update UserManage..UpdateServer set [Version]='" & model.Version & "',Remark='" & model.Remark & "',State='" & model.State & "'" & vbCrLf _
        & " where SystemName='" & model.SystemName & "'"

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ִ������
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteTran(ByVal sql As String)
        Return DbHelper.ExecuteTran(sql)
    End Function
    ''' <summary>
    ''' ��¼�ͻ��˵���Ϣ
    ''' </summary>
    ''' <param name="Ip">ip��ַ</param>
    ''' <param name="sname">ϵͳ����</param>
    ''' <param name="Versoin">�汾��</param>
    ''' <remarks></remarks>
    Public Shared Function InsertClientInfo(ByVal Ip As String, ByVal sname As String, ByVal Versoin As String)
        sql = "Exec UserManage..UpdateClientList '" & sname & "','" & Versoin & "','" & Ip & "'"

        Return DbHelper.AddInof(sql)
    End Function

    ''' <summary>
    ''' ��¼�ͻ��˸��µ���ϸ��Ϣ
    ''' </summary>
    ''' <param name="ucid"></param>
    ''' <param name="path"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Public Shared Sub InsertPathInfo(ByVal ucid As Int32, ByVal path As String, ByVal state As String)
        sql = "Exec UserManage..InsertClientDetails " & ucid & ",'" & path & "','" & state & "'"

        DbHelper.ExecuteSql(sql)
    End Sub

    ''' <summary>
    ''' ��ѯ�ͻ�����Ϣ����
    ''' </summary>
    ''' <param name="Ip">ip��ַ,�˲�����ѡ��</param>
    ''' <param name="sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryClientInfo(ByVal Ip As String, ByVal sn As String)
        sql = "Exec UserManage..QueryUpdateClient '" & Ip & "','" & sn & "'"

        Return DbHelper.Query(sql)
    End Function
    ''' <summary>
    ''' ��ѯ���µ�����
    ''' </summary>
    ''' <param name="UCId">�⽨</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryUpdateClientDetails(ByVal UCId As Int32)
        sql = "Exec UserManage..QueryUpdateClientDetails " & UCId & ""

        Return DbHelper.Query(sql)
    End Function
    ''' <summary>
    ''' ����ͻ�����Ϣ
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteUpdateClient(ByVal Id As Int32)
        sql = "Exec UserManage..DeleteUpdateClient " & Id & ""

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ɾ������˵���������
    ''' </summary>
    ''' <param name="sn"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteServerInfo(ByVal sn As String)
        sql = "Exec UserManage..DeleteUpdateServer '" & sn & "'"

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ɾ���ͻ��˸���״̬��Ϣ
    ''' </summary>
    ''' <param name="Ucid">�ͻ�������</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteClientDetailsList(ByVal Ucid As Int32)
        sql = "Exec UserManage..DeleteClientDetailsList " & Ucid & ""

        DbHelper.ExecuteSql(sql)
    End Sub
    ''' <summary>
    ''' ��ѯftp��������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryUpdateInfo() As DataTable
        sql = "Exec UserManage..QueryUpdateInfo"

        Return DbHelper.Query(sql)
    End Function
    ''' <summary>
    ''' ����ftp��������
    ''' </summary>
    ''' <param name="ftpip">ip��ַ</param>
    ''' <param name="username">�û���</param>
    ''' <param name="pwd">����</param>
    ''' <remarks></remarks>
    Public Shared Sub InsertUpdateInfo(ByVal ftpip As String, ByVal username As String, ByVal pwd As String)
        sql = "Exec UserManage..InsertUpdateInfo '" & ftpip & "','" & username & "','" & pwd & "'"
        DbHelper.ExecuteSql(sql)
    End Sub
End Class
