Imports Lixil.AvoidMissSystem.DataAccess
Imports Lixil.AvoidMissSystem.Utilities
Imports Lixil.AvoidMissSystem.Utilities.Consts
Imports System.Transactions
Public Class ShouInputCheckResultBizLogic

    Public Function GetSearchData(ByVal ID As String, ByVal syainCd As String, ByVal result As String, ByVal makenumber As String) As DataSet

        'Dim IndexBizLogic As New IndexBizLogic
        'Dim idx As String = IndexBizLogic.GetIndex(Consts.TYPEKBN.CHECK_RESULT)


        Dim ShouInputCheckResultDA As New ShouInputCheckResultDA
        Return ShouInputCheckResultDA.GetSearchData(ID, syainCd, result, makenumber)


    End Function


    Public Function InsData(ByVal ID As String, ByVal syainCd As String, ByVal result As String, ByVal makenumber As String) As Boolean

        Dim IndexBizLogic As New IndexBizLogic
        Dim idx As String = IndexBizLogic.GetIndex(Consts.TYPEKBN.CHECK_RESULT)

        Dim ShouInputCheckResultDA As New ShouInputCheckResultDA
        Return ShouInputCheckResultDA.InsData(idx, syainCd, result, makenumber)


    End Function


    Public Function InsDataZhijie(ByVal ID As String, ByVal syouhincd As String, ByVal syainCd As String, ByVal result As String, ByVal makenumber As String, ByVal line As String) As Boolean

        Dim IndexBizLogic As New IndexBizLogic
        Dim idx As String = IndexBizLogic.GetIndex(Consts.TYPEKBN.CHECK_RESULT)

        Dim ShouInputCheckResultDA As New ShouInputCheckResultDA
        Return ShouInputCheckResultDA.InsDataZhijie(idx, syouhincd, syainCd, result, makenumber, line)


    End Function

    Public Function Gett_check_result(ByVal makenumber As String) As DataTable
        Dim ShouInputCheckResultDA As New ShouInputCheckResultDA
        Return ShouInputCheckResultDA.Gett_check_result(makenumber)

    End Function

    Public Function GetGoodID(ByVal GoodCd As String) As String
        Dim ShouInputCheckResultDA As New ShouInputCheckResultDA
        Return ShouInputCheckResultDA.GetGoodID(GoodCd)
    End Function

End Class
