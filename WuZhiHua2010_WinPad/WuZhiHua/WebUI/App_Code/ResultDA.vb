Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data

Public Class ResultDA

    ''' <summary>
    ''' 向检查结果表内插入数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertResultTemp(ByVal crIndex As String, ByVal goods_cd As String, ByVal make_number As String, ByVal check_user As String) As Integer

        Dim result As Integer
        Dim sb As New StringBuilder

        With sb


            .AppendLine(" INSERT INTO ")
            .AppendLine(" t_check_result ")
            .AppendLine("SELECT top 1")
            .AppendLine(" " & crIndex & " ")
            .AppendLine("  , A.goods_id ")
            .AppendLine("  , '" & make_number & "' ")
            .AppendLine("  , B.department_cd")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , GETDATE() ")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , null ") '[up_start_time]    更新时 需要
            .AppendLine(" , null ") '[up_end_time]  更新时 需要
            '再检检查员
            .AppendLine(" , '' ")   'result 更新时 需要
            .AppendLine(" , '' ")    '[remarks]
            .AppendLine(" , B.check_times ")   'check_times
            .AppendLine(" , '' ")    'shareResult_id



            '.AppendLine(" , '' ")   '更新时 需要



            .AppendLine(" , '3' ")     '0 完了  1待判  2默认 是否是临时退出flg 3 临时保存  更新时 需要
            .AppendLine(" , '0' ")  'delete_flg
            .AppendLine(" , '0' ")  'qianpin_flg
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , C.Product_Line ") '生产线
            .AppendLine(" , C.ProductionQuantity ") '数量
            .AppendLine(" , C.Finish_Date ") '生产实际日

            .AppendLine("FROM v_goods_kind A")
            .AppendLine("INNER JOIN m_check B ON")
            .AppendLine("B.goods_id = A.goods_id ")
            .AppendLine("LEFT JOIN TB_CompleteData C ON")
            .AppendLine("C.Code = '" & goods_cd & "' ")
            .AppendLine("And C.MakeNumber = '" & make_number & "' ")
            .AppendLine("WHERE A.[goods_cd]='" & goods_cd & "'")
        End With


        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Rireki.InsRireki("t_check_result新规", crIndex, "", goods_cd, make_number, "", check_user)

        Return result
    End Function


    ''' <summary>
    ''' 向检查结果表内插入数据 手入力
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertResultByHand(ByVal crIndex As String, ByVal goods_cd As String, ByVal make_number As String, ByVal check_user As String, _
                                       ByVal lineCd As String, ByVal result As String) As Integer

        Dim sb As New StringBuilder

        With sb


            .AppendLine(" INSERT INTO ")
            .AppendLine(" t_check_result ")
            .AppendLine("SELECT top 1")
            .AppendLine(" " & crIndex & " ")
            .AppendLine("  , A.goods_id ")
            .AppendLine("  , '" & make_number & "' ")
            .AppendLine("  , B.department_cd")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , GETDATE() ")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , null ") '[up_start_time]    更新时 需要
            .AppendLine(" , null ") '[up_end_time]  更新时 需要
            '再检检查员
            .AppendLine(" , '" & result & "' ")   'result 更新时 需要



            '.AppendLine(" , '' ")   '更新时 需要
            .AppendLine(" , '' ")    '[remarks]
            .AppendLine(" , B.check_times ")   'check_times
            .AppendLine(" , '手入力' ")    'shareResult_id
            .AppendLine(" , '0' ")     '0 完了  1待判  2默认 是否是临时退出flg 3 临时保存  更新时 需要
            .AppendLine(" , '0' ")  'delete_flg
            .AppendLine(" , '0' ")  'qianpin_flg
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , C.Product_Line ") '生产线
            .AppendLine(" , C.ProductionQuantity ") '数量
            .AppendLine(" , C.Finish_Date ") '生产实际日

            .AppendLine("FROM v_goods_kind A")
            .AppendLine("LEFT JOIN m_check B ON")
            .AppendLine("B.goods_id = A.goods_id ")

            .AppendLine("LEFT JOIN TB_CompleteData C ON")
            .AppendLine("C.Code = '" & goods_cd & "' ")
            .AppendLine("And C.MakeNumber = '" & make_number & "' ")

            .AppendLine("WHERE [goods_cd]='" & goods_cd & "' or  [goods_cd]='" & goods_cd.Replace("-", "") & "'  ")
        End With

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Return result
    End Function

    ''' <summary>
    ''' 向检查结果表内插入数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertResultMoren(ByVal crIndex As String, ByVal goods_cd As String, ByVal make_number As String, ByVal check_user As String, ByVal share_id As String) As Integer

        Dim result As Integer
        Dim sb As New StringBuilder

        With sb


            .AppendLine(" INSERT INTO ")
            .AppendLine(" t_check_result ")
            .AppendLine("SELECT top 1")
            .AppendLine(" " & crIndex & " ")
            .AppendLine("  , A.goods_id ")
            .AppendLine("  , '" & make_number & "' ")
            .AppendLine("  , A.department_cd")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , GETDATE() ")
            '再检检查员
            .AppendLine(" , '' ")   '再检检查员 更新时 需要
            .AppendLine(" , null ") '[up_start_time]    更新时 需要
            .AppendLine(" , null ") '[up_end_time]  更新时 需要
            .AppendLine(" , result ")   'result更新时 需要
            .AppendLine(" , '' ")    '[remarks]
            .AppendLine(" , check_times ")   'check_times
            .AppendLine(" , '" & share_id & "' ")    'shareResult_id
            .AppendLine(" , '2' ")     '0 完了  1待判  2默认 是否是临时退出flg 3 临时保存  更新时 需要
            .AppendLine(" , '0' ")  'delete_flg
            .AppendLine(" , qianpin_flg ")  'qianpin_flg
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine("  , '" & check_user & "' ")
            .AppendLine(" , GETDATE() ")
            .AppendLine(" , Product_Line_check ") '生产线
            .AppendLine(" , ProductionQuantity_check ") '数量
            .AppendLine(" , Finish_Date_check ") '生产实际日

            .AppendLine("FROM t_check_result A")
            .AppendLine("WHERE [id]='" & share_id & "'")
            '.AppendLine("FROM v_goods_kind A")
            '.AppendLine("INNER JOIN m_check B ON")
            '.AppendLine("B.goods_id = A.goods_id ")
            '.AppendLine("WHERE [goods_cd]='" & goods_cd & "'")
        End With

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Rireki.InsRireki("t_check_result新规", crIndex, "", goods_cd, make_number, "继承" & share_id, check_user)

        Return result

    End Function


    Public Function InsertResultDetail(ByVal result_id As String, ByVal where_result_id As String, ByVal check_user As String) As Integer

        Dim result As Integer
        Dim sb As New StringBuilder

        With sb


            .AppendLine(" INSERT INTO ")
            .AppendLine(" t_result_detail ")
            .AppendLine("SELECT ")
            .AppendLine("'" & result_id & "' ")
            .AppendLine(",check_id ")
            .AppendLine(",measure_value1 ")
            .AppendLine(",measure_value2 ")

            .AppendLine(",picture_id ")
            .AppendLine(",result ")
            .AppendLine(",dis_no ")
            .AppendLine(",remarks ")
            .AppendLine(",delete_flg ")
            .AppendLine(",benchmark_type ")
            .AppendLine(",benchmark_value1 ")
            .AppendLine(",benchmark_value2 ")
            .AppendLine(",benchmark_value3 ")
            .AppendLine(",tools_scan_flg ")
            .AppendLine(",classify_id ")
            .AppendLine(",check_times ")
            .AppendLine("FROM t_result_detail ")

            .AppendLine("WHERE result_id='" & where_result_id & "'")
        End With

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Rireki.InsRireki("t_result_detail新规", result_id, "", "", "", "继承" & where_result_id, check_user)

        Return result
    End Function

    Public Function Updatet_check_result_continue_chk_flg(ByVal id As String, ByVal continue_chk_flg As String, ByVal check_user As String, ByVal result As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)

        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)


        '非继续检查情况下的最终保存
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_check_result WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" continue_chk_flg = @continue_chk_flg ")
        sb.AppendLine(" ,end_time = getdate() ")
        sb.AppendLine(" ,up_end_time = getdate() ")
        If result <> "" Then
            sb.AppendLine(", result = '" & result & "' ")
        End If
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 13, id))
        paramList.Add(MakeParam("@continue_chk_flg", SqlDbType.Char, 1, continue_chk_flg))

        Dim rtn As Integer = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Rireki.InsRireki("t_check_result更新", id, "", "", "", "更新continue_chk_flg" & continue_chk_flg, check_user)

        '更新の実行
        Return rtn

    End Function


    ''' <summary>
    ''' 向检查结果表内插入数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertResultDetailWaiguan(ByVal crIndex As String, ByVal goods_cd As String, ByVal check_user As String) As Integer

        Dim result As Integer
        Dim sb As New StringBuilder

        With sb

            For i As Integer = 1 To 9
                .AppendLine("INSERT INTO t_result_detail")
                .AppendLine("SELECT DISTINCT '" & crIndex & "' AS result_id,")
                .AppendLine("                A.id AS check_id,")
                .AppendLine("                '' AS measure_value1,")
                .AppendLine("                '' AS measure_value2,")
                .AppendLine("                C.picture_id,")
                .AppendLine("                '' AS RESULT,")
                .AppendLine("                C.disp_no AS dis_no,")
                .AppendLine("                '' AS remarks,")
                .AppendLine("                '0' AS delete_flg,")
                .AppendLine("                [benchmark_type],")
                .AppendLine("                [benchmark_value1],")
                .AppendLine("                [benchmark_value2],")
                .AppendLine("                [benchmark_value3],")
                .AppendLine("                '0',") 'scan flg
                .AppendLine("                A.classify_id,") 'scan flg
                .AppendLine("                '" & i & "'") 'scan flg
                .AppendLine("FROM m_check A")
                .AppendLine("INNER JOIN m_goods B ON B.id = A.goods_id")
                .AppendLine("INNER JOIN m_classify C WITH (READCOMMITTED) ON A.classify_id = C.id")
                .AppendLine("AND C.delete_flg = '0'")
                .AppendLine("WHERE  [goods_cd] ='" & goods_cd & "'")
                .AppendLine("AND  A.check_times >='" & i & "'")
            Next

        End With

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Rireki.InsRireki("t_result_detail新规", crIndex, "", goods_cd, "", "", check_user)

        Return result
    End Function




    ''' <summary>
    ''' 更新检查结果详细表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateResultDetail(ByVal result_id As String, ByVal check_id As String, ByVal dis_no As String, ByVal check_times As String, ByVal measure_value1 As String, ByVal measure_value2 As String, ByVal result As String, ByVal remarks As String, ByVal benchmark_type As String, ByVal benchmark_value1 As String, ByVal benchmark_value2 As String, ByVal benchmark_value3 As String) As Integer


        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_result_detail WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" result = @result ")
        sb.AppendLine(" , remarks = @remarks ")

        'パラメータ設定
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, result_id))
        paramList.Add(MakeParam("@check_id", SqlDbType.VarChar, 9, check_id))

        sb.AppendLine(" , measure_value1 = @measure_value1  ")
        paramList.Add(MakeParam("@measure_value1", SqlDbType.VarChar, 100, measure_value1))


        sb.AppendLine(" , measure_value2 = @measure_value2 ")
        paramList.Add(MakeParam("@measure_value2", SqlDbType.VarChar, 100, measure_value2))


        sb.AppendLine(" , benchmark_type = @benchmark_type ")
        paramList.Add(MakeParam("@benchmark_type", SqlDbType.VarChar, 100, benchmark_type))

        sb.AppendLine(" , benchmark_value1 = @benchmark_value1 ")
        paramList.Add(MakeParam("@benchmark_value1", SqlDbType.VarChar, 100, benchmark_value1))

        sb.AppendLine(" , benchmark_value2 = @benchmark_value2 ")
        paramList.Add(MakeParam("@benchmark_value2", SqlDbType.VarChar, 100, benchmark_value2))

        sb.AppendLine(" , benchmark_value3 = @benchmark_value3 ")
        paramList.Add(MakeParam("@benchmark_value3", SqlDbType.VarChar, 100, benchmark_value3))





        sb.AppendLine(" WHERE ")
        sb.AppendLine(" result_id = @result_id ")
        sb.AppendLine(" AND check_id = @check_id ")
        sb.AppendLine(" AND dis_no = @dis_no ")
        sb.AppendLine(" AND check_times = '" & check_times & "' ")

        paramList.Add(MakeParam("@result", SqlDbType.Char, 2, result))
        paramList.Add(MakeParam("@dis_no", SqlDbType.VarChar, 2, dis_no))
        paramList.Add(MakeParam("@remarks", SqlDbType.VarChar, 200, remarks))
        '更新の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return result
    End Function



    ''' <summary>
    ''' 更新检查结果详细表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateResultDetailToolsFlg(ByVal result_id As String, ByVal classify_id As String) As Integer


        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_result_detail WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" tools_scan_flg='1' ")

        'パラメータ設定
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, result_id))
        paramList.Add(MakeParam("@classify_id", SqlDbType.VarChar, 9, classify_id))

        sb.AppendLine(" WHERE ")
        sb.AppendLine(" result_id = @result_id ")
        sb.AppendLine(" AND classify_id = @classify_id ")

        '更新の実行
        Return ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)


    End Function

    ''' <summary>
    ''' 更新检查结果详细表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateResultDetailAllToolsFlg(ByVal result_id As String) As Integer


        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_result_detail WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" tools_scan_flg='1' ")

        'パラメータ設定
        paramList.Add(MakeParam("@result_id", SqlDbType.VarChar, 13, result_id))


        sb.AppendLine(" WHERE ")
        sb.AppendLine(" result_id = @result_id ")


        '更新の実行
        Return ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)


    End Function


    Public Function Updatet_check_resultQinapinFlg(ByVal id As String, ByVal qianpin_flg As String, ByVal check_user As String) As Integer
        AddMethodEntrance(MyClass.GetType.FullName & "." & GetCurrentMethod.Name)
        Dim result As Integer
        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)


        '非继续检查情况下的最终保存
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_check_result WITH (UPDLOCK) ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" qianpin_flg = @qianpin ")
        sb.AppendLine(" WHERE ")
        sb.AppendLine(" id = @id ")

        'パラメータ設定
        paramList.Add(MakeParam("@id", SqlDbType.VarChar, 13, id))
        paramList.Add(MakeParam("@qianpin", SqlDbType.Char, 1, qianpin_flg))

        '更新の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)
        Rireki.InsRireki("欠品更新", id, "", "", "", "qianpin_flg:" & qianpin_flg, check_user)
        Return result
    End Function


    Public Function UpdFirstCheck(ByVal tongyong_cd As String) As Integer


        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" UPDATE ")
        sb.AppendLine(" t_first_check ")
        sb.AppendLine(" SET ")
        sb.AppendLine(" checked_flg='1' ")

        sb.AppendLine(" WHERE ")
        sb.AppendLine(" tongyong_cd = '" & tongyong_cd & "' ")


        '更新の実行
        Return ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)


    End Function


    Public Function InsFirstCheck(ByVal goods_cd As String, ByVal tongyong_cd As String) As Integer


        Dim sb As New StringBuilder
        Dim paramList As New List(Of SqlParameter)
        sb.AppendLine(" insert into t_first_check ")
        sb.AppendLine(" select ")
        sb.AppendLine(" '" & goods_cd & "' ")
        sb.AppendLine(" ,'" & tongyong_cd & "' ")
        sb.AppendLine(" ,'1' ")

        '更新の実行
        Return ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)


    End Function

End Class
