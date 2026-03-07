Namespace CompanionKit.Controls.MonthCalendar.Features

	Public Class SelectionPropertiesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

       ''' <summary>
        ''' Handles the ValueChanged event of the mobjNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjNumericUpDown.ValueChanged
            'Sets MaxSelectionCount value, which picked from NUD control
            mobjMonthCalendar.MaxSelectionCount = CInt(mobjNumericUpDown.Value)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SelectionPropertiesPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub SelectionPropertiesPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'OnLoad dateTimePickers initialization
            mobjStartDateTimePicker.Value = DateTime.Now
            mobjEndDateTimePicker.Value = DateTime.Now.AddDays(3)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            'Assigns selection range to MonthCalendar, based on dateTimePickers values
            mobjMonthCalendar.SelectionRange = New SelectionRange(mobjStartDateTimePicker.Value, mobjEndDateTimePicker.Value)
        End Sub

	End Class

End Namespace