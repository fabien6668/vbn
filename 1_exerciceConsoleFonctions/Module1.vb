Module Module1

    Sub Main()
        Dim a As Integer = 1
        Dim b As Integer = 2
        Console.WriteLine("Avant échange : {0} - {1}", a, b)
        Echange(a, b)
        Console.WriteLine("Après échange : {0} - {1}", a, b)


        Dim r = SommePair(1, 50)
        Console.WriteLine("Somme des nombres pairs de 1 à 50 : {0}", r)

        Dim t() As Integer = {1, 2, 3, 6, 8, 9, 13, 16, 17, 18, 20}
        Dim q = SommePair(t)
        Console.WriteLine("Somme des nombres pairs d'un tableau: {0}", q)

    End Sub

    Sub Echange(ByRef i As Integer, ByRef j As Integer)
        Dim tmp As Integer = i
        i = j
        j = tmp
    End Sub

    Function SommePair(ByVal i As Integer, ByVal f As Integer) As Integer
        Dim s As Integer = 0

        For a As Integer = i To f
            If (a Mod 2) = 0 Then
                s += a
            End If
        Next

        Return s
    End Function

    Function SommePair(ByVal tab() As Integer) As Integer
        Dim s As Integer

        For i As Integer = 0 To tab.Count - 1
            If (tab(i) Mod 2) = 0 Then
                s += tab(i)
            End If
        Next


        Return s
    End Function

End Module
