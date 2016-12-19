Imports System.Xml

Module Module1
    Public path As String = "C:\Users\ESTUDIANTE\Source\Repos\PROYECTOVISUAL2016-2S\ProyectoVotaciones2017\ProyectoVotaciones2017\usuarios.xml"
    Public xmldoc As New XmlDocument()
    Public raiz2 As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")
    Sub Main()
        Dim Opcion As Integer
        Dim usuario, contraseña As String

        'Do
        Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine("******** Sistema de Votacion ********")
            Console.WriteLine("Bienvenidos a ........")
            Console.WriteLine("Escoga una opcion... :")
            Console.WriteLine("1.   Inicie sesion como Administrador")
            Console.WriteLine("2.   Inicie sesion como Votante")
            Console.WriteLine("3.   Inicie sesion como Candidato")
            Console.WriteLine("Opcion:     ")
        'Loop Until Opcion < 4 & Opcion > 0
        Opcion = Console.ReadLine()

        Select Case Opcion
            Case 1
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

        End Select

        Console.ReadLine()



    End Sub

    Public Function leerXmlUsuarios(usuario As Object, opcion As Integer) As Boolean


        'Dim role As String
        'If opcion = 1 Then
        '    role = "Administrador"
        'ElseIf opcion = 3 Then
        '    role = "Candidato"
        'End If
        Dim existe2 = True
        Console.WriteLine("entro")
        Dim role = "Administrador"
        Dim cargo = 1
        Do
            Dim coincidencias As Integer = 0

            If cargo = 1 Then
                Console.WriteLine("ssssssssssssssssss")
                For Each nodoPadre As XmlNode In raiz2
                    Console.WriteLine("ssssssssssssssssss")
                    For Each nodohijo As XmlNode In nodoPadre
                        If nodohijo.Name = role Then
                            Console.WriteLine("sdfdfdgdgdfhtrufth")
                            For Each nodochild As XmlNode In nodohijo.ChildNodes
                                If (nodohijo.Name = "Administrador") Then
                                    If String.Compare(nodohijo.InnerText, usuario.Usuario, True) Then
                                        Console.WriteLine("----------Bienvenido ---------- ")
                                        Console.WriteLine("Usuario" & vbTab & nodohijo.InnerText)
                                        coincidencias = coincidencias + 1
                                    End If
                                End If
                                If (nodohijo.Name = "Contraseña") Then
                                    If String.Compare(nodohijo.InnerText, usuario.Contraseña, True) Then
                                        coincidencias = coincidencias + 1
                                        Console.WriteLine("Contraseña" & vbTab & nodohijo.InnerText)

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

        Loop Until existe2 = True

        'Dim confimarExistencia = False
        'Dim coincidencias As Integer = 0
        'If cargo = 1 Then
        '    For Each nodoPadre As XmlNode In raiz
        '        For Each nodoHijo As XmlNode In nodoPadre
        '            If nodoHijo.Name = "Vendedor" Then
        '                For Each nodoChid As XmlNode In nodoHijo.ChildNodes
        '                    If (nodoChid.Name = "Usuario") Then
        '                        If String.Compare(nodoChid.InnerText, user.Usuario, True) = 0 Then
        '                            Console.WriteLine("----------Bienvenido ---------- ")
        '                            Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
        '                            coincidencias = coincidencias + 1
        '                        End If
        '                    End If
        '                    If (nodoChid.Name = "Contraseña") Then
        '                        If String.Compare(nodoChid.InnerText, user.Contraseña, True) = 0 Then
        '                            coincidencias = coincidencias + 1
        '                            Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        Next
        '    Next
        '    If coincidencias = 2 Then
        '        Return True
        '    End If
        'Else
        '    For Each nodoPadre As XmlNode In raiz
        '        For Each nodoHijo As XmlNode In nodoPadre
        '            If nodoHijo.Name = "Administrador" Then

        '                For Each nodoChid As XmlNode In nodoHijo.ChildNodes
        '                    If (nodoChid.Name = "Usuario") Then
        '                        Console.WriteLine()
        '                        Dim k = String.Compare(nodoChid.InnerText, user.Usuario, True)
        '                        If k = 0 Then
        '                            Console.WriteLine("----------Bienvenido ---------- ")
        '                            Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
        '                            coincidencias = coincidencias + 1
        '                        End If
        '                    End If
        '                    If (nodoChid.Name = "Contraseña") Then
        '                        Dim i = String.Compare(nodoChid.InnerText, user.Contraseña, True)
        '                        If i = 0 Then
        '                            coincidencias = coincidencias + 1
        '                            Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        Next
        '    Next
        '    If coincidencias = 2 Then
        '        Return True
        '    End If
        'End If

    End Function

End Module
