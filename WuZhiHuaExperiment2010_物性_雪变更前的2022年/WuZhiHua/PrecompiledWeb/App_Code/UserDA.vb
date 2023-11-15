Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data


Public Class UserDA


    ''' <summary>
    ''' 取得用户权限信息处理
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetUserName(ByVal userId As String) As String

        Dim sb As New StringBuilder
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        Dim tableName As String = "TB_User"

        sb.AppendLine(" SELECT")
        sb.AppendLine("	    U.LoginName") '用户ID
        sb.AppendLine("	    ,U.UserName") '用户名
        sb.AppendLine(" FROM")
        sb.AppendLine("	    TB_User U WITH(READCOMMITTED)") '用户表
        sb.AppendLine(" WHERE")
        sb.AppendLine("     U.UserCode = @LoginName")

        'パラメータ設定
        paramList.Add(MakeParam("@LoginName", SqlDbType.NVarChar, 30, userId)) '用户名

        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)

        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("UserName").ToString
        Else
            Return ComConst.Err
        End If

    End Function

End Class
