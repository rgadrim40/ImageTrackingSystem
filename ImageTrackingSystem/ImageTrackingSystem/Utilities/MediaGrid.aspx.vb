Public Class MediaGrid
    Inherits System.Web.UI.Page

    Protected strUserSecur As String
    Protected strUser As String
    Protected strTemp As String
    Protected strConn As String
    Protected strBool As Boolean
    Protected strError As String = "Error retrieving data"

    Protected strUserMember As String
    Protected objMedia As BeanMedia
    Protected objUser As BeanUserProfile
    Protected objDb As DBAccesstpm
    Protected objUtil As New Utility()
    Protected objSecure As New clsSecurity()

    '=================================================================================================
    ' initialize content before page load.
    '-------------------------------------------------------------------------------------------------
    Private Sub MediaGrid_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.objMedia = New BeanMedia()
        Me.objUser = New BeanUserProfile()
        Me.objDb = New DBAccesstpm()

        Me.strUserSecur = Me.objSecure.QuickClean(Me.objUtil.StripDomain(Context.User.Identity.Name), 50)
        Me.strUser = Me.strUserSecur
        Me.lclUserName.Text = Me.strUser
        Me.hiddenUser.Value = Me.strUser
        Me.strBool = False
        Me.strConn = Me.objUtil.GetConnectString()
        Me.SqlDataMedia.ConnectionString = Me.strConn
        Me.SqlDataMediaName.ConnectionString = Me.strConn
        Me.SqlDataType.ConnectionString = Me.strConn
        Me.SqlDataForm.ConnectionString = Me.strConn
        Me.SqlDataForm.SelectCommand = "SELECT UserName, MType, MName, MDescription, MDate FROM Media"
        Me.SqlDataMediaName.SelectCommand = "SELECT MName, RowID FROM Media"
        Me.SqlDataType.SelectCommand = "SELECT RowID, Type, Inactive FROM MediaType"
        Me.SqlDataMedia.SelectCommand = "SELECT * FROM Media WHERE UserName = @UserName"
        Me.SqlDataMedia.DeleteCommand = "UPDATE Media SET Inactive = 1, InactiveDate = getdate(), LastUpdate = getdate() WHERE RowID = @RowID"
        Me.SqlDataMedia.UpdateCommand = "UPDATE Media SET UserName = @UserName, MType = @MType, MName = @MName, MDescription = @MDescription, MDate = @MDate, Inactive = @Inactive, LastUpdate = getdate() WHERE RowID = @RowID"
        Me.SqlDataInactive.SelectCommand = "SELECT Inactive, RowID FROM Media"
    End Sub

    '=================================================================================================
    ' initialize content
    '-------------------------------------------------------------------------------------------------
    Private Sub MediaGrid_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Dim objLclItem As ListItem
        Try
            If Not IsPostBack() Then
                objLclItem = New ListItem("--Select--", "")
                Me.ddlType.Items.Add(objLclItem)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '=================================================================================================
    ' Load Page
    '-------------------------------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.lblMessage.Text = "The Grid is for keeping track of media. With the ability to Edit and Delete, When Deleting A media the media will be set to Inactive for future use!"
        End If
    End Sub

    '=================================================================================================
    ' Determineds the select command for the sort capability (Inactive).
    '-------------------------------------------------------------------------------------------------
    Protected Sub ddlInactive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInactive.SelectedIndexChanged
        If IsPostBack Then
            Me.strTemp = Me.ddlInactive.SelectedValue
            If Me.strTemp = "false" Then
                Me.SqlDataMedia.SelectCommand = "SELECT * FROM Media WHERE Inactive = 0, UserName = @UserName"
            ElseIf Me.strTemp = "true" Then
                Me.SqlDataMedia.SelectCommand = "SELECT * FROM Media WHERE Inactive = 1, UserName = @UserName"
            ElseIf Me.strTemp = "all" Then
                Me.SqlDataMedia.SelectCommand = "SELECT * FROM Media WHERE UserName = @UserName"
            End If
        End If
    End Sub

    '=================================================================================================
    ' Review record.
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnReview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strRowID As String = TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).Cells(1).Text
        Dim intRowID As Integer = Convert.ToInt32(strRowID)
        Me.objMedia = New BeanMedia(Me.objDb.GetMediaByID(intRowID))
        Try
            Me.reviewUser.Text = Me.objMedia.UserName
            Me.reviewType.Text = Me.objMedia.MType
            Me.reviewName.Text = Me.objMedia.MName
            Me.reviewDescript.Text = Me.objMedia.MDescription
            Me.reviewDate.Text = Me.objMedia.MDate
            If Me.objMedia.Inactive = False Then
                Me.reviewInactive.Checked = False
            Else
                Me.reviewInactive.Checked = True
            End If
        Catch ex As Exception
        End Try
        Me.reviewPnl.Visible = True
        Me.editPnl.Visible = False
        Me.lblMessage.Text = "The form is for review only!"
    End Sub

    '=================================================================================================
    ' Edit record.
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strRowID As String = TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).Cells(1).Text
        Dim intRowID As Integer = Convert.ToInt32(strRowID)
        Me.hiddenRowID.Value = strRowID
        Me.objMedia = New BeanMedia(Me.objDb.GetMediaByID(intRowID))
        Try
            Me.editUserName.Text = Me.objMedia.UserName
            Me.editDDlType.Text = Me.objMedia.MType
            Me.editName.Text = Me.objMedia.MName
            Me.editDescript.Text = Me.objMedia.MDescription
            Me.editDate.Text = Me.objMedia.MDate
            If Me.objMedia.Inactive = False Then
                Me.editInactive.Checked = False
            Else
                Me.editInactive.Checked = True
            End If
        Catch ex As Exception
        End Try
        Me.editPnl.Visible = True
        Me.reviewPnl.Visible = False
        Me.lblMessage.Text = "The form is for editing the selected record!"
    End Sub

    '=================================================================================================
    ' Saves new record into database and then redirects after a set amount of time.
    '-------------------------------------------------------------------------------------------------
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnSave2.Click
        Dim strRowID As String

        If Not String.IsNullOrEmpty(Me.hiddenRowID.Value) Then
            strRowID = Convert.ToSingle(Me.hiddenRowID.Value.TrimStart())
            StoreUserRecord(strRowID)
            GridView1.DataBind()
        Else
            strRowID = 0
            StoreUserRecord(strRowID)
            GridView1.DataBind()
        End If
    End Sub

    '=================================================================================================
    ' stores record into database.
    '-------------------------------------------------------------------------------------------------
    Private Sub StoreUserRecord(ByVal strRowIDParam As String)
        Dim intLclRtnCode As Integer
        Dim objLclDemog As New BeanMedia
        Dim intRowID As Integer = 0
        intRowID = Convert.ToInt32(strRowIDParam)

        Me.objMedia = New BeanMedia(Me.objDb.GetMediaByID(intRowID))
        If Me.objMedia.RowID > 0 Then
            Me.strBool = True
            intLclRtnCode = Me.GetFormValues(objLclDemog, Me.strBool)
            If intLclRtnCode = 0 Then
                Try
                    objLclDemog.RowID = Me.hiddenRowID.Value
                    intLclRtnCode = Me.objDb.UpdateMedia(objLclDemog)
                Catch ex As Exception
                    Me.lblError.Text = Me.strError
                End Try
                If String.IsNullOrEmpty(intLclRtnCode) Then
                    Me.strError = "Error storing data"
                    Me.lblError.Text = Me.strError
                    Me.ErrorPnl.Visible = True
                Else
                    Me.lblMessage.Text = "The Record has been stored!"
                    Me.MessagePnl.Visible = True
                End If
                Me.editPnl.Visible = False
            End If
        Else
            Me.strBool = False
            intLclRtnCode = Me.GetFormValues(objLclDemog, Me.strBool)
            If intLclRtnCode = 0 Then
                Try
                    intLclRtnCode = Me.objDb.InsertMedia(objLclDemog)
                Catch ex As Exception
                    Me.lblError.Text = Me.strError
                End Try
                If String.IsNullOrEmpty(intLclRtnCode) Then
                    Me.strError = "Error storing data"
                    Me.lblError.Text = Me.strError
                    Me.ErrorPnl.Visible = True
                Else
                    Me.lblMessage.Text = "The Record has been stored!"
                    Me.MessagePnl.Visible = True
                End If
            Else
                Me.strError = "Error storing data"
                Me.lblError.Text = Me.strError
                Me.ErrorPnl.Visible = True
            End If
            Me.lclDescription.Text = ""
            Me.lclMediaDate.Text = ""
            Me.lclMediaName.Text = ""
            Me.ddlType.SelectedIndex = 0
        End If
    End Sub

    '=================================================================================================
    ' gets the data from the form
    '-------------------------------------------------------------------------------------------------
    Protected Function GetFormValues(ByRef objUserParam As BeanMedia, ByVal strBoolParam As Boolean) As Integer
        Dim intLclRtnCode As Integer = 0

        If strBoolParam = False Then
            Try
                Me.strTemp = Me.ddlType.SelectedValue
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MType = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.lclMediaName.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MName = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.lclDescription.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MDescription = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.lclMediaDate.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MDate = Me.strTemp.Trim()
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
        Else
            Try
                Me.strTemp = Me.editDDlType.SelectedValue
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MType = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.editName.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MName = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.editDescript.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MDescription = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.editDate.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.MDate = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try
            Try
                Me.strTemp = Me.editUserName.Text
                If Not String.IsNullOrEmpty(Me.strTemp.Trim()) Then
                    objUserParam.UserName = Me.strTemp.Trim()
                End If
            Catch ex As Exception
            End Try

        End If
        Return intLclRtnCode
    End Function

    Protected Sub SqlDataMedia_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs)
        e.Command.Parameters("@UserName").Value = Me.strUser 'Context.User.Identity.Name
    End Sub
End Class