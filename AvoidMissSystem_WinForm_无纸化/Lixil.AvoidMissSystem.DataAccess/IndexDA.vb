Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager

''' <summary>
''' 採番用
''' </summary>
''' <remarks></remarks>
Public Class IndexDA
    ''' <summary>
    ''' 根据区分来检索採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIndex(ByVal typeKbn As String, Optional ByVal dateNow As String = "") As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, typeKbn)

        Dim sb As New StringBuilder
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)

        sb.Append(" SELECT ")
        sb.Append("	    type_kbn ")
        sb.Append("	    ,no ")
        sb.Append("	    ,max_no ")
        sb.Append("	FROM t_index  WITH(READCOMMITTED) ")
        sb.Append("	WHERE type_kbn = @type_kbn ")

        If String.IsNullOrEmpty(dateNow) = False Then
            sb.Append("	AND index_date = @index_date ")
            paramList.Add(MakeParam("@index_date", SqlDbType.VarChar, 8, dateNow))
        End If

        'パラメータ設定
        paramList.Add(MakeParam("@type_kbn", SqlDbType.Char, 2, typeKbn))

        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "t_index", paramList.ToArray)
        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' 插入採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <param name="no">当前值</param>
    ''' <param name="maxNo">最大值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIndex(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal typeKbn As String, ByVal no As String, ByVal maxNo As String, ByVal dateNow As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, typeKbn, no, maxNo)
        '変数宣言
        Dim paramList As New List(Of SqlClient.SqlParameter)
        Dim reCount As New Integer
        Dim insertsql As New Text.StringBuilder

        insertsql.AppendLine("	INSERT INTO                   ")
        insertsql.AppendLine("		t_index WITH(UPDLOCK) (   ")
        insertsql.AppendLine("			type_kbn              ")
        insertsql.AppendLine("			,index_date           ")
        insertsql.AppendLine("			,no                   ")
        insertsql.AppendLine("			,max_no )             ")
        insertsql.AppendLine("		VALUES(                   ")
        insertsql.AppendLine("			@type_kbn             ")
        insertsql.AppendLine("			,@index_date          ")
        insertsql.AppendLine("			,@no                  ")
        insertsql.AppendLine("			,@max_no )            ")

        paramList.Add(MakeParam("@type_kbn", SqlDbType.Char, 2, typeKbn))
        paramList.Add(MakeParam("@index_date", SqlDbType.VarChar, 8, dateNow))
        paramList.Add(MakeParam("@no", SqlDbType.VarChar, 8, no))
        paramList.Add(MakeParam("@max_no", SqlDbType.VarChar, 8, maxNo))

        reCount = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, insertsql.ToString(), paramList.ToArray)

        Return reCount
    End Function

    ''' <summary>
    ''' 更改採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <param name="no">当前值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIndex(ByVal typeKbn As String, ByVal no As String, Optional ByVal dateNow As String = "") As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, typeKbn, no)
        '変数宣言
        Dim paramList As New List(Of SqlClient.SqlParameter)
        Dim reCount As New Integer
        Dim updatesql As New Text.StringBuilder

        updatesql.AppendLine("	UPDATE                        ")
        updatesql.AppendLine("		t_index WITH(UPDLOCK)     ")
        updatesql.AppendLine("	SET		            ")
        updatesql.AppendLine("			no      = @no         ")
        updatesql.AppendLine("	WHERE type_kbn = @type_kbn    ")

        If String.IsNullOrEmpty(dateNow) = False Then
            updatesql.Append("	AND index_date = @index_date ")
            paramList.Add(MakeParam("@index_date", SqlDbType.VarChar, 8, dateNow))
        End If

        paramList.Add(MakeParam("@type_kbn", SqlDbType.Char, 2, typeKbn))
        paramList.Add(MakeParam("@no", SqlDbType.VarChar, 8, no))

        reCount = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, updatesql.ToString(), paramList.ToArray)

        Return reCount
    End Function
End Class
