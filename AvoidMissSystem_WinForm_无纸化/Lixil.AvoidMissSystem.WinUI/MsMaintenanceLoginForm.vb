Imports Lixil.AvoidMissSystem.BizLogic
Imports Lixil.AvoidMissSystem.Utilities
Imports System.IO
Imports System.IO.Directory
Imports System.Configuration

''' <summary>
''' MS维护登录页面用Form
''' </summary>
''' <remarks></remarks>
Public Class MsMaintenanceLoginForm

    '权限区分code
    Public Const ACCESS_CD As String = "AccessCd"
    '用户id
    Public Const USER_ID As String = "UserId"

#Region "事件"

    ''' <summary>
    ''' 窗体加载处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MsMaintenanceLoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm() '窗体初期化处理
        Me.Text = "MS维护登录页面"
        Me.Width = 473
        Me.Height = 383

        If Me.WindowState <> FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.WindowState = FormWindowState.Normal
        End If

        Try
            If Not My.Computer.FileSystem.DirectoryExists(GetConfig.GetConfigVal("ExcelFilePatch")) Then
                My.Computer.FileSystem.CreateDirectory(GetConfig.GetConfigVal("ExcelFilePatch"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'Dim parentPath As String = System.IO.Path.GetFullPath(".")


        'For Each foundFile As String In My.Computer.FileSystem.GetFiles(ConfigurationManager.AppSettings("ApplicationUpdatePath").ToString())
        '    Dim serverFileInfo As New FileInfo(foundFile)
        '    Dim clientFileName As String = serverFileInfo.Name
        '    Dim clientFilePath As String = parentPath & "\" & clientFileName
        '    Dim clientFileInfo As New FileInfo(clientFilePath)
        '    '如果最终更新时间不相同 复制文件
        '    If clientFileInfo.LastWriteTime <> serverFileInfo.LastWriteTime Then
        '        'AndAlso serverFileInfo.Name <> "Maintenance_Config.xml" _
        '        'AndAlso serverFileInfo.Name <> "Maintenance_Config.xml" Then
        '        If MsgBox("程序有更新，是否更新到最新版", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        '            Me.Close()
        '            Shell(parentPath & "\ApplicationUpdata\ApplicationUpdata.exe")

        '        Else
        '            Exit Sub
        '        End If
        '    End If

        'Next


    End Sub

    ''' <summary>
    ''' 确定按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEnsure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnsure.Click

        Dim loginBizLogic As New MsMaintenanceLoginBizLogic
        Dim dsLoginInfo As New DataSet
        Dim strId As String = String.Empty
        Dim strUserId As String = String.Empty
        Dim strUserName As String = String.Empty
        Dim strPassword As String = String.Empty
        Dim intCnt As Integer '用户权限信息结果件数
        Dim strAccessCd As String '权限区分code
        Dim lstCode As New ArrayList '权限区分信息list

        strUserId = txtUserId.Text '取得输入的用户名
        strPassword = txtPassword.Text '取得输入的密码

        If String.IsNullOrEmpty(strUserId) Then
            '用户名未输入的时候，弹出提示信息
            MessageBox.Show(String.Format(MsgConst.M00002I, "用户名"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUserId.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(strPassword) Then
            '密码未输入的时候，弹出提示信息
            MessageBox.Show(String.Format(MsgConst.M00002I, "密码"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Focus()
            Exit Sub
        End If

        Try
            '取得当前登录用户权限信息
            dsLoginInfo = loginBizLogic.GetUserInfo(strUserId, strPassword)
            '取得结果件数
            intCnt = dsLoginInfo.Tables(0).Rows.Count

            '结果件数大于0时
            If intCnt > 0 Then
                '取得用户ID、用户名
                With dsLoginInfo.Tables(0).Rows(0)
                    strId = .Item("ID").ToString
                    strUserName = .Item("UserName").ToString
                End With

                'Login信息的是否为管理员属性设定
                If dsLoginInfo.Tables(0).Select("access_type='" & Consts.AccessType.ADMIN & "'" & " AND ID='" & strId & "'").Length > 0 Then
                    Me.Login.IsAdmin = True
                Else
                    Me.Login.IsAdmin = False
                    '循环取得权限区分code
                    For Each row As DataRow In dsLoginInfo.Tables(0).Select("ID='" & strId & "'")
                        If row.Item("access_type").ToString = Consts.AccessType.KINOU Then
                            '取得权限区分
                            strAccessCd = row.Item("access_cd").ToString.Trim
                            '如果权限区分不为空值,将值放到list中
                            If String.IsNullOrEmpty(strAccessCd) = False Then
                                lstCode.Add(strAccessCd)
                            End If
                        End If
                    Next
                End If

            Else '输入的用户不存在的时候
                MessageBox.Show(MsgConst.M00001E, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '共通LoginInfo设定
            Me.SetLoginInfo(strId, strUserName, lstCode)

            NavigateToNextPage(Consts.PAGE.MS_MAIN) '跳转到Main(MS维护)主页面

        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 取消按钮点击处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close() '关闭窗体
    End Sub

    ''' <summary>
    ''' 用户名文本框失去焦点处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtUserId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserId.LostFocus
        '用户名
        Dim strUserId As String = String.Empty
        '去掉输入的用户名两端的空格
        strUserId = Me.txtUserId.Text.Trim
        '将去空格后的值赋给文本框
        Me.txtUserId.Text = strUserId
    End Sub

    ''' <summary>
    ''' 密码文本框enter键按下处理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        '如果是enter键按下
        If e.KeyCode = Keys.Enter Then
            '触发确定按钮点击处理
            Me.btnEnsure_Click(sender, e)
        End If
    End Sub

#End Region

#Region "方法"

    ''' <summary>
    ''' 窗体初期化处理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        Me.txtUserId.Text = String.Empty
        Me.txtPassword.Text = String.Empty
    End Sub

#End Region

    Private Sub 帮助ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
