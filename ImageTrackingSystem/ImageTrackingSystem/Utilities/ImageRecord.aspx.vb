'=================================================================================================
'-------------------------------------------------------------------------------------------------
'   Author: Richard K Gadrim        Begun:  2/18/2015         Last Modification:  
'-------------------------------------------------------------------------------------------------
'   Modification Log:
'=================================================================================================
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports techpromediainc.com

Partial Class Utilities_ImageRecord
    Inherits System.Web.UI.Page

    Protected intEmpID As Integer
    Protected intImageID As Integer

    Protected strCounty As String
    Protected strUser As String
    Protected strSiteDDL As String
    Protected strRoomDDL As String

    Protected objAssetImgDB As DBAccessImg
    Protected objUtil As New Utility()
    Protected objSecure As New clsSecurity()

    '=================================================================================================
    ' Perform pre-initialization functions. Get User & County and set Page Theme.
    '-------------------------------------------------------------------------------------------------
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        Me.strUser = Me.objUtil.StripDomain(Context.User.Identity.Name)
        If Not String.IsNullOrEmpty(Me.strUser) Then
            Me.strUser = Me.objSecure.QuickClean(Me.strUser, 50)
        End If

        Me.objAssetImgDB = New DBAccessImg()
    End Sub

    '=================================================================================================
    ' Initialize page by gathering Session & Querystring variables.
    '-------------------------------------------------------------------------------------------------
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim strLclTemp As String

        Try
            Me.lblCaption.Text = "Image Tracking System"
            Me.lblGreet.Text &= Me.strUser
        Catch ex As Exception
        End Try
        strLclTemp = Request.QueryString("RowID")
        If Not String.IsNullOrEmpty(strLclTemp) Then
            Try
                If IsNumeric(strLclTemp) And CInt(strLclTemp) Then
                    Me.intImageID = CInt(strLclTemp)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    '=================================================================================================
    ' Control the overall processing of the application.
    '-------------------------------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Me.strSiteDDL = Me.GetSiteList()
        End If
    End Sub

    '=================================================================================================
    ' Get a ddl string of all active Users in the database.
    '-------------------------------------------------------------------------------------------------
    Private Function GetSiteList() As String
        Dim strLclList As String = ""
        Return strLclList
    End Function
End Class
