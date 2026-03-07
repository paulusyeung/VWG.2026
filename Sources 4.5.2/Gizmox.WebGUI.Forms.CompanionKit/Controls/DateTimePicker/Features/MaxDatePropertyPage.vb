Namespace CompanionKit.Controls.DateTimePicker.Features

	Public Class MaxDatePropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the DateTimePicker that
        ''' represents allowed maximum date for the demonstrated DateTimePicker.
        ''' </summary>
        Private Sub mobjMaxDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles mobjMaxDateTimePicker.ValueChanged
            Dim mobjDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker = TryCast(sender, Gizmox.WebGUI.Forms.DateTimePicker)

            ' Change maximum limit of the DateTimePicker.
            Me.mobjDemoDateTimePicker.MaxDate = mobjDateTimePicker.Value
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub MaxDatePropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for the DateTimePicker as maximum date of the demonstrated DateTimePicker
            Me.mobjMaxDateTimePicker.Value = Me.mobjDemoDateTimePicker.MaxDate
        End Sub
    End Class

End Namespace