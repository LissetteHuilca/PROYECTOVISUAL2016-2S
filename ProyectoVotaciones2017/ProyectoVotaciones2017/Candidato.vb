Imports System.Xml

Public Class Candidato
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
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Private _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property



    Public Sub New(nombre As String, apellido As String, edad As Integer, email As String, telefono As String, genero As String, cedula As String, dignidad As String, usuario As String, contraseña As String)
        MyBase.New(nombre, apellido, edad, email, telefono, genero, cedula)
        Me.Dignidad = dignidad
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub

    Public Sub New(nombre As String, apellido As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
    End Sub

    Public Sub New()

    End Sub

    Public Sub verificarResultado()

    End Sub

    Friend Function agregarCandidato(xmldoc As XmlDocument) As XmlNode
        Dim candidato As XmlElement = xmldoc.CreateElement("Candidato")
        Dim nombre As XmlElement = xmldoc.CreateElement("Nombre")
        Dim apellido As XmlElement = xmldoc.CreateElement("Apellido")
        Dim edad As XmlElement = xmldoc.CreateElement("Edad")
        Dim email As XmlElement = xmldoc.CreateElement("Email")
        Dim telefono As XmlElement = xmldoc.CreateElement("Telefono")
        Dim genero As XmlElement = xmldoc.CreateElement("Genero")
        Dim cedula As XmlElement = xmldoc.CreateElement("Cedula")
        Dim dignidad As XmlElement = xmldoc.CreateElement("Dignidad")
        Dim usuario As XmlElement = xmldoc.CreateElement("Usuario")
        Dim contraseña As XmlElement = xmldoc.CreateElement("Contraseña")

        nombre.InnerText = MyBase.Nombre
        apellido.InnerText = MyBase.Apellido
        edad.InnerText = MyBase.Edad
        email.InnerText = MyBase.Email
        telefono.InnerText = Me.Telefono
        genero.InnerText = Me.Genero
        cedula.InnerText = MyBase.Cedula
        dignidad.InnerText = Me.Dignidad
        usuario.InnerText = Me.Usuario
        contraseña.InnerText = Me.Contraseña


        candidato.AppendChild(nombre)
        candidato.AppendChild(apellido)
        candidato.AppendChild(edad)
        candidato.AppendChild(email)
        candidato.AppendChild(telefono)
        candidato.AppendChild(genero)
        candidato.AppendChild(cedula)
        candidato.AppendChild(dignidad)
        candidato.AppendChild(usuario)
        candidato.AppendChild(contraseña)

        Return candidato
    End Function


    Sub New(raiz As XmlNode, dignidad As String)
        Dim arrCandidatos As New ArrayList
        Dim nombre1, apellido1 As String
        'Dim edad1 As Integer
        Dim dig = dignidad
        Dim candidato As Candidato
        Dim i As Integer = 1
        Console.WriteLine(dignidad)
        For Each nodo As XmlNode In raiz.ChildNodes
            If nodo.Name = "Candidato" Then
                Console.WriteLine("entro1")
                For Each atributo As XmlNode In nodo.ChildNodes
                    If (atributo.Name = "Nombre") Then
                        nombre1 = atributo.InnerText
                        'Console.WriteLine("entro a nombre" + nombre1)
                    End If
                    If (atributo.Name = "Apellido") Then
                        apellido1 = atributo.InnerText
                        'Console.WriteLine("entro a apellido" + apellido1)
                    End If
                    If (atributo.Name = "Dignidad") Then

                        If String.Compare(atributo.InnerText, dig, True) = 0 Then
                            Console.WriteLine("entro3")
                            Console.WriteLine("nombre" + nombre1 + "apellido" + Apellido)
                            candidato = New Candidato(nombre1, apellido1)
                            arrCandidatos.Add(candidato)
                            Console.WriteLine(nombre1)
                        End If
                    End If

                Next

            End If


        Next

        For Each cand As Candidato In arrCandidatos
            Console.WriteLine(cand)
            Console.WriteLine(" ")
        Next
    End Sub


    Public Overrides Function tostring() As String
        Return "Nombre: " & Nombre + " " & Apellido
    End Function
End Class


