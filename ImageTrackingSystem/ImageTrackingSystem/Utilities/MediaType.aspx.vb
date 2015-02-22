Imports System.Data

Public Class MediaType
    Inherits System.Web.UI.Page

    Protected strUserSecur As String
    Protected strUser As String
    Protected strTemp As String
    Protected strConn As String
    Protected strError As String = "Error retrieving data"

    Protected strUserMember As String
    Protected objMedia As BeanMedia
    Protected objUser As BeanUserProfile
    Protected objDb As DBAccesstpm
    Protected objUtil As New Utility()
    Protected objSecure As New clsSecurity()

    Private Sub MediaType_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.objMedia = New BeanMedia()
        Me.objUser = New BeanUserProfile()
        Me.objDb = New DBAccesstpm()
        Me.lblMessage.Text = "The Grid is for keeping track of the different types of media. With the ability to Edit and Delete, When Deleting A type the type will be set to Inactive for future use!"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    '=================================================================================================
    ' Saves new record into database and then redirects after a set amount of time.
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsPostBack() Then
            StoreUserRecord()
            If Me.ErrorPnl.Visible = False Then
                Response.AddHeader("REFRESH", "4;URL=../Utilities/MediaType.aspx")
            End If
        End If
    End Sub

    '=================================================================================================
    ' stores record into database.
    '-------------------------------------------------------------------------------------------------
    Private Sub StoreUserRecord()
        Dim intLclRtnCode As Integer
        Dim objLclDemog As New BeanMediaType

        intLclRtnCode = Me.GetFormValues(objLclDemog)
        If intLclRtnCode = 0 Then
            Try
                intLclRtnCode = Me.objDb.InsertMediaType(objLclDemog)
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
        Else
            Me.strError = "Error storing data"
            Me.lblError.Text = Me.strError
            Me.ErrorPnl.Visible = True
        End If
    End Sub

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Protected Function GetFormValues(ByRef objTypeParam As BeanMediaType) As Integer
        Dim intLclRtnCode As Integer = 0

        Try
            Me.strTemp = Me.lclType.Text
            If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                objTypeParam.Type = Me.strTemp.Trim()
            End If
        Catch ex As Exception
        End Try
        Return intLclRtnCode
    End Function
End Class