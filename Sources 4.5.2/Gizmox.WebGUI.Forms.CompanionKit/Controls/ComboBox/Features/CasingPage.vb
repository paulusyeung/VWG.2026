Namespace CompanionKit.Controls.ComboBox.Features

	Public Class CasingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the objCasingComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCasingComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjCasingComboBox.SelectedIndexChanged
            'Sets selected type of CharacterCasing to combo
            If (mobjCasingComboBox.SelectedIndex = 0) Then
                mobjTestComboBox.CharacterCasing = CharacterCasing.Normal
            Else
                If (mobjCasingComboBox.SelectedIndex = 1) Then
                    mobjTestComboBox.CharacterCasing = CharacterCasing.Upper
                Else
                    mobjTestComboBox.CharacterCasing = CharacterCasing.Lower
                End If
            End If
        End Sub
    End Class

End Namespace