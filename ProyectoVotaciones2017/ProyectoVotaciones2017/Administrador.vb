Public Class Administrador
    Inherits IntegrantesElecciones

    Private contraseña As String
    Private usuario As String

    Public Sub New(usuario As String, contraseña As String)
        Me.usuario = usuario
        Me.contraseña = contraseña
    End Sub

End Class
