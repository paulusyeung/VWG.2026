Namespace CompanionKit.Controls.Form.Programming

	Public Class OrientationChangedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjOpenButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjOpenButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjOpenButton.Click
            'Shows OrientationForm instance
            Dim mobjForm As New OrientationForm()
            mobjForm.WindowState = FormWindowState.Maximized
            mobjForm.Show()
        End Sub
    End Class

End Namespace