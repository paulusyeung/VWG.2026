Namespace CompanionKit.Concepts.ClientAPI.LoadingIcon

	Public Class LoadingIconPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles the Click event of the objButton control by invoking js function to show and hide icon with defined duration.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        ''' <remarks></remarks>
   		 Private Sub objButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objButton.ClientClick
        		objArgs.Context.Invoke("showLoadingIcon")
   		 End Sub
	End Class

End Namespace