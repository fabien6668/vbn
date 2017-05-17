Imports _8_bibliothequeWF_delegate.Biblio

Public Class Form1
    Dim bibliotheque As Bibliotheque = New Bibliotheque("Orsys Biblio")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        bibliotheque.AjouteDocument("Le misanthrope", "Molière")
        bibliotheque.AjouteDocument("Discours sur le style", "Buffon")
        bibliotheque.AjouteDocument("Le neveu de Rameau", "Diderot")
        bibliotheque.AjouteDocument("Lorenzaccio", "Musset")
        bibliotheque.AjouteDocument("Aventures de Télémaque", "Fénelon")

        Me.Text = bibliotheque.LeNom
        MetAJourLaListe()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bibliotheque.AjouteDocument(TextBox1.Text, TextBox2.Text)
        MetAJourLaListe()

    End Sub

    Private Sub MetAJourLaListe()

        ListBox1.Items.Clear()

        For Each d As Document In bibliotheque.LesDocs
            If d Is Nothing Then
                Exit For
            End If
            ListBox1.Items.Add(d.Print())
        Next
    End Sub

    Public Sub Affiche(ByVal s As String)
        MessageBox.Show(s, "Nouveau document")
        MetAJourLaListe()
    End Sub

   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        bibliotheque.UnDocumentEnPlus = AddressOf Affiche
    End Sub
End Class
