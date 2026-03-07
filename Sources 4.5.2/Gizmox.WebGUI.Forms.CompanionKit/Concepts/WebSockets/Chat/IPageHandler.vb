Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Gizmox.WebGUI.Forms.Client

Namespace WebSocketsSampleAppsVB
    Public Interface IPageHandler
        ''' <summary>
        ''' Pages the handle.
        ''' </summary>
        ''' <param name="strConnectionId">The STR connection id.</param>
        ''' <param name="strData">The STR data.</param>
        Sub PageHandle(ByVal strConnectionId As String, ByVal strData As String)

        ''' <summary>
        ''' Pages the client handle.
        ''' </summary>
        ''' <param name="objSender">The obj sender.</param>
        ''' <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        Sub PageClientHandle(ByVal objSender As Object, ByVal objArgs As ClientEventArgs)
    End Interface
End Namespace