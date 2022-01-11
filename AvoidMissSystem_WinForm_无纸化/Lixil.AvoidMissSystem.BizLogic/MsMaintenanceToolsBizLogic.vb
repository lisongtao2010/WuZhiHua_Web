Imports System.Transactions
Imports Lixil.AvoidMissSystem.DataAccess
Imports Lixil.AvoidMissSystem.Utilities.Consts

''' <summary>
''' 治具MS维护
''' </summary>
''' <remarks></remarks>
Public Class MsMaintenanceToolsBizLogic
    Private toolsDa As New MsMaintenanceToolsDA
    Private ComBizLogic As CommonBizLogic
    Public strDBError As String = String.Empty
    Dim comDa As New CommonDA

    ''' <summary>
    ''' 部门取得
    ''' </summary>
    ''' <param name="strUserID"></param>
    ''' <param name="isAdmin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDepartment(ByVal strUserID As String, ByVal isAdmin As Boolean) As DataSet
        If isAdmin Then
            Return comDa.GetAdminDepartment()
        Else
            Return comDa.GetDepartment(strUserID)
        End If

    End Function

    ''' <summary>
    ''' 治具信息取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTools(ByVal dicSearch As Dictionary(Of String, String)) As DataSet
        Return toolsDa.GetTools(dicSearch)
    End Function

    ''' <summary>
    ''' 商品CD取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGoodsCdList(ByVal strToolId As String) As DataSet
        Return toolsDa.GetGoodsCdList(strToolId)
    End Function

    ''' <summary>
    ''' 治具信息添加
    ''' </summary>
    ''' <param name="dicTools"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertTools(ByVal dicTools As Dictionary(Of String, String)) As Boolean
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction

        Try
            If toolsDa.InsertTools(PerDbTraneAction, dicTools) <> 1 Then
                PerDbTraneAction.CloseRollback()
                Return False
            End If
            PerDbTraneAction.CloseCommit()
            Return True
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 治具信息
    ''' </summary>
    ''' <param name="dtGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateTools(ByVal dtGrid As DataTable, ByVal strUser As String, _
                                ByVal updPara As Dictionary(Of String, String)) As Boolean
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction


        Try
            Dim sysTime As DateTime
            Dim dicTools As New Dictionary(Of String, String)
            ComBizLogic = New CommonBizLogic
            sysTime = ComBizLogic.GetSystemDate()
            For i As Integer = 0 To dtGrid.Rows.Count - 1
                dicTools.Clear()
                With dtGrid.Rows(i)
                    dicTools.Add("ID", Convert.ToString(.Item("id")))
                    If updPara.ContainsKey(TOOLSNO) Then
                        dicTools.Add("ToolsNo", updPara(TOOLSNO))
                    Else
                        dicTools.Add("ToolsNo", Convert.ToString(.Item("tools_no")))
                    End If
                    If updPara.ContainsKey(DEPARTMENT) Then
                        dicTools.Add("DepartmentCd", updPara(DEPARTMENT))
                    Else
                        dicTools.Add("DepartmentCd", Convert.ToString(.Item("department_cd")))
                    End If
                    If updPara.ContainsKey(DISTINGUISH) Then
                        dicTools.Add("Distinguish", updPara(DISTINGUISH))
                    Else
                        dicTools.Add("Distinguish", Convert.ToString(.Item("distinguish")))
                    End If
                    If updPara.ContainsKey(BARCODEFLG) Then
                        dicTools.Add("BarcodeFlg", updPara(BARCODEFLG))
                    Else
                        dicTools.Add("BarcodeFlg", Convert.ToString(.Item("barcode_flg")))
                    End If
                    If updPara.ContainsKey(BARCODE) Then
                        dicTools.Add("Barcode", updPara(BARCODE))
                    Else
                        dicTools.Add("Barcode", Convert.ToString(.Item("barcode")))
                    End If
                    If updPara.ContainsKey(REMARKS) Then
                        dicTools.Add("Remarks", updPara(REMARKS))
                    Else
                        dicTools.Add("Remarks", Convert.ToString(.Item("remarks")))
                    End If
                    dicTools.Add("User", strUser)
                    dicTools.Add("SysTime", sysTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                End With

                If toolsDa.UpdateTools(PerDbTraneAction, dicTools) <> 1 Then
                    PerDbTraneAction.CloseRollback()
                    Return False
                End If
            Next
            PerDbTraneAction.CloseCommit()
            Return True
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 治具信息
    ''' </summary>
    ''' <param name="dtGrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteTools(ByVal dtGrid As DataTable, ByVal strUser As String) As Boolean
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction


        Try
            Dim sysTime As DateTime
            Dim dicTools As New Dictionary(Of String, String)
            ComBizLogic = New CommonBizLogic
            sysTime = ComBizLogic.GetSystemDate()
            For i As Integer = 0 To dtGrid.Rows.Count - 1
                dicTools.Clear()
                With dtGrid.Rows(i)
                    dicTools.Add("ID", Convert.ToString(.Item("id")))
                    dicTools.Add("User", strUser)
                    dicTools.Add("SysTime", sysTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                    If toolsDa.DeleteTools(PerDbTraneAction, dicTools) <> 1 Then
                        PerDbTraneAction.CloseRollback()
                        Return False
                    End If
                End With
            Next

            PerDbTraneAction.CloseCommit()
            Return True
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 治具信息
    ''' </summary>
    ''' <param name="dtExcel"></param>
    ''' <param name="strUser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsOrUpdTools(ByVal dtExcel As DataTable, ByVal strUser As String, _
                                  ByRef afterUpdDt As DataTable) As Boolean
        Dim sysTime As DateTime
        Dim strID As String
        Dim bizIndex As IndexBizLogic = Nothing
        Dim PerDbTraneAction As New PersonalDataAccess.PersonalDbTransactionScopeAction

        Try
            strDBError = String.Empty
            ComBizLogic = New CommonBizLogic
            sysTime = ComBizLogic.GetSystemDate()
            For i As Integer = 0 To dtExcel.Rows.Count - 1
                strID = Convert.ToString(dtExcel.Rows(i).Item("ID"))
                If String.IsNullOrEmpty(strID) Then
                    If bizIndex Is Nothing Then
                        bizIndex = New IndexBizLogic
                    End If

                    strID = bizIndex.GetIndex(TYPEKBN.TOOLS)
                    Select Case strID
                        Case DBErro.InserError
                            strDBError = strID
                            PerDbTraneAction.CloseRollback()
                            Return False
                        Case DBErro.UpdateError
                            strDBError = strID
                            PerDbTraneAction.CloseRollback()
                            Return False
                        Case DBErro.GetIndexError
                            strDBError = strID
                            PerDbTraneAction.CloseRollback()
                            Return False
                        Case DBErro.GetIndexMaxError
                            strDBError = strID
                            PerDbTraneAction.CloseRollback()
                            Return False
                    End Select

                    dtExcel.Rows(i).Item("ID") = strID
                    If toolsDa.InsertImport(PerDbTraneAction, dtExcel.Rows(i), strUser, sysTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) <> 1 Then
                        PerDbTraneAction.CloseRollback()
                        Return False
                    End If
                Else
                    If toolsDa.UpdateImport(PerDbTraneAction, dtExcel.Rows(i), strUser, sysTime.ToString("yyyy-MM-dd HH:mm:ss.fff")) <> 1 Then
                        PerDbTraneAction.CloseRollback()
                        Return False
                    Else
                        '更新的时候，更新成功的数据保存到更新后的Datatable
                        afterUpdDt.Rows.Add(dtExcel.Rows(i).ItemArray)
                    End If
                End If
            Next
            PerDbTraneAction.CloseCommit()
            Return True
        Catch ex As Exception
            PerDbTraneAction.CloseRollback()
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 治具ID存在判断
    ''' </summary>
    ''' <param name="strID">治具ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExistsToolsID(ByVal strID As String) As DataTable

        Return toolsDa.GetToolsID(strID).Tables("mTools")

    End Function
End Class
