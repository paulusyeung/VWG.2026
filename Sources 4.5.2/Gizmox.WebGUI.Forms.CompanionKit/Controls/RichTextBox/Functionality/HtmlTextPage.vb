Namespace CompanionKit.Controls.RichTextBox.Functionality

	Public Class HtmlTextPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjHtmlButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjHtmlButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjHtmlButton.Click
            'Set RichTextBox Html property
            mobjRichTextBox.Html = mobjTextBox.Text
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjTextButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjTextButton.Click
            'Set RichTextBox Text property
            mobjRichTextBox.Text = mobjTextBox.Text
        End Sub
	End Class

End Namespace