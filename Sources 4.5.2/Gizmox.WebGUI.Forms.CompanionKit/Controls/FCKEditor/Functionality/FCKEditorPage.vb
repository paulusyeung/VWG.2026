Namespace CompanionKit.Controls.FCKEditor

	Public Class FCKEditorPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSendButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSendButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjSendButton.Click
            'Sent FCKEditor value to RichTextBox
            mobjRichTextBox.Html = mobjFCKEditor.Value
        End Sub
    End Class

End Namespace