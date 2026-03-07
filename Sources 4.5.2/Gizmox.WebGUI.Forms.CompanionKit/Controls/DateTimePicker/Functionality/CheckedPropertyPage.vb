Namespace CompanionKit.Controls.DateTimePicker.Functionality

	Public Class CheckedPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the DateTimePicker.
        ''' Updates text of the label that represents checked state of the DateTimePicker.
        ''' </summary>
        Private Sub mobjDemoDateTimePicker_CheckedChanged(sender As Object, e As EventArgs) Handles mobjDemoDateTimePicker.CheckedChanged
            ' Update text of the label that represents checked state of the DateTimePicker.
            Me.mobjDateTimePickerCheckBoxStateLabel.Text = String.Format("The DateTimePicker is {0} now !", IIf((Me.mobjDemoDateTimePicker.Checked), "checked", "unchecked"))
        End Sub

        ''' <summary>
        ''' Handles Load event of the example UserControl.
        ''' </summary>
        Private Sub CheckedPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for text of the label that represents checked state of the DateTimePicker.
            Me.mobjDateTimePickerCheckBoxStateLabel.Text = String.Format("The DateTimePicker is {0} now!", IIf((Me.mobjDemoDateTimePicker.Checked), "checked", "unchecked"))
        End Sub
    End Class

End Namespace