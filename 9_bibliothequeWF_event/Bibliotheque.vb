Namespace Biblio



    Public Class Bibliotheque
        Private nom As String
        Private documents(100) As Document
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

        Public Sub AjouteDocument(ByVal t As String, ByVal a As String)
            Dim d As Document = New Document(t, a)
            documents(nombreDocs) = d
            nombreDocs += 1

            RaiseEvent UnDocumentEnPlus(d.Print())

        End Sub

        Public Function Print() As String
            Dim ret As String = "Je suis la bibliothèque " & nom & " je contiens " & nombreDocs.ToString() & " documents"

            For i As Integer = 0 To nombreDocs - 1
                ret = ret & documents(i).Print() & vbCr
            Next

            Return ret
        End Function

        Public ReadOnly Property LesDocs() As Document()
            Get
                Return documents
            End Get

        End Property
    End Class
End Namespace

