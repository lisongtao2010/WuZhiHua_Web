Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data

Public Class CheckIndex



    ''' <summary>
    ''' 根据区分来检索採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeNewIndex(ByVal typeKbn As String, ByVal userCd As String, ByVal dateNow As String, Optional ByVal noLength As Integer = 5) As String

        SyncLock "GetIndex"

            Dim sb As New StringBuilder
            Dim ds As New DataSet
            Dim paramList As New List(Of SqlParameter)

            With sb
                '.AppendLine("DECLARE @type_kbn VARCHAR(2)")
                '.AppendLine("DECLARE @index_date VARCHAR(8)")
                '.AppendLine("")
                '.AppendLine("SET @type_kbn = 'CR'")
                '.AppendLine("SET @index_date = '20150509'")
                '.AppendLine("")

                .AppendLine("IF EXISTS(SELECT 1")
                .AppendLine("          FROM   t_index WITH(UPDLOCK)")
                .AppendLine("          WHERE  type_kbn = @type_kbn")
                .AppendLine("                 AND index_date = @index_date)")
                .AppendLine("  BEGIN")
                .AppendLine("      UPDATE t_index WITH(UPDLOCK)")
                .AppendLine("      SET    [no] = (SELECT [no] + 1")
                .AppendLine("                     FROM   t_index WITH(UPDLOCK)")
                .AppendLine("                     WHERE  type_kbn = @type_kbn")
                .AppendLine("                            AND index_date = @index_date)")
                .AppendLine("      WHERE  type_kbn = @type_kbn")
                .AppendLine("  END")
                .AppendLine("ELSE")
                .AppendLine("  BEGIN")
                .AppendLine("      INSERT INTO t_index WITH(UPDLOCK)")
                .AppendLine("                  (type_kbn,")
                .AppendLine("                   index_date,")
                .AppendLine("                   [no],")
                .AppendLine("                   max_no)")
                .AppendLine("      VALUES     ( @type_kbn,")
                .AppendLine("                   @index_date,")
                .AppendLine("                   1,")
                .AppendLine("                   '99999999' )")
                .AppendLine("  END")

                .AppendLine("SELECT [no]")
                .AppendLine("FROM   t_index")
                .AppendLine("WHERE  type_kbn = @type_kbn")
                .AppendLine("       AND index_date = @index_date")

            End With
            paramList.Add(MakeParam("@index_date", SqlDbType.VarChar, 8, dateNow))
            'パラメータ設定
            paramList.Add(MakeParam("@type_kbn", SqlDbType.Char, 2, typeKbn))
            FillDataset(DataAccessManager.Connection, CommandType.Text, sb.ToString(), ds, "t_index", paramList.ToArray)

            Dim no As String = Now.ToString("yyyyMMdd") & CInt(ds.Tables(0).Rows(0).Item("no").ToString).ToString.PadLeft(noLength, "0"c)

            If noLength <= 5 Then
                Rireki.InsRireki("Index作成", no, "", "", "", "", userCd)
            End If

            Return no

        End SyncLock


    End Function







End Class
