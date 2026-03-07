Namespace CompanionKit.Controls.DateTimePicker.Functionality

	Public Class ValuePropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub ValuePropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for text of the label that represents current value of the DateTimePicker.
            Me.mobjSelectedValueLabel.Text = String.Format("You selected:" & vbCr & vbLf & "{0}", Me.mobjDemoDateTimePicker.Value.ToLongDateString())
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the demonstrated DateTimePicker.
        ''' </summary>
        Private Sub mobjDemoDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles mobjDemoDateTimePicker.ValueChanged
            ' Update text of the label that represents current value of the DateTimePicker.
            Me.mobjSelectedValueLabel.Text = String.Format("You selected:" & vbCr & vbLf & "{0}", Me.mobjDemoDateTimePicker.Value.ToLongDateString())
        End Sub
    End Class

End Namespace