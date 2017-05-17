Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Integer
        If Integer.TryParse(TextBox1.Text, a) Then
            Dim b As Integer
            If Integer.TryParse(TextBox2.Text, b) Then

                Echange(a, b)

                TextBox1.Text = a.ToString()
                TextBox2.Text = b.ToString()

            End If
        End If
    End Sub

    Sub Echange(ByRef i As Integer, ByRef j As Integer)
        Dim tmp As Integer = i
        i = j
        j = tmp
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As Integer
        If Integer.TryParse(TextBox3.Text, a) Then
            Dim b As Integer
            If Integer.TryParse(TextBox4.Text, b) Then

                Dim r = SommePair(1, 50)

                TextBox5.Text = r.ToString()
            End If
        End If

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim t() As Integer = {1, 2, 3, 6, 8, 9, 13, 16, 17, 18, 20}


        Dim q = SommePair(t)


        TextBox6.Text = q.ToString()
    End Sub

    Function SommePair(ByVal tab() As Integer) As Integer
        Dim s As Integer

        For i As Integer = 0 To tab.Count - 1
            If (tab(i) Mod 2) = 0 Then
                s += tab(i)
            End If
        Next


        Return s
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox7.Text = "{1, 2, 3, 6, 8, 9, 13, 16, 17, 18, 20}"
    End Sub
End Class
