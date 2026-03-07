Namespace CompanionKit.Controls.DateTimePicker.Features

	Public Class DropAndUpDownPage

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
            'Handles all available options of DateTimePicker's buttons structure            
            Select Case mobjComboBox.SelectedIndex
                'DropDown
                Case 0
                    mobjDateTimePicker.ShowUpDown = False
                    mobjDateTimePicker.ShowBothEditButtons = False
                    Exit Select
                    'UpDown
                Case 1
                    mobjDateTimePicker.ShowUpDown = True
                    mobjDateTimePicker.ShowBothEditButtons = False
                    Exit Select
                    'Both
                Case 2
                    mobjDateTimePicker.ShowUpDown = True
                    mobjDateTimePicker.ShowBothEditButtons = True
                    Exit Select
            End Select
        End Sub

    End Class

End Namespace