Public Class Recinto
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _mesa As Mesa
    Public Property Mesa() As Mesa
        Get
            Return _mesa
        End Get
        Set(ByVal value As Mesa)
            _mesa = value
        End Set
    End Property

End Class
