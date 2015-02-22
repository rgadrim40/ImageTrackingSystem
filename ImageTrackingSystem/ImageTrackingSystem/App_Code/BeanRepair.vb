'	========================================================================================================
'   Repair notes and dates.
'	--------------------------------------------------------------------------------------------------------
'	Author:	Richard Gadrim			    begun:	2/19/2015		    last modification:	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanRepair
    Private RowIDValue As Integer
    Private CompIDValue As Integer
    Private RepairDateValue As Date
    Private TechUIDValue As String
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
        CompIDValue = 0
        RepairDateValue = "12:00:00 AM"
        TechUIDValue = ""
        DescriptionValue = ""
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objRepairParam As BeanRepair)
        RowIDValue = objRepairParam.RowID
        CompIDValue = objRepairParam.CompID
        RepairDateValue = objRepairParam.RepairDate
        TechUIDValue = objRepairParam.TechUID
        DescriptionValue = objRepairParam.Description
        InactiveValue = objRepairParam.Inactive
        InactiveDateValue = objRepairParam.InactiveDate
        LastUpdateValue = objRepairParam.LastUpdate
        UpdEmpNameValue = objRepairParam.UpdEmpName
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
    Public Property CompID() As Integer
        Get
            Return CompIDValue
        End Get
        Set(ByVal value As Integer)
            CompIDValue = value
        End Set
    End Property
    Public Property RepairDate() As Date
        Get
            Return RepairDateValue
        End Get
        Set(ByVal value As Date)
            RepairDateValue = value
        End Set
    End Property
    Public Property TechUID() As String
        Get
            Return TechUIDValue
        End Get
        Set(ByVal value As String)
            TechUIDValue = value
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
