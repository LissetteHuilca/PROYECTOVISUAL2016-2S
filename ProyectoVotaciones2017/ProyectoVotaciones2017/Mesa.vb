Public Class Mesa
    Private _presidente As String
    Public Property Presidente() As String
        Get
            Return _presidente
        End Get
        Set(ByVal value As String)
            _presidente = value
        End Set
    End Property

    Private _secretaria As String
    Public Property Secretaria() As String
        Get
            Return _secretaria
        End Get
        Set(ByVal value As String)
            _secretaria = value
        End Set
    End Property

    Private _vocal As String
    Public Property Vocal() As String
        Get
            Return _vocal
        End Get
        Set(ByVal value As String)
            _vocal = value
        End Set
    End Property

End Class
