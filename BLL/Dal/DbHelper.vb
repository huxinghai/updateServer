Imports System.Data.SqlClient

Public Class DbHelper
    Private Shared _Connection As SqlConnection
    Private Shared _Command As SqlCommand
    Private Shared _DataAdapter As SqlDataAdapter
    Private Shared _Tran As SqlTransaction


    ''' <summary>
    ''' Connection����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared ReadOnly Property Connection()
        Get
            If _Connection Is Nothing Then
                _Connection = New SqlConnection(WriteConnection)
            End If

            If _Connection.State = ConnectionState.Closed Then
                _Connection.Open()
            End If

            Return _Connection
        End Get
    End Property

    ''' <summary>
    ''' ��ѯ����
    ''' </summary>
    ''' <param name="sql">sql���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Query(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        _Command = New SqlCommand(sql, Connection)
        _DataAdapter = New SqlDataAdapter(_Command)
        _DataAdapter.Fill(dt)

        Return dt
    End Function
    ''' <summary>
    ''' ִ��sql���
    ''' </summary>
    ''' <param name="sql">sql���</param>
    ''' <remarks></remarks>
    Public Shared Sub ExecuteSql(ByVal sql As String)
        _Command = New SqlCommand(sql, Connection)
        _Command.ExecuteNonQuery()
    End Sub

    ''' <summary>
    ''' �ж��Ƿ��������
    ''' </summary>
    ''' <param name="sql">sql���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsExists(ByVal sql As String) As Boolean
        Dim dt As New DataTable
        _Command = New SqlCommand(sql, Connection)
        _DataAdapter = New SqlDataAdapter(_Command)
        _DataAdapter.Fill(dt)

        If dt.Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    ''' <summary>
    '''ִ������ 
    ''' </summary>
    ''' <param name="sql">����sql���</param>
    ''' <remarks></remarks>
    Public Shared Function ExecuteTran(ByVal sql As String) As Boolean
        Try
            _Tran = Connection.BeginTransaction()
            _Command = New SqlCommand(sql, Connection)
            _Command.Transaction = _Tran
            _Command.ExecuteNonQuery()
            _Tran.Commit()
            Return True
        Catch ex As Exception
            _Tran.Rollback()
            Return False
        End Try
    End Function

    ''' <summary>
    '''���һ������
    ''' </summary>
    ''' <param name="sql">����sql���</param>
    ''' <remarks>��һ�е�һ�е�����</remarks>
    Public Shared Function AddInof(ByVal sql As String)
        Try
            _Command = New SqlCommand(sql, Connection)
            Return _Command.ExecuteScalar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' �õ�����������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetServerDate() As String
        Dim dt As New DataTable
        dt = Query("select GetDate()")

        Return Format(Convert.ToDateTime(dt.Rows(0)(0)), "yyyy-MM-dd")
    End Function

    ''' <summary>
    ''' ��ȡ�����ִ�
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteConnection() As String
        Dim str As String = ""
        Try
            If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\Cn.txt") Then
                Return str
            End If

            str = IO.File.ReadAllText(My.Application.Info.DirectoryPath & "\Cn.txt").Trim()

            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
