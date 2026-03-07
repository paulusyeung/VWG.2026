Namespace CompanionKit.Controls.DateTimePicker.Features

	Public Class FormatPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub FormatPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up the ComboBow with enable date formats of the DataTimePicker.
            Dim mobjDefaultDateFormat As DateTimePickerFormat = Me.mobjDemoDateTimePicker.Format
            Me.mobjDateFormatComboBox.DataSource = [Enum].GetValues(GetType(DateTimePickerFormat))
            Me.mobjDateFormatComboBox.SelectedItem = mobjDefaultDateFormat
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox that contains
        ''' enable date formats of the DataTimePicker. Sets selected format
        ''' for the DateTimePicker.
        ''' </summary>
        Private Sub mobjDateFormatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjDateFormatComboBox.SelectedIndexChanged
            ' Set selected date format for the DateTimePicker
            Me.mobjDemoDateTimePicker.Format = DirectCast(Me.mobjDateFormatComboBox.SelectedItem, DateTimePickerFormat)
        End Sub
    End Class

End Namespace