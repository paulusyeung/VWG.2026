Namespace CompanionKit.Concepts.ClientAPI.EnabledAndVisible

	Public Class EnabledVisiblePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub


        ''' <summary>
        ''' Handles the ClientCheckedChanged event of the mobjEnabledCheckBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjEnabledCheckBox_ClientCheckedChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjEnabledCheckBox.ClientCheckedChanged
            objArgs.Context.Invoke("enabledChange")

        End Sub

       
        ''' <summary>
        ''' Handles the ClientCheckedChanged event of the mobjVisibleCheckBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjVisibleCheckBox_ClientCheckedChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjVisibleCheckBox.ClientCheckedChanged
            objArgs.Context.Invoke("visibleChange")
        End Sub
    End Class

End Namespace