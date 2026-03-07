Namespace CompanionKit.Controls.ComboBox.Features

	Public Class AutocompletePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjAutoCompleteComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAutoCompleteComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjAutoCompleteComboBox.SelectedIndexChanged
            'Sets combobox's AutoComplete mode according to selected option
            Select Case mobjAutoCompleteComboBox.SelectedIndex
                'None
                Case 0
                    Me.mobjComboBox.AutoCompleteMode = AutoCompleteMode.None
                    Exit Select
                    'Suggest
                Case 1
                    Me.mobjComboBox.AutoCompleteMode = AutoCompleteMode.Suggest
                    Exit Select
                    'Append
                Case 2
                    Me.mobjComboBox.AutoCompleteMode = AutoCompleteMode.Append
                    Exit Select
                    'SuggestAppend
                Case 3
                    Me.mobjComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    Exit Select
            End Select
        End Sub

	End Class

End Namespace