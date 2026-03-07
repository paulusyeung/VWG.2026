Namespace CompanionKit.Concepts.ClientAPI.ClientCheckedState

	Public Class ClientCheckedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles the ClientCheckedChanged event of the testCheckBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub testCheckBox_ClientCheckedChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objCheckBox.ClientCheckedChanged
            'Invoking js function to represent Checked state on a label.
            objArgs.Context.Invoke("setLabelText")
        End Sub

	End Class

End Namespace