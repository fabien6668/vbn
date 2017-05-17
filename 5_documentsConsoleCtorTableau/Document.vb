
Namespace Biblio

    Public Class Document
        Private titre As String
        Private auteur As String
        Private datecreation As DateTime

        Public Property LeTitre() As String
            Get
                Return titre
            End Get
            Set(ByVal value As String)
                titre = value
            End Set
        End Property

        Public Property LAuteur() As String
            Get
                Return auteur
            End Get
            Set(ByVal value As String)
                auteur = value
            End Set
        End Property

        'Etape 1
        Public Sub New()
            datecreation = New DateTime
            titre = "sans titre "
            auteur = "auteur inconnu"
        End Sub

        Public Function Print() As String
            Return "Le document est " & titre & " de " & auteur & " le " & datecreation.ToShortDateString
        End Function

        'Etape 2
        Public Sub New(ByVal t As String, ByVal a As String)
            titre = t
            auteur = a
            datecreation = Date.Now
        End Sub
    End Class



End Namespace
