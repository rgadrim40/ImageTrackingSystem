Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ImgUtil
    
    '=================================================================================================
    ' Retrieve the connectstring.
    '-------------------------------------------------------------------------------------------------
    Public Function GetConnectString() As String
        Try
            Return ConfigurationManager.ConnectionStrings("ImgTrackSys").ConnectionString
        Catch ex As Exception
            Return ConfigurationManager.ConnectionStrings("ImgTrackSys").ConnectionString
        End Try
    End Function

    '=================================================================================================
    ' Strips the domainusers\ off the userid.
    '-------------------------------------------------------------------------------------------------
    Function StripDomain(ByVal strLogonUser As String) As String
        Return Mid(strLogonUser, InStr(strLogonUser, "\") + 1)
    End Function
End Class
