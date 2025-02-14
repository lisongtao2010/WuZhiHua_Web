Imports System.Windows
Imports Lixil.AvoidMissSystem.BizLogic
Imports Lixil.AvoidMissSystem.Utilities
'Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Runtime.InteropServices.Marshal
Imports Lixil.AvoidMissSystem.WinUI.Common
Imports System.Transactions

Public Class ResultModify

#Region "变量声明"

    'BC层实例化
    Private bc As New ResultModifyBizLogic
    Dim bcCom As New CommonBizLogic
    Dim bcIndex As New IndexBizLogic
#End Region

#Region "系统响应事件"

    ''' <summary>
    ''' PageLode
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResultModify_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Init()
        Me.Width = 1220
        Me.Height = 800
        Me.Location = New Point(1, 1)
        Me.Height = My.Computer.Screen.Bounds.Height - 40
        Me.Width = My.Computer.Screen.Bounds.Width - 10
        Me.AutoScroll = True
    End Sub

    ''' <summary>
    ''' 用户关闭系统关闭按钮事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResultModify_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        '    NavigateToNextPage("msMain")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
#End Region

#Region "内部调用函数"
    ''' <summary>
    ''' 初始化函数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Init()
        '部门初始化
        InitializeDepart()
        '结果dropdownlist初始化
        Dim list As New DataTable()
        list.Columns.Add(New DataColumn("value", System.Type.GetType("System.String")))
        list.Columns.Add(New DataColumn("name", System.Type.GetType("System.String")))
        list.Rows.Add("All", "所有")
        list.Rows.Add("OK", "合格")
        list.Rows.Add("NG", "不合格")

        '查询区
        Me.drpResult.DataSource = list
        drpResult.DisplayMember = "name"
        drpResult.ValueMember = "value"

        Dim listE As New DataTable()
        listE.Columns.Add(New DataColumn("value", System.Type.GetType("System.String")))
        listE.Columns.Add(New DataColumn("name", System.Type.GetType("System.String")))
        listE.Rows.Add("OK", "合格")
        listE.Rows.Add("NG", "不合格")

        '编辑区
        Me.drpEResult.DataSource = listE
        drpEResult.DisplayMember = "name"
        drpEResult.ValueMember = "value"

        '编辑区状态设置
        Me.Text = "检查结果修正"

        Dim listState As New DataTable()
        listState.Columns.Add(New DataColumn("value", System.Type.GetType("System.String")))
        listState.Columns.Add(New DataColumn("name", System.Type.GetType("System.String")))
        listState.Rows.Add("0", "完了")
        listState.Rows.Add("1", "待判")

        Me.drpState.DataSource = listState
        drpState.DisplayMember = "name"
        drpState.ValueMember = "value"
        '按钮设置
        Me.btnUpdate.Enabled = False
        Me.btnSakujyo.Enabled = False
        Me.btnOpenDetail.Enabled = False
    End Sub
    ''' <summary>
    ''' 部门初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDepart()
        Dim dtDepart As DataTable
        'Dim drDepart As DataRow
        'Dim chkObject As CheckBox
        Try
            dtDepart = bc.GetDepartment(Me.Login.UserId, Me.Login.IsAdmin).Tables("Department")
            ''部门选择框初期化
            'For i As Integer = 0 To dtDepart.Rows.Count - 1
            '    chkObject = New CheckBox
            '    chkObject.Name = Convert.ToString(dtDepart.Rows(i).Item("mei_cd"))
            '    chkObject.Text = Convert.ToString(dtDepart.Rows(i).Item("mei"))
            '    chkObject.Location = New System.Drawing.Point(88 + i * 54, 10)
            '    chkObject.Visible = True
            '    chkObject.Checked = False
            '    chkObject.Width = 50
            '    chkObject.TabIndex = i + 1
            '    Me.gbSearch.Controls.Add(chkObject)
            'Next

            '部门下拉列表初期化
            'drDepart = dtDepart.NewRow()
            'drDepart("mei_cd") = ""
            'drDepart("mei") = ""
            'dtDepart.Rows.InsertAt(drDepart, 0)
            Me.chkLDepartment.DataSource = dtDepart
            Me.chkLDepartment.ValueMember = "mei_cd"
            Me.chkLDepartment.DisplayMember = "mei"

            Dim ds As DataSet = bc.GetLineNames
            cbLine_name.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                cbLine_name.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)

            Next
            'cbLine_name.DataSource = ds
            'Me.cbLine_name.ValueMember = "line_name"
            'Me.cbLine_name.DisplayMember = "line_name"
            'cbLine_name.Items.Insert(0, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 检索条件整合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getSearchKey() As Hashtable

        '数据保存Hashtable
        Dim hsKeys As New Hashtable
        Dim strDepartment As String = String.Empty
        Dim strAllDepartment As String = String.Empty
        Dim dtDepartment As DataTable = DirectCast(chkLDepartment.DataSource, DataTable)

        '部门

        'If Me.drpDepartment.SelectedIndex = 0 Then
        '    hsKeys.Add("Department", "")
        'Else
        '    hsKeys.Add("Department", Me.drpDepartment.SelectedValue.ToString)
        'End If
        '选择的部门取得
        For i As Integer = 0 To Me.chkLDepartment.Items.Count - 1
            If chkLDepartment.GetItemChecked(i) = True Then
                'strKindCd = strKindCd & "'" & chkLKind.GetItemText(chkLKind.Items(i)) & "',"
                strDepartment = strDepartment & "'" & dtDepartment.Rows(i).Item("mei_cd").ToString() & "',"
            End If
            strAllDepartment = strAllDepartment & "'" & dtDepartment.Rows(i).Item("mei_cd").ToString() & "',"
        Next
        strDepartment = strDepartment.TrimEnd(CChar(","))
        strAllDepartment = strAllDepartment.TrimEnd(CChar(","))
        If strDepartment = String.Empty Then
            hsKeys.Add("Department", strAllDepartment)
        Else
            hsKeys.Add("Department", strDepartment)
        End If

        '商品code
        If Me.txtSearchGoodsCD.Text.ToString.Trim.Equals(String.Empty) Then
            hsKeys.Add("GoodsCd", "")
        Else
            hsKeys.Add("GoodsCd", "%" + Me.txtSearchGoodsCD.Text.ToString.Trim + "%")
        End If

        '商品作番
        If Me.txtMakeNo.Text.ToString.Trim.Equals(String.Empty) Then
            hsKeys.Add("MakeNo", "")
        Else
            hsKeys.Add("MakeNo", "%" + Me.txtMakeNo.Text.ToString.Trim + "%")
        End If

        '生产实际日期区间
        hsKeys.Add("PFromDate", IIf(Me.PFromDate.Checked, Me.PFromDate.Value, ""))
        hsKeys.Add("PToDate", IIf(Me.PToDate.Checked, Me.PToDate.Value, ""))
        '检查实际日区间
        hsKeys.Add("CFromDate", IIf(Me.CFromDate.Checked, Me.CFromDate.Value, ""))
        hsKeys.Add("CToDate", IIf(Me.CToDate.Checked, Me.CToDate.Value, ""))

        'If Me.PFromdate.Text.ToString.Trim.Equals(String.Empty) Then
        '    hsKeys.Add("Date", "")
        'Else
        '    hsKeys.Add("Date", Me.PFromdate.Value)
        'End If

        '检查结果
        If Me.drpResult.SelectedIndex = 0 OrElse Me.drpResult.SelectedIndex = 1 Then
            hsKeys.Add("Result", "")
        Else
            hsKeys.Add("Result", Me.drpResult.SelectedValue.ToString)
        End If

        '检查员code
        If Me.txtChkUser.Text.ToString.Trim.Equals(String.Empty) Then
            hsKeys.Add("ChkUser", "")
        Else
            hsKeys.Add("ChkUser", "%" + Me.txtChkUser.Text.ToString.Trim + "%")
        End If

        If cbLine_name.SelectedIndex = -1 Or cbLine_name.SelectedIndex = 0 Then
            hsKeys.Add("line_name", "")
        Else
            hsKeys.Add("line_name", cbLine_name.Items(cbLine_name.SelectedIndex).ToString)
        End If



        '二次量试
        'If Me.ChkBoxTwoChk.Checked = False Then
        '    hsKeys.Add("check_times", "")
        'Else
        '    hsKeys.Add("check_times", "1")
        'End If

        Return hsKeys

    End Function

    ''' <summary>
    ''' 导出到Excel
    ''' </summary>
    ''' <param name="Table"></param>
    ''' <remarks></remarks>
    Private Sub ExportToExcel(ByVal Table As DataTable)

        '变量声明
        Dim strFileName As String
        Dim saveFileDialog As SaveFileDialog
        Dim xlBook = Nothing
        Dim xlSheet = Nothing
        Dim xlApp = Nothing
        Dim rowCount As Integer
        Dim colCount As Integer
        Dim arrData(0, 0) As String
        Try
            saveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls"
            saveFileDialog.FilterIndex = 0
            saveFileDialog.RestoreDirectory = True
            saveFileDialog.Title = "导出文件保存"
            saveFileDialog.ShowDialog()
            strFileName = saveFileDialog.FileName
            If String.IsNullOrEmpty(strFileName) Then
                Return
            End If
            Me.Cursor = Cursors.WaitCursor
            xlApp = CreateObject("Excel.Application")
            xlApp.Visible = False
            xlBook = xlApp.Workbooks.Add
            rowCount = Table.Rows.Count
            colCount = Table.Columns.Count
            ReDim arrData(rowCount, colCount)
            '列名设置
            arrData(0, 0) = "编号"
            arrData(0, 1) = "ID"
            arrData(0, 2) = "商品CODE"
            arrData(0, 3) = "商品作番"
            arrData(0, 4) = "生产线"
            arrData(0, 5) = "生产数量"
            arrData(0, 6) = "生产实际日"
            arrData(0, 7) = "纳期日"
            arrData(0, 8) = "方向"
            arrData(0, 9) = "部门"
            arrData(0, 10) = "检查员"
            arrData(0, 11) = "状态"
            arrData(0, 12) = "开始时间"
            arrData(0, 13) = "结束时间"
            arrData(0, 14) = "再检开始时间"
            arrData(0, 15) = "再检结束时间"
            arrData(0, 16) = "检查结果"
            arrData(0, 17) = "备注"
            arrData(0, 18) = "继承结果ID"
            arrData(0, 19) = "检查时长(秒)"

            For i As Integer = 1 To rowCount
                With Table.Rows(i - 1)
                    arrData(i, 0) = i.ToString
                    arrData(i, 1) = Convert.ToString(.Item("ID"))
                    arrData(i, 2) = Convert.ToString(.Item("商品CD"))
                    arrData(i, 3) = Convert.ToString(.Item("商品作番"))
                    arrData(i, 4) = Convert.ToString(.Item("生产线"))
                    arrData(i, 5) = Convert.ToString(.Item("生产数量"))
                    arrData(i, 6) = Convert.ToString(.Item("生产实际日"))
                    arrData(i, 7) = Convert.ToString(.Item("纳期日"))
                    arrData(i, 8) = Convert.ToString(.Item("方向"))
                    arrData(i, 9) = Convert.ToString(.Item("部门"))
                    arrData(i, 10) = Convert.ToString(.Item("检查员"))
                    arrData(i, 11) = Convert.ToString(.Item("状态"))
                    arrData(i, 12) = Convert.ToString(.Item("开始时间"))
                    arrData(i, 13) = Convert.ToString(.Item("结束时间"))
                    arrData(i, 14) = Convert.ToString(.Item("再检开始时间"))
                    arrData(i, 15) = Convert.ToString(.Item("再检结束时间"))
                    arrData(i, 16) = Convert.ToString(.Item("检查结果"))
                    arrData(i, 17) = Convert.ToString(.Item("备注"))
                    arrData(i, 18) = Convert.ToString(.Item("继承结果ID"))
                    arrData(i, 19) = Convert.ToString(.Item("检查时长(秒)"))
                End With
            Next
            '导出数据设定
            xlSheet = xlBook.Worksheets.Add()
            xlSheet.Name = "检查结果"
            For Each wkSheet In xlBook.Worksheets
                If wkSheet.Name <> "检查结果" Then
                    wkSheet.Delete()
                End If
            Next
            xlSheet.Activate()
            xlSheet.Range("A1").Resize(rowCount + 1, colCount).Value = arrData
            xlBook.SaveAs(strFileName)
            xlBook.Close()
            xlApp.Quit()

            Me.Cursor = Cursors.Arrow
            MessageBox.Show(MsgConst.M00004I, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Arrow
            If Not xlSheet Is Nothing Then
                ReleaseComObject(xlSheet)
            End If
            If Not xlBook Is Nothing Then
                ReleaseComObject(xlBook)
            End If
            If Not xlApp Is Nothing Then
                ReleaseComObject(xlApp)
            End If
        End Try

    End Sub

    ''' <summary>
    ''' 数据取得 一览显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDateAndShow()
        '数据取得
        Dim dtSearchData As DataTable = bc.GetSearchData(getSearchKey).Tables("SearchData")
        '数据源绑定
        Me.dgvChkResult.DataSource = dtSearchData

        If dtSearchData.Rows.Count > 0 Then

            '列绑定
            For i As Integer = 0 To dtSearchData.Columns.Count - 1
                '现在有问题
                Me.dgvChkResult.Columns(i).DataPropertyName = dtSearchData.Columns(i).ToString

                dgvChkResult.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells)

                'Me.dgvChkResult.Columns(i).Width = 80
            Next
            '宽度设置
            'Me.dgvChkResult.Columns(9).Width = 57

            '最后一列（商品ID）设为不可见
            Me.dgvChkResult.Columns(19).Visible = False
            'Me.dgvChkResult.Columns(11).Visible = False

            '查看详细按钮显示yangw2追加
            'Me.btnOpenDetail.Visible = True
            '状态隐藏
            Me.lblState.Visible = False
            Me.drpState.Visible = False
        Else
            MessageBox.Show(MsgConst.M00005I)
            Exit Sub
        End If
    End Sub
    ''' <summary>
    ''' 编辑区清空
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearEditZone()
        '遍历编辑区控件，全部清空
        For Each c As Control In Me.gbEdit.Controls
            If c.GetType Is GetType(TextBox) Then
                Dim ct As TextBox = DirectCast(c, TextBox)
                'ct.ReadOnly = False
                ct.Text = String.Empty
                'ct.ReadOnly = True
            ElseIf c.GetType Is GetType(ComboBox) Then
                Dim cb As ComboBox = DirectCast(c, ComboBox)
                cb.SelectedIndex = 0
            End If
        Next
    End Sub

    ''' <summary>
    ''' 查询区清空
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearSearchZone()
        '遍历查询区控件，全部清空
        For Each c As Control In Me.gbSearch.Controls
            If c.GetType Is GetType(TextBox) Then
                Dim ct As TextBox = DirectCast(c, TextBox)
                'ct.ReadOnly = False
                ct.Text = String.Empty
                'ct.ReadOnly = True
            ElseIf c.GetType Is GetType(ComboBox) Then
                Dim cb As ComboBox = DirectCast(c, ComboBox)
                cb.SelectedIndex = 0
            ElseIf c.GetType Is GetType(DateTimePicker) Then
                Dim dp As DateTimePicker = DirectCast(c, DateTimePicker)
                dp.ResetText()
            End If
        Next
    End Sub

#End Region

#Region "画面按钮相应事件"

    ''' <summary>
    ''' 检索按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '查看详细按钮隐藏yangw2追加
        'Me.btnOpenDetail.Visible = False
        GetDateAndShow()



        '更新按钮置灰
        Me.btnUpdate.Enabled = False
        Me.btnSakujyo.Enabled = False
        '详细置灰
        Me.btnOpenDetail.Enabled = False
        '清空可用
        Me.btnClear.Enabled = True
        '编辑区清空
        ClearEditZone()

    End Sub

    ''' <summary>
    ''' 导出按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        '当前日期取得（yyyyMMdd）
        'Dim strDateNow As String = String.Format("{0:yyyyMMdd}", bcCom.GetSystemDate())
        '导出
        ExportToExcel(bc.GetSearchData(getSearchKey).Tables("SearchData"))
    End Sub

    ''' <summary>
    ''' 更新按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        '状态
        Dim strState As String = "INIT"
        '检查结果ID
        Dim strChkID As String = Me.txtReultID.Text.ToString.Trim
        '修改结果
        Dim strResult As String = Me.drpEResult.SelectedValue.ToString
        '备注
        Dim strRemake As String = Me.txtRemark.Text.ToString.Trim
        '状态判断
        If Me.drpState.Visible = True Then
            strState = Me.drpState.SelectedValue.ToString
        End If

        '输入值检验
        If strChkID.Equals(String.Empty) Then
            MessageBox.Show("请选择要更新的结果！")
            Exit Sub
        End If
        '更新
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction

        Try
            Dim upTime As DateTime = bcCom.GetSystemDate()
            If bc.UpdateResult(PerDbTraneAction, strChkID, strResult, strRemake, Me.Login.UserId, upTime, strState) > 0 Then
                '日志表插入
                If bc.InsertLog(PerDbTraneAction, bcIndex.GetIndex(Consts.TYPEKBN.LOG), strChkID, Me.Login.UserId, upTime) > 0 Then
                    PerDbTraneAction.CloseCommit()
                Else
                    PerDbTraneAction.CloseRollback()
                    MessageBox.Show("日志写入失败！")
                End If
            Else
                PerDbTraneAction.CloseRollback()
                MessageBox.Show("数据更新失败！")
            End If
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            MessageBox.Show("数据更新失败！")
        End Try
        If drpState.Visible = True AndAlso drpState.SelectedValue.ToString = "0" Then
            Dim ac As New PersonalDataAccess.PersonalDbTransactionScopeAction

            Try

                Dim tongyong_cd As String = _
                bc.Gettongyong_cd(Me.txtEGoodsCd.Text.Trim)

                If tongyong_cd <> "" Then
                    If bc.UpdFirstCheck(ac, tongyong_cd) > 0 Then
                        ac.CloseCommit()
                    Else
                        ac.CloseRollback()
                    End If
                    'Else
                    '    ResultDA.InsFirstCheck(Me.tbxGoodsCd.Text.Trim, Me.tbxGoodsCd.Text.Trim)
                End If
            Catch ex As Exception
                ac.CloseRollback()
            End Try
        End If

        'txtEGoodsCd

        '编辑区清空
        ClearEditZone()
        '画面刷新
        GetDateAndShow()
        '按钮设置
        Me.btnClear.Enabled = True
        Me.btnUpdate.Enabled = False
        Me.btnSakujyo.Enabled = False
        Me.btnOpenDetail.Enabled = False

    End Sub
    ''' <summary>
    ''' 返回按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Try
            NavigateToNextPage("msMain")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 关闭按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            NavigateToNextPage("msLogin")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 清空按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click

        If MessageBox.Show("要清空么？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        '编辑区清空
        Me.ClearSearchZone()

        '一览内容清空
        Dim dtEmpty As DataTable
        dtEmpty = DirectCast(dgvChkResult.DataSource, DataTable)
        If dtEmpty Is Nothing = False Then
            dtEmpty.Rows.Clear()
            Me.dgvChkResult.DataSource = dtEmpty
        End If

        '更新按钮置灰
        Me.btnUpdate.Enabled = False
        Me.btnSakujyo.Enabled = False
        '详细置灰
        Me.btnOpenDetail.Enabled = False
        '选择行取消
        'Me.dgvChkResult.SelectedRows.Item(0).Selected = False

        '查看详细按钮隐藏yangw2追加
        ' Me.btnOpenDetail.Visible = False
        'Me.dgvChkResult.SelectedRows.Item(0).DefaultCellStyle.BackColor = Color.Red

    End Sub

    ''' <summary>
    ''' 查看详细
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOpenDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDetail.Click
        Dim strGoodsId As String = String.Empty
        Dim strSelectId As String = String.Empty
        With Me.dgvChkResult.SelectedRows.Item(0)
            '判断是否是继承检查结果
            If .Cells.Item(18).Value.ToString.Equals(String.Empty) Then
                '非继承的场合，结果ID为当前结果ID
                strSelectId = .Cells.Item(0).Value.ToString
            Else
                '继承的场合，结果ID为继承结果ID
                strSelectId = .Cells.Item(18).Value.ToString
            End If
            strGoodsId = .Cells.Item(19).Value.ToString
        End With
        Dim formDetail As New ResultDetail(strGoodsId, strSelectId)
        formDetail.Show()
    End Sub

#End Region

#Region "控件处理事件"


    ''' <summary>
    ''' 一览区行的单击处理事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvChkResult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChkResult.CellClick
        Try
            If e.RowIndex >= 0 Then
                Me.btnOpenDetail.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 一览区行的双击处理事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvChkResult_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvChkResult.CellMouseDoubleClick
        '编辑区赋值
        If e.RowIndex >= 0 Then
            With Me.dgvChkResult.SelectedRows.Item(0)
                'ID
                Me.txtReultID.Text = .Cells.Item(0).Value.ToString

                '商品code
                Me.txtEGoodsCd.Text = .Cells.Item(3).Value.ToString
                '商品作番
                Me.txtEMakeNo.Text = .Cells.Item(4).Value.ToString
                '生产线
                'Me.txtELine.Text = .Cells.Item(5).Value.ToString
                Me.txtELine.Text = ""
                '生产数量
                Me.txtENumber.Text = .Cells.Item(5).Value.ToString
                '生产实际日
                Me.txtFDate.Text = .Cells.Item(6).Value.ToString
                '纳期日
                Me.txtPDate.Text = .Cells.Item(7).Value.ToString
                '方向
                Me.txtEDirection.Text = .Cells.Item(8).Value.ToString
                '部门
                Me.txtEDptMent.Text = .Cells.Item(9).Value.ToString
                '检察员
                Me.txtEChkUser.Text = .Cells.Item(10).Value.ToString
                '状态
                If .Cells.Item(11).Value.ToString.Equals("待判") OrElse .Cells.Item(11).Value.ToString.Equals("临时数据") Then
                    Me.lblState.Visible = True
                    Me.drpState.Visible = True
                    Me.drpState.SelectedIndex = 1
                Else
                    Me.lblState.Visible = False
                    Me.drpState.Visible = False
                End If
                '开始时间
                Me.txtEStartTime.Text = .Cells.Item(12).Value.ToString
                '结束时间
                Me.txtEndTime.Text = .Cells.Item(13).Value.ToString
                '再检开始
                Me.txtUpEnd.Text = .Cells.Item(14).Value.ToString
                '再检结束
                Me.txtUpEnd.Text = .Cells.Item(15).Value.ToString
                '检查结果
                If .Cells.Item(16).Value.ToString.Equals("OK") Then
                    Me.drpEResult.SelectedIndex = 0
                Else
                    Me.drpEResult.SelectedIndex = 1
                End If
                '备注
                Me.txtRemark.Text = .Cells.Item(17).Value.ToString
                '检查次数
                Me.txtSharId.Text = .Cells.Item(18).Value.ToString


            End With
        End If
        '更新按钮可用
        Me.btnUpdate.Enabled = True
        Me.btnSakujyo.Enabled = True
        '详细按钮可用
        Me.btnOpenDetail.Enabled = True
        '清空按钮不可用
        Me.btnClear.Enabled = False
    End Sub

#End Region

#Region "其他"
    ''' <summary>
    ''' 点击一下就能选中或者取消选中（默认模式是先获得焦点，然后才能设置选中，需要点击两次）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkLDepartment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLDepartment.Click
        Dim chk As ColorCodedCheckedListBox = DirectCast(sender, ColorCodedCheckedListBox)
        chk.SetSelected(chk.SelectedIndex, True)
    End Sub
#End Region

    Private Sub btnSakujyo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSakujyo.Click

        If Me.txtReultID.Text.ToString.Trim() = "" Then
            MsgBox("请选择要删除的记录")
        Else

            If MessageBox.Show("要消除么？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            bc.Deletet_check_result(Me.txtReultID.Text.ToString.Trim())
            '编辑区清空
            ClearEditZone()
            '画面刷新
            GetDateAndShow()
            '按钮设置
            Me.btnClear.Enabled = True
            Me.btnUpdate.Enabled = False
            Me.btnSakujyo.Enabled = False
            Me.btnOpenDetail.Enabled = False
        End If




    End Sub
End Class
