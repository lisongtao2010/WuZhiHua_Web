Imports System.Data
Imports System.IO

Partial Class NotCheckList
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbxDate_key.Text = System.DateTime.Now.ToString("yyyy/MM/dd")
            ViewState("hebing") = "0"
            kensaku(ViewState("hebing"))
        End If
    End Sub

    Sub kensaku(ByVal sumFlg As String)
        '未检查数据取得
        NotCheckDataBind(sumFlg)
    End Sub

    Public Function NotCheckDataBind(ByVal sumFlg As String) As Boolean

        Dim notCheckMS As Data.DataTable
        If sumFlg = "0" Then
            notCheckMS = checkDA.GetNotCheckInfo(Me.tbxDate_key.Text)
        Else
            notCheckMS = checkDA.GetNotCheckInfoSum(Me.tbxDate_key.Text)
        End If

        gvNotCheckMS.DataSource = notCheckMS
        gvNotCheckMS.DataBind()

        If notCheckMS.Rows.Count = 0 Then
            lblMessage.Text = "没有未检查数据"
        Else

        End If

    End Function


    Public Function SetDateYMD(ByVal v As String) As String

        If v.Trim = "" Then
            Return ""
        Else
            Return CDate(v).ToString("yyyy-MM-dd")
        End If
    End Function

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

        kensaku(ViewState("hebing"))

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

        kensaku(ViewState("hebing"))

    End Sub

    ''' <summary>
    ''' 检索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnReSearch_Click(sender As Object, e As EventArgs) Handles btnReSearch.Click
        ViewState("hebing") = "0"
        kensaku(ViewState("hebing"))
    End Sub

    ''' <summary>
    ''' 出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

        Response.AppendHeader("Content-Disposition", "attachment;filename=未检查一览" + Now.ToString("yyyyMMddHHmmss") & ".xls")        Response.Charset = "utf-8"        Response.ContentType = "application/vnd.ms-excel"        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>")

        Dim notCheckMS As Data.DataTable
        'checkDA.GetNotCheckInfo(Me.tbxDate_key.Text)


        If ViewState("hebing") = "0" Then
            notCheckMS = checkDA.GetNotCheckInfo(Me.tbxDate_key.Text)
        Else
            notCheckMS = checkDA.GetNotCheckInfoSum(Me.tbxDate_key.Text)
        End If

        If notCheckMS.Rows.Count = 0 Then
            lblMessage.Text = "没有未检查数据"
        Else

            Dim sb As New StringBuilder
            Dim i, j As Integer
            Dim str As String = ""

            sb.Append("<table>")

            sb.Append("<tr>")
            For i = 0 To notCheckMS.Columns.Count - 1
                sb.Append("<td>")
                str = notCheckMS.Columns(i).Caption
                sb.Append(str & vbTab)
                sb.Append("</td>")
            Next
            sb.Append("</tr>")

            For j = 0 To notCheckMS.Rows.Count - 1
                sb.Append("<tr>")
                For i = 0 To notCheckMS.Columns.Count - 1
                    sb.Append("<td>")
                    Dim strRow As String
                    strRow = IIf(notCheckMS.Rows(j).Item(i) Is DBNull.Value, "", notCheckMS.Rows(j).Item(i))
                    sb.Append(strRow & vbTab)
                    sb.Append("</td>")
                Next
                sb.Append("</tr>")
            Next

            sb.Append("</table>")

            Response.Write(sb)
            Response.End()

        End If

    End Sub


    Protected Sub btnReSearchSum_Click(sender As Object, e As EventArgs) Handles btnReSearchSum.Click
        ViewState("hebing") = "1"
        kensaku(ViewState("hebing"))
    End Sub
End Class
