Imports Lixil.AvoidMissSystem.DataAccess

Public Class SimpleBizLogic
    Dim testDa As New SimpleDA


    Public Function GetTestData() As DataSet
        Return testDa.TestDB()
    End Function

End Class
