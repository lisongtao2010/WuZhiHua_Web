Imports System.Threading
Imports System.Web.Services
Imports System.IO
Imports System.Collections.Generic

Partial Class AJAX
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("k") = "1" Then
            updatedetail()
        ElseIf Request.QueryString("k") = "11" Then
            updateToolsScanFlg()
        ElseIf Request.QueryString("k") = "31" Then
            UpdateQianpin()
        ElseIf Request.QueryString("k") = "auto_ipt" Then
            Dim auto_ipt_path As String
            If Request.QueryString("serKbn") = "1" Then
                auto_ipt_path = ConfigurationManager.AppSettings("auto_ipt1").ToString()
            Else
                auto_ipt_path = ConfigurationManager.AppSettings("auto_ipt2").ToString()
            End If

            Dim iptCnt As String = Request.QueryString("iptCnt")
            Dim stTime As DateTime = Now
            If Request.QueryString("stTime") <> "" Then
                stTime = CDate(Request.QueryString("stTime"))
            Else
                Dim mDirInfo As New System.IO.DirectoryInfo(auto_ipt_path)
                Dim mFileInfo As System.IO.FileInfo
                For Each mFileInfo In mDirInfo.GetFiles("*.csv")
                    Try

                        System.IO.Directory.Move(mFileInfo.FullName, auto_ipt_path & "\Old\" & Now.ToString("yyyyMMddhhmmssfff") & "_" & mFileInfo.Name)
                    Catch ex As Exception
                        Response.Write("NG 没有权限" & "," & ex.Message)
                        Response.End()
                    End Try
                Next
            End If

            Dim fidx As String = "0"



            Dim dt As Data.DataTable = GetAllFilesDt(auto_ipt_path)
            If dt.Rows.Count < CInt(iptCnt) Then
                Response.Write("WAIT 准备开始读取" & dt.Rows.Count & "," & stTime)
                Response.End()
            Else
                Dim arr(iptCnt - 1) As String
                Dim drs As Data.DataRow() = dt.Select("", "upTime asc")

                For i As Integer = 0 To drs.Length - 1
                    Dim flName As String = drs(i).Item(0)
                    'For j As Integer = 1 To CInt(iptCnt)
                    If flName.Contains(" _ ") Then
                        fidx = Left(Right(flName, 5), 1)
                        Dim txt As String = System.IO.File.ReadAllText(drs(i).Item(0)).Split(",")(1).Replace("""", "")
                        If IsNumeric(txt) Then
                            If fidx > arr.Length Then
                                Response.Write("WAIT 读取数据数超越可输入的值的数量," & stTime)
                                Response.End()
                            Else
                                Try
                                    arr(fidx - 1) = txt
                                Catch ex As Exception

                                End Try

                            End If

                        End If
                    End If
                    'Next
                Next


                For i As Integer = 0 To arr.Length - 1
                    If arr(i) = "" Then
                        Response.Write("WAIT 已经读取到" & fidx & "," & stTime)
                        Response.End()
                    End If
                Next

                Dim mDirInfo As New System.IO.DirectoryInfo(auto_ipt_path)
                Dim mFileInfo As System.IO.FileInfo
                For Each mFileInfo In mDirInfo.GetFiles("*.csv")
                    Try
                        System.IO.Directory.Move(mFileInfo.FullName, auto_ipt_path & "\Old\" & Now.ToString("yyyyMMddhhmmssfff") & "_" & mFileInfo.Name)

                    Catch ex As Exception

                    End Try
                Next

                For i As Integer = 0 To arr.Length - 1
                    If i > 0 Then
                        Response.Write(",")
                    End If
                    Response.Write(arr(i))
                Next
                Response.End()

                'For i As Integer = 0 To CInt(iptCnt) - 1
                '    If i > 0 Then
                '        Response.Write(",")
                '    End If
                '    Response.Write(System.IO.File.ReadAllText(drs(i).Item(0)).Split(",")(1).Replace("""", ""))
                'Next
                'Response.End()
            End If

            'For i As Integer = 1 To 30
            '    path = GetAllFiles(auto_ipt_path, stTime)
            '    If path <> "" Then
            '        Response.Write(System.IO.File.ReadAllText(path))
            '        Response.End()
            '        Exit Sub
            '    Else
            '        Thread.Sleep(1000)
            '    End If
            'Next

            'Response.Write("NG")
            'Response.End()


        End If
    End Sub


    'Private Function GetAllFilesDt(ByVal strDirect As String, ByVal stTime As DateTime) As Data.DataTable    '搜索所有目录下的文件

    '    Dim dt As New Data.DataTable
    '    dt.Columns.Add("fileName")
    '    dt.Columns.Add("upTime")

    '    If Not (strDirect Is Nothing) Then
    '        Dim mFileInfo As System.IO.FileInfo
    '        Dim mDir As System.IO.DirectoryInfo
    '        Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
    '        Try
    '            For Each mFileInfo In mDirInfo.GetFiles("* _ *.csv")
    '                'Debug.Print(mFileInfo.FullName)
    '                'GetIncludeInfo(mFileInfo.FullName)

    '                'Return mFileInfo.FullName

    '                Dim lastWrtTiime As DateTime = System.IO.File.GetLastWriteTime(mFileInfo.FullName)



    '                If lastWrtTiime > stTime Then

    '                    Dim dr As Data.DataRow
    '                    dr = dt.NewRow
    '                    dr.Item(0) = mFileInfo.FullName
    '                    dr.Item(1) = lastWrtTiime

    '                    dt.Rows.Add(dr)
    '                Else
    '                    Dim h = DateDiff(DateInterval.Hour, lastWrtTiime, Now)
    '                    If h > 2 Then
    '                        Try
    '                            System.IO.Directory.Move(mFileInfo.FullName, strDirect & "\Old\" & mFileInfo.Name)
    '                        Catch ex As Exception

    '                        End Try

    '                        'Return mFileInfo.FullName
    '                    End If
    '                End If
    '                'System.IO.File.GetLastWriteTime(strFilepath & "" & File1.Name).ToShortDateString()
    '            Next
    '            Return dt

    '            'For Each mDir In mDirInfo.GetDirectories
    '            '    'Debug.Print("******目录回调*******")
    '            '    GetAllFiles(mDir.FullName)
    '            'Next
    '        Catch ex As System.IO.DirectoryNotFoundException

    '        End Try
    '    End If
    'End Function


    Private Function GetAllFilesDt(ByVal strDirect As String) As Data.DataTable    '搜索所有目录下的文件

        Dim dt As New Data.DataTable
        dt.Columns.Add("fileName")
        dt.Columns.Add("upTime")

        If Not (strDirect Is Nothing) Then
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            Try
                For Each mFileInfo In mDirInfo.GetFiles("* _ *.csv")
                    'Debug.Print(mFileInfo.FullName)
                    'GetIncludeInfo(mFileInfo.FullName)

                    'Return mFileInfo.FullName

                    'Dim lastWrtTiime As DateTime = System.IO.File.GetLastWriteTime(mFileInfo.FullName)


                    Dim dr As Data.DataRow
                    dr = dt.NewRow
                    dr.Item(0) = mFileInfo.FullName
                    dr.Item(1) = Now

                    dt.Rows.Add(dr)

                    'If lastWrtTiime > stTime Then

                    'Else
                    '    Dim h = DateDiff(DateInterval.Hour, lastWrtTiime, Now)
                    '    If h > 2 Then
                    '        Try
                    '            System.IO.Directory.Move(mFileInfo.FullName, strDirect & "\Old\" & mFileInfo.Name)
                    '        Catch ex As Exception

                    '        End Try

                    '        'Return mFileInfo.FullName
                    '    End If
                    'End If
                    'System.IO.File.GetLastWriteTime(strFilepath & "" & File1.Name).ToShortDateString()
                Next
                Return dt

                'For Each mDir In mDirInfo.GetDirectories
                '    'Debug.Print("******目录回调*******")
                '    GetAllFiles(mDir.FullName)
                'Next
            Catch ex As System.IO.DirectoryNotFoundException

            End Try
        End If
    End Function


    '欠品更新
    Sub UpdateQianpin()

        Try

            Dim param As String() = Request.QueryString("param").Split("|")
            Dim result_id As String = param(0)
            Dim qianpinFlg As String = param(1)
            Dim ResultDA As New ResultDA
            ResultDA.Updatet_check_resultQinapinFlg(result_id, qianpinFlg)
            Response.Write("OK")
        Catch ex As Exception
            Response.Write("NG")
        End Try
        Response.End()

    End Sub

    '治具扫描Flg更新
    Sub updateToolsScanFlg()
        Try
            Dim param As String() = Request.QueryString("param").Split("|")

            Dim result_id As String = param(0)
            Dim check_id As String = param(1)
            Dim ResultDA As New ResultDA
            ResultDA.UpdateResultDetailToolsFlg(result_id, check_id)
            Response.Write("OK")
        Catch ex As Exception
            Response.Write("NG")
        End Try
        Response.End()
    End Sub


    '检查结果明细更新
    Function updatedetail() As String

        Dim param As String() = Request.QueryString("param").Split("|")

        Dim result_id As String = param(0)
        Dim check_id As String = param(1)
        Dim value1 As String = param(2)
        Dim value2 As String = param(3)
        Dim value3 As String = param(4)
        Dim value4 As String = param(5)
        Dim value5 As String = param(6)
        Dim value6 As String = param(7)
        Dim jieguo As String = param(8).Trim

        If jieguo = "合" Then
            jieguo = "OK"
        ElseIf jieguo = "微" Then
            jieguo = "SD"
        ElseIf jieguo = "轻" Then
            jieguo = "M1"
        ElseIf jieguo = "中" Then
            jieguo = "M2"
        ElseIf jieguo = "重" Then
            jieguo = "M3"
        ElseIf jieguo = "误" Then
            jieguo = "NG"
        ElseIf jieguo = "警" Then
            jieguo = "JN"
        End If

        Dim zbenchmark_type As String = param(9)
        Dim zbenchmark_value1 As String = param(10)
        Dim zbenchmark_value2 As String = param(11)
        Dim zbenchmark_value3 As String = param(12)

        Dim dis_no As String = param(13)
        Dim beizhu As String = param(14)
        Dim checkTimes As String = param(15)
        Dim usercd As String = param(16)

        Try
            Dim ResultDA As New ResultDA
            ResultDA.UpdateResultDetail(result_id, check_id, dis_no, checkTimes, value1, value2, value3, value4, value5, value6, jieguo, beizhu, zbenchmark_type, zbenchmark_value1, zbenchmark_value2, zbenchmark_value3, usercd)
            Response.Write(Com.GetResultMsg(result_id))
        Catch ex As Exception
            Response.Write("NG")
        End Try

        Response.End()

        Return ""

    End Function

End Class
