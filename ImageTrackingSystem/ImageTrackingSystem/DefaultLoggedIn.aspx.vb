Public Class DefaultLoggedIn
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Context.User.Identity.IsAuthenticated Then
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class