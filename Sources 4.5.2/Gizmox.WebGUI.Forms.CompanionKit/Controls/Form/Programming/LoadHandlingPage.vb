Namespace CompanionKit.Controls.Form.Programming

	Public Class LoadHandlingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens the demonstrated Form.
        ''' </summary>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            Dim form As New LoadEventForm()
            form.ShowDialog()
        End Sub
	End Class

End Namespace