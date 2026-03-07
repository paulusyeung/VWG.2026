Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class AllowAndResetPromptPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjResetCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjResetCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjResetCheckBox.CheckedChanged
                mobjMaskedTextBox.ResetOnPrompt = mobjResetCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAllowCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAllowCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjAllowCheckBox.CheckedChanged
                mobjMaskedTextBox.AllowPromptAsInput = mobjAllowCheckBox.Checked
        End Sub

	End Class

End Namespace