﻿'	========================================================================================================
'   Data Access functions for Computer Imaging Checklist system.                                                 
'	--------------------------------------------------------------------------------------------------------
'	Author:	Richard Gadrim			begun:	06/28/2014		last modification: 07/28/2014		
'                                       
'	========================================================================================================
'	Modification Log: 07/28/2014 RKG Utilizing existing codefor functionality
'
'-----------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports techpromediainc.com


Public Class DBAccessImg
    Protected strError As String
    Protected strConn As String
    Protected objUtil As New ImgUtil()
    Protected objSecure As New clsSecurity()

    '========================================================================================================
    '--------------------------------------------------------------------------------------------------------
    Public Sub New()
        Me.strConn = ""
    End Sub
    Public Sub New(ByVal strCntyParam As String)
        Me.strConn = Me.objUtil.GetConnectString()
    End Sub

    '=========================================================================================================
    ' Return an error message, which may be set by other functions in the class.
    '---------------------------------------------------------------------------------------------------------
    Public Function GetError() As String
        Return Me.strError
    End Function
    Public Sub ClearError()
        Me.strError = ""
    End Sub


    '========================================================================================================
    ' Retrieve an Image Detail record based on the Row ID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetDetailByID(ByVal intDetailParam As Integer) As BeanImgDetail
        Dim strLclSQL As String = "SELECT * FROM ImgDetail WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclImageDetail As New BeanImgDetail()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intDetailParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclImageDetail.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ImgID")) Then
                            objLclImageDetail.ImgID = objLclCursor("ImgID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ItemID")) Then
                            objLclImageDetail.ItemID = objLclCursor("ItemID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ItemName")) Then
                            objLclImageDetail.ItemName = objLclCursor("ItemName")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Status")) Then
                            objLclImageDetail.Status = objLclCursor("Status")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclImageDetail.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclImageDetail.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclImageDetail.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclImageDetail.UpdEmpName = objLclCursor("UpdEmpName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImageDetail
    End Function

    '========================================================================================================
    ' Retrieve an Imaging record based on the RowID.
    ' 
    '--------------------------------------------------------------------------------------------------------
    Public Function GetCompIDByID(ByVal intRowIDParam As Integer) As BeanCompID
        Dim strLclSQL As String = "SELECT * FROM CompID WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclCompID As New BeanCompID()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intRowIDParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclCompID.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("AssetID")) Then
                            objLclCompID.AssetID = objLclCursor("AssetID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("CompName")) Then
                            objLclCompID.CompName = objLclCursor("CompName")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclCompID.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclCompID.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclCompID.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclCompID.UpdEmpName = objLclCursor("UpdEmpName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclCompID
    End Function

    '========================================================================================================
    ' 
    '--------------------------------------------------------------------------------------------------------
    Public Function GetCompIDByAssetID(ByVal strAssetIDParam As String) As BeanCompID
        Dim objLclCompID As New BeanCompID()
        Dim strLclSQL As String
        Dim objLclCursor As SqlDataReader

        strLclSQL = "SELECT RowID FROM CompID WHERE AssetID = @AssetID "
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@AssetID", SqlDbType.VarChar)
                objLclCmd.Parameters("@AssetID").Value = Convert.ToString(strAssetIDParam)

                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        objLclCursor.Read()
                        Try
                            If Not IsDBNull(objLclCursor("RowID")) Then
                                objLclCompID = New BeanCompID(GetCompIDByID(objLclCursor("RowID")))
                            End If
                        Catch ex2 As Exception
                        End Try
                    End If
                    objLclCursor.Close()
                Catch ex As SqlException
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclCompID
    End Function

    '========================================================================================================
    ' Retrieve an Image Item (Trend installed, Moved in AD, etc.) based on the Row ID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetItemByID(ByVal intItemParam As Integer) As BeanImageItem
        Dim strLclSQL As String = "SELECT * FROM ImageItem WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclImageItem As New BeanImageItem()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intItemParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclImageItem.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ItemName")) Then
                            objLclImageItem.ItemName = objLclCursor("ItemName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclImageItem.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclImageItem.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclImageItem.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclImageItem.UpdEmpName = objLclCursor("UpdEmpName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImageItem
    End Function

    '========================================================================================================
    ' Retrieve an Image Item (Trend installed, Moved in AD, etc.) based on the Row ID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetImgDateByID(ByVal intItemParam As Integer) As BeanImgTable
        Dim strLclSQL As String = "SELECT ImgDate FROM ImgTable WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclImageItem As New BeanImgTable()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intItemParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclImageItem.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ImgDate")) Then
                            objLclImageItem.ImgDate = objLclCursor("ImgDate").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("CompID")) Then
                            objLclImageItem.CompID = objLclCursor("CompID").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Notes")) Then
                            objLclImageItem.Notes = objLclCursor("Notes").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ReadyToDeploy")) Then
                            objLclImageItem.ReadyToDeploy = objLclCursor("ReadyToDeploy").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Reason")) Then
                            objLclImageItem.Reason = objLclCursor("Reason").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclImageItem.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclImageItem.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclImageItem.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclImageItem.UpdEmpName = objLclCursor("UpdEmpName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImageItem
    End Function

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Public Function GetActiveImageItems(ByRef colItemParam As Collection) As Integer
        Dim objLclImgItem As BeanImageItem
        Dim strLclSQL As String
        Dim objLclCursor As SqlDataReader

        strLclSQL = "SELECT RowID FROM Img_ImageItem WHERE Inactive = @Inactive order by OrderNum"
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(False)

                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        Do While objLclCursor.Read()
                            Try
                                If Not IsDBNull(objLclCursor("RowID")) Then
                                    objLclImgItem = New BeanImageItem(Me.GetItemByID(objLclCursor("RowID")))
                                    colItemParam.Add(objLclImgItem)
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return colItemParam.Count()
    End Function

    '========================================================================================================
    ' Retrieve Imaging Table info based on the RowID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetImagingTableByID(ByVal intTableParam As Integer) As BeanImgTable
        Dim strLclSQL As String = "SELECT * FROM ImagingTable WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclImgTable As New BeanImgTable()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intTableParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclImgTable.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ImgDate")) Then
                            objLclImgTable.ImgDate = objLclCursor("ImgDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("CompID")) Then
                            objLclImgTable.CompID = objLclCursor("CompID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Notes")) Then
                            objLclImgTable.Notes = objLclCursor("Notes").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ReadyToDeploy")) Then
                            objLclImgTable.ReadyToDeploy = objLclCursor("ReadyToDeploy")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Reason")) Then
                            objLclImgTable.Reason = objLclCursor("Reason").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclImgTable.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclImgTable.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclImgTable.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclImgTable.UpdEmpName = objLclCursor("UpdateUserName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImgTable
    End Function

    '========================================================================================================
    ' Retrieve Imaging Table info based on the CompID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetImagingTableByCompID(ByVal intTableParam As Integer) As BeanImgTable
        Dim strLclSQL As String = "SELECT * FROM ImagingTable WHERE CompID = @CompID "
        Dim objLclCursor As SqlDataReader
        Dim objLclImgTable As New BeanImgTable()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(intTableParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclImgTable.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ImgDate")) Then
                            objLclImgTable.ImgDate = objLclCursor("ImgDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("CompID")) Then
                            objLclImgTable.CompID = objLclCursor("CompID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Notes")) Then
                            objLclImgTable.Notes = objLclCursor("Notes").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("ReadyToDeploy")) Then
                            objLclImgTable.ReadyToDeploy = objLclCursor("ReadyToDeploy")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Reason")) Then
                            objLclImgTable.Reason = objLclCursor("Reason").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclImgTable.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclImgTable.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclImgTable.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclImgTable.UpdEmpName = objLclCursor("UpdateUserName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImgTable
    End Function

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Public Function GetImgTblColByCompID(ByRef colImgTblParam As Collection, ByVal intCompIDParam As Integer) As Integer
        Dim objLclImgTbl As BeanImgTable
        Dim strLclSQL As String
        Dim objLclCursor As SqlDataReader

        strLclSQL = "SELECT RowID FROM ImagingTable WHERE CompID = @CompID"
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(intCompIDParam)

                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        Do While objLclCursor.Read()
                            Try
                                If Not IsDBNull(objLclCursor("RowID")) Then
                                    objLclImgTbl = New BeanImgTable(Me.GetImagingTableByID(objLclCursor("RowID")))
                                    colImgTblParam.Add(objLclImgTbl)
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return colImgTblParam.Count()
    End Function

    '=================================================================================================
    '
    '-------------------------------------------------------------------------------------------------
    Public Function GetImagingTableByCompIDAndDate(ByVal intCompIDParam As Integer, ByVal strImgDateParam As String) As BeanImgTable
        Dim objLclImgTbl As New BeanImgTable()
        Dim strLclSQL As String
        Dim objLclCursor As SqlDataReader

        strLclSQL = "SELECT RowID FROM ImagingTable WHERE CompID = @CompID and ImgDate = @ImgDate"
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(intCompIDParam)
                objLclCmd.Parameters.Add("@ImgDate", SqlDbType.DateTime)
                objLclCmd.Parameters("@ImgDate").Value = Convert.ToDateTime(strImgDateParam)

                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        objLclCursor.Read()
                        Try
                            If Not IsDBNull(objLclCursor("RowID")) Then
                                objLclImgTbl = New BeanImgTable(Me.GetImagingTableByID(objLclCursor("RowID")))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclImgTbl
    End Function

    '========================================================================================================
    ' Retrieve Repair Notes based on the Row ID.
    '--------------------------------------------------------------------------------------------------------
    Public Function GetRepairByID(ByVal intRepairParam As Integer) As BeanRepair
        Dim strLclSQL As String = "SELECT * FROM Repair WHERE RowID = @RowID "
        Dim objLclCursor As SqlDataReader
        Dim objLclRepair As New BeanRepair()

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(intRepairParam)
                objLclCursor = objLclCmd.ExecuteReader()
                If objLclCursor.HasRows Then
                    objLclCursor.Read()
                    Try
                        If Not IsDBNull(objLclCursor("RowID")) Then
                            objLclRepair.RowID = objLclCursor("RowID")
                        Else
                            Me.strError &= "Invalid Row ID.<br />"
                        End If
                    Catch ex As Exception
                        Me.strError &= "Invalid Row ID.<br />"
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("CompID")) Then
                            objLclRepair.CompID = objLclCursor("CompID")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("RepairDate")) Then
                            objLclRepair.RepairDate = objLclCursor("RepairDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("TechUID")) Then
                            objLclRepair.TechUID = objLclCursor("TechUID").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Description")) Then
                            objLclRepair.Description = objLclCursor("Description").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("Inactive")) Then
                            objLclRepair.Inactive = objLclCursor("Inactive")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("InactiveDate")) Then
                            objLclRepair.InactiveDate = objLclCursor("InactiveDate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("LastUpdate")) Then
                            objLclRepair.LastUpdate = objLclCursor("LastUpdate")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(objLclCursor("UpdEmpName")) Then
                            objLclRepair.UpdEmpName = objLclCursor("UpdEmpName").Replace("''", "'")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                objLclCursor.Close()
            End Using
            objLclDataConn.Close()
        End Using
        Return objLclRepair
    End Function

    '=================================================================================================
    'Pass True as boolFlagParam for ALL records, or False for ONLY ACTIVE records.
    '-------------------------------------------------------------------------------------------------
    Public Function GetRepairsByCompID(ByRef colRepairParam As Collection, ByVal intCompIDParam As Integer, Optional ByVal boolFlagParam As Boolean = False) As Integer
        Dim objLclImgRepair As New BeanRepair()
        Dim strLclSQL As String
        Dim objLclCursor As SqlDataReader


        strLclSQL = "SELECT RowID FROM Repair WHERE CompID = @CompID "
        If Not boolFlagParam Then
            strLclSQL &= "and Inactive = 0 "

        End If
        strLclSQL &= "ORDER BY RepairDate Desc "

        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(intCompIDParam)

                Try
                    objLclCursor = objLclCmd.ExecuteReader()
                    If objLclCursor.HasRows Then
                        Do While objLclCursor.Read()
                            Try
                                If Not IsDBNull(objLclCursor("RowID")) Then
                                    objLclImgRepair = New BeanRepair(Me.GetRepairByID(objLclCursor("RowID")))
                                    colRepairParam.Add(objLclImgRepair)
                                End If
                            Catch ex As Exception
                            End Try
                        Loop
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return colRepairParam.Count()
    End Function


    '========================================================================================================
    ' Insert or Update a Detail record depending on the ID of the bean provided.
    ' DETAIL
    '--------------------------------------------------------------------------------------------------------
    Public Function SaveDetail(ByRef objRowIDParam As BeanImgDetail) As Integer
        Dim intLclRtnCode As Integer

        If objRowIDParam.RowID = 0 Then
            intLclRtnCode = InsertImgDetail(objRowIDParam)
        Else
            intLclRtnCode = UpdateImgDetail(objRowIDParam)
        End If
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Save methods
    '========================================================================================================
    ' Insert or Update a Computer record depending on the ID of the bean provided.
    ' 
    '--------------------------------------------------------------------------------------------------------
    Public Function SaveComputer(ByRef objRowIDParam As BeanCompID) As Integer
        Dim intLclRtnCode As Integer

        If objRowIDParam.RowID = 0 Then
            intLclRtnCode = InsertImgCompID(objRowIDParam)
        Else
            intLclRtnCode = UpdateImgCompID(objRowIDParam)
        End If
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert or Update an Item Field depending on the ID of the bean provided.
    ' ITEM
    '--------------------------------------------------------------------------------------------------------
    Public Function SaveItem(ByRef objRowIDParam As BeanImageItem) As Integer
        Dim intLclRtnCode As Integer

        If objRowIDParam.RowID = 0 Then
            intLclRtnCode = InsertImgImageItem(objRowIDParam)
        Else
            intLclRtnCode = UpdateImgImageItem(objRowIDParam)
        End If
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert or Update a Computer record depending on the ID of the bean provided.
    ' TABLE
    '--------------------------------------------------------------------------------------------------------
    Public Function SaveTable(ByRef objRowIDParam As BeanImgTable) As Integer
        Dim intLclRtnCode As Integer

        If objRowIDParam.RowID = 0 Then
            intLclRtnCode = InsertImgImagingTable(objRowIDParam)
        Else
            intLclRtnCode = UpdateImgImagingTable(objRowIDParam)
        End If
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert or Update a Computer record depending on the ID of the bean provided.
    ' REPAIR
    '--------------------------------------------------------------------------------------------------------
    Public Function SaveRepair(ByRef objRowIDParam As BeanRepair) As Integer
        Dim intLclRtnCode As Integer

        If objRowIDParam.RowID = 0 Then
            intLclRtnCode = InsertImgRepair(objRowIDParam)
        Else
            intLclRtnCode = UpdateImgRepair(objRowIDParam)
        End If
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert Funcions
    '========================================================================================================


    '========================================================================================================
    ' Insert the Image Detail Info
    '--------------------------------------------------------------------------------------------------------
    Protected Function InsertImgDetail(ByRef objRowIDParam As BeanImgDetail) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO ImgDetail ("
        Dim strLclValues As String = " VALUES ("

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID > 0 Then
                        strLclSQL &= "RowID"
                        strLclValues &= "@RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ImgID > 0 Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ImgID"
                        strLclValues &= "@ImgID"
                        objLclCmd.Parameters.Add("@ImgID", SqlDbType.Int)
                        objLclCmd.Parameters("@ImgID").Value = Convert.ToInt32(objRowIDParam.ImgID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ItemID > 0 Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ItemID"
                        strLclValues &= "@ItemID"
                        objLclCmd.Parameters.Add("@ItemID", SqlDbType.Int)
                        objLclCmd.Parameters("@ItemID").Value = Convert.ToInt32(objRowIDParam.ItemID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ItemName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ItemName"
                        strLclValues &= "@ItemName"
                        objLclCmd.Parameters.Add("@ItemName", SqlDbType.VarChar)
                        objRowIDParam.ItemName = objSecure.QuickClean(objRowIDParam.ItemName, 60)
                        objLclCmd.Parameters("@ItemName").Value = Convert.ToString(objRowIDParam.ItemName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Status Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Status"
                        strLclValues &= "@Status"
                        objLclCmd.Parameters.Add("@Status", SqlDbType.Bit)
                        objLclCmd.Parameters("@Status").Value = Convert.ToBoolean(objRowIDParam.Status)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    strLclSQL &= ", LastUpdate"
                    strLclValues &= ", @LastUpdate"
                    objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                    objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                        strLclSQL &= ", UpdEmpName) "
                        strLclValues &= ", @UpdEmpName) "
                        objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.UpdEmpName.Replace("'", "''"), 60))
                    Else
                        strLclSQL &= ")"
                        strLclValues &= ")"
                    End If
                    strLclSQL &= strLclValues
                    strLclSQL &= "; SELECT RowID FROM ImgDetail WHERE RowID = @@IDENTITY"
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = objLclCmd.ExecuteScalar()
                    If intLclRtnCode > 0 Then
                        objRowIDParam.RowID = intLclRtnCode
                    End If
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert the initial Computer Asset Info
    '--------------------------------------------------------------------------------------------------------
    Protected Function InsertImgCompID(ByRef objRowIDParam As BeanCompID) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO CompID ("
        Dim strLclValues As String = " VALUES ("

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID > 0 Then
                        strLclSQL &= "RowID"
                        strLclValues &= "@RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.AssetID > 0 Then
                        strLclSQL &= "AssetID"
                        strLclValues &= "@AssetID"
                        objLclCmd.Parameters.Add("@AssetID", SqlDbType.Int)
                        objLclCmd.Parameters("@AssetID").Value = Convert.ToInt32(objRowIDParam.AssetID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.CompName.Length() > 0 Then
                        If strLclSQL.Length() > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "CompName"
                        strLclValues &= "@CompName"
                        objLclCmd.Parameters.Add("@CompName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@CompName").Value = Convert.ToString(objRowIDParam.CompName.Trim().Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    strLclSQL &= ", LastUpdate"
                    strLclValues &= ", @LastUpdate"
                    objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                    objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                        strLclSQL &= ", UpdEmpName) "
                        strLclValues &= ", @UpdEmpName) "
                        objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.UpdEmpName.Replace("'", "''"), 60))
                    Else
                        strLclSQL &= ")"
                        strLclValues &= ")"
                    End If
                    strLclSQL &= strLclValues
                    strLclSQL &= "; SELECT RowID FROM Img_CompID WHERE RowID = @@IDENTITY"
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = objLclCmd.ExecuteScalar()
                    If intLclRtnCode > 0 Then
                        objRowIDParam.RowID = intLclRtnCode
                    End If
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert the Image Item Info
    '--------------------------------------------------------------------------------------------------------
    Protected Function InsertImgImageItem(ByRef objRowIDParam As BeanImageItem) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO ImageItem ("
        Dim strLclValues As String = " VALUES ("

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID > 0 Then
                        strLclSQL &= "RowID"
                        strLclValues &= "@RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.OrderNum > 0 Then
                        strLclSQL &= "OrderNum"
                        strLclValues &= "@OrderNum"
                        objLclCmd.Parameters.Add("@OrderNum", SqlDbType.Int)
                        objLclCmd.Parameters("@OrderNum").Value = Convert.ToInt32(objRowIDParam.OrderNum)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.ItemName) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ItemName"
                        strLclValues &= "@ItemName"
                        objLclCmd.Parameters.Add("@ItemName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@ItemName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.ItemName.Replace("'", "''"), 50))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.Description) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Description"
                        strLclValues &= "@Description"
                        objLclCmd.Parameters.Add("@Description", SqlDbType.VarChar)
                        objLclCmd.Parameters("@Description").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.Description.Replace("'", "''"), 1000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    strLclSQL &= ", LastUpdate"
                    strLclValues &= ", @LastUpdate"
                    objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                    objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                        strLclSQL &= ", UpdEmpName) "
                        strLclValues &= ", @UpdEmpName) "
                        objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.UpdEmpName.Replace("'", "''"), 60))
                    Else
                        strLclSQL &= ")"
                        strLclValues &= ")"
                    End If
                    strLclSQL &= strLclValues
                    strLclSQL &= "; SELECT RowID FROM ImageItem WHERE ID = @@IDENTITY"
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = objLclCmd.ExecuteScalar()
                    If intLclRtnCode > 0 Then
                        objRowIDParam.RowID = intLclRtnCode
                    End If
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert the Imaging Table Info
    '--------------------------------------------------------------------------------------------------------
    Protected Function InsertImgImagingTable(ByRef objRowIDParam As BeanImgTable) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO ImagingTable ("
        Dim strLclValues As String = " VALUES ("

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID > 0 Then
                        strLclSQL &= "RowID"
                        strLclValues &= "@RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ImgDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ImgDate"
                        strLclValues &= "@ImgDate"
                        objLclCmd.Parameters.Add("@ImgDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@ImgDate").Value = Convert.ToDateTime(objRowIDParam.ImgDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.CompID > 0 Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "CompID"
                        strLclValues &= "@CompID"
                        objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                        objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(objRowIDParam.CompID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.Notes) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Notes"
                        strLclValues &= "@Notes"
                        objLclCmd.Parameters.Add("@Notes", SqlDbType.VarChar)
                        objLclCmd.Parameters("@Notes").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.Notes.Replace("'", "''"), 8000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ReadyToDeploy Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "ReadyToDeploy"
                        strLclValues &= "@ReadyToDeploy"
                        objLclCmd.Parameters.Add("@ReadyToDeploy", SqlDbType.Bit)
                        objLclCmd.Parameters("@ReadyToDeploy").Value = Convert.ToBoolean(objRowIDParam.ReadyToDeploy)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.Reason) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Reason"
                        strLclValues &= "@Reason"
                        objLclCmd.Parameters.Add("@Reason", SqlDbType.VarChar)
                        objLclCmd.Parameters("@Reason").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.Reason.Replace("'", "''"), 2000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    strLclSQL &= ", LastUpdate"
                    strLclValues &= ", @LastUpdate"
                    objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                    objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                        strLclSQL &= ", UpdEmpName) "
                        strLclValues &= ", @UpdEmpName) "
                        objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.UpdEmpName.Replace("'", "''"), 60))
                    Else
                        strLclSQL &= ")"
                        strLclValues &= ")"
                    End If
                    strLclSQL &= strLclValues
                    strLclSQL &= "; SELECT RowID FROM ImagingTable WHERE RowID = @@IDENTITY"
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = objLclCmd.ExecuteScalar()
                    If intLclRtnCode > 0 Then
                        objRowIDParam.RowID = intLclRtnCode
                    End If
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Insert the Repair Notes
    '--------------------------------------------------------------------------------------------------------
    Protected Function InsertImgRepair(ByRef objRowIDParam As BeanRepair) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer = 0
        Dim strLclSQL As String = "INSERT INTO Repair ("
        Dim strLclValues As String = " VALUES ("

        intLclQryLen = strLclSQL.Length()
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.CompID > 0 Then
                        strLclSQL &= "CompID"
                        strLclValues &= "@CompID"
                        objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                        objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(objRowIDParam.CompID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.RepairDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "RepairDate"
                        strLclValues &= "@RepairDate"
                        objLclCmd.Parameters.Add("@RepairDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@RepairDate").Value = Convert.ToDateTime(objRowIDParam.RepairDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.TechUID) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "TechUID"
                        strLclValues &= "@TechUID"
                        objLclCmd.Parameters.Add("@TechUID", SqlDbType.VarChar)
                        objLclCmd.Parameters("@TechUID").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.TechUID.Replace("'", "''"), 50))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.Description) Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Description"
                        strLclValues &= "@Description"
                        objLclCmd.Parameters.Add("@Description", SqlDbType.VarChar)
                        objLclCmd.Parameters("@Description").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.Description.Replace("'", "''"), 2000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "Inactive"
                        strLclValues &= "@Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                            strLclValues &= ", "
                        End If
                        strLclSQL &= "InactiveDate"
                        strLclValues &= "@InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    strLclSQL &= ", LastUpdate"
                    strLclValues &= ", @LastUpdate"
                    objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                    objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                    If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                        strLclSQL &= ", UpdEmpName) "
                        strLclValues &= ", @UpdEmpName) "
                        objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                        objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(objRowIDParam.UpdEmpName.Replace("'", "''"), 60))
                    Else
                        strLclSQL &= ")"
                        strLclValues &= ")"
                    End If
                    strLclSQL &= strLclValues
                    strLclSQL &= "; SELECT RowID FROM Repair WHERE RowID = @@IDENTITY"
                    objLclCmd.CommandText = strLclSQL
                    intLclRtnCode = objLclCmd.ExecuteScalar()
                    If intLclRtnCode > 0 Then
                        objRowIDParam.RowID = intLclRtnCode
                    End If
                End If
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    '   Update Functions
    '========================================================================================================
    ' Process changes by IT Techs to the CompID Table
    '--------------------------------------------------------------------------------------------------------
    Protected Function UpdateImgCompID(ByRef objRowIDParam As BeanCompID) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer
        Dim strLclTemp As String
        Dim strLclSQL As String = "UPDATE CompID SET "
        Dim objLclCompID As BeanCompID
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        objLclCompID = New BeanCompID(Me.GetCompIDByID(objRowIDParam.RowID))
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID <> objLclCompID.RowID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RowID = @RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.AssetID <> objLclCompID.AssetID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "AssetID = @AssetID"
                        objLclCmd.Parameters.Add("@AssetID", SqlDbType.Int)
                        objLclCmd.Parameters("@AssetID").Value = Convert.ToInt32(objRowIDParam.AssetID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.CompName <> objLclCompID.CompName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "CompName = @CompName"
                        objLclCmd.Parameters.Add("@CompName", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.CompName
                        objLclCmd.Parameters("@CompName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 8000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive <> objLclCompID.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" And objRowIDParam.InactiveDate <> objLclCompID.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                If strLclSQL.Length > intLclQryLen Then
                    Try
                        If objRowIDParam.LastUpdate <> objLclCompID.LastUpdate Then
                            strLclSQL &= ", LastUpdated = @LastUpdated"
                            objLclCmd.Parameters.Add("@LastUpdated", SqlDbType.DateTime)
                            objLclCmd.Parameters("@LastUpdated").Value = Convert.ToDateTime(Now())
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) And objRowIDParam.UpdEmpName <> objLclCompID.UpdEmpName Then
                            strLclSQL &= ", UpdEmpName = @UpdEmpName"
                            objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                            objRowIDParam.UpdEmpName = objLclSecure.QuickClean(objRowIDParam.UpdEmpName, 60)
                            objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(objRowIDParam.UpdEmpName.Replace("'", "''"))
                        End If
                    Catch ex As Exception
                    End Try
                    strLclSQL &= " WHERE RowID = @RowID "
                    objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                    objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
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


    '========================================================================================================
    ' Process changes by IT Techs to the Image Detail Table
    '--------------------------------------------------------------------------------------------------------
    Protected Function UpdateImgDetail(ByRef objRowIDParam As BeanImgDetail) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer
        Dim strLclTemp As String
        Dim strLclSQL As String = "UPDATE ImgDetail SET "
        Dim objLclImageDetail As BeanImgDetail
        Dim objLclSecure As New clsSecurity()

        intLclQryLen = strLclSQL.Length()
        objLclImageDetail = New BeanImgDetail(Me.GetDetailByID(objRowIDParam.RowID))
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID <> objLclImageDetail.RowID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RowID = @RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ImgID <> objLclImageDetail.ImgID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ImgID = @ImgID"
                        objLclCmd.Parameters.Add("@ImgID", SqlDbType.Int)
                        objLclCmd.Parameters("@ImgID").Value = Convert.ToInt32(objRowIDParam.ImgID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ItemID <> objLclImageDetail.ItemID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ItemID = @ItemID"
                        objLclCmd.Parameters.Add("@ItemID", SqlDbType.Int)
                        objLclCmd.Parameters("@ItemID").Value = Convert.ToInt32(objRowIDParam.ItemID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not String.IsNullOrEmpty(objRowIDParam.ItemName) And objRowIDParam.ItemName <> objLclImageDetail.ItemName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ItemName = @ItemName"
                        objLclCmd.Parameters.Add("@ItemName", SqlDbType.VarChar)
                        objRowIDParam.ItemName = objLclSecure.QuickClean(objRowIDParam.ItemName, 60)
                        objLclCmd.Parameters("@ItemName").Value = Convert.ToString(objRowIDParam.ItemName.Replace("'", "''"))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Status <> objLclImageDetail.Status Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Status = @Status"
                        objLclCmd.Parameters.Add("@Status", SqlDbType.Bit)
                        objLclCmd.Parameters("@Status").Value = Convert.ToBoolean(objRowIDParam.Status)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive <> objLclImageDetail.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" And objRowIDParam.InactiveDate <> objLclImageDetail.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If strLclSQL.Length > intLclQryLen Then
                        If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                            strLclSQL &= ", UpdEmpName = @UpdEmpName"
                            objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                            strLclTemp = objRowIDParam.UpdEmpName
                            objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 60))
                        End If
                        strLclSQL &= ", LastUpdate = @LastUpdate "
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        strLclSQL &= " WHERE RowID = @RowID "
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                        Try
                            objLclCmd.CommandText = strLclSQL
                            If intLclRtnCode = 0 Then
                                intLclRtnCode = objLclCmd.ExecuteNonQuery()
                            End If
                        Catch ex As Exception
                            intLclRtnCode = -1
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Process changes by IT Techs to the Image Item Table
    '--------------------------------------------------------------------------------------------------------
    Protected Function UpdateImgImageItem(ByRef objRowIDParam As BeanImageItem) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer
        Dim strLclTemp As String
        Dim strLclSQL As String = "UPDATE ImageItem SET "
        Dim objLclImageItem As BeanImageItem

        intLclQryLen = strLclSQL.Length()
        objLclImageItem = New BeanImageItem(Me.GetItemByID(objRowIDParam.RowID))
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID <> objLclImageItem.RowID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RowID = @RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.OrderNum <> objLclImageItem.OrderNum Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "OrderNum = @OrderNum"
                        objLclCmd.Parameters.Add("@OrderNum", SqlDbType.Int)
                        objLclCmd.Parameters("@OrderNum").Value = Convert.ToInt32(objRowIDParam.OrderNum)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ItemName <> objLclImageItem.ItemName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ItemName = @ItemName"
                        objLclCmd.Parameters.Add("@ItemName", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.ItemName
                        objLclCmd.Parameters("@ItemName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 50))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ItemName <> objLclImageItem.ItemName Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ItemName = @ItemName"
                        objLclCmd.Parameters.Add("@ItemName", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.ItemName
                        objLclCmd.Parameters("@ItemName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 50))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive <> objLclImageItem.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" And objRowIDParam.InactiveDate <> objLclImageItem.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If strLclSQL.Length > intLclQryLen Then
                        If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                            strLclSQL &= ", UpdEmpName = @UpdEmpName"
                            objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                            strLclTemp = objRowIDParam.UpdEmpName
                            objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 60))
                        End If
                        strLclSQL &= ", LastUpdate = @LastUpdate "
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        strLclSQL &= " WHERE RowID = @RowID "
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                        Try
                            objLclCmd.CommandText = strLclSQL
                            If intLclRtnCode = 0 Then
                                intLclRtnCode = objLclCmd.ExecuteNonQuery()
                            End If
                        Catch ex As Exception
                            intLclRtnCode = -1
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Process changes by IT Techs to the Imaging Table
    '--------------------------------------------------------------------------------------------------------
    Protected Function UpdateImgImagingTable(ByRef objRowIDParam As BeanImgTable) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer
        Dim strLclTemp As String
        Dim strLclSQL As String = "UPDATE ImagingTable SET "
        Dim objLclImagingTable As BeanImgTable

        intLclQryLen = strLclSQL.Length()
        objLclImagingTable = New BeanImgTable(Me.GetImagingTableByID(objRowIDParam.RowID))
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID <> objLclImagingTable.RowID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RowID = @RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ImgDate <> "12:00:00 AM" And objRowIDParam.ImgDate <> objLclImagingTable.ImgDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ImgDate = @ImgDate"
                        objLclCmd.Parameters.Add("@ImgDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@ImgDate").Value = Convert.ToDateTime(objRowIDParam.ImgDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.CompID <> objLclImagingTable.CompID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "CompID = @CompID"
                        objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                        objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(objRowIDParam.CompID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Notes <> objLclImagingTable.Notes Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Notes = @Notes"
                        objLclCmd.Parameters.Add("@Notes", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.Notes
                        objLclCmd.Parameters("@Notes").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 8000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.ReadyToDeploy <> objLclImagingTable.ReadyToDeploy Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "ReadyToDeploy = @ReadyToDeploy"
                        objLclCmd.Parameters.Add("@ReadyToDeploy", SqlDbType.Bit)
                        objLclCmd.Parameters("@ReadyToDeploy").Value = Convert.ToBoolean(objRowIDParam.ReadyToDeploy)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Reason <> objLclImagingTable.Reason Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Reason = @Reason"
                        objLclCmd.Parameters.Add("@Reason", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.Reason
                        objLclCmd.Parameters("@Reason").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 2000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive <> objLclImagingTable.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" And objRowIDParam.InactiveDate <> objLclImagingTable.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If strLclSQL.Length > intLclQryLen Then
                        If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                            strLclSQL &= ", UpdEmpName = @UpdEmpName"
                            objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                            strLclTemp = objRowIDParam.UpdEmpName
                            objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 60))
                        End If
                        strLclSQL &= ", LastUpdate = @LastUpdate "
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        strLclSQL &= " WHERE RowID = @RowID "
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                        Try
                            objLclCmd.CommandText = strLclSQL
                            If intLclRtnCode = 0 Then
                                intLclRtnCode = objLclCmd.ExecuteNonQuery()
                            End If
                        Catch ex As Exception
                            intLclRtnCode = -1
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function

    '========================================================================================================
    ' Process changes by IT Techs to the Repair Table
    '--------------------------------------------------------------------------------------------------------
    Protected Function UpdateImgRepair(ByRef objRowIDParam As BeanRepair) As Integer
        Dim intLclQryLen As Integer
        Dim intLclRtnCode As Integer
        Dim strLclTemp As String
        Dim strLclSQL As String = "UPDATE Repair SET "
        Dim objLclRepair As BeanRepair

        intLclQryLen = strLclSQL.Length()
        objLclRepair = New BeanRepair(Me.GetRepairByID(objRowIDParam.RowID))
        Using objLclDataConn As New SqlConnection(Me.strConn)
            objLclDataConn.Open()
            Using objLclCmd As New SqlCommand(strLclSQL, objLclDataConn)
                Try
                    If objRowIDParam.RowID <> objLclRepair.RowID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RowID = @RowID"
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.CompID <> objLclRepair.CompID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "CompID = @CompID"
                        objLclCmd.Parameters.Add("@CompID", SqlDbType.Int)
                        objLclCmd.Parameters("@CompID").Value = Convert.ToInt32(objRowIDParam.CompID)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.RepairDate <> "12:00:00 AM" And objRowIDParam.RepairDate <> objLclRepair.RepairDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "RepairDate = @RepairDate"
                        objLclCmd.Parameters.Add("@RepairDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@RepairDate").Value = Convert.ToDateTime(objRowIDParam.RepairDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.TechUID <> objLclRepair.TechUID Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "TechUID = @TechUID"
                        objLclCmd.Parameters.Add("@TechUID", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.TechUID
                        objLclCmd.Parameters("@TechUID").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 50))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Description <> objLclRepair.Description Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Description = @Description"
                        objLclCmd.Parameters.Add("@Description", SqlDbType.VarChar)
                        strLclTemp = objRowIDParam.Description
                        objLclCmd.Parameters("@Description").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 2000))
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.Inactive <> objLclRepair.Inactive Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "Inactive = @Inactive"
                        objLclCmd.Parameters.Add("@Inactive", SqlDbType.Bit)
                        objLclCmd.Parameters("@Inactive").Value = Convert.ToBoolean(objRowIDParam.Inactive)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If objRowIDParam.InactiveDate <> "12:00:00 AM" And objRowIDParam.InactiveDate <> objLclRepair.InactiveDate Then
                        If strLclSQL.Length > intLclQryLen Then
                            strLclSQL &= ", "
                        End If
                        strLclSQL &= "InactiveDate = @InactiveDate"
                        objLclCmd.Parameters.Add("@InactiveDate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@InactiveDate").Value = Convert.ToDateTime(objRowIDParam.InactiveDate)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If strLclSQL.Length > intLclQryLen Then
                        If Not String.IsNullOrEmpty(objRowIDParam.UpdEmpName) Then
                            strLclSQL &= ", UpdEmpName = @UpdEmpName"
                            objLclCmd.Parameters.Add("@UpdEmpName", SqlDbType.VarChar)
                            strLclTemp = objRowIDParam.UpdEmpName
                            objLclCmd.Parameters("@UpdEmpName").Value = Convert.ToString(Me.objSecure.QuickClean(strLclTemp.Replace("'", "''"), 60))
                        End If
                        strLclSQL &= ", LastUpdate = @LastUpdate "
                        objLclCmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime)
                        objLclCmd.Parameters("@LastUpdate").Value = Convert.ToDateTime(Now())
                        strLclSQL &= " WHERE RowID = @RowID "
                        objLclCmd.Parameters.Add("@RowID", SqlDbType.Int)
                        objLclCmd.Parameters("@RowID").Value = Convert.ToInt32(objRowIDParam.RowID)
                        Try
                            objLclCmd.CommandText = strLclSQL
                            If intLclRtnCode = 0 Then
                                intLclRtnCode = objLclCmd.ExecuteNonQuery()
                            End If
                        Catch ex As Exception
                            intLclRtnCode = -1
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End Using
            objLclDataConn.Close()
        End Using
        Return intLclRtnCode
    End Function
End Class
