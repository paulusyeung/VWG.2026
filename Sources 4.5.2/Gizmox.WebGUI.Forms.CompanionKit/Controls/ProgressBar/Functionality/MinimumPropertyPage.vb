Namespace CompanionKit.Controls.ProgressBar.Functionality

	Public Class MinimumPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjIncrementTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjIncrementTimer.Tick
            If ((Me.mobjDemoMin0ProgressBar.Value + Me.mobjDemoMin0ProgressBar.Step) >= Me.mobjDemoMin0ProgressBar.Maximum) Then
                Me.mobjDemoMin0ProgressBar.Value = Me.mobjDemoMin0ProgressBar.Minimum
            End If
            Me.mobjDemoMin0ProgressBar.PerformStep()
            If ((Me.mobjDemoMin75ProgressBar.Value + Me.mobjDemoMin75ProgressBar.Step) >= Me.mobjDemoMin75ProgressBar.Maximum) Then
                Me.mobjDemoMin75ProgressBar.Value = Me.mobjDemoMin75ProgressBar.Minimum
            End If
            Me.mobjDemoMin75ProgressBar.PerformStep()

        End Sub
    End Class

End Namespace