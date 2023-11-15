Imports Microsoft.VisualBasic

Public Class DataAccessManager

    Public Shared connStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionString").ConnectionString

    ''' <summary>
    ''' DB接続文字列の取得
    ''' </summary>
    ''' <returns>DB接続文字列</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Connection() As String
        Get
            'Return "Data Source=DAM302;Initial Catalog=AvoidMiss;Persist Security Info=True;user=sa;password=tostem"
            'Return "Data Source=ot0346;Initial Catalog=AvoidMiss;Persist Security Info=True;user=sa;password=a123456!"
            Return connStr
        End Get
    End Property

End Class
