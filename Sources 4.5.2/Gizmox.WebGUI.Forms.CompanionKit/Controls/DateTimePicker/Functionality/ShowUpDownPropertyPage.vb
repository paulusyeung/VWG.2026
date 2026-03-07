Namespace CompanionKit.Controls.DateTimePicker.Functionality

	Public Class ShowUpDownPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the CheckBox that represents
        ''' a state of the DateTimePicker ShowUpDown property
        ''' </summary>
        Private Sub mobjUpDownButtonCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjUpDownButtonCheckBox.CheckedChanged
            ' Set value for the DateTimePicker ShowUpDown property according to checked state of the CheckBox
            Me.mobjDemoDateTimePicker.ShowUpDown = Me.mobjUpDownButtonCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub ShowUpDownPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial checked state for the CheckBox that represents
            ' a state of the DateTimePicker ShowUpDown property
            Me.mobjUpDownButtonCheckBox.Checked = Me.mobjDemoDateTimePicker.ShowUpDown
        End Sub
    End Class

End Namespace