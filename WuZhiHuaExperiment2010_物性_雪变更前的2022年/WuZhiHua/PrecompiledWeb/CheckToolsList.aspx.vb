Imports System.Data

Partial Class CheckCunFaMobile
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        If Not IsPostBack Then

            Me.tbxGoodsCd.Text = Context.Items("Goods_cd")
            Me.tbxMakeNumber.Text = Context.Items("MakeNumber")
            Me.tbxCheckUserCd.Text = Context.Items("CheckUserCd")
            Me.hidResult_id.Value = Context.Items("Result_id")
            Me.hidGoods_cd.Value = Context.Items("Goods_cd")
            Me.hidKind_cd.Value = "02" '外观01 治具 02 


            Dim result_id As String = Me.hidResult_id.Value
            Dim goods_cd As String = Me.hidGoods_cd.Value
            Dim kind_cd As String = Me.hidKind_cd.Value
            Dim classify_id As String = Me.hidClassify_id.Value
            Dim tools_id As String = Me.hidTools_id.Value
            Dim picture_id As String = Me.hidPicture_id.Value

            ShowToolsList("")


        End If

    End Sub

    Public Function ShowToolsList(ByVal classify_id As String) As String

        '治具列表取得
        Dim cunFaKindsList As Data.DataTable = checkDA.GetGoodKind(Me.tbxGoodsCd.Text, "02", "", "")

        scanMsFlgDt = checkDA.GetChkDetailResultScanFlg(Me.hidResult_id.Value)

        gvZhiju.DataSource = cunFaKindsList
        gvZhiju.DataBind()

        For i As Integer = 0 To cunFaKindsList.Rows.Count - 1

            Dim result_id As String = Me.hidResult_id.Value
            Dim goods_cd As String = Me.hidGoods_cd.Value
            Dim kind_cd As String = Me.hidKind_cd.Value
            Dim classifyid As String = cunFaKindsList.Rows(i).Item("classify_id")

            Dim tools_id As String = cunFaKindsList.Rows(i).Item("tools_id")
            Dim picture_id As String = Me.hidPicture_id.Value


            Dim checkMs As Data.DataTable = _
            checkDA.GetChkDetailInfo(result_id, goods_cd, "02", cunFaKindsList.Rows(i).Item("classify_id").ToString, "")

            If checkMs.Select("tools_scan_flg='1'").Length > 0 Then
                Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
                Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
                Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
                Context.Items("Result_id") = Me.hidResult_id.Value
                Server.Transfer("CheckToolsMobile.aspx")
                Return ""
            End If


            If checkMs.Select("result='M1' OR result='M2' OR result='M3' OR result='NG'").Length > 0 Then

                gvZhiju.Rows(i).Cells(0).Attributes.CssStyle.Item("color") = "red"
            ElseIf checkMs.Select("result='OK' OR result='SD' OR result='JN'").Length = checkMs.Rows.Count Then

                gvZhiju.Rows(i).Cells(0).Attributes.CssStyle.Item("color") = "#00A600"
            ElseIf checkMs.Select("result='OK' OR result='SD' OR result='JN'").Length > 0 Then

                gvZhiju.Rows(i).Cells(0).Attributes.CssStyle.Item("color") = "#0000E3"

            Else

            End If

            gvZhiju.Rows(i).Attributes.Add("onfocus", "RowSelectTools(this,'" & cunFaKindsList.Rows(i).Item("classify_id") & "')")
            gvZhiju.Rows(i).Attributes.Add("tabindex", "-1")

            If cunFaKindsList.Rows(i).Item("classify_id") = classify_id Then
                gvZhiju.Rows(i).Cells(3).Attributes.CssStyle.Item("background-color") = "#ADD8E6"
                gvZhiju.Rows(i).Cells(2).Attributes.CssStyle.Item("background-color") = "#ADD8E6"
                gvZhiju.Rows(i).Cells(1).Attributes.CssStyle.Item("background-color") = "#ADD8E6"
                gvZhiju.Rows(i).Cells(0).CssClass = "JQ_SELECT_CELL"
            End If


        Next
        Return ""
    End Function


    Public scanMsFlgDt As Data.DataTable
    Public Function GetDisplay(ByVal classify_id As String, ByVal flg As Boolean) As String
        If flg Then
            If scanMsFlgDt.Select("classify_id='" & classify_id & "' and tools_scan_flg='1'").Length > 0 Then
                Return ""
            Else
                Return ("display:none;")
            End If
        Else
            If scanMsFlgDt.Select("classify_id='" & classify_id & "' and tools_scan_flg='1'").Length > 0 Then
                Return ("display:none;")
            Else
                Return ""
            End If
        End If


    End Function



    'Protected Sub btnKensaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKensaku.Click


    '    Dim result_id As String = Me.hidResult_id.Value
    '    Dim goods_cd As String = Me.hidGoods_cd.Value
    '    Dim kind_cd As String = Me.hidKind_cd.Value
    '    Dim classify_id As String = Me.hidClassify_id.Value
    '    Dim tools_id As String = Me.hidTools_id.Value
    '    Dim picture_id As String = Me.hidPicture_id.Value

    '    ShowToolsList(Me.hidClassify_id.Value)

    'End Sub


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

    '类型Scan Or Input
    Public Function GetRemark(ByVal remark As String, ByVal result As String _
                            , ByVal ktype As String _
                            , ByVal oldktype As String _
                            , ByVal k1 As String _
                            , ByVal k2 As String _
                            , ByVal k3 As String _
                            , ByVal oldk1 As String _
                            , ByVal oldk2 As String _
                            , ByVal oldk3 As String) As String
        If result = "NG" Then
            Return "(" & k1 & "," & k2 & "," & k3 & ")"

        ElseIf oldktype <> "" AndAlso ( _
                k1 <> oldk1 _
                OrElse k2 <> oldk2 _
                OrElse k3 <> oldk3 _
                OrElse ktype <> oldktype) Then
            Return "基准值变化 请重新检查"
        Else
            Return remark
        End If
    End Function

    Public Function GetSameMakeNoFontColor(ByVal value As String) As String
        If value = Me.tbxMakeNumber.Text Then
            Return "blue"
        Else
            Return "#000"
        End If

    End Function


    Public strMakeNo As String
    '检索

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



    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Server.Transfer("Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim resultDA As New ResultDA

        resultDA.UpdateResultDetailAllToolsFlg(Me.hidResult_id.Value)
        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = Me.hidResult_id.Value
        Server.Transfer("CheckToolsMobile.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Context.Items("Goods_cd") = Me.tbxGoodsCd.Text
        Context.Items("MakeNumber") = Me.tbxMakeNumber.Text
        Context.Items("CheckUserCd") = Me.tbxCheckUserCd.Text
        Context.Items("Result_id") = Me.hidResult_id.Value
        Server.Transfer("CheckCunFaMobile.aspx")
    End Sub
End Class
