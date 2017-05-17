Imports _5_documentsConsoleCtorTableau.Biblio

Module Module1

    Sub Main()
        'Etape 1
        Dim d As Document
        d = New Document
        Console.WriteLine(d.Print())

        d = New Document
        d.LeTitre = "Le sentiment même de soi"
        d.LAuteur = "Damasio"
        Console.WriteLine(d.Print())

        'Etape 2
        d = New Document("Damasio", "Le sentiment même de soi")
        Console.WriteLine(d.Print())

        'Etape 3
        Dim t(4) As Document
        t(0) = New Document("Le misanthrope", "Molière")
        t(1) = New Document("Discours sur le style", "Buffon")
        t(2) = New Document("Le neveu de Rameau", "Diderot")
        t(3) = New Document("Lorenzaccio", "Musset")
        t(4) = New Document("Aventures de Télémaque", "Fénelon")

        For i As Integer = 0 To 4
            Console.WriteLine(t(i).Print())
        Next


    End Sub

End Module
