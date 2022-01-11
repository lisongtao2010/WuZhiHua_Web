Imports Microsoft.VisualBasic
Imports Lixil.AvoidMissSystem.Utilities

Namespace Common

    ''' <summary>
    ''' ログイン情報を保持するクラスです。
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class LoginInfo

#Region "プロパティ"

        Public _userName As String
        ''' <summary>
        ''' LoginId
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UserName() As String
            Get
                Return _userName
            End Get
            Set(ByVal value As String)
                _userName = value
            End Set
        End Property

        Public _userId As String
        ''' <summary>
        ''' user_id
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UserId() As String
            Get
                Return _userId
            End Get
            Set(ByVal value As String)
                _userId = value
            End Set
        End Property

        Public _authority As ArrayList
        ''' <summary>
        ''' Authority
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Authority() As ArrayList
            Get
                Return _authority
            End Get
            Set(ByVal value As ArrayList)
                _authority = value
            End Set
        End Property

        Public _isAdmin As Boolean
        ''' <summary>
        ''' 是否为管理员
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsAdmin() As Boolean
            Get
                Return _isAdmin
            End Get
            Set(ByVal value As Boolean)
                _isAdmin = value
            End Set
        End Property

#End Region

    End Class

End Namespace