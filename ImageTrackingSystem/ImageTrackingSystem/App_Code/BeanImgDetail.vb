'	========================================================================================================
'   Represents completion checkboxes for each item, tied to IT Imaging Checksheet.
'	--------------------------------------------------------------------------------------------------------
'	Author:	Jared Otto			    begun:	06/28/2012		    last modification:	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'  
'
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanImgDetail
    Private RowIDValue As Integer
    Private ImgIDValue As Integer
    Private ItemIDValue As Integer
    Private ItemNameValue As String
    Private StatusValue As Boolean
    Private InactiveValue As Boolean
    Private InactiveDateValue As Date
    Private LastUpdateValue As Date
    Private UpdEmpNameValue As String
    '========================================================================================================
    ' Constructors
    '--------------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0
        ImgIDValue = 0
        ItemIDValue = 0
        ItemNameValue = ""
        StatusValue = False
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objDetailParam As BeanImgDetail)
        RowIDValue = objDetailParam.RowID
        ImgIDValue = objDetailParam.ImgID
        ItemIDValue = objDetailParam.ItemID
        ItemNameValue = objDetailParam.ItemName
        StatusValue = objDetailParam.Status
        InactiveValue = objDetailParam.Inactive
        InactiveDateValue = objDetailParam.InactiveDate
        LastUpdateValue = objDetailParam.LastUpdate
        UpdEmpNameValue = objDetailParam.UpdEmpName
    End Sub

    '========================================================================================================
    ' Properties
    '--------------------------------------------------------------------------------------------------------
    Public Property RowID() As Integer
        Get
            Return RowIDValue
        End Get
        Set(ByVal value As Integer)
            RowIDValue = value
        End Set
    End Property
    Public Property ImgID() As Integer
        Get
            Return ImgIDValue
        End Get
        Set(ByVal value As Integer)
            ImgIDValue = value
        End Set
    End Property
    Public Property ItemID() As Integer
        Get
            Return ItemIDValue
        End Get
        Set(ByVal value As Integer)
            ItemIDValue = value
        End Set
    End Property
    Public Property ItemName() As String
        Get
            Return ItemNameValue
        End Get
        Set(ByVal value As String)
            ItemNameValue = value
        End Set
    End Property
    Public Property Status() As Boolean
        Get
            Return StatusValue
        End Get
        Set(ByVal value As Boolean)
            StatusValue = value
        End Set
    End Property
    Public Property Inactive() As Boolean
        Get
            Return InactiveValue
        End Get
        Set(ByVal value As Boolean)
            InactiveValue = value
        End Set
    End Property
    Public Property InactiveDate() As Date
        Get
            Return InactiveDateValue
        End Get
        Set(ByVal value As Date)
            InactiveDateValue = value
        End Set
    End Property
    Public Property LastUpdate() As Date
        Get
            Return LastUpdateValue
        End Get
        Set(ByVal value As Date)
            LastUpdateValue = value
        End Set
    End Property
    Public Property UpdEmpName() As String
        Get
            Return UpdEmpNameValue
        End Get
        Set(ByVal value As String)
            UpdEmpNameValue = value
        End Set
    End Property

End Class
