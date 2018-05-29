Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data

Public Class CheckTools

    Public Const UNDELETED As String = "0"

    ''' <summary>
    ''' 治具列表的取得
    ''' </summary>
    ''' <param name="strGoodsId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetToolsNoList(ByVal strGoodsId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strGoodsId)
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" DISTINCT( m_check.tools_id ) ")
        sb.AppendLine(" , ISNULL(m_tools.tools_no, '') AS tools_no ")
        sb.AppendLine(" , ISNULL(m_check.tools_order, '') AS tools_order ")
        sb.AppendLine(" , ISNULL(m_tools.barcode_flg, '') AS barcode_flg ")
        sb.AppendLine(" , ISNULL(m_tools.barcode, '') AS barcode ")
        sb.AppendLine(" , ISNULL(m_tools.remarks, '') AS remarks ")
        sb.AppendLine(" FROM ")
        sb.AppendLine(" m_check WITH(READCOMMITTED) ")
        sb.AppendLine(" INNER JOIN m_tools WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_check.tools_id = m_tools.id ")
        sb.AppendLine(" AND m_tools.delete_flg = @delete_flg ")
        sb.AppendLine(" WHERE m_check.goods_id = @goods_id ")
        sb.AppendLine(" AND m_check.kind_cd = '02' ")
        sb.AppendLine(" AND m_check.delete_flg = @delete_flg ")
        sb.AppendLine(" ORDER BY m_check.tools_order ")

        paramList.Add(MakeParam("@goods_id", SqlDbType.Char, 7, strGoodsId))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        'パラメータ設定
        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "ToolsList"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function
End Class
