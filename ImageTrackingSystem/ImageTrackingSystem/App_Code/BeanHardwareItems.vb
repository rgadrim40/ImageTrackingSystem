'	========================================================================================================
'	Author:	Richard Gadrim			    begun:	08/1/2014		    last modification:  08/1/2014	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'
'
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanHardwareItems
    Private RowIDValue As Integer
    Private OrderNumValue As Integer
    Private HOItemNameValue As String
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
        HOItemNameValue = ""
        DescriptionValue = ""
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objCompIDParam As BeanHardwareItems)
        RowIDValue = objCompIDParam.RowID
        OrderNumValue = objCompIDParam.OrderNum
        DescriptionValue = objCompIDParam.Description
        HOItemNameValue = objCompIDParam.HOItemName
        InactiveValue = objCompIDParam.Inactive
        InactiveDateValue = objCompIDParam.InactiveDate
        LastUpdateValue = objCompIDParam.LastUpdate
        UpdEmpNameValue = objCompIDParam.UpdEmpName
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
    Public Property HOItemName() As String
        Get
            Return HOItemNameValue
        End Get
        Set(ByVal value As String)
            HOItemNameValue = value
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
