
Namespace Biblio

    <Serializable()> Public Class Document
        Private titre As String
        Private datecreation As DateTime

        Private Shared compteur As Integer = 0

        Public Property LeTitre() As String
            Get
                Return titre
            End Get
            Set(ByVal value As String)
                titre = value
            End Set
        End Property


        Public Sub New(ByVal t As String)
            titre = t
            datecreation = Date.Now
            compteur += 1
        End Sub

        Public Shared ReadOnly Property Combien() As Integer
            Get
                Return compteur
            End Get

        End Property

        Public Overrides Function ToString() As String
            Return LeTitre & " du " & datecreation
        End Function

    End Class



End Namespace
