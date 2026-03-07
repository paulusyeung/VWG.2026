Namespace CompanionKit.Concepts.ClientAPI.PropertyAndId

	Public Class PropertyAndIdPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjPrintButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPrintButton_Click(sender As Object, e As EventArgs) Handles mobjPrintButton.Click
            'Invokes js handling function
            VWGClientContext.Current.Invoke("printProperties")
        End Sub

        Private Sub mobjTestButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjTestButton.Click
            'Changes button's text on each click
            mobjTestButton.Text = IIf(mobjTestButton.Text Is "Normal", "Flat", "Normal")

            'Invokes js handling function
            VWGClientContext.Current.Invoke("changeStyle")
        End Sub
    End Class

End Namespace