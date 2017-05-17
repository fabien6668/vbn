Imports _17_bibliothequeADO.NET_DLL.Biblio
Imports _17_bibliothequeADO.NET_DLL

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Text = "Biblio en base ..."
        MetAJourLaListe()
        MetAJourLaCombo()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            BibliothequeDAO.AjouteDocument(TextBox5.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, CType(TextBox4.Text, Integer))
            MetAJourLaListe()
        Catch ex As TropDeDocumentsException
            MessageBox.Show(ex.Affiche(), "Il n'y a plus de dispos !!")
        End Try

    End Sub

    Private Sub MetAJourLaListe()

        ListBox1.DataSource = BibliothequeDAO.GetAllDocuments()
        
    End Sub

    Public Sub Affiche(ByVal s As String)
        ' MessageBox.Show(s, "Nouveau document")
        MetAJourLaListe()
        MetAJourLaCombo()
    End Sub

    Private Sub MetAJourLaCombo()

        ComboBox1.DataSource = BibliothequeDAO.GetAllIndexes()

    End Sub

   
  
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selec As String = ComboBox1.SelectedItem.ToString()

        ListBox1.DataSource = BibliothequeDAO.GetAllDocumentsForIndex(selec)
      
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim req = From d In BibliothequeDAO.GetAllDocuments()
                  Where d.GetType().Name.Contains("Livre")
                  Order By d.ToString()
                  Select d

        ListBox1.DataSource = req.ToList()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'bibliotheque.AjouteDocument("Theatre", "Le misanthrope", "Molière", "Larousse", 102)
        'bibliotheque.AjouteDocument("Littérature", "Discours sur le style", "Buffon", "Hatier", 59)
        'bibliotheque.AjouteDocument("Theatre", "Le neveu de Rameau", "Diderot", "Larousse", 152)
        'bibliotheque.AjouteDocument("Littérature", "Lorenzaccio", "Musset", "Larousse", 152)
        'bibliotheque.AjouteDocument("VB.NET", "Aventures de Télémaque", "Fénelon", "Larousse", 152)
        'bibliotheque.AjouteDocument("Science", "Pour la Science", bibliotheque.Frequence.Mensuel)
        'bibliotheque.AjouteDocument("VB.NET", "la recherche", bibliotheque.Frequence.Mensuel)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        BibliothequeDAO.InitDb()
        MessageBox.Show("Base initialisée")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ListBox1.DataSource = BibliothequeDAO.GetAllDocuments()
        ComboBox1.DataSource = BibliothequeDAO.GetAllIndexes()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ListBox1.DataSource = BibliothequeDAO.CreateDataset().Tables(0).DefaultView
        ListBox1.DisplayMember = "Titre"

    End Sub
End Class
