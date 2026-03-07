Namespace CompanionKit.Concepts.ClientAPI.ValidationForm

	Public Class ValidationFormPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Fires an event.
        ''' </summary>
        ''' <param name="objEvent">event.</param>
        Protected Overrides Sub FireEvent(objEvent As Gizmox.WebGUI.Common.Interfaces.IEvent)
            If objEvent.Type = "validation" Then
                'Getting parameters from client side
                Dim strEmail = objEvent("email")
                Dim strPassword = objEvent("password")
                'Show identification message
                MessageBox.Show([String].Format("You have been authorized:{0}", strEmail), "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MyBase.FireEvent(objEvent)
            End If
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the objLoginButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objLoginButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objLoginButton.ClientClick
            objArgs.Context.Invoke("validateInputData")
        End Sub
    End Class

End Namespace