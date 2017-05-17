Namespace Biblio

    Public Class Bibliotheque
        Private nom As String
        Private documents As List(Of Document) = New List(Of Document)
        Private indexes As Dictionary(Of String, List(Of Document)) = New Dictionary(Of String, List(Of Document))()

        Public Event UnDocumentEnPlus(ByVal s As String)

        Public Sub New(ByVal s As String)
            nom = s

        End Sub

        Public ReadOnly Property LeNom() As String
            Get
                Return nom
            End Get
        End Property

        Public ReadOnly Property LesIndex() As IEnumerable(Of String)
            Get
                Return indexes.Keys
            End Get
        End Property

        Public Sub AjouteDocument(ByVal ind As String, ByVal t As String, ByVal a As String, ByVal e As String, ByVal p As Integer)
            Dim d As Document = New Livre(t, a, e, p)

            If documents.Count > 10 Then
                Throw New TropDeDocumentsException(d)
            End If


            documents.Add(d)

            AjouteIndex(ind, d)

            RaiseEvent UnDocumentEnPlus(d.ToString())

        End Sub
        Public Sub AjouteDocument(ByVal ind As String, ByVal t As String, ByVal f As Revue.Frequence)
            Dim d As Document = New Revue(t, f)

            If documents.Count > 10 Then
                Throw New TropDeDocumentsException(d)
            End If


            documents.Add(d)
            AjouteIndex(ind, d)

            RaiseEvent UnDocumentEnPlus(d.ToString())

        End Sub

        Public ReadOnly Property LesDocs() As IEnumerable
            Get
                Return documents
            End Get

        End Property

        Public ReadOnly Property LesDocsParIndex(ByVal s As String) As IEnumerable
            Get
                Return indexes(s)
            End Get

        End Property

        Private Sub AjouteIndex(ByVal ind As String, ByVal d As Document)

            If indexes.ContainsKey(ind) Then
                Dim laliste As List(Of Document) = indexes(ind)
                laliste.Add(d)
            Else
                Dim laliste As List(Of Document) = New List(Of Document)
                indexes.Add(ind, laliste)
                laliste.Add(d)
            End If
        End Sub

    End Class
End Namespace

