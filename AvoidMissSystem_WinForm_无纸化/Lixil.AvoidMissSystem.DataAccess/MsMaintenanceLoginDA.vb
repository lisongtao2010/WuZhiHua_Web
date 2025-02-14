Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities

''' <summary>
''' MS维护登录页面用DB数据取得DataAccess
''' </summary>
''' <remarks></remarks>
Public Class MsMaintenanceLoginDA

    ''' <summary>
    ''' 取得用户权限信息处理
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="password" ></param>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetUserInfo(ByVal userId As String, ByVal password As String) As DataSet

        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, userId, password)
        Dim sb As New StringBuilder
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        Dim tableName As String = "TB_User"

        sb.AppendLine(" SELECT")
        sb.AppendLine("	    U.ID") '用户ID
        sb.AppendLine("	    ,U.UserName") '用户名
        sb.AppendLine("	    ,P.access_type") '用户名
        sb.AppendLine("	    ,P.access_cd") '权限区分
        sb.AppendLine(" FROM")
        sb.AppendLine("	    TB_User U WITH(READCOMMITTED)") '用户表
        sb.AppendLine(" LEFT JOIN")
        sb.AppendLine("	    m_permission P WITH(READCOMMITTED)") '权限表
        sb.AppendLine(" ON")
        sb.AppendLine("     U.ID = P.user_id")
        sb.AppendLine(" AND")
        sb.AppendLine("     P.delete_flg = @delete_flg")
        sb.AppendLine(" WHERE")
        sb.AppendLine("	    U.LoginName = @LoginName")
        sb.AppendLine(" AND")
        sb.AppendLine("     U.LoginPassword = @LoginPassword")

        'パラメータ設定
        paramList.Add(MakeParam("@LoginName", SqlDbType.NVarChar, 30, userId)) '用户名
        paramList.Add(MakeParam("@LoginPassword", SqlDbType.NVarChar, 30, password)) '密码
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, Consts.UNDELETED)) '删除区分：未删除

        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

End Class
