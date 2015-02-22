Imports Microsoft.VisualBasic

Public Class BeanUserProfile

    Protected RowIDValue As Integer
    Protected FirstNameValue As String
    Protected LastNameValue As String
    Protected Address1Value As String
    Protected Address2Value As String
    Protected CityValue As String
    Protected StateValue As String
    Protected EmailValue As String
    Protected UserNameValue As String
    Protected InactiveValue As Boolean
    Protected InactiveDateValue As Date
    Protected LastUpdateValue As Date

    '=================================================================================================
    ' Constructors
    '-------------------------------------------------------------------------------------------------
    Public Sub New()
        RowIDValue = 0                      'integer
        FirstNameValue = ""                 'string
        LastNameValue = ""                  'string
        Address1Value = ""                  'string
        Address2Value = ""                  'string
        CityValue = ""                      'string
        StateValue = ""                     'string
        EmailValue = ""                     'string
        UserNameValue = ""                  'string
        InactiveValue = False               ' As Boolean
        InactiveDateValue = "12:00:00 AM"   ' As Date
        LastUpdateValue = "12:00:00 AM"     ' As Date
    End Sub

    '=================================================================================================
    ' Copy Constructor
    '-------------------------------------------------------------------------------------------------
    Public Sub New(ByRef objMstr As BeanUserProfile)
        RowIDValue = objMstr.RowID
        FirstNameValue = objMstr.FirstName
        LastNameValue = objMstr.LastName
        Address1Value = objMstr.Address1
        Address2Value = objMstr.Address2
        CityValue = objMstr.City
        StateValue = objMstr.State
        EmailValue = objMstr.Email
        UserNameValue = objMstr.UserName
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

    Public Property FirstName() As String
        Get
            Return FirstNameValue
        End Get
        Set(ByVal value As String)
            FirstNameValue = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return LastNameValue
        End Get
        Set(ByVal value As String)
            LastNameValue = value
        End Set
    End Property

    Public Property Address1() As String
        Get
            Return Address1Value
        End Get
        Set(ByVal value As String)
            Address1Value = value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return Address2Value
        End Get
        Set(ByVal value As String)
            Address2Value = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return CityValue
        End Get
        Set(ByVal value As String)
            CityValue = value
        End Set
    End Property


    Public Property State() As String
        Get
            Return StateValue
        End Get
        Set(ByVal value As String)
            StateValue = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return EmailValue
        End Get
        Set(ByVal value As String)
            EmailValue = value
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
