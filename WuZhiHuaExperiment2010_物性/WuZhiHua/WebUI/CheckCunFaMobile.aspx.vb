Imports System.Data

Partial Class CheckCunFaMobile
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        If Not IsPostBack Then



            ''寸法取得 种类列表
            'Dim cunFaKindsList As Data.DataTable = _
            'checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "01", "")

            'Me.gvGoodsKins.DataSource = cunFaKindsList
            'Me.gvGoodsKins.DataBind()

            'Dim zhijuKindsList As Data.DataTable = _
            'checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "02", "")

            Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
            Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
            Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
            Me.hidResult_id.Value = Context.Items("Result_id")
            Me.hidGoods_cd.Value = Context.Items("Goods_cd")

            If Context.Items("classify_id") IsNot Nothing Then
                hidClassify_id.Value = Context.Items("classify_id")
            End If



            Me.hidKind_cd.Value = "01" '外观01 治具 02 
            'Me.hidClassify_id.Value = "00013351" 'zhijuKindsList或cunFaKindsList 选择的classify_id
            'Me.hidTools_id.Value = "2015090200003"
            'Me.hidPicture_id.Value = "0001093"

            Dim result_id As String = Me.hidResult_id.Value
            Dim goods_cd As String = Me.hidGoods_cd.Value
            Dim kind_cd As String = Me.hidKind_cd.Value
            Dim classify_id As String = Me.hidClassify_id.Value
            Dim tools_id As String = Me.hidTools_id.Value
            Dim picture_id As String = Me.hidPicture_id.Value

            imgLook.ImageUrl = "Img.aspx?id=" & picture_id



            GridViewBind(result_id, goods_cd, kind_cd, classify_id, tools_id)

            lbl_RESULT_MSG.Text = Com.GetResultMsg(result_id)

        End If





    End Sub

    Public Function GridViewBind(ByVal result_id As String, ByVal goods_cd As String, ByVal kind_cd As String, ByVal classify_id As String, ByVal tools_id As String) As Boolean

        If hidKind_Name.Value <> "" Then
            Dim cunFaKindsList As Data.DataTable = _
            checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "01", "", "")

            For i As Integer = 0 To cunFaKindsList.Rows.Count - 1
                ' If hidKind_Name.Value.IndexOf(cunFaKindsList.Rows(i).Item("classify_name")) > 0 Then
                If Right(hidKind_Name.Value, cunFaKindsList.Rows(i).Item("classify_name").ToString.Length) = cunFaKindsList.Rows(i).Item("classify_name") Then
                    Me.hidClassify_id.Value = cunFaKindsList.Rows(i).Item("classify_id")
                    classify_id = Me.hidClassify_id.Value
                End If
            Next

        End If

        Dim checkMs As Data.DataTable = _
        checkDA.GetChkDetailInfo(result_id, goods_cd, kind_cd, classify_id, tools_id)

        Me.gvLastCheckResultMS.DataSource = checkMs
        Me.gvLastCheckResultMS.DataBind()


        For i As Integer = 0 To checkMs.Rows.Count - 1

            If checkMs.Rows(0).Item("kind") = "ピーリング" _
                OrElse checkMs.Rows(0).Item("kind") = "クリープ" _
                OrElse checkMs.Rows(0).Item("kind") = "平面引张" _
                OrElse checkMs.Rows(0).Item("kind") = "平面引张" _
                OrElse checkMs.Rows(0).Item("kind") = "表面胶合强度" _
                OrElse checkMs.Rows(0).Item("kind") = "浸渍剥离" Then

                Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
                Context.Items("Goods_cd") = Me.hidGoods_cd.Value
                Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
                Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
                Context.Items("Result_id") = Me.hidResult_id.Value
                Context.Items("classify_id") = classify_id

                Server.Transfer("NewCheckCunFaMobile.aspx")


            End If

            Me.lblKind.Text = checkMs.Rows(0).Item("kind")

            ''小口标签时  警告按钮不可用
            'If Me.lblKind.Text = "小口标签" Then
            '    tdJinggao.Attributes.Item("onclick") = ""
            '    tdJinggao.InnerText = ""
            'Else
            '    tdJinggao.Attributes.Item("onclick") = "KeyBoard(this);"
            '    tdJinggao.InnerText = "警"


            'End If

            Dim conCell结果 As Integer = 5

            gvLastCheckResultMS.Rows(i).Attributes.Add("onfocus", "RowSelect(this)")
            gvLastCheckResultMS.Rows(i).Attributes.Add("tabindex", "-1")
            gvLastCheckResultMS.Rows(i).Attributes.Add("zID", checkMs.Rows(i).Item("id"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_type", checkMs.Rows(i).Item("benchmark_type"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value1", checkMs.Rows(i).Item("benchmark_value1"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value2", checkMs.Rows(i).Item("benchmark_value2"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value3", checkMs.Rows(i).Item("benchmark_value3"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("check_times", isnullone(checkMs.Rows(i).Item("check_times")))
            gvLastCheckResultMS.Rows(i).Attributes.Add("dis_no", checkMs.Rows(i).Item("dis_no"))


            Select Case checkMs.Rows(i).Item("result").ToString.Trim
                Case "OK", "SD"
                    gvLastCheckResultMS.Rows(i).Cells(conCell结果).Attributes.CssStyle.Item("background-color") = "#93FF93" '绿
                Case "JN"
                    gvLastCheckResultMS.Rows(i).Cells(conCell结果).Attributes.CssStyle.Item("background-color") = "#93FF93" '绿
                Case ""

                Case Else
                    gvLastCheckResultMS.Rows(i).Cells(conCell结果).Attributes.CssStyle.Item("background-color") = "#FF2D2D" '红
            End Select


        Next
        Return True

    End Function

    Public Function isnullone(ByVal v As Object) As String
        If v Is DBNull.Value Then
            Return "1"
        Else
            Return v.ToString
        End If

    End Function


    Public Function GetKindLinks() As String

        '寸法取得 种类列表
        Dim cunFaKindsList As Data.DataTable = _
        checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "01", "", "")


        'For i As Integer = 0 To cunFaKindsList.Rows.Count - 1
        '    '选择的行
        '    If Me.hidClassify_id.Value = cunFaKindsList.Rows(i).Item("classify_id").ToString Then
        '        Me.gvGoodsKins.Rows(i).Style.Item("background-color") = "#FFE4B5"
        '    End If
        'Next

        Dim idx As Integer = 1

        Dim sb As New StringBuilder

        sb.Append("<table>")
        For i As Integer = 0 To cunFaKindsList.Rows.Count - 1

            If idx Mod 5 = 1 Then
                sb.Append("<tr>")
            End If
            sb.Append("<td>")

            Dim result_id As String = Me.hidResult_id.Value
            Dim goods_cd As String = Me.hidGoods_cd.Value
            Dim kind_cd As String = Me.hidKind_cd.Value
            Dim classify_id As String = Me.hidClassify_id.Value
            Dim tools_id As String = Me.hidTools_id.Value
            Dim picture_id As String = Me.hidPicture_id.Value


            Dim checkMs As Data.DataTable = _
            checkDA.GetChkDetailInfo(result_id, goods_cd, kind_cd, cunFaKindsList.Rows(i).Item("classify_id").ToString, tools_id)





            sb.Append("<a ")
            sb.Append(" style=""text-align:center;margin-left:10px;text-decoration:underline;white-space:nowrap;")

            If checkMs.Select("result='M1' OR result='M2' OR result='M3' OR result='NG'").Length > 0 Then
                sb.Append("color:red;")

            ElseIf checkMs.Select("result='OK' OR result='SD' OR result='JN'").Length = checkMs.Rows.Count Then
                sb.Append("color:#00A600;")

            ElseIf checkMs.Select("result='OK' OR result='SD' OR result='JN'").Length > 0 Then
                'sb.Append("color:#0000E3;")
                '没有错误  而且不是全部OK 那么表示 NG
                sb.Append("color:red;")

            Else

            End If

            If Me.hidClassify_id.Value = cunFaKindsList.Rows(i).Item("classify_id").ToString Then
                sb.Append("font-size:34px;")
                sb.Append("background-color:#FFE4B5;")
                sb.Append("""")
                sb.Append(" class='JQ_SELECT_CELL'")


                If checkMs.Select("result='M1' OR result='M2' OR result='M3' OR result='NG'").Length > 0 Then
                    lblKind.ForeColor = Drawing.Color.Red
                    lblKind.Attributes.CssStyle.Add("color", "red")
                ElseIf checkMs.Select("result='OK' OR result='SD'").Length = checkMs.Rows.Count Then
                    'lblKind.Attributes.CssStyle.Item("color") = "#00A600"
                    lblKind.Attributes.CssStyle.Add("color", "#00A600")
                    lblKind.ForeColor = Drawing.Color.Red
                ElseIf checkMs.Select("result='OK' OR result='SD'").Length > 0 Then
                    'lblKind.Attributes.CssStyle.Item("color") = "#0000E3"

                    lblKind.Attributes.CssStyle.Add("color", "#0000E3")
                Else

                End If


                imgLook.ImageUrl = "Img.aspx?id=" & cunFaKindsList.Rows(i).Item("picture_id").ToString
            Else
                sb.Append("font-size:30px;")
                sb.Append("""")
            End If


            sb.Append(" onclick = ""SelectKind(this,'" & cunFaKindsList.Rows(i).Item("classify_id").ToString & "')"">")
            sb.Append((i + 1).ToString & ".")
            sb.Append(cunFaKindsList.Rows(i).Item("classify_name").ToString)
            sb.Append("</a>")
            sb.Append(vbNewLine)
            sb.Append("</td>")
            If idx Mod 5 = 0 Then
                sb.Append("</tr>")
            End If

            idx += 1
        Next

        sb.Append("</table>")
        Return sb.ToString

    End Function

    Protected Sub btnKensaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKensaku.Click


        Dim result_id As String = Me.hidResult_id.Value
        Dim goods_cd As String = Me.hidGoods_cd.Value
        Dim kind_cd As String = Me.hidKind_cd.Value
        Dim classify_id As String = Me.hidClassify_id.Value
        Dim tools_id As String = Me.hidTools_id.Value
        Dim picture_id As String = Me.hidPicture_id.Value



        GridViewBind(result_id, goods_cd, kind_cd, classify_id, tools_id)
        lbl_RESULT_MSG.Text = Com.GetResultMsg(result_id)
    End Sub


    '类型Scan Or Input
    Public Function GetTextBoxClass(ByVal key As String) As String
        If key = "扫码" Then
            Return "textbox_scan"
        Else
            Return "textbox_input"
        End If
    End Function

    Public Function GetTextJieguo(ByVal jieguo As String) As String

        If jieguo = "OK" Then
            jieguo = "合"
        ElseIf jieguo = "SD" Then
            jieguo = "微"
        ElseIf jieguo = "M1" Then
            jieguo = "轻"
        ElseIf jieguo = "M2" Then
            jieguo = "中"
        ElseIf jieguo = "M3" Then
            jieguo = "重"
        ElseIf jieguo = "NG" Then
            jieguo = "误"
        ElseIf jieguo = "JN" Then
            jieguo = "警"

            'ElseIf jieguo = "合" Then
            '    jieguo = "SD"
            'ElseIf jieguo = "合" Then
            '    jieguo = "SD"
        Else
            jieguo = ""
        End If
        Return jieguo

    End Function


    Public Function GetTextBoxEnable(ByVal key As String, Optional ByVal ShiCeKbn As String = "1") As String


        Select Case key
            Case "00" '目测
                Return "none"
            Case "01", "02", "03", "04", "05", "06", "10", "12", "14"
                If ShiCeKbn = "1" Then
                    Return "true"
                Else
                    Return "none"
                End If
            Case Else
                Return "true"
        End Select

    End Function



    Public Function GetSameMakeNoFontColor(ByVal value As String) As String
        If value = Me.tbxMakeNumber.Text Then
            Return "blue"
        Else
            Return "#000"
        End If

    End Function


    Public strMakeNo As String

    Public Sub LblMsg(ByVal msg As String)
        Me.lblMessage.Text = msg
    End Sub


    ''' <summary>
    ''' 根据图片ID取得图片二进制
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPicInfo(ByVal pictureId As String) As Byte()
        Dim bt As Byte()
        Dim dtPicInfo As DataTable = checkDA.GetPicInfoById(pictureId).Tables("PicInfo")
        If dtPicInfo.Rows.Count > 0 Then
            bt = DirectCast(dtPicInfo.Rows(0).Item("picture_content"), Byte())
        Else
            bt = Nothing
        End If
        Return bt
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
        Dim UserDA As New UserDA

        Dim userName As String = UserDA.GetUserName(tbxCheckUserCd.Text.Trim)
        If ComConst.IsErr(userName) Then
            Me.lblMessage.Text = "检查员不存在"
            tbxCheckUserCd.Text = ""
            tbxCheckUserCd.Focus()
            Return False
        End If

        If Me.tbxMakeNumber.Text.Trim = "" Then

            Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
            Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
            Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
            Server.Transfer("Default.aspx")
            Return False
        End If


        Return True

    End Function

    Protected Sub btnSaiKensaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaiKensaku.Click

        Rireki.InsRireki("跳转", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)

        If Not CheckInput() Then
            Exit Sub
        End If

        Dim lastCheckResultMS As Data.DataTable = _
        checkDA.GetLastReultInfoFrom_t_check_result(Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "no")

        If lastCheckResultMS.Rows.Count > 0 Then
            Me.hidResult_id.Value = lastCheckResultMS.Rows(0).Item("ID").ToString
        Else
            Me.lblMessage.Text = "检查数据不存在"
            Exit Sub
        End If



        Me.hidGoods_cd.Value = Me.tbxGoodsCd.Text

        Dim result_id As String = Me.hidResult_id.Value
        Dim goods_cd As String = Me.hidGoods_cd.Value
        Dim kind_cd As String = Me.hidKind_cd.Value
        Dim classify_id As String = Me.hidClassify_id.Value
        Dim tools_id As String = Me.hidTools_id.Value
        Dim picture_id As String = Me.hidPicture_id.Value
        GridViewBind(result_id, goods_cd, kind_cd, classify_id, tools_id)
        lbl_RESULT_MSG.Text = Com.GetResultMsg(result_id)
        'hidKind_Name.Value = ""

    End Sub



    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        System.Threading.Thread.Sleep(1000)
        Rireki.InsRireki("完了", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim ResultDA As New ResultDA
        ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "0", Com.GetResult(Me.hidResult_id.Value))
        Server.Transfer("Default.aspx")
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        Rireki.InsRireki("假保存", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim ResultDA As New ResultDA
        ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "3")
    End Sub

    'Protected Sub btnJiaSame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJiaSame.Click
    '    Dim ResultDA As New ResultDA
    '    ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "1")
    '    Server.Transfer("Default.aspx")
    'End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
    '    Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
    '    Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
    '    Context.Items("Result_id") = Me.hidResult_id.Value
    '    Server.Transfer("CheckToolsList.aspx")
    'End Sub
End Class
