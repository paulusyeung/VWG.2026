Namespace CompanionKit.Concepts.ClientAPI.DomainUpDown

	Public Class DomainUpDownPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

       
        ''' <summary>
        ''' Handles the ClientSelectedItemChanged event of the mobjDomainUpDown control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjDomainUpDown_ClientSelectedItemChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjDomainUpDown.ClientSelectedItemChanged
            objArgs.Context.Invoke("onDomainValueChanged")
        End Sub

        ''' <summary>
        ''' Handles the ClientSelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_ClientSelectedIndexChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjComboBox.ClientSelectedIndexChanged
            objArgs.Context.Invoke("onComboBoxValueChanged")
        End Sub
    End Class

End Namespace