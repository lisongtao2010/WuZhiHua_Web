Imports System.Data
Imports System.Collections.Generic

Imports System.Text.RegularExpressions

Partial Class _Default
    Inherits System.Web.UI.Page

    Public UserDA As New UserDA
    Private checkDA As New CheckDA

    Public xingfan_list As String

    'Load
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.tbxDate_key.Text = System.DateTime.Now.ToString("yyyy/MM/dd")

            If Context.Items("Goods_cd") IsNot Nothing Then
                Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
                Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
                Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
                kensaku()
            End If

            Dim ResultDA As New ResultDA


            Dim dt2 As DataTable = ResultDA.GetXingfan()
            Dim sb2 As New StringBuilder
            For i As Integer = 0 To dt2.Rows.Count - 1
                sb2.AppendLine("<option value=""" & dt2.Rows(i).Item(0).ToString.Trim & """>" & dt2.Rows(i).Item(0).ToString.Trim & "</option>")

            Next
            xingfan_list = sb2.ToString

            Dim dt As DataTable = ResultDA.GetMDlx()
            Dim sb As New StringBuilder
            For i As Integer = 0 To dt.Rows.Count - 1
                sb.Append(dt.Rows(i).Item(0).ToString.Trim)
                sb.Append(",")
                sb.Append(dt.Rows(i).Item(1).ToString.Trim)
                sb.Append(",")
                sb.Append(dt.Rows(i).Item(2).ToString.Trim)

                If i <> dt.Rows.Count - 1 Then
                    sb.Append("|")
                End If
            Next
            hidDLX.Value = sb.ToString

            ViewState("xingfan_list") = xingfan_list



            Me.tbxGoodsCd.Focus()
            Me.lblMessage.Text = "请输入商品CD"
        Else
            xingfan_list = ViewState("xingfan_list").ToString
        End If

    End Sub

#Region "检索"

    ''' <summary>
    ''' 检索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnKensaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKensaku.Click

        kensaku()

    End Sub

    '检索
    Sub kensaku()

        If Not CheckInput() Then
            Me.gvLastCheckResultMS.DataSource = Nothing
            gvLastCheckResultMS.DataBind()
            Me.btnReCheck.Visible = False
            Me.btnDefault.Visible = False
            Me.btnContinueCheck.Visible = False
            Me.lblHint.Text = ""
            GVFlg3.DataSource = Nothing
            GVFlg3.DataBind()
            Me.gvPlanMS.DataSource = Nothing
            Me.gvPlanMS.DataBind()
            Return
        End If

        '检查完了数据取得
        CheckCompleteDataBind()

        '检查中数据取得
        CheckingDataBind()

        '计划数据取得
        PlanDataBind()

    End Sub

    '检查完了数据取得
    Public Function CheckCompleteDataBind() As Boolean

        '一览表示 同批次数据取得 临时数据以外的数据continueflg <> 3
        Dim lastCheckResultMS As Data.DataTable = _
            checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "no")

        Dim ngDt As DataTable = checkDA.GetNgMS(Me.tbxGoodsCd.Text)
        If ngDt.Rows.Count > 0 Then
            gvNg.DataSource = ngDt
            gvNg.DataBind()
            lblNg.Visible = True
            gvNg.Visible = True
            btnHid.Visible = True
        Else
            lblNg.Visible = False
            gvNg.Visible = False
            btnHid.Visible = False
        End If


        Me.btnReCheck.Visible = True
        Me.btnDefault.Visible = False
        Me.btnContinueCheck.Visible = False
        Me.lblHint.Text = ""

        '同批次检查结果取得
        If lastCheckResultMS.Rows.Count > 0 Then

            If tbxMakeNumber.Text.Trim <> "" Then
                Me.btnReCheck.Visible = False
            Else
                Me.btnReCheck.Visible = True
            End If

            Dim rows As DataRow()
            '相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & GetBefore3Days() & "' And  作番 = '" & Me.tbxMakeNumber.Text & "' AND 状态='完了'", "结束时间 DESC")
            If rows.Length > 0 Then
                Me.lblHint.Text &= "本商品检查完了"
                GoTo SamePiCi
            End If


            Me.lblHint.Text &= " "
            '相同座番 是否有待判数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & GetBefore3Days() & "' And  作番 = '" & Me.tbxMakeNumber.Text & "'", "结束时间 DESC")
            If rows.Length > 0 Then
                Me.lblHint.Text &= " 本商品检查中"
                GoTo SamePiCi
            End If

        Else

            Me.lblHint.Text &= "不存在检查记录"
            Me.btnReCheck.Visible = True
            'Me.btnNoCheck.Visible = True
            GoTo SamePiCi

        End If


SamePiCi:

        Dim dt As DataTable = lastCheckResultMS.Clone
        dt.Clear()
        For Each dr As DataRow In GetDatatableRows(lastCheckResultMS, "开始时间>='" & GetBefore3Days() & "' AND 状态='完了'", "结束时间 DESC")
            dt.Rows.Add(dr.ItemArray)
        Next

        lblChecked.Visible = dt.Rows.Count > 0



        gvLastCheckResultMS.DataSource = dt
        gvLastCheckResultMS.DataBind()
        bdQianpin(dt, gvLastCheckResultMS)
        bdTodayRow(dt, gvLastCheckResultMS)
        Return dt.Rows.Count > 0

    End Function

    '检查中数据取得
    Public Function CheckingDataBind() As Boolean
        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "3")

        lblChecking.Visible = lastCheckResultMS.Rows.Count > 0

        GVFlg3.DataSource = lastCheckResultMS
        GVFlg3.DataBind()

        bdQianpin(lastCheckResultMS, GVFlg3)
        bdTodayRow(lastCheckResultMS, GVFlg3)
    End Function

    '计划数据取得
    Public Function PlanDataBind() As Boolean
        Dim planMS As Data.DataTable


        planMS = checkDA.GetPlanInfo(Me.tbxGoodsCd.Text, Me.tbxDate_key.Text)


        gvPlanMS.DataSource = planMS
        gvPlanMS.DataBind()


        'btnReCheck.Enabled = planMS.Rows.Count > 0

        If planMS.Rows.Count = 0 Then
            lblMessage.Text = "没有计划数据。。。"
        Else

        End If


        '中间材CD
        For i As Integer = 0 To planMS.Rows.Count - 1
            If planMS.Rows(i).Item("参照") = "1" Then '已经有参照数据
                CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Checked = True
                CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).ForeColor = Drawing.Color.Blue

                CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Enabled = False
                'CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).BackColor = Drawing.Color.Green
                gvPlanMS.Rows(i).BackColor = Drawing.Color.Silver
                'gvPlanMS.Rows(i).Style.Item("display") = "none"
            Else

                If planMS.Rows(i).Item("匹配型番").ToString.Split(","c).Length = 2 AndAlso planMS.Rows(i).Item("匹配型番").ToString.Split(","c)(1) = "" Then '只匹配到一个型番
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Checked = True
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).ForeColor = Drawing.Color.Blue
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Enabled = False
                    'CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).BackColor = Drawing.Color.Green
                    gvPlanMS.Rows(i).BackColor = Drawing.Color.Silver
                    'gvPlanMS.Rows(i).Style.Item("display") = "none"
                ElseIf Regex.Match(planMS.Rows(i).Item("中间材CD").ToString, "[a-zA-Z]" & tbxGoodsCd.Text.Trim & "[a-zA-Z0-9]").Success Then '输入型番 正则匹配
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Checked = True
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).ForeColor = Drawing.Color.Blue
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Enabled = True
                    'CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).BackColor = Drawing.Color.Yellow
                    gvPlanMS.Rows(i).BackColor = Drawing.Color.LightCoral
                Else '需要人工判断
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Checked = False
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).ForeColor = Drawing.Color.Blue
                    CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Enabled = True
                    'CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).BackColor = Drawing.Color.Yellow
                    gvPlanMS.Rows(i).BackColor = Drawing.Color.White
                End If
            End If

        Next

    End Function

    '画面入力项目检查
    Public Function CheckInput() As Boolean

        '入力检查
        If Me.tbxGoodsCd.Text.Trim = "" Then
            Me.lblMessage.Text = "请输入商品CD"
            tbxGoodsCd.Focus()
            Return False
        End If


        If Me.tbxCheckUserCd.Text.Trim = "" Then
            Me.tbxCheckUserCd.Text = Me.tbxCheckUserCd.Text.Trim
            Me.lblMessage.Text = "请输入检查员CD"
            tbxCheckUserCd.Focus()
            Return False
        End If

        '数据检查
        Dim userName As String = UserDA.GetUserName(tbxCheckUserCd.Text.Trim)
        If ComConst.IsErr(userName) Then
            Me.lblMessage.Text = "检查员不存在"
            tbxCheckUserCd.Text = ""
            tbxCheckUserCd.Focus()
            Return False
        End If

        If Me.tbxMakeNumber.Text.Trim = "" Then

            'Dim kbn As String = CInt(Right(CheckIndex.MakeNewIndex("QF", tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd")), 5)).ToString
            'Me.tbxMakeNumber.Text = kbn.Trim
            Me.lblMessage.Text = "区分自动生成"

        Else
            Me.lblMessage.Text = ""
        End If


        Return True

    End Function

    '今日的行作成
    Function bdTodayRow(ByVal dt As DataTable, ByVal gv As GridView) As String
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("开始时间") >= DateAdd(DateInterval.Day, 0, Now).ToString("yyyy/MM/dd") & " 00:00:00" Then
                gv.Rows(i).BackColor = Drawing.Color.LightSkyBlue
            End If
        Next
        Return ""
    End Function

    '前3日时间取得
    Public Function GetBefore3Days() As String
        Return DateAdd(DateInterval.Day, -24, Now).ToString("yyyy/MM/dd") & " 00:00:00"
    End Function

    ''' <summary>
    ''' h获得行数据
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="key"></param>
    ''' <param name="sort"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDatatableRows(ByVal data As DataTable, ByVal key As String, ByVal sort As String) As DataRow()
        Dim dtNew As New DataTable
        dtNew = data.Copy
        Return dtNew.Select(key, sort)
    End Function

#End Region

#Region "欠品"

    Function bdQianpin(ByVal dt As DataTable, ByVal gv As GridView) As String
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("qianpin_flg") IsNot DBNull.Value AndAlso dt.Rows(i).Item("qianpin_flg") = "1" Then
                CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Checked = True
            Else
                CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Checked = False
            End If

            CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Attributes.Item("onclick") = "fnUpdQianpin(this,'" & dt.Rows(i).Item("ID") & "')"

        Next
        Return ""
    End Function

#End Region

#Region "画面Style设置"
    Public Function GetSameMakeNoFontColor(ByVal value As String) As String
        If value = Me.tbxMakeNumber.Text Then
            Return "blue"
        Else
            Return "#000"
        End If
    End Function

#End Region

    ''' <summary>
    ''' 新规检查
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnReCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReCheck.Click

        Rireki.InsRireki("新规检查Start", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        'If Me.tbxXingfan.Text.Trim = "" Then
        '    Me.lblHint.Text = "请输入型番"
        '    Exit Sub
        'End If

        If Me.hidBumen.Value = "" Then
            Me.lblHint.Text = "没选部门"
            Exit Sub
        End If

        If Me.hidLineName.Value = "" Then
            Me.lblHint.Text = "没选生产线"
            Exit Sub
        End If


        '如果区分没有输入 那么 自动生成
        If Me.tbxMakeNumber.Text.Trim = "" Then
            Dim kbn As String = CInt(Right(CheckIndex.MakeNewIndex("QF", tbxCheckUserCd.Text.Trim, "11111111", 8), 8)).ToString
            Me.tbxMakeNumber.Text = kbn.Trim
        Else
            Dim lastCheckResultMS As Data.DataTable = _
            checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "no")

            If lastCheckResultMS.Rows.Count > 0 Then
                Me.lblHint.Text = "本商品存在检查记录"
                Exit Sub
            End If

        End If


        'Exit Sub

        '采番
        Dim crIndex As String = _
        CheckIndex.MakeNewIndex("CR", Me.tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd"))

        '结果临时数据作成
        Dim ResultDA As New ResultDA
        ResultDA.InsertResultTemp(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxMakeNumber.Text.Trim, Me.tbxCheckUserCd.Text.Trim)

        '结果明细临时数据作成
        ResultDA.InsertResultDetailWaiguan(crIndex, Me.tbxGoodsCd.Text.Trim)


        ResultDA.ins_t_dlx_chk(crIndex, Me.hidBumen.Value, Me.hidLineName.Value, tbxGoodsCd.Text.Trim, lblChkKbn.Items(lblChkKbn.SelectedIndex).Value)


        '选择行的作番取得
        Dim selectedMakeNumberList As ArrayList
        selectedMakeNumberList = New ArrayList
        For i As Integer = 0 To gvPlanMS.Rows.Count - 1
            If CType(gvPlanMS.Rows(i).FindControl("cbMerge"), CheckBox).Checked = True Then
                selectedMakeNumberList.Add(CType(gvPlanMS.Rows(i).FindControl("lblmakeNumber"), Label).Text)
            End If
        Next

        If selectedMakeNumberList.Count <> 0 Then
            '型番与Code的对照表作成
            ResultDA.ins_m_code_reference(Me.tbxGoodsCd.Text.Trim, selectedMakeNumberList)

            '计划检查完了表作成
            ResultDA.ins_m_plan_check_finished(crIndex, selectedMakeNumberList)
        End If



        Rireki.InsRireki("新规检查End", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)


        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = crIndex
        Server.Transfer("CheckCunFaMobile.aspx")

    End Sub

    '默认检查
    Protected Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefault.Click


        'If Me.tbxXingfan.Text.Trim = "" Then
        '    Me.lblHint.Text = "请输入型番"
        '    Exit Sub
        'End If

        If Me.hidBumen.Value = "" Then
            Me.lblHint.Text = "没选部门"
            Exit Sub
        End If

        If Me.hidLineName.Value = "" Then
            Me.lblHint.Text = "没选生产线"
            Exit Sub
        End If


        Dim crIndex As String = CheckIndex.MakeNewIndex("CR", Me.tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd"))

        '结果临时数据作成
        Dim ResultDA As New ResultDA
        ResultDA.InsertResultMoren(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxMakeNumber.Text.Trim, Me.tbxCheckUserCd.Text.Trim, ViewState("shareId"))


        ResultDA.ins_t_dlx_chk(crIndex, Me.hidBumen.Value, Me.hidLineName.Value, tbxGoodsCd.Text.Trim, lblChkKbn.Items(lblChkKbn.SelectedIndex).Value)

        ResultDA.InsertResultDetail(crIndex, ViewState("shareId"))
        ResultDA.Updatet_check_result_continue_chk_flg(crIndex, "2")

        '结果明细临时数据作成
        'ResultDA.InsertResultDetailWaiguan(crIndex, Me.tbxGoodsCd.Text.Trim)

        kensaku()

    End Sub

    Protected Sub btnContinueCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueCheck.Click
        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = ViewState("result_id").ToString
        Server.Transfer("CheckCunFaMobile.aspx")
    End Sub

    ''' <summary>
    ''' 编辑
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Rireki.InsRireki("编辑", Me.hidResultID.Value, "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.hidKbn.Value
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = Me.hidResultID.Value
        Server.Transfer("CheckCunFaMobile.aspx")
    End Sub

    Public Function SetDateF(ByVal v As String) As String

        If v.Trim = "" Then
            Return ""
        Else
            Return CDate(v).ToString("yy/MM/dd HH:mm")
        End If
    End Function

    Public Function SetDateYMD(ByVal v As String) As String

        If v.Trim = "" Then
            Return ""
        Else
            Return CDate(v).ToString("yyyy-MM-dd")
        End If
    End Function

    Protected Sub btnByHand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByHand1.Click

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = Me.hidResultID.Value
        Server.Transfer("InputByHand.aspx")

    End Sub


    Protected Sub btnByHand2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByHand2.Click
        Server.Transfer("Default.aspx")
    End Sub


    ''' <summary>
    ''' 前一日
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnPreDay_Click(sender As Object, e As EventArgs) Handles btnPreDay.Click
        If Me.tbxDate_key.Text = "" Then
            Me.tbxDate_key.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")
        Else
            Me.tbxDate_key.Text = Convert.ToDateTime(Me.tbxDate_key.Text).AddDays(-1).ToString("yyyy/MM/dd")
        End If

        kensaku()

    End Sub

    ''' <summary>
    ''' 后一日
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnNextDay_Click(sender As Object, e As EventArgs) Handles btnNextDay.Click
        If Me.tbxDate_key.Text = "" Then
            Me.tbxDate_key.Text = System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd")
        Else
            Me.tbxDate_key.Text = Convert.ToDateTime(Me.tbxDate_key.Text).AddDays(1).ToString("yyyy/MM/dd")
        End If

        kensaku()

    End Sub


End Class
