Namespace CompanionKit.Controls.ProgressBar.ApplicationScenarios

	Public Class ChangeValuePage

        Private mintNumber As Integer = 0

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjIncrementTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjIncrementTimer.Tick
            Me.mintNumber = (Me.mintNumber + 5)
            If (Me.mintNumber > 100) Then
                Me.mintNumber = 0
            End If
            Me.mobjDemoProgressBar.Value = Me.mintNumber

        End Sub
    End Class

End Namespace