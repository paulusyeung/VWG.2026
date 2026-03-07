Namespace CompanionKit.Controls.ProgressBar.Functionality

	Public Class MaximumPropertyPage

        Private mintNumber As Integer = 0

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handle Tick event of the timer that increase value of the ProgressBars.
        ''' </summary>
        Private Sub mobjIncrementTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjIncrementTimer.Tick
            ' Compute new value of the the demonstrated ProgressBars
            Me.mintNumber = (Me.mintNumber + 5)
            If (Me.mintNumber > 100) Then
                Me.mintNumber = 0
            End If

            ' Set value for the demonstrated ProgressBars 
            Me.mobjDemoMax100ProgressBar.Value = Me.mintNumber

            Me.mobjDemoMax25ProgressBar.Value = (Me.mintNumber Mod Me.mobjDemoMax25ProgressBar.Maximum)

        End Sub
    End Class

End Namespace