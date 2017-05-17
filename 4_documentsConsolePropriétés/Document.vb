
Namespace Biblio


    Public Class Document
        Private titre As String
        Private auteur As String

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
    End Class

End Namespace
