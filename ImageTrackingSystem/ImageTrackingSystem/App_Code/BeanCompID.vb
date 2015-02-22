'	========================================================================================================
'   Represents a Computer Asset ID, tied to IT Imaging Checksheet.
'	--------------------------------------------------------------------------------------------------------
'	Author:	Jared Otto			    begun:	06/28/2012		    last modification:	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'
'
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanCompID
    Private RowIDValue As Integer
    Private AssetIDValue As Integer
    Private CompNameValue As String
    Private InactiveValue As Boolean
    Private InactiveDateValue As Date
    Private LastUpdateValue As Date
    Private UpdEmpNameValue As String

    '========================================================================================================
    ' Constructors
    '--------------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0
        AssetIDValue = 0
        CompNameValue = ""
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objCompIDParam As BeanCompID)
        RowIDValue = objCompIDParam.RowID
        AssetIDValue = objCompIDParam.AssetID
        CompNameValue = objCompIDParam.CompName
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
    Public Property AssetID() As Integer
        Get
            Return AssetIDValue
        End Get
        Set(ByVal value As Integer)
            AssetIDValue = value
        End Set
    End Property
    Public Property CompName() As String
        Get
            Return CompNameValue
        End Get
        Set(ByVal value As String)
            CompNameValue = value
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
