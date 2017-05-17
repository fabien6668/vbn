Namespace Biblio

    Public Class Bibliotheque
        Private nom As String
        Private documents(10) As Document
        Private nombreDocs As Integer

        Public Event UnDocumentEnPlus(ByVal s As String)

        Public Sub New(ByVal s As String)
            nom = s
            nombreDocs = 0
        End Sub

        Public ReadOnly Property LeNom() As String
            Get
                Return nom
            End Get
        End Property

        Public Sub AjouteDocument(ByVal t As String, ByVal a As String, ByVal e As String, ByVal p As Integer)
            Dim d As Document = New Livre(t, a, e, p)

            If nombreDocs > 10 Then
                Throw New TropDeDocumentsException(d)
            End If


            documents(nombreDocs) = d
            nombreDocs += 1

            RaiseEvent UnDocumentEnPlus(d.ToString())

        End Sub
        Public Sub AjouteDocument(ByVal t As String, ByVal f As Revue.Frequence)
            Dim d As Document = New Revue(t, f)

            If nombreDocs > 10 Then
                Throw New TropDeDocumentsException(d)
            End If
            documents(nombreDocs) = d
            nombreDocs += 1

            RaiseEvent UnDocumentEnPlus(d.ToString())

        End Sub

       

        Public ReadOnly Property LesDocs() As Document()
            Get
                Return documents
            End Get

        End Property
    End Class
End Namespace

