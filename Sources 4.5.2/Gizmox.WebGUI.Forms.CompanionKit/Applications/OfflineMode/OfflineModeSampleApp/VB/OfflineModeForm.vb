Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace Gizmox.WebGUI.Forms.CompanionKit.OfflineModeSampleAppVB

    Public Class OfflineModeForm

        ''' <summary>
        ''' Handles the ClientPreload event of the OfflineModeForm control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub OfflineModeForm_ClientPreload(ByVal objSender As Object, ByVal objArgs As Client.ClientEventArgs) Handles Me.ClientPreload
            objArgs.Context.PreloadResources(AddressOf OnResourceLoad)
        End Sub

        ''' <summary>
        ''' Handles the OfflineConfirming event of the OfflineModeForm control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub OfflineModeForm_OfflineConfirming(ByVal objSender As Object, ByVal objArgs As Client.ClientEventArgs) Handles Me.OfflineConfirming
            objArgs.Context.Invoke("offlineConfirming")
        End Sub

        ''' <summary>
        ''' Handles the OfflineInitializing event of the OfflineModeForm control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub OfflineModeForm_OfflineInitializing(ByVal objSender As Object, ByVal objArgs As Client.ClientEventArgs) Handles Me.OfflineInitializing
            objArgs.Context.Invoke("offlineInitializing")
        End Sub

        ''' <summary>
        ''' Called when [resource load].
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="PreloadResourcesCompleteEventArgs"/> instance containing the event data.</param>
        Private Sub OnResourceLoad(ByVal sender As Object, ByVal e As PreloadResourcesCompleteEventArgs)
            Dim mstrMessage As String = String.Format("Resources preloading complete ({0} resources loaded, {1} loading errors)", e.ResourceLoadedCount, e.ResourceErrorCount)
            VWGClientContext.Current.Invoke("writeLineToLog", mstrMessage)
        End Sub

    End Class
End Namespace
