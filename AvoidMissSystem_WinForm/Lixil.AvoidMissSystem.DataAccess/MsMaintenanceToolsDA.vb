Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities.Consts

''' <summary>
''' 治具MS维护
''' </summary>
''' <remarks></remarks>
Public Class MsMaintenanceToolsDA

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

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@user_id", SqlDbType.BigInt, 18, strUserID))

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

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, "0004"))

        '検索の実行
        Dim tableName As String = "Department"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 治具信息取得
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetTools(ByVal dicSearch As Dictionary(Of String, String)) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicSearch)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	  id ")
        sb.AppendLine("	 ,tools_no ")
        sb.AppendLine("	 ,department_cd ")
        sb.AppendLine("	 ,mk.mei as department ")
        sb.AppendLine("	 ,distinguish ")
        sb.AppendLine("	 ,CASE WHEN barcode_flg='0' THEN '无条码' ")
        sb.AppendLine("	  WHEN barcode_flg='1' THEN '有条码' ")
        sb.AppendLine("	  ELSE '' END AS barcode_flg_name ")
        sb.AppendLine("	 ,barcode_flg ")
        sb.AppendLine("	 ,barcode ")
        sb.AppendLine("	 ,remarks ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_tools mt WITH(READCOMMITTED) ")
        sb.AppendLine(" LEFT JOIN m_kbn mk WITH(READCOMMITTED) ")
        sb.AppendLine(" ON mt.department_cd =mk.mei_cd ")
        sb.AppendLine(" AND mk.mei_kbn = '0004' ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("	  mt.department_cd in (" & dicSearch("DepartmentCD") & ") ")

        '商品CD
        If Not String.IsNullOrEmpty(dicSearch("GoodsCD")) Then
            sb.AppendLine("	AND EXISTS(SELECT ")
            sb.AppendLine("	 tools_id ")
            sb.AppendLine(" FROM ")
            sb.AppendLine("  m_goods mg WITH(READCOMMITTED) ")
            sb.AppendLine(" LEFT JOIN m_classify mc WITH(READCOMMITTED) ")
            sb.AppendLine(" ON mc.goods_id = mg.id ")
            sb.AppendLine(" AND mc.delete_flg = @delete_flg ")
            sb.AppendLine("	WHERE mg.goods_cd like @goods_cd ")
            sb.AppendLine("	AND mc.tools_id = mt.id ")
            sb.AppendLine("	AND mg.delete_flg = @delete_flg) ")
        End If
        '治具ID
        If Not String.IsNullOrEmpty(dicSearch("ID")) Then
            sb.AppendLine("	AND mt.id = @id")
        End If
        '治具编号
        If Not String.IsNullOrEmpty(dicSearch("ToolsNo")) Then
            sb.AppendLine("	AND mt.tools_no like @tools_no")
        End If
        '区分
        If Not String.IsNullOrEmpty(dicSearch("Distinguish")) Then
            sb.AppendLine("	AND mt.distinguish like @distinguish")
        End If
        '基准值
        If Not String.IsNullOrEmpty(dicSearch("BarcodeFlg")) Then
            sb.AppendLine("	AND mt.barcode_flg = @barcode_flg")
        Else
            sb.AppendLine("	AND mt.barcode_flg IN ('0','1')")
        End If
        '条形码
        If Not String.IsNullOrEmpty(dicSearch("Barcode")) Then
            sb.AppendLine("	AND mt.barcode like @barcode")
        End If
        '备注 
        If Not String.IsNullOrEmpty(dicSearch("Remarks")) Then
            sb.AppendLine("	AND mt.remarks like @remarks ")
        End If
        sb.AppendLine("	AND mt.delete_flg = @delete_flg ")
        sb.AppendLine(" ORDER BY mt.id ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, dicSearch("ID")))
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 32, "%" & dicSearch("GoodsCD") & "%"))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 32, "%" & dicSearch("ToolsNo") & "%"))
        paramList.Add(MakeParam("@distinguish", SqlDbType.VarChar, 102, "%" & dicSearch("Distinguish") & "%"))
        paramList.Add(MakeParam("@barcode", SqlDbType.VarChar, 32, "%" & dicSearch("Barcode") & "%"))
        paramList.Add(MakeParam("@barcode_flg", SqlDbType.Char, 1, dicSearch("BarcodeFlg")))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 202, "%" & dicSearch("Remarks") & "%"))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "mtools"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 商品CD取得
    ''' </summary>
    ''' <param name="strToolId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGoodsCdList(ByVal strToolId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strToolId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mg.goods_cd ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_tools mt WITH(READCOMMITTED) ")
        sb.AppendLine(" LEFT JOIN m_classify mc WITH(READCOMMITTED) ")
        sb.AppendLine(" ON mt.id = mc.tools_id ")
        sb.AppendLine(" LEFT JOIN m_goods mg WITH(READCOMMITTED) ")
        sb.AppendLine(" ON mc.goods_id = mg.id ")
        sb.AppendLine(" WHERE mt.id = @id ")
        sb.AppendLine(" AND mg.goods_cd IS NOT NULL ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, strToolId))

        '検索の実行
        Dim tableName As String = "Goods"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 治具信息添加
    ''' </summary>
    ''' <param name="dicTools"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertTools(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal dicTools As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicTools)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("	 m_tools(id, tools_no,department_cd,distinguish,barcode_flg,barcode,remarks,delete_flg,insert_user,insert_date,update_user,update_date) ")
        sb.AppendLine("	  VALUES(@id, @tools_no, @department_cd, @distinguish, @barcode_flg, @barcode, @remarks, @delete_flg, @insert_user, @insert_date, @update_user, @update_date) ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, dicTools("ID")))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 30, dicTools("ToolsNo")))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, dicTools("DepartmentCd")))
        paramList.Add(MakeParam("@distinguish", SqlDbType.VarChar, 100, dicTools("Distinguish")))
        paramList.Add(MakeParam("@barcode_flg", SqlDbType.Char, 1, dicTools("BarcodeFlg")))
        paramList.Add(MakeParam("@barcode", SqlDbType.VarChar, 30, dicTools("Barcode")))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, dicTools("Remarks")))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "0"))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, dicTools("User")))
        paramList.Add(MakeParam("@insert_date", SqlDbType.DateTime, 28, dicTools("SysTime")))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicTools("User")))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, dicTools("SysTime")))
        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具信息更新
    ''' </summary>
    ''' <param name="dicTools"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateTools(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal dicTools As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicTools)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE ")
        sb.AppendLine("	 m_tools WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 tools_no = @tools_no ")
        sb.AppendLine("	 ,department_cd = @department_cd ")
        sb.AppendLine("	 ,distinguish = @distinguish ")
        sb.AppendLine("	 ,barcode_flg = @barcode_flg ")
        sb.AppendLine("	 ,barcode = @barcode ")
        sb.AppendLine("	 ,remarks = @remarks ")
        sb.AppendLine("	 ,update_user = @update_user ")
        sb.AppendLine("	 ,update_date = @update_date ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, dicTools("ID")))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 30, dicTools("ToolsNo")))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, dicTools("DepartmentCd")))
        paramList.Add(MakeParam("@distinguish", SqlDbType.VarChar, 100, dicTools("Distinguish")))
        paramList.Add(MakeParam("@barcode_flg", SqlDbType.Char, 1, dicTools("BarcodeFlg")))
        paramList.Add(MakeParam("@barcode", SqlDbType.VarChar, 30, dicTools("Barcode")))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, dicTools("Remarks")))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicTools("User")))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, dicTools("SysTime")))
        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具信息删除
    ''' </summary>
    ''' <param name="dicTools"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteTools(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal dicTools As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicTools)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE ")
        sb.AppendLine("	 m_tools WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 delete_flg = @delete_flg ")
        sb.AppendLine("	 ,update_user = @update_user ")
        sb.AppendLine("	 ,update_date = @update_date ")
        sb.AppendLine("	WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, Convert.ToString(dicTools("ID"))))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "1"))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, Convert.ToString(dicTools("User"))))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, dicTools("SysTime")))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具信息添加
    ''' </summary>
    ''' <param name="drExcel"></param>
    ''' <param name="strUser"></param>
    ''' <param name="sysTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertImport(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal drExcel As DataRow, ByVal strUser As String, ByVal sysTime As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, drExcel, strUser, sysTime)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine("	  INSERT INTO m_tools WITH (UPDLOCK)  ")
        sb.AppendLine("	  (id, tools_no,department_cd,distinguish,barcode_flg,barcode,remarks,delete_flg,insert_user,insert_date,update_user,update_date)  ")
        sb.AppendLine("	  VALUES(@id, @tools_no,@department_cd, @distinguish, @barcode_flg, @barcode, @remarks, @delete_flg, @insert_user, @insert_date, @update_user, @update_date) ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, Convert.ToString(drExcel("ID"))))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 30, Convert.ToString(drExcel("治具编号"))))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, Convert.ToString(drExcel("部门CD"))))
        paramList.Add(MakeParam("@distinguish", SqlDbType.VarChar, 100, Convert.ToString(drExcel("治具区分"))))
        paramList.Add(MakeParam("@barcode_flg", SqlDbType.Char, 1, Convert.ToString(drExcel("基准值"))))
        paramList.Add(MakeParam("@barcode", SqlDbType.VarChar, 30, Convert.ToString(drExcel("条形码"))))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, Convert.ToString(drExcel("备注"))))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "0"))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, strUser))
        paramList.Add(MakeParam("@insert_date", SqlDbType.DateTime, 28, sysTime))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, strUser))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, sysTime))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具信息更新
    ''' </summary>
    ''' <param name="drExcel"></param>
    ''' <param name="strUser"></param>
    ''' <param name="sysTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateImport(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal drExcel As DataRow, ByVal strUser As String, ByVal sysTime As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, drExcel, strUser, sysTime)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine("	   UPDATE m_tools WITH (UPDLOCK) ")
        sb.AppendLine("	   SET tools_no = @tools_no  ")
        sb.AppendLine("	      ,department_cd = @department_cd ")
        sb.AppendLine("	      ,distinguish = @distinguish ")
        sb.AppendLine("	      ,barcode_flg = @barcode_flg ")
        sb.AppendLine("	      ,barcode = @barcode ")
        sb.AppendLine("	      ,remarks = @remarks ")
        sb.AppendLine("	      ,update_user = @update_user ")
        sb.AppendLine("	      ,update_date = @update_date ")
        sb.AppendLine("	   WHERE Id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, Convert.ToString(drExcel("ID"))))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 30, Convert.ToString(drExcel("治具编号"))))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, Convert.ToString(drExcel("部门CD"))))
        paramList.Add(MakeParam("@distinguish", SqlDbType.VarChar, 100, Convert.ToString(drExcel("治具区分"))))
        paramList.Add(MakeParam("@barcode_flg", SqlDbType.Char, 1, Convert.ToString(drExcel("基准值"))))
        paramList.Add(MakeParam("@barcode", SqlDbType.VarChar, 30, Convert.ToString(drExcel("条形码"))))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, Convert.ToString(drExcel("备注"))))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, strUser))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, sysTime))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具ID取得
    ''' </summary>
    ''' <param name="strToolId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetToolsID(ByVal strToolId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strToolId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 id ")
        sb.AppendLine("	 ,tools_no ")
        sb.AppendLine("	 ,department_cd ")
        sb.AppendLine("	 ,distinguish ")
        sb.AppendLine("	 ,barcode_flg ")
        sb.AppendLine("	 ,barcode ")
        sb.AppendLine("	 ,remarks ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_tools WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE id = @id ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, strToolId))

        '検索の実行
        Dim tableName As String = "mTools"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function
End Class
