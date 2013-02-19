Public Class UpdateServerDetails

    Private _Id As Int32
    Private _UId As String
    Private _ServerName As String
    Private _Paths As String

    ''' <summary>
    ''' 编号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Id()
        Get
            Return _Id
        End Get
        Set(ByVal value)
            _Id = value
        End Set
    End Property
    ''' <summary>
    ''' 主表外键
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UId()
        Get
            Return _UId
        End Get
        Set(ByVal value)
            _UId = value
        End Set
    End Property
    ''' <summary>
    ''' 名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ServerName()
        Get
            Return _ServerName
        End Get
        Set(ByVal value)
            _ServerName = value
        End Set
    End Property
    ''' <summary>
    ''' 路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Paths()
        Get
            Return _Paths
        End Get
        Set(ByVal value)
            _Paths = value
        End Set
    End Property
End Class
