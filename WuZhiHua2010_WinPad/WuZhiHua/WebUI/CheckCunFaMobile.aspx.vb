Imports System.Data

Partial Class CheckCunFaMobile
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA

    ''' <summary>
    ''' Page_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
            Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
            Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
            Me.hidResult_id.Value = Context.Items("Result_id")
            Me.hidGoods_cd.Value = Context.Items("Goods_cd")

            Me.hidKind_cd.Value = "01" '外观01 治具 02 

            Dim result_id As String = Me.hidResult_id.Value
            Dim goods_cd As String = Me.hidGoods_cd.Value
            Dim kind_cd As String = Me.hidKind_cd.Value
            Dim classify_id As String = Me.hidClassify_id.Value
            Dim tools_id As String = Me.hidTools_id.Value
            Dim picture_id As String = Me.hidPicture_id.Value

            imgLook.ImageUrl = "Img.aspx?id=" & picture_id

            GridViewBind(result_id, goods_cd, kind_cd, classify_id, tools_id)

            lbl_RESULT_MSG.Text = Com.GetResultMsg(result_id)

            If Page.PreviousPage.ToString.Contains("default_aspx") AndAlso checkDA.Gettongyong_cd(goods_cd) <> "" Then
                Dim tongyong_cd As String = _
                      checkDA.GetFirstCheck(goods_cd)
                If tongyong_cd = "" Then
                    Me.tbxGoodsCd.ForeColor = Drawing.Color.Yellow
                    Dim csScript As New StringBuilder
                    With csScript
                        .AppendLine("alert('初回检查');")
                    End With
                    'ページ応答で、クライアント側のスクリプト ブロックを出力します
                    ClientScript.RegisterStartupScript(Me.GetType(), "ShowMessage", csScript.ToString, True)
                End If
            End If





        End If

    End Sub

    ''' <summary>
    ''' 画面明細設定
    ''' </summary>
    ''' <param name="result_id"></param>
    ''' <param name="goods_cd"></param>
    ''' <param name="kind_cd"></param>
    ''' <param name="classify_id"></param>
    ''' <param name="tools_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridViewBind(ByVal result_id As String, ByVal goods_cd As String, ByVal kind_cd As String, ByVal classify_id As String, ByVal tools_id As String) As Boolean

        Dim checkMs As Data.DataTable = _
        checkDA.GetChkDetailInfo(result_id, goods_cd, kind_cd, classify_id, tools_id)

        Me.gvLastCheckResultMS.DataSource = checkMs
        Me.gvLastCheckResultMS.DataBind()

        Dim conCell结果 As Integer = 5

        For i As Integer = 0 To checkMs.Rows.Count - 1

            Me.lblKind.Text = checkMs.Rows(0).Item("kind")

            '小口标签时  警告按钮不可用
            If Me.lblKind.Text = "小口标签" Then
                tdJinggao.Attributes.Item("onclick") = ""
                tdJinggao.InnerText = ""
            Else
                tdJinggao.Attributes.Item("onclick") = "KeyBoard(this);"
                tdJinggao.InnerText = "警"
            End If

            gvLastCheckResultMS.Rows(i).Attributes.Add("onfocus", "RowSelect(this)")
            gvLastCheckResultMS.Rows(i).Attributes.Add("tabindex", "-1")
            gvLastCheckResultMS.Rows(i).Attributes.Add("zID", checkMs.Rows(i).Item("id"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_type", checkMs.Rows(i).Item("benchmark_type"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value1", checkMs.Rows(i).Item("benchmark_value1"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value2", checkMs.Rows(i).Item("benchmark_value2"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value3", checkMs.Rows(i).Item("benchmark_value3"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("check_times", Com.IsNullOne(checkMs.Rows(i).Item("check_times")))
            gvLastCheckResultMS.Rows(i).Attributes.Add("dis_no", checkMs.Rows(i).Item("dis_no"))


            Select Case checkMs.Rows(i).Item("result").ToString.Trim
                Case "OK", "SD", "JN"
                    gvLastCheckResultMS.Rows(i).Cells(conCell结果).Attributes.CssStyle.Item("background-color") = "#93FF93" '绿
                Case ""

                Case Else
                    gvLastCheckResultMS.Rows(i).Cells(conCell结果).Attributes.CssStyle.Item("background-color") = "#FF2D2D" '红
            End Select


        Next
        Return True

    End Function

    ''' <summary>
    ''' 重別のＬｉｎｋ設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKindLinks() As String

        '寸法取得 种类列表
        Dim cunFaKindsList As Data.DataTable = _
        checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "01", "", "")

        Dim idx As Integer = 1

        Dim sb As New StringBuilder

        sb.Append("<table>")

        For i As Integer = 0 To cunFaKindsList.Rows.Count - 1

            If idx Mod 5 = 1 Then sb.Append("<tr>")

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

            '選択のＬｉｎｋ
            If Me.hidClassify_id.Value = cunFaKindsList.Rows(i).Item("classify_id").ToString Then
                sb.Append("font-size:30px;")
                sb.Append("background-color:#C4CFE9;")
                sb.Append("""")
                sb.Append(" class='JQ_SELECT_CELL'")

                If checkMs.Select("result='M1' OR result='M2' OR result='M3' OR result='NG'").Length > 0 Then
                    lblKind.ForeColor = Drawing.Color.Red
                    lblKind.Attributes.CssStyle.Add("color", "red")
                ElseIf checkMs.Select("result='OK' OR result='SD'").Length = checkMs.Rows.Count Then
                    lblKind.Attributes.CssStyle.Add("color", "#00A600")
                    lblKind.ForeColor = Drawing.Color.Red
                ElseIf checkMs.Select("result='OK' OR result='SD'").Length > 0 Then
                    lblKind.Attributes.CssStyle.Add("color", "#0000E3")
                Else

                End If

                imgLook.ImageUrl = "Img.aspx?id=" & cunFaKindsList.Rows(i).Item("picture_id").ToString

            Else
                sb.Append("font-size:30px;")
                sb.Append("""")

            End If


            sb.Append(" onclick = ""SelectKind('" & cunFaKindsList.Rows(i).Item("classify_id").ToString & "')"">")
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




    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        System.Threading.Thread.Sleep(1000)
        Rireki.InsRireki("外观-完了", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim ResultDA As New ResultDA
        ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "0", Me.tbxCheckUserCd.Text.Trim, Com.GetResult(Me.hidResult_id.Value))


        If Not Com.GetResultLoujian(Me.hidResult_id.Value) Then
            Dim tongyong_cd As String = _
            checkDA.Gettongyong_cd(Me.tbxGoodsCd.Text.Trim)

            If tongyong_cd <> "" Then
                ResultDA.UpdFirstCheck(tongyong_cd)
                'Else
                '    ResultDA.InsFirstCheck(Me.tbxGoodsCd.Text.Trim, Me.tbxGoodsCd.Text.Trim)
            End If
        End If


        Server.Transfer("Default.aspx")
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        Rireki.InsRireki("外观-假保存", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim ResultDA As New ResultDA
        ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "3", Me.tbxCheckUserCd.Text, "")
    End Sub
    Protected Sub btnJiaSame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJiaSame.Click
        Rireki.InsRireki("外观-待判", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Dim ResultDA As New ResultDA
        ResultDA.Updatet_check_result_continue_chk_flg(Me.hidResult_id.Value, "1", Me.tbxCheckUserCd.Text, "")
        Server.Transfer("Default.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Rireki.InsRireki("外观-退出", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Server.Transfer("Default.aspx")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Rireki.InsRireki("外观-治具", "", "", Me.tbxGoodsCd.Text, Me.tbxMakeNumber.Text, "", Me.tbxCheckUserCd.Text.Trim)
        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = Me.hidResult_id.Value
        Server.Transfer("CheckToolsList.aspx")
    End Sub
End Class
