Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports Itis.ApplicationBlocks.Data.SQLHelper
Imports Itis.ApplicationBlocks.ExceptionManagement.UnTrappedExceptionManager
Imports System.Collections.Generic
Imports System.Data
Public Class Rireki

    Public Shared Sub InsRireki(ByVal dousa As String _
                                    , ByVal result_id As String _
                                    , ByVal goods_id As String _
                                    , ByVal goods_cd As String _
                                    , ByVal make_number As String _
                                    , ByVal mark As String _
                                    , ByVal user As String _
                                      )


        Dim result As Integer
        Dim sb As New StringBuilder

        With sb
            .AppendLine("INSERT INTO [t_sousa_rireki]")
            .AppendLine("           ([dousa]")
            .AppendLine("           ,[result_id]")
            .AppendLine("           ,[goods_id]")
            .AppendLine("           ,[goods_cd]")
            .AppendLine("           ,[make_number]")
            .AppendLine("           ,[mark]")
            .AppendLine("           ,[insert_user]")
            .AppendLine("           ,[insert_date])")
            .AppendLine("     VALUES")
            .AppendLine("           ('" & dousa & "'")
            .AppendLine("           ,'" & result_id & "'")
            .AppendLine("           ,'" & goods_id & "'")
            .AppendLine("           ,'" & goods_cd & "'")
            .AppendLine("           ,'" & make_number & "'")
            .AppendLine("           ,'" & mark & "'")
            .AppendLine("           ,'" & user & "'")
            .AppendLine("           ,getdate())")
        End With

        '挿入の実行
        result = ExecuteNonQuery(DataAccessManager.Connection, CommandType.Text, sb.ToString())

    End Sub

End Class
