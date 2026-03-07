Namespace CompanionKit.Controls.Form.Features

	Public Class GeographicLocationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            'Opens GeographicLocationForm as dialog
            Dim mobjGeographicLocationForm As New GeographicLocationForm()
            mobjGeographicLocationForm.ShowDialog()
        End Sub

	End Class

End Namespace