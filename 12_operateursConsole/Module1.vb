Module Module1

    Sub Main()
        Dim a As Complexe = New Complexe With {.Reel = 1, .Img = 2}
        Dim b As Complexe = New Complexe With {.Reel = 4, .Img = 6}
        Dim c As Complexe = New Complexe With {.Reel = 4, .Img = 5}

        Dim d = a + b
        Console.WriteLine(d)

        Dim e = c - d
        Console.WriteLine(e)

        Dim f = b / 2
        Console.WriteLine(f)

        Dim g As Complexe = 4
        Console.WriteLine(g)

        Dim i As Integer = CInt(g)
        Console.WriteLine(i)

    End Sub

End Module
