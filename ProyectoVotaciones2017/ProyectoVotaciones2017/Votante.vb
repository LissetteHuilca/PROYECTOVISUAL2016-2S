Public Class Votante
    Inherits IntegrantesElecciones




    Private _cedula As String

    Public Sub New(cedula As String)
        Me.Cedula = cedula
    End Sub

    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property



End Class
