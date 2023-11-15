Imports Microsoft.VisualBasic
Imports System.Security.Principal
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Public Class AccessSharedPath
    Implements IDisposable

    Private _impersonationContext As WindowsImpersonationContext

    Public Sub New(ByVal userName As String, ByVal domain As String, ByVal password As String)
        Dim tokenHandle As IntPtr = IntPtr.Zero

        ' 使用指定用户的凭据登录，获取访问令牌
        Dim success As Boolean = LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, tokenHandle)
        If Not success Then
            Throw New Win32Exception(Marshal.GetLastWin32Error())
        End If

        ' 创建 WindowsIdentity 对象，表示模拟用户的身份
        Dim impersonatedUser As New WindowsIdentity(tokenHandle)

        ' 创建 WindowsImpersonationContext 对象，表示模拟用户的身份上下文
        _impersonationContext = impersonatedUser.Impersonate()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 结束模拟用户的身份
        If _impersonationContext IsNot Nothing Then
            _impersonationContext.Undo()
        End If
    End Sub

    Private Const LOGON32_LOGON_INTERACTIVE As Integer = 2
    Private Const LOGON32_PROVIDER_DEFAULT As Integer = 0

    <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Private Shared Function LogonUser(ByVal lpszUserName As String, ByVal lpszDomain As String, ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Boolean
    End Function
End Class
