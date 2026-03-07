Imports Newtonsoft.Json
Imports Gizmox.WebGUI.Forms

Namespace WebSocketsSampleAppsVB
    Public Class CompanionKitWebSocketMessage
        ''' <summary>
        ''' Gets or sets the type of the object.
        ''' </summary>
        ''' <value>
        ''' The type of the object.
        ''' </value>
        Public Property ObjectType() As Type
            Get
                Return m_ObjectType
            End Get
            Set(ByVal value As Type)
                m_ObjectType = value
            End Set
        End Property
        Private m_ObjectType As Type

        Public Sub New()
            Me.ObjectType = Me.[GetType]()
        End Sub

        ''' <summary>
        ''' Sends the message.
        ''' </summary>
        ''' <param name="objMessage">The obj message.</param>
        Public Shared Sub SendMessage(ByVal objMessage As CompanionKitWebSocketMessage)
            'Serialize object to string 
            Dim strMessage As String = JsonConvert.SerializeObject(objMessage)
            'Sends serialized message via WebSockets
            Application.WebSockets.Send(Application.WebSockets.ConnectionId, strMessage, SendType.All)
        End Sub
    End Class
End Namespace