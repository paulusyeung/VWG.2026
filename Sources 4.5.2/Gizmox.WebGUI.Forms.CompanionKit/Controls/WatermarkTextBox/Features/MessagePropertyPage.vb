Namespace CompanionKit.Controls.WatermarkTextBox.Features

	Public Class MessagePropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjButton.Click
            'if textBox contains not empty text - assign it to WatermarkTextBox's message property
            If (Not String.IsNullOrEmpty(mobjInputTextBox.Text)) Then
                mobjWatermarkTextBox.Message = mobjInputTextBox.Text
            End If
        End Sub
    End Class

End Namespace