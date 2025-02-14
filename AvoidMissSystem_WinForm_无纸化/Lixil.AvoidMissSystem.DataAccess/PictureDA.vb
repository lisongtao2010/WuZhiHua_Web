Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities.Consts

Public Class PictureDA

    ''' <summary>
    ''' 権限取得
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetAuthority(ByVal strUserID As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mp.access_type ")
        sb.AppendLine("	 ,mp.delete_flg ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_permission mp WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  mp.delete_flg <> '1' ")
        sb.AppendLine("  AND mp.user_id = @user_id ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@user_id", SqlDbType.BigInt, 18, strUserID))

        '検索の実行
        Dim tableName As String = "authority"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 管理员权限管理员部门信息取得
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetAdminDepartment() As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mk.mei_cd ")
        sb.AppendLine("	 ,mk.mei ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_kbn mk WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  mk.delete_flg <> '1' ")
        sb.AppendLine("  AND mk.mei_kbn = @mei_kbn ")

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
    ''' 部门权限部门信息取得
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetUserDepartment(ByVal strUserID As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

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
        sb.AppendLine("  mp.delete_flg <> '1' ")
        sb.AppendLine("  AND mk.delete_flg <> '1' ")
        sb.AppendLine("  AND mp.user_id = @user_id ")
        sb.AppendLine("  AND mp.access_type = '2' ")

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
    ''' 图片一覧取得
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetPictureData(ByVal goodsCd As String _
                                  , ByVal department As String _
                                  , ByVal picId As String _
                                  , ByVal picNm As String _
                                  , ByVal picName As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, goodsCd, department, picId, picNm, picName)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT DISTINCT")
        sb.AppendLine("     m_picture.id AS picture_id,")
        'sb.AppendLine("     m_goods.goods_cd AS goods_cd,")
        sb.AppendLine("     m_picture.department_cd AS department_cd,")
        sb.AppendLine("     m_kbn.mei AS department_mei,")
        sb.AppendLine("     m_picture.picture_nm AS picture_nm,")
        sb.AppendLine("     m_picture.picture_name AS picture_name,")
        sb.AppendLine("     m_picture.update_date AS update_date")
        'sb.AppendLine("     m_classify.goods_id AS goods_id")
        sb.AppendLine(" FROM")
        sb.AppendLine("     m_picture WITH(READCOMMITTED)")
        sb.AppendLine(" LEFT JOIN")
        sb.AppendLine("     m_classify WITH(READCOMMITTED)")
        sb.AppendLine(" ON  m_picture.id = m_classify.picture_id")
        sb.AppendLine(" AND m_classify.delete_flg <> '1' ")
        sb.AppendLine(" LEFT JOIN")
        sb.AppendLine("     m_goods WITH(READCOMMITTED)")
        sb.AppendLine(" ON  m_classify.goods_id = m_goods.id")
        sb.AppendLine(" AND m_goods.delete_flg <> '1' ")
        sb.AppendLine(" LEFT JOIN")
        sb.AppendLine("     m_kbn WITH(READCOMMITTED)")
        sb.AppendLine(" ON  m_picture.department_cd = m_kbn.mei_cd")
        sb.AppendLine(" AND m_kbn.mei_kbn = '0004'")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  m_picture.delete_flg <> '1' ")
        If String.IsNullOrEmpty(goodsCd) = False Then
            sb.AppendLine(" AND m_goods.goods_cd LIKE @goods_cd")
        End If
        If String.IsNullOrEmpty(department) = False Then
            sb.AppendLine(" AND m_picture.department_cd IN (" & department & ")")
        End If
        If String.IsNullOrEmpty(picId) = False Then
            sb.AppendLine(" AND m_picture.id = @picId")
        End If
        If String.IsNullOrEmpty(picNm) = False Then
            sb.AppendLine(" AND m_picture.picture_nm LIKE @picNm")
        End If
        If String.IsNullOrEmpty(picName) = False Then
            sb.AppendLine(" AND m_picture.picture_name LIKE @picName")
        End If
        sb.AppendLine(" ORDER BY ")
        sb.AppendLine("     m_picture.id,")
        sb.AppendLine("     m_picture.update_date DESC")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 32, "%" & goodsCd & "%"))
        paramList.Add(MakeParam("@picId", SqlDbType.Char, 7, picId))
        paramList.Add(MakeParam("@picNm", SqlDbType.NVarChar, 400, "%" & picNm & "%"))
        paramList.Add(MakeParam("@picName", SqlDbType.NVarChar, 200, "%" & picName & "%"))

        '検索の実行
        Dim tableName As String = "picture"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 根据ID取得图片
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function GetPictureById(ByVal picId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, picId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT")
        sb.AppendLine("     id AS picture_id,")
        sb.AppendLine("     picture_content AS picture_content")
        sb.AppendLine(" FROM")
        sb.AppendLine("     m_picture WITH(READCOMMITTED)")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  id = @Id ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@Id", SqlDbType.Char, 7, picId))

        '検索の実行
        Dim tableName As String = "pictureById"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 图片信息添加
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function InsertPicture(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal hstb As Hashtable) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, hstb)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("     m_picture")
        sb.AppendLine("     (id,")
        sb.AppendLine("     department_cd,")
        sb.AppendLine("     picture_nm,")
        sb.AppendLine("     picture_name,")
        sb.AppendLine("     picture_content,")
        sb.AppendLine("     delete_flg,")
        sb.AppendLine("     insert_user,")
        sb.AppendLine("     insert_date,")
        sb.AppendLine("     update_user,")
        sb.AppendLine("     update_date)")
        sb.AppendLine(" VALUES(")
        sb.AppendLine("     @id,")
        sb.AppendLine("     @department_cd,")
        sb.AppendLine("     @picture_nm,")
        sb.AppendLine("     @picture_name,")
        sb.AppendLine("     @picture_content,")
        sb.AppendLine("     @delete_flg,")
        sb.AppendLine("     @insert_user,")
        sb.AppendLine("     GETDATE(),")
        sb.AppendLine("     @update_user,")
        sb.AppendLine("     GETDATE())")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, hstb("picId")))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, hstb("departmentCd")))
        paramList.Add(MakeParam("@picture_nm", SqlDbType.NVarChar, 400, hstb("picNm")))
        paramList.Add(MakeParam("@picture_name", SqlDbType.NVarChar, 200, hstb("picName")))
        paramList.Add(MakeParam("@picture_content", SqlDbType.VarBinary, -1, hstb("picContent")))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "0"))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, hstb("User")))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, hstb("User")))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 图片更新
    ''' </summary>
    ''' <param name="hstb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdatePicture(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal hstb As Hashtable) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, hstb)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE ")
        sb.AppendLine("	 m_picture WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 department_cd = @department_cd ")
        sb.AppendLine("	 ,picture_name = @picture_name ")
        sb.AppendLine("	 ,update_user = @update_user ")
        sb.AppendLine("	 ,update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id")

        'パラメータ設定
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, hstb("departmentCd")))
        paramList.Add(MakeParam("@picture_name", SqlDbType.NVarChar, 200, hstb("picName")))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, hstb("user")))
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, hstb("picId")))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 图片删除
    ''' </summary>
    ''' <param name="hstb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeletePicture(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal hstb As Hashtable) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, hstb)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE ")
        sb.AppendLine("	 m_picture WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 delete_flg = @delete_flg ")
        sb.AppendLine("	 ,update_user = @update_user ")
        sb.AppendLine("	 ,update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id IN (" & hstb("picId").ToString & ")")

        'パラメータ設定
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, hstb("user")))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "1"))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 分类表更新
    ''' </summary>
    ''' <param name="hstb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateClassify(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, ByVal hstb As Hashtable) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, hstb)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE ")
        sb.AppendLine("	 m_classify WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 picture_id = @picture_id ")
        sb.AppendLine("	 ,update_user = @update_user ")
        sb.AppendLine("	 ,update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 picture_id = @picture_id_old")
        sb.AppendLine("	 AND goods_id IN ( ")
        sb.AppendLine("	    SELECT id FROM m_goods WITH(READCOMMITTED)")
        sb.AppendLine("	    WHERE goods_cd IN (" & hstb("goodsId").ToString & ")")
        sb.AppendLine("	 )")


        'パラメータ設定
        paramList.Add(MakeParam("@picture_id", SqlDbType.VarChar, 7, hstb("picId")))
        paramList.Add(MakeParam("@picture_id_old", SqlDbType.VarChar, 7, hstb("picIdOld")))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, hstb("User")))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 图片导入
    ''' </summary>
    ''' <param name="drExcel"></param>
    ''' <param name="strUser"></param>
    ''' <param name="sysTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsOrUpdPicture(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
                                    ByVal drExcel As DataRow, ByVal strUser As String, ByVal hstb As Hashtable, ByVal sysTime As String, _
                                    ByRef updFlg As Boolean) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, drExcel, strUser, hstb, sysTime)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        If String.IsNullOrEmpty(hstb(drExcel("图片ID").ToString).ToString) Then
            sb.AppendLine(" IF EXISTS(SELECT * FROM m_picture WHERE Id = @id) ")
            sb.AppendLine("	 BEGIN ")
            sb.AppendLine("	   UPDATE m_picture WITH (UPDLOCK) ")
            sb.AppendLine("	   SET department_cd = @department_cd  ")
            sb.AppendLine("	      ,picture_name = @picture_name ")
            sb.AppendLine("	      ,update_user = @update_user ")
            sb.AppendLine("	      ,update_date = @update_date ")
            sb.AppendLine("	   WHERE Id = @id ")
            sb.AppendLine("	END ")

            updFlg = True
        Else
            sb.AppendLine("	  INSERT INTO m_picture WITH (UPDLOCK)  ")
            sb.AppendLine("	  (id, department_cd,picture_nm,picture_name,picture_content,delete_flg,insert_user,insert_date,update_user,update_date)  ")
            sb.AppendLine("	  VALUES(@id, @department_cd, @picture_nm, @picture_name, @picture_content, @delete_flg, @insert_user, @insert_date, @update_user, @update_date) ")

            updFlg = False
        End If

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, Convert.ToString(drExcel("图片ID"))))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, Convert.ToString(drExcel("部门CD"))))
        paramList.Add(MakeParam("@picture_nm", SqlDbType.NVarChar, 400, Convert.ToString(drExcel("图片名称"))))
        paramList.Add(MakeParam("@picture_name", SqlDbType.NVarChar, 200, Convert.ToString(drExcel("图片描述备注"))))
        If String.IsNullOrEmpty(hstb(drExcel("图片ID").ToString).ToString) = False Then
            paramList.Add(MakeParam("@picture_content", SqlDbType.VarBinary, -1, hstb(drExcel("图片ID").ToString)))
        End If
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, "0"))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, strUser))
        paramList.Add(MakeParam("@insert_date", SqlDbType.DateTime, 28, sysTime))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, strUser))
        paramList.Add(MakeParam("@update_date", SqlDbType.DateTime, 28, sysTime))

        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        'PersonalDbTransactionScopeAction.e(sb.ToString(), CommandType.Text, paramList.ToArray)
        ''更新の実行
        'result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 图片导出
    ''' </summary>
    ''' <returns>データセット</returns>
    ''' <remarks></remarks>
    Public Function ExportPictureData(ByVal goodsId As String _
                                      , ByVal department As String _
                                      , ByVal picId As String _
                                      , ByVal picNm As String _
                                      , ByVal picName As String, ByVal pageIdx As Integer) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, goodsId, department, picId, picName)

        Dim sb As New StringBuilder


        sb.AppendLine(" SELECT * FROM (")
        sb.AppendLine(" SELECT ")


        'sb.AppendLine(" SELECT DISTINCT")
        sb.AppendLine("     m_picture.id AS picture_id,")
        sb.AppendLine("     '' AS goods_id,")
        sb.AppendLine("     m_kbn.mei AS department_mei,")
        sb.AppendLine("     m_picture.picture_nm AS picture_nm,")
        sb.AppendLine("     m_picture.department_cd AS department_cd,")
        sb.AppendLine("     m_picture.picture_name AS picture_name,")
        sb.AppendLine("     m_picture.update_date AS update_date,")
        'sb.AppendLine("     '' AS picture_mei,")
        sb.AppendLine("     m_picture.picture_content AS picture_content,")
        sb.AppendLine("     row_number() over(order by m_picture.id) as rowIdx")
        sb.AppendLine(" FROM")
        sb.AppendLine("     m_picture WITH(READCOMMITTED)")
        'sb.AppendLine(" INNER JOIN")
        'sb.AppendLine("     m_classify WITH(READCOMMITTED)")
        'sb.AppendLine(" ON  m_picture.id = m_classify.picture_id")
        sb.AppendLine(" LEFT JOIN")
        sb.AppendLine("     m_kbn WITH(READCOMMITTED)")
        sb.AppendLine(" ON  m_picture.department_cd = m_kbn.mei_cd")
        sb.AppendLine(" AND m_kbn.mei_kbn = '0004'")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  m_picture.delete_flg <> '1' ")
        'sb.AppendLine("  AND m_classify.delete_flg <> '1' ")
        'If String.IsNullOrEmpty(goodsId) = False Then
        '    sb.AppendLine(" AND m_classify.goods_id = @goodsId")
        'End If
        If String.IsNullOrEmpty(department) = False Then
            sb.AppendLine(" AND m_picture.department_cd IN (" & department & ")")
        End If
        If String.IsNullOrEmpty(picId) = False Then
            sb.AppendLine(" AND m_picture.id = @picId")
        End If
        If String.IsNullOrEmpty(picNm) = False Then
            sb.AppendLine(" AND m_picture.picture_nm LIKE @picNm")
        End If
        If String.IsNullOrEmpty(picName) = False Then
            sb.AppendLine(" AND m_picture.picture_name LIKE @picName")
        End If
        sb.AppendLine("	AND m_picture.delete_flg = @delete_flg ")


        sb.AppendLine(" ) tbl ")

        If pageIdx > 0 Then
            sb.AppendLine(" WHERE rowIdx between " & ((pageIdx - 1) * 1000 + 1) & " AND  " & ((pageIdx) * 1000))
        Else
            sb.AppendLine(" WHERE 1=1 ")
        End If

        sb.AppendLine(" ORDER BY ")
        sb.AppendLine("     picture_id")
        'sb.AppendLine("     m_picture.update_date DESC")
        ' sb.AppendLine("     m_picture.id")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        'paramList.Add(MakeParam("@goodsId", SqlDbType.Char, 7, goodsId))
        paramList.Add(MakeParam("@picId", SqlDbType.Char, 7, picId))
        paramList.Add(MakeParam("@picNm", SqlDbType.NVarChar, 400, "%" & picNm & "%"))
        paramList.Add(MakeParam("@picName", SqlDbType.NVarChar, 200, "%" & picName & "%"))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "picture"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 商品CD取得
    ''' </summary>
    ''' <param name="strPictureId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGoodsCdList(ByVal strPictureId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strPictureId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT  DISTINCT ")
        'sb.AppendLine("      m_picture.id AS picture_id, ")
        sb.AppendLine("      m_goods.goods_cd , ")
        sb.AppendLine("      m_goods.id  ")
        sb.AppendLine("  FROM ")
        sb.AppendLine("      m_classify WITH(READCOMMITTED) ")
        sb.AppendLine("  LEFT JOIN ")
        sb.AppendLine("      m_picture WITH(READCOMMITTED) ")
        sb.AppendLine("  ON  m_picture.id = m_classify.picture_id ")
        sb.AppendLine("  AND m_picture.delete_flg <> '1'  ")
        sb.AppendLine("  LEFT JOIN ")
        sb.AppendLine("      m_goods WITH(READCOMMITTED) ")
        sb.AppendLine("  ON  m_classify.goods_id = m_goods.id ")
        sb.AppendLine("  AND m_goods.delete_flg <> '1'  ")
        sb.AppendLine("  WHERE  ")
        sb.AppendLine("   m_classify.delete_flg <> '1'  ")
        'sb.AppendLine("   AND m_picture.id = @id ")
        sb.AppendLine("   AND m_picture.id IN ( " & strPictureId & " ) ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        'paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, strPictureId))

        '検索の実行
        Dim tableName As String = "Goods"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 图片ID取得
    ''' </summary>
    ''' <param name="picId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPictureId(ByVal picId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, picId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT")
        sb.AppendLine("     id AS picture_id")
        sb.AppendLine("     ,picture_nm")
        sb.AppendLine("     ,department_cd")
        sb.AppendLine("     ,picture_name")
        sb.AppendLine(" FROM")
        sb.AppendLine("     m_picture WITH(READCOMMITTED)")
        sb.AppendLine(" WHERE ")
        sb.AppendLine("  id = @Id ")

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@Id", SqlDbType.Char, 7, picId))

        '検索の実行
        Dim tableName As String = "pictureById"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

End Class
