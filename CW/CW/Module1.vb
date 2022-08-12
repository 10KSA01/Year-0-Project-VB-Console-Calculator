Imports System.IO
Module Module1 '
    ' Global variables
    Public decimalPoint As Integer = 1
    Public responceYesNo As String
    Public menuActive As Boolean = False
    Public accuracyOptionActive As Boolean = False
    Public quadraticEquationActive As Boolean = False
    Public proteinSequencActive As Boolean = False
    Public primeNumberActive As Boolean = False

    Sub Main() ' Main Menu
        menuText(0) ' This calls the menuText function
        menuOption(0) ' This calls the menuOption function

        menuActive = True ' When the program gets executed then the variable ed menuActive will get assigned as True instead of False so that the loop will run
        Dim Options As String ' 
        While menuActive = True
            Try
                Console.Write("Please pick the options from 1 to 5 and then press Enter key: ")
                Options = Console.ReadLine()
                Console.WriteLine()
                menuOption(Options)
                If Options = "1" Then
                    menuActive = False
                    AccuracyOptionMenu()
                ElseIf Options = "2" Then
                    menuActive = False
                    QuadraticEquationMenu()
                ElseIf Options = "3" Then
                    menuActive = False
                    ProteinSequenceSegmentationMenu()
                ElseIf Options = "4" Then
                    menuActive = False
                    PrimeNumberMenu()
                ElseIf Options = "5" Then
                    menuActive = False
                    QuitMenu()
                Else
                    Console.Write("You have not entered the correct responce. Please write either 1, 2, 3, 4 or 5: ") ' This message will output if an invalid number has been entered
                    Options = Console.ReadLine()
                    Console.WriteLine()
                    menuActive = True
                End If
            Catch ex As Exception ' This message will output if a number has not been entered
                Console.WriteLine("You have not entered an option")
            End Try
        End While
    End Sub

    Sub AccuracyOptionMenu() ' 1
        menuText(1)

        accuracyOptionActive = True
        While accuracyOptionActive = True
            Dim decimalActive As Boolean = True
            Dim decimalEntered As String
            Console.WriteLine("How many decimal places do you want your results to display as? ")
            While decimalActive = True
                Try
                    Console.Write("Please enter a number between 1-5: ")
                    decimalEntered = Console.ReadLine

                    If decimalEntered = "1" Or decimalEntered = "2" Or decimalEntered = "3" Or decimalEntered = 4 Or decimalEntered = 5 Then
                        decimalPoint = Convert.ToInt64(decimalEntered)
                        Console.WriteLine("The decimal places has been set to: " & decimalPoint)
                        Console.WriteLine()
                        decimalActive = False
                    Else
                        Console.WriteLine("The number that you have entered is not a natural number between 1 to 5.")
                        decimalActive = True
                    End If
                Catch ex As Exception
                    Console.WriteLine("That is not a natural number.")
                End Try
            End While

            Console.Write("Do you want to use another value instead? (Yes/No): ")
            responceYesNo = Console.ReadLine().ToLower
            Console.WriteLine()
            YesOrNo(responceYesNo)
            If YesOrNo(responceYesNo) = "no" Or YesOrNo(responceYesNo) = "n" Then
                accuracyOptionActive = False
            End If
        End While
    End Sub

    Sub QuadraticEquationMenu() ' 2
        menuText(2)

        quadraticEquationActive = True
        While quadraticEquationActive = True
            Dim a, b, c, rootX1, rootX2 As Decimal
            Dim aCheck, bCheck, cCheck As Boolean
            aCheck = True
            bCheck = True
            cCheck = True

            While aCheck = True
                Try
                    Console.Write("Please enter the value of A: ")
                    a = Console.ReadLine()
                    If a <> 0 Then
                        aCheck = False
                    Else
                        Console.WriteLine("0 is invalid input")
                    End If
                Catch ex As Exception
                    Console.WriteLine("That is not a real number. Please enter a real number.")
                End Try
            End While
            While bCheck = True
                Try
                    Console.Write("Please enter the value of B: ")
                    b = Console.ReadLine()
                    bCheck = False
                Catch ex As Exception
                    Console.WriteLine("That is not a real number. Please enter a real number.")
                End Try
            End While
            While cCheck = True
                Try
                    Console.Write("Please enter the value of C: ")
                    c = Console.ReadLine()
                    cCheck = False
                Catch ex As Exception
                    Console.WriteLine("That is not a real number. Please enter a real number.")
                End Try
            End While
            Console.WriteLine()

            Dim discriminantValue As Decimal = ((b ^ 2) - 4 * a * c)
            If discriminantValue >= 0 Then
                Console.WriteLine("The roots are real")
                rootX1 = Math.Round((-b + Math.Sqrt(((b ^ 2) - (4 * a * c)))) / (2 * a), decimalPoint)
                rootX2 = Math.Round((-b - Math.Sqrt(((b ^ 2) - (4 * a * c)))) / (2 * a), decimalPoint)

                Console.WriteLine("The value of X1 is: " & trailingZero(rootX1) & " and the value of X2 is: " & trailingZero(rootX2))
                Console.WriteLine()
            Else
                Console.WriteLine("The roots are complex")
                rootX1 = Math.Round((-b / (2 * a)), decimalPoint)
                rootX2 = Math.Round((discriminantValue * -1) ^ 0.5 / (2 * a), decimalPoint)

                Console.WriteLine("The value of X1 is: " & (trailingZero(rootX1) & "+" & trailingZero(rootX2) & "i") & " and the value of X2 is: " & (trailingZero(rootX1) & "-" & trailingZero(rootX2) & "i"))
                Console.WriteLine()
            End If

            Console.Write("Do you want to calculate another quadratic equation? (Yes/No): ")
            responceYesNo = Console.ReadLine().ToLower
            Console.WriteLine()
            YesOrNo(responceYesNo)
            If YesOrNo(responceYesNo) = "no" Or YesOrNo(responceYesNo) = "n" Then
                quadraticEquationActive = False
            End If

        End While
    End Sub

    Sub ProteinSequenceSegmentationMenu() ' 3
        menuText(3)

        proteinSequencActive = True
        While proteinSequencActive = True
            Dim fileReader As String
            Dim fileFound As Boolean = True
            Dim fileEnter As String
            While fileFound = True
                Try
                    Console.WriteLine("Please enter the file location: ")
                    fileEnter = Console.ReadLine()
                    Dim fileLocation As New IO.StreamReader(fileEnter)
                    fileReader = fileLocation.ReadLine
                    Console.WriteLine("This is the protein sequence: " & fileReader)
                    fileFound = False
                Catch ex As Exception
                    Console.WriteLine("File not found. (Did you add .txt at the end of file location)")
                End Try
            End While
            Console.WriteLine()

            Dim stringLength As Integer = Len(fileReader)
            Dim Start As Long = 0
            Dim Finish As Long = stringLength
            Dim proteinArray() As Char = fileReader.ToArray

            Console.Write(proteinArray(0))
            For i1 = 0 To stringLength - 2
                If (proteinArray(i1) = "R" And proteinArray(i1 + 1) <> "P") Or (proteinArray(i1) = "K" And proteinArray(i1 + 1) <> "P") Then
                    Finish = i1
                    For i2 = Start + 1 To Finish
                        Console.Write(proteinArray(i2))
                    Next i2
                    Start = Finish
                    Console.WriteLine()
                End If
            Next i1
            For i3 = Finish + 1 To stringLength - 1
                Console.Write(proteinArray(i3))
            Next i3
            Console.WriteLine()
            Console.WriteLine()

            Console.Write("Do you want to try another protein sequence? (Yes/No): ")
            responceYesNo = Console.ReadLine().ToLower
            Console.WriteLine()
            YesOrNo(responceYesNo)
        End While

    End Sub

    Sub PrimeNumberMenu() ' 4
        menuText(4)

        primeNumberActive = True
        While primeNumberActive = True

            Dim enterPrime As ULong, initialTime As Decimal, finalTime As Decimal, timeTaken As Decimal
            Dim enterprimeCheck As Boolean = True

            initialTime = Timer
            While enterprimeCheck = True
                Try
                    Console.Write("Enter a number: ")
                    enterPrime = Console.ReadLine()
                    initialTime = Timer
                    enterprimeCheck = False
                Catch ex As Exception
                    Console.WriteLine("That is not a natural number. Please enter a natural number that is less than 18,446,744,073,709,551,615. ")
                End Try
            End While
            primeCheck(enterPrime)
            finalTime = Timer
            timeTaken = Math.Round(finalTime - initialTime, decimalPoint)
            Console.WriteLine("The time taken to calculate this was: " & timeTaken & " seconds")

            Console.Write("Do you want to enter another number to see whether it is a prime number of not? (Yes/No): ")
            responceYesNo = Console.ReadLine().ToLower
            Console.WriteLine()
            YesOrNo(responceYesNo)
        End While
    End Sub

    Sub QuitMenu() ' 5
        menuText(5)

        Console.Write("Are you sure you want to quit? (Yes/No): ")
        responceYesNo = Console.ReadLine().ToLower
        YesOrNo(responceYesNo)
    End Sub

    Function primeCheck(ByVal x As ULong) As ULong
        Dim primeResult As Boolean = True
        If x = 1 Then
            primeResult = False
        Else
            For Check As ULong = 2 To Math.Sqrt(x) Step 2
                If x Mod Check = 0 Then
                    primeResult = False
                End If
            Next
        End If
        If primeResult = True Then
            Console.WriteLine(trailingZero(x) & " is a prime number")
            Console.WriteLine()
        Else
            Console.WriteLine(trailingZero(x) & " is not a prime number")
            Console.WriteLine()
        End If
        Return primeCheck
    End Function

    Function YesOrNo(ByVal x As String) As String
        Dim tryAgain As Boolean = True
        While tryAgain = True

            If x = "n" Or x = "no" Then
                Console.WriteLine()
                Main()
                tryAgain = False
                menuActive = False
                accuracyOptionActive = False
                quadraticEquationActive = False
                proteinSequencActive = False
                primeNumberActive = False

            ElseIf x = "y" Or x = "yes" Then
                If menuOption(1) Then
                    AccuracyOptionMenu()
                ElseIf menuOption(2) Then
                    QuadraticEquationMenu()
                ElseIf menuOption(3) Then
                    ProteinSequenceSegmentationMenu()
                ElseIf menuOption(4) Then
                    PrimeNumberMenu()
                ElseIf menuOption(5) Then
                    Environment.Exit(0)
                ElseIf menuOption(0) Then
                    Main()
                End If
                tryAgain = False

            Else
                Console.Write("You have not entered a valid responce. Please write either Yes or No: ")
                x = Console.ReadLine().ToLower
                Console.WriteLine()
                tryAgain = True
            End If
        End While
        Return YesOrNo
    End Function

    Function trailingZero(ByVal x As Decimal) As Decimal
        Dim Rounding As Decimal
        If decimalPoint = 1 Then
            Rounding = Format(x, "##.0")
            trailingZero = Math.Round(Rounding, decimalPoint)
        ElseIf decimalPoint = 2 Then
            Rounding = Format(x, "##.00")
            trailingZero = Math.Round(Rounding, decimalPoint)
        ElseIf decimalPoint = 3 Then
            Rounding = Format(x, "##.000")
            trailingZero = Math.Round(Rounding, decimalPoint)
        ElseIf decimalPoint = 4 Then
            Rounding = Format(x, "##.0000")
            trailingZero = Math.Round(Rounding, decimalPoint)
        ElseIf decimalPoint = 5 Then
            Rounding = Format(x, "##.00000")
            trailingZero = Math.Round(Rounding, decimalPoint)
        End If
        Return trailingZero
    End Function
    Function menuOption(ByVal x As Integer) As Integer
        If x = 1 Then
            x = menuOption
        ElseIf x = 2 Then
            x = menuOption
        ElseIf x = 3 Then
            x = menuOption
        ElseIf x = 4 Then
            x = menuOption
        ElseIf x = 5 Then
            x = menuOption
        End If
        Return menuOption
    End Function

    Function menuText(ByVal x As Integer) As String
        If x = 0 Then
            Console.Clear()
            Console.Title = "CS0002 - Main Menu"
            Console.WriteLine("=================================================")
            Console.WriteLine(" CS0002 - Introduction to Programming Coursework ")
            Console.WriteLine("-------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("The decimal point is set to 1 by default. If you wish to change it then choose option 1) Accuracy Option)")
            Console.WriteLine()
            Console.WriteLine("1) Accuracy Option")
            Console.WriteLine("2) Quadratic Equations")
            Console.WriteLine("3) Protein Sequence Segmentation")
            Console.WriteLine("4) Prime Numbers")
            Console.WriteLine("5) Exit")
            Console.WriteLine()

        ElseIf x = 1 Then
            Console.Clear()
            Console.Title = "CS0002 - Accuracy Option Menu"
            Console.WriteLine("======================")
            Console.WriteLine(" Accuracy Option Menu ")
            Console.WriteLine("----------------------")
            Console.WriteLine()

        ElseIf x = 2 Then
            Console.Clear()
            Console.Title = "CS0002 - Quadratic Equations Menu"
            Console.WriteLine("==========================")
            Console.WriteLine(" Quadratic Equations Menu ")
            Console.WriteLine("--------------------------")
            Console.WriteLine()
            Console.WriteLine("This is the quadratic equation: Ax^2+Bx+C=0.")
            Console.WriteLine("A, B and C are real numbers.")
            Console.WriteLine()

        ElseIf x = 3 Then
            Console.Clear()
            Console.Title = "CS0002 - Protein Sequence Segmentation Menu"
            Console.WriteLine("====================================")
            Console.WriteLine(" Protein Sequence Segmentation Menu ")
            Console.WriteLine("------------------------------------")
            Console.WriteLine()

        ElseIf x = 4 Then
            Console.Clear()
            Console.Title = "CS0002 - Prime Number Menu"
            Console.WriteLine("===================")
            Console.WriteLine(" Prime Number Menu ")
            Console.WriteLine("-------------------")
            Console.WriteLine()
            Console.WriteLine("A prime number is a natural number (a number >= 0) that is divisible only by itself and 1.")
            Console.WriteLine()

        ElseIf x = 5 Then
            Console.Clear()
            Console.Title = "CS0002 - Quit Menu"
            Console.WriteLine("===========")
            Console.WriteLine(" Quit Menu ")
            Console.WriteLine("-----------")
            Console.WriteLine()

        End If
        Return x
    End Function
End Module
