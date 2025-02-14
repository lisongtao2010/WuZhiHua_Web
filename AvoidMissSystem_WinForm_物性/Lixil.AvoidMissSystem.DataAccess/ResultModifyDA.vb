Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports Lixil.AvoidMissSystem.Utilities

Public Class ResultModifyDA

#Region "数据取得"


    '商品分类列表
    Public Function GetFirstCheck(ByVal cd As String) As String

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine("SELECT tongyong_cd FROM t_first_check where tongyong_cd in (")
        sb.AppendLine("SELECT tongyong_cd FROM t_first_check where good_cd = '" & cd & "')")
        sb.AppendLine("and checked_flg='1'")
        Dim ds As New DataSet
        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "GetFirstCheck", paramList.ToArray)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""
        End If

    End Function

    Public Function Gettongyong_cd(ByVal cd As String) As String

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" SELECT tongyong_cd FROM t_first_check where good_cd = '" & cd & "'")

        Dim ds As New DataSet
        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "GetFirstCheck", paramList.ToArray)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""
        End If

    End Function

    ''' <summary>
    ''' 非管理员部门取得
    ''' </summary>
    ''' <param name="strUserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDepartment(ByVal strUserID As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strUserID)
        Dim paramList As New List(Of SqlParameter)
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
        paramList.Add(MakeParam("@user_id", SqlDbType.BigInt, 18, strUserID))

        '検索の実行
        Dim tableName As String = "Department"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function


    Public Function UpdFirstCheck(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal tongyong_cd As String) As Integer
            Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_first_check ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" checked_flg='1' ")

        sb.AppendLine(" WHERE ")
        sb.AppendLine(" tongyong_cd = '" & tongyong_cd & "' ")

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
        Return result

    End Function


    'Public Function UpdFirstCheck(ByVal tongyong_cd As String) As Integer


    '    Dim sb As New StringBuilder
    '    Dim paramList As New List(Of SqlParameter)
    '    sb.AppendLine(" UPDATE ")
    '    sb.AppendLine(" t_first_check ")
    '    sb.AppendLine(" SET ")
    '    sb.AppendLine(" checked_flg='1' ")

    '    sb.AppendLine(" WHERE ")
    '    sb.AppendLine(" tongyong_cd = '" & tongyong_cd & "' ")


    '    '更新の実行
    '    Return ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)


    'End Function



    ''' <summary>
    ''' 管理员部门取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAdminDepartment() As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine("	 mk.mei_cd ")
        sb.AppendLine("	 ,mk.mei ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_kbn mk WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE mk.mei_kbn = @mei_kbn ")

        'パラメータ設定
        Dim ds As New DataSet

        paramList.Add(MakeParam("@mei_kbn", SqlDbType.Char, 4, "0004"))

        '検索の実行
        Dim tableName As String = "Department"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function



    Public Function Deletet_check_result(ByVal id As String) As Boolean

        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_check_result WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" delete_flg = '1' ")
      
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = '" & id & "' ")

        Try
            result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
            Return True
        Catch ex As Exception
            Return False
        End Try
        '挿入の実行
    End Function

    ''' <summary>
    ''' 根据检索条件取得信息
    ''' </summary>
    ''' <param name="hsSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSearchData(ByVal hsSearch As Hashtable) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, hsSearch)
        Dim whereFlg As Integer = 0
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" t_check_result.id  AS 'ID' ")

        sb.AppendLine("      ,t_dlx_chk.[department_cd] AS '部门'")
        sb.AppendLine("      ,t_dlx_chk.[line_name] AS '生产线'")

        sb.AppendLine(" , ISNULL(m_goods.goods_cd, '') AS '商品CD'  ")
        sb.AppendLine(" , t_check_result.make_number AS '商品作番' ")
        '既存表 TB_CompleteData 的信息
        'sb.AppendLine(" , ISNULL(TB_CompleteData.Product_Line, '' ) AS '生产线' ")
        sb.AppendLine(" , ISNULL(TB_CompleteData.ProductionQuantity, 0 ) AS '生产数量' ")
        sb.AppendLine(" , ISNULL(CONVERT(varchar(100),TB_CompleteData.Finish_Date,20 ), '' ) AS '生产实际日' ")
        sb.AppendLine(" , ISNULL(CONVERT(varchar(100),TB_CompleteData.Pay_Date,20), '' ) AS '纳期日' ")
        sb.AppendLine(" , ISNULL(TB_CompleteData.Direction, '' ) AS '方向' ")

        sb.AppendLine(" , ISNULL(m_kbn.mei, '' ) AS '区分' ")
        sb.AppendLine(" , ISNULL(TB_User.UserName, '' ) AS '检查员' ")
        sb.AppendLine(" , CASE t_check_result.continue_chk_flg WHEN '1' THEN '待判' WHEN '2' THEN '继承' WHEN '3' THEN '临时数据' ELSE '完了' END AS '状态' ")
        'sb.AppendLine(" , t_check_result.start_time AS '开始时间' ")
        'sb.AppendLine(" , t_check_result.end_time AS '结束时间' ")
        sb.AppendLine(" ,  CONVERT(varchar(100),t_check_result.start_time ,20)  AS '开始时间' ")
        sb.AppendLine(" ,  CONVERT(varchar(100),t_check_result.end_time ,20)  AS '结束时间' ")

        'sb.AppendLine(" , ISNULL(t_check_result.up_start_time,'') AS '再检开始时间' ")
        'sb.AppendLine(" , ISNULL(t_check_result.up_end_time,'') AS '再检结束时间' ")

        sb.AppendLine(" ,  CONVERT(varchar(100),t_check_result.up_start_time ,20)  AS '再检开始时间' ")
        sb.AppendLine(" ,  CONVERT(varchar(100),t_check_result.up_end_time ,20)  AS '再检结束时间' ")


        sb.AppendLine(" , ISNULL(t_check_result.result, '' ) AS '检查结果' ")
        sb.AppendLine(" , t_check_result.remarks AS '备注' ")
        sb.AppendLine(" , ISNULL(t_check_result.shareResult_id, '' ) AS '继承结果ID' ")
        sb.AppendLine(" , t_check_result.goods_id AS '商品ID' ")
        sb.AppendLine(" , DATEDIFF(ss,t_check_result.start_time,t_check_result.end_time) AS '检查时长(秒)' ")
        sb.AppendLine(" FROM ")
        sb.AppendLine(" t_check_result WITH(READCOMMITTED) ")
        sb.AppendLine(" LEFT JOIN m_goods WITH(READCOMMITTED) ")
        sb.AppendLine(" ON t_check_result.goods_id = m_goods.id ")
        sb.AppendLine(" LEFT JOIN m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_kbn.mei_cd = t_check_result.department_cd ")
        sb.AppendLine(" AND m_kbn.mei_kbn = '0004' ")
        sb.AppendLine(" LEFT JOIN TB_User WITH(READCOMMITTED) ")
        sb.AppendLine(" ON TB_User.UserCode = t_check_result.check_user ")
        sb.AppendLine(" LEFT JOIN TB_CompleteData WITH(READCOMMITTED) ")
        sb.AppendLine(" ON TB_CompleteData.Code = replace(cast(m_goods.goods_cd as varchar(30)),'-','') ")
        sb.AppendLine(" AND TB_CompleteData.MakeNumber = t_check_result.make_number ")
        sb.AppendLine(" LEFT JOIN t_dlx_chk WITH(READCOMMITTED) ")
        sb.AppendLine(" ON t_dlx_chk.id = t_check_result.id ")

        sb.AppendLine(" WHERE ")
        sb.AppendLine(" t_check_result.delete_flg = @delete_flg ")

        If hsSearch("PFromDate").ToString <> "" AndAlso hsSearch("PToDate").ToString <> "" Then
            'sb.AppendLine(" AND CONVERT(varchar(8),TB_CompleteData.Finish_Date ,112) BETWEEN  @PFromDate AND @PToDate ")
            sb.AppendLine(" AND TB_CompleteData.Finish_Date BETWEEN  @PFromDate AND @PToDate ")
            '生产实际日
            'paramList.Add(MakeParam("@PFromDate", SqlDbType.VarChar, 8, String.Format("{0:yyyyMMdd}", hsSearch("PFromDate"))))
            'paramList.Add(MakeParam("@PToDate", SqlDbType.VarChar, 8, String.Format("{0:yyyyMMdd}", hsSearch("PToDate"))))
            hsSearch("PToDate") = CDate(hsSearch("PToDate")).AddDays(1).ToString("yyyy/MM/dd")
            paramList.Add(MakeParam("@PFromDate", SqlDbType.DateTime, 50, CDate(hsSearch("PFromDate")).ToString("yyyy/MM/dd") & " 08:00:00"))
            paramList.Add(MakeParam("@PToDate", SqlDbType.DateTime, 50, CDate(hsSearch("PToDate")).ToString("yyyy/MM/dd") & " 07:59:59"))

        End If

        If hsSearch("CFromDate").ToString <> "" AndAlso hsSearch("CToDate").ToString <> "" Then
            'sb.AppendLine(" AND CONVERT(varchar(8),t_check_result.start_time ,112) BETWEEN  @CFromDate AND @CToDate ")
            sb.AppendLine(" AND t_check_result.start_time BETWEEN  @CFromDate AND @CToDate ")
            '检查实际日
            'paramList.Add(MakeParam("@CFromDate", SqlDbType.VarChar, 8, String.Format("{0:yyyyMMdd}", hsSearch("CFromDate"))))
            'paramList.Add(MakeParam("@CToDate", SqlDbType.VarChar, 8, String.Format("{0:yyyyMMdd}", hsSearch("CToDate"))))
            hsSearch("CToDate") = CDate(hsSearch("CToDate")).AddDays(1).ToString("yyyy/MM/dd")
            paramList.Add(MakeParam("@CFromDate", SqlDbType.DateTime, 50, CDate(hsSearch("CFromDate")).ToString("yyyy/MM/dd") & " 08:00:00"))
            paramList.Add(MakeParam("@CToDate", SqlDbType.DateTime, 50, CDate(hsSearch("CToDate")).ToString("yyyy/MM/dd") & " 07:59:59"))
        End If


        '删除flg
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, Consts.UNDELETED))

        '部门
        If Not hsSearch("Department").ToString.Equals(String.Empty) Then
            sb.AppendLine(" AND isnull(t_dlx_chk.department_cd,t_check_result.department_cd) IN ( " & Convert.ToString(hsSearch("Department")) & " ) ")
            'sb.AppendLine(" AND department_cd = @Department ")
            'paramList.Add(MakeParam("@Department", SqlDbType.Char, 3, Convert.ToString(hsSearch("Department"))))
        End If

        If Not hsSearch("line_name").ToString.Equals(String.Empty) Then
            sb.AppendLine(" AND t_dlx_chk.line_name = N'" & hsSearch("line_name").ToString & "'")
        End If


        '商品code 模糊查询
        If Not hsSearch("GoodsCd").ToString.Equals(String.Empty) Then

            sb.AppendLine(" AND m_goods.goods_cd LIKE @GoodsCd ")
            '因为商品表的中的商品CD为带“-”的,而在生产表中是不带“-”。所以要对商品CD加处理
            paramList.Add(MakeParam("@GoodsCd", SqlDbType.VarChar, 30, Replace(Convert.ToString(hsSearch("GoodsCd")), "-", "")))
        End If

        '商品作番 模糊查询
        If Not hsSearch("MakeNo").ToString.Equals(String.Empty) Then

            sb.AppendLine(" AND make_number LIKE @MakeNo ")
            paramList.Add(MakeParam("@MakeNo", SqlDbType.VarChar, 32, Convert.ToString(hsSearch("MakeNo"))))
        End If

        '日期 
        'If Not hsSearch("Date").ToString.Equals(String.Empty) Then

        '    Dim strdate As String = String.Format("{0:yyyyMMdd}", DirectCast(hsSearch("Date"), Date)) + "%"
        '    sb.AppendLine(" AND t_check_result.id LIKE @Date ")
        '    paramList.Add(MakeParam("@Date", SqlDbType.VarChar, 30, strdate))
        'End If

        '检查结果
        If Not hsSearch("Result").ToString.Equals(String.Empty) Then

            sb.AppendLine(" AND result = @Result ")
            paramList.Add(MakeParam("@Result", SqlDbType.Char, 2, Convert.ToString(hsSearch("Result"))))
        End If

        '检查员code 模糊查询
        If Not hsSearch("ChkUser").ToString.Equals(String.Empty) Then
            'If whereFlg = 0 Then
            '    whereFlg = 1
            '    sb.AppendLine(" WHERE ")
            'End If

            sb.AppendLine(" AND check_user LIKE @ChkUser ")
            paramList.Add(MakeParam("@ChkUser", SqlDbType.VarChar, 32, Convert.ToString(hsSearch("ChkUser"))))
        End If



        '二次量试
        'If Not hsSearch("check_times").ToString.Equals(String.Empty) Then

        '    sb.AppendLine(" AND check_times <> @check_times ")
        '    paramList.Add(MakeParam("@check_times", SqlDbType.VarChar, 30, Convert.ToString(hsSearch("check_times"))))
        'End If
        sb.AppendLine(" ORDER BY t_check_result.id ")
        'パラメータ設定
        Dim ds As New DataSet


        '検索の実行
        Dim tableName As String = "SearchData"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 根据商品ID，检查结果ID取得所有所有信息
    ''' </summary>
    ''' <param name="strGoodsId"></param>
    ''' <param name="strResultId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllDetaileById(ByVal strGoodsId As String, ByVal strResultId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strGoodsId, strResultId)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" m_check.id AS '检查项目ID' ")
        sb.AppendLine(" , m_check.check_times AS '检查次数' ")
        sb.AppendLine(" , ISNULL(m_check.kind, '' ) AS '类别' ")
        sb.AppendLine(" , ISNULL(m_check.check_position, '' ) AS '检查位置' ")
        sb.AppendLine(" , ISNULL(m_check.check_item, '' ) AS '检查项目' ")
        '基准相关
        'sb.AppendLine(" , ISNULL(m_check.benchmark_type, '' ) AS benchmark_type ")
        'sb.AppendLine(" , ISNULL( m_check.benchmark_value1, '' ) AS benchmark_value1 ")
        'sb.AppendLine(" , ISNULL(m_check.benchmark_value2, '' ) AS benchmark_value2 ")
        'sb.AppendLine(" , ISNULL(m_check.benchmark_value3, '' ) AS benchmark_value3 ")
        sb.AppendLine(" , ISNULL(m_check.check_way, '' ) AS '检查方法' ")
        '结果详细
        sb.AppendLine(" , ISNULL(t_result_detail.measure_value1, '' ) AS '实测值1'  ")
        sb.AppendLine(" , ISNULL(t_result_detail.measure_value2 , '' ) AS '实测值2' ")

        If DataAccessManager.Connection.IndexOf("AvoidMiss_Experiment") > 0 Then
            'sb.AppendLine(" , ISNULL(t_result_detail.measure_value3 , '' ) AS '实测值3' ")
            'sb.AppendLine(" , ISNULL(t_result_detail.measure_value4 , '' ) AS '实测值4' ")
            'sb.AppendLine(" , ISNULL(t_result_detail.measure_value5 , '' ) AS '实测值5' ")
            'sb.AppendLine(" , ISNULL(t_result_detail.measure_value6 , '' ) AS '实测值6' ")
            sb.AppendLine(" ,  CASE WHEN ISNULL(t_result_detail.measure_value3 , '' ) = 'NaN' THEN '' ELSE ISNULL(t_result_detail.measure_value3 , '' ) END AS '实测值3' ")
            sb.AppendLine(" ,  CASE WHEN ISNULL(t_result_detail.measure_value3 , '' ) = 'NaN' THEN '' ELSE ISNULL(t_result_detail.measure_value4 , '' ) END AS '实测值4' ")
            sb.AppendLine(" ,  CASE WHEN ISNULL(t_result_detail.measure_value3 , '' ) = 'NaN' THEN '' ELSE ISNULL(t_result_detail.measure_value5 , '' ) END AS '实测值5' ")
            sb.AppendLine(" ,  CASE WHEN ISNULL(t_result_detail.measure_value3 , '' ) = 'NaN' THEN '' ELSE ISNULL(t_result_detail.measure_value6 , '' ) END AS '实测值6' ")

        End If


        sb.AppendLine(" , ISNULL(t_result_detail.picture_id, '' ) AS '图片ID' ")
        sb.AppendLine(" , ISNULL(t_result_detail.result, '' ) AS '判定结果' ")
        sb.AppendLine(" , ISNULL(t_result_detail.remarks, '' ) AS '备注' ")
        sb.AppendLine(" , ISNULL(t_result_detail.dis_no, '1' ) AS '表示顺' ")
        sb.AppendLine(" , ISNULL(t_result_detail.[benchmark_type], '1' ) AS '基准类型' ")
        sb.AppendLine(" , ISNULL(t_result_detail.[benchmark_value1], '1' ) AS '基准值1' ")
        sb.AppendLine(" , ISNULL(t_result_detail.[benchmark_value2], '1' ) AS '基准值2' ")
        sb.AppendLine(" , ISNULL(t_result_detail.[benchmark_value3], '1' ) AS '基准值3' ")

        sb.AppendLine(" FROM ")
        sb.AppendLine(" m_check WITH(READCOMMITTED) ")
        sb.AppendLine(" LEFT JOIN ")
        sb.AppendLine(" t_result_detail WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_check.id = t_result_detail.check_id ")
        sb.AppendLine(" AND t_result_detail.result_id = @result_id ")
        sb.AppendLine(" INNER JOIN ")
        sb.AppendLine(" m_classify WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_check.classify_id = m_classify.id ")
        sb.AppendLine(" AND m_classify.delete_flg = @delete_flg ")
        sb.AppendLine(" WHERE  ")
        sb.AppendLine(" m_check.goods_id = @goods_id ")
        sb.AppendLine(" AND m_check.delete_flg = @delete_flg ")
        sb.AppendLine(" ORDER BY m_check.id ")

        'If hsKeys("All").ToString.Equals(String.Empty) Then
        '    Dim key As String = " AND t_result_detail.result IN ( "
        '    If hsKeys("MD").ToString.Equals("1") Then
        '        key = key + "MD,"
        '    End If
        '    If hsKeys("NG").ToString.Equals("1") Then
        '        key = key + "NG,"
        '    End If
        '    If hsKeys("OK").ToString.Equals("1") Then
        '        key = key + "OK,"
        '    End If
        '    If hsKeys("OW").ToString.Equals("1") Then
        '        key = key + "OW,"
        '    End If
        '    If hsKeys("SD").ToString.Equals("1") Then
        '        key = key + "SD ) "
        '    End If
        '    sb.AppendLine(key)
        'End If



        'パラメータ設定
        paramList.Add(MakeParam("@goods_id", SqlDbType.VarChar, 7, strGoodsId))
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, strResultId))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, Consts.UNDELETED))
        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "DetailInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

    ''' <summary>
    ''' 图片内容取得 
    ''' </summary>
    ''' <param name="strPicId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPictureMsgById(ByVal strPicId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strPicId)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" picture_content ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_picture WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = @picId ")

        paramList.Add(MakeParam("@picId", SqlDbType.Char, 7, strPicId))
        Dim ds As New DataSet
        '検索の実行
        Dim tableName As String = "DetailInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds
    End Function

#End Region

#Region "数据更新"

    ''' <summary>
    ''' 检查结果的修改
    ''' </summary>
    ''' <param name="strId"></param>
    ''' <param name="strResult"></param>
    ''' <param name="strRemake"></param>
    ''' <param name="strUserId"></param>
    ''' <param name="upDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function UpdateResult(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
 ByVal strId As String, ByVal strResult As String, ByVal strRemake As String, ByVal strUserId As String, ByVal upDate As DateTime, ByVal strState As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strId, strResult, strRemake, strUserId, upDate, strState)
        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_check_result WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" result = @result ")
        sb.AppendLine(" , remarks = @remarks ")
        '状态判断
        If strState.Equals("INIT") = False Then
            sb.AppendLine(" , continue_chk_flg = @continue_chk_flg ")
            paramList.Add(MakeParam("@continue_chk_flg", SqlDbType.Char, 1, strState))
        End If
        sb.AppendLine(" , update_user = @strUserId ")
        sb.AppendLine(" , update_date = @upDate ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = @id ")
        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 13, strId))
        paramList.Add(MakeParam("@result", SqlDbType.Char, 2, strResult))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, strRemake))
        paramList.Add(MakeParam("@strUserId", SqlDbType.VarChar, 30, strUserId))
        paramList.Add(MakeParam("@upDate", SqlDbType.DateTime, 23, upDate))

        'paramList.Add(MakeParam("@upDate", SqlDbType.DateTime, 23, upDate))

        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
        Return result

    End Function

#End Region

#Region "数据插入"

    ''' <summary>
    ''' 日志表插入信息
    ''' </summary>
    ''' <param name="strId"></param>
    ''' <param name="strResultId"></param>
    ''' <param name="strUserId"></param>
    ''' <param name="upDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertLog(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
        ByVal strId As String, ByVal strResultId As String, ByVal strUserId As String, ByVal upDate As DateTime) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strId, strResultId, strUserId, upDate)
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
        sb.AppendLine(" @strId ")
        sb.AppendLine(" , '检查结果修正' ")
        sb.AppendLine(" , 'UP' ")
        sb.AppendLine(" , @strUserId ")
        sb.AppendLine(" , @strResultId ")
        sb.AppendLine(" , @DateTime ) ")
        paramList.Add(MakeParam("@strId", SqlDbType.VarChar, 15, strId))
        paramList.Add(MakeParam("@strResultId", SqlDbType.VarChar, 200, strResultId))
        paramList.Add(MakeParam("@strUserId", SqlDbType.VarChar, 30, strUserId))
        paramList.Add(MakeParam("@DateTime", SqlDbType.DateTime, 23, upDate))
        '挿入の実行
        result = PersonalDbTransactionScopeAction.ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
        Return result
    End Function
#End Region

End Class
