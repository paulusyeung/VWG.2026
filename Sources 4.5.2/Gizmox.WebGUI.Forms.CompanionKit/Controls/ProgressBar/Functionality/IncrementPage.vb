Namespace CompanionKit.Controls.ProgressBar.Functionality

	Public Class IncrementPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

      ''' <summary>
        ''' Handles the Click event of the button that increments value of the ProgressBar.
        ''' </summary>
        Private Sub mobjIncrementButton_Click(sender As Object, e As EventArgs) Handles mobjIncrementButton.Click
            If Me.mobjDemoProgressBar.Value = Me.mobjDemoProgressBar.Maximum Then
                Me.mobjDemoProgressBar.Value = 0
            End If
            ' Compute step of increasing ProgressBar value.
            Dim mintStep As Integer = Decimal.ToInt16(Me.mobjStepProgressBarNumericUpDown.Value)
            If Me.mobjDemoProgressBar.Value + mintStep > Me.mobjDemoProgressBar.Maximum Then
                mintStep = Me.mobjDemoProgressBar.Maximum - Me.mobjDemoProgressBar.Value
            End If
            ' Increment value of the demonstrated ProgressBar.
            Me.mobjDemoProgressBar.Increment(mintStep)
        End Sub
    End Class

End Namespace