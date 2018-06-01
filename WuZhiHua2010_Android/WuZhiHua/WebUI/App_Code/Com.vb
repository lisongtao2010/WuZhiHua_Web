Imports Microsoft.VisualBasic

Public Class Com

    '获得检查总体结果
    Public Shared Function GetResultMsg(ByVal result_id As String) As String
        Dim CheckDA As New CheckDA
        Dim dt As Data.DataTable = CheckDA.GetChkDetailResultMSG(result_id)
        Dim str As New StringBuilder
        str.Append("全部（" & dt.Rows.Count & "）")
        str.Append("合格（" & dt.Select("result='OK'").Length & "）")
        str.Append("微（" & dt.Select("result='SD'").Length & "）")
        str.Append("警（" & dt.Select("result='JN'").Length & "）")
        str.Append("轻（" & dt.Select("result='M1'").Length & "）")
        str.Append("中（" & dt.Select("result='M2'").Length & "）")
        str.Append("重（" & dt.Select("result='M3'").Length & "）")
        str.Append("误（" & dt.Select("result='NG'").Length & "）")
        str.Append("漏检（" & dt.Select("result=''").Length & "）")
        Return str.ToString
    End Function


    Public Shared Function GetResult(ByVal result_id As String) As String
        Dim CheckDA As New CheckDA
        Dim dt As Data.DataTable = CheckDA.GetChkDetailResultMSG(result_id)
        If dt.Select("result='NG' ").Length > 0 OrElse _
            dt.Select("result='M1' ").Length > 0 OrElse _
            dt.Select("result='M2' ").Length > 0 OrElse _
            dt.Select("result='M3' ").Length > 0 OrElse _
            dt.Select("result='' ").Length > 0 Then


            Return "NG"
        Else
            Return "OK"
        End If
    End Function


    Public Shared Function GetResultSuu(ByVal result_id As String) As String
        Dim CheckDA As New CheckDA
        Dim dt As Data.DataTable = CheckDA.GetChkDetailResultMSG(result_id)
        If dt.Select("result='NG' ").Length > 0 OrElse _
            dt.Select("result='M1' ").Length > 0 OrElse _
            dt.Select("result='M2' ").Length > 0 OrElse _
            dt.Select("result='M3' ").Length > 0 OrElse _
            dt.Select("result='' ").Length > 0 Then


            Dim str As New StringBuilder
            str.Append("轻（" & dt.Select("result='M1'").Length & "）")
            str.Append("中（" & dt.Select("result='M2'").Length & "）")
            str.Append("重（" & dt.Select("result='M3'").Length & "）")
            str.Append("误（" & dt.Select("result='NG'").Length & "）")
            str.Append("漏检（" & dt.Select("result=''").Length & "）")
            Return str.ToString
        Else
            Return "OK"
        End If
    End Function

    Public Shared Function GetResultLoujian(ByVal result_id As String) As Boolean
        Dim CheckDA As New CheckDA
        Dim dt As Data.DataTable = CheckDA.GetChkDetailResultMSG(result_id)
        If dt.Select("result='' ").Length > 0 Then

            Return True

        Else
            Return False
        End If
    End Function

    '类型Scan Or Input
    Public Shared Function GetRemark(ByVal remark As String, ByVal result As String _
                            , ByVal ktype As String _
                            , ByVal oldktype As String _
                            , ByVal k1 As String _
                            , ByVal k2 As String _
                            , ByVal k3 As String _
                            , ByVal oldk1 As String _
                            , ByVal oldk2 As String _
                            , ByVal oldk3 As String _
                            , ByVal v1 As String _
                            , ByVal v2 As String) As String
        If result = "NG" OrElse result = "M1" OrElse result = "M2" OrElse result = "M3" Then
            Return "(" & k1 & "," & k2 & "," & k3 & ")"

        ElseIf oldktype <> "" AndAlso ( _
                k1 <> oldk1 _
                OrElse k2 <> oldk2 _
                OrElse k3 <> oldk3 _
                OrElse ktype <> oldktype) Then
            Return "基准值变化 请重新检查"
        ElseIf Not CheckJizhunzhi(ktype, k1, k2, k3, v1, v2) Then
            Return "(" & k1 & "," & k2 & "," & k3 & ")"
        Else
            'Return remark
            Return ""
        End If
    End Function



    Public Shared Function CheckJizhunzhi(ByVal zbenchmark_type As String, _
                                   ByVal zbenchmark_value1 As String, _
                                   ByVal zbenchmark_value2 As String, _
                                   ByVal zbenchmark_value3 As String, _
                                   ByVal v1 As String, _
                                   ByVal v2 As String) As Boolean

        Try


            Dim value, jizhun As String
            Dim Result As Boolean
            value = v1

            If v1.Trim & v2.Trim = "" Then
                Return True
            End If

            If (zbenchmark_type = "00") Then '目视
            ElseIf (zbenchmark_type = "01") Then
                ' K1 = In

                If (value = zbenchmark_value1.Replace("-", "")) Then
                    Result = True
                Else
                    'jizhun = "=" + zbenchmark_value1.replace("-", "")
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "02") Then
                ' IN < V1
                If (parseFloat(value) < parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = "<" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "03") Then
                ' IN <= V1
                If (parseFloat(value) <= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = "<=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"

                    Result = False
                End If
            ElseIf (zbenchmark_type = "04") Then
                ' IN > V1
                If (parseFloat(value) > parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = ">" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"

                    Result = False
                End If
            ElseIf (zbenchmark_type = "05") Then
                ' IN >= V1
                If (parseFloat(value) >= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    ' jizhun = ">=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "06") Then
                ' V1+V3 <= IN <= V1+V2
                If (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(value) <= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    ' jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "10") Then
                '/ 0 <= IN <= v1/1000
                If (parseFloat(value) >= 0 AndAlso parseFloat(value) <= parseFloat(zbenchmark_value1) / 1000) Then
                    Result = True
                Else
                    'jizhun = "0～" + parseFloat(zbenchmark_value1) / 1000
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "12") Then

                Dim temp = ("20" + value).Replace("Y7", "").ToUpper()
                '    "小口标签日期测试，1.有没有标签，有就算合格 2.没有就算NG   3.有的话扫描到的日期如果和当前 要在当前日期的加减3天以内，则为正确 不是的话就是OW
                If (parseFloat(temp) + 3 >= parseFloat(getNowFormatDate()) AndAlso parseFloat(temp) - 3 <= parseFloat(getNowFormatDate())) Then
                    Result = True
                Else
                    jizhun = "前后3日以内"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "13") Then
                ' 0 < IN <=V1
                If (parseFloat(value) > 0 AndAlso parseFloat(value) <= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = "0～" + parseFloat(zbenchmark_value1) / 1000
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "14") Then
                ' V1+V3<= IN < V1+V2
                If (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    'jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "15-1") Then
                ' IN > V1
                If (parseFloat(value) > parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = ">" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "16-1") Then
                ' IN < V1
                If (parseFloat(value) < parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    ' jizhun = "<" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "17-1") Then
                ' IN >= V1
                If (parseFloat(value) >= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = ">=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "18-1") Then
                ' IN <= V1
                If (parseFloat(value) <= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = "<=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "19-1") Then
                ' V1 + V3 < IN < V1 + V2
                If (parseFloat(value) > parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    'jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "20-1") Then
                ' V1+v3 <= IN < V1 + V2
                If (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    'jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            End If



            '绝对值取得
            Dim cha As String = "0"

            Try
                cha = (Convert.ToDecimal(v1) - Convert.ToDecimal(v2)).ToString
            Catch ex As Exception
                If v1 = "" Then
                    v1 = "0"
                End If
                If v2 = "" Then
                    v2 = "0"
                End If
                cha = (Convert.ToDecimal(v1) - Convert.ToDecimal(v2)).ToString
            End Try


            If (zbenchmark_type = "15-2") Then
                ' ｜V1-V2｜》v

                If (parseFloat(cha) > parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = ">" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If

            ElseIf (zbenchmark_type = "16-2") Then
                ' ｜V1-V2｜《v1
                If (parseFloat(cha) < parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = "<" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "17-2") Then
                ' ｜V1-V2｜》＝V1
                If (parseFloat(cha) >= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    'jizhun = ">=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "18-2") Then
                '｜V1-V2｜《＝V1
                If (parseFloat(cha) <= parseFloat(zbenchmark_value1)) Then
                    Result = True
                Else
                    ' jizhun = "<=" + zbenchmark_value1
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "19-2") Then
                ' V1+V3 《 ｜V1-V2｜ 《 V1+V3
                If (parseFloat(cha) > parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(cha) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    ' jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            ElseIf (zbenchmark_type = "20-2") Then
                ' v1+v3 《＝｜V1-V2｜ 《 v1 ＋ V2
                If (parseFloat(cha) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) AndAlso parseFloat(cha) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2)) Then
                    Result = True
                Else
                    ' jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2))
                    jizhun = "(" + zbenchmark_value1.Replace("-", "") + "," + zbenchmark_value2.Replace("-", "") + "," + zbenchmark_value3.Replace("-", "") + ")"
                    Result = False
                End If
            End If

            Return Result
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function parseFloat(ByVal v As Object) As Decimal
        Return Convert.ToDecimal(v)

    End Function

    Public Shared Function getNowFormatDate() As String
        Return Now.ToString("yyyyMMdd")
    End Function

End Class
