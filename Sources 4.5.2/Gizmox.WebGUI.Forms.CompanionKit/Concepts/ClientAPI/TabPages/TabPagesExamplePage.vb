Namespace CompanionKit.Concepts.ClientAPI.TabPages

	Public Class TabPagesExamplePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the ClientCloseClick event of the objTabControl control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objTabControl_ClientCloseClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objTabControl.ClientCloseClick
            objArgs.Context.Invoke("closeSelectedTabPage")
        End Sub
    End Class

End Namespace