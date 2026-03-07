Imports System
Namespace CompanionKit.Controls.TextBox.Functionality

	Public Class CharacterCasingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Aplies CharacterCasing according to selected item in ComboBox
            Select Case mobjComboBox.SelectedIndex
                'Normal
                Case 0
                    mobjTextBox.CharacterCasing = CharacterCasing.Normal
                    Exit Select
                    'Upper
                Case 1
                    mobjTextBox.CharacterCasing = CharacterCasing.Upper
                    Exit Select
                    'Lower
                Case 2
                    mobjTextBox.CharacterCasing = CharacterCasing.Lower
                    Exit Select
            End Select
        End Sub

	End Class

End Namespace