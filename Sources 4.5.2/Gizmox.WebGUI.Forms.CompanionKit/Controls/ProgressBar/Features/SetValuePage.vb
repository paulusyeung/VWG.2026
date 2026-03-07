Namespace CompanionKit.Controls.ProgressBar.Features

	Public Class SetValuePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the TrackBar that changes of the ProgressBar.
        ''' </summary>
        Private Sub mobjChangevalueTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles mobjChangevalueTrackBar.ValueChanged
            ' Set a new value of the TrackBar for the ProgressBar.
            Me.mobjDemoProgressBar.Value = Me.mobjChangevalueTrackBar.Value
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub SetValuePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for TrackBar that changes value for progress bar.
            Me.mobjChangevalueTrackBar.Value = Me.mobjDemoProgressBar.Value
            Me.mobjChangevalueTrackBar.Minimum = Me.mobjDemoProgressBar.Minimum
            Me.mobjChangevalueTrackBar.Maximum = Me.mobjDemoProgressBar.Maximum
            Me.mobjChangevalueTrackBar.TickFrequency = Me.mobjDemoProgressBar.[Step]
        End Sub
    End Class

End Namespace