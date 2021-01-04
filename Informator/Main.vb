Module Main
    Dim command As String
    Sub Main()
        Console.Title = "C:\Windows\System32\cmd.exe \>Launch " & IO.Directory.GetCurrentDirectory & "\" & My.Application.Info.AssemblyName & ".exe"
        Console.WriteLine("Initialising ...")
        Console.WriteLine("Launching ...")
        Wait(4)
        Console.Clear()
        Console.WriteLine("Initialising ... OK")
        Console.WriteLine("Launching ...")
        Wait(5)
        Console.Clear()
        Console.WriteLine("Initialising ... OK")
        Console.WriteLine("Launching ... OK")
        Wait(1)
        Console.Clear()
        Console.Title = IO.Directory.GetCurrentDirectory & "\" & My.Application.Info.AssemblyName & ".exe"
        Console.WriteLine("    - - - - FILE INFORMATOR - - - -    ")
        Console.WriteLine("")
start:
        Console.Write("Enter command :")
        command = Console.ReadLine()
        Console.WriteLine("")
        Wait(1)
        If command.ToLower = "help" Then
            Console.WriteLine(" -- HELP -- ")
            Console.WriteLine("INFO <way> - Get information from file. Prewiev: INFO C:\Users\Documents Result: create date, save date, open date.")
            Console.WriteLine("SEARCH <date> <mode> - Get file from information. Prewiev: SEARCH 10.08.2010 open Result: file names.")
            Console.WriteLine("END - End programm.")
        ElseIf command.Split(" ")(0).ToLower = "info" Then
            Try
                If My.Computer.FileSystem.FileExists(command.Split(" ")(1)) Then
                    Console.WriteLine("Create date: " & My.Computer.FileSystem.GetFileInfo(command.Split(" ")(1)).CreationTime.Date)
                    Console.WriteLine("Save date: " & My.Computer.FileSystem.GetFileInfo(command.Split(" ")(1)).LastWriteTime.Date)
                    Console.WriteLine("Open date: " & My.Computer.FileSystem.GetFileInfo(command.Split(" ")(1)).LastAccessTime.Date)
                Else
                    Console.WriteLine("File is not found.")
                End If
            Catch
                Console.WriteLine("File is not found.")
            End Try
        ElseIf command.Split(" ")(0).ToLower = "search" Then
            Dim dravers() As IO.DriveInfo = IO.DriveInfo.GetDrives
            Console.WriteLine("Results:")
            Try
                For i_1 As Integer = 0 To dravers.Length - 1
                    Try
                        Dim result() As String = IO.Directory.GetFiles(dravers(i_1).Name, "*", IO.SearchOption.AllDirectories)
                        If command.Split(" ")(2).ToLower = "open" Then
                            For i_2 As Integer = 0 To result.Length - 1
                                If My.Computer.FileSystem.GetFileInfo(result(i_2)).LastAccessTime.Date = command.Split(" ")(1) Then
                                    Console.WriteLine(result(i_2))
                                End If
                            Next
                        ElseIf command.Split(" ")(2).ToLower = "save" Then
                            For i_2 As Integer = 0 To result.Length - 1
                                If My.Computer.FileSystem.GetFileInfo(result(i_2)).LastWriteTime.Date = command.Split(" ")(1) Then
                                    Console.WriteLine(result(i_2))
                                End If
                            Next
                        ElseIf command.Split(" ")(2).ToLower = "create" Then
                            For i_2 As Integer = 0 To result.Length - 1
                                If My.Computer.FileSystem.GetFileInfo(result(i_2)).CreationTime.Date = command.Split(" ")(1) Then
                                    Console.WriteLine(result(i_2))
                                End If
                            Next
                        End If
                    Catch
                        Console.WriteLine("File is not found.")
                    End Try
                Next
            Catch
                Console.WriteLine("File is not found.")
            End Try
        ElseIf command.Split(" ")(0).ToLower = "cmd" Then
            Console.Clear()
            Console.Title = "C:\Windows\System32\cmd.exe \>Launch " & IO.Directory.GetCurrentDirectory & "\" & My.Application.Info.AssemblyName & ".exe"
            Console.WriteLine("Reload FILE INFORMATOR... Please, wait...")
            For i As Integer = 0 To 100
                Wait(1)
                Console.WriteLine("Progress: " & i & "%")
            Next
            Wait(1)
            Console.Clear()
            Console.Title = IO.Directory.GetCurrentDirectory & "\" & My.Application.Info.AssemblyName & ".exe"
            Console.WriteLine("    - - - - FILE INFORMATOR - - - -    ")
        Else
            If command.ToLower <> "end" Then
                Console.WriteLine("Unknown command. Enter commad 'help' to get help for commands.")
            End If
        End If
        Console.WriteLine("")
        If command.ToLower <> "end" Then
            GoTo start
        End If
    End Sub
    Private Sub Wait(ByVal seconds As Short)
        Dim start As Single
        start = Timer
        Do While Timer < start + seconds
        Loop
    End Sub
End Module
