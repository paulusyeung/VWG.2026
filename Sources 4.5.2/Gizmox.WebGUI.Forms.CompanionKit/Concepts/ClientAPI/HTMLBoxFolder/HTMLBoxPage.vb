Namespace CompanionKit.Concepts.ClientAPI.HTMLBoxFolder

	Public Class HTMLBoxPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()  

		End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the objButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objButton.ClientClick
            objArgs.Context.Invoke("loadAddress")
        End Sub
    End Class

End Namespace