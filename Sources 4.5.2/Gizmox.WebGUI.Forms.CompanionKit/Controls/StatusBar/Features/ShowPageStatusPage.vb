Namespace CompanionKit.Controls.StatusBar.Features

	Public Class ShowPageStatusPage

        ''' <summary>
        '''  Represents percents of page loading process.
        ''' </summary>
		Private _mintNumber As Integer

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

       ''' <summary>
        ''' Update text of the status bar an the progrest according to loading process.
        ''' </summary>
        Private Sub updateStatusBarTimer_Tick(sender As Object, e As EventArgs) Handles mobjUpdateStatusBarTimer.Tick
            ' Increase loading percents.
            _mintNumber += 6

            'Resets percent of loadin process.
            If _mintNumber > 100 Then
                Me.mobjDemoStatusBar.Text = "Starting"
                _mintNumber = 0

                ' Update the StatusBar text with loading phase name.
            ElseIf _mintNumber > 0 AndAlso _mintNumber < 40 Then
                Me.mobjDemoStatusBar.Text = "Phase 1"
            ElseIf _mintNumber > 40 AndAlso _mintNumber < 80 Then
                Me.mobjDemoStatusBar.Text = "Phase 2"
            ElseIf _mintNumber > 80 AndAlso _mintNumber < 100 Then
                Me.mobjDemoStatusBar.Text = "Phase 3"
            End If
            Me.mobjProgressBar.Value = _mintNumber
        End Sub
	End Class

End Namespace