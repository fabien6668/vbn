Imports _13_bibliothequeCollections.Biblio

Public Class Form1
    Dim WithEvents bibliotheque As Bibliotheque = New Bibliotheque("Orsys Biblio")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        bibliotheque.AjouteDocument("Theatre", "Le misanthrope", "Molière", "Larousse", 102)
        bibliotheque.AjouteDocument("Littérature", "Discours sur le style", "Buffon", "Hatier", 59)
        bibliotheque.AjouteDocument("Theatre", "Le neveu de Rameau", "Diderot", "Larousse", 152)
        bibliotheque.AjouteDocument("Littérature", "Lorenzaccio", "Musset", "Larousse", 152)
        bibliotheque.AjouteDocument("VB.NET", "Aventures de Télémaque", "Fénelon", "Larousse", 152)
        bibliotheque.AjouteDocument("Science", "Pour la Science", Revue.Frequence.Mensuel)
        bibliotheque.AjouteDocument("VB.NET", "la recherche", Revue.Frequence.Mensuel)

        Me.Text = bibliotheque.LeNom
        MetAJourLaListe()
        MetAJourLaCombo()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            bibliotheque.AjouteDocument(TextBox5.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, CType(TextBox4.Text, Integer))
            MetAJourLaListe()
        Catch ex As TropDeDocumentsException
            MessageBox.Show(ex.Affiche, "Il n'y a plus de dispos !!")
        End Try

    End Sub

    Private Sub MetAJourLaListe()

        ListBox1.Items.Clear()

        For Each d As Document In bibliotheque.LesDocs
            If d Is Nothing Then
                Exit For
            End If
            ListBox1.Items.Add(d)
        Next
    End Sub

    Public Sub Affiche(ByVal s As String) Handles bibliotheque.UnDocumentEnPlus
        MessageBox.Show(s, "Nouveau document")
        MetAJourLaListe()
        MetAJourLaCombo()
    End Sub

    Private Sub MetAJourLaCombo()
        ComboBox1.Items.Clear()

        For Each d As String In bibliotheque.LesIndex
            If d Is Nothing Then
                Exit For
            End If
            ComboBox1.Items.Add(d)
        Next
    End Sub

   
  
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selec As String = ComboBox1.SelectedItem.ToString()

        ListBox1.Items.Clear()

        For Each d As Document In bibliotheque.LesDocsParIndex(selec)
            If d Is Nothing Then
                Exit For
            End If
            ListBox1.Items.Add(d)
        Next
    End Sub
End Class
