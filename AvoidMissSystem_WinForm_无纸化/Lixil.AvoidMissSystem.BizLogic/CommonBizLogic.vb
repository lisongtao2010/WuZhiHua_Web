Imports Lixil.AvoidMissSystem.DataAccess
Imports Lixil.AvoidMissSystem.Utilities
Imports Lixil.AvoidMissSystem.Utilities.Consts
Imports System.Transactions

Public Class CommonBizLogic
    Dim da As New CommonDA

    ''' <summary>
    ''' 取得系统日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSystemDate() As DateTime
        Dim dt As DataTable = da.SelectSystemDate()
        If dt.Rows.Count > 0 Then
            Return CDate(dt.Rows(0).Item("system_date"))
        Else
            Return Date.Now
        End If
    End Function

    ''' <summary>
    ''' 取得基准显示信息
    ''' </summary>
    ''' <param name="strType"></param>
    ''' <param name="hsSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBenchmarkShow(ByVal strType As String, ByVal hsSearch As Hashtable) As String
        'strType；基准类型 hsSearch（"value1"）:基准值1 hsSearch（"value2"）:基准值2 hsSearch（"value3"）:基准值3
        Select Case strType
            Case "00"
                Return String.Empty

            Case "01"
                '……
            Case Else

        End Select
        Return "显示基准值"

    End Function
    ''' <summary>
    ''' 取得检查结果
    ''' </summary>
    ''' <param name="strType"></param>
    ''' <param name="hsSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCheckResult(ByVal strType As String, ByVal hsSearch As Hashtable) As String
        'strType；基准类型 hsSearch（"value1"）:实测值1 hsSearch（"value2"）:实测值2 hsSearch（"value3"）:实测值3
        Select Case strType
            Case "01"

            Case "02"
                '……
            Case Else

        End Select

        Return "检查结果"

    End Function

    ''' <summary>
    ''' 管理员部门取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAdminDepartment() As DataSet
        Return da.GetAdminDepartment()
    End Function

    ''' <summary>
    ''' 非管理员部门取得
    ''' </summary>
    ''' <param name="strUserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDepartment(ByVal strUserID As String) As DataSet
        Return da.GetDepartment(strUserID)
    End Function

    ''' <summary>
    ''' 日志表插入
    ''' </summary>
    ''' <param name="name">操作的机能名</param>
    ''' <param name="type">操作类型</param>
    ''' <param name="filePath">更新操作Excel文件存放路径</param>
    ''' <param name="useId">操作用户id</param>
    ''' <param name="updDate">操作时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertLog(ByVal name As String, _
                              ByVal type As String, _
                              ByVal filePath As String, _
                              ByVal useId As String, _
                              ByVal updDate As DateTime) As Integer
        Dim id As String = String.Empty
        Dim bcIndex As New IndexBizLogic
        '采番处理
        id = bcIndex.GetIndex(Consts.TYPEKBN.LOG)
        Select Case id
            Case DBErro.InserError
                Return 0
            Case DBErro.UpdateError
                Return 0
            Case DBErro.GetIndexError
                Return 0
            Case DBErro.GetIndexMaxError
                Return 0
        End Select

        Return da.InsertLog(id, name, type, filePath, useId, updDate)
    End Function

End Class
