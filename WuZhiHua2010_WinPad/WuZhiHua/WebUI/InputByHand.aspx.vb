Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Public UserDA As New UserDA
    Private checkDA As New CheckDA


    Sub kensaku()

        If Not CheckInput() Then
            Return
        End If

        '同批次数据表示
        If Not ShowSamePiCi() Then
            '如果不存在同批次 ， 判断检查结果表是否已经有检查记录
            ShowOldCheckResult()
        End If

        Dim lastLineAndSuuMS As Data.DataTable = _
        checkDA.GetLineAndSuuFrom_TB_CompleteData(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text)

        If lastLineAndSuuMS.Rows.Count > 0 Then
            Me.tbxLineCd.Text = lastLineAndSuuMS.Rows(0).Item("生产线")
            Me.tbxSuu.Text = lastLineAndSuuMS.Rows(0).Item("数量")

        End If


        '一览表示 同批次数据取得
        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "3")


        GVFlg3.DataSource = lastCheckResultMS
        GVFlg3.DataBind()


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
                Me.btnDefault.Visible = True
                Me.btnReCheck.Visible = True


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

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    If dt.Rows(i).Item("qianpin_flg") IsNot DBNull.Value AndAlso dt.Rows(i).Item("qianpin_flg") = "1" Then
        '        CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Checked = True
        '    Else
        '        CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Checked = False
        '    End If

        '    CType(gv.Rows(i).FindControl("cbQianpin"), CheckBox).Attributes.Item("onclick") = "fnUpdQianpin(this,'" & dt.Rows(i).Item("ID") & "')"

        'Next

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
            Return False
        End If

        If Me.tbxMakeNumber.Text.Trim = "" Then
            Me.lblMessage.Text = "请输入座番"
            Return False
        End If

        If Me.tbxCheckUserCd.Text.Trim = "" Then
            Me.tbxCheckUserCd.Text = Me.tbxCheckUserCd.Text.Trim
            Me.lblMessage.Text = "请输入检查员CD"
            Return False
        End If

        '数据检查
        Dim userName As String = UserDA.GetUserName(tbxCheckUserCd.Text.Trim)
        If ComConst.IsErr(userName) Then
            Me.lblMessage.Text = "检查员不存在"
            Return False
        End If

        Me.lblMessage.Text = ""

        Return True

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Context.Items("Goods_cd") IsNot Nothing Then
            Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
            Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
            Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
            Me.tbxLineCd.Text = Context.Items("tbxLineCd")

            kensaku()

        End If

    End Sub
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click


        If Me.tbxMakeNumber.Text <> "" Then

            Dim dt As Data.DataTable = _
            checkDA.GetGoodCdByMakeNo(Me.tbxMakeNumber.Text)

            If dt.Rows.Count > 0 Then

                Me.tbxGoodsCd.Text = dt.Rows(0).Item(0).ToString

                'Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
                'Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
                'Me.tbxLineCd.Text = Context.Items("tbxLineCd")

            Else
                Me.lblMessage.Text = "座番不存在"
            End If


            kensaku()
        Else
            Me.lblMessage.Text = "座番未入力"

        End If
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click


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


    Protected Sub btnToroku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTorokuNew.Click

        Rireki.InsRireki("手入力-Start", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim result As String
        If Me.rbtnOk.Checked Then
            result = "OK"
        Else
            result = "NG"
        End If

        If CheckInput() = False Then

            Exit Sub
        End If
        '输入检查
        If Me.tbxGoodsCd.Text = "" OrElse Me.tbxMakeNumber.Text = "" OrElse Me.tbxCheckUserCd.Text = "" Then
            Me.lblMessage.Text = ("信息请输入完整")
            Exit Sub
        End If

        '采番
        Dim crIndex As String = _
        CheckIndex.MakeNewIndex("CR", Me.tbxCheckUserCd.Text.Trim, Now.ToString("yyyyMMdd"))

        Dim rl As Integer



        '结果临时数据作成
        Dim ResultDA As New ResultDA
        rl = ResultDA.InsertResultByHand(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxMakeNumber.Text.Trim, Me.tbxCheckUserCd.Text.Trim, Me.tbxLineCd.Text, result)

        If rl > 0 Then
            '结果明细临时数据作成
            ResultDA.InsertResultDetailWaiguan(crIndex, Me.tbxGoodsCd.Text.Trim, Me.tbxCheckUserCd.Text.Trim)

            Dim tongyong_cd As String = _
            checkDA.Gettongyong_cd(Me.tbxGoodsCd.Text.Trim)

            If tongyong_cd <> "" Then
                ResultDA.UpdFirstCheck(tongyong_cd)
            End If

        Else

            Rireki.InsRireki("手入力-t_check_result登录", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "商品不存在 手入力不成功", Me.tbxCheckUserCd.Text.Trim)
            Me.lblMessage.Text = ("商品不存在 手入力不成功")
            Exit Sub
        End If

        Rireki.InsRireki("手入力-End", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("tbxLineCd") = Me.tbxLineCd.Text
        Me.lblMessage.Text = ""
        Server.Transfer("InputByHand.aspx")
    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub


End Class
