Imports System.Data
Imports System.Collections.Generic
Imports System.IO.Ports
Imports System.Threading

Public Class MainWinForm


    '------------------------------------------------------------------------------------------
    'COM
    '------------------------------------------------------------------------------------------
    'Public browser As ChromiumWebBrowser
    Public serialPort As SerialPort

    'Public updDA As New UpdDA
    Private Const WS_EX_NOACTIVATE As Integer = &H8000000
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_NOACTIVATE
            Return cp
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cnt As Integer

        'cnt = GetComDATA("A XXX" & vbCr & "B YYY")

        'SearchDate()

        ComNameInit()


        If Me.cbComName.Items.Count >= 2 Then
            'Me.cbComName.SelectedIndex = 1
            Me.cbComName.Text = "COM10"

            ConnectCom()
        End If

    End Sub


    '装车
    Private Sub ConnectCom()

        Try
            '设置COM参数，并且打开
            InstanceSerialPort()
            ''设置COM 关联控件状态可用
            SetControlStaus(True)

            Exit Sub
        Catch ex As Exception
            'MessageBox.Show(ex.Message)

            Try
                SetControlStaus(False)
                serialPort.Close()
            Catch ex1 As Exception

            End Try

        End Try


        Try
            '设置COM参数，并且打开
            InstanceSerialPort()
            ''设置COM 关联控件状态可用
            SetControlStaus(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '设置COM 关联控件状态
    Private Sub SetControlStaus(ByVal connectStaus As Boolean)
        Me.btnConnect.Enabled = Not connectStaus
        Me.btnStop.Enabled = connectStaus
        Me.cbComName.Enabled = Not connectStaus
        Me.comboBox_comPl.Enabled = Not connectStaus
    End Sub



    'COM PORT
    Private Sub InstanceSerialPort()
        serialPort = New SerialPort()
        serialPort.PortName = Me.cbComName.Text
        serialPort.BaudRate = Convert.ToInt32(Me.comboBox_comPl.Text)
        serialPort.Parity = Parity.None
        serialPort.StopBits = StopBits.One
        serialPort.DataBits = 8
        serialPort.DiscardNull = True
        AddHandler serialPort.DataReceived, AddressOf serialPort_DataReceived
        serialPort.Open()
    End Sub

    '扫描数据事件
    Private Sub serialPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Thread.Sleep(600)
            Dim serialPort As SerialPort = CType(sender, SerialPort)
            Dim threadReceiveSub As Thread = New Thread(New ParameterizedThreadStart(AddressOf ReceiveData))
            threadReceiveSub.Start(serialPort)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '接受扫描数据
    Private Sub ReceiveData(ByVal serialPortobj As Object)
        Try
            Dim serialPort As SerialPort = CType(serialPortobj, SerialPort)

            Dim str As String = serialPort.ReadExisting()

            If str = String.Empty Then
                Return
            Else
                SetMessage(str)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    '扫描枪扫描事件
    Private Sub SetMessage(ByVal msg As String)
        Me.Invoke(New Action(Sub()

                                 'Me.Text = (msg)
                                 Dim cnt As Integer
                                 cnt = GetComDATA(msg)
                                 'SearchDate()
                                 'SendKeys.SendWait("{F8}")
                                 'Thread.Sleep(400)
                                 'SendKeys.Send(msg)
                                 sWaitTime(100)

                             End Sub))


    End Sub

    Private Sub sWaitTime(ByVal st As Long)
        '指定の時間待つ（1/1000 秒単位で指定)
        Dim lngSt As Long
        'システム起動後のミリ秒単位の経過時間を取得します。
        'システムが 24.9 日間稼動し続けた場合、この経過時間は 0 に戻ります。
        lngSt = System.Environment.TickCount
        Do While System.Environment.TickCount - lngSt < st
            'メッセージ キューに現在ある Windows メッセージをすべて処理します
            Application.DoEvents()              'こちらだけではCPUの使用率が100％になる
            '指定した時間だけ現在のスレッドを中断します。
            System.Threading.Thread.Sleep(10)   'これだけでは他の処理を受け付けない
        Loop
    End Sub
    'COM LIST
    Private Sub ComNameInit()
        Me.btnConnect.Enabled = True
        Me.btnStop.Enabled = False
        cbComName.Items.Clear()
        Me.cbComName.Items.Add("请选择COM口")
        For Each portName As String In System.IO.Ports.SerialPort.GetPortNames()
            Me.cbComName.Items.Add(portName)
        Next
    End Sub

    'Public Sub SearchDate()

    '    Dim mainDt As DataTable = updDA.GetMainData()

    '    If mainDt.Rows.Count > 0 Then
    '        gvMainData.DataSource = mainDt
    '        gvMainData.Visible = True
    '    Else
    '        gvMainData.Visible = False

    '    End If

    'End Sub

    Public Function GetComDATA(ByVal signAndValues As String) As Integer
        Dim rowsCnt As Integer
        Dim arrSignAndValues As String()
        Dim tmpSignAndValue As String()
        Dim tmpSign As String
        Dim tmpValue As String
        Dim strComputer As String

        rowsCnt = 0
        strComputer = Environment.MachineName
        'signAndValues = signAndValues & vbCr & " Y +0019.22"
        arrSignAndValues = signAndValues.Split(vbCr)
        pBtns.Controls.Clear()

        Dim cnt As Integer = 0
        Dim value As String = ""

        For i As Integer = 0 To arrSignAndValues.Count - 1
            If arrSignAndValues(i).Trim <> "" Then
                cnt = cnt + 1
                value = arrSignAndValues(i).Trim
                Dim btn As New Button
                pBtns.Controls.Add(btn)
                btn.Dock = DockStyle.Top
                btn.Text = arrSignAndValues(i).Trim
                btn.Font = New Font(Me.Font.Name, 30)
                btn.Height = 45
                AddHandler btn.Click, AddressOf mybutton_Click
            End If
        Next

        If cnt = 1 Then
            Try
                Dim txt As String = GetNumbers(value)
                SendKeys.Send(Math.Round(Convert.ToDecimal(txt) + 0.00000000001, 2))
                sWaitTime(500)
                SendKeys.SendWait("{ENTER}")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If



        'If arrSignAndValues.Count > 0 Then

        '    For i As Integer = 0 To arrSignAndValues.Count - 1

        '        tmpSignAndValue = arrSignAndValues(i).Split(" ")
        '        tmpSign = ""
        '        tmpValue = ""

        '        If tmpSignAndValue.Count = 1 Then
        '            tmpSign = tmpSignAndValue(0)

        '        ElseIf tmpSignAndValue.Count = 2 Then
        '            tmpSign = tmpSignAndValue(0)
        '            tmpValue = tmpSignAndValue(1)

        '        End If

        '        'rowsCnt = rowsCnt + updDA.InsMainData(Me.cbComName.SelectedText, tmpSign, tmpValue, strComputer)

        '    Next

        'End If

        Return rowsCnt

    End Function

    Private Sub mybutton_Click(sender As Object, e As EventArgs)
        Dim btn As Button
        btn = CType(sender, Button)

        Try
            Dim txt As String = GetNumbers(btn.Text)
            SendKeys.Send(Math.Round(Convert.ToDecimal(txt) + 0.00000000001, 2))
            sWaitTime(500)
            SendKeys.SendWait("{ENTER}")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Function GetNumbers(ByVal strp As String) As String
        Dim strReturn As String = String.Empty
        If strp Is Nothing OrElse strp.Trim() = "" Then
            strReturn = ""
        End If
        For Each chrTemp As Char In strp
            If [Char].IsNumber(chrTemp) Or chrTemp = "." Then
                strReturn += chrTemp.ToString()
            End If
        Next
        Return strReturn
    End Function

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ConnectCom()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Try
            SetControlStaus(False)
            serialPort.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
