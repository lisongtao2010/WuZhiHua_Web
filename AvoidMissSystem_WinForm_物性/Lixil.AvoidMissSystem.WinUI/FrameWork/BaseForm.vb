Imports System.Configuration
Imports System.Reflection
Imports System.Threading
Imports System.ComponentModel
Imports Lixil.AvoidMissSystem.WinUI.Common
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
'Imports Lixil.AvoidMissSystem.WinUI.CustomTextBox

''' <summary>
''' ベースフォームクラス
''' </summary>
''' <remarks></remarks>
Public Class BaseForm
    'Dim TargetName As String = "DummyKeybord" '存储进程名为文本型，注：进程名不加扩展名
    Public Login As LoginInfo '登录信息
    Dim listener As TcpListener

#Region "画面"

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitializeComponent()

        If State.ContainsKey("LoginInfo") = False Then
            '不存在LoginInfo的时候
            Login = New LoginInfo
        Else
            Login = DirectCast(State.Item("LoginInfo"), LoginInfo)
        End If
    End Sub

    ''' <summary>
    ''' 画面关闭
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '本机作为服务器时关闭
        'Me.CancelConnectToServer()
        'Me.CloseServer()
    End Sub

    ''' <summary>
    ''' 登录值设定
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="userName"></param>
    ''' <param name="authority"></param>
    ''' <remarks></remarks>
    Public Sub SetLoginInfo(ByVal userId As String, ByVal userName As String, ByVal authority As ArrayList)
        Login.UserId = userId
        Login.UserName = userName
        Login.Authority = authority
    End Sub

    ''' <summary>
    ''' 登录值清空
    ''' </summary>
    Public Sub ClearLoginInfo()
        Login.UserId = String.Empty
        Login.UserName = String.Empty
        Login.Authority.Clear()
    End Sub

    ''' <summary>
    ''' 指定された画面に遷移します
    ''' </summary>
    ''' <param name="nextPage"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub NavigateToNextPage(ByVal nextPage As String)
        If State.ContainsKey("LoginInfo") = True Then
            State.Remove("LoginInfo")
        End If
        Me.State.Add("LoginInfo", Login)

        ' 構成ファイルから画面情報を取得
        Dim pageSection As PageNavigationSection _
                = CType(ConfigurationManager.GetSection("pageNavigationSection"), PageNavigationSection)

        Dim def As PageDefinition = pageSection.Pages(nextPage)


        Dim assem As Assembly = Nothing
        If def.AssemblyName = Nothing OrElse def.AssemblyName = String.Empty Then
            assem = Assembly.GetExecutingAssembly()
        Else
            assem = Assembly.Load(def.AssemblyName)
        End If

        Dim nextForm As Form = CType(assem.CreateInstance(def.FormName), Form)

        If IsNothing(nextForm) Then
            ' エラーにする
        End If

        nextForm.StartPosition = FormStartPosition.Manual
        nextForm.Location = Me.Location

        '本机作为服务器时关闭
        Me.CloseServer()

        nextForm.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' 複数の画面間で共有されるデータを保持するHashtableを返します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property State() As Hashtable
        Get
            Return StateManager.Instance.State
        End Get
    End Property

    Public Sub TaskKill(ByVal target As String)
        On Error GoTo Errmessages  '在做系统操作时加排错标签是个好习惯

        Dim TargetKill() As Process = Process.GetProcessesByName(target) '从进程名获取进程
        Dim TargetPath As String  '存储进程路径为文本型
        If TargetKill.Length > 1 Then  '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
            For i As Integer = 0 To TargetKill.Length - 1
                TargetPath = TargetKill(i).MainModule.FileName
                TargetKill(i).Kill()
            Next
        ElseIf TargetKill.Length = 0 Then  '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
            'MsgBox("没有发现进程！")
            Exit Sub
        ElseIf TargetKill.Length = 1 Then  '判断进程名的数量，如果只有一个，就不用For循环
            TargetKill(0).Kill()
        End If
        'MsgBox("已终止" & TargetKill.Length & "个进程") '弹窗提示已终止多少个进程

Errmessages:  '定义排错标签
        If Err.Description <> Nothing Then  '判断有无错误，如果有，则 ↓
            MsgBox(Err.Description) '当出现错误时，弹窗提示
        End If
    End Sub

    'Public Sub ShowKeybord()
    '    'Dim pid As Long = Shell(TargetName, AppWinStyle.MaximizedFocus)
    '    TaskKill(TargetName)
    '    Dim myProcess As Process = System.Diagnostics.Process.Start(TargetName)
    'End Sub

    Private Sub BaseForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '本机作为服务器时关闭
        'Me.CancelConnectToServer()
        Me.CloseServer()
        'TaskKill(TargetName)
        ClosePicture()
    End Sub

    ''' <summary>
    ''' 关闭图片
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClosePicture()
        Dim frmName As String = "frmMaxPicture"

        '如果图 片放大窗口已经 打开 了，那么 先关 ?掉
        Try
            For Each myForm As Form In Application.OpenForms

                If myForm.Name = frmName Then
                    myForm.Close()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' 判断键盘是否在运行
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsKeybordRun() As Boolean
        '        On Error GoTo Errmessages  '在做系统操作时加排错标签是个好习惯

        '        Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
        '        Dim TargetPath As String  '存储进程路径为文本型
        '        If TargetKill.Length >= 1 Then
        '            Return True
        '        ElseIf TargetKill.Length = 0 Then
        '            Return False
        '        End If

        'Errmessages:  '定义排错标签
        '        If Err.Description <> Nothing Then  '判断有无错误，如果有，则 ↓
        '            MsgBox(Err.Description) '当出现错误时，弹窗提示
        '        End If
    End Function

    ''' <summary>
    ''' 打开COM口
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenSerialPort()
        Dim myProcess As Process = System.Diagnostics.Process.Start("ComToTcpProgram")
    End Sub

    ''' <summary>
    ''' 关闭COM口
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseSerialPort()
        TaskKill("ComToTcpProgram")
    End Sub
#End Region

#Region "Server 用于接收从别的电脑接收到的信息"

    '监听接收数据线程
    Dim myThread As Thread
    Public _sendToPort As String = "5400"
    ''' <summary>
    ''' 发送先IP端口号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SendToPort() As String
        Get
            Return _sendToPort
        End Get
        Set(ByVal value As String)
            _sendToPort = value
        End Set
    End Property

    Public _serialPortData As String
    ''' <summary>
    ''' 扫描到的数据
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SerialPortData() As String
        Get
            Return _serialPortData
        End Get
        Set(ByVal value As String)
            _serialPortData = value
        End Set
    End Property

    ''' <summary>
    ''' 打开服务器
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenServer()
        myThread = New Thread(AddressOf Listen)
        myThread.Start()
    End Sub

    ''' <summary>
    ''' 监听
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Listen()
        Dim done As Boolean = False

        ' IPEndPoint类将网络标识为IP地址和端口号
        listener = New TcpListener(New IPEndPoint(IPAddress.Any, CInt(Me.SendToPort)))

        listener.Start()

        While Not done
            Dim client As TcpClient = listener.AcceptTcpClient()
            Dim ns As NetworkStream = client.GetStream()
            Dim bytes() As Byte = New [Byte](1024) {}
            Dim bytesRead As Integer
            Dim data As String = String.Empty

            Try
                bytesRead = ns.Read(bytes, 0, bytes.Length)

                '将字节流解码为字符串
                data = Encoding.ASCII.GetString(bytes, 0, bytesRead)

                '引发事件
                SerialPortData = data
                Dim ea As New EventArgsSD
                ea.data = data
                '引发事件
                Dim synchronizer As ISynchronizeInvoke = Me
                If synchronizer.InvokeRequired = True Then
                    '如果不能直接访问该控件，用Invoke
                    Dim threadSafeDelegate As New OnTcpReceiveDataDelegate(AddressOf RaiseEventForOnTcpReceiveData)
                    Me.Invoke(threadSafeDelegate, ea)
                Else
                    RaiseEventForOnTcpReceiveData(ea)
                End If

                ns.Close()
                client.Close()
            Catch ex As Exception
                ns.Close()
                client.Close()
                done = True
                'MessageBox.Show(ex.Message, "接受TCP数据异常", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        End While
    End Sub

    ''' <summary>
    ''' 关闭服务器
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseServer()
        Try

            If myThread IsNot Nothing Then
                myThread.Abort()
            End If

            If listener IsNot Nothing Then
                listener.Stop()

            End If
        Finally

        End Try
    End Sub

#End Region

#Region "其他"
    ''' <summary>
    ''' 注册一个TCP接受数据事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event OnTcpReceiveData(ByVal sender As Object, ByVal e As EventArgsSD)

    ''' <summary>
    ''' 声明一个委托
    ''' </summary>
    ''' <param name="ea"></param>
    ''' <remarks></remarks>
    Public Delegate Sub OnTcpReceiveDataDelegate(ByVal ea As EventArgsSD)
    ''' <summary>
    ''' 触发事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseEventForOnTcpReceiveData(ByVal ea As EventArgsSD)
        RaiseEvent OnTcpReceiveData(Me, ea)
    End Sub

    ''' <summary>
    ''' 显示发 大图     
    ''' </summary>
    ''' <param name="picture"></param>
    ''' <remarks></remarks>
    Public Sub ShowMaxPicture(ByVal picture As Image)

        Try
            Dim frmMaxImage As Form
            Dim maxPictureBox As PictureBox
            Dim frmName As String = "frmMaxPicture"

            '如果图 片放大窗口已经 打开 了，那么 先关 ?掉
            CloseMaxImage(Me, EventArgs.Empty)

            frmMaxImage = New Form '新建立一个form窗口
            maxPictureBox = New PictureBox '新建立一个图 片显 示控件
            frmMaxImage.Name = frmName
            With picture
                frmMaxImage.Width = .Width
                frmMaxImage.Height = .Height + 36
                maxPictureBox.Width = .Width
                maxPictureBox.Height = .Height
            End With
            maxPictureBox.Image = picture '设置图 片显 示控件的图 片，来自形参
            frmMaxImage.Controls.Add(maxPictureBox) '将图 片控件加入到form窗口中

            AddHandler frmMaxImage.LostFocus, AddressOf CloseMaxImage 'form失去焦点后关闭大图

            frmMaxImage.Show() '显示form窗口
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' 关闭大图
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseMaxImage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frmName As String = "frmMaxPicture"
        Try
            For Each myForm As Form In Application.OpenForms

                If myForm.Name = frmName Then
                    myForm.Close()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class

Public Class EventArgsSD
    Inherits EventArgs

    Public data As String
End Class