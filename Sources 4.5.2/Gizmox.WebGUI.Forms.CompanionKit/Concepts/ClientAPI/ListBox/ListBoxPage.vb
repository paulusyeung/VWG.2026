Namespace CompanionKit.Concepts.ClientAPI.ListBox

	Public Class ListBoxPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjFillButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFillButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjFillButton.Click
            VWGClientContext.Current.Invoke("fillListBox")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjClearButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjClearButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjClearButton.Click
            VWGClientContext.Current.Invoke("clearListBox")
        End Sub
    End Class

End Namespace