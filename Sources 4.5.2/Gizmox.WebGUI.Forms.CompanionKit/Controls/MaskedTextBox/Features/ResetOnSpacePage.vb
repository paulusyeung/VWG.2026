Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class ResetOnSpacePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox.CheckedChanged
            'Switch ResetOnSpace property's state
            mobjMaskedTextBox.ResetOnSpace = mobjCheckBox.Checked
        End Sub

	End Class

End Namespace