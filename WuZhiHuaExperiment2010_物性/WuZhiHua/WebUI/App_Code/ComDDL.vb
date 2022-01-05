Imports Microsoft.VisualBasic
Imports EMAB = Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports MyMethod = System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.Data
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Configuration.ConfigurationSettings
Imports System.Collections.Generic
Imports System.IO
'Imports SqlHelper.SqlHelper
Imports SqlHelper

Public Class ComDDL

    ''' <summary>
    ''' 图片数据To Byte
    ''' </summary>
    ''' <param name="Imagepath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function imageToByte(ByVal Imagepath As String) As Byte()
        If System.IO.File.Exists(Imagepath) Then '检查图片路径是否正确
            Dim fs As FileStream = New FileStream(Imagepath, FileMode.Open)
            Dim br As BinaryReader = New BinaryReader(fs)
            Dim imageByte() As Byte = br.ReadBytes(CInt(fs.Length))
            br.Close()
            fs.Close()
            Return imageByte
        Else
            Return Nothing
        End If
    End Function

    Public Function InsMPictureChk(ByVal chk_id As String, _
                                   ByVal path As String, _
                                   ByVal user_cd As String) As Boolean



        'EMAB　ＥＲＲ
        'SQLコメント ByRef picCon As Byte()
        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文

        sb.AppendLine("INSERT INTO  m_picture_chk")
        sb.AppendLine("(")
        sb.AppendLine("chk_id")                                                    '图片ID
        sb.AppendLine(", pic_conn")                                                '图片内容
        sb.AppendLine(", ins_user")
        sb.AppendLine(", ins_date")
        sb.AppendLine(")")

        sb.AppendLine("VALUES(")
        sb.AppendLine("@chk_id")                                                       '图片ID
        sb.AppendLine(", @pic_conn")                                                   '图片内容
        sb.AppendLine(", '" & user_cd & "'")
        sb.AppendLine(", getdate()")
        sb.AppendLine(")")
        'バラメタ格納
        'PARAM
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 20, chk_id))
        paramList.Add(MakeParam("@pic_conn", SqlDbType.VarBinary, -1, imageToByte(path)))

        ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString(), paramList.ToArray)

        Return True

    End Function




    Public Function DelMPictureChk(ByVal chk_id As String, ByVal idx As String) As Boolean



        'EMAB　ＥＲＲ
        'SQLコメント ByRef picCon As Byte()
        '--**テーブル： : m_picture
        Dim sb As New StringBuilder
        'SQL文

        sb.AppendLine("Delete ")

        sb.AppendLine("FROM m_picture_chk")
        sb.AppendLine("WHERE idx=" & idx & "")

        sb.AppendLine("AND chk_id='" & chk_id & "'")   '图片ID

        ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

        Return True

    End Function

    Public Function SelChkPicture(ByVal chk_id As String) As DataTable
        'SQLコメント
        '--**テーブル：图片MS : m_picture
        Dim sb As New StringBuilder
        'SQL文
        sb.AppendLine("SELECT")
        sb.AppendLine("*")                                                    '图片ID

        sb.AppendLine("FROM m_picture_chk")
        sb.AppendLine("WHERE 1=1")

        sb.AppendLine("AND chk_id=@chk_id")   '图片ID



        'バラメタ格納
        Dim paramList As New List(Of SqlParameter)
        paramList.Add(MakeParam("@chk_id", SqlDbType.VarChar, 20, chk_id))

        Dim dsInfo As New Data.DataSet
        FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), dsInfo, "SelChkPicture", paramList.ToArray)

        'If dsInfo.Tables(0).Rows.Count > 0 Then
        '    Return dsInfo.Tables(0).Rows(0).Item("pic_conn")
        'Else
        '    Return ""
        'End If

        Return dsInfo.Tables(0)

    End Function

    ''' <summary>
    ''' GetIntValue
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIntValue(ByVal v As Object) As Object

        If v Is Nothing OrElse v Is DBNull.Value OrElse v.ToString = "" Then
            Return 0
        Else
            Return Convert.ToInt32(v)
        End If
    End Function





End Class
