Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class HidePromptOnLeavePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the hidePromptOnLeaveCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub hidePromptOnLeaveCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hidePromptOnLeaveCheckBox.CheckedChanged
            ' Set changed value:
            demoMaskedTextBox.HidePromptOnLeave = hidePromptOnLeaveCheckBox.Checked
            demoMaskedTextBox2.HidePromptOnLeave = hidePromptOnLeaveCheckBox.Checked
        End Sub
    End Class

End Namespace