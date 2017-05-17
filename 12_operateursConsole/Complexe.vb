Public Class Complexe

    Public Property Reel() As Integer
    Public Property Img() As Integer


    Public Overrides Function ToString() As String
        Return "[ " & Reel & " , " & Img & " ]"
    End Function

    Public Shared Operator +(ByVal c1 As Complexe, ByVal c2 As Complexe) As Complexe
        Return New Complexe With {.Reel = c1.Reel + c2.Reel, .Img = c1.Img + c2.Img}
    End Operator

    Public Shared Operator -(ByVal c1 As Complexe, ByVal c2 As Complexe) As Complexe
        Return New Complexe With {.Reel = c1.Reel - c2.Reel, .Img = c1.Img - c2.Img}
    End Operator

    Public Shared Operator /(ByVal c1 As Complexe, ByVal i As Integer) As Complexe
        Return New Complexe With {.Reel = CType(c1.Reel / i, Integer), .Img = CType(c1.Img / i, Integer)}
    End Operator

    Public Shared Narrowing Operator CType(ByVal c As Complexe) As Integer
        Return c.Reel
    End Operator

    Public Shared Widening Operator CType(ByVal i As Integer) As Complexe
        Return New Complexe With {.Reel = i}
    End Operator
End Class
