Namespace Biblio

    Class Revue
        Inherits Document
     

        Private parution As Bibliotheque.Frequence

        Public Sub New(ByVal t As String, ByVal f As Bibliotheque.Frequence)
            MyBase.New(t)
            parution = f
        End Sub

        Public Overrides Function ToString() As String
            Return MyBase.ToString() & " parution " & parution.ToString()
        End Function
    End Class
End Namespace

