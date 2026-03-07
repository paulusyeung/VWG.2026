Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class PromptCharacterPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            Me.mobjPromptCharsComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Me.mobjPromptCharsComboBox.Items.AddRange(New Char() {"*"c, "+"c, "_"c, "~"c})
            Me.mobjPromptCharsComboBox.SelectedIndex = 3

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjPromptCharsComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPromptCharsComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjPromptCharsComboBox.SelectedIndexChanged
            Me.mobjMaskedTextBox.PromptChar = DirectCast(Me.mobjPromptCharsComboBox.SelectedItem, Char)
        End Sub
    End Class

End Namespace