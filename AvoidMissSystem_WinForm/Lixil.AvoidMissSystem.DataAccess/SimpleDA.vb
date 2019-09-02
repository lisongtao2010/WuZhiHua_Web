Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager

Partial Public Class SimpleDA

    ''' <summary>
    ''' test database
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function TestDB() As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.Append(" SELECT")
        sb.Append("	 GETDATE()")

        'sb.Append(" WHERE")
        'sb.Append("	  A.kaisya_cd = @kaisya_cd")
        'sb.Append("   AND")
        'sb.Append("	  A.eigyo_jgy_cd = @eigyo_jgy_cd")
        'sb.Append("   AND")
        'sb.Append("	  A.kentou_no = @kentou_no")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        'paramList.Add(Dao.MakeParam("@kaisya_cd", SqlDbType.Char, 4, "test"))

        '検索の実行
        Dim tableName As String = "test"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

End Class
