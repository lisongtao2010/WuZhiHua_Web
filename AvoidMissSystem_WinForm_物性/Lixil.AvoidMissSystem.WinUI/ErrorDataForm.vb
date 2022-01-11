
''' <summary>
''' 出错数据一览
''' </summary>
''' <remarks></remarks>
Public Class ErrorDataForm

    Private dtErrorData As DataTable

    Public Property ErrorData() As DataTable
        Get
            Return dtErrorData
        End Get
        Set(ByVal value As DataTable)
            dtErrorData = value
        End Set
    End Property

    ''' <summary>
    ''' 窗体加载处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ErrorDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "出错数据一览"
            Me.dgvErrorData.DataSource = ErrorData
            Me.dgvErrorData.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 窗体卸载处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ErrorDataForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class