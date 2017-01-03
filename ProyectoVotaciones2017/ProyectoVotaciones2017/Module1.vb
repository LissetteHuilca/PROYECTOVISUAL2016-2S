Imports System.Xml

Module Module1

    Const LISTAR As Byte = 1
    Const VOTAR As Byte = 2
    Const OUT As Byte = 3
    Const VLISTAR As Byte = 1
    Const VVOTAR As Byte = 2
    Const VOUT As Byte = 3

    Const CREAR As Byte = 1
    Const INFO As Byte = 2
    Const GENERAR As Byte = 3
    Const REGRESAR As Byte = 4
    Const ACREAR As Byte = 1
    Const AGENERAR As Byte = 2
    Const AREGRESAR As Byte = 4

    Const VERIFICAR As Byte = 1
    Const REGRESA As Byte = 2
    Const CVERIFICAR As Byte = 1
    Const CREGRESA As Byte = 2

    Const OREGRESAR As Byte = 3

    Const DPRESIDENTE As Byte = 1
    Const DALCALDE As Byte = 2
    Const DPREFECTO As Byte = 3
    Const DASAMBLEISTA As Byte = 4
    Const DCONSEJALES As Byte = 5
    Const DMINISTROS As Byte = 6
    Const DREGRESAR As Byte = 7

    Const LISPRESIDENTE As Byte = 1
    Const LISALCALDE As Byte = 2
    Const LISPREFECTO As Byte = 3
    Const LISASAMBLEISTA As Byte = 4
    Const LISCONSEJALES As Byte = 5
    Const LISMINISTROS As Byte = 6
    Const LISREGRESAR As Byte = 7



    Enum Opmain
        Invalid
        Administrador
        Votante
        Candidato
        Out
    End Enum


    Public path As String = "..\..\usuarios.xml"
    Public xmldoc As New XmlDocument()

    Public raiz As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")


    Sub Main()
        Dim Opcion As Integer
        Dim usuario, contraseña, cedula As String

        Dim op As String = ""

        Do
            MenuPrincipal()

            op = Console.ReadLine()

            Try
                Opcion = CByte(op) 'Byte.parse
            Catch ex As OverflowException
                Opcion = 255
            Catch ex As Exception
                Opcion = Opmain.Invalid

            End Try

            Console.WriteLine("Ud ha ingresado: {0}", op)
            'Console.ReadLine()

            Select Case Opcion
                Case Opmain.Administrador
                    Console.WriteLine("-----------------------")
                    Dim existe
                    Do
                        Dim administrador As Administrador
                        Console.WriteLine("Ingrese su usuario:")
                        usuario = Console.ReadLine()
                        Console.WriteLine("Ingrese su contraseña:")
                        contraseña = Console.ReadLine()
                        administrador = New Administrador(usuario, contraseña)
                        existe = leerXmlUsuarios(administrador, Opcion)
                        If existe <> True Then
                            Console.WriteLine("Usuario no existe")
                        End If
                    Loop Until existe = True
                    ManejarAdministrador()

                Case Opmain.Votante
                    Console.WriteLine("-----------------------")
                    Dim existe
                    Do
                        Dim votante As Votante
                        Console.WriteLine("Ingrese su cédula: ")
                        cedula = Console.ReadLine()
                        votante = New Votante(cedula)
                        Console.WriteLine("ud envio" & Opcion & votante.Cedula)
                        existe = leerXmlUsuarios(votante, Opcion)
                        If existe <> True Then
                            Console.WriteLine("Cédula no existe")
                        End If

                    Loop Until existe = True
                    ManejarVotante()

                Case Opmain.Candidato
                    Console.WriteLine("-----------------------")
                    Dim existe
                    Do
                        Dim candidato As Candidato
                        Console.WriteLine("Ingrese su usuario:")
                        usuario = Console.ReadLine()
                        Console.WriteLine("Ingrese su contraseña:")
                        contraseña = Console.ReadLine()
                        candidato = New Candidato(usuario, contraseña)
                        existe = leerXmlUsuarios(candidato, Opcion)
                        If existe <> True Then
                            Console.WriteLine("Candidato no existe")
                        End If
                    Loop Until existe = True
                    ManejarCandidato()

                Case Opmain.Out
                    Console.WriteLine("Cerrando la aplicación")
                Case Else
                    Console.WriteLine("XXX Opción Inválida: [{0}]", Opcion)

            End Select

        Loop Until Opcion = Opmain.Out

        Console.WriteLine("Gracias")
        Console.ReadLine()

    End Sub

    Sub MenuPrincipal()
        Console.WriteLine("--------------------------------------------------------------------------------")
        Console.WriteLine("******** Sistema de Votación ********")
        Console.WriteLine("Bienvenidos a ........")
        Console.WriteLine("Escoga una opción... :")
        Console.WriteLine("1.   Inicie sesión como Administrador")
        Console.WriteLine("2.   Inicie sesión como Votante")
        Console.WriteLine("3.   Inicie sesión como Candidato")
        Console.WriteLine("4.   Cerrar la aplicación")
        Console.WriteLine("Opcion:     ")
    End Sub

    Sub MenuVotante()
        Console.WriteLine("{0}. Listar Candidatos", LISTAR)
        Console.WriteLine("{0}. Votar", VOTAR)
        Console.WriteLine("{0}. Regresar al menú principal", OUT)
    End Sub

    Sub ManejarVotante()
        Dim op As String = ""
        Dim opcion As Byte
        Do
            MenuVotante()

            op = Console.ReadLine()
            Try
                opcion = CByte(op)
            Catch ex As Exception
                opcion = 0

            End Try

            Console.WriteLine("Ud ha ingresado: {0}", op)


            Select Case opcion
                Case VLISTAR
                    Console.WriteLine("Lista De Candidatos:")
                    ListarDignidades()

                Case VVOTAR
                    Console.WriteLine("Votando...")
                Case VOUT
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = VOUT

    End Sub

    Private Sub ListarDignidades()
        Dim op As String = ""
        Dim opcion As Byte
        Do
            ListaDignidades()

            op = Console.ReadLine()
            Try
                opcion = CByte(op)
            Catch ex As Exception
                opcion = 0

            End Try
            Dim dignid As String
            Console.WriteLine("Ud ha ingresado: {0}", op)
            Select Case opcion
                Case LISPRESIDENTE
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISALCALDE
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISPREFECTO
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISASAMBLEISTA
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISCONSEJALES
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISMINISTROS
                    Console.WriteLine("Lista de candidatos a presidentes ")
                    dignid = "Presidente"
                Case LISREGRESAR
                    MenuPrincipal()
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select
            Dim ncandidato As Candidato = New Candidato(raiz.Item(0), dignid)
        Loop Until opcion = AREGRESAR
    End Sub

    Private Sub ListaDignidades()
        Console.WriteLine("A continuacion escoja una de las dignidades :")
        Console.WriteLine("*******  Dignidades   *******")
        Console.WriteLine("{0}. Presidente y Vicepresidente", LISPRESIDENTE)
        Console.WriteLine("{0}. Alcalde y Vicealcalde", LISALCALDE)
        Console.WriteLine("{0}. Prefecto y Viceprefecto", LISPREFECTO)
        Console.WriteLine("{0}. Asambelistas", LISASAMBLEISTA)
        Console.WriteLine("{0}. Consejales", LISCONSEJALES)
        Console.WriteLine("{0}. Ministros", LISMINISTROS)
        Console.WriteLine("{0}. Regresar al menu principal", LISREGRESAR)
    End Sub

    Sub MenuAdministrador()
        Console.WriteLine("{0}. Agregar candidatos", CREAR)
        Console.WriteLine("{0}. Generar reportes", GENERAR)
        Console.WriteLine("{0}. Regresar al menú principal", OREGRESAR)

    End Sub

    Sub ManejarAdministrador()
        Dim op As String = ""
        Dim opcion As Byte
        Do
            MenuAdministrador()

            op = Console.ReadLine()
            Try
                opcion = CByte(op)
            Catch ex As Exception
                opcion = 0

            End Try

            Console.WriteLine("Ud ha ingresado: {0}", op)
            Dim nomDignidad As String
            Select Case opcion
                Case ACREAR
                    Console.WriteLine("A continuacion Escoja la dignidad del candidato a ingresar : ")
                    IngresarDignidades()
                Case AGENERAR
                    Console.WriteLine("Generando reportes...")
                Case OREGRESAR
                    MenuPrincipal()
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = AREGRESAR

    End Sub

    Private Sub IngresarDignidades()
        Dim op As String = ""
        Dim opcion As Byte
        Do
            MenuDignidades()
            Console.WriteLine("Opcion...  :")
            op = Console.ReadLine()
            Try
                opcion = CByte(op)
            Catch ex As Exception
                opcion = 0

            End Try
            Dim dignidad As String

            Select Case opcion
                Case DPRESIDENTE
                    Console.WriteLine("Ingrese los datos del presidente:")
                    dignidad = "Presidente"
                    IngresarInformacion(dignidad)
                    Console.WriteLine("Ingrese los datos del vicepresidente:")
                    dignidad = "Vicepresidente"
                    IngresarInformacion(dignidad)
                Case DALCALDE
                    Console.WriteLine("Ingrese los datos del alcalde:")
                    dignidad = "Alcalde"
                    IngresarInformacion(dignidad)
                    Console.WriteLine("Ingrese los datos del alcalde:")
                    dignidad = "ViceAlcalde"
                    IngresarInformacion(dignidad)
                Case DPREFECTO
                    Console.WriteLine("Ingrese los datos del Prefecto:")
                    dignidad = "Prefecto"
                    IngresarInformacion(dignidad)
                    Console.WriteLine("Ingrese los datos del VicePrefecto:")
                    dignidad = "VicePrefecto"
                    IngresarInformacion(dignidad)
                Case DASAMBLEISTA
                    Console.WriteLine("Ingrese los datos del Asambleista:")
                    dignidad = "Asambleista"
                    IngresarInformacion(dignidad)
                Case DCONSEJALES
                    Console.WriteLine("Ingrese los datos del Concejal:")
                    dignidad = "Concejal"
                    IngresarInformacion(dignidad)
                Case DMINISTROS
                    Console.WriteLine("Ingrese los datos del Ministro:")
                    dignidad = "Ministro"
                    IngresarInformacion(dignidad)
                Case DREGRESAR
                    ManejarAdministrador()
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = AREGRESAR


    End Sub

    Private Sub IngresarInformacion(dign As String)
        'Dim candidato As Candidato
        Dim candidato As New Candidato
        Dim nombre, apellido, email, telefono, genero, cedula, dignidad, usuario, contraseña As String
        Dim edad As Integer
        Console.Write("Nombre    :")
        nombre = Console.ReadLine()
        Console.Write("Apellido    :")
        apellido = Console.ReadLine()
        Console.Write("Edad    :")
        edad = Console.ReadLine()
        Console.Write("Email    :")
        email = Console.ReadLine()
        Console.Write("Telefono   :")
        telefono = Console.ReadLine()
        Console.Write(" Genero    :")
        genero = Console.ReadLine()
        Console.Write("Cedula    :")
        cedula = Console.ReadLine()
        Console.Write("Usuario    :")
        usuario = Console.ReadLine()
        Console.Write("Contraseña    :")
        contraseña = Console.ReadLine()
        dignidad = dign
        candidato = New Candidato(nombre, apellido, edad, email, telefono, genero, cedula, dignidad, usuario, contraseña)

        Dim path As String = "..\..\usuarios.xml"
        Dim raiz As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")
        Dim nodos As XmlNode = candidato.agregarCandidato(xmldoc)

        For Each nodo As XmlNode In raiz
            Console.WriteLine("Registrando...")
            nodo.AppendChild(nodos)
        Next
        Console.WriteLine("El nuevo candidato fue agregado con exito")
        xmldoc.Save(path)


    End Sub

    Private Sub MenuDignidades()
        Console.WriteLine("*******  Dignidades   *******")
        Console.WriteLine("{0}. Presidente y Vicepresidente", DPRESIDENTE)
        Console.WriteLine("{0}. Alcalde y Vicealcalde", DALCALDE)
        Console.WriteLine("{0}. Prefecto y Viceprefecto", DPREFECTO)
        Console.WriteLine("{0}. Asambelistas", DASAMBLEISTA)
        Console.WriteLine("{0}. Consejales", DCONSEJALES)
        Console.WriteLine("{0}. Ministros", DMINISTROS)
        Console.WriteLine("{0}. Regresar al menu principal", DREGRESAR)
    End Sub

    Sub MenuCandidato()
        Console.WriteLine("{0}. Verificar resultados", VERIFICAR)
        Console.WriteLine("{0}. Regresar al menú principal", REGRESA)

    End Sub

    Sub ManejarCandidato()
        Dim op As String = ""
        Dim opcion As Byte
        Do
            MenuCandidato()

            op = Console.ReadLine()
            Try
                opcion = CByte(op)
            Catch ex As Exception
                opcion = 0

            End Try

            Console.WriteLine("Ud ha ingresado: {0}", op)


            Select Case opcion
                Case CVERIFICAR
                    Console.WriteLine("Verificando resultados...")
                Case CREGRESA
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = CREGRESA

    End Sub

    Public Function leerXmlUsuarios(usuario As Object, opcion As Integer) As Boolean

        xmldoc.Load(path)

        Dim cargo As Integer
        cargo = opcion


        Dim coincidencias As Integer = 0
        If cargo = 1 Then
            For Each nodoPadre As XmlNode In raiz
                For Each nodoHijo As XmlNode In nodoPadre
                    If nodoHijo.Name = "Administrador" Then
                        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
                            If (nodoChid.Name = "Usuario") Then
                                If String.Compare(nodoChid.InnerText, usuario.Usuario, True) = 0 Then
                                    Console.WriteLine("----------Bienvenido ---------- ")
                                    Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
                                    coincidencias = coincidencias + 1
                                End If
                            End If
                            If (nodoChid.Name = "Contraseña") Then
                                If String.Compare(nodoChid.InnerText, usuario.Contraseña, True) = 0 Then
                                    coincidencias = coincidencias + 1
                                    Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
            If coincidencias = 2 Then
                Return True
            End If
        ElseIf cargo = 2 Then

            For Each nodoPadre As XmlNode In raiz
                For Each nodoHijo As XmlNode In nodoPadre
                    If nodoHijo.Name = "Votante" Then
                        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
                            If (nodoChid.Name = "Cedula") Then
                                If String.Compare(nodoChid.InnerText, usuario.Cedula, True) = 0 Then
                                    Console.WriteLine("----------Bienvenido ---------- ")
                                    Console.WriteLine("Cédula" & vbTab & nodoChid.InnerText)
                                    Return True
                                End If
                            End If
                        Next
                    End If
                Next
            Next
        Else
            For Each nodoPadre As XmlNode In raiz
                For Each nodoHijo As XmlNode In nodoPadre
                    If nodoHijo.Name = "Candidato" Then
                        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
                            If (nodoChid.Name = "Usuario") Then
                                If String.Compare(nodoChid.InnerText, usuario.Usuario, True) = 0 Then
                                    Console.WriteLine("----------Bienvenido ---------- ")
                                    Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
                                    coincidencias = coincidencias + 1
                                End If
                            End If
                            If (nodoChid.Name = "Contraseña") Then
                                If String.Compare(nodoChid.InnerText, usuario.Contraseña, True) = 0 Then
                                    coincidencias = coincidencias + 1
                                    Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
            If coincidencias = 2 Then
                Return True
            End If
        End If

    End Function

End Module
