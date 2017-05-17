Public Class Document

    Private _t As String
    Private _p As Integer

    Protected Sub New(t As String, p As Integer)
        ' TODO: Complete member initialization 
        _t = t
        _p = p
    End Sub

End Class

Public Class Livre
    Inherits Document

    Private auteur As String

    Public Sub New(ByVal t As String, ByVal p As Integer, ByVal a As String)
        MyBase.New(t, p)

        auteur = a
    End Sub

    Public Shadows Function ToString() As String
        Return MyBase.ToString() + " auteur : " + auteur
    End Function
End Class
