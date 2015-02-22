Imports Microsoft.VisualBasic

Public Class BeanMedia

    Protected RowIDValue As Integer
    Protected UserNameValue As String
    Protected MTypeValue As String
    Protected MNameValue As String
    Protected MDescriptionValue As String
    Protected MDateValue As Date
    Protected InactiveValue As Boolean
    Protected InactiveDateValue As Date
    Protected LastUpdateValue As Date

    '=================================================================================================
    ' Constructors
    '-------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0                      'integer
        UserNameValue = ""                  'string
        MTypeValue = ""                     'string
        MNameValue = ""                     'string
        MDescriptionValue = ""              'string
        MDateValue = "12:00:00 AM"          'Date
        InactiveValue = False               'Boolean
        InactiveDateValue = "12:00:00 AM"   'Date
        LastUpdateValue = "12:00:00 AM"     'Date
    End Sub

    '=================================================================================================
    ' Copy Constructor
    '-------------------------------------------------------------------------------------------------
    Public Sub New(ByRef objMstr As BeanMedia)
        RowIDValue = objMstr.RowID
        UserNameValue = objMstr.UserName
        MTypeValue = objMstr.MType
        MNameValue = objMstr.MName
        MDescriptionValue = objMstr.MDescription
        MDateValue = objMstr.MDate
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

    Public Property MType() As String
        Get
            Return MTypeValue
        End Get
        Set(ByVal value As String)
            MTypeValue = value
        End Set
    End Property

    Public Property MName() As String
        Get
            Return MNameValue
        End Get
        Set(ByVal value As String)
            MNameValue = value
        End Set
    End Property

    Public Property MDescription() As String
        Get
            Return MDescriptionValue
        End Get
        Set(ByVal value As String)
            MDescriptionValue = value
        End Set
    End Property

    Public Property MDate() As Date
        Get
            Return MDateValue
        End Get
        Set(ByVal value As Date)
            MDateValue = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return UserNameValue
        End Get
        Set(ByVal value As String)
            UserNameValue = value
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
