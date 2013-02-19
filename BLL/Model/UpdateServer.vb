Public Class UpdateServer

    Private _Id As Int32
    Private _SystemName As String
    Private _fileName As String
    Private _Version As String
    Private _Remark As String
    Private _State As String
    ''' <summary>
    ''' ±àºÅ
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
    ''' ³ÌÐòÃû³Æ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SystemName()
        Get
            Return _SystemName
        End Get
        Set(ByVal value)
            _SystemName = value
        End Set
    End Property
    ''' <summary>
    ''' Â·¾¶
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property fileName()
        Get
            Return _fileName
        End Get
        Set(ByVal value)
            _fileName = value
        End Set
    End Property
    ''' <summary>
    ''' °æ±¾ºÅ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Version()
        Get
            Return _Version
        End Get
        Set(ByVal value)
            _Version = value
        End Set
    End Property
    ''' <summary>
    ''' ±¸×¢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Remark()
        Get
            Return _Remark
        End Get
        Set(ByVal value)
            _Remark = value
        End Set
    End Property
    ''' <summary>
    ''' ×´Ì¬
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property State()
        Get
            Return _State
        End Get
        Set(ByVal value)
            _State = value
        End Set
    End Property
End Class
