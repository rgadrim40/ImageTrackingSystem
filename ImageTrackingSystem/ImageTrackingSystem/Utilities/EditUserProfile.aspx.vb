Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports techpromediainc.com

Public Class EditUserProfile
    Inherits System.Web.UI.Page

    Protected strUserSecur As String
    Protected strUser As String
    Protected strTemp As String
    Protected strConn As String
    Protected strError As String = "Error retrieving data"

    Protected strUserMember As MembershipUser
    Protected objUser As BeanUserProfile
    Protected objDb As DBAccesstpm
    Protected objUtil As New Utility()
    Protected objSecure As New clsSecurity()

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Private Sub EditUserProfile_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Me.strUser = Membership.GetUser(Context.User.Identity.Name)
        Me.strUserSecur = Me.objSecure.QuickClean(Me.objUtil.StripDomain(Context.User.Identity.Name), 50)
        Me.strUser = Me.strUserSecur
        Me.objDb = New DBAccesstpm()
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                SetFormValues()
            Catch ex As Exception
                Me.lblError.Text = Me.strError
            End Try
        End If
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Sub SetFormValues()

        Me.objUser = New BeanUserProfile(Me.objDb.GetUserInfoByUserID(Me.strUser))
        If Me.objUser.RowID > 0 Then
            Try
                Me.btnSave.Text = "Update"
                Me.hiddenRowID.Value = Me.objUser.RowID
                Me.lclFirstName.Text = Me.objUser.FirstName
                Me.lclLastName.Text = Me.objUser.LastName
                Me.lclAddress1.Text = Me.objUser.Address1
                Me.lclAddress2.Text = Me.objUser.Address2
                Me.lclCity.Text = Me.objUser.City
                Me.lclState.Text = Me.objUser.State
                Me.lclEmail.Text = Me.objUser.Email
                Me.lclUserName.Text = Me.objUser.UserName
            Catch ex As Exception
            End Try
        Else
            Me.btnSave.Text = "Submit"
            Me.strUserMember = Membership.GetUser(Context.User.Identity.Name)
            Me.lclEmail.Text = Me.strUserMember.Email
            Me.lblMessage.Text = "<b>User must enter information!</b>"
            Me.MessagePnl.Visible = True
        End If
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsPostBack() Then
            StoreUserRecord()
            If Me.ErrorPnl.Visible = False Then
                Response.AddHeader("REFRESH", "4;URL=../DefaultLoggedIn.aspx")
            End If
        End If
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Private Sub StoreUserRecord()
        Dim intLclRtnCode As Integer
        Dim objLclDemog As New BeanUserProfile

        Me.objUser = New BeanUserProfile(Me.objDb.GetUserInfoByUserID(Me.strUser))
        If Me.objUser.RowID > 0 Then
            intLclRtnCode = Me.GetFormValues(objLclDemog)
            If intLclRtnCode = 0 Then
                Try
                    objLclDemog.RowID = Me.hiddenRowID.Value
                    intLclRtnCode = Me.objDb.UpdateUserProfile(objLclDemog)
                Catch ex As Exception
                    Me.lblError.Text = Me.strError
                End Try
                If String.IsNullOrEmpty(intLclRtnCode) Then
                    Me.strError = "Error storing data"
                    Me.lblError.Text = Me.strError
                    Me.ErrorPnl.Visible = True
                Else
                    Me.lblMessage.Text = "Data Stored <br />You will be now be <br />redirected!"
                    Me.MessagePnl.Visible = True
                End If
            End If
        Else
            intLclRtnCode = Me.GetFormValues(objLclDemog)
            If intLclRtnCode = 0 Then
                Try
                    intLclRtnCode = Me.objDb.InsertUserProfile(objLclDemog)
                Catch ex As Exception
                    Me.lblError.Text = Me.strError
                End Try
                If String.IsNullOrEmpty(intLclRtnCode) Then
                    Me.strError = "Error storing data"
                    Me.lblError.Text = Me.strError
                    Me.ErrorPnl.Visible = True
                Else
                    Me.lblMessage.Text = "Data Stored <br />You will be now be <br />redirected!"
                    Me.MessagePnl.Visible = True
                End If
            End If
        End If
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Function GetFormValues(ByRef objUserParam As BeanUserProfile) As Integer
        Dim intLclRtnCode As Integer = 0

        Try
            Me.strTemp = Me.lclFirstName.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.FirstName = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclLastName.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.LastName = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclAddress1.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.Address1 = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclAddress2.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.Address2 = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclCity.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.City = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclState.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.State = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclEmail.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.Email = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            Me.strTemp = Me.lclUserName.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objUserParam.UserName = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Try
            objUserParam.UserName = Context.User.Identity.Name
        Catch ex As Exception
        End Try
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/DefaultLoggedIn.aspx")
    End Sub
End Class