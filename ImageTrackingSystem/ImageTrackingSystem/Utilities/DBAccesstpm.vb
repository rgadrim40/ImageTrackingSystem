'-------------------------------------------------------------------------------------------------
'   Author: Richard Gadrim                                  Last Modification:  11/15/2013
'-------------------------------------------------------------------------------------------------
'   Modification Log:
'   
'           09/10/2013: RKG Updated and revised for the new Event Calendar
'=================================================================================================
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Common

Public Class DBAccesstpm

    Protected strError As String
    Protected strConn As String

    Protected objUtil As New Utility()
    '=================================================================================================
    ' Constructors
    '-------------------------------------------------------------------------------------------------
    Public Sub New()
        Me.strConn = Me.objUtil.GetConnectString()
    End Sub

    '=========================================================================================================
    ' get functions
    '=================================================================================================
    ' Retrieves FormData By RowID
    '-------------------------------------------------------------------------------------------------
    Public Function GetUserProfileByRowID(ByVal intLclID As Integer) As BeanUserProfile
        Dim objFormData As New BeanUserProfile()
        Dim strLclSQL As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        strError = ""
        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM UserProfile WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                objFormData = Me.GetUserProfileByID(lclCursor("RowID"))
            Else
                objFormData.RowID = 0
            End If
        Catch ex As Exception
            Me.strError = ex.Message
            objFormData.RowID = 0
        End Try
        strLclCmd.Connection.Close()
        Return objFormData
    End Function

    '=================================================================================================
    ' Get the User Info record for the specified User.  
    '-------------------------------------------------------------------------------------------------
    Public Function GetMediaInfoByUserandType(ByVal strUserParam As String, ByVal strTypeParam As String) As BeanMedia
        Dim objLclUserInfo As New BeanMedia()
        Dim strLclSQL As String = "SELECT RowID FROM Media WHERE Inactive = 0 AND UserName = @User AND MName = @Name"
        Dim objLclCursor As SqlDataReader

        Me.strConn = ConfigurationManager.ConnectionStrings("FormData").ConnectionString
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@User", SqlDbType.VarChar)
                objLclCmd.Parameters("@User").Value = Convert.ToString(strUserParam.Replace("'", "''"))
                objLclCmd.Parameters.Add("@Name", SqlDbType.VarChar)
                objLclCmd.Parameters("@Name").Value = Convert.ToString(strTypeParam.Replace("'", "''"))
                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        objLclCursor.Read()
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclUserInfo = New BeanMedia(GetMediaByID(objLclCursor("RowID")))
                        End If
                    End If
                    objLclCursor.Close()
                Catch ex As SqlException
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclUserInfo
    End Function

    '=========================================================================================================
    ' Retrieve Media Type By RowID
    '-------------------------------------------------------------------------------------------------
    Public Function GetMediaTypeByRowID(ByVal intLclID As Integer) As BeanMediaType
        Dim objFormData As New BeanMediaType()
        Dim strLclSQL As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        strError = ""
        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM MediaType WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                objFormData = Me.GetMediaTypeByID(lclCursor("RowID"))
            Else
                objFormData.RowID = 0
            End If
        Catch ex As Exception
            Me.strError = ex.Message
            objFormData.RowID = 0
        End Try
        strLclCmd.Connection.Close()
        Return objFormData
    End Function

    '=========================================================================================================
    ' Retrieve Media By RowID
    '-------------------------------------------------------------------------------------------------
    Public Function GetMediaByRowID(ByVal intLclID As Integer) As BeanMedia
        Dim objFormData As New BeanMedia()
        Dim strLclSQL As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        strError = ""
        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM Media WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                objFormData = Me.GetMediaByID(lclCursor("RowID"))
            Else
                objFormData.RowID = 0
            End If
        Catch ex As Exception
            Me.strError = ex.Message
            objFormData.RowID = 0
        End Try
        strLclCmd.Connection.Close()
        Return objFormData
    End Function

    '=================================================================================================
    ' Get the User Info record for the specified User.  
    '-------------------------------------------------------------------------------------------------
    Public Function GetUserInfoByUserID(ByVal strUserIDParam As String) As BeanUserProfile
        Dim objLclUserInfo As New BeanUserProfile()
        Dim strLclSQL As String = "SELECT RowID FROM UserProfile WHERE Inactive = 0 AND UserName = @UserID"
        Dim objLclCursor As SqlDataReader

        Me.strConn = ConfigurationManager.ConnectionStrings("FormData").ConnectionString
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@UserID", SqlDbType.VarChar)
                objLclCmd.Parameters("@UserID").Value = Convert.ToString(strUserIDParam.Replace("'", "''"))
                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        objLclCursor.Read()
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclUserInfo = New BeanUserProfile(GetUserProfileByID(objLclCursor("RowID")))
                        End If
                    End If
                    objLclCursor.Close()
                Catch ex As SqlException
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclUserInfo
    End Function

    '=========================================================================================================
    ' get the UserProfile data
    '---------------------------------------------------------------------------------------------------------
    Public Function GetUserProfileByID(ByVal intLclID As Integer) As BeanUserProfile
        Dim objForm As New BeanUserProfile()
        Dim strLclSQL As String
        Dim strTemp As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM UserProfile WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                Try
                    strTemp = lclCursor("RowID")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.RowID = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("FirstName")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.FirstName = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("LastName")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.LastName = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Address1")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Address1 = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Address2")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Address2 = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("City")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.City = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("State")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.State = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Email")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Email = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("UserName")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.UserName = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Inactive")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Inactive = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("InactiveDate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.InactiveDate = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("LastUpdate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.LastUpdate = strTemp
                    End If
                Catch ex As Exception
                End Try
            Else
                strError &= "<br>Error Reading Record with ID " & intLclID
            End If
        Catch ex As Exception
            strError &= "<br>Error Executing Reader with ID " & intLclID
            Me.strError &= ex.Message
        End Try
        strLclCmd.Connection.Close()
        Return objForm
    End Function

    '=========================================================================================================
    ' get the MediaType data
    '---------------------------------------------------------------------------------------------------------
    Public Function GetMediaTypeByID(ByVal intLclID As Integer) As BeanMediaType
        Dim objForm As New BeanMediaType()
        Dim strLclSQL As String
        Dim strTemp As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM MediaType WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                Try
                    strTemp = lclCursor("RowID")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.RowID = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Type")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Type = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Inactive")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Inactive = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("InactiveDate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.InactiveDate = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("LastUpdate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.LastUpdate = strTemp
                    End If
                Catch ex As Exception
                End Try
            Else
                strError &= "<br>Error Reading Record with ID " & intLclID
            End If
        Catch ex As Exception
            strError &= "<br>Error Executing Reader with ID " & intLclID
            Me.strError &= ex.Message
        End Try
        strLclCmd.Connection.Close()
        Return objForm
    End Function

    '=========================================================================================================
    ' get the Media data 
    '---------------------------------------------------------------------------------------------------------
    Public Function GetMediaByID(ByVal intLclID As Integer) As BeanMedia
        Dim objForm As New BeanMedia()
        Dim strLclSQL As String
        Dim strTemp As String
        Dim dataLclConn As SqlConnection
        Dim strLclCmd As SqlCommand
        Dim lclCursor As SqlDataReader

        dataLclConn = New SqlConnection(Me.strConn)
        strLclSQL = "SELECT * FROM Media WHERE RowID = " & intLclID
        strLclCmd = New SqlCommand(strLclSQL, dataLclConn)
        Try
            strLclCmd.Connection.Open()
            lclCursor = strLclCmd.ExecuteReader()
            If lclCursor.HasRows Then
                lclCursor.Read()
                Try
                    strTemp = lclCursor("RowID")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.RowID = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("MType")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.MType = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("MName")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.MName = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("MDescription")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.MDescription = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("MDate")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.MDate = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("UserName")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.UserName = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("Inactive")
                    If Not String.IsNullOrEmpty(strTemp) Then
                        objForm.Inactive = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("InactiveDate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.InactiveDate = strTemp
                    End If
                Catch ex As Exception
                End Try
                Try
                    strTemp = lclCursor("LastUpdate")
                    If IsDate(strTemp) And strTemp <> "12:00:00 AM" Then
                        objForm.LastUpdate = strTemp
                    End If
                Catch ex As Exception
                End Try
            Else
                strError &= "<br>Error Reading Record with ID " & intLclID
            End If
        Catch ex As Exception
            strError &= "<br>Error Executing Reader with ID " & intLclID
            Me.strError &= ex.Message
        End Try
        strLclCmd.Connection.Close()
        Return objForm
    End Function

    '=================================================================================================
    '  Insert Functions
    '-------------------------------------------------------------------------------------------------
    '  Insert a new record into the UserProfile table 
    '-------------------------------------------------------------------------------------------------
    Public Function InsertUserProfile(ByRef objParam As BeanUserProfile) As Integer
        Dim intLclTemp As Integer = 0
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO UserProfile ("
        Dim strLclValues As String = "VALUES ("
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objParam.FirstName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "FirstName"
                        strLclValues &= "@FirstName"
                        objLclCmd.Parameters.Add("@FirstName", SqlDbType.VarChar)
                        objParam.FirstName = objLclSecure.QuickClean(objParam.FirstName, 100)
                        objLclCmd.Parameters("@FirstName").Value = Convert.ToString(objParam.FirstName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.LastName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "LastName"
                        strLclValues &= "@LastName"
                        objLclCmd.Parameters.Add("@LastName", SqlDbType.VarChar)
                        objParam.LastName = objLclSecure.QuickClean(objParam.LastName, 100)
                        objLclCmd.Parameters("@LastName").Value = Convert.ToString(objParam.LastName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Address1.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Address1"
                        strLclValues &= "@Address1"
                        objLclCmd.Parameters.Add("@Address1", SqlDbType.VarChar)
                        objParam.Address1 = objLclSecure.QuickClean(objParam.Address1, 100)
                        objLclCmd.Parameters("@Address1").Value = Convert.ToString(objParam.Address1.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Address2.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Address2"
                        strLclValues &= "@Address2"
                        objLclCmd.Parameters.Add("@Address2", SqlDbType.VarChar)
                        objParam.Address2 = objLclSecure.QuickClean(objParam.Address2, 100)
                        objLclCmd.Parameters("@Address2").Value = Convert.ToString(objParam.Address2.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.City.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "City"
                        strLclValues &= "@City"
                        objLclCmd.Parameters.Add("@City", SqlDbType.VarChar)
                        objParam.City = objLclSecure.QuickClean(objParam.City, 100)
                        objLclCmd.Parameters("@City").Value = Convert.ToString(objParam.City.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.State.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "State"
                        strLclValues &= "@State"
                        objLclCmd.Parameters.Add("@State", SqlDbType.VarChar)
                        objParam.State = objLclSecure.QuickClean(objParam.State, 50)
                        objLclCmd.Parameters("@State").Value = Convert.ToString(objParam.State.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Email.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Email"
                        strLclValues &= "@Email"
                        objLclCmd.Parameters.Add("@Email", SqlDbType.VarChar)
                        objParam.Email = objLclSecure.QuickClean(objParam.Email, 50)
                        objLclCmd.Parameters("@Email").Value = Convert.ToString(objParam.Email.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.UserName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "UserName"
                        strLclValues &= "@UserName"
                        objLclCmd.Parameters.Add("@UserName", SqlDbType.VarChar)
                        objParam.UserName = objLclSecure.QuickClean(objParam.UserName, 50)
                        objLclCmd.Parameters("@UserName").Value = Convert.ToString(objParam.UserName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.InactiveDate) And objParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.LastUpdate) And objParam.LastUpdate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "LastUpdate"
                        strLclValues &= "@LastUpdate"
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    End If
                Catch ex As Exception
                End Try
                strLclSQL &= ")"
                strLclValues &= ")"
                strLclSQL &= strLclValues
                strLclSQL &= "; SELECT RowID FROM UserProfile WHERE RowID = @@IDENTITY"
                Try
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                Catch ex As Exception
                    Me.strError = ex.Message
                    Return intLclRtnCode
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '  Insert a new record into the Media Table 
    '-------------------------------------------------------------------------------------------------
    Public Function InsertMedia(ByRef objParam As BeanMedia) As Integer
        Dim intLclTemp As Integer = 0
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO Media ("
        Dim strLclValues As String = "VALUES ("
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objParam.MType.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "MType"
                        strLclValues &= "@MType"
                        objLclCmd.Parameters.Add("@MType", SqlDbType.VarChar)
                        objParam.MType = objLclSecure.QuickClean(objParam.MType, 60)
                        objLclCmd.Parameters("@MType").Value = Convert.ToString(objParam.MType.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.MName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "MName"
                        strLclValues &= "@MName"
                        objLclCmd.Parameters.Add("@MName", SqlDbType.VarChar)
                        objParam.MName = objLclSecure.QuickClean(objParam.MName, 50)
                        objLclCmd.Parameters("@MName").Value = Convert.ToString(objParam.MName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.MDescription.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "MDescription"
                        strLclValues &= "@MDescription"
                        objLclCmd.Parameters.Add("@MDescription", SqlDbType.VarChar)
                        objParam.MDescription = objLclSecure.QuickClean(objParam.MDescription, 1000)
                        objLclCmd.Parameters("@MDescription").Value = Convert.ToString(objParam.MDescription.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.MDate) And objParam.MDate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "MDate"
                        strLclValues &= "@MDate"
                        objLclCmd.Parameters.Add("@MDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@MDate").Value = Convert.ToDateTime(objParam.MDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.UserName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "UserName"
                        strLclValues &= "@UserName"
                        objLclCmd.Parameters.Add("@UserName", SqlDbType.VarChar)
                        objParam.UserName = objLclSecure.QuickClean(objParam.UserName, 50)
                        objLclCmd.Parameters("@UserName").Value = Convert.ToString(objParam.UserName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.InactiveDate) And objParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.LastUpdate) And objParam.LastUpdate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "LastUpdate"
                        strLclValues &= "@LastUpdate"
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    End If
                Catch ex As Exception
                End Try
                strLclSQL &= ")"
                strLclValues &= ")"
                strLclSQL &= strLclValues
                strLclSQL &= "; SELECT RowID FROM Media WHERE RowID = @@IDENTITY"
                Try
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                Catch ex As Exception
                    Me.strError = ex.Message
                    Return intLclRtnCode
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '  Insert a new record into the MediaType Table 
    '-------------------------------------------------------------------------------------------------
    Public Function InsertMediaType(ByRef objParam As BeanMediaType) As Integer
        Dim intLclTemp As Integer = 0
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO MediaType ("
        Dim strLclValues As String = "VALUES ("
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objParam.Type.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Type"
                        strLclValues &= "@Type"
                        objLclCmd.Parameters.Add("@Type", SqlDbType.VarChar)
                        objParam.Type = objLclSecure.QuickClean(objParam.Type, 60)
                        objLclCmd.Parameters("@Type").Value = Convert.ToString(objParam.Type.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.InactiveDate) And objParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsDate(objParam.LastUpdate) And objParam.LastUpdate <> "12:00:00 AM" Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "LastUpdate"
                        strLclValues &= "@LastUpdate"
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    End If
                Catch ex As Exception
                End Try
                strLclSQL &= ")"
                strLclValues &= ")"
                strLclSQL &= strLclValues
                strLclSQL &= "; SELECT RowID FROM MediaType WHERE RowID = @@IDENTITY"
                Try
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                Catch ex As Exception
                    Me.strError = ex.Message
                    Return intLclRtnCode
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '   Update Functions
    '=================================================================================================
    '   Update information into the FormData 
    '-------------------------------------------------------------------------------------------------
    Public Function UpdateUserProfile(ByVal objParam As BeanUserProfile) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "UPDATE UserProfile SET "
        Dim objLclUserProf As BeanUserProfile
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        objLclUserProf = Me.GetUserProfileByRowID(objParam.RowID)
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If Not String.IsNullOrEmpty(objParam.FirstName) And objParam.FirstName <> objLclUserProf.FirstName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "FirstName = @FirstName"
                        objLclCmd.Parameters.Add("@FirstName", SqlDbType.VarChar)
                        objParam.FirstName = objLclSecure.QuickClean(objParam.FirstName, 100)
                        objLclCmd.Parameters("@FirstName").Value = Convert.ToString(objParam.FirstName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.LastName) And objParam.LastName <> objLclUserProf.LastName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "LastName = @LastName"
                        objLclCmd.Parameters.Add("@LastName", SqlDbType.VarChar)
                        objParam.LastName = objLclSecure.QuickClean(objParam.LastName, 100)
                        objLclCmd.Parameters("@LastName").Value = Convert.ToString(objParam.LastName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.Address1) And objParam.Address1 <> objLclUserProf.Address1 Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Address1 = @Address1"
                        objLclCmd.Parameters.Add("@Address1", SqlDbType.VarChar)
                        objParam.Address1 = objLclSecure.QuickClean(objParam.Address1, 100)
                        objLclCmd.Parameters("@Address1").Value = Convert.ToString(objParam.Address1.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.Address2) And objParam.Address2 <> objLclUserProf.Address2 Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Address2 = @Address2"
                        objLclCmd.Parameters.Add("@Address2", SqlDbType.VarChar)
                        objParam.Address2 = objLclSecure.QuickClean(objParam.Address2, 100)
                        objLclCmd.Parameters("@Address2").Value = Convert.ToString(objParam.Address2.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.City) And objParam.City <> objLclUserProf.City Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "City = @City"
                        objLclCmd.Parameters.Add("@City", SqlDbType.VarChar)
                        objParam.City = objLclSecure.QuickClean(objParam.City, 100)
                        objLclCmd.Parameters("@City").Value = Convert.ToString(objParam.City.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.State) And objParam.State <> objLclUserProf.State Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "State = @State"
                        objLclCmd.Parameters.Add("@State", SqlDbType.VarChar)
                        objParam.State = objLclSecure.QuickClean(objParam.State, 50)
                        objLclCmd.Parameters("@State").Value = Convert.ToString(objParam.State.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.Email) And objParam.Email <> objLclUserProf.Email Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Email = @Email"
                        objLclCmd.Parameters.Add("@Email", SqlDbType.VarChar)
                        objParam.Email = objLclSecure.QuickClean(objParam.Email, 50)
                        objLclCmd.Parameters("@Email").Value = Convert.ToString(objParam.Email.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.UserName) And objParam.UserName <> objLclUserProf.UserName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "UserName = @UserName"
                        objLclCmd.Parameters.Add("@UserName", SqlDbType.VarChar)
                        objParam.UserName = objLclSecure.QuickClean(objParam.UserName, 50)
                        objLclCmd.Parameters("@UserName").Value = Convert.ToString(objParam.UserName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive <> objLclUserProf.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.InactiveDate <> "12:00:00 AM" And objParam.InactiveDate <> objLclUserProf.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    Try
                        If objParam.LastUpdate <> objLclUserProf.LastUpdate Then
                            strLclSQL &= ", LastUpdate = @LastUpdate"
                            objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                            objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        End If
                    Catch ex As Exception
                    End Try
                    strLclSQL &= " WHERE RowID = @RowID "
                    objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                    objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objParam.RowID)
                    Try
                        objLclCmd.CommandText = strLclSQL
                        intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                    Catch ex As Exception
                        Me.strError = ex.Message
                    End Try
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '   Update information into the Media table 
    '-------------------------------------------------------------------------------------------------
    Public Function UpdateMedia(ByVal objParam As BeanMedia) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "UPDATE Media SET "
        Dim objLclUserProf As BeanMedia
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        objLclUserProf = Me.GetMediaByRowID(objParam.RowID)
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If Not String.IsNullOrEmpty(objParam.MType) And objParam.MType <> objLclUserProf.MType Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "MType = @MType"
                        objLclCmd.Parameters.Add("@MType", SqlDbType.VarChar)
                        objParam.MType = objLclSecure.QuickClean(objParam.MType, 60)
                        objLclCmd.Parameters("@MType").Value = Convert.ToString(objParam.MType.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.MName) And objParam.MName <> objLclUserProf.MName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "MName = @MName"
                        objLclCmd.Parameters.Add("@MName", SqlDbType.VarChar)
                        objParam.MName = objLclSecure.QuickClean(objParam.MName, 60)
                        objLclCmd.Parameters("@MName").Value = Convert.ToString(objParam.MName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.MDescription) And objParam.MDescription <> objLclUserProf.MDescription Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "MDescription = @MDescription"
                        objLclCmd.Parameters.Add("@MDescription", SqlDbType.VarChar)
                        objParam.MDescription = objLclSecure.QuickClean(objParam.MDescription, 1000)
                        objLclCmd.Parameters("@MDescription").Value = Convert.ToString(objParam.MDescription.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.MDate <> "12:00:00 AM" And objParam.MDate <> objLclUserProf.MDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "MDate = @MDate"
                        objLclCmd.Parameters.Add("@MDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@MDate").Value = Convert.ToDateTime(objParam.MDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objParam.UserName) And objParam.UserName <> objLclUserProf.UserName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "UserName = @UserName"
                        objLclCmd.Parameters.Add("@UserName", SqlDbType.VarChar)
                        objParam.UserName = objLclSecure.QuickClean(objParam.UserName, 60)
                        objLclCmd.Parameters("@UserName").Value = Convert.ToString(objParam.UserName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive <> objLclUserProf.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.InactiveDate <> "12:00:00 AM" And objParam.InactiveDate <> objLclUserProf.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    Try
                        If objParam.LastUpdate <> objLclUserProf.LastUpdate Then
                            strLclSQL &= ", LastUpdate = @LastUpdate"
                            objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                            objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        End If
                    Catch ex As Exception
                    End Try
                    strLclSQL &= " WHERE RowID = @RowID "
                    objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                    objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objParam.RowID)
                    Try
                        objLclCmd.CommandText = strLclSQL
                        intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                    Catch ex As Exception
                        Me.strError = ex.Message
                    End Try
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '=================================================================================================
    '   Update information into the Media table 
    '-------------------------------------------------------------------------------------------------
    Public Function UpdateMediaType(ByVal objParam As BeanMediaType) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "UPDATE MediaType SET "
        Dim objLclUserProf As BeanMediaType
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        objLclUserProf = Me.GetMediaTypeByRowID(objParam.RowID)
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If Not String.IsNullOrEmpty(objParam.Type) And objParam.Type <> objLclUserProf.Type Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Type = @Type"
                        objLclCmd.Parameters.Add("@Type", SqlDbType.VarChar)
                        objParam.Type = objLclSecure.QuickClean(objParam.Type, 60)
                        objLclCmd.Parameters("@Type").Value = Convert.ToString(objParam.Type.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.Inactive <> objLclUserProf.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objParam.InactiveDate <> "12:00:00 AM" And objParam.InactiveDate <> objLclUserProf.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    Try
                        If objParam.LastUpdate <> objLclUserProf.LastUpdate Then
                            strLclSQL &= ", LastUpdate = @LastUpdate"
                            objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                            objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        End If
                    Catch ex As Exception
                    End Try
                    strLclSQL &= " WHERE RowID = @RowID "
                    objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                    objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objParam.RowID)
                    Try
                        objLclCmd.CommandText = strLclSQL
                        intLclRtnCode = CInt(objLclCmd.ExecuteNonQuery())
                    Catch ex As Exception
                        Me.strError = ex.Message
                    End Try
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function
End Class
