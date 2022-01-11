''' <summary>
''' ステート情報管理
''' アプリケーション実装者はこのクラスを直接利用することはありません
''' </summary>
''' <remarks></remarks>
Public Class StateManager
    ' シングルトンで保持
    Private _state As Hashtable = New Hashtable()

    Public ReadOnly Property State() As Hashtable
        Get
            Return _state
        End Get
    End Property

    Private Sub New()
    End Sub

    Private Shared soloInstance As New StateManager

    Public Shared ReadOnly Property Instance() As StateManager
        Get
            Return soloInstance
        End Get
    End Property
End Class
