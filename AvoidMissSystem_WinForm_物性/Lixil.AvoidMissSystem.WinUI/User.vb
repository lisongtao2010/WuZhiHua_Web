Public Class User

    Private Sub User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'AvoidMiss_NewDataSet.TB_User' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TB_UserTableAdapter.Fill(Me.AvoidMiss_NewDataSet.TB_User)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.TB_UserTableAdapter.Update(Me.AvoidMiss_NewDataSet.TB_User)
            MsgBox("保存成功")
        Catch ex As Exception
            MsgBox("保存失败")
        End Try


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TODO: このコード行はデータを 'AvoidMiss_NewDataSet.TB_User' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.TB_UserTableAdapter.Fill(Me.AvoidMiss_NewDataSet.TB_User)
    End Sub
End Class