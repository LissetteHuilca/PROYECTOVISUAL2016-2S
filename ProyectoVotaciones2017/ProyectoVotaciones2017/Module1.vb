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
    Const AINFO As Byte = 2
    Const AGENERAR As Byte = 3
    Const AREGRESAR As Byte = 4

    Const VERIFICAR As Byte = 1
    Const REGRESA As Byte = 2
    Const CVERIFICAR As Byte = 1
    Const CREGRESA As Byte = 2

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
                Case VVOTAR
                    Console.WriteLine("Votando...")
                Case VOUT
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = VOUT

    End Sub

    Sub MenuAdministrador()
        Console.WriteLine("{0}. Crear dignidad", CREAR)
        Console.WriteLine("{0}. Información de la votación", INFO)
        Console.WriteLine("{0}. Generar reportes", GENERAR)
        Console.WriteLine("{0}. Regresar al menú principal", REGRESAR)

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

            Select Case opcion
                Case ACREAR
                    Console.WriteLine("Creando dignidades...")
                Case AINFO
                    Console.WriteLine("Informacion de la votación...")
                Case AGENERAR
                    Console.WriteLine("Generando reportes...")
                Case AREGRESAR
                    Console.WriteLine("Volver al menú principal")
                Case Else
                    Console.WriteLine("XXX Opción Inválida XXX")

            End Select

        Loop Until opcion = AREGRESAR

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

        Dim cargo = 1


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
        End If
        If cargo = 2 Then
            'For Each nodoPadre As XmlNode In raiz
            '    For Each nodoHijo As XmlNode In nodoPadre
            '    If nodoHijo.Name = "Votante" Then
            '        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
            '            If (nodoChid.Name = "Cedula") Then
            '                If String.Compare(nodoChid.InnerText, usuario.Cedula, True) = 0 Then
            '                    Console.WriteLine("----------Bienvenido ---------- ")
            '                    Console.WriteLine("Cédula" & vbTab & nodoChid.InnerText)
            '                End If
            '            End If
            '        Next
            '    End If
            'Next
            'Next

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
