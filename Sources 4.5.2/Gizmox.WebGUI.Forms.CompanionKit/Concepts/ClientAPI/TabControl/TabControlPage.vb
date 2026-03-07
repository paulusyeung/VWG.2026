Namespace CompanionKit.Concepts.ClientAPI.TabControl

	Public Class TabControlPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the ClientSelectedIndexChanged event of the objTabControl control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objTabControl_ClientSelectedIndexChanged(objSender As Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objTabControl.ClientSelectedIndexChanged
            'Invoking js handler function
            objArgs.Context.Invoke("currentSelectedTabPage")
        End Sub


    End Class

End Namespace