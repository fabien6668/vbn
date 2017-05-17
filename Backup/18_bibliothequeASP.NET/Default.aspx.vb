Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            DropDownList1.DataSource = _17_bibliothequeADO.NET_DLL.BibliothequeDAO.GetAllIndexes()
            DropDownList1.DataBind()
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim selec As String = DropDownList1.SelectedItem.ToString()

        ListBox1.DataSource = _17_bibliothequeADO.NET_DLL.BibliothequeDAO.GetAllDocumentsForIndex(selec)
        ListBox1.DataValueField = "LeTitre"
        ListBox1.DataBind()
    End Sub
End Class