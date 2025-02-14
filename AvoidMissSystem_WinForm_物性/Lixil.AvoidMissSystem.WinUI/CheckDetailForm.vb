Imports System.Threading
Imports System.Transactions
Imports Lixil.AvoidMissSystem.BizLogic
Imports Lixil.AvoidMissSystem.Utilities
Imports Lixil.AvoidMissSystem.Utilities.Consts
Imports Lixil.AvoidMissSystem.Utilities.MsgConst
Imports System.IO
Imports System.Configuration

Public Class CheckDetailForm

#Region "变量声明"


    Public MS_Font_Size As Integer = CInt(ConfigurationManager.AppSettings("CheckDetail_MSFontSize").ToString())
    Public MS_MSLableFontFamily As String = (ConfigurationManager.AppSettings("CheckDetail_MSLableFontFamily").ToString())
    Public MS_MSButtonFontFamily As String = (ConfigurationManager.AppSettings("CheckDetail_MSButtonFontFamily").ToString())




    Private NG_BackColor As Color = Color.LightCoral
    Private KeyBoardButtonBackcolor As Color = Color.LightCoral
    Private KeyBoardMouseDownColor As Color = Color.LawnGreen


    'BC层实体化
    Dim bc As New CheckBizLogic
    Dim bcCom As New CommonBizLogic

    '主Form
    Public mainFm As CheckMainForm
    '接值信息类
    Private ReceiveInfo As CheckInfo

    '商品code
    Private strGoodsCd As String = String.Empty
    '商品作番
    Private strMakeNo As String = String.Empty
    '检查结果ID 
    Private strChkResultId As String = String.Empty
    '主页面传来的分类code
    Private strClsCd As String = String.Empty
    '种类Code
    Private strKindCd As String = String.Empty
    '分类名称
    Private strClsName As String = String.Empty
    '治具ID
    Private strToolId As String = String.Empty

    '图片ID
    Private strPicID As String = String.Empty

    '检查详细信息
    Dim dicCheckResultInfo As New Dictionary(Of String, Hashtable)
    '检查类型信息
    Dim dicTypeInfo As New Dictionary(Of String, List(Of String))

    '图片
    Private img As Image
    '第一个类型名称
    Private strFirstTypeName As String = String.Empty
    '商品ID
    Private strGoodsId As String = String.Empty

    '检查最终结果（返回主页面是用）
    Private strChkResult As String = String.Empty

    '分类的种类（返回主页面是用）
    Private strClassifyType As String = String.Empty
    '微欠点计数
    Dim intSDno As Integer = 0
    '合格但须警告计数
    Dim intOWno As Integer = 0
    '轻中重欠品计数
    Dim intMDno As Integer = 0
    '不合格计数
    Dim intNGno As Integer = 0
    '漏检计数
    Dim intINITno As Integer = 0
    'flg 是否是最后一个类型下的页面
    Dim flgLastType As Integer = Flag.OFF
    '最后一个类型的Name
    Dim strLastTyName As String = String.Empty
    '下一个类型的Name
    Dim strNextType As String = String.Empty
    '类型List
    Dim lstType As New List(Of String)

#End Region
#Region "Common"

    Public Function GetActiveRowIndex() As Integer
        Return Me.TabPal.GetRow(Me.ActiveControl)

        '  Me.TabPal.getco()
    End Function



#End Region
#Region "小键盘制作"


    Public Function GetKeybordButton(ByVal txt As String) As Label
        Dim btn As New Label
        btn.TextAlign = ContentAlignment.MiddleCenter
        'If txt = "合格" OrElse txt = "back" OrElse txt = "不合格" Then
        '    btn.Height = 72
        'Else
        '    btn.Height = 67
        'End If
        btn.Height = 68
        btn.Width = 68
        btn.BorderStyle = BorderStyle.FixedSingle
        btn.Text = txt
        btn.TabStop = True
        btn.Cursor = Cursors.Hand
        btn.Padding = New Padding(3, 3, 3, 3)
        btn.BackColor = KeyBoardButtonBackcolor
        'btn.FlatStyle = FlatStyle.System
        btn.ForeColor = Color.Black
        If txt.Length <> 1 Then
            btn.Font = New Font(MS_MSButtonFontFamily, 13, FontStyle.Regular)
        Else
            btn.Font = New Font(MS_MSButtonFontFamily, 24, FontStyle.Regular)
        End If

        Dim m_path As System.Drawing.Drawing2D.GraphicsPath
        m_path = New System.Drawing.Drawing2D.GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        m_path.AddEllipse(1, 1, 66, 66)
        btn.Region() = New Region(m_path)
        Return btn
    End Function

    Public Sub GetNextCombox()
        Try
            Dim r As Integer = GetActiveRowIndex()
            Dim ct As Control
            For Each ct In Me.TabPal.Controls
                If r = Me.TabPal.GetRow(ct) Then
                    If (TypeOf ct Is CustomDropdownList) Then
                        ct.Focus()
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetKeyBoard()

        '小键盘的键值
        'Dim keystr As String = "blank,backspace,enter,0,1,2,3,4,5,6,7,8,9,.,%,*,/,-,+,=,<,>,\,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,:,;,',"",(,)"
        Dim keys() As String = ("合格,back,不合格,微,7,8,9,轻,4,5,6,中,1,2,3,重,.,0,enter,警告").Split(","c)

        Dim idx As Integer = 0
        For row As Integer = 0 To 4
            For col As Integer = 0 To 3
                If idx <= keys.Length - 1 Then
                    Dim btn As Label = GetKeybordButton(keys(idx))
                    Me.TableLayoutPanelInput.Controls.Add(btn, col, row)
                    AddHandler btn.Click, AddressOf KeyPressEvent
                    idx += 1
                Else
                    Exit Sub
                End If

            Next
        Next

    End Sub

    Public Sub KeyPressEvent(ByVal sender As Object, ByVal e As System.EventArgs)

        kariKeyKbn = True

        DirectCast(sender, Label).BackColor = KeyBoardMouseDownColor

        Dim strWord As String = DirectCast(sender, Label).Text

        Select Case strWord
            Case "合格"
                GetNextCombox()
                SendKeys.Send("0")
                kariKeyKbn = False

            Case "不合格"
                GetNextCombox()
                SendKeys.Send("1")
                kariKeyKbn = False
            Case "微"
                GetNextCombox()
                SendKeys.Send("2")
                kariKeyKbn = False
            Case "轻"
                GetNextCombox()
                SendKeys.Send("3")
                kariKeyKbn = False
            Case "中"
                GetNextCombox()
                SendKeys.Send("3")
                kariKeyKbn = False
            Case "重"
                GetNextCombox()
                SendKeys.Send("3")
                kariKeyKbn = False

            Case "警告"
                GetNextCombox()
                SendKeys.Send("4")
                kariKeyKbn = False
            Case "blank"
                SendKeys.Send(" ")
            Case "back"
                SendKeys.Send("{backspace}")
            Case "enter"
                SendKeys.Send("{" & strWord & "}")
            Case "SHIFT"
                For Each ctrl As Object In DirectCast(sender, Label).Parent.Controls
                    If ctrl.GetType Is GetType(Label) AndAlso DirectCast(ctrl, Label).Text.Length = 1 Then

                        If ToLowerKbn Then
                            DirectCast(ctrl, Label).Text = DirectCast(ctrl, Label).Text.ToUpper

                        Else
                            DirectCast(ctrl, Label).Text = DirectCast(ctrl, Label).Text.ToLower

                        End If
                    End If
                Next

                ToLowerKbn = Not ToLowerKbn

            Case Else
                'SendKeys.Send(strWord)
                SendKeys.Send("{" & strWord & "}")
                SendKeys.Flush()
        End Select

        System.Threading.Thread.Sleep(50)
        DirectCast(sender, Label).BackColor = KeyBoardButtonBackcolor

    End Sub

#End Region


#Region "系统响应事件 Load Close"
    Protected Overrides Sub OnNotifyMessage(ByVal m As Message)
        If (m.Msg <> &H14) Then
            MyBase.OnNotifyMessage(m)
        End If
    End Sub

    '防止画面闪动
    Private Sub StopPageShandong()
        '双缓冲 明细闪动
        TabPal.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic).SetValue(TabPal, True, Nothing)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    ''' <summary>
    ''' 重写构造函数，接值（检查信息）
    ''' </summary>
    ''' <param name="mainForm"></param>
    ''' <param name="CheckInfo"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mainForm As CheckMainForm, ByVal CheckInfo As CheckInfo, ByVal strType As String)

        '继承构造函数
        InitializeComponent()

        '双缓冲 '双缓冲 禁止 明细闪动
        DoubleBuffered = False
        StopPageShandong()

        '小键盘按下判断初始化 ，True的场合 不触发失去焦点事件
        kariKeyKbn = False

        '分类code赋值
        ReceiveInfo = CheckInfo

        '主Form赋值
        mainFm = mainForm

        '分类的种类
        strClassifyType = strType

        'Com口打开
        Me.LOpen()

        '页面初始化
        Init()

    End Sub

    ''' <summary>
    ''' 用户点击系统关闭按钮处理事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckDetailForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ChkFinish() = True Then
            '关闭COM
            Me.LClose()
            '关闭当前窗口
            mainFm.callback(Me.strClsCd, Me.strChkResult, Me.strClassifyType)
            '继续关闭
            e.Cancel = False
        Else
            Panel1.Focus()
            SendKeys.Send("{TAB}")
            '停止关闭
            e.Cancel = True
        End If


    End Sub

    ''' <summary>
    ''' PageLoad
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckDetailForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '标题
        Me.Text = "检查详细"

        'Form宽度和名称设置()
        Me.Width = 1270
        Me.Height = 750
        Me.Location = New Point(2, 2)

        '标头显示
        showTitle()

        '小键盘制作
        SetKeyBoard()

    End Sub

    'Public Event KeyPressEvent(ByVal sender As Object, ByVal e As System.EventArgs)
    '如果是小键盘按钮按下 ，那么不触发失去焦点事件
    Public Shared kariKeyKbn As Boolean = False
    Public Shared ToLowerKbn As Boolean = True

#End Region

#Region "画面按钮相应事件"

    ''' <summary>
    ''' 返回按钮按下处理事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'Flg变更
        Me.flgLastType = Flag.ON
        '检查完了确认
        ' ChkFinish()
        Me.Close()
    End Sub

#End Region

#Region "内部调用方法"

    ''' <summary>
    ''' 页面初始化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Init()

        '数值本地化

        '商品code
        strGoodsCd = mainFm.strGoodsCode
        '商品ID
        Me.strGoodsId = mainFm.strGoodsID
        '商品作番
        strMakeNo = mainFm.strMakeNo
        '检查结果ID 
        strChkResultId = mainFm.strReulstID
        '主页面传来的分类code
        strClsCd = ReceiveInfo.ClassifyCd
        '种类Code
        strKindCd = ReceiveInfo.KindCd
        '分类名称
        strClsName = ReceiveInfo.ClassifyName
        '治具ID
        strToolId = ReceiveInfo.ToolsID
        '图片ID
        strPicID = ReceiveInfo.PictureCode

        '检查详细信息
        dicCheckResultInfo.Clear()
        '检查类型信息
        dicTypeInfo.Clear()

        '图片
        img = Nothing

        '第一个类型名称
        strFirstTypeName = String.Empty
        '检查最终结果（返回主页面是用）
        strChkResult = String.Empty
        'flg 是否是最后一个类型下的页面
        flgLastType = Flag.OFF
        '最后一个类型的Name
        strLastTyName = String.Empty
        strNextType = String.Empty
        '类型List清空
        Me.lstType.Clear()
        '计数清零
        Me.intMDno = 0
        Me.intNGno = 0
        Me.intOWno = 0
        Me.intSDno = 0
        Me.intINITno = 0

        SetJieguo(ReceiveInfo.CheckResult.ToString.Equals(CheckResult.OK))

        '根据分类code取得相关数据
        getChkDetailData()
        '画面显示
        allShow()
    End Sub

    '整体检查结果设定
    Private Sub SetJieguo(ByVal ok As Boolean)

        If ok Then
            Me.lblResult.Text = "结果：合格"
            Me.lblResult.BackColor = Color.LightGreen
            'Me.AllJieguo.Text = "结果：合格"
            'Me.AllJieguo.BackColor = Color.LightGreen


        Else
            Me.lblResult.Text = "结果：不合格"
            Me.lblResult.BackColor = NG_BackColor
            'Me.AllJieguo.Text = "结果：不合格"
            'Me.AllJieguo.BackColor = NG_BackColor
        End If
    End Sub

#End Region

#Region "数据取得"

    ''' <summary>
    ''' 数据取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getChkDetailData()
        '数据保存Hashtable
        Dim hsSearch As New Hashtable
        '临时变量
        'Dim hsTemp As New Hashtable
        Dim lstTemp As New List(Of String)
        'Dim strTypeCd As String = String.Empty
        '1 商品id
        hsSearch.Add("goods_id", Me.strGoodsId)
        '2 种类code
        hsSearch.Add("kind_cd", Me.strKindCd)
        '3 结果ID
        hsSearch.Add("result_id", Me.strChkResultId)
        '4 分类code
        hsSearch.Add("classify_id", Me.strClsCd)
        '5 治具ID
        hsSearch.Add("tools_id", Me.strToolId)

        '从m_check t_result_detail取得数据
        Dim dtChkDetail As DataTable = bc.GetChkDetailInfo(hsSearch).Tables("CheckDetailInfo")

        Dim rowCount As Integer = dtChkDetail.Rows.Count

        If rowCount > 0 Then

            '第一个类型名称
            Me.strFirstTypeName = dtChkDetail.Rows(0).Item("mei").ToString
            'strTypeCd = Me.strFirstTypeName
            For i As Integer = 0 To rowCount - 1

                '检查Id处理。原因：一位存在相同的检查ID在详细表中的对应多条结果的场合，在造成在dictionary中key值重复
                '现在在存储的检查项目Id变更为：检查项目ID + / +详细表的表示顺(默认为"1")

                Dim strChkId_disNo As String = dtChkDetail.Rows(i).Item("id").ToString + "/" + dtChkDetail.Rows(i).Item("dis_no").ToString

                Dim mei As String = dtChkDetail.Rows(i).Item("mei").ToString

                '检查项目ID储存
                lstTemp.Add(strChkId_disNo) 'ID / dis_no

                '如果是最后一行 ，或者 次行和本行的 mei 不同
                '那么追加信息到 DIC中
                If i = rowCount - 1 OrElse _
                    mei <> _
                    dtChkDetail.Rows(i + 1).Item("mei").ToString Then

                    '类型信息保存
                    dicTypeInfo.Add(mei, lstTemp)
                    '记忆当前类型临时变量改变
                    lstType.Add(mei)

                    'strTypeCd = dtChkDetail.Rows(i).Item("mei").ToString

                    If i = rowCount - 1 Then
                        '最后一行
                        Me.strLastTyName = dtChkDetail.Rows(rowCount - 1).Item("mei").ToString
                    Else
                        '检查项目ID临时储存List清空
                        lstTemp = Nothing
                        lstTemp = New List(Of String)
                    End If

                End If



                ''类型判断
                ''dicTypeInfo： 如果类型名称发生变化，那么把这个类型包含的DisNo保存起来
                'If Not strTypeCd.Equals(dtChkDetail.Rows(i).Item("mei").ToString) Then
                '    '类型变化的场合
                '    '类型信息保存
                '    dicTypeInfo.Add(strTypeCd, lstTemp)
                '    '记忆当前类型临时变量改变
                '    lstType.Add(strTypeCd)

                '    strTypeCd = dtChkDetail.Rows(i).Item("mei").ToString
                '    '检查项目ID临时储存List清空
                '    lstTemp = Nothing
                '    lstTemp = New List(Of String)

                'End If



                ''最后一个分类保存
                'If i = dtChkDetail.Rows.Count - 1 Then
                '    '类型信息保存
                '    dicTypeInfo.Add(strTypeCd, lstTemp)
                '    lstType.Add(strTypeCd)
                '    Me.strLastTyName = strTypeCd
                'End If

                '记忆检查项目详细信息HashTable清空
                Dim hsTemp As New Hashtable
                '分类Code
                hsTemp.Add("mei_cd", dtChkDetail.Rows(i).Item("mei_cd").ToString)
                '分类名称
                hsTemp.Add("mei", dtChkDetail.Rows(i).Item("mei").ToString)
                '检查项目ID
                hsTemp.Add("id", dtChkDetail.Rows(i).Item("id").ToString)
                '类别
                hsTemp.Add("kind", dtChkDetail.Rows(i).Item("kind").ToString)
                '检查位置
                hsTemp.Add("check_position", dtChkDetail.Rows(i).Item("check_position").ToString)
                '检查项目
                hsTemp.Add("check_item", dtChkDetail.Rows(i).Item("check_item").ToString)
                '基准类型
                hsTemp.Add("benchmark_type", dtChkDetail.Rows(i).Item("benchmark_type").ToString)
                '基准值1
                hsTemp.Add("benchmark_value1", dtChkDetail.Rows(i).Item("benchmark_value1").ToString)
                '基准值2
                hsTemp.Add("benchmark_value2", dtChkDetail.Rows(i).Item("benchmark_value2").ToString)
                '基准值3
                hsTemp.Add("benchmark_value3", dtChkDetail.Rows(i).Item("benchmark_value3").ToString)
                '基准类型
                hsTemp.Add("benchmark_type_old", dtChkDetail.Rows(i).Item("benchmark_type_old").ToString)
                '基准值1
                hsTemp.Add("benchmark_value1_old", dtChkDetail.Rows(i).Item("benchmark_value1_old").ToString)
                '基准值2
                hsTemp.Add("benchmark_value2_old", dtChkDetail.Rows(i).Item("benchmark_value2_old").ToString)
                '基准值3
                hsTemp.Add("benchmark_value3_old", dtChkDetail.Rows(i).Item("benchmark_value3_old").ToString)
                '检查方式
                hsTemp.Add("check_way", dtChkDetail.Rows(i).Item("check_way").ToString)
                '检查次数
                hsTemp.Add("check_times", dtChkDetail.Rows(i).Item("check_times").ToString)
                '实测值1
                hsTemp.Add("measure_value1", dtChkDetail.Rows(i).Item("measure_value1").ToString)
                '实测值2
                hsTemp.Add("measure_value2", dtChkDetail.Rows(i).Item("measure_value2").ToString)
                '表示位置
                hsTemp.Add("dis_no", dtChkDetail.Rows(i).Item("dis_no").ToString)
                '备注
                hsTemp.Add("remarks", dtChkDetail.Rows(i).Item("remarks").ToString)
                '实测结果
                If dtChkDetail.Rows(i).Item("result").ToString.Trim.Equals(String.Empty) Then
                    '结果初始状态设置
                    hsTemp.Add("result", CheckResult.INIT)
                Else
                    hsTemp.Add("result", dtChkDetail.Rows(i).Item("result").ToString)
                End If

                '检查项目详细信息储存
                dicCheckResultInfo.Add(strChkId_disNo, hsTemp)
            Next
        Else

            MsgBox(String.Format(MsgConst.M00035I, "检查项目"), MsgBoxStyle.Critical, "错误信息")

        End If
    End Sub

    ''' <summary>
    ''' 根据图片ID取得图片二进制
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPicInfo() As Byte()
        Dim bt As Byte()
        Dim dtPicInfo As DataTable = bc.GetPicInfoById(Me.strPicID).Tables("PicInfo")
        If dtPicInfo.Rows.Count > 0 Then
            bt = DirectCast(dtPicInfo.Rows(0).Item("picture_content"), Byte())
        Else
            MsgBox(String.Format(MsgConst.M00010I, "图片"), MsgBoxStyle.Critical, "错误信息")
            bt = Nothing
        End If
        Return bt
    End Function

#End Region

#Region "画面显示"

    ''' <summary>
    ''' 画面显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub allShow()
        '图片显示
        ShowPicture()
        '类型显示
        showTypeBtns()
        '检查项目显示
        showChkDetail(Me.strFirstTypeName)
    End Sub

    ''' <summary>
    ''' 检查项目显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showChkDetail(ByVal strTypeName As String)

        Me.TabPal.Visible = False

        '控件清空

        ClearMS()


        '临时变量
        Dim lisChkId As List(Of String)

        Dim hsBenchark As New Hashtable
        Dim clm As Integer = 1
        Dim flgFocus As Integer = 0
        '显示行计数
        Dim intRowCount As Integer = 1
        lisChkId = dicTypeInfo(strTypeName) ''ID / dis_no

        Dim rowCount As Integer = Me.lstType.Count
        '下一个Type赋值
        For i As Integer = 0 To rowCount - 1
            If lstType.Item(i).Equals(strTypeName) AndAlso i <> Me.lstType.Count - 1 Then
                Me.strNextType = lstType.Item(i + 1)
                Exit For
            End If
        Next

        '最后一个Type判断
        If strTypeName.Equals(Me.strLastTyName) Then
            Me.flgLastType = Flag.ON
        Else
            Me.flgLastType = Flag.OFF
        End If

        rowCount = lisChkId.Count
        For i As Integer = 0 To rowCount - 1
            Dim hsTemp As New Hashtable
            hsBenchark.Clear()
            hsTemp = CType(dicCheckResultInfo(lisChkId.Item(i).ToString).Clone, Hashtable)

            If hsTemp("check_times").ToString.Equals("1") Then
                '非多次检查
                '正常显示
                GetDetaiRowParam(hsTemp, intRowCount, lisChkId.Item(i).ToString)
                intRowCount = intRowCount + 1
            Else
                '多次检查的场合

                '获取检查ID和表示顺。strInfo(0)：检查ID strInfo(1)：表示顺
                Dim strInfo As String() = Split(lisChkId.Item(i).ToString, "/")


                '临时信息copy
                Dim hsMsg As Hashtable = CType(hsTemp.Clone, Hashtable)

                '信息重新设置

                '实测值1
                hsMsg("measure_value1") = String.Empty
                '实测值2
                hsMsg("measure_value2") = String.Empty
                '表示位置
                'hsMsg("dis_no") = j.ToString
                '结果初始状态设置
                hsMsg("result") = CheckResult.INIT

                Dim iTimes As Integer = CInt(hsTemp("check_times").ToString)

                '第一条正常显示判断
                If strInfo(1).Equals("1") Then
                    '第一条为表示顺为1的场合。
                    GetDetaiRowParam(hsTemp, intRowCount, lisChkId.Item(i).ToString)
                    intRowCount = intRowCount + 1
                Else
                    '第一条为表示顺不为1的场合。输出占位信息hsMsg
                    GetDetaiRowParam(hsMsg, intRowCount, strInfo(0) + "/1")
                    intRowCount = intRowCount + 1
                    '大循环 - 1 。将此前的行倒回。 
                    i = i - 1
                End If

                '从第二条开始判断输出。
                For j As Integer = 2 To iTimes
                    '从第二条开始判断下一个检查ID是否相同
                    If i < lisChkId.Count - 1 Then
                        If lisChkId.Item(i + 1).ToString.StartsWith(strInfo(0)) Then
                            '相同的场合。说明下一个已经存在结果

                            hsTemp = CType(dicCheckResultInfo(lisChkId.Item(i + 1).ToString).Clone, Hashtable)
                            '判断当前表示顺是否相同。
                            If hsTemp("dis_no").ToString.Equals(j.ToString) Then
                                '相同的场合
                                '大循环 + 1
                                i = i + 1
                                '显示
                                GetDetaiRowParam(hsTemp, intRowCount, lisChkId.Item(i).ToString)
                                intRowCount = intRowCount + 1
                            Else
                                '不相同的场合
                                hsMsg("dis_no") = j.ToString
                                'dicCheckResultInfo添加
                                If dicCheckResultInfo.ContainsKey(strInfo(0) + "/" + j.ToString) = False Then
                                    Dim hsMT As Hashtable = CType(hsMsg.Clone, Hashtable)
                                    dicCheckResultInfo.Add(strInfo(0) + "/" + j.ToString, hsMT)
                                    'key值组合。检查ID+"/"+dis_no
                                    GetDetaiRowParam(hsMsg, intRowCount, strInfo(0) + "/" + j.ToString)
                                    intRowCount = intRowCount + 1
                                Else
                                    GetDetaiRowParam(dicCheckResultInfo(strInfo(0) + "/" + j.ToString), intRowCount, strInfo(0) + "/" + j.ToString)
                                    intRowCount = intRowCount + 1
                                End If

                            End If
                        Else
                            '不同的场合
                            hsMsg("dis_no") = j.ToString
                            'dicCheckResultInfo添加
                            If dicCheckResultInfo.ContainsKey(strInfo(0) + "/" + j.ToString) = False Then
                                Dim hsMT As Hashtable = CType(hsMsg.Clone, Hashtable)
                                dicCheckResultInfo.Add(strInfo(0) + "/" + j.ToString, hsMT)
                                'key值组合。检查ID+"/"+dis_no
                                GetDetaiRowParam(hsMsg, intRowCount, strInfo(0) + "/" + j.ToString)
                                intRowCount = intRowCount + 1
                            Else
                                GetDetaiRowParam(dicCheckResultInfo(strInfo(0) + "/" + j.ToString), intRowCount, strInfo(0) + "/" + j.ToString)
                                intRowCount = intRowCount + 1
                            End If

                        End If
                    Else
                        '不同的场合
                        hsMsg("dis_no") = j.ToString
                        'dicCheckResultInfo添加
                        If dicCheckResultInfo.ContainsKey(strInfo(0) + "/" + j.ToString) = False Then
                            Dim hsMT As Hashtable = CType(hsMsg.Clone, Hashtable)
                            dicCheckResultInfo.Add(strInfo(0) + "/" + j.ToString, hsMT)
                            'key值组合。检查ID+"/"+dis_no
                            GetDetaiRowParam(hsMsg, intRowCount, strInfo(0) + "/" + j.ToString)
                            intRowCount = intRowCount + 1
                        Else
                            GetDetaiRowParam(dicCheckResultInfo(strInfo(0) + "/" + j.ToString), intRowCount, strInfo(0) + "/" + j.ToString)
                            intRowCount = intRowCount + 1
                        End If

                    End If

                Next

            End If

        Next



        ShowMS()


        '遍历控件
        'For Each c As Control In TabPal.Controls
        '    If c.Name.Equals("ss") Then
        '        c.BackColor = Color.DeepPink

        '    End If
        'Next

        Me.TabPal.Visible = True
    End Sub

    Private arrhsTemp As New List(Of Hashtable)
    Private arrintICount As New List(Of Integer)
    Private arrstrIdNo As New List(Of String)
    Private Sub GetDetaiRowParam(ByVal hsTemp As Hashtable, ByVal intICount As Integer, ByVal strIdNo As String)
        arrhsTemp.Add(hsTemp)
        arrintICount.Add(intICount)
        arrstrIdNo.Add(strIdNo)
    End Sub

    Private Sub ShowMS()
        Dim rowCount As Integer = arrhsTemp.Count
        For i As Integer = 0 To rowCount - 1
            ShowDetailRow(arrhsTemp(i), arrintICount(i), arrstrIdNo(i))
        Next
    End Sub
    Private Sub ClearMS()
        Me.TabPal.Controls.Clear()
        arrhsTemp.Clear()
        arrintICount.Clear()
        arrstrIdNo.Clear()
    End Sub


    ''' <summary>
    ''' 检查详细行生成
    ''' </summary>
    ''' <param name="hsTemp"></param>
    ''' <param name="intICount"></param>
    ''' <param name="strIdNo"></param>
    ''' <remarks></remarks>
    Private Sub ShowDetailRow(ByVal hsTemp As Hashtable, ByVal intICount As Integer, ByVal strIdNo As String)
        '类别1
        Me.TabPal.Controls.Add(GetLable(hsTemp("kind").ToString), 0, intICount)
        '检查位置2
        Me.TabPal.Controls.Add(GetLable(hsTemp("check_position").ToString), 1, intICount)
        '检查项目3
        Me.TabPal.Controls.Add(GetLable(hsTemp("check_item").ToString), 2, intICount)
        '方法4
        Me.TabPal.Controls.Add(GetLable(hsTemp("check_way").ToString), 3, intICount)


        Select Case hsTemp("benchmark_type").ToString

            Case Consts.BenchmarkType.TYPE00
                '目测
            Case BenchmarkType.TYPE01, BenchmarkType.TYPE02, BenchmarkType.TYPE03, BenchmarkType.TYPE04, BenchmarkType.TYPE05, BenchmarkType.TYPE06, BenchmarkType.TYPE10, BenchmarkType.TYPE12, BenchmarkType.TYPE14

                '暂时是一个入力值
                '实测值1
                Dim ct1 As New CustomTextBox
                ct1.Name = "Value1"
                ct1.Tag = strIdNo
                ct1.ReferenceBaseForm = Me

                'If hsTemp("benchmark_type_old").ToString = "" Then
                ct1.BenchmarkType = hsTemp("benchmark_type").ToString
                ct1.BenchmarkValue1 = hsTemp("benchmark_value1").ToString
                ct1.BenchmarkValue2 = hsTemp("benchmark_value2").ToString
                ct1.BenchmarkValue3 = hsTemp("benchmark_value3").ToString
                'Else
                '    ct1.BenchmarkType = hsTemp("benchmark_type_old").ToString
                '    ct1.BenchmarkValue1 = hsTemp("benchmark_value1_old").ToString
                '    ct1.BenchmarkValue2 = hsTemp("benchmark_value2_old").ToString
                '    ct1.BenchmarkValue3 = hsTemp("benchmark_value3_old").ToString
                'End If




                ct1.txtBox.Text = hsTemp("measure_value1").ToString
                ct1.AutoSize = True
                ct1.Dock = DockStyle.Bottom
                ct1.txtBox.Width = 70
                ct1.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
                If intICount = 1 Then
                    ct1.Select()
                End If
                AddHandler ct1.CustomTextBox_LostFocus, AddressOf Control_LostFocus
                TabPal.Controls.Add(ct1, 4, intICount)
            Case Else
                '两个入力值
                '实测值1
                Dim ct1 As New CustomTextBox
                ct1.Name = "Value21"
                ct1.Tag = strIdNo
                ct1.ReferenceBaseForm = Me
                'If hsTemp("benchmark_type_old").ToString = "" Then
                ct1.BenchmarkType = hsTemp("benchmark_type").ToString
                ct1.BenchmarkValue1 = hsTemp("benchmark_value1").ToString
                ct1.BenchmarkValue2 = hsTemp("benchmark_value2").ToString
                ct1.BenchmarkValue3 = hsTemp("benchmark_value3").ToString
                'Else
                '    ct1.BenchmarkType = hsTemp("benchmark_type_old").ToString
                '    ct1.BenchmarkValue1 = hsTemp("benchmark_value1_old").ToString
                '    ct1.BenchmarkValue2 = hsTemp("benchmark_value2_old").ToString
                '    ct1.BenchmarkValue3 = hsTemp("benchmark_value3_old").ToString
                'End If

                ct1.txtBox.Text = hsTemp("measure_value1").ToString
                ct1.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
                ct1.AutoSize = True
                ct1.Dock = DockStyle.Bottom
                ct1.txtBox.Width = 70

                AddHandler ct1.CustomTextBox_LostFocus, AddressOf Control_LostFocus
                'AddHandler ct1.GotFocus, AddressOf Control_GotFocus

                Me.TabPal.Controls.Add(ct1, 4, intICount)
                '实测值2
                Dim ct2 As New CustomTextBox
                ct2.Name = "Value22"
                ct2.Tag = strIdNo
                ct2.ReferenceBaseForm = Me
                'If hsTemp("benchmark_type_old").ToString = "" Then
                ct2.BenchmarkType = hsTemp("benchmark_type").ToString
                ct2.BenchmarkValue1 = hsTemp("benchmark_value1").ToString
                ct2.BenchmarkValue2 = hsTemp("benchmark_value2").ToString
                ct2.BenchmarkValue3 = hsTemp("benchmark_value3").ToString
                'Else
                'ct2.BenchmarkType = hsTemp("benchmark_type_old").ToString
                'ct2.BenchmarkValue1 = hsTemp("benchmark_value1_old").ToString
                'ct2.BenchmarkValue2 = hsTemp("benchmark_value2_old").ToString
                'ct2.BenchmarkValue3 = hsTemp("benchmark_value3_old").ToString
                'End If

                ct2.txtBox.Text = hsTemp("measure_value2").ToString
                ct2.AutoSize = True
                ct2.Dock = DockStyle.Bottom
                ct2.txtBox.Width = 70
                ct2.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
                AddHandler ct2.CustomTextBox_LostFocus, AddressOf Control_LostFocus
                'AddHandler ct2.GotFocus, AddressOf Control_GotFocus
                Me.TabPal.Controls.Add(ct2, 5, intICount)


        End Select

        Dim xiaokoubiaoqian As Boolean = False
        If hsTemp("kind").ToString = "小口标签" Then
            xiaokoubiaoqian = True
        End If

        '结果
        Dim cd As New CustomDropdownList(xiaokoubiaoqian)
        cd.AutoSize = True
        cd.Dock = DockStyle.Bottom
        cd.Name = "CdResult"
        cd.Tag = strIdNo
        cd.SelecedtValue = hsTemp("result").ToString
        cd.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
        If hsTemp("benchmark_type").ToString.Equals(Consts.BenchmarkType.TYPE00) AndAlso intICount = 1 Then
            cd.Select()
        End If

        '颜色变更
        Select Case cd.SelecedtValue
            Case Consts.CheckResult.OK, Consts.CheckResult.SD '合格，微欠
                cd.BackColor = Color.LightGreen
            Case Consts.CheckResult.OW '警告
                cd.BackColor = Color.LightBlue
            Case Else
                cd.BackColor = NG_BackColor
        End Select

        AddHandler cd.CustomDropdownList_LostFocus, AddressOf Control_LostFocus
        Me.TabPal.Controls.Add(cd, 6, intICount)

        '备注
        Dim ctRM As New TextBox
        ctRM.Name = strIdNo
        ctRM.Tag = strIdNo
        ctRM.Text = hsTemp("remarks").ToString
        ctRM.AutoSize = True
        ctRM.Dock = DockStyle.Bottom
        ctRM.Padding = New Padding(1, 1, 1, 1)
        ctRM.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
        AddHandler ctRM.KeyPress, AddressOf TextBoxKeyPress
        AddHandler ctRM.LostFocus, AddressOf Control_LostFocus
        AddHandler ctRM.MouseUp, AddressOf Control_MouseUp
        Me.TabPal.Controls.Add(ctRM, 7, intICount)


        Dim lblKijun As New Label
        lblKijun.Name = "lblKijun"
        lblKijun.AutoSize = True
        lblKijun.Dock = DockStyle.Fill
        lblKijun.TextAlign = ContentAlignment.MiddleCenter
        lblKijun.Font = New Font(MS_MSLableFontFamily, MS_Font_Size - 2, FontStyle.Regular)

        If cd.SelecedtValue = Consts.CheckResult.NG Then
            lblKijun.Text = "(" & hsTemp("benchmark_value1").ToString _
                            & "," & hsTemp("benchmark_value2").ToString _
                            & "," & hsTemp("benchmark_value3").ToString & ")"
        ElseIf hsTemp("benchmark_type_old").ToString.Trim <> "" AndAlso ( _
                   hsTemp("benchmark_value1_old").ToString <> hsTemp("benchmark_value1").ToString _
            OrElse hsTemp("benchmark_value2_old").ToString <> hsTemp("benchmark_value2").ToString _
            OrElse hsTemp("benchmark_value3_old").ToString <> hsTemp("benchmark_value3").ToString _
            OrElse hsTemp("benchmark_type_old").ToString.Trim <> hsTemp("benchmark_type").ToString.Trim) Then

            lblKijun.Text = "基准值有变化，请重新检查"
            lblKijun.BackColor = Color.Red
        End If

        lblKijun.Font = New Font(MS_MSLableFontFamily, 9, FontStyle.Regular)
        Me.TabPal.Controls.Add(lblKijun, 8, intICount)

        '实测值2
    End Sub

    Public Shared activeTxtControls As TextBox
    'Public Sub Control_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    activeTxtControls = CType(sender, CustomTextBox).InnerTxt
    'End Sub


    ''' <summary>
    ''' 检查完了确认
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ChkFinish() As Boolean
        If Me.flgLastType = Flag.ON Then
            Dim resultFlg As Boolean = True
            Dim strMsg As String = String.Empty
            '计数清零
            Me.intMDno = 0
            Me.intNGno = 0
            Me.intOWno = 0
            Me.intSDno = 0
            Me.intINITno = 0
            '循环所有项目
            For Each pairKey As KeyValuePair(Of String, Hashtable) In dicCheckResultInfo

                '结果数据统计
                Select Case pairKey.Value("result").ToString.Trim
                    Case CheckResult.INIT
                        Me.intINITno = Me.intINITno + 1
                    Case CheckResult.OW
                        Me.intOWno = Me.intOWno + 1
                    Case CheckResult.SD
                        Me.intSDno = Me.intSDno + 1
                    Case CheckResult.MD
                        Me.intMDno = Me.intMDno + 1
                    Case CheckResult.NG
                        Me.intNGno = Me.intNGno + 1
                    Case Else
                End Select

                'INIT的时候为NG 或者检查结果不是OK且不是OW且不是SD的情况下判定为NG

                'If pairKey.Value("result").ToString.Equals(CheckResult.INIT) OrElse _
                '  (pairKey.Value("result").ToString <> CheckResult.OK AndAlso pairKey.Value("result").ToString <> CheckResult.OW AndAlso pairKey.Value("result").ToString <> CheckResult.SD) Then
                '    strChkResult = Consts.CheckResult.NG
                '    resultFlg = False
                'End If
            Next
            '消息提示
            If Me.intINITno > 0 OrElse Me.intMDno > 0 OrElse Me.intNGno > 0 Then
                If Me.intINITno > 0 Then
                    strMsg = "当前检查状况：" & vbCrLf & "漏检" & Me.intINITno & "件。" & vbCrLf
                End If
                If Me.intOWno > 0 Then
                    strMsg = strMsg + "警告" & Me.intOWno & "件。" & vbCrLf
                End If
                If Me.intSDno > 0 Then
                    strMsg = strMsg + "微欠品" & Me.intSDno & "件。" & vbCrLf
                End If
                If Me.intMDno > 0 Then
                    strMsg = strMsg + "轻中重" & Me.intMDno & "件。" & vbCrLf
                End If
                If Me.intNGno > 0 Then
                    strMsg = strMsg + "不合格" & Me.intNGno & "件。" & vbCrLf
                End If
                If MessageBox.Show(String.Format(MsgConst.M00042I, strMsg), "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    '结果赋值
                    If Me.intINITno > 0 Then
                        Me.strChkResult = CheckResult.LC
                    Else
                        Me.strChkResult = CheckResult.NG
                    End If

                    Return True
                Else
                    Return False
                End If
            Else
                '结果赋值
                Me.strChkResult = CheckResult.OK
                Return True
            End If

            '消息提示
            'strMsg = "当前检查状况：" & vbCrLf & "漏检{0}件。" & vbCrLf & "警告{1}件。" & vbCrLf & "微欠品{2}件。" & vbCrLf & "轻中重{3}件" & vbCrLf & "不合格{4}件" & vbCrLf
            'strMsg.Replace("{0}", Me.intINITno.ToString)
            'strMsg.Replace("{1}", Me.intOWno.ToString)
            'strMsg.Replace("{2}", Me.intSDno.ToString)
            'strMsg.Replace("{3}", Me.intMDno.ToString)
            'strMsg.Replace("{4}", Me.intNGno.ToString)

            '结果赋值
            'If Me.intINITno > 0 OrElse Me.intMDno > 0 OrElse Me.intNGno > 0 Then
            '    strChkResult = Consts.CheckResult.NG
            'Else
            '    strChkResult = Consts.CheckResult.OK
            'End If
            'strMsg = String.Format(strMsg, Me.intINITno.ToString, Me.intOWno.ToString, Me.intSDno.ToString, Me.intMDno.ToString, Me.intNGno.ToString)
            'If MessageBox.Show(String.Format(MsgConst.M00042I, strMsg), "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            '    'Me.Close()
            '    Return True
            'End If
        Else
            showChkDetail(Me.strNextType)
        End If
        Return False
    End Function

    ''' <summary>
    ''' textbox key press
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub



    ''' <summary>
    ''' 失去焦点事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Control_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '临时变量声明




        Dim hsValues As New Hashtable

        '保存共同数据
        '检查结果ID保存
        hsValues.Add("result_id", Me.strChkResultId)
        '检查ID
        hsValues.Add("check_id", String.Empty)
        '实测值1
        hsValues.Add("measure_value1", "NULL")
        '实测值2
        hsValues.Add("measure_value2", "NULL")
        '结果
        hsValues.Add("result", String.Empty)
        '表示顺
        hsValues.Add("dis_no", "1")
        '删除flg
        hsValues.Add("delete_flg", "0")
        '图片ID
        hsValues.Add("picture_id", Me.strPicID)
        '备注
        hsValues.Add("remarks", String.Empty)
        hsValues.Add("benchmark_type", String.Empty)
        hsValues.Add("benchmark_value1", String.Empty)
        hsValues.Add("benchmark_value2", String.Empty)
        hsValues.Add("benchmark_value3", String.Empty)

        If sender.GetType Is GetType(CustomTextBox) Then

            If DirectCast(sender, CustomTextBox).InnerTxt.Text = DirectCast(sender, CustomTextBox).OldValue Then
                Exit Sub
            End If




            '实测值1
            Dim ct As CustomTextBox = DirectCast(sender, CustomTextBox)



            '颜色变更
            Select Case ct.CheckResult
                Case Consts.CheckResult.OK, Consts.CheckResult.SD '合格，微欠
                    If DirectCast(sender, CustomTextBox).KIJUN <> "" Then
                        Dim row As Integer = _
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetCellPosition(DirectCast(sender, CustomTextBox)).Row
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetControlFromPosition(8, row).Text = ""
                    End If
                Case Consts.CheckResult.OW '警告
                    If DirectCast(sender, CustomTextBox).KIJUN <> "" Then
                        Dim row As Integer = _
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetCellPosition(DirectCast(sender, CustomTextBox)).Row
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetControlFromPosition(8, row).Text = ""
                    End If
                Case Else
                    If DirectCast(sender, CustomTextBox).KIJUN <> "" Then
                        Dim row As Integer = _
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetCellPosition(DirectCast(sender, CustomTextBox)).Row
                        DirectCast(DirectCast(sender, CustomTextBox).Parent, TableLayoutPanel).GetControlFromPosition(8, row).Text = DirectCast(sender, CustomTextBox).KIJUN
                    End If
            End Select




            'strChkId = ct.Tag.ToString
            Dim strInfo As String() = Split(ct.Tag.ToString, "/")
            '检查ID存入:取前9位为检查项目ID
            hsValues("check_id") = strInfo(0)
            '表示顺
            hsValues("dis_no") = strInfo(1)
            '结果存入
            hsValues("result") = ct.CheckResult

            If ct.Name.Equals("Value1") Then
                '实测值1存入
                hsValues("measure_value1") = ct.txtBox.Text.ToString
                '实测值1
                dicCheckResultInfo(ct.Tag.ToString)("measure_value1") = ct.txtBox.Text.ToString

            ElseIf ct.Name.Equals("Value21") Then
                hsValues("measure_value1") = ct.txtBox.Text.ToString
                '实测值1
                dicCheckResultInfo(ct.Tag.ToString)("measure_value1") = ct.txtBox.Text.ToString
            Else
                '实测值2存入
                hsValues("measure_value2") = ct.txtBox.Text.ToString
                '实测值2
                dicCheckResultInfo(ct.Tag.ToString)("measure_value2") = ct.txtBox.Text.ToString
            End If

            'dic数据变更
            '实测值1
            'dicCheckResultInfo(ct.Tag.ToString)("measure_value1") = ct.txtBox.Text.ToString
            '结果
            If ct.CheckResult IsNot Nothing Then
                dicCheckResultInfo(ct.Tag.ToString)("result") = ct.CheckResult.ToString
            Else
                dicCheckResultInfo(ct.Tag.ToString)("result") = ""
            End If



            '遍历控件，结果栏赋值
            For Each c As Control In TabPal.Controls.Find("CdResult", True)
                'Tag 用于识别检查ID
                If c.GetType Is GetType(CustomDropdownList) AndAlso c.Tag.ToString.Equals(ct.Tag.ToString) Then
                    Dim cd As CustomDropdownList = DirectCast(c, CustomDropdownList)
                    '结果显示
                    cd.SelecedtValue = ct.CheckResult
                    cd.IsAutoTab = ct.IsAutoTab


                    hsValues("benchmark_type") = ct.BenchmarkType
                    hsValues("benchmark_value1") = ct.BenchmarkValue1
                    hsValues("benchmark_value2") = ct.BenchmarkValue2
                    hsValues("benchmark_value3") = ct.BenchmarkValue3


                    '颜色变更
                    Select Case ct.CheckResult
                        Case Consts.CheckResult.OK, Consts.CheckResult.SD '合格，微欠

                            cd.BackColor = Color.LightGreen
                        Case Consts.CheckResult.OW '警告
                            cd.BackColor = Color.LightBlue
                        Case Else
                            cd.BackColor = NG_BackColor
                    End Select

                End If
            Next



            '遍历控件，备注保存
            For Each c As Control In TabPal.Controls.Find(ct.Tag.ToString, True)
                Dim ctRM As TextBox = DirectCast(c, TextBox)
                hsValues("remarks") = ctRM.Text.Trim
            Next

            '检查全体是否合格
            CheckAllOKNG()

            ct.IsAutoTab = False
        ElseIf sender.GetType Is GetType(CustomDropdownList) Then
            '目测
            Dim cd As CustomDropdownList = DirectCast(sender, CustomDropdownList)
            Dim strInfo As String() = Split(cd.Tag.ToString, "/")
            '检查ID存入
            hsValues("check_id") = strInfo(0)
            '结果存入
            hsValues("result") = cd.SelecedtValue.ToString
            '表示顺
            hsValues("dis_no") = strInfo(1)

            'dic数据变更
            '结果
            dicCheckResultInfo(cd.Tag.ToString)("result") = cd.SelecedtValue.ToString

            '结果栏颜色变更
            Select Case cd.SelecedtValue.ToString
                Case Consts.CheckResult.OK, Consts.CheckResult.SD '合格，微欠

                    cd.BackColor = Color.LightGreen
                Case Consts.CheckResult.OW '警告
                    cd.BackColor = Color.LightBlue
                    MsgBox(MsgConst.M00060I) '小口日期标签，日期不在前后3天内，请确认
                Case Else
                    cd.BackColor = NG_BackColor
            End Select

            '遍历控件，备注保存
            For Each c As Control In TabPal.Controls.Find(cd.Tag.ToString, True)
                Dim ctRM As TextBox = DirectCast(c, TextBox)
                hsValues("remarks") = ctRM.Text.Trim
            Next

            '检查全体是否合格
            CheckAllOKNG()

            cd.IsAutoTab = False
        ElseIf sender.GetType Is GetType(TextBox) Then

            Dim ctRM As TextBox = DirectCast(sender, TextBox)
            Dim strInfo As String() = Split(ctRM.Tag.ToString, "/")
            '检查ID存入
            hsValues("check_id") = strInfo(0)
            '表示顺
            hsValues("dis_no") = strInfo(1)
            hsValues("remarks") = ctRM.Text.Trim
            '遍历控件，结果保存
            For Each c As Control In TabPal.Controls.Find("CdResult", True)
                'Tag 用于识别检查ID
                If c.GetType Is GetType(CustomDropdownList) AndAlso c.Tag.ToString.Equals(ctRM.Tag.ToString) Then
                    Dim cd As CustomDropdownList = DirectCast(c, CustomDropdownList)
                    '结果存入
                    hsValues("result") = cd.SelecedtValue.ToString
                End If
            Next

        End If

        '数据保存
        Using scope As New TransactionScope(TransactionScopeOption.Required)

            Try
                Dim strType As String
                If bc.CheckDetailInfoHave(Me.strChkResultId, hsValues("check_id").ToString, hsValues("dis_no").ToString) Then
                    '更新场合
                    strType = "UPDATE"
                Else
                    '插入场合
                    strType = "INSERT"
                End If

                If bc.ResultDetaileInOrUp(strType, hsValues) > 0 Then
                    scope.Complete()
                Else
                    scope.Dispose()
                    MsgBox(String.Format(MsgConst.M00002D, "结果详细信息"), MsgBoxStyle.Critical, "错误信息")
                    Exit Sub
                End If

            Catch ex As Exception
                scope.Dispose()
            End Try

        End Using

        ''光标走向控制 CT1:只有一个入力值，需要跳一个Table键。CT21:两个入力值的第一个输入框，不跳。CT2：第二个入力框，跳一个。CD:结果栏，不跳
        'Select Case strControlType
        '    Case "CT21", "CD"
        '        '两个入力值和结果栏的场合，不跳！
        '    Case "CT1", "CT2"
        '        '一个入力值或第二个入力框时跳一个Table
        '        SendKeys.Send("{TAB}")
        '    Case Else

        'End Select

    End Sub


    '检查全体有 没有不合格的
    Private Sub CheckAllOKNG()
        Try
            Dim ct As Control
            For Each ct In Me.TabPal.Controls.Find("CdResult", True)
                If (TypeOf ct Is CustomDropdownList) Then
                    If DirectCast(ct, CustomDropdownList).BackColor = NG_BackColor Then
                        SetJieguo(False)

                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
        SetJieguo(True)
    End Sub

    ''' <summary>
    ''' 内容全选择
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DirectCast(sender, TextBox).SelectAll()
    End Sub

    ''' <summary>
    ''' 图片显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowPicture()

        Try
            Dim ms As New MemoryStream
            Dim bytes As Byte() = GetPicInfo()
            ms.Write(bytes, 0, bytes.Length)
            '图片名称
            'Me.grpBoxPic.Text = Me.strClsName
            'lblPicName.Text = Me.strClsName
            Me.GroupBox2.Text = Me.strClsName

            '图片二进制
            Dim Bitmap As System.Drawing.Bitmap = CType(Image.FromStream(ms), Bitmap)

            Me.picBox.Image = Bitmap
            Me.img = Bitmap
            'picBoxBig.Image = Bitmap
            Me.picBox.Height = CInt(Me.picBox.Width * Bitmap.Height / Bitmap.Width)

            ms.Close()
            ms.Dispose()

            Dim imgsmall As Image = Nothing
            imgsmall = picBox.Image


            setNomailpicsize()
        Catch ex As Exception

        End Try


        'Dim sx As Integer = -20
        'Dim sy As Integer = -20
        'Dim g As Graphics = Graphics.FromHwnd(picBoxBig.Handle)
        'g.Clear(picBoxBig.BackColor)
        'g.DrawImage(picBox.Image, New Rectangle(0, 0, Me.picBoxBig.Width, Me.picBoxBig.Height), sx, sy, 750, 300, GraphicsUnit.Pixel)



    End Sub

    ''' <summary>
    ''' 类型按钮显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showTypeBtns()
        '坐标设置
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim iCount As Integer = 1
        '循环类型信息储存变量动态生成按钮
        For Each pairKey As KeyValuePair(Of String, List(Of String)) In dicTypeInfo

            Dim btn As New Button
            'btn.TabIndex = 99999
            btn.Width = 62
            btn.Height = 26
            btn.Text = pairKey.Key
            btn.Name = pairKey.Key
            btn.FlatStyle = FlatStyle.System

            btn.Font = New Font(MS_MSLableFontFamily, 13, FontStyle.Bold)
            '下一个Type赋值     
            If iCount < lstType.Count Then
                btn.Tag = Me.lstType.Item(iCount)
            End If
            btn.Location = New Point(x, y)
            AddHandler btn.Click, AddressOf btnClicked
            Me.pnlBtn.Controls.Add(btn)
            '根据文字多少设置位置。一个字占40 
            y = y + iCount * 40
            iCount = iCount + 1
        Next
    End Sub

    Dim AllJieguo As New Label

    Private Function GetLable(ByVal txt As String) As Label
        Dim lb1 As New Label
        lb1.Text = txt
        lb1.AutoSize = True
        lb1.Dock = DockStyle.Fill
        lb1.TextAlign = ContentAlignment.MiddleCenter
        lb1.Font = New Font(MS_MSLableFontFamily, MS_Font_Size, FontStyle.Regular)
        AddHandler lb1.MouseDown, AddressOf Panel1_MouseDown
        AddHandler lb1.MouseMove, AddressOf Panel1_MouseMove
        AddHandler lb1.MouseUp, AddressOf Panel1_MouseUp
        AddHandler lb1.MouseLeave, AddressOf TabPal_MouseLeave


        Return lb1
    End Function

    ''' <summary>
    ''' 标头设置
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showTitle()
        Me.tblTitle.Controls.Clear()
        '标题控件添加
        Me.tblTitle.Controls.Add(GetLable("类别"), 0, 0)
        Me.tblTitle.Controls.Add(GetLable("检查位置"), 1, 0)
        Me.tblTitle.Controls.Add(GetLable("检查项目"), 2, 0)
        Me.tblTitle.Controls.Add(GetLable("方法"), 3, 0)
        Me.tblTitle.Controls.Add(GetLable("实测值1"), 4, 0)
        Me.tblTitle.Controls.Add(GetLable("实测值2"), 5, 0)
        Me.tblTitle.Controls.Add(GetLable("结果"), 6, 0)
        Me.tblTitle.Controls.Add(GetLable("备注"), 7, 0)
        Me.tblTitle.Controls.Add(GetLable("基准值"), 8, 0)
    End Sub

#End Region

#Region "控件添加事件"


    ''' <summary>
    ''' 类型按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bnt As Button = DirectCast(sender, Button)
        If bnt.Name.ToString.Equals(Me.strLastTyName) Then
            Me.flgLastType = Flag.ON
        Else
            Me.flgLastType = Flag.OFF
            '下一个Type赋值
            Me.strNextType = bnt.Tag.ToString
        End If
        showChkDetail(bnt.Name.ToString)

    End Sub

    ''' <summary>
    ''' 图片双击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picBox.DoubleClick
        Me.ShowMaxPicture(Me.img)
    End Sub

    ''' <summary>
    ''' 图片放大
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBox.MouseDown
        Dim img As Image = Nothing
        img = picBox.Image
        Try
            Dim sx As Integer = CInt(e.X * (img.Width / picBox.Width) - 20)
            Dim sy As Integer = CInt((e.Y) * (img.Height / picBox.Height) - 20)
            Dim w As Integer = Me.picBox.Width
            Dim h As Integer = 100
            Dim g As Graphics = Graphics.FromHwnd(picBoxBig.Handle)
            g.Clear(picBoxBig.BackColor)
            g.DrawImage(picBox.Image, New Rectangle(0, 0, Me.picBoxBig.Width, Me.picBoxBig.Height), sx, sy, 700, 280, GraphicsUnit.Pixel)

        Catch ex As Exception

        End Try


        'setNomailpicsize()

    End Sub


    Private Sub picBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBox.MouseMove
        Dim img As Image = Nothing
        img = picBox.Image
        Try
            Dim sx As Integer = CInt(e.X * (img.Width / picBox.Width) - 20)
            Dim sy As Integer = CInt((e.Y) * (img.Height / picBox.Height) - 20)
            Dim w As Integer = Me.picBox.Width
            Dim h As Integer = 100
            Dim g As Graphics = Graphics.FromHwnd(picBoxBig.Handle)
            g.Clear(picBoxBig.BackColor)
            g.DrawImage(picBox.Image, New Rectangle(0, 0, Me.picBoxBig.Width, Me.picBoxBig.Height), sx, sy, 700, 280, GraphicsUnit.Pixel)

        Catch ex As Exception

        End Try


    End Sub





    ''' <summary>
    ''' tableLayoutPanel控件的CellPaint事件里重新绘制边框
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabPal_CellPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs)
        Dim pp As Pen = New Pen((Color.Gray))
        e.Graphics.DrawRectangle(pp, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1)
    End Sub

    ''' <summary>
    ''' 检查结束标识TextBox获得光标事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtStop_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        '触发失去光标事件，进行检查完了确认处理。原因：如果在此事件加处理的话会造成死循环
        SendKeys.Send("{TAB}")
    End Sub
    ''' <summary>
    ''' 检查结束标识TextBox失去光标事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtStop_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ''检查完了确认
        'If ChkFinish() = False Then
        '    Panel1.Focus()
        '    SendKeys.Send("{TAB}")
        'End If
        If Me.flgLastType = Flag.ON Then
            Me.Close()
        Else
            showChkDetail(Me.strNextType)
        End If

    End Sub


#End Region

#Region "父类继承事件"

    ''' <summary>
    ''' 打开COM和Service
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LOpen()
        '打开TCP服务器
        Me.OpenServer()
        '打开本机COM口
        ' Me.OpenSerialPort()
    End Sub

    ''' <summary>
    ''' 关闭COM和Service
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LClose()
        '关闭TCP服务器
        Me.CloseServer()
    End Sub

#End Region

#Region "软键盘调用"
    ''' <summary>
    ''' 软键盘打开关闭
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ShowKeybord()
    End Sub
#End Region


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        setNomailpicsize()
        'Me.Panel1.AutoScrollPosition = New Point(0, -200)

        ' Panel1.MaximumSize = New System.Drawing.Size(10)



        'Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Value - 10
    End Sub


    Sub setNomailpicsize()
        'Dim bl As Double
        picBoxBig.Image = Me.img
        'bl = Me.img.Width / picBoxBig.Width
        'Dim g As Graphics = Graphics.FromHwnd(picBoxBig.Handle)
        'g.Clear(picBoxBig.BackColor)
        'g.DrawImage(picBox.Image, New Rectangle(0, 0, CInt(Me.picBoxBig.Width * bl), CInt(Me.picBoxBig.Height * bl)), 0, 0, 750, 300, GraphicsUnit.Pixel)
    End Sub



    'Private Sub TabPal_CellPaint1(ByVal sender As Object, ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs) Handles TabPal.CellPaint
    '    If e.Row Mod 2 = 0 Then
    '        Dim g As Graphics = e.Graphics
    '        Dim r As Rectangle = e.CellBounds
    '        g.FillRectangle(Brushes.WhiteSmoke, r)

    '    End If
    'End Sub

    Private Sub btnGotoErrRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGotoErrRow.Click
        Try
            Dim ct As Control
            For Each ct In Me.TabPal.Controls.Find("CdResult", True)
                If (TypeOf ct Is CustomDropdownList) Then
                    If DirectCast(ct, CustomDropdownList).BackColor = NG_BackColor Then
                        DirectCast(ct, CustomDropdownList).Focus()

                        'Try
                        '    Dim r As Integer = GetActiveRowIndex() + 1
                        '    Dim ct1 As Control
                        '    For Each ct1 In Me.TabPal.Controls
                        '        If r = Me.TabPal.GetRow(ct1) Then
                        '            If (TypeOf ct1 Is CustomDropdownList) Then
                        '                ct1.Focus()
                        '            End If
                        '        End If
                        '    Next
                        'Catch ex As Exception
                        'End Try

                        'btnGotoErrRow.Focus()

                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub


    Public mousdownFlg As Boolean = False
    Public mouseY As Integer = 0

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPal.MouseDown
        mousdownFlg = True
        mouseY = e.Y



    End Sub


    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPal.MouseMove
        If mousdownFlg Then
            Dim y As Integer = -10
            If mouseY > e.Y Then
                y = 10
            End If
            Dim p As New Point(0, -Panel1.AutoScrollPosition.Y + y)
            Panel1.AutoScrollPosition = p
            System.Threading.Thread.Sleep(20)
        End If

    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPal.MouseUp
        mousdownFlg = False
    End Sub


    Private Sub TabPal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPal.MouseLeave
        mousdownFlg = False
    End Sub
End Class
