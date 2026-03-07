Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsVB
    Partial Public Class DynamicDataForm
        Inherits Form
        Implements IPageHandler

        Public Sub New()
            'Sets WebSocket's handler class
            Application.WebSockets.SetHandler(Of DynamicDataWebSocketsHandler)()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the DynamicDataPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub DynamicDataPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            'Tries to cast WebSocketHandler as CompanionKitWebSocketsHandler
            Dim objHandler As DynamicDataWebSocketsHandler = TryCast(Application.WebSockets.WebSocketHandler, DynamicDataWebSocketsHandler)
            If objHandler IsNot Nothing Then
                'Sets current instance to Page property
                objHandler.Page = Me
            End If
        End Sub

        ''' <summary>
        ''' Pages the handle.
        ''' </summary>
        ''' <param name="strConnectionId">The STR connection id.</param>
        ''' <param name="strData">The STR data.</param>
        ''' <exception cref="System.NotImplementedException"></exception>
        Public Sub PageHandle(ByVal strConnectionId As String, ByVal strData As String) Implements IPageHandler.PageHandle
            'Not implemented. Retained for interface compatibility. 
            Throw New NotImplementedException()
        End Sub

        ''' <summary>
        ''' Pages the client handle.
        ''' </summary>
        ''' <param name="objSender">The obj sender.</param>
        ''' <param name="objArgs">The <see cref="ClientEventArgs" /> instance containing the event data.</param>
        Public Sub PageClientHandle(ByVal objSender As Object, ByVal objArgs As Client.ClientEventArgs) Implements IPageHandler.PageClientHandle
            'Invokes js ClientHandler function
            objArgs.Context.Invoke("ClientHandler")
        End Sub



        ''' <summary>
        ''' Called when [unregister components].
        ''' </summary>
        Protected Overrides Sub OnUnregisterComponents()
            MyBase.OnUnregisterComponents()
            DirectCast(Application.WebSockets.WebSocketHandler, DynamicDataWebSocketsHandler).Abort()
        End Sub

    End Class
End Namespace