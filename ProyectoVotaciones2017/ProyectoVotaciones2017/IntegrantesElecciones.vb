Public Class IntegrantesElecciones
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _edad As Byte
    Public Property Edad() As Byte
        Get
            Return _edad
        End Get
        Set(ByVal value As Byte)
            _edad = value
        End Set
    End Property

    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property
    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _genero As String
    Public Property Genero() As String
        Get
            Return _genero
        End Get
        Set(ByVal value As String)
            _genero = value
        End Set
    End Property

    Public Sub New(nombre As String, apellido As String, edad As Integer, email As String, telefono As String, genero As String, cedula As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Edad = edad
        Me.Email = email
        Me.Telefono = telefono
        Me.Genero = genero
        Me.Cedula = cedula
    End Sub

    Public Sub New()

    End Sub

End Class
