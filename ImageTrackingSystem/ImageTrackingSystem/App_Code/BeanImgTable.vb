'	========================================================================================================
'   Image date and reason whether or not to deploy machine, tied to IT Imaging Checksheet.
'	--------------------------------------------------------------------------------------------------------
'	Author:	Jared Otto			    begun:	06/28/2012		    last modification:	
'	--------------------------------------------------------------------------------------------------------
'	Modification Log:
'  
'
'	========================================================================================================
Imports Microsoft.VisualBasic

Public Class BeanImgTable
    Private RowIDValue As Integer
    Private ImgDateValue As Date
    Private CompIDValue As Integer
    Private NotesValue As String
    Private ReadyToDeployValue As Boolean
    Private ReasonValue As String
    Private InactiveValue As Boolean
    Private InactiveDateValue As Date
    Private LastUpdateValue As Date
    Private UpdEmpNameValue As String

    '========================================================================================================
    ' Constructors
    '--------------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0
        ImgDateValue = "12:00:00 AM"
        CompIDValue = 0
        NotesValue = ""
        ReadyToDeployValue = False
        ReasonValue = ""
        InactiveValue = False
        InactiveDateValue = "12:00:00 AM"
        LastUpdateValue = "12:00:00 AM"
        UpdEmpNameValue = ""
    End Sub
    Public Sub New(ByRef objImagingTableParam As BeanImgTable)
        RowIDValue = objImagingTableParam.RowID
        ImgDateValue = objImagingTableParam.ImgDate
        CompIDValue = objImagingTableParam.CompID
        NotesValue = objImagingTableParam.Notes
        ReadyToDeployValue = objImagingTableParam.ReadyToDeploy
        ReasonValue = objImagingTableParam.Reason
        InactiveValue = objImagingTableParam.Inactive
        InactiveDateValue = objImagingTableParam.InactiveDate
        LastUpdateValue = objImagingTableParam.LastUpdate
        UpdEmpNameValue = objImagingTableParam.UpdEmpName
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
    Public Property ImgDate() As Date
        Get
            Return ImgDateValue
        End Get
        Set(ByVal value As Date)
            ImgDateValue = value
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
    Public Property Notes() As String
        Get
            Return NotesValue
        End Get
        Set(ByVal value As String)
            NotesValue = value
        End Set
    End Property
    Public Property ReadyToDeploy() As Boolean
        Get
            Return ReadyToDeployValue
        End Get
        Set(ByVal value As Boolean)
            ReadyToDeployValue = value
        End Set
    End Property
    Public Property Reason() As String
        Get
            Return ReasonValue
        End Get
        Set(ByVal value As String)
            ReasonValue = value
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
