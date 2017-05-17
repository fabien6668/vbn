Imports _6_bibliothequeConsole.Biblio

Module Module1

    Sub Main()
        Dim b As Bibliotheque = New Bibliotheque("Orsys Biblio")
        b.AjouteDocument("Le misanthrope", "Molière")
        b.AjouteDocument("Discours sur le style", "Buffon")
        b.AjouteDocument("Le neveu de Rameau", "Diderot")
        b.AjouteDocument("Lorenzaccio", "Musset")
        b.AjouteDocument("Aventures de Télémaque", "Fénelon")

        Console.WriteLine(b.Print())

        Console.WriteLine("Nombre de documents : " & Document.Combien.ToString())

    End Sub

End Module
