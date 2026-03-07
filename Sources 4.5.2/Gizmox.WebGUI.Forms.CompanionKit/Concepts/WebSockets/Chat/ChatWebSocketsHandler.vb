Imports Gizmox.WebGUI.Common.Interfaces
Imports Gizmox.WebGUI.Forms.Client

Namespace WebSocketsSampleAppsVB
    Public Class ChatWebSocketsHandler
        Implements IWebSocketHandler
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
                Return False
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
                Return True
            End Get
        End Property


        Public Sub WebSocketInitialized() Implements IWebSocketHandler.WebSocketInitialized
            'Not implemented. Retained for interface compatibility. 
        End Sub
    End Class

End Namespace