Imports Lixil.AvoidMissSystem.DataAccess
Imports Lixil.AvoidMissSystem.Utilities
Imports Lixil.AvoidMissSystem.Utilities.Consts
Imports System.Transactions

Public Class IndexBizLogic
    Dim indexDA As New IndexDA
    Dim bcCommon As CommonBizLogic

    ''' <summary>
    ''' 根据区分来检索採番表
    ''' </summary>
    ''' <param name="typeKbn">区分</param>
    ''' <returns>如果返回空则代表採番失败，否则返回番号</returns>
    ''' <remarks></remarks>
    Public Function GetIndex(ByVal typeKbn As String) As String
        Dim no As Integer = 0
        Dim maxNo As Integer = 0
        Dim maxByte As Integer = 0
        Dim dateNow As String = String.Empty

        Select Case typeKbn
            Case Consts.TYPEKBN.CHECK_RESULT
                maxByte = 5 '检查结果表
            Case Consts.TYPEKBN.CLASSIFY, Consts.TYPEKBN.TYPE
                maxByte = 8 '分类表,类型表
            Case Consts.TYPEKBN.CHECK
                maxByte = 9 '检查表(基础表)
            Case Else
                maxByte = 7
        End Select

        Try
            Dim dt As DataTable
            If typeKbn = Consts.TYPEKBN.CHECK_RESULT OrElse typeKbn = Consts.TYPEKBN.LOG Then
                '检查结果时
                bcCommon = New CommonBizLogic
                dateNow = String.Format("{0:yyyyMMdd}", bcCommon.GetSystemDate())
                dt = indexDA.GetIndex(typeKbn, dateNow)
            Else
                dt = indexDA.GetIndex(typeKbn)
            End If

            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    no = CInt(.Item("no"))
                    maxNo = CInt(.Item("max_no"))
                End With

                If no + 1 > maxNo Then
                    '到达了最大番号
                    Return DBErro.GetIndexMaxError
                End If

                no = no + 1
                If UpdateIndex(typeKbn, no.ToString, dateNow) = False Then
                    '採番更新失败
                    Return DBErro.UpdateError
                Else
                    Return dateNow & no.ToString.PadLeft(maxByte, "0"c)
                End If

            Else
                no = 0
                maxNo = 99999999
                If InsertIndex(typeKbn, no.ToString, maxNo.ToString(), dateNow) = False Then
                    '採番登录失败
                    Return DBErro.InserError
                Else
                    Return dateNow & no.ToString.PadLeft(maxByte, "0"c)
                End If
            End If
        Catch ex As Exception
            Return DBErro.GetIndexError
        End Try

        Return String.Empty

    End Function

    ''' <summary>
    ''' 插入採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <param name="no">当前值</param>
    ''' <param name="maxNo">最大值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIndex(ByVal typeKbn As String, ByVal no As String, ByVal maxNo As String, ByVal dateNow As String) As Boolean
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction

        Try
            If indexDA.InsertIndex(PerDbTraneAction, typeKbn, no, maxNo, dateNow) = 1 Then
                PerDbTraneAction.CloseCommit()
                Return True
            Else
                PerDbTraneAction.CloseRollback()
                Return False
            End If
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            Return False
        End Try

    End Function

    ''' <summary>
    ''' 更改採番表
    ''' </summary>
    ''' <param name="typeKbn">表区分</param>
    ''' <param name="no">当前值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIndex(ByVal typeKbn As String, ByVal no As String, ByVal dateNow As String) As Boolean
        Using scope As New TransactionScope(TransactionScopeOption.Required)
            Try
                If indexDA.UpdateIndex(typeKbn, no, dateNow) = 1 Then
                    scope.Complete()
                    Return True
                Else
                    scope.Dispose()
                    Return False
                End If
            Catch ex As Exception
                scope.Dispose()
                Return False
            End Try
        End Using
    End Function

End Class
