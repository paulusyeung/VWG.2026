Namespace CompanionKit.Controls.Timer.Features

	Public Class IntervalActionPage

		Public Const FORMAT As String = "hh:mm:ss tt"

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			Me.Label1.Text = DateTime.Now.ToString(FORMAT)

		End Sub

        ''' <summary>
        ''' Handles Tick event of the Timer.
        ''' Updates text of the Label with current time.
        ''' </summary>
		Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
			Me.Label1.Text = DateTime.Now.ToString(FORMAT)

			' Disable the Timer when the UserControl removed from the container
			If Me.Parent Is Nothing Then
				Me.Timer1.Enabled = False
			End If
		End Sub
	End Class

End Namespace