Namespace CompanionKit.Controls.RichTextBox.Functionality

	Public Class WordWrapPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsWordWrap control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIsWordWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjIsWordWrap.CheckedChanged
            'Change WordWrap property of RichTextBox
            mobjRichTextBox.WordWrap = mobjIsWordWrap.Checked
        End Sub
	End Class

End Namespace