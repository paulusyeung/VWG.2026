Namespace CompanionKit.Controls.DateTimePicker.Features

	Public Class CustomFormatPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl
        ''' </summary>
        Private Sub CustomFormatPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up with custom date formats.
            Me.mobjDateFormatsListBox.Items.AddRange(New String() {"M/d/yyyy", "dddd, MMMM dd, yyyy", "dddd, MMMM dd, yyyy h:mm:ss tt", "MMMM dd", "ddd, dd MMM yyyy HH:mm:ss", "h:mm tt", _
                "h:mm:ss tt", "yyyy-MM-dd HH:mm:ssZ", "MMMM, yyyy"})
            Me.mobjDateFormatsListBox.SelectedIndex = 0
        End Sub

        ''' <summary>
        ''' Handles a SelectedIndexChanged event of the ListBox
        ''' that contains custom date formats of the DateTimePicker
        ''' </summary>
        Private Sub mobjDateFormatsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjDateFormatsListBox.SelectedIndexChanged
            ' Update custom format of the demonstrated DateTimePicker.
            Me.mobjDemoDateTimePicker.CustomFormat = DirectCast(Me.mobjDateFormatsListBox.SelectedItem, String)
        End Sub
    End Class

End Namespace