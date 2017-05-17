Namespace Biblio

    Public Class Revue
        Inherits Document
        Public Enum Frequence
            Quotidien
            Hebdomadaire
            Mensuel
        End Enum

        Private parution As Frequence

        Public Sub New(ByVal t As String, ByVal f As Frequence)
            MyBase.New(t)
            parution = f
        End Sub

        Public Overrides Function ToString() As String
            Return MyBase.ToString() & " parution " & parution.ToString()
        End Function
    End Class
End Namespace

