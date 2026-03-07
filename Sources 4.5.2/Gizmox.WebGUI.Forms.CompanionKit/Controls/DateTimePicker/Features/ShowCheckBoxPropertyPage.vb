Namespace CompanionKit.Controls.DateTimePicker.Features

	Public Class ShowCheckBoxPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub ShowCheckBoxPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial checked state for the CheckBox that represents
            ' a state of the DateTimePicker ShowCheckBox property
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Checked = Me.mobjDemoDateTimePicker.ShowCheckBox
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the CheckBox that represents
        ''' a state of the DateTimePicker ShowCheckBox property
        ''' </summary>
        Private Sub mobjAllowCheckBoxForDateTimePickerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjAllowCheckBoxForDateTimePickerCheckBox.CheckedChanged
            ' Set value for the DateTimePicker ShowCheckBox property according to checked state of the CheckBox
            Me.mobjDemoDateTimePicker.ShowCheckBox = Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Checked
        End Sub
    End Class

End Namespace