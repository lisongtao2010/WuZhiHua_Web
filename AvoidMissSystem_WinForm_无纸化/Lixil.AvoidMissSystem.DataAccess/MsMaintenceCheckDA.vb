Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities.Consts



Public Class MsMaintenceCheckDA

    ''' <summary>
    ''' 查询数据取得
    ''' </summary>
    ''' <param name="dicRequirement"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCheckData(ByVal dicRequirement As Dictionary(Of String, String), ByVal pageIdx As Integer) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicRequirement)

        Dim sb As New StringBuilder
        'm_check_ms_temp
        'sb.AppendLine(" truncate table m_check_ms_temp")
        'sb.AppendLine(" INSERT INTO m_check_ms_temp")
        sb.AppendLine(" SELECT * FROM (")
        sb.AppendLine(" SELECT ")
        sb.AppendLine(" row_number() over(order by m_check.id) as rowIdx")
        sb.AppendLine(" ,m_check.id")
        sb.AppendLine(" ,m_check.goods_id")
        sb.AppendLine(" ,m_check.kind_cd")
        sb.AppendLine(" ,m_check.tools_id")
        sb.AppendLine(" ,m_check.tools_order")
        sb.AppendLine(" ,m_check.classify_id")
        sb.AppendLine(" ,m_check.classify_order")
        sb.AppendLine(" ,m_check.type_cd")
        sb.AppendLine(" ,m_check.department_cd")
        sb.AppendLine(" ,m_check.kind")
        sb.AppendLine(" ,m_check.check_position")
        sb.AppendLine(" ,m_check.check_item")
        sb.AppendLine(" ,m_check.benchmark_type")
        sb.AppendLine(" ,m_check.benchmark_value1")
        sb.AppendLine(" ,m_check.benchmark_value2")
        sb.AppendLine(" ,m_check.benchmark_value3")
        sb.AppendLine(" ,m_check.check_way")
        sb.AppendLine(" ,m_check.check_times")
        sb.AppendLine(" ,m_check.delete_flg")
        sb.AppendLine(" ,m_kind.mei AS kind_name ")
        sb.AppendLine(" ,m_type.mei AS type_name ")
        sb.AppendLine(" ,m_department.mei AS department_name ")
        sb.AppendLine(" ,m_classify.classify_name ")
        sb.AppendLine(" ,m_picture.id AS picture_id")
        'sb.AppendLine(" ,m_picture.picture_content AS picture")
        sb.AppendLine(" ,m_goods.goods_cd ")
        sb.AppendLine(" ,m_goods.goods_name ")
        sb.AppendLine(" ,m_tools.tools_no")
        sb.AppendLine(" ,m_picture.picture_nm")
        sb.AppendLine(" ,m_picture.picture_name")


        sb.AppendLine(" FROM m_check WITH(READCOMMITTED)")
        '分类表
        sb.AppendLine(" LEFT JOIN m_classify WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.classify_id = m_classify.id ")
        sb.AppendLine(" AND m_classify.delete_flg = @delete_flg")
        '商品表
        sb.AppendLine(" LEFT JOIN m_goods WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.goods_id = m_goods.id ")
        sb.AppendLine(" AND m_goods.delete_flg = @delete_flg")
        '治具表
        sb.AppendLine(" LEFT JOIN m_tools WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.tools_id = m_tools.id ")
        sb.AppendLine(" AND m_tools.delete_flg = @delete_flg")
        '种类名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_kind WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.kind_cd = m_kind.mei_cd ")
        sb.AppendLine(" AND m_kind.mei_kbn = @mei_kbn_kind")
        sb.AppendLine(" AND m_kind.delete_flg = @delete_flg")
        '类型名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_type WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.type_cd = m_type.mei_cd ")
        sb.AppendLine(" AND m_type.mei_kbn = @mei_kbn_type")
        sb.AppendLine(" AND m_type.delete_flg = @delete_flg")
        '部门名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_department WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.department_cd = m_department.mei_cd ")
        sb.AppendLine(" AND m_department.mei_kbn = @mei_kbn_department")
        sb.AppendLine(" AND m_department.delete_flg = @delete_flg")
        '图片取得用
        sb.AppendLine(" LEFT JOIN m_picture WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_picture.id = m_classify.picture_id ")
        sb.AppendLine(" AND m_picture.delete_flg = @delete_flg")
        sb.AppendLine(" WHERE 1 = 1 ")
        'sb.AppendLine(" WHERE rows between " & pageIdx & "  ")


        If dicRequirement.Item("goodsCd") <> String.Empty Then
            sb.AppendLine(" AND m_goods.goods_cd LIKE @goods_cd")
        End If
        If dicRequirement.Item("goodsName") <> String.Empty Then
            sb.AppendLine(" AND m_goods.goods_name LIKE @goods_name")
        End If
        If dicRequirement.Item("kindCd") <> String.Empty Then
            sb.AppendLine(" AND m_check.kind_cd IN (" & dicRequirement.Item("kindCd").ToString & ")")
        End If
        If dicRequirement.Item("toolNo") <> String.Empty Then
            'sb.AppendLine(" AND m_check.tools_id LIKE @tools_id")
            sb.AppendLine(" AND m_tools.tools_no LIKE @tools_no")
        End If
        If dicRequirement.Item("classify") <> String.Empty Then
            'sb.AppendLine(" AND m_check.classify_cd = @classify_cd")
            sb.AppendLine(" AND m_classify.classify_name LIKE @classify_name")
        End If
        If dicRequirement.Item("type") <> String.Empty Then
            sb.AppendLine(" AND m_check.type_cd IN (" & dicRequirement.Item("type").ToString & ")")
        End If
        If dicRequirement.Item("department") <> String.Empty Then
            sb.AppendLine(" AND m_check.department_cd IN (" & dicRequirement.Item("department").ToString & ")")
        End If
        If dicRequirement.Item("kind") <> String.Empty Then
            sb.AppendLine(" AND m_check.kind LIKE @kind")
        End If
        If dicRequirement.Item("chkPosition") <> String.Empty Then
            sb.AppendLine(" AND m_check.check_position LIKE @check_position")
        End If
        If dicRequirement.Item("chkItem") <> String.Empty Then
            sb.AppendLine(" AND m_check.check_item LIKE @check_item")
        End If
        If dicRequirement.Item("BMType") <> String.Empty Then
            'sb.AppendLine(" AND m_check.benchmark_type LIKE @benchmark_type")
            sb.AppendLine(" AND m_check.benchmark_type LIKE '%" & dicRequirement.Item("BMType") & "%'")
        End If
        If dicRequirement.Item("BMValue1") <> String.Empty Then
            sb.AppendLine(" AND m_check.benchmark_value1 LIKE @benchmark_value1")
        End If
        If dicRequirement.Item("BMValue2") <> String.Empty Then
            sb.AppendLine(" AND m_check.benchmark_value2 LIKE @benchmark_value2")
        End If
        If dicRequirement.Item("BMValue3") <> String.Empty Then
            sb.AppendLine(" AND m_check.benchmark_value3 LIKE @benchmark_value3")
        End If
        If dicRequirement.Item("chkWay") <> String.Empty Then
            sb.AppendLine(" AND m_check.check_way LIKE @check_way")
        End If
        'If dicRequirement.Item("chkTimes") <> String.Empty Then
        '    sb.AppendLine(" AND m_check.check_times = @check_times")
        'End If
        If dicRequirement.Item("imgId") <> String.Empty Then
            'sb.AppendLine(" AND m_picture.id LIKE @img_id")
            sb.AppendLine(" AND m_picture.id LIKE '%" & dicRequirement.Item("imgId") & "%'")
        End If
        sb.AppendLine(" AND m_check.delete_flg = @delete_flg")


        'sb.AppendLine(" ORDER BY m_check.id ")

        sb.AppendLine(" ) tbl ")

        If pageIdx > 0 Then
            sb.AppendLine(" WHERE rowIdx between " & ((pageIdx - 1) * 50000 + 1) & " AND  " & ((pageIdx) * 50000))
        Else
            sb.AppendLine(" WHERE 1=1 ")
        End If

        'パラメータ設定
        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)




        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn_kind", SqlDbType.Char, 4, "0001"))
        paramList.Add(MakeParam("@mei_kbn_type", SqlDbType.Char, 4, "0002"))
        paramList.Add(MakeParam("@mei_kbn_department", SqlDbType.Char, 4, "0004"))


        If dicRequirement.Item("goodsCd") <> String.Empty Then
            paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 32, "%" & dicRequirement.Item("goodsCd") & "%"))
        End If
        If dicRequirement.Item("goodsName") <> String.Empty Then
            paramList.Add(MakeParam("@goods_name", SqlDbType.NVarChar, 102, "%" & dicRequirement.Item("goodsName") & "%"))
        End If
        'If kindCd <> String.Empty Then
        '    paramList.Add(MakeParam("@kind_cd", SqlDbType.Char, 3, kindCd))
        'End If
        If dicRequirement.Item("toolNo") <> String.Empty Then
            'paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, "%" & dicRequirement.Item("toolNo") & "%"))
            paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 32, "%" & dicRequirement.Item("toolNo") & "%"))
        End If
        If dicRequirement.Item("classify") <> String.Empty Then
            paramList.Add(MakeParam("@classify_name", SqlDbType.VarChar, 102, "%" & dicRequirement.Item("classify") & "%"))
        End If
        'If type <> String.Empty Then
        '    paramList.Add(MakeParam("@type_cd", SqlDbType.Char, 8, type))
        'End If
        If dicRequirement.Item("kind") <> String.Empty Then
            paramList.Add(MakeParam("@kind", SqlDbType.VarChar, 102, "%" & dicRequirement.Item("kind") & "%"))
        End If
        If dicRequirement.Item("chkPosition") <> String.Empty Then
            paramList.Add(MakeParam("@check_position", SqlDbType.VarChar, 102, "%" & dicRequirement.Item("chkPosition") & "%"))
        End If
        If dicRequirement.Item("chkItem") <> String.Empty Then
            paramList.Add(MakeParam("@check_item", SqlDbType.NVarChar, 502, "%" & dicRequirement.Item("chkItem") & "%"))
        End If
        'If dicRequirement.Item("BMType") <> String.Empty Then
        '    paramList.Add(MakeParam("@benchmark_type", SqlDbType.Char, 2, "%" & dicRequirement.Item("BMType") & "%"))
        'End If
        If dicRequirement.Item("BMValue1") <> String.Empty Then
            paramList.Add(MakeParam("@benchmark_value1", SqlDbType.VarChar, 22, "%" & dicRequirement.Item("BMValue1") & "%"))
        End If
        If dicRequirement.Item("BMValue2") <> String.Empty Then
            paramList.Add(MakeParam("@benchmark_value2", SqlDbType.VarChar, 22, "%" & dicRequirement.Item("BMValue2") & "%"))
        End If
        If dicRequirement.Item("BMValue3") <> String.Empty Then
            paramList.Add(MakeParam("@benchmark_value3", SqlDbType.VarChar, 22, "%" & dicRequirement.Item("BMValue3") & "%"))
        End If
        If dicRequirement.Item("chkWay") <> String.Empty Then
            paramList.Add(MakeParam("@check_way", SqlDbType.VarChar, 52, "%" & dicRequirement.Item("chkWay") & "%"))
        End If
        'If dicRequirement.Item("chkTimes") <> String.Empty Then
        '    paramList.Add(MakeParam("@check_times", SqlDbType.VarChar, 2, dicRequirement.Item("chkTimes")))
        'End If
        'If dicRequirement.Item("imgId") <> String.Empty Then
        '    paramList.Add(MakeParam("@img_id", SqlDbType.Char, 9, "%" & dicRequirement.Item("imgId") & "%"))
        'End If

        '更新の実行
        'Dim PersonalDbTransactionScopeAction As New PersonalDataAccess.PersonalDbTransactionScopeAction(False)
        'PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
        'PersonalDbTransactionScopeAction.CloseCommit()

        'sb.AppendLine("Select * from #m_check_info")
        '検索の実行
        Dim tableName As String = "m_check"
        Dim PDB As New PersonalDataAccess.PersonalDbTransactionScopeAction(False)
        PDB.FillDataset(CommandType.Text, sb.ToString, ds, tableName, paramList.ToArray)
        PDB.CloseConn(PDB.conn)
        'm_check_info






        'Dim PersonFillDataset As New PersonalDataAccess.PersonFillDataset

        'PersonFillDataset.FillDataset(CommandType.Text, "Select * from ##aaa", ds, tableName, paramList.ToArray)

        '検索の実行
        'Dim tableName As String = "m_check"
        'FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 区分表名称取得
    ''' </summary>
    ''' <param name="meiKbn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKbn(ByVal meiKbn As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, meiKbn)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" mei_cd")
        sb.AppendLine(" ,mei")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = @mei_kbn ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, meiKbn))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 分类表情报取得
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMClassify(ByVal id As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id ")
        sb.AppendLine(" FROM m_classify WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE id = @id ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@id", SqlDbType.Char, 8, id))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "table"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

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
    ''' 检查项目表更新
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="updPara"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMCheck(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal id As String, _
                                 ByVal updPara As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, updPara)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_check WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        If updPara.ContainsKey(TOOLNO_TEXT) Then
            sb.AppendLine("	 tools_id = @tools_id, ")
        End If
        If updPara.ContainsKey(TOOLDISP_TEXT) Then
            sb.AppendLine("	 tools_order = @tools_order, ")
        End If
        If updPara.ContainsKey(CLASSIFYDISP_TEXT) Then
            sb.AppendLine("	 classify_order = @classify_order, ")
        End If
        If updPara.ContainsKey(DEPARTMENT_TEXT) Then
            sb.AppendLine("	 department_cd = @department_cd, ")
        End If
        If updPara.ContainsKey(GOODSKIND_TEXT) Then
            sb.AppendLine("	 kind = @kind, ")
        End If
        If updPara.ContainsKey(CHKPOSITION_TEXT) Then
            sb.AppendLine("	 check_position = @check_position, ")
        End If
        If updPara.ContainsKey(CHKITEM_TEXT) Then
            sb.AppendLine("	 check_item = @check_item, ")
        End If
        If updPara.ContainsKey(BMTYPE_TEXT) Then
            sb.AppendLine("	 benchmark_type = @benchmark_type, ")
        End If
        If updPara.ContainsKey(BMVALUE1_TEXT) Then
            sb.AppendLine("	 benchmark_value1 = @benchmark_value1, ")
        End If
        If updPara.ContainsKey(BMVALUE2_TEXT) Then
            sb.AppendLine("	 benchmark_value2 = @benchmark_value2, ")
        End If
        If updPara.ContainsKey(BMVALUE3_TEXT) Then
            sb.AppendLine("	 benchmark_value3 = @benchmark_value3, ")
        End If
        If updPara.ContainsKey(CHKWAY_TEXT) Then
            sb.AppendLine("	 check_way = @check_way, ")
        End If
        If updPara.ContainsKey(CHKTIMES_TEXT) Then
            sb.AppendLine("	 check_times = @check_times, ")
        End If
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        If updPara.ContainsKey(TOOLNO_TEXT) Then
            paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, updPara(TOOLNO_TEXT)))
        End If
        If updPara.ContainsKey(TOOLDISP_TEXT) Then
            paramList.Add(MakeParam("@tools_order", SqlDbType.Char, 3, updPara(TOOLDISP_TEXT)))
        End If
        If updPara.ContainsKey(CLASSIFYDISP_TEXT) Then
            paramList.Add(MakeParam("@classify_order", SqlDbType.Char, 3, updPara(CLASSIFYDISP_TEXT)))
        End If
        If updPara.ContainsKey(DEPARTMENT_TEXT) Then
            paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, updPara(DEPARTMENT_TEXT)))
        End If
        If updPara.ContainsKey(GOODSKIND_TEXT) Then
            paramList.Add(MakeParam("@kind", SqlDbType.VarChar, 100, updPara(GOODSKIND_TEXT)))
        End If
        If updPara.ContainsKey(CHKPOSITION_TEXT) Then
            paramList.Add(MakeParam("@check_position", SqlDbType.VarChar, 100, updPara(CHKPOSITION_TEXT)))
        End If
        If updPara.ContainsKey(CHKITEM_TEXT) Then
            paramList.Add(MakeParam("@check_item", SqlDbType.NVarChar, 500, updPara(CHKITEM_TEXT)))
        End If
        If updPara.ContainsKey(BMTYPE_TEXT) Then
            paramList.Add(MakeParam("@benchmark_type", SqlDbType.VarChar, 4, updPara(BMTYPE_TEXT)))
        End If
        If updPara.ContainsKey(BMVALUE1_TEXT) Then
            paramList.Add(MakeParam("@benchmark_value1", SqlDbType.VarChar, 20, updPara(BMVALUE1_TEXT)))
        End If
        If updPara.ContainsKey(BMVALUE2_TEXT) Then
            paramList.Add(MakeParam("@benchmark_value2", SqlDbType.VarChar, 20, updPara(BMVALUE2_TEXT)))
        End If
        If updPara.ContainsKey(BMVALUE3_TEXT) Then
            paramList.Add(MakeParam("@benchmark_value3", SqlDbType.VarChar, 20, updPara(BMVALUE3_TEXT)))
        End If
        If updPara.ContainsKey(CHKWAY_TEXT) Then
            paramList.Add(MakeParam("@check_way", SqlDbType.VarChar, 50, updPara(CHKWAY_TEXT)))
        End If
        If updPara.ContainsKey(CHKTIMES_TEXT) Then
            paramList.Add(MakeParam("@check_times", SqlDbType.VarChar, 2, updPara(CHKTIMES_TEXT)))
        End If

        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, updPara(USER_TEXT)))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 9, id))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 商品表更新
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="updPara"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMGoods(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
                                    ByVal id As String, _
                                 ByVal updPara As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, updPara)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_goods WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        If updPara.ContainsKey(GOODSNAME_TEXT) Then
            sb.AppendLine("	 goods_name = @goods_name, ")
        End If
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        If updPara.ContainsKey(GOODSNAME_TEXT) Then
            paramList.Add(MakeParam("@goods_name", SqlDbType.NVarChar, 100, updPara(GOODSNAME_TEXT)))
        End If
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, updPara(USER_TEXT)))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, id))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 分类表更新
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="updPara"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMClassify(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal id As String, _
                                 ByVal updPara As Dictionary(Of String, String)) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, updPara)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_classify WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        If updPara.ContainsKey(DEPARTMENT_TEXT) Then
            sb.AppendLine("	 department_cd = @department_cd, ")
        End If
        If updPara.ContainsKey(TOOLNO_TEXT) Then
            sb.AppendLine("	 tools_id = @tools_id, ")
        End If
        If updPara.ContainsKey(CLASSIFY_TEXT) Then
            sb.AppendLine("	 classify_name = @classify_name, ")
        End If
        If updPara.ContainsKey(IMGID_TEXT) Then
            sb.AppendLine("	 picture_id = @picture_id, ")
        End If
        If updPara.ContainsKey(CLASSIFYDISP_TEXT) Then
            sb.AppendLine("	 disp_no = @disp_no, ")
        End If
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        If updPara.ContainsKey(DEPARTMENT_TEXT) Then
            paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, updPara(DEPARTMENT_TEXT)))
        End If
        If updPara.ContainsKey(TOOLNO_TEXT) Then
            paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, updPara(TOOLNO_TEXT)))
        End If
        If updPara.ContainsKey(CLASSIFY_TEXT) Then
            paramList.Add(MakeParam("@classify_name", SqlDbType.VarChar, 100, updPara(CLASSIFY_TEXT)))
        End If
        If updPara.ContainsKey(IMGID_TEXT) Then
            paramList.Add(MakeParam("@picture_id", SqlDbType.VarChar, 8, updPara(IMGID_TEXT)))
        End If
        If updPara.ContainsKey(CLASSIFYDISP_TEXT) Then
            paramList.Add(MakeParam("@disp_no", SqlDbType.Char, 3, updPara(CLASSIFYDISP_TEXT)))
        End If
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, updPara(USER_TEXT)))
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 8, id))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 检查表插入
    ''' </summary>
    ''' <param name="dicInsert"></param>
    ''' <param name="strCheckId"></param>
    ''' <param name="strClassifyId"></param>
    ''' <param name="strGoodsId"></param>
    ''' <param name="strKindCd"></param>
    ''' <param name="strTypeCd"></param>
    ''' <param name="strDepartmentCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertCheckMs(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
                                    ByVal dicInsert As Dictionary(Of String, String), _
                                  ByVal strCheckId As String, _
                                  ByVal strClassifyId As String, _
                                  ByVal strGoodsId As String, _
                                  ByVal strKindCd As String, _
                                  ByVal strTypeCd As String, _
                                  ByVal strDepartmentCd As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicInsert, _
                                                                                  strCheckId, _
                                                                                  strClassifyId, _
                                                                                  strGoodsId, _
                                                                                  strKindCd, _
                                                                                  strTypeCd, _
                                                                                  strDepartmentCd)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("	 m_check(")
        sb.AppendLine("  id ")
        sb.AppendLine(" ,goods_id ")
        sb.AppendLine(" ,kind_cd ")
        sb.AppendLine(" ,tools_id ")
        sb.AppendLine(" ,tools_order ")
        sb.AppendLine(" ,classify_id ")
        sb.AppendLine(" ,classify_order ")
        sb.AppendLine(" ,type_cd ")
        sb.AppendLine(" ,department_cd ")
        sb.AppendLine(" ,kind ")
        sb.AppendLine(" ,check_position ")
        sb.AppendLine(" ,check_item ")
        sb.AppendLine(" ,benchmark_type ")
        sb.AppendLine(" ,benchmark_value1 ")
        sb.AppendLine(" ,benchmark_value2 ")
        sb.AppendLine(" ,benchmark_value3 ")
        sb.AppendLine(" ,check_way ")
        sb.AppendLine(" ,check_times ")
        sb.AppendLine(" ,delete_flg ")
        sb.AppendLine(" ,insert_user ")
        sb.AppendLine(" ,insert_date ")
        sb.AppendLine(" ,update_user ")
        sb.AppendLine(" ,update_date ) ")
        sb.AppendLine("	  VALUES(")
        sb.AppendLine("  @id ")
        sb.AppendLine(" ,@goods_id ")
        sb.AppendLine(" ,@kind_cd ")
        sb.AppendLine(" ,@tools_id ")
        sb.AppendLine(" ,@tools_order ")
        sb.AppendLine(" ,@classify_id ")
        sb.AppendLine(" ,@classify_order ")
        sb.AppendLine(" ,@type_cd ")
        sb.AppendLine(" ,@department_cd ")
        sb.AppendLine(" ,@kind ")
        sb.AppendLine(" ,@check_position ")
        sb.AppendLine(" ,@check_item ")
        sb.AppendLine(" ,@benchmark_type ")
        sb.AppendLine(" ,@benchmark_value1 ")
        sb.AppendLine(" ,@benchmark_value2 ")
        sb.AppendLine(" ,@benchmark_value3 ")
        sb.AppendLine(" ,@check_way ")
        sb.AppendLine(" ,@check_times ")
        sb.AppendLine(" ,@delete_flg ")
        sb.AppendLine(" ,@insert_user ")
        sb.AppendLine(" ,GETDATE() ")
        sb.AppendLine(" ,@update_user ")
        sb.AppendLine(" ,GETDATE() ) ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 9, strCheckId))
        paramList.Add(MakeParam("@goods_id", SqlDbType.Char, 7, strGoodsId))
        paramList.Add(MakeParam("@kind_cd", SqlDbType.Char, 3, strKindCd))
        paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, dicInsert(TOOLNO_TEXT)))
        paramList.Add(MakeParam("@tools_order", SqlDbType.Char, 3, dicInsert(TOOLDISP_TEXT)))
        paramList.Add(MakeParam("@classify_id", SqlDbType.Char, 8, strClassifyId))
        paramList.Add(MakeParam("@classify_order", SqlDbType.Char, 3, dicInsert(CLASSIFYDISP_TEXT)))
        paramList.Add(MakeParam("@type_cd", SqlDbType.Char, 3, strTypeCd))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, strDepartmentCd))
        paramList.Add(MakeParam("@kind", SqlDbType.VarChar, 100, dicInsert(GOODSKIND_TEXT)))
        paramList.Add(MakeParam("@check_position", SqlDbType.VarChar, 100, dicInsert(CHKPOSITION_TEXT)))
        paramList.Add(MakeParam("@check_item", SqlDbType.NVarChar, 500, dicInsert(CHKITEM_TEXT)))
        paramList.Add(MakeParam("@benchmark_type", SqlDbType.VarChar, 4, dicInsert(BMTYPE_TEXT)))
        paramList.Add(MakeParam("@benchmark_value1", SqlDbType.VarChar, 20, dicInsert(BMVALUE1_TEXT)))
        paramList.Add(MakeParam("@benchmark_value2", SqlDbType.VarChar, 20, dicInsert(BMVALUE2_TEXT)))
        paramList.Add(MakeParam("@benchmark_value3", SqlDbType.VarChar, 20, dicInsert(BMVALUE3_TEXT)))
        paramList.Add(MakeParam("@check_way", SqlDbType.VarChar, 50, dicInsert(CHKWAY_TEXT)))
        paramList.Add(MakeParam("@check_times", SqlDbType.VarChar, 2, dicInsert(CHKTIMES_TEXT)))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 分类表插入
    ''' </summary>
    ''' <param name="dicInsert"></param>
    ''' <param name="strClassifyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertClassifyMs(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal dicInsert As Dictionary(Of String, String), _
                                     ByVal strClassifyId As String, _
                                     ByVal strGoodsId As String, _
                                     ByVal strKindCd As String, _
                                     ByVal strTypeCd As String, _
                                     ByVal strDepartmentCd As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicInsert, _
                                                                                  strClassifyId, _
                                                                                  strGoodsId, _
                                                                                  strKindCd, _
                                                                                  strTypeCd, _
                                                                                  strDepartmentCd)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("	 m_classify(")
        sb.AppendLine("  id ")
        sb.AppendLine(" ,goods_id ")
        sb.AppendLine(" ,kind_cd ")
        sb.AppendLine(" ,department_cd ")
        sb.AppendLine(" ,tools_id ")
        sb.AppendLine(" ,classify_name ")
        sb.AppendLine(" ,picture_id ")
        sb.AppendLine(" ,disp_no ")
        sb.AppendLine(" ,delete_flg ")
        sb.AppendLine(" ,insert_user ")
        sb.AppendLine(" ,insert_date ")
        sb.AppendLine(" ,update_user ")
        sb.AppendLine(" ,update_date ) ")
        sb.AppendLine("	  VALUES(")
        sb.AppendLine("  @id ")
        sb.AppendLine(" ,@goods_id ")
        sb.AppendLine(" ,@kind_cd ")
        sb.AppendLine(" ,@department_cd ")
        sb.AppendLine(" ,@tools_id ")
        sb.AppendLine(" ,@classify_name ")
        sb.AppendLine(" ,@picture_id ")
        sb.AppendLine(" ,@disp_no ")
        sb.AppendLine(" ,@delete_flg ")
        sb.AppendLine(" ,@insert_user ")
        sb.AppendLine(" ,GETDATE() ")
        sb.AppendLine(" ,@update_user ")
        sb.AppendLine(" ,GETDATE() ) ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 8, strClassifyId))
        paramList.Add(MakeParam("@goods_id", SqlDbType.Char, 7, strGoodsId))
        paramList.Add(MakeParam("@kind_cd", SqlDbType.Char, 3, strKindCd))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, strDepartmentCd))
        paramList.Add(MakeParam("@tools_id", SqlDbType.VarChar, 7, dicInsert(TOOLNO_TEXT)))
        paramList.Add(MakeParam("@classify_name", SqlDbType.VarChar, 100, dicInsert(CLASSIFY_TEXT)))
        paramList.Add(MakeParam("@picture_id", SqlDbType.VarChar, 7, dicInsert(IMGID_TEXT)))
        paramList.Add(MakeParam("@disp_no", SqlDbType.VarChar, 3, dicInsert(CLASSIFYDISP_TEXT)))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 商品表插入
    ''' </summary>
    ''' <param name="dicInsert"></param>
    ''' <param name="strGoodsId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertGoodsMs(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal dicInsert As Dictionary(Of String, String), _
                                     ByVal strGoodsId As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicInsert, strGoodsId)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("	 m_goods(")
        sb.AppendLine("  id ")
        sb.AppendLine(" ,goods_cd ")
        sb.AppendLine(" ,goods_name ")
        sb.AppendLine(" ,delete_flg ")
        sb.AppendLine(" ,insert_user ")
        sb.AppendLine(" ,insert_date ")
        sb.AppendLine(" ,update_user ")
        sb.AppendLine(" ,update_date ) ")
        sb.AppendLine("	  VALUES(")
        sb.AppendLine("  @id ")
        sb.AppendLine(" ,@goods_cd ")
        sb.AppendLine(" ,@goods_name ")
        sb.AppendLine(" ,@delete_flg ")
        sb.AppendLine(" ,@insert_user ")
        sb.AppendLine(" ,GETDATE() ")
        sb.AppendLine(" ,@update_user ")
        sb.AppendLine(" ,GETDATE() ) ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, strGoodsId))
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 30, dicInsert(GOODSCD_TEXT)))
        paramList.Add(MakeParam("@goods_name", SqlDbType.NVarChar, 100, dicInsert(GOODSNAME_TEXT)))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@insert_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 商品ID取得
    ''' </summary>
    ''' <param name="goodsCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGoodId(ByVal goodsCd As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, goodsCd)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,goods_name")
        sb.AppendLine(" FROM m_goods WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE goods_cd = @goods_cd ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 30, goodsCd))

        '検索の実行
        Dim tableName As String = "m_goods"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 分类信息取得
    ''' </summary>
    ''' <param name="goodsID"></param>
    ''' <param name="kindCd"></param>
    ''' <param name="departmentCd"></param>
    ''' <param name="toolsId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetClassify(ByVal goodsID As String, _
                                ByVal kindCd As String, _
                                ByVal departmentCd As String, _
                                ByVal toolsId As String, _
                                ByVal classifyName As String, _
                                ByVal pictureId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, goodsID, _
                                                                                  kindCd, _
                                                                                  departmentCd, _
                                                                                  toolsId, _
                                                                                  classifyName, _
                                                                                  pictureId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,classify_name")
        sb.AppendLine(" ,picture_id")
        sb.AppendLine(" ,disp_no")
        sb.AppendLine(" FROM m_classify WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE goods_id = @goods_id ")
        sb.AppendLine(" AND kind_cd = @kind_cd ")
        sb.AppendLine(" AND department_cd = @department_cd ")
        sb.AppendLine(" AND tools_id = @tools_id ")
        sb.AppendLine(" AND classify_name = @classify_name ")
        sb.AppendLine(" AND picture_id = @picture_id ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@goods_id", SqlDbType.VarChar, 7, goodsID))
        paramList.Add(MakeParam("@kind_cd", SqlDbType.VarChar, 3, kindCd))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, departmentCd))
        paramList.Add(MakeParam("@tools_id", SqlDbType.VarChar, 7, toolsId))
        paramList.Add(MakeParam("@classify_name", SqlDbType.VarChar, 100, classifyName))
        paramList.Add(MakeParam("@picture_id", SqlDbType.VarChar, 8, pictureId))

        '検索の実行
        Dim tableName As String = "m_classify"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 区分表名称存在判断
    ''' </summary>
    ''' <param name="mei"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKbnMei(ByVal meiKbn As String, ByVal mei As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, meiKbn, mei)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" mei_cd")
        sb.AppendLine(" ,mei")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = @mei_kbn ")
        sb.AppendLine(" AND mei = @mei ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, meiKbn))
        paramList.Add(MakeParam("@mei", SqlDbType.VarChar, 50, mei))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 区分表に部門コード存在判断
    ''' </summary>
    ''' <param name="meiCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBumenCd(ByVal meiKbn As String, ByVal meiCd As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, meiKbn, meiCd)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" mei_cd")
        sb.AppendLine(" ,mei")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = @mei_kbn ")
        sb.AppendLine(" AND mei_cd = @mei_cd ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, meiKbn))
        paramList.Add(MakeParam("@mei_cd", SqlDbType.Char, 3, meiCd))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function


    Public Function GetBumenAll0004Cd() As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" mei_cd")
        sb.AppendLine(" ,mei")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = '0004' ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)

    End Function

    Public Function GetBumenAll0001Cd() As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" mei_cd")
        sb.AppendLine(" ,mei")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = '0001' ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)

    End Function
    ''' <summary>
    ''' 区分CD最大值取得
    ''' </summary>
    ''' <param name="meiKbn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMaxKbnCd(ByVal meiKbn As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, meiKbn)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" MAX(mei_cd)")
        sb.AppendLine(" FROM m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mei_kbn = @mei_kbn ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, meiKbn))

        '検索の実行
        Dim tableName As String = "m_kbn"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 区分表名称插入
    ''' </summary>
    ''' <param name="meiKbn"></param>
    ''' <param name="meiCd"></param>
    ''' <param name="mei"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertKbn(ByVal meiKbn As String, ByVal meiCd As String, ByVal mei As String, ByVal strUser As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, meiKbn, meiCd, mei)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" INSERT INTO ")
        sb.AppendLine("	 m_kbn(")
        sb.AppendLine("  mei_kbn ")
        sb.AppendLine(" ,mei_cd ")
        sb.AppendLine(" ,mei ")
        sb.AppendLine(" ,delete_flg ")
        sb.AppendLine(" ,update_user ")
        sb.AppendLine(" ,update_date ) ")
        sb.AppendLine("	  VALUES(")
        sb.AppendLine("  @mei_kbn ")
        sb.AppendLine(" ,@mei_cd ")
        sb.AppendLine(" ,@mei ")
        sb.AppendLine(" ,@delete_flg ")
        sb.AppendLine(" ,@update_user ")
        sb.AppendLine(" ,GETDATE() ) ")

        'パラメータ設定
        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, meiKbn))
        paramList.Add(MakeParam("@mei_cd", SqlDbType.Char, 3, meiCd))
        paramList.Add(MakeParam("@mei", SqlDbType.VarChar, 50, mei))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, strUser))

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function

    ''' <summary>
    ''' 治具编号存在检查用治具信息取得
    ''' </summary>
    ''' <param name="toolNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTool(ByVal toolNo As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, toolNo)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,tools_no")
        sb.AppendLine(" ,department_cd")
        sb.AppendLine(" FROM m_tools WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE tools_no = @tools_no ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@tools_no", SqlDbType.VarChar, 30, toolNo))

        '検索の実行
        Dim tableName As String = "m_tools"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 治具编号存在检查用治具信息取得
    ''' </summary>
    ''' <param name="toolId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetToolId(ByVal toolId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, toolId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,tools_no")
        sb.AppendLine(" ,department_cd")
        sb.AppendLine(" FROM m_tools WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE id = @id ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, toolId))

        '検索の実行
        Dim tableName As String = "m_tools"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 图片ID存在检查用图片信息取得
    ''' </summary>
    ''' <param name="imgId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPicture(ByVal imgId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, imgId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,department_cd")
        sb.AppendLine(" ,picture_name")
        sb.AppendLine(" FROM m_picture WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE id = @id ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, imgId))

        '検索の実行
        Dim tableName As String = "m_picture"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 图片内容取得
    ''' </summary>
    ''' <param name="imgId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPictureContent(ByVal imgId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, imgId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" id")
        sb.AppendLine(" ,picture_content")
        sb.AppendLine(" FROM m_picture WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE id = @id ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 7, imgId))

        '検索の実行
        Dim tableName As String = "m_picture"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ''' <summary>
    ''' 检查表删除
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteMCheck(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal id As String, ByVal userId As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, userId)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_check WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 delete_flg = @delete_flg, ")
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, DELETED))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, userId))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 9, id))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 商品表删除
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteMGoods(ByVal id As String, ByVal userId As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, userId)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_goods WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 delete_flg = @delete_flg, ")
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, DELETED))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, userId))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 7, id))

        '更新の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 分类表删除
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteMClassify(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal id As String, ByVal userId As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, id, userId)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_classify WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 delete_flg = @delete_flg, ")
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, DELETED))
        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, userId))
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 8, id))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 检查表批量更新
    ''' </summary>
    ''' <param name="dicInsert"></param>
    ''' <param name="classifyId"></param>
    ''' <param name="goodsId"></param>
    ''' <param name="strKindCd"></param>
    ''' <param name="strTypeCd"></param>
    ''' <param name="strDepartmentCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateCheckMs(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal dicInsert As Dictionary(Of String, String), _
                                  ByVal classifyId As String, _
                                  ByVal goodsId As String, _
                                  ByVal strKindCd As String, _
                                  ByVal strTypeCd As String, _
                                  ByVal strDepartmentCd As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, dicInsert, classifyId, goodsId)

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" UPDATE  ")
        sb.AppendLine("	 m_check WITH (UPDLOCK) ")
        sb.AppendLine("	SET ")
        sb.AppendLine("	 goods_id = @goods_id, ")
        sb.AppendLine("	 kind_cd = @kind_cd, ")
        sb.AppendLine("	 tools_id = @tools_id, ")
        sb.AppendLine("	tools_order = @tools_order,")
        sb.AppendLine("	classify_id = @classify_id,")
        sb.AppendLine("	classify_order = @classify_order,")
        sb.AppendLine("	type_cd = @type_cd,")
        sb.AppendLine("	department_cd = @department_cd,")
        sb.AppendLine("	kind = @kind,")
        sb.AppendLine("	check_position = @check_position,")
        sb.AppendLine("	check_item = @check_item,")
        sb.AppendLine("	benchmark_type = @benchmark_type,")
        sb.AppendLine("	benchmark_value1 = @benchmark_value1,")
        sb.AppendLine("	benchmark_value2 = @benchmark_value2,")
        sb.AppendLine("	benchmark_value3 = @benchmark_value3,")
        sb.AppendLine("	check_way = @check_way,")
        sb.AppendLine("	check_times = @check_times,")
        sb.AppendLine("	 update_user = @update_user, ")
        sb.AppendLine("	 update_date = GETDATE() ")
        sb.AppendLine("	 WHERE ")
        sb.AppendLine("	 id = @id ")

        'パラメータ設定

        paramList.Add(MakeParam("@goods_id", SqlDbType.Char, 7, goodsId))
        paramList.Add(MakeParam("@kind_cd", SqlDbType.Char, 3, strKindCd))
        paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, dicInsert(TOOLNO_TEXT)))
        paramList.Add(MakeParam("@tools_order", SqlDbType.Char, 3, dicInsert(TOOLDISP_TEXT)))
        paramList.Add(MakeParam("@classify_id", SqlDbType.Char, 8, classifyId))
        paramList.Add(MakeParam("@classify_order", SqlDbType.Char, 3, dicInsert(CLASSIFYDISP_TEXT)))
        paramList.Add(MakeParam("@type_cd", SqlDbType.Char, 3, strTypeCd))
        paramList.Add(MakeParam("@department_cd", SqlDbType.Char, 3, strDepartmentCd))
        paramList.Add(MakeParam("@kind", SqlDbType.VarChar, 100, dicInsert(GOODSKIND_TEXT)))
        paramList.Add(MakeParam("@check_position", SqlDbType.VarChar, 100, dicInsert(CHKPOSITION_TEXT)))
        paramList.Add(MakeParam("@check_item", SqlDbType.NVarChar, 500, dicInsert(CHKITEM_TEXT)))
        paramList.Add(MakeParam("@benchmark_type", SqlDbType.VarChar, 4, dicInsert(BMTYPE_TEXT)))
        paramList.Add(MakeParam("@benchmark_value1", SqlDbType.VarChar, 20, dicInsert(BMVALUE1_TEXT)))
        paramList.Add(MakeParam("@benchmark_value2", SqlDbType.VarChar, 20, dicInsert(BMVALUE2_TEXT)))
        paramList.Add(MakeParam("@benchmark_value3", SqlDbType.VarChar, 20, dicInsert(BMVALUE3_TEXT)))
        paramList.Add(MakeParam("@check_way", SqlDbType.VarChar, 50, dicInsert(CHKWAY_TEXT)))
        paramList.Add(MakeParam("@check_times", SqlDbType.VarChar, 2, dicInsert(CHKTIMES_TEXT)))

        paramList.Add(MakeParam("@update_user", SqlDbType.VarChar, 30, dicInsert(USER_TEXT)))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 9, dicInsert(CHECKID_TEXT)))

        '更新の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result

    End Function

    ''' <summary>
    ''' 检查项目Id存在判断
    ''' </summary>
    ''' <param name="checkId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCheckId(ByVal checkId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, checkId)

        Dim sb As New StringBuilder

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" m_check.id")
        sb.AppendLine(" ,m_goods.goods_cd ")
        sb.AppendLine(" ,m_goods.goods_name ")
        sb.AppendLine(" ,m_department.mei AS department_name ")
        sb.AppendLine(" ,m_kind.mei AS kind_name ")
        sb.AppendLine(" ,m_classify.classify_name ")
        sb.AppendLine(" ,m_check.classify_order")
        sb.AppendLine(" ,m_type.mei AS type_name ")
        sb.AppendLine(" ,m_picture.id AS picture_id")
        sb.AppendLine(" ,m_tools.tools_no")
        sb.AppendLine(" ,m_check.tools_order")
        sb.AppendLine(" ,m_check.kind")
        sb.AppendLine(" ,m_check.check_position")
        sb.AppendLine(" ,m_check.check_item")
        sb.AppendLine(" ,m_check.benchmark_type")
        sb.AppendLine(" ,m_check.benchmark_value1")
        sb.AppendLine(" ,m_check.benchmark_value2")
        sb.AppendLine(" ,m_check.benchmark_value3")
        sb.AppendLine(" ,m_check.check_way")
        sb.AppendLine(" ,m_check.check_times")
        'sb.AppendLine(" ,m_check.goods_id")
        'sb.AppendLine(" ,m_check.kind_cd")
        'sb.AppendLine(" ,m_check.tools_id")
        'sb.AppendLine(" ,m_check.classify_id")
        'sb.AppendLine(" ,m_check.type_cd")
        'sb.AppendLine(" ,m_check.department_cd")
        'sb.AppendLine(" ,m_check.delete_flg")
        'sb.AppendLine(" ,m_department.mei AS department_name ")
        'sb.AppendLine(" ,m_picture.picture_content AS picture")

        sb.AppendLine(" FROM m_check WITH(READCOMMITTED)")
        '分类表
        sb.AppendLine(" LEFT JOIN m_classify WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.classify_id = m_classify.id ")
        sb.AppendLine(" AND m_classify.delete_flg = @delete_flg")
        '商品表
        sb.AppendLine(" LEFT JOIN m_goods WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.goods_id = m_goods.id ")
        sb.AppendLine(" AND m_goods.delete_flg = @delete_flg")
        '治具表
        sb.AppendLine(" LEFT JOIN m_tools WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.tools_id = m_tools.id ")
        sb.AppendLine(" AND m_tools.delete_flg = @delete_flg")
        '种类名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_kind WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.kind_cd = m_kind.mei_cd ")
        sb.AppendLine(" AND m_kind.mei_kbn = @mei_kbn_kind")
        sb.AppendLine(" AND m_kind.delete_flg = @delete_flg")
        '类型名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_type WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.type_cd = m_type.mei_cd ")
        sb.AppendLine(" AND m_type.mei_kbn = @mei_kbn_type")
        sb.AppendLine(" AND m_type.delete_flg = @delete_flg")
        '部门名称取得用
        sb.AppendLine(" LEFT JOIN m_kbn AS m_department WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_check.department_cd = m_department.mei_cd ")
        sb.AppendLine(" AND m_department.mei_kbn = @mei_kbn_department")
        sb.AppendLine(" AND m_department.delete_flg = @delete_flg")
        '图片取得用
        sb.AppendLine(" LEFT JOIN m_picture WITH(READCOMMITTED)")
        sb.AppendLine(" ON m_picture.id = m_classify.picture_id ")
        sb.AppendLine(" AND m_picture.delete_flg = @delete_flg")

        sb.AppendLine(" WHERE m_check.id = @id ")
        sb.AppendLine(" AND m_check.delete_flg = @delete_flg ")

        Dim ds As New DataSet
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        paramList.Add(MakeParam("@mei_kbn_kind", SqlDbType.Char, 4, "0001"))
        paramList.Add(MakeParam("@mei_kbn_type", SqlDbType.Char, 4, "0002"))
        paramList.Add(MakeParam("@mei_kbn_department", SqlDbType.Char, 4, "0004"))
        paramList.Add(MakeParam("@id", SqlDbType.Char, 9, checkId))
        Dim tableName As String = "m_check"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function


End Class
