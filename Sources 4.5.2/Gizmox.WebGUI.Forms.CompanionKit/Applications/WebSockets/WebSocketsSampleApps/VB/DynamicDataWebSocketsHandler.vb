Imports Gizmox.WebGUI.Common.Interfaces
Imports System.Threading
Imports Gizmox.WebGUI.Forms.Client
Imports Gizmox.WebGUI.Forms
Imports Newtonsoft.Json
Imports Gizmox.WebGUI.Common.WebSockets

Namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsVB
    Public Class DynamicDataWebSocketsHandler
        Implements IWebSocketHandler
        Private mobjWorkThread As Thread
        ''' <summary>
        ''' Gets or sets the page.
        ''' </summary>
        ''' <value>
        ''' The page.
        ''' </value>
        Public Property Page() As Object
            Get
                Return m_Page
            End Get
            Set(ByVal value As Object)
                m_Page = value
            End Set
        End Property
        Private m_Page As Object

        ''' <summary>
        ''' Clients the handle.
        ''' </summary>
        ''' <param name="objSender">The obj sender.</param>
        ''' <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        Public Sub ClientHandle(ByVal objSender As Object, ByVal objArgs As ClientEventArgs) Implements IWebSocketHandler.ClientHandle
            'Calls PageClientHandle method from Page instance
            Dim mobjPage = TryCast(Page, IPageHandler)
            mobjPage.PageClientHandle(objSender, objArgs)
        End Sub

        ''' <summary>
        ''' Handles the specified STR sender conection id.
        ''' </summary>
        ''' <param name="strSenderConectionId">The STR sender conection id.</param>
        ''' <param name="strData">The STR data.</param>
        Public Sub Handle(ByVal strSenderConectionId As String, ByVal strData As String) Implements IWebSocketHandler.Handle
            'Calls PageHandle method from Page instance
            Dim mobjPage = TryCast(Page, IPageHandler)
            mobjPage.PageHandle(strSenderConectionId, strData)
        End Sub

        ''' <summary>
        ''' Gets a value indicating whether this instance is client handler.
        ''' </summary>
        ''' <value>
        ''' <c>true</c> if this instance is client handler; otherwise, <c>false</c>.
        ''' </value>
        Public ReadOnly Property IsClientHandler() As Boolean Implements IWebSocketHandler.IsClientHandler
            Get
                Return True
            End Get
        End Property

        ''' <summary>
        ''' Gets a value indicating whether this instance is server handler.
        ''' </summary>
        ''' <value>
        ''' <c>true</c> if this instance is server handler; otherwise, <c>false</c>.
        ''' </value>
        Public ReadOnly Property IsServerHandler() As Boolean Implements IWebSocketHandler.IsServerHandler
            Get
                Return False
            End Get
        End Property


        Public Sub WebSocketInitialized() Implements IWebSocketHandler.WebSocketInitialized

            'Define args for thread handler
            Dim mobjArgs = New WebSocketState() With { _
             .Service = Application.WebSockets, _
             .ConnectionId = Application.WebSockets.ConnectionId _
            }
            'Create and start thread instance
            mobjWorkThread = New Thread(AddressOf ThreadHandler)
            mobjWorkThread.Start(mobjArgs)
        End Sub

        ''' <summary>
        ''' Thread's handler that simulatse time consuming operation.
        ''' </summary>
        ''' <param name="objArgs">The obj args.</param>
        Public Sub ThreadHandler(ByVal objArgs As Object)

            Dim mobjState = TryCast(objArgs, WebSocketState)
            Dim strConnectionId As String = mobjState.ConnectionId

            While True
                'Simulate time consuming operation.
                Thread.Sleep(1000)
                ' Create new message
                Dim mobjMessage As New DynamicDataSampleMessage()
                Dim mobjRandom As New Random()
                'Fill message with random values
                For i As Integer = 0 To mobjMessage.RandomValues.Length - 1
                    mobjMessage.RandomValues(i) = mobjRandom.[Next](0, 101)
                Next
                'Send the message
                mobjState.Service.Send(strConnectionId, JsonConvert.SerializeObject(mobjMessage), SendType.Self)
            End While
        End Sub

        Public Sub Abort()
            'Stop working thread
            mobjWorkThread.Abort()
        End Sub
    End Class

    Class WebSocketState
        ''' <summary>
        ''' Gets or sets the service.
        ''' </summary>
        ''' <value>
        ''' The service.
        ''' </value>
        Public Property Service() As WebSocketService
            Get
                Return m_Service
            End Get
            Set(ByVal value As WebSocketService)
                m_Service = value
            End Set
        End Property
        Private m_Service As WebSocketService

        ''' <summary>
        ''' Gets or sets the connection id.
        ''' </summary>
        ''' <value>
        ''' The connection id.
        ''' </value>
        Public Property ConnectionId() As String
            Get
                Return m_ConnectionId
            End Get
            Set(ByVal value As String)
                m_ConnectionId = value
            End Set
        End Property
        Private m_ConnectionId As String
    End Class

End Namespace