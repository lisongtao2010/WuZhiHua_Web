Imports Lixil.AvoidMissSystem.Utilities
''' <summary>
''' DBアクセス時の処理を記述する。
''' </summary>
''' <remarks>NotInheritable:インスタンスを生成させないようにする
'''  初回アクセス時にのみ起動し、DB接続文字列を設定する。
''' </remarks>
Public NotInheritable Class DataAccessManager

    Private Shared server As String = GetConfig.GetConfigVal("SERVER")
    Private Shared dataname As String = GetConfig.GetConfigVal("DataName")
    Private Shared uid As String = GetConfig.GetConfigVal("UID")
    Private Shared pwd As String = GetConfig.GetConfigVal("PWD")

    'Private Shared connStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionString").ConnectionString
    'Private Shared connStr As String = "Data Source= " & server & ";Initial Catalog=" & dataname & ";Persist Security Info=True;user=" & uid & ";password=" & pwd & ""


    ''' <summary>
    ''' DB接続文字列の設定
    ''' </summary>
    ''' <remarks></remarks>
     Public Shared Function ConnStr() As String
        Return System.Configuration.ConfigurationManager.ConnectionStrings("connectionString").ConnectionString
    End Function


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

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
