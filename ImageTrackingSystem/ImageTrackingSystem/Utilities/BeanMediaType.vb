Imports Microsoft.VisualBasic

Public Class BeanMediaType

    Protected RowIDValue As Integer
    Protected TypeValue As String
    Protected InactiveValue As Boolean
    Protected InactiveDateValue As Date
    Protected LastUpdateValue As Date

    '=================================================================================================
    ' Constructors
    '-------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0                      'integer
        TypeValue = ""                  'string
        InactiveValue = False               'Boolean
        InactiveDateValue = "12:00:00 AM"   'Date
        LastUpdateValue = "12:00:00 AM"     'Date
    End Sub

    '=================================================================================================
    ' Copy Constructor
    '-------------------------------------------------------------------------------------------------
    Public Sub New(ByRef objMstr As BeanMediaType)
        RowIDValue = objMstr.RowID
        TypeValue = objMstr.Type
        InactiveValue = objMstr.Inactive
        InactiveDateValue = objMstr.InactiveDate
        LastUpdateValue = objMstr.LastUpdate
    End Sub

    '=================================================================================================
    ' Properties
    '-------------------------------------------------------------------------------------------------
    Public Property RowID() As Integer
        Get
            Return RowIDValue
        End Get
        Set(ByVal value As Integer)
            RowIDValue = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return TypeValue
        End Get
        Set(ByVal value As String)
            TypeValue = value
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
End Class
