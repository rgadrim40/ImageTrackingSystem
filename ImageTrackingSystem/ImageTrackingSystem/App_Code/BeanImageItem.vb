'	========================================================================================================
'   Represents Item fields (Trend installed, Moved in AD, etc.), tied to IT Imaging Checksheet.
'	--------------------------------------------------------------------------------------------------------
'	Author:	Jared Otto			    begun:	06/28/2012		    last modification:	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'  
'
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanImageItem
    Private RowIDValue As Integer
    Private OrderNumValue As String
    Private ItemNameValue As String
    Private DescriptionValue As String
    Private InactiveValue As Boolean
    Private InactiveDateValue As Date
    Private LastUpdateValue As Date
    Private UpdEmpNameValue As String

    '========================================================================================================
    ' Constructors
    '--------------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0
        OrderNumValue = 0
        ItemNameValue = ""
        DescriptionValue = ""
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objItemParam As BeanImageItem)
        RowIDValue = objItemParam.RowID
        OrderNumValue = objItemParam.OrderNum
        ItemNameValue = objItemParam.ItemName
        DescriptionValue = objItemParam.Description
        InactiveValue = objItemParam.Inactive
        InactiveDateValue = objItemParam.InactiveDate
        LastUpdateValue = objItemParam.LastUpdate
        UpdEmpNameValue = objItemParam.UpdEmpName
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
    Public Property OrderNum() As Integer
        Get
            Return OrderNumValue
        End Get
        Set(ByVal value As Integer)
            OrderNumValue = value
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
    Public Property Description() As String
        Get
            Return DescriptionValue
        End Get
        Set(ByVal value As String)
            DescriptionValue = value
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
