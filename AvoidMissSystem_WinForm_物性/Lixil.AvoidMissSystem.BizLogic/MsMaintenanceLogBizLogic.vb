Imports Lixil.AvoidMissSystem.DataAccess

Public Class MsMaintenanceLogBizLogic
    Dim da As New MsMaintenanceLogDA
    ''' <summary>
    ''' LogêMëßéÊìæ
    ''' </summary>
    ''' <param name="fromDate"></param>
    ''' <param name="toDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSearchData(ByVal fromDate As Date, ByVal toDate As Date) As DataTable
        Return da.GetSearchData(fromDate, toDate).Tables(0)
    End Function
End Class
