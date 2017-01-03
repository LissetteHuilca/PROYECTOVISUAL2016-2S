Public Class Administrador
    Inherits IntegrantesElecciones


    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _contraseña As String

    Public Sub New(nombre As String, apellido As String, edad As Integer, email As String, telefono As String, genero As String, cedula As String)
        MyBase.New(nombre, apellido, edad, email, telefono, genero, cedula)
    End Sub

    Public Sub New(usuario As String, contraseña As String)
        MyBase.New()
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub

    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property





End Class
