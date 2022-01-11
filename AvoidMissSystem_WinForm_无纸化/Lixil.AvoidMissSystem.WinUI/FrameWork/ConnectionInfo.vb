Imports System.Net
Imports System.Net.Sockets

Namespace Common
Public Class ConnectionInfo
        Private _AppendMethod As Action(Of String)
        Public ReadOnly Property AppendMethod() As Action(Of String)
            Get
                Return _AppendMethod
            End Get
        End Property

        Private _Client As TcpClient
        Public ReadOnly Property Client() As TcpClient
            Get
                Return _Client
            End Get
        End Property

        Private _Stream As NetworkStream
        Public ReadOnly Property Stream() As NetworkStream
            Get
                Return _Stream
            End Get
        End Property

        Private _LastReadLength As Integer
        Public ReadOnly Property LastReadLength() As Integer
            Get
                Return _LastReadLength
            End Get
        End Property

        Private _Buffer(63) As Byte

        Public Sub New(ByVal address As IPAddress, ByVal port As Integer, ByVal append As Action(Of String))
            _AppendMethod = append
            _Client = New TcpClient
            _Client.Connect(address, port)
            _Stream = _Client.GetStream
        End Sub

        Public Sub AwaitData()
            _Stream.BeginRead(_Buffer, 0, _Buffer.Length, AddressOf DoReadData, Me)
        End Sub

        Public Sub Close()
            If _Client IsNot Nothing Then _Client.Close()
            _Client = Nothing
            _Stream = Nothing
        End Sub

        Private Sub DoReadData(ByVal result As IAsyncResult)
            Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
            Try
                If info._Stream IsNot Nothing AndAlso info._Stream.CanRead Then
                    info._LastReadLength = info._Stream.EndRead(result)
                    If info._LastReadLength > 0 Then
                        Dim message As String = System.Text.Encoding.ASCII.GetString(info._Buffer)
                        info._AppendMethod(message)
                    End If
                    info.AwaitData()
                End If
            Catch ex As Exception
                info._LastReadLength = -1
                info._AppendMethod(ex.Message)
            End Try
        End Sub
    End Class
End Namespace