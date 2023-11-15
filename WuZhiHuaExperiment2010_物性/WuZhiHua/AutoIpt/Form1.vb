Imports System.IO
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class Form1

    <DllImportAttribute("User32.dll")>
    Private Shared Function FindWindow(ByVal ClassName As String, ByVal WindowName As String) As Integer

    End Function
    Private Const WS_EX_NOACTIVATE As Integer = &H8000000
        Private Const WS_EX_TOOLWINDOW As Integer = &H80
        Private Const GWL_EXSTYLE As Integer = -20

    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
        Return If(Environment.Is64BitProcess, GetWindowLong64(hWnd, nIndex), GetWindowLong32(hWnd, nIndex))
    End Function

    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As IntPtr
        Return If(Environment.Is64BitProcess, SetWindowLong64(hWnd, nIndex, dwNewLong), SetWindowLong32(hWnd, nIndex, dwNewLong))
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")>
    Private Shared Function GetWindowLong32(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr

    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowLongPtr")>
    Private Shared Function GetWindowLong64(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr

    End Function
    <DllImport("user32.dll", EntryPoint:="SetWindowLong")>
    Private Shared Function SetWindowLong32(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As IntPtr

    End Function
    <DllImport("user32.dll", EntryPoint:="SetWindowLongPtr")>
    Private Shared Function SetWindowLong64(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As IntPtr

    End Function

    Public strDirName As String
        Public watchingTime As Long
        Public counter As Long
        Public blnFolderUpdated As Boolean
        Public dirs1 As String()
    Public dirs2 As String()

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE
            Return cp
        End Get
    End Property


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
            Process.GetCurrentProcess.Kill()
            Timer1.Stop()
        End If

        strDirName = ConfigurationManager.AppSettings("WatchingFolder").ToString()
        watchingTime = CLng(ConfigurationManager.AppSettings("WatchingTime").ToString())

        Timer1.Start()

    End Sub



    Private Sub InitializeTimer()
        counter = 0
        blnFolderUpdated = False
        Timer1.Enabled = True
        Timer1.Interval = 1000
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim dir1 As String
        Dim dir2 As String
        Dim blnExist As Boolean

        counter = counter + 1

        If counter = 1 Then
            dirs1 = Directory.GetFiles(strDirName, "*.*", SearchOption.AllDirectories)

        Else
            dirs2 = Directory.GetFiles(strDirName, "*.*", SearchOption.AllDirectories)

            Try
                For Each dir2 In dirs2

                    blnExist = False

                    For Each dir1 In dirs1

                        If dir2 = dir1 Then
                            blnExist = True
                            Exit For
                        End If

                    Next

                    If blnExist = False Then

                        'Dim fs As New FileStream("d:\log2.txt", FileMode.Append)
                        'Dim sw As New StreamWriter(fs)

                        Dim sr As StreamReader = New StreamReader(dir2)
                        Dim strText As String
                        Dim arrText As String()

                        'sw.WriteLine(Now() & Microsoft.VisualBasic.vbTab & " 创建 " & dir2)

                        'sw.Close()
                        'fs.Close()

                        strText = sr.ReadToEnd()
                        If strText <> Nothing Then
                            arrText = strText.Split(",")

                            Me.TopMost = True
                            Me.Focus()

                            'TextBox1.Text = ""
                            'TextBox1.Visible = True
                            'TextBox1.Focus()

                            For i As Integer = 0 To arrText.Length - 1
                                If arrText(i) <> "" Then
                                    SendKeys.Send(arrText(i))
                                    SendKeys.Send("{ENTER}")
                                End If
                            Next

                            blnFolderUpdated = True
                            Timer1.Stop()

                        End If

                        sr.Close()
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

            dirs1 = dirs2
        End If

        If counter > watchingTime And blnFolderUpdated = False Then
            Timer1.Stop()
        End If

    End Sub
End Class
