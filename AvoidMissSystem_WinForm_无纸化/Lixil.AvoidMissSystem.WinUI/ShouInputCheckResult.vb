Imports System.Threading
Imports System.Transactions
Imports Lixil.AvoidMissSystem.BizLogic
Imports Lixil.AvoidMissSystem.Utilities
Imports Lixil.AvoidMissSystem.Utilities.Consts
Imports Lixil.AvoidMissSystem.Utilities.MsgConst
Imports System.IO
Public Class ShouInputCheckResult

    Private Sub btnSel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSel.Click

        Me.btnIns.Enabled = False
        Me.btnTUika.Enabled = False


        Dim result As String
        If Me.rbOk.Checked Then
            result = "OK"
        Else
            result = "NG"
        End If

        Dim ShouInputCheckResultBizLogic As New ShouInputCheckResultBizLogic
        Dim dt As DataTable = ShouInputCheckResultBizLogic.GetSearchData("自动", Me.tbxJianchayuan.Text, result, Me.tbxZuofan.Text).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.tbxGoodcd.Text = dt.Rows(0).Item("商品CD").ToString
            gv1.DataSource = dt
        Else
            gv1.DataSource = Nothing
        End If


        Dim dt2 As DataTable = ShouInputCheckResultBizLogic.Gett_check_result(Me.tbxZuofan.Text)
        If dt2.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = dt2
        Else
            Me.DataGridView1.DataSource = Nothing
        End If



        If dt.Rows.Count = 0 Then
            MsgBox("数据不存在,座番，商品CD和检查员输入后，可以点击【直接追加】按钮追加数据")
            btnTUika.Enabled = True
            Exit Sub
        Else
            If dt.Rows(0).Item("检查员名") Is DBNull.Value Then
                MsgBox("检查员不存在")
                Exit Sub
            End If
        End If
        If dt.Rows.Count > 0 Then

            Me.tbxGoodcd.Text = dt.Rows(0).Item("商品CD").ToString
            Me.btnIns.Enabled = True
            'Me.btnTUika.Enabled = True
        Else
            Me.btnIns.Enabled = False
            Me.btnTUika.Enabled = False

        End If



    End Sub

    Private Sub ShouInputCheckResult_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.rbOk.Checked = True
        'Me.tbxZuofan.Text = "007060850"
        'Me.tbxJianchayuan.Text = "301105"
    End Sub

    Private Sub btnIns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIns.Click

        Dim result As String
        If Me.rbOk.Checked Then
            result = "OK"
        Else
            result = "NG"
        End If

        Dim ShouInputCheckResultBizLogic As New ShouInputCheckResultBizLogic
        ShouInputCheckResultBizLogic.InsData("", Me.tbxJianchayuan.Text, result, Me.tbxZuofan.Text)

        Me.DataGridView1.DataSource = ShouInputCheckResultBizLogic.Gett_check_result(Me.tbxZuofan.Text)

        Me.btnIns.Enabled = False
        Me.btnTUika.Enabled = False
    End Sub

    Private Sub btnTUika_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTUika.Click

        Dim result As String
        If Me.rbOk.Checked Then
            result = "OK"
        Else
            result = "NG"
        End If

        Try

            If Me.tbxGoodcd.Text = "" OrElse Me.tbxJianchayuan.Text = "" OrElse Me.tbxZuofan.Text = "" OrElse Me.tbxZuofan.Text = "" Then
                MsgBox("信息请输入完整")
                Exit Sub
            End If

            Dim ShouInputCheckResultBizLogic As New ShouInputCheckResultBizLogic

            Dim goodscd As String
            Try
                goodscd = ShouInputCheckResultBizLogic.GetGoodID(Me.tbxGoodcd.Text)
            Catch ex As Exception
                MsgBox("不能取得商品CD")
                Exit Sub
            End Try

            ShouInputCheckResultBizLogic.InsDataZhijie("", goodscd, Me.tbxJianchayuan.Text, result, Me.tbxZuofan.Text, "")

            Me.DataGridView1.DataSource = ShouInputCheckResultBizLogic.Gett_check_result(Me.tbxZuofan.Text)

            Me.btnIns.Enabled = False
            MsgBox("追加完了")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.btnIns.Enabled = False
        Me.btnTUika.Enabled = False

    End Sub

End Class