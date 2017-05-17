Namespace Biblio

    Public Class Livre
        Inherits Document

        Private auteur As String
        Private editeur As String
        Private nbPages As Integer

        Public Sub New(ByVal t As String, ByVal a As String, ByVal e As String, ByVal p As Integer)
            MyBase.New(t)
            auteur = a
            editeur = e
            nbPages = p
        End Sub

        Public Overrides Function ToString() As String
            Return MyBase.ToString() & "de " & auteur & " chez " & editeur & " nombre de pages : " & nbPages.ToString
        End Function

    End Class
End Namespace
