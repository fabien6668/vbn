Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class BibliothequeCtrl
    Shared Sub Sauver(ByRef bib As Biblio.Bibliotheque)

        Dim sw As FileStream = File.Create("documents.dat")

        Dim xs As BinaryFormatter = New BinaryFormatter()

        xs.Serialize(sw, bib)

        sw.Close()
    End Sub

    Shared Function Charger() As Biblio.Bibliotheque
        Dim b As Biblio.Bibliotheque

        Dim sw As FileStream = File.Open("documents.dat", FileMode.Open)

        Dim xs As BinaryFormatter = New BinaryFormatter()

        b = xs.Deserialize(sw)

        sw.Close()

        Return b

    End Function
End Class
