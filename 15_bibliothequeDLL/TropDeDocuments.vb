﻿Namespace Biblio
    Public Class TropDeDocumentsException
        Inherits Exception

        Private doc As Object

        Public Sub New(ByRef d As Object)
            doc = d
        End Sub

        Public Function Affiche() As String
            Return doc.ToString() & " ne peut pas être ajouté "
        End Function
    End Class
End Namespace
