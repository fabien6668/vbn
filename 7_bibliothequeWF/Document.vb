
Namespace Biblio

    Public Class Document
        Private titre As String
        Private auteur As String
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

        Public Property LAuteur() As String
            Get
                Return auteur
            End Get
            Set(ByVal value As String)
                auteur = value
            End Set
        End Property


        Public Function Print() As String
            Return "Le document est " & titre & " de " & auteur & " le " & datecreation.ToShortDateString
        End Function


        Public Sub New(ByVal t As String, ByVal a As String)
            titre = t
            auteur = a
            datecreation = New DateTime
            compteur += 1
        End Sub

        Public Shared ReadOnly Property Combien() As Integer
            Get
                Return compteur
            End Get

        End Property


    End Class



End Namespace
