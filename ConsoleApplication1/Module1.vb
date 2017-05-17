Imports System.Runtime.CompilerServices

Module Module1

    Sub Print(ParamArray params() As Integer)

        For Each i As Integer In params
            Console.WriteLine(i & "-")
        Next

    End Sub

    <Extension()>
    Sub Print(i As Integer)
        Console.WriteLine(" i vaut " & i)
    End Sub

    Sub Main()


        Dim i As Integer = 6

        i.Print()

        Print(1)
        Print(42, 45)
        Print(43, 56, 67, 87, 89)

        Dim tab()() As Integer = New Integer(2)() {}

        tab(0) = New Integer() {1, 2}

        tab(0)(0) = 5


        Dim c = Convert.ToChar(10)

        Dim d = New With {.Nom = "Brissonneau", .Prenom = "Fabien"}

        Dim sonNom As String = d.Nom


    End Sub

End Module
