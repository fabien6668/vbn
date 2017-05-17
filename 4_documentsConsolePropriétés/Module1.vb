Imports _4_documentsConsolePropriétés.Biblio

Module Module1

    Sub Main()

        Dim d As Document
        d = New Document

        d.LeTitre = "Le sentiment même de soi"
        d.LAuteur = "Damasio"

        Console.WriteLine("Le document est " & d.LeTitre & " de " & d.LAuteur)

    End Sub

End Module
