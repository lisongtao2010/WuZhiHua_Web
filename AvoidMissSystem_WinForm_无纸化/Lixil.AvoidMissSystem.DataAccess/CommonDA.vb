Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities.Consts

''' <summary>
''' 共通用
''' </summary>
''' <remarks></remarks>
Public Class CommonDA

    ''' <summary>
    ''' 取得DB日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectSystemDate() As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder
        Dim ds As New DataSet
        sb.Append(" SELECT ")
        sb.Append("	    GETDATE() AS system_date ")

        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "system_date")
        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' 非管理员部门取得
    ''' </summary>
    ''' <param name="strUserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDepartment(ByVal strUserID As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strUserID)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mk.mei_cd ")
        sb.AppendLine("	 ,mk.mei ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_permission mp WITH(READCOMMITTED) ")
        sb.AppendLine(" LEFT JOIN ")
        sb.AppendLine("  m_kbn mk WITH(READCOMMITTED) ")
        sb.AppendLine(" ON mp.access_cd = mk.mei_cd ")
        sb.AppendLine(" AND mk.mei_kbn = '0004' ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  mp.user_id = @user_id ")
        sb.AppendLine(" AND mp.access_type = '2' ")
        sb.AppendLine(" AND mp.delete_flg = @delete_flg ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@user_id", SqlDbType.BigInt, 18, strUserID))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "Department"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 管理员部门取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAdminDepartment() As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mk.mei_cd ")
        sb.AppendLine("	 ,mk.mei ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_kbn mk WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mk.mei_kbn = @mei_kbn ")
        sb.AppendLine(" AND mk.delete_flg = @delete_flg ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, "0004"))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "Department"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 日志表插入
    ''' </summary>
    ''' <param name="id">日志表采番的id</param>
    ''' <param name="name">操作的机能名</param>
    ''' <param name="type">操作类型</param>
    ''' <param name="filePath">更新操作Excel文件存放路径</param>
    ''' <param name="useId">操作用户id</param>
    ''' <param name="updDate">操作时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertLog(ByVal id As String, _
                              ByVal name As String, _
                              ByVal type As String, _
                              ByVal filePath As String, _
                              ByVal useId As String, _
                              ByVal updDate As DateTime) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, name, type, useId)
        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine(" t_log ( ")
        sb.AppendLine(" log_cd ")
        sb.AppendLine(" , operate_tb ")
        sb.AppendLine(" , operate_kind ")
        sb.AppendLine(" , operator_cd ")
        sb.AppendLine(" , operate_objcd ")
        sb.AppendLine(" , operate_date ")
        sb.AppendLine(" ) ")
        sb.AppendLine(" VALUES( ")
        sb.AppendLine(" @log_cd ")
        sb.AppendLine(" ,@operate_tb ")
        sb.AppendLine(" ,@operate_kind ")
        sb.AppendLine(" , @strUserId ")
        sb.AppendLine(" , @operate_objcd ")
        sb.AppendLine(" , @operate_date) ")
        paramList.Add(MakeParam("@log_cd", SqlDbType.VarChar, 15, id))
        paramList.Add(MakeParam("@operate_tb", SqlDbType.VarChar, 20, name))
        paramList.Add(MakeParam("@operate_kind", SqlDbType.VarChar, 3, type))
        paramList.Add(MakeParam("@strUserId", SqlDbType.VarChar, 30, useId))
        paramList.Add(MakeParam("@operate_objcd", SqlDbType.VarChar, 200, filePath))
        paramList.Add(MakeParam("@operate_date", SqlDbType.DateTime, 23, updDate))
        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function
End Class
