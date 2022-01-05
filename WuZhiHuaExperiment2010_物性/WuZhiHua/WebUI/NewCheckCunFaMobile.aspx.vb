Imports System.Data

Imports System.IO
Imports System.Drawing
Partial Class NewCheckCunFaMobile
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
            Me.hidGoods_cd.Value = Context.Items("Goods_cd")
            Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
            Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
            Me.hidResult_id.Value = Context.Items("Result_id")


            'Me.tbxGoodsCd.Text = "W0620MJJA"
            'Me.hidGoods_cd.Value = "W0620MJJA"
            'Me.tbxMakeNumber.Text = "074090017"
            'Me.tbxCheckUserCd.Text = "300368"
            'Me.hidResult_id.Value = "2015110100008"
            If Context.Items("classify_id") IsNot Nothing Then
                hidClassify_id.Value = Context.Items("classify_id")
            End If


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

        End If

    End Sub

    '头部标签
    Public Function GetKindLinks() As String

        '寸法取得 种类列表
        Dim cunFaKindsList As Data.DataTable = _
        checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "01", "", "")

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



    '输入值Textbox是否表示
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
            Case "50", "52", "56", "57", "60", "62", "64" '六个数值
                Return "true"
            Case "51", "53", "54", "55", "61", "63", "65" '六个数值
                If ShiCeKbn = "1" Or ShiCeKbn = "2" Or ShiCeKbn = "3" Then
                    Return "true"
                Else
                    Return "none"
                End If

            Case Else
                Return "true"
        End Select

    End Function


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



        'Title设置
        If checkMs.Rows.Count > 0 Then
            If checkMs.Rows(0).Item("kind") = "ピーリング" Then
                Me.Label7.Text = "平均值"
                Me.Label8.Text = "最小值"
            End If
            If checkMs.Rows(0).Item("kind") = "クリープ" Then
                Me.Label7.Text = "最大值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "平面引张" Then
                Me.Label7.Text = "最小值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "表面胶合强度" Then
                Me.Label7.Text = "平均值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "浸渍剥离" Then
                Me.Label7.Text = ""
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "浸渍剥离" Or checkMs.Rows(0).Item("kind") = "表面胶合强度" Then
                Me.Label1.Text = "1"
                Me.Label2.Text = "2"
                Me.Label3.Text = "3"
                Me.Label4.Text = "4"
                Me.Label5.Text = "5"
                Me.Label6.Text = "6"
            Else


                Me.Label1.Text = "上"
                Me.Label2.Text = "上"
                Me.Label3.Text = "中"
                Me.Label4.Text = "中"
                Me.Label5.Text = "下"
                Me.Label6.Text = "下"


            End If

            If checkMs.Rows(0).Item("benchmark_type") = "51" Or checkMs.Rows(0).Item("benchmark_type") = "53" Or checkMs.Rows(0).Item("benchmark_type") = "54" Or checkMs.Rows(0).Item("benchmark_type") = "61" Or checkMs.Rows(0).Item("benchmark_type") = "63" Or checkMs.Rows(0).Item("benchmark_type") = "65" Then
                Me.Label1.Text = "上"
                Me.Label2.Text = "中"
                Me.Label3.Text = "下"
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
            End If

            If checkMs.Rows(0).Item("kind") = "ピーリング" _
            OrElse checkMs.Rows(0).Item("kind") = "クリープ" _
            OrElse checkMs.Rows(0).Item("kind") = "平面引张" _
            OrElse checkMs.Rows(0).Item("kind") = "表面胶合强度" _
            OrElse checkMs.Rows(0).Item("kind") = "浸渍剥离" _
            Then


            Else
                Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
                Context.Items("Goods_cd") = Me.hidGoods_cd.Value
                Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
                Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
                Context.Items("Result_id") = Me.hidResult_id.Value
                Context.Items("classify_id") = classify_id

                Server.Transfer("CheckCunFaMobile.aspx")

                Exit Function
            End If

        checkMs.Columns.Add("JQ_atai1")
        checkMs.Columns.Add("JQ_atai2")

        For i As Integer = 0 To checkMs.Rows.Count - 1
            Dim v1, v2, v3, v4, v5, v6 As String
            v1 = checkMs.Rows(i).Item("measure_value1")
            v2 = checkMs.Rows(i).Item("measure_value2")
            v3 = checkMs.Rows(i).Item("measure_value3")
            v4 = checkMs.Rows(i).Item("measure_value4")
            v5 = checkMs.Rows(i).Item("measure_value5")
            v6 = checkMs.Rows(i).Item("measure_value6")

            Dim maxValue, minValue, avgValue, sumValue, inputSuu As Decimal
            maxValue = 0
            minValue = 0
            avgValue = 0
            sumValue = 0
            inputSuu = 0

            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value1"))
            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value2"))
            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value3"))
            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value4"))
            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value5"))
            minValue = GetMinValue(minValue, checkMs.Rows(i).Item("measure_value6"))

            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value1"))
            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value2"))
            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value3"))
            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value4"))
            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value5"))
            maxValue = GetMaxValue(maxValue, checkMs.Rows(i).Item("measure_value6"))

            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value1"))
            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value2"))
            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value3"))
            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value4"))
            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value5"))
            sumValue = sumValue + GetNumValue(checkMs.Rows(i).Item("measure_value6"))

            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value1"))
            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value2"))
            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value3"))
            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value4"))
            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value5"))
            inputSuu = inputSuu + HaveValue(checkMs.Rows(i).Item("measure_value6"))

                If checkMs.Rows(0).Item("kind") = "ピーリング" Then

                    If (checkMs.Rows(i).Item("benchmark_type") = "50" Or checkMs.Rows(i).Item("benchmark_type") = "60" Or checkMs.Rows(i).Item("benchmark_type") = "62" Or checkMs.Rows(i).Item("benchmark_type") = "64") And inputSuu = 6 Then
                        checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(sumValue / 6)
                        checkMs.Rows(i).Item("JQ_atai2") = ZeroToEmpty(minValue)
                    ElseIf (checkMs.Rows(i).Item("benchmark_type") = "51" Or checkMs.Rows(i).Item("benchmark_type") = "61" Or checkMs.Rows(i).Item("benchmark_type") = "63" Or checkMs.Rows(i).Item("benchmark_type") = "65") And inputSuu = 3 Then
                        checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(sumValue / 3)
                        checkMs.Rows(i).Item("JQ_atai2") = ZeroToEmpty(minValue)
                    ElseIf (checkMs.Rows(i).Item("benchmark_type") >= "66" AndAlso checkMs.Rows(i).Item("benchmark_type") <= "71") Then
                        If inputSuu <> 0 Then
                            checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(sumValue / inputSuu)
                        End If

                        checkMs.Rows(i).Item("JQ_atai2") = ZeroToEmpty(minValue)
                    End If
                    Me.Label7.Text = "平均值"
                    Me.Label8.Text = "最小值"
                End If
            If checkMs.Rows(0).Item("kind") = "クリープ" Then

                If checkMs.Rows(i).Item("benchmark_type") = "52" And inputSuu = 6 Then
                    checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(maxValue)
                End If
                If checkMs.Rows(i).Item("benchmark_type") = "53" And inputSuu = 3 Then
                    checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(maxValue)
                End If

                Me.Label7.Text = "最大值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "平面引张" Then

                If inputSuu = 3 Then
                    checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(minValue)
                    End If
                    checkMs.Rows(i).Item("JQ_atai2") = checkMs.Rows(i).Item("check_item")

                Me.Label7.Text = "最小值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "表面胶合强度" Then

                If inputSuu = 6 Then
                    checkMs.Rows(i).Item("JQ_atai1") = ZeroToEmpty(minValue)
                End If

                Me.Label7.Text = "平均值"
                Me.Label8.Text = ""
            End If
            If checkMs.Rows(0).Item("kind") = "浸渍剥离" Then
                Me.Label7.Text = ""
                Me.Label8.Text = ""
            End If
            'If checkMs.Rows(0).Item("kind") = "膨胀率" Then
            '    Me.Label7.Text = "差"
            '    Me.Label8.Text = "膨胀率"
            'End If


        Next




        End If

        Me.gvLastCheckResultMS.DataSource = checkMs
        Me.gvLastCheckResultMS.DataBind()



        '明细设置


        For i As Integer = 0 To checkMs.Rows.Count - 1

            Me.lblKind.Text = checkMs.Rows(0).Item("kind")

            '小口标签时  警告按钮不可用
            'If Me.lblKind.Text = "小口标签" Then
            '    tdJinggao.Attributes.Item("onclick") = ""
            '    tdJinggao.InnerText = ""
            'Else
            '    tdJinggao.Attributes.Item("onclick") = "KeyBoard(this);"
            '    tdJinggao.InnerText = "警"


            'End If

            Dim conCell结果 As Integer = 8

            gvLastCheckResultMS.Rows(i).Attributes.Add("onfocus", "RowSelect(this)")
            gvLastCheckResultMS.Rows(i).Attributes.Add("tabindex", "-1")
            gvLastCheckResultMS.Rows(i).Attributes.Add("zID", checkMs.Rows(i).Item("id"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_type", checkMs.Rows(i).Item("benchmark_type"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value1", checkMs.Rows(i).Item("benchmark_value1"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value2", checkMs.Rows(i).Item("benchmark_value2"))
            gvLastCheckResultMS.Rows(i).Attributes.Add("zbenchmark_value3", checkMs.Rows(i).Item("benchmark_value3"))


            gvLastCheckResultMS.Rows(i).Attributes.Add("check_times", isnullone(checkMs.Rows(i).Item("check_times")))

            gvLastCheckResultMS.Rows(i).Attributes.Add("dis_no", checkMs.Rows(i).Item("dis_no"))

            gvLastCheckResultMS.Rows(i).Attributes.Add("check_item", checkMs.Rows(i).Item("check_item"))

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

        PicMSInit()

        Return True

    End Function

    Public Function isnullone(ByVal v As Object) As String
        If v Is DBNull.Value Then
            Return "1"
        Else
            Return v.ToString
        End If

    End Function

    Function GetMinValue(ByVal value As Decimal, ByRef newValue As Object) As Decimal
        Try
            If newValue IsNot DBNull.Value AndAlso newValue.ToString <> "" Then


                If Convert.ToDecimal(newValue) <= value Or value = 0 Then
                    value = Convert.ToDecimal(newValue)
                End If
                newValue = Convert.ToDecimal(newValue).ToString("########0.0")
            End If
        Catch ex As Exception

        End Try


        Return value

    End Function

    Function GetMaxValue(ByVal value As Decimal, ByRef newValue As Object) As Decimal
        Try
            If newValue IsNot DBNull.Value AndAlso newValue.ToString <> "" Then
                If Convert.ToDecimal(newValue) >= value Then
                    value = Convert.ToDecimal(newValue)
                End If
            End If
        Catch ex As Exception

        End Try


        Return value

    End Function

    Function GetNumValue(ByRef newValue As Object) As Decimal
        Try
            If newValue IsNot DBNull.Value AndAlso newValue.ToString <> "" Then
                Return Convert.ToDecimal(newValue)
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try


    End Function

    Function ZeroToEmpty(ByVal value As Decimal) As String

        If value = 0 Then
            Return ""
        End If

        Return Math.Round(value, 1).ToString("########0.0")
    End Function

    Function HaveValue(ByRef newValue As Object) As Decimal

        If newValue IsNot DBNull.Value AndAlso newValue.ToString <> "" Then
            Return 1
        Else
            Return 0
        End If

    End Function



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
            Me.lblMessage.Text = ""

        Else
            Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
            Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
            Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
            Server.Transfer("Default.aspx")
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
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim FilePath As String = Server.MapPath(".") & ("/IMG/")
        Dim Extension As String = System.IO.Path.GetExtension(PicUpload.PostedFile.FileName)
        Dim NewFilePath As String = DateTime.Now.ToString("yyyyMMddHHmmss") & Extension
        Dim cm As New ComDDL
        Dim result_id As String = Me.hidResult_id.Value
        Dim user_cd As String = Me.tbxCheckUserCd.Text
        PicUpload.SaveAs(FilePath & NewFilePath)
        cm.InsMPictureChk(result_id, (FilePath & NewFilePath), user_cd)
        'File.Delete(FilePath & NewFilePath)
        PicMSInit()

    End Sub

    Sub PicMSInit()
        Dim result_id As String = Me.hidResult_id.Value
        Dim cm As New ComDDL
        Dim dtImg As Data.DataTable = cm.SelChkPicture(result_id)
        GvPic.DataSource = dtImg
        GvPic.DataBind()

        For i As Integer = 0 To dtImg.Rows.Count - 1
            Dim img As System.Web.UI.WebControls.Image = CType(GvPic.Rows(i).FindControl("Image1"), System.Web.UI.WebControls.Image)
            Dim btn As Button = GvPic.Rows(i).FindControl("btnDel")

            Dim MStream As New MemoryStream(CType(dtImg.Rows(i).Item("pic_conn"), Byte()))
            Dim base64 As String = Convert.ToBase64String(MStream.ToArray())
            img.ImageUrl = "data:image/jpg;base64," + base64
            btn.Attributes.Item("idx") = dtImg.Rows(i).Item("idx")

            ' AddHandler btn.Click, AddressOf Me.btClick
        Next


    End Sub

    Public Sub btClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button
        btn = CType(sender, Button)
        Dim cm As New ComDDL
        Dim result_id As String = Me.hidResult_id.Value
        cm.DelMPictureChk(result_id, btn.Attributes.Item("idx"))
        PicMSInit()
    End Sub
End Class
