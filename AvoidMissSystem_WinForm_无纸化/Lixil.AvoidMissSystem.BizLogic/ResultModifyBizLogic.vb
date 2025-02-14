Imports Lixil.AvoidMissSystem.DataAccess
Public Class ResultModifyBizLogic

    Dim da As New ResultModifyDA
    Dim comDa As New CommonDA

    Public Function UpdFirstCheck(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, ByVal tongyong_cd As String) As Integer
        Return da.UpdFirstCheck(PersonalDbTransactionScopeAction, tongyong_cd)

    End Function

    Public Function Gettongyong_cd(ByVal cd As String) As String
        Return da.Gettongyong_cd(cd)
    End Function

    Public Function GetFirstCheck(ByVal cd As String) As String
        Return da.GetFirstCheck(cd)
    End Function

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
    ''' 根据检索条件取得信息
    ''' </summary>
    ''' <param name="hsSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSearchData(ByVal hsSearch As Hashtable) As DataSet

        Return da.GetSearchData(hsSearch)
    End Function


    Public Function Deletet_check_result(ByVal id As String) As Boolean

        Return da.Deletet_check_result(id)

    End Function
    ''' <summary>
    ''' 取得图片内容
    ''' </summary>
    ''' <param name="strPicId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPictureMsgById(ByVal strPicId As String) As DataSet
        Return da.GetPictureMsgById(strPicId)
    End Function

    ''' <summary>
    ''' '检查结果的修改
    ''' </summary>
    ''' <param name="strId"></param>
    ''' <param name="strResult"></param>
    ''' <param name="strRemake"></param>
    ''' <param name="strUserId"></param>
    ''' <param name="upDate"></param>
    ''' <param name="strState"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateResult(ByVal PersonalDbTransactionScopeAction As PersonalDataAccess.PersonalDbTransactionScopeAction, _
ByVal strId As String, ByVal strResult As String, ByVal strRemake As String, ByVal strUserId As String, ByVal upDate As DateTime, ByVal strState As String) As Integer

        Return da.UpdateResult(PersonalDbTransactionScopeAction, strId, strResult, strRemake, strUserId, upDate, strState)
    End Function


    ''' <summary>
    ''' 根据检商品Id，查结果ID取得所有所有信息
    ''' </summary>
    ''' <param name="strGoodsId"></param>
    ''' <param name="strResultId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllDetaileById(ByVal strGoodsId As String, ByVal strResultId As String) As DataSet
        Return da.GetAllDetaileById(strGoodsId, strResultId)
    End Function
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
        Return da.InsertLog(PersonalDbTransactionScopeAction, strId, strResultId, strUserId, upDate)
    End Function
End Class
