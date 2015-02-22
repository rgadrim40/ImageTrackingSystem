Imports Microsoft.VisualBasic

Public Class clsSecurity

    Private strErrorValue As String

    '=================================================================================================
    ' Default Class constructor
    '-------------------------------------------------------------------------------------------------
    Public Sub New()
        Me.strErrorValue = ""
    End Sub

    '=================================================================================================
    ' This function checks the supplied string (with an optional field size) for potential security
    ' risks and returns a count of the number of potential issues identified.  The string is NOT
    ' modified.
    '-------------------------------------------------------------------------------------------------
    Public Function CheckSanitize(ByVal strTextParam As String, Optional ByVal intSizeParam As Integer = 0, Optional ByVal boolEmailAddr As Boolean = False) As Integer
        Dim intLclRtnCode As Integer = 0

        Me.strErrorValue = ""
        Try
            intLclRtnCode += CheckChar(strTextParam, boolEmailAddr)
        Catch ex As Exception
        End Try
        Try
            intLclRtnCode += Me.CheckString(strTextParam)
        Catch ex As Exception
        End Try
        If intSizeParam > 0 Then
            If strTextParam.Length > intSizeParam Then
                Me.strErrorValue &= "Provided string is too long" & vbCrLf
                intLclRtnCode += 1
            End If
        End If

        Return intLclRtnCode
    End Function

    '=================================================================================================
    ' This function checks the supplied string (with an optional field size) for potential security
    ' risks and returns a count of the number of potential issues identified.  The string WILL be
    ' modified with problemmatic characters replaced with their HTML or decimal equivalent and 
    ' potentially dangerous strings of characters replaced with dummy values.  The string will also
    ' be truncated to the length provided, if necessary.
    '-------------------------------------------------------------------------------------------------
    Public Function DoSanitize(ByVal strTextParam As String, Optional ByVal intSizeParam As Integer = 0) As String

        Me.strErrorValue = ""
        If Not String.IsNullOrEmpty(strTextParam) Then
            Try
                StripChar(strTextParam)
            Catch ex As Exception
            End Try
            Try
                Me.StripString(strTextParam)
            Catch ex As Exception
            End Try
            Try
                If intSizeParam > 0 Then
                    If strTextParam.Length > intSizeParam Then
                        strTextParam = strTextParam.Substring(0, intSizeParam)
                        Me.strErrorValue &= "Provided string is too long" & vbCrLf
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
        Return strTextParam
    End Function

    '=================================================================================================
    ' This funtion checks the supplied character against a list of known potential problem characters
    ' and sets an error message accordingly, returning the number of potential problems identified.
    ' The character is NOT modified.
    '-------------------------------------------------------------------------------------------------
    Public Function CheckCharAll(ByVal strTextParam As String) As Integer
        Dim intLclRtnCode As Integer = 0

        For idx As Integer = 0 To strTextParam.Length - 1
            Select Case strTextParam.Substring(idx, 1)
                Case "|"
                    Me.strErrorValue &= "&quot;|&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "&"
                    Me.strErrorValue &= "&quot;&amp;&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ";"
                    Me.strErrorValue &= "&quot;<&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "$"
                    Me.strErrorValue &= "&quot;$&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "%"
                    Me.strErrorValue &= "&quot;%&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "@"
                    Me.strErrorValue &= "&quot;@&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "<"
                    Me.strErrorValue &= "&quot;<&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ">"
                    Me.strErrorValue &= "&quot;>&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "("
                    Me.strErrorValue &= "&quot;(&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ")"
                    Me.strErrorValue &= "&quot;)&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "+"
                    Me.strErrorValue &= "&quot;+&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ","
                    Me.strErrorValue &= "&quot;,&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "\"
                    Me.strErrorValue &= "&quot;\&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "`"
                    Me.strErrorValue &= "&quot;`&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
            End Select
        Next
        If strTextParam.Contains("%27") Then
            Me.strErrorValue &= "&quot;%27&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%29") Then
            Me.strErrorValue &= "&quot;%29&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3B") Or strTextParam.Contains("%3b") Then
            Me.strErrorValue &= "&quot;%3B&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3C") Or strTextParam.Contains("%3c") Then
            Me.strErrorValue &= "&quot;%3C&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3D") Or strTextParam.Contains("%3d") Then
            Me.strErrorValue &= "&quot;%3D&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3E") Or strTextParam.Contains("%3e") Then
            Me.strErrorValue &= "&quot;%3E&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%20") Then
            Me.strErrorValue &= "&quot;%20&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%0D") Or strTextParam.Contains("%0d") Then
            Me.strErrorValue &= "&quot;%0D&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%0A") Or strTextParam.Contains("%0a") Then
            Me.strErrorValue &= "&quot;%0A&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If

        Return intLclRtnCode
    End Function

    '=================================================================================================
    ' This funtion checks the supplied character against a list of known potential problem characters
    ' and sets an error message accordingly, returning the number of potential problems identified.
    ' Only a subset of the AppScan recommended list of characters is checked.
    ' The character is NOT modified.
    '-------------------------------------------------------------------------------------------------
    Public Function CheckChar(ByVal strTextParam As String, Optional ByVal boolEmailAddr As Boolean = False) As Integer
        Dim intLclRtnCode As Integer = 0

        For idx As Integer = 0 To strTextParam.Length - 1
            Select Case strTextParam.Substring(idx, 1)
                Case "|"
                    Me.strErrorValue &= "&quot;|&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ";"
                    Me.strErrorValue &= "&quot;<&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "@"
                    If Not boolEmailAddr Then
                        Me.strErrorValue &= "&quot;@&quot; located" & vbCrLf
                        intLclRtnCode += 1
                    End If
                    Exit Select
                Case "<"
                    Me.strErrorValue &= "&quot;<&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case ">"
                    Me.strErrorValue &= "&quot;>&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "+"
                    Me.strErrorValue &= "&quot;+&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "\"
                    Me.strErrorValue &= "&quot;\&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
                Case "`"
                    Me.strErrorValue &= "&quot;`&quot; located" & vbCrLf
                    intLclRtnCode += 1
                    Exit Select
            End Select
        Next
        If strTextParam.Contains("%27") Then
            Me.strErrorValue &= "&quot;%27&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%22") Then
            Me.strErrorValue &= "&quot;%22&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%29") Then
            Me.strErrorValue &= "&quot;%29&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%2F") Or strTextParam.Contains("%2F") Then
            Me.strErrorValue &= "&quot;%2F&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3B") Or strTextParam.Contains("%3b") Then
            Me.strErrorValue &= "&quot;%3B&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3C") Or strTextParam.Contains("%3c") Then
            Me.strErrorValue &= "&quot;%3C&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3D") Or strTextParam.Contains("%3d") Then
            Me.strErrorValue &= "&quot;%3D&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%3E") Or strTextParam.Contains("%3e") Then
            Me.strErrorValue &= "&quot;%3E&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%20") Then
            Me.strErrorValue &= "&quot;%20&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%0D") Or strTextParam.Contains("%0d") Then
            Me.strErrorValue &= "&quot;%0D&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.Contains("%0A") Or strTextParam.Contains("%0a") Then
            Me.strErrorValue &= "&quot;%0A&quot; located" & vbCrLf
            intLclRtnCode += 1
        End If

        Return intLclRtnCode
    End Function

    '=================================================================================================
    ' This function checks the provided string for inclusion of potential insecure characters and 
    ' strings of characters, setting an error message with each potential problem identified and
    ' returning the number of issues identified.  The source string is NOT modified.
    '-------------------------------------------------------------------------------------------------
    Public Function CheckString(ByVal strTextParam As String) As Integer
        Dim intLclRtnCode As Integer = 0

        If strTextParam.ToLower().Contains("drop ") Then
            Me.strErrorValue &= "possible &quot;drop&quot; statement located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("insert ") Then
            Me.strErrorValue &= "possible &quot;insert&quot; statement located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("update ") Then
            Me.strErrorValue &= "possible &quot;update&quot; statement located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("delete ") Then
            Me.strErrorValue &= "possible &quot;delete&quot; statement located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("script") Then
            Me.strErrorValue &= "possible &quot;script&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("object") Then
            Me.strErrorValue &= "possible &quot;object&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("applet") Then
            Me.strErrorValue &= "possible &quot;applet&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("embed") Then
            Me.strErrorValue &= "possible &quot;embed&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("http") Then
            Me.strErrorValue &= "possible &quot;http&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("src=") Then
            Me.strErrorValue &= "possible &quot;src=&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        If strTextParam.ToLower().Contains("<form>") Then
            Me.strErrorValue &= "possible &quot;<form>&quot; tag located" & vbCrLf
            intLclRtnCode += 1
        End If
        Return intLclRtnCode
    End Function

    '=================================================================================================
    ' This funtion checks the supplied character against a list of known potential problem characters,
    ' replacing each problem character with an appropriate character or string.
    '-------------------------------------------------------------------------------------------------
    Public Sub StripChar(ByRef strTextParam As String)
        If Not String.IsNullOrEmpty(strTextParam) Then
            strTextParam = strTextParam.Replace(";", ":")
            strTextParam = strTextParam.Replace("&", "&amp;")
            strTextParam = strTextParam.Replace("<", "&lt;")
            strTextParam = strTextParam.Replace(">", "&gt;")
            strTextParam = strTextParam.Replace("(", "")
            strTextParam = strTextParam.Replace(")", "")
            strTextParam = strTextParam.Replace("`", "&#44;")
            strTextParam = strTextParam.Replace("|", "-")
            strTextParam = strTextParam.Replace("$", "")
            strTextParam = strTextParam.Replace("%", "pct")
            strTextParam = strTextParam.Replace("@", " at ")
            strTextParam = strTextParam.Replace("+", " plus ")
        End If
    End Sub

    '=================================================================================================
    ' This function replaces each occurrance of a potential insecure string with an empty string in 
    ' the supplied character string.
    '-------------------------------------------------------------------------------------------------
    Public Sub StripString(ByRef strTextParam As String)
        If Not String.IsNullOrEmpty(strTextParam) Then
            strTextParam = strTextParam.Replace("%3B", ",")
            strTextParam = strTextParam.Replace("%3C", "&lt;")
            strTextParam = strTextParam.Replace("%3D", "")
            strTextParam = strTextParam.Replace("%3E", "&gt;")
            strTextParam = strTextParam.Replace("%3b", ",")
            strTextParam = strTextParam.Replace("%3c", "")
            strTextParam = strTextParam.Replace("%3d", "")
            strTextParam = strTextParam.Replace("%3e", "")
        End If
    End Sub

    '=================================================================================================
    ' This function replaces characters that could produce SQL Injection or Javascript injection 
    ' with harmless replacements.  The program may not function properly after the replacement but
    ' the hacking attempt will not succeed.
    '-------------------------------------------------------------------------------------------------
    Public Sub StripHTML(ByVal strTextParam As String)
        If Not String.IsNullOrEmpty(strTextParam) Then
            strTextParam = strTextParam.Replace(";", ":")
            strTextParam = strTextParam.Replace("&", "&amp;")
            strTextParam = strTextParam.Replace("<", "&lt;")
            strTextParam = strTextParam.Replace(">", "&gt;")
            strTextParam = strTextParam.Replace("(", "")
            strTextParam = strTextParam.Replace(")", "")
            strTextParam = strTextParam.Replace("--", "-")
        End If
    End Sub

    '=================================================================================================
    ' This function replaces characters that could produce SQL Injection or Javascript injection 
    ' with harmless replacements.  The program may not function properly after the replacement but
    ' the hacking attempt will not succeed.
    '-------------------------------------------------------------------------------------------------
    Public Sub StripHexValues(ByRef strTextParam As String, Optional ByVal boolAllowSpace As Boolean = False)
        If Not String.IsNullOrEmpty(strTextParam) Then
            strTextParam = strTextParam.Replace("%3B", "")       ' ;
            strTextParam = strTextParam.Replace("%26", "&amp;")   ' &
            strTextParam = strTextParam.Replace("%3C", "&lt;")    ' <
            strTextParam = strTextParam.Replace("%3D", "")        ' =
            strTextParam = strTextParam.Replace("%3E", "&gt;")    ' >
            If Not boolAllowSpace Then
                strTextParam = strTextParam.Replace("%20", "")
            End If

            strTextParam = strTextParam.Replace("%3b", "")
            strTextParam = strTextParam.Replace("%3c", "&lt;")
            strTextParam = strTextParam.Replace("%3d", "")
            strTextParam = strTextParam.Replace("%3e", "&gt;")
        End If
    End Sub

    '=================================================================================================
    ' This function replaces all dangerous characters in the provided string with safer alternatives.
    ' If a length is provided, the string is truncated to the specified length if necessary. The string
    ' returned contains any error messages encountered, but the provided string may still be modified.
    '-------------------------------------------------------------------------------------------------
    Public Function QuickClean(ByVal strTextParam As String, Optional ByVal intSizeParam As Integer = 0) As String
        Dim strLclTemp As String

        strLclTemp = strTextParam
        Try
            If Not String.IsNullOrEmpty(strLclTemp) Then
                strLclTemp = strLclTemp.Replace("\", "")
                strLclTemp = strLclTemp.Replace(";", ":")
                strLclTemp = strLclTemp.Replace("&", "&amp;")
                strLclTemp = strLclTemp.Replace("<", "&lt;")
                strLclTemp = strLclTemp.Replace(">", "&gt;")
                strLclTemp = strLclTemp.Replace("(", "")
                strLclTemp = strLclTemp.Replace(")", "")
                strLclTemp = strLclTemp.Replace("--", "-")
                strLclTemp = strLclTemp.Replace("`", "&#44;")
                strLclTemp = strLclTemp.Replace("%22", "&quot;")
                strLclTemp = strLclTemp.Replace("%27", "''")
                strLclTemp = strLclTemp.Replace("%29", "")  ' right paren
                strLclTemp = strLclTemp.Replace("%3B", ":")
                strLclTemp = strLclTemp.Replace("%3C", "&lt;")
                strLclTemp = strLclTemp.Replace("%3D", "")
                strLclTemp = strLclTemp.Replace("%3E", "&gt;")
                strLclTemp = strLclTemp.Replace("%3b", ":")
                strLclTemp = strLclTemp.Replace("%3c", "&lt;")
                strLclTemp = strLclTemp.Replace("%3d", " ")
                strLclTemp = strLclTemp.Replace("%3e", "&gt;")
                strLclTemp = strLclTemp.Replace("%0d", " ")
                strLclTemp = strLclTemp.Replace("%0a", " ")
            End If
        Catch ex As Exception
            Me.strErrorValue &= "Error replacing invalid characters" & vbCrLf
        End Try
        Try
            If intSizeParam > 0 Then
                If strLclTemp.Length > intSizeParam Then
                    strLclTemp = strLclTemp.Substring(0, intSizeParam)
                    Me.strErrorValue &= "Provided string is too long" & vbCrLf
                End If
            End If
        Catch ex As Exception
        End Try
        Return strLclTemp
    End Function

    '=================================================================================================
    '-------------------------------------------------------------------------------------------------
    Public Function CheckNumeric(ByVal strTextParam As String, Optional ByVal boolRangeParam As Boolean = False, Optional ByVal intMinParam As Integer = 0, Optional ByVal intMaxParam As Integer = 1000000) As Integer
        Dim intLclTemp As Integer = 0

        If Not String.IsNullOrEmpty(strTextParam) And IsNumeric(strTextParam) Then
            Try
                intLclTemp = CInt(strTextParam)
                If boolRangeParam Then
                    If intLclTemp < intMinParam Or intLclTemp > intMaxParam Then
                        Me.strErrorValue &= "Numeric value out of range" & vbCrLf
                    End If
                End If
            Catch ex As Exception
                Me.strErrorValue &= "Nonnumeric value detected" & vbCrLf
            End Try
        Else
            Me.strErrorValue &= "Nonnumeric value detected" & vbCrLf
        End If

        Return intLclTemp
    End Function

    '=================================================================================================
    ' This function resets the class error message to an empty string.
    '-------------------------------------------------------------------------------------------------
    Public Sub ClearError()
        Me.strErrorValue = ""
    End Sub

    '=================================================================================================
    ' Properties.
    '-------------------------------------------------------------------------------------------------
    Public Property strError() As String
        Get
            Try
                Return strErrorValue
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
        End Set
    End Property

End Class
