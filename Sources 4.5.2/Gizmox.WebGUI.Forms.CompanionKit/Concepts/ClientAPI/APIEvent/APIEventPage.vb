Namespace CompanionKit.Concepts.ClientAPI.APIEvent

	Public Class APIEventPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub

        ''' <summary>
        ''' Fires an event.
        ''' </summary>
        ''' <param name="objEvent">event.</param>
        Protected Overrides Sub FireEvent(objEvent As Gizmox.WebGUI.Common.Interfaces.IEvent)
            'Catch custom event
            If (objEvent.Type = "customEvent") Then
                'Get events attributes
                Dim intIndex = objEvent("index")
                Dim strText = objEvent("text")
                'Display attributes on label
                objLabel.Text = String.Format("Index:{0}, Text:{1}", intIndex, strText)

            Else
                MyBase.FireEvent(objEvent)
            End If

        End Sub

        ''' <summary>
        ''' Handles the ClientSelectedIndexChanged event of the objComboBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objComboBox_ClientSelectedIndexChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objComboBox.ClientSelectedIndexChanged
            objArgs.Context.Invoke("raiseCustomEvent")
        End Sub
    End Class

End Namespace