Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data


Public Class CheckDA

    Public Const UNDELETED As String = "0"

    ''' <summary>
    ''' 当天该商品code的最新检查结果取得 临时数据以外
    ''' 同批次包括
    ''' </summary>
    ''' <param name="strGoodsCode"></param>
    ''' <param name="strMakeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLastReultInfoFrom_TB_CompleteData(ByVal strGoodsCode As String, ByVal strMakeNo As String) As DataTable


        '因为商品表的中的商品CD为带“-”的,而在生产表中是不带“-”。所以要对商品CD加处理
        Dim strPGoodCd As String = Replace(strGoodsCode, "-", "")
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine("declare @s varchar(30)")
        sb.AppendLine("declare @e varchar(30)")
        sb.AppendLine("declare @p nvarchar(4000)")

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" @s=(SUBSTRING(CONVERT(CHAR(19), Finish_Date, 120),1,10) + ' 08:00:00.000') ")
        sb.AppendLine(" FROM TB_CompleteData WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" Code = @Pgoods_cd ")
        sb.AppendLine(" AND MakeNumber = @MakeNumber  ")


        sb.AppendLine(" SELECT ")
        sb.AppendLine(" @e=(SUBSTRING(CONVERT(CHAR(19), DATEADD(DAY,1,Finish_Date), 120),1,10) + ' 07:59:59.999') ")
        sb.AppendLine(" FROM TB_CompleteData WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" Code = @Pgoods_cd ")
        sb.AppendLine(" AND MakeNumber = @MakeNumber  ")


        sb.AppendLine("SELECT @p=Product_Line")
        sb.AppendLine("FROM TB_CompleteData WITH(READCOMMITTED) ")
        sb.AppendLine("WHERE Code=@Pgoods_cd ")
        sb.AppendLine("AND MakeNumber=@MakeNumber")


        sb.AppendLine(" SELECT ")
        sb.AppendLine(" A.id AS 'ID' ")
        sb.AppendLine(" , B.goods_cd AS '商品CD' ")
        sb.AppendLine(" , A.make_number AS '作番'")
        sb.AppendLine(" , D.Product_Line AS '生产线'")
        sb.AppendLine(" , D.ProductionQuantity AS '数量'")
        sb.AppendLine(" , D.Finish_Date  AS '生产实际日'")
        sb.AppendLine(" , A.result AS '结果' ")
        sb.AppendLine(" , CASE A.continue_chk_flg WHEN '0' THEN '完了' WHEN '1' THEN '待判' WHEN '2' THEN '默认' END AS '状态' ")
        sb.AppendLine(" , C.UserName AS '检查员' ")
        sb.AppendLine(" , A.start_time AS '开始时间' ")
        sb.AppendLine(" , A.end_time AS '结束时间' ")
        sb.AppendLine(" , A.shareResult_id AS '继承结果'")
        sb.AppendLine(" , A.check_user AS '检查员CD'")
        sb.AppendLine(" , A.qianpin_flg ")
        sb.AppendLine("FROM t_check_result AS A  WITH(READCOMMITTED)")
        sb.AppendLine("LEFT JOIN m_goods AS B WITH(READCOMMITTED)")
        sb.AppendLine("ON B.id = A.goods_id")
        sb.AppendLine("AND B.delete_flg = @delete_flg ")
        sb.AppendLine("LEFT JOIN TB_User AS C WITH(READCOMMITTED)  ")
        sb.AppendLine("ON A.check_user = C.UserCode  ")
        sb.AppendLine("LEFT JOIN TB_CompleteData AS D WITH(READCOMMITTED)  ")
        sb.AppendLine("ON A.make_number = D.MakeNumber")
        sb.AppendLine("AND D.Code = @Pgoods_cd")
        sb.AppendLine("WHERE A.delete_flg = @delete_flg ")

        sb.AppendLine("AND (replace(cast(B.goods_cd as varchar(30)),'-',''))")
        sb.AppendLine("IN  (")
        sb.AppendLine("SELECT Code")
        sb.AppendLine("FROM TB_CompleteData WITH(READCOMMITTED)")
        sb.AppendLine("WHERE Product_Line = @p")
        sb.AppendLine("AND Finish_Date BETWEEN @s AND @e")
        sb.AppendLine("AND Code = @Pgoods_cd ")
        sb.AppendLine(" )")
        sb.AppendLine(" AND continue_chk_flg <> 3 ") '临时保存以外的数据
        sb.AppendLine(" AND D.Product_Line = @p ")
        sb.AppendLine(" ORDER BY A.end_time DESC ")

        'パラメータ設定
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 30, strGoodsCode))
        paramList.Add(MakeParam("@Pgoods_cd", SqlDbType.VarChar, 30, strPGoodCd))
        paramList.Add(MakeParam("@MakeNumber", SqlDbType.VarChar, 50, strMakeNo))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "ResultInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)

    End Function

    ''' <summary>
    ''' 从检查结果表中取得当天该商品code的最新检查结果取得 
    ''' </summary>
    ''' <param name="strGoodsCode"></param>
    ''' <param name="strMakeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLastReultInfoFrom_t_check_result(ByVal strGoodsCode As String, ByVal strMakeNo As String, Optional ByVal chk_flg As String = "3") As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strGoodsCode, strMakeNo)

        '因为商品表的中的商品CD为带“-”的,而在生产表中是不带“-”。所以要对商品CD加处理
        Dim strPGoodCd As String = Replace(strGoodsCode, "-", "")
        Dim paramList As New List(Of SqlParameter)

        Dim varname1 As New System.Text.StringBuilder
        varname1.Append("SELECT " & vbCrLf)
        varname1.Append(" A.id AS 'ID' " & vbCrLf)
        varname1.Append(" , B.goods_cd AS '商品CD' " & vbCrLf)
        varname1.Append(" , A.make_number AS '作番' " & vbCrLf)
        varname1.Append(" , A.Product_Line_check AS '生产线' " & vbCrLf)
        varname1.Append(" , A.ProductionQuantity_check AS '数量'")
        varname1.Append(" , A.Finish_Date_check  AS '生产实际日' " & vbCrLf)
        varname1.Append(" , A.result AS '结果' " & vbCrLf)
        varname1.Append(" , CASE A.continue_chk_flg WHEN '0' THEN '完了' WHEN '1' THEN '待判' WHEN '2' THEN '默认' END AS '状态' " & vbCrLf)
        varname1.Append(" , C.UserName AS '检查员' " & vbCrLf)
        varname1.Append(" , A.start_time AS '开始时间' " & vbCrLf)
        varname1.Append(" , A.end_time AS '结束时间' " & vbCrLf)
        varname1.Append(" , A.shareResult_id AS '继承结果' " & vbCrLf)
        varname1.Append(" , A.check_user AS '检查员CD'")
        varname1.Append(" , A.qianpin_flg ")
        varname1.Append("FROM t_check_result AS A  WITH(READCOMMITTED) " & vbCrLf)
        varname1.Append("LEFT JOIN m_goods AS B WITH(READCOMMITTED) " & vbCrLf)
        varname1.Append("ON B.id = A.goods_id " & vbCrLf)
        varname1.Append("AND B.delete_flg = '0' " & vbCrLf)
        varname1.Append("LEFT JOIN TB_User AS C WITH(READCOMMITTED) " & vbCrLf)
        varname1.Append("ON A.check_user = C.UserCode " & vbCrLf)
        varname1.Append(" " & vbCrLf)
        varname1.Append("WHERE A.delete_flg = '0' " & vbCrLf)
        varname1.Append("and B.goods_cd = '" & strGoodsCode & "' " & vbCrLf)
        varname1.Append("and A.make_number = '" & strMakeNo & "' " & vbCrLf)

        If chk_flg = "3" Then
            varname1.Append("AND continue_chk_flg = 3 " & vbCrLf)
        Else
            varname1.Append("AND continue_chk_flg <> 3 " & vbCrLf)
        End If

        varname1.Append("ORDER BY A.end_time DESC")


        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "ResultInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, varname1.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)

    End Function

    '商品分类列表
    Public Function GetGoodKind(ByVal goods_cd As String, ByVal kind_cd As String, ByVal tools_id As String, ByVal classify_id As String) As DataTable

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" SELECT * from v_goods_kind")
        sb.AppendLine(" WHERE goods_cd = @goods_cd ")
        sb.AppendLine(" AND kind_cd = @kind_cd ")
        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 30, goods_cd))
        paramList.Add(MakeParam("@kind_cd", SqlDbType.VarChar, 2, kind_cd))

        If tools_id <> "" Then
            sb.AppendLine(" AND tools_id = @tools_id ")
            paramList.Add(MakeParam("@tools_id", SqlDbType.VarChar, 30, tools_id))
        End If

        If classify_id <> "" Then
            sb.AppendLine(" AND classify_id = @classify_id ")
            paramList.Add(MakeParam("@classify_id", SqlDbType.VarChar, 30, classify_id))
        End If


        sb.AppendLine(" Order By disp_no ")
        Dim ds As New DataSet
        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "GetGoodKind", paramList.ToArray)
        Return ds.Tables(0)

    End Function


    ''' <summary>
    ''' 分类列表取得s
    ''' </summary>
    ''' <param name="strGoodsId"></param>
    ''' <param name="strToolsCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetClassifyList(ByVal strGoodsId As String, Optional ByVal strToolsCd As String = "") As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strGoodsId, strToolsCd)
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        If strToolsCd.Equals("") Then
            '外观寸法分类取得
            sb.AppendLine(" SELECT * from (")
            sb.AppendLine(" SELECT ")
            sb.AppendLine(" DISTINCT(m_check.classify_id) ")
            sb.AppendLine(" , ISNULL(m_classify.classify_name, '') AS classify_name ")
            sb.AppendLine(" , ISNULL(m_classify.picture_id, '') AS picture_id ")
            sb.AppendLine(" , ISNULL(m_classify.disp_no, '') AS disp_no ")
            sb.AppendLine(" FROM m_check WITH(READCOMMITTED) ")
            sb.AppendLine(" INNER JOIN m_classify WITH(READCOMMITTED) ")
            sb.AppendLine(" ON m_check.classify_id = m_classify.id ")
            sb.AppendLine(" AND m_classify.delete_flg = @delete_flg ")
            sb.AppendLine(" WHERE m_check.goods_id = @goods_id ")
            sb.AppendLine(" AND m_check.kind_cd='01' ")
            sb.AppendLine(" AND m_check.delete_flg= @delete_flg ) a")
            sb.AppendLine(" order by Convert(int, a.disp_no) ")

        Else
            '治具分类列表取得
            sb.AppendLine(" SELECT * from (")
            sb.AppendLine(" SELECT ")
            sb.AppendLine(" DISTINCT(m_check.classify_id) ")
            sb.AppendLine(" ,ISNULL(m_classify.classify_name, '') AS classify_name ")
            sb.AppendLine(" ,ISNULL(m_classify.picture_id, '') AS picture_id ")
            sb.AppendLine(" ,ISNULL(m_classify.disp_no, '') AS disp_no ")
            sb.AppendLine(" FROM m_check WITH(READCOMMITTED) ")
            sb.AppendLine(" INNER JOIN m_classify WITH(READCOMMITTED) ")
            sb.AppendLine(" ON m_check.classify_id = m_classify.id ")
            sb.AppendLine(" AND m_classify.delete_flg = @delete_flg ")
            sb.AppendLine(" WHERE m_check.goods_id = @goods_id ")
            sb.AppendLine(" AND m_check.kind_cd='02' ")
            sb.AppendLine(" AND m_check.tools_id = @tools_id ")
            sb.AppendLine(" AND m_check.delete_flg= @delete_flg ) a")

            sb.AppendLine(" order by Convert(int, a.disp_no) ")

            paramList.Add(MakeParam("@tools_id", SqlDbType.Char, 7, strToolsCd))
        End If
        paramList.Add(MakeParam("@goods_id", SqlDbType.Char, 7, strGoodsId))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
        'パラメータ設定
        Dim ds As New DataSet


        '検索の実行
        Dim tableName As String = "classifyList"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function


    ''' <summary>
    ''' 检查项目详细信息取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChkDetailInfo(ByVal result_id As String, ByVal goods_cd As String, ByVal kind_cd As String, ByVal classify_id As String, ByVal tools_id As String) As DataTable
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" m_check.id ")
        sb.AppendLine(" , m_check.kind ")
        sb.AppendLine(" , m_check.check_position ")
        sb.AppendLine(" , m_check.check_item ")
        sb.AppendLine(" , m_check.benchmark_type ")
        sb.AppendLine(" , m_check.benchmark_value1 ")
        sb.AppendLine(" , m_check.benchmark_value2 ")
        sb.AppendLine(" , m_check.benchmark_value3 ")
        sb.AppendLine(" , m_check.check_way ")
        sb.AppendLine(" , t_result_detail.check_times ")
        sb.AppendLine(" , ISNULL(t_result_detail.measure_value1, '') AS measure_value1 ")
        sb.AppendLine(" , ISNULL(t_result_detail.measure_value2, '') AS measure_value2 ")
        sb.AppendLine(" , ISNULL(t_result_detail.result, '') AS result ")
        sb.AppendLine(" , ISNULL(t_result_detail.dis_no, '1') AS dis_no ")
        sb.AppendLine(" , ISNULL(t_result_detail.remarks, '') AS remarks ")
        sb.AppendLine(" , ISNULL(m_kbn.mei, '') AS mei ")
        sb.AppendLine(" , ISNULL(m_kbn.mei_cd, '') AS mei_cd ")

        sb.AppendLine(" , t_result_detail.benchmark_type as benchmark_type_old")
        sb.AppendLine(" , t_result_detail.benchmark_value1 as benchmark_value1_old")
        sb.AppendLine(" , t_result_detail.benchmark_value2 as benchmark_value2_old")
        sb.AppendLine(" , t_result_detail.benchmark_value3 as benchmark_value3_old")
        sb.AppendLine(" , ISNULL(t_result_detail.tools_scan_flg, '') AS tools_scan_flg ")

        sb.AppendLine(" FROM ")
        sb.AppendLine(" m_check WITH(READCOMMITTED) ")

        sb.AppendLine(" LEFT JOIN m_goods WITH (READCOMMITTED)")
        sb.AppendLine(" ON dbo.m_goods.id = dbo.m_check.goods_id ")

        sb.AppendLine(" LEFT JOIN ")
        sb.AppendLine(" t_result_detail WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_check.id = t_result_detail.check_id ")
        sb.AppendLine(" AND t_result_detail.result_id  = @result_id ")

        sb.AppendLine(" LEFT JOIN ")
        sb.AppendLine(" m_kbn WITH(READCOMMITTED) ")
        sb.AppendLine(" ON m_check.type_cd = m_kbn.mei_cd ")
        sb.AppendLine(" AND m_kbn.mei_kbn = '0002' ")

        sb.AppendLine(" INNER JOIN m_classify WITH (READCOMMITTED) ON m_check.classify_id = m_classify.id AND m_classify.delete_flg = '0'")


        sb.AppendLine(" WHERE  ")
        sb.AppendLine(" m_goods.goods_cd = @goods_cd ")
        sb.AppendLine(" AND m_check.kind_cd = @kind_cd ")
        '种类判断
        If kind_cd.ToString.Equals("02") Then
            'sb.AppendLine(" AND m_check.tools_id = @tools_id ")
            'paramList.Add(MakeParam("@tools_id", SqlDbType.VarChar, 7, tools_id))
        End If

        sb.AppendLine(" AND m_check.classify_id = @classify_id ")
        sb.AppendLine(" ORDER BY m_check.type_cd,m_check.id ,t_result_detail.dis_no,t_result_detail.check_times ")


        paramList.Add(MakeParam("@goods_cd", SqlDbType.VarChar, 30, goods_cd))
        'パラメータ設定
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, result_id))

        paramList.Add(MakeParam("@kind_cd", SqlDbType.VarChar, 3, kind_cd))
        paramList.Add(MakeParam("@classify_id", SqlDbType.VarChar, 8, classify_id))

        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "CheckDetailInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)
    End Function


    ''' <summary>
    ''' 根据图片ID取得图片二进制
    ''' </summary>
    ''' <param name="strPicId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPicInfoById(ByVal strPicId As String) As DataSet
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strPicId)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine(" picture_content ")
        sb.AppendLine(" FROM ")
        sb.AppendLine("  m_picture WITH(READCOMMITTED) ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = @picId ")
        sb.AppendLine(" AND delete_flg = @delete_flg ")

        'パラメータ設定
        paramList.Add(MakeParam("@picId", SqlDbType.Char, 7, strPicId))
        paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))

        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "PicInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds

    End Function

    ' ''' <summary>
    ' ''' 取得该分类下的所有检查结果
    ' ''' </summary>
    ' ''' <param name="strGoodsId"></param>
    ' ''' <param name="strResultId"></param>
    ' ''' <param name="strClassfyId"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetChkDetailResult(ByVal strGoodsId As String, ByVal strResultId As String, ByVal strClassfyId As String) As DataSet
    '    AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name, strResultId, strClassfyId)
    '    Dim sb As New StringBuilder
    '    Dim paramList As New List(Of SqlParameter)

    '    sb.AppendLine(" SELECT ")
    '    sb.AppendLine(" m_check.id  AS id ")
    '    sb.AppendLine(" , ISNULL( t_result_detail.result,'INIT') AS result ")
    '    sb.AppendLine(" FROM ")
    '    sb.AppendLine(" m_check WITH(READCOMMITTED) ")
    '    sb.AppendLine(" LEFT JOIN t_result_detail WITH(READCOMMITTED) ")
    '    sb.AppendLine(" ON  t_result_detail.check_id = m_check.id ")
    '    sb.AppendLine(" AND t_result_detail.result_id = @strResultId ")
    '    sb.AppendLine(" AND t_result_detail.delete_flg = @delete_flg ")
    '    sb.AppendLine(" WHERE ")
    '    sb.AppendLine("  m_check.goods_id = @strGoodsId ")
    '    sb.AppendLine(" AND m_check.classify_id = @strClassfyId ")
    '    sb.AppendLine(" AND m_check.delete_flg = @delete_flg ")

    '    'パラメータ設定
    '    paramList.Add(MakeParam("@strGoodsId", SqlDbType.VarChar, 7, strGoodsId))
    '    paramList.Add(MakeParam("@strClassfyId", SqlDbType.VarChar, 8, strClassfyId))
    '    paramList.Add(MakeParam("@strResultId", SqlDbType.VarChar, 13, strResultId))
    '    paramList.Add(MakeParam("@delete_flg", SqlDbType.Char, 1, UNDELETED))
    '    Dim ds As New DataSet

    '    '検索の実行
    '    Dim tableName As String = "DetailResultInfo"
    '    FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)

    '    Return ds
    'End Function


    ''' <summary>
    ''' 该分类下结果取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChkDetailResultMSG(ByVal strResultId As String) As DataTable

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT ")
        sb.AppendLine("     isnull(t_result_detail.result,'') as result ")
        sb.AppendLine(" FROM ")

        sb.AppendLine("   t_result_detail WITH(READCOMMITTED) ")

        sb.AppendLine(" WHERE ")
        sb.AppendLine("   t_result_detail.result_id = @strResultId ")

        'パラメータ設定
        paramList.Add(MakeParam("@strResultId", SqlDbType.VarChar, 13, strResultId))
        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "DetailResultInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)

        Return ds.Tables(0)
    End Function


    ''' <summary>
    ''' 治具是否扫描明细
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChkDetailResultScanFlg(ByVal result_id As String) As DataTable

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)

        sb.AppendLine(" SELECT classify_id,")
        sb.AppendLine("     isnull(tools_scan_flg,'') as tools_scan_flg ")
        sb.AppendLine(" FROM ")

        sb.AppendLine("   t_result_detail WITH(READCOMMITTED) ")

        sb.AppendLine(" WHERE ")
        sb.AppendLine(" result_id = @result_id ")
        ' sb.AppendLine(" AND classify_id = @classify_id ")


        'パラメータ設定
        'パラメータ設定
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, result_id))


        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "DetailResultInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)

        Return ds.Tables(0)
    End Function


    Public Function GetLineAndSuuFrom_TB_CompleteData(ByVal strGoodsCode As String, ByVal strMakeNo As String) As DataTable


        '因为商品表的中的商品CD为带“-”的,而在生产表中是不带“-”。所以要对商品CD加处理
        Dim strPGoodCd As String = Replace(strGoodsCode, "-", "")
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
       

        sb.AppendLine(" SELECT ")
        sb.AppendLine("  D.Product_Line AS '生产线'")
        sb.AppendLine(" , D.ProductionQuantity  AS '数量'")    
        sb.AppendLine("FROM TB_CompleteData AS D WITH(READCOMMITTED)  ")
        sb.AppendLine("WHERE D.Code = '" & strGoodsCode & "' ")
        sb.AppendLine("AND D.MakeNumber = '" & strMakeNo & "'")

        Dim ds As New DataSet

        '検索の実行
        Dim tableName As String = "ResultInfo"
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, tableName, paramList.ToArray)
        Return ds.Tables(0)

    End Function

    '商品分类列表
    Public Function GetGoodCdByMakeNo(ByVal strMakeNo As String) As DataTable

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" SELECT Code ,MakeNumber FROM TB_CompleteData where MakeNumber = '" & strMakeNo & "'")
        Dim ds As New DataSet
        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "GetGoodCD", paramList.ToArray)
        Return ds.Tables(0)

    End Function


    '商品分类列表
    Public Function GetFirstCheck(ByVal cd As String) As String

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine("SELECT tongyong_cd FROM t_first_check where tongyong_cd in (")
        sb.AppendLine("SELECT tongyong_cd FROM t_first_check where good_cd = '" & cd.Replace("-", "") & "')")
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
        sb.AppendLine(" SELECT tongyong_cd FROM t_first_check where good_cd = '" & cd.Replace("-", "") & "'")

        Dim ds As New DataSet
        '検索の実行
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "GetFirstCheck", paramList.ToArray)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""
        End If

    End Function

End Class
