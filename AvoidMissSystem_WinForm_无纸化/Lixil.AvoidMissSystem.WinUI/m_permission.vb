Public Class m_permission

    Private Sub User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: このコード行はデータを 'AvoidMiss_NewDataSet.m_permission' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.M_permissionTableAdapter.Fill(Me.AvoidMiss_NewDataSet.m_permission)
        'TODO: このコード行はデータを 'AvoidMiss_NewDataSet.TB_User' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        ' Me.M_permissionTableAdapter.Fill(Me.AvoidMiss_NewDataSet.m_permission)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.M_permissionTableAdapter.Update(Me.AvoidMiss_NewDataSet.m_permission)
            MsgBox("保存成功")
        Catch ex As Exception
            MsgBox("保存失败")
        End Try


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TODO: このコード行はデータを 'AvoidMiss_NewDataSet.TB_User' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        Me.M_permissionTableAdapter.Fill(Me.AvoidMiss_NewDataSet.m_permission)
    End Sub
End Class