Imports System.Web.Services

Partial Class AJAX
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("k") = "1" Then
            updatedetail()
        ElseIf Request.QueryString("k") = "11" Then
            updateToolsScanFlg()
        ElseIf Request.QueryString("k") = "31" Then
            UpdateQianpin()
        End If
    End Sub

    '欠品更新
    Sub UpdateQianpin()

        Try

            Dim param As String() = Request.QueryString("param").Split("|")
            Dim result_id As String = param(0)
            Dim qianpinFlg As String = param(1)
            Dim ResultDA As New ResultDA
            ResultDA.Updatet_check_resultQinapinFlg(result_id, qianpinFlg)
            Response.Write("OK")
        Catch ex As Exception
            Response.Write("NG")
        End Try
        Response.End()

    End Sub

    '治具扫描Flg更新
    Sub updateToolsScanFlg()
        Try
            Dim param As String() = Request.QueryString("param").Split("|")

            Dim result_id As String = param(0)
            Dim check_id As String = param(1)
            Dim ResultDA As New ResultDA
            ResultDA.UpdateResultDetailToolsFlg(result_id, check_id)
            Response.Write("OK")
        Catch ex As Exception
            Response.Write("NG")
        End Try
        Response.End()
    End Sub


    '检查结果明细更新
    Function updatedetail() As String

        Dim param As String() = Request.QueryString("param").Split("|")

        Dim result_id As String = param(0)
        Dim check_id As String = param(1)
        Dim value1 As String = param(2)
        Dim value2 As String = param(3)
        Dim value3 As String = param(4)
        Dim value4 As String = param(5)
        Dim value5 As String = param(6)
        Dim value6 As String = param(7)
        Dim jieguo As String = param(8).Trim

        If jieguo = "合" Then
            jieguo = "OK"
        ElseIf jieguo = "微" Then
            jieguo = "SD"
        ElseIf jieguo = "轻" Then
            jieguo = "M1"
        ElseIf jieguo = "中" Then
            jieguo = "M2"
        ElseIf jieguo = "重" Then
            jieguo = "M3"
        ElseIf jieguo = "误" Then
            jieguo = "NG"
        ElseIf jieguo = "警" Then
            jieguo = "JN"
        End If

        Dim zbenchmark_type As String = param(9)
        Dim zbenchmark_value1 As String = param(10)
        Dim zbenchmark_value2 As String = param(11)
        Dim zbenchmark_value3 As String = param(12)

        Dim dis_no As String = param(13)
        Dim beizhu As String = param(14)
        Dim checkTimes As String = param(15)
        Dim usercd As String = param(16)

        Try
            Dim ResultDA As New ResultDA
            ResultDA.UpdateResultDetail(result_id, check_id, dis_no, checkTimes, value1, value2, value3, value4, value5, value6, jieguo, beizhu, zbenchmark_type, zbenchmark_value1, zbenchmark_value2, zbenchmark_value3, usercd)
            Response.Write(Com.GetResultMsg(result_id))
        Catch ex As Exception
            Response.Write("NG")
        End Try

        Response.End()

        Return ""

    End Function

End Class
