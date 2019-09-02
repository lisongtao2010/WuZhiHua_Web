Imports System.Net
Imports System.Net.Sockets

Namespace Common
    Public Class MonitorInfo
        Public cCancel As Boolean
        Public Property Cancel() As Boolean
            Get
                Return cCancel
            End Get
            Set(ByVal value As Boolean)
                cCancel = value
            End Set
        End Property

        Private _Connections As List(Of ConnectionInfo)
        Public ReadOnly Property Connections() As List(Of ConnectionInfo)
            Get
                Return _Connections
            End Get
        End Property

        Private _Listener As TcpListener
        Public ReadOnly Property Listener() As TcpListener
            Get
                Return _Listener
            End Get
        End Property

        Public Sub New(ByVal tcpListener As TcpListener, ByVal connectionInfoList As List(Of ConnectionInfo))
            _Listener = tcpListener
            _Connections = connectionInfoList
        End Sub
    End Class
End Namespace