Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Public UserDA As New UserDA
    Private checkDA As New CheckDA

    ''' <summary>
    ''' 检索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnKensaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKensaku.Click

        kensaku()

    End Sub

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
            Return
        End If

        '同批次数据表示
        If Not ShowSamePiCi() Then
            '如果不存在同批次 ， 判断检查结果表是否已经有检查记录
            ShowOldCheckResult()
        End If


        '一览表示 同批次数据取得
        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "3")


        GVFlg3.DataSource = lastCheckResultMS
        GVFlg3.DataBind()

        bdQianpin(GVFlg3, lastCheckResultMS)

    End Sub


#Region "同批次"

    '同批次数据表示
    Public Function ShowSamePiCi() As Boolean

        '一览表示 同批次数据取得
        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_TB_CompleteData(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text)

        Dim rows As DataRow()

        Me.btnReCheck.Visible = False
        Me.btnDefault.Visible = False
        Me.btnContinueCheck.Visible = False
        ''Me.btnNoCheck.Visible = False
        Me.lblHint.Text = ""

        '同批次检查结果取得
        If lastCheckResultMS.Rows.Count > 0 Then
            Me.lblHint.Text &= " 新生产已入力!"

            '相同座番 是否有待判数据 判定

            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  作番 = '" & Me.tbxMakeNumber.Text & "' AND 状态='待判'", "结束时间 DESC")
            If rows.Length > 0 Then

                'CASE1  存在待判的场合。选项：1 重新检查 2 继续检查  3 不检查
                Me.btnContinueCheck.Visible = True
                Me.lblHint.Text &= " 【继续检查】：检查前次未完了商品"

                Me.btnReCheck.Visible = True
                ''Me.btnNoCheck.Visible = True

                GoTo SamePiCi

            End If


            '相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  作番 = '" & Me.tbxMakeNumber.Text & "' AND 状态='完了'", "结束时间 DESC")
            If rows.Length > 0 Then

                ViewState("shareId") = rows(0).Item("ID")

                'CASE1  存在待判的场合。选项：1 重新检查 2 默认检查  3 不检查
                Me.btnDefault.Visible = True '2 默认检查

                Me.btnReCheck.Visible = True '1 重新检查


                ''Me.btnNoCheck.Visible = True
                GoTo SamePiCi

            End If


            '不相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='待判'", "结束时间 DESC")
            If rows.Length > 0 Then
                'CASE1  存在待判的场合。选项：1 重新检查 2 继续检查  3 不检查
                Me.btnReCheck.Visible = True
                Me.btnContinueCheck.Visible = True
                ''Me.btnNoCheck.Visible = True
                GoTo SamePiCi

            End If

            '不相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='完了'", "结束时间 DESC")
            If rows.Length > 0 Then

                ViewState("shareId") = rows(0).Item("ID")
                'CASE1  存在待判的场合。选项：用户选项：1 重新检查 2 默认结果 3 不检查
                Me.btnDefault.Visible = True

                Me.btnReCheck.Visible = True


                'Me.btnNoCheck.Visible = True
                GoTo SamePiCi

            End If


        Else
            Me.lblHint.Text &= " 新生产未入力!"





        End If


SamePiCi:
        If lastCheckResultMS.Rows.Count > 0 Then

            If lastCheckResultMS.Select("开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='待判'").Length > 0 Then
                ViewState("result_id") = lastCheckResultMS.Select("开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='待判'")(0).Item("ID")
            End If


        End If

        gvLastCheckResultMS.DataSource = lastCheckResultMS
        gvLastCheckResultMS.DataBind()
        bdQianpin(gvLastCheckResultMS, lastCheckResultMS)

        Return lastCheckResultMS.Select("开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' ").Length > 0

    End Function

    Function bdQianpin(ByVal gv As GridView, ByVal dt As DataTable) As String

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


    '同批次数据不存在 ，检查结果表数据取得
    Public Function ShowOldCheckResult() As Boolean

        '一览表示 同批次数据取得 临时数据以外的数据continueflg <> 3
        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "<>3")

        Me.btnReCheck.Visible = True
        Me.btnDefault.Visible = False
        Me.btnContinueCheck.Visible = False
        ''Me.btnNoCheck.Visible = False
        Me.lblHint.Text = ""

        '同批次检查结果取得
        If lastCheckResultMS.Rows.Count > 0 Then

            Me.lblHint.Text &= " 新生产未入力 "
            '相同座番 是否有待判数据 判定
            Dim rows As DataRow()
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  作番 = '" & Me.tbxMakeNumber.Text & "' AND 状态='待判'", "结束时间 DESC")
            If rows.Length > 0 Then
                Me.lblHint.Text &= " 并且已经存在 待判的 检查结果"

                'CASE1  存在待判的场合。选项：1 重新检查 2 继续检查  3 不检查
                Me.btnContinueCheck.Visible = True
                Me.lblHint.Text &= " 【继续检查】：检查前次未完了商品"

                Me.btnReCheck.Visible = True
                'Me.btnNoCheck.Visible = True

                GoTo SamePiCi

            End If


            '相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  作番 = '" & Me.tbxMakeNumber.Text & "' AND 状态='完了'", "结束时间 DESC")
            If rows.Length > 0 Then
                'CASE1  存在待判的场合。选项：1 重新检查 2 默认检查  3 不检查
                Me.lblHint.Text &= "本商品检查完了，需要重新检查 请点击 重新检查按钮"
                Me.btnReCheck.Visible = True
                'Me.btnNoCheck.Visible = True
                GoTo SamePiCi

            End If


            '相同座番 完了数据 判定
            rows = GetDatatableRows(lastCheckResultMS, "开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  作番 = '" & Me.tbxMakeNumber.Text & "'", "结束时间 DESC")
            If rows.Length > 0 Then
                'CASE1  存在待判的场合。选项：1 重新检查 2 默认检查  3 不检查
                Me.lblHint.Text = ""
                Me.btnReCheck.Visible = True
                'Me.btnNoCheck.Visible = True
                GoTo SamePiCi

            End If


        Else

            Me.lblHint.Text &= " 新生产可能未入力 并且不存在检查记录"
            Me.btnReCheck.Visible = True
            'Me.btnNoCheck.Visible = True
            GoTo SamePiCi

        End If


SamePiCi:
        If lastCheckResultMS.Rows.Count > 0 Then
            If lastCheckResultMS.Select("开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='待判'").Length > 0 Then
                ViewState("result_id") = lastCheckResultMS.Select("开始时间>='" & Now.ToString("yyyy/MM/dd") & " 00:00:00' And  状态='待判'")(0).Item("ID")
            End If
        End If



        gvLastCheckResultMS.DataSource = lastCheckResultMS
        gvLastCheckResultMS.DataBind()
        bdQianpin(gvLastCheckResultMS, lastCheckResultMS)
        Return lastCheckResultMS.Rows.Count > 0

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


    '画面入力项目检查
    Public Function CheckInput() As Boolean

        '入力检查
        If Me.tbxGoodsCd.Text.Trim = "" Then
            Me.lblMessage.Text = "请输入商品CD"
            tbxGoodsCd.Focus()
            Return False
        End If

        If Me.tbxMakeNumber.Text.Trim = "" Then
            Me.lblMessage.Text = "请输入座番"
            tbxMakeNumber.Focus()
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

        Me.lblMessage.Text = ""

        Return True

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.tbxGoodsCd.Focus()
            Me.lblMessage.Text = "请输入商品CD"
        End If
    End Sub

    ''' <summary>
    ''' 新规检查
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnReCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReCheck.Click

        Rireki.InsRireki("新规检查Start", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        '采番
        Dim crIndex As String = _
        CheckIndex.MakeNewIndex("CR", Me.tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd"))

        '结果临时数据作成
        Dim ResultDA As New ResultDA
        ResultDA.InsertResultTemp(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxMakeNumber.Text.Trim, Me.tbxCheckUserCd.Text.Trim)

        '结果明细临时数据作成
        ResultDA.InsertResultDetailWaiguan(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxCheckUserCd.Text.Trim)
        Rireki.InsRireki("新规检查End", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = crIndex
        Server.Transfer("CheckCunFaMobile.aspx")

    End Sub

    '默认检查
    Protected Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefault.Click

        Rireki.InsRireki("默认结果Start", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Dim crIndex As String = CheckIndex.MakeNewIndex("CR", Me.tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd"))

        '结果临时数据作成
        Dim ResultDA As New ResultDA
        ResultDA.InsertResultMoren(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxMakeNumber.Text.Trim, Me.tbxCheckUserCd.Text.Trim, ViewState("shareId"))
        ResultDA.InsertResultDetail(crIndex, ViewState("shareId"), Me.tbxCheckUserCd.Text.Trim)
        ResultDA.Updatet_check_result_continue_chk_flg(crIndex, "2", Me.tbxCheckUserCd.Text.Trim, "")

        Rireki.InsRireki("默认结果End", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        '结果明细临时数据作成
        'ResultDA.InsertResultDetailWaiguan(crIndex, Me.tbxGoodsCd.Text.Trim)

        kensaku()

    End Sub
    Protected Sub btnContinueCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueCheck.Click

        Rireki.InsRireki("继续检查", ViewState("result_id").ToString, "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = ViewState("result_id").ToString
        Server.Transfer("CheckCunFaMobile.aspx")
    End Sub


    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Rireki.InsRireki("编辑", Me.hidResultID.Value, "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
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

    Protected Sub btnByHand1_Load(sender As Object, e As System.EventArgs) Handles btnByHand1.Load
        tbxGoodsCd.Attributes.Item("AutoCompleteType") = "off"
        tbxMakeNumber.Attributes.Item("AutoCompleteType") = "off"
    End Sub
End Class
