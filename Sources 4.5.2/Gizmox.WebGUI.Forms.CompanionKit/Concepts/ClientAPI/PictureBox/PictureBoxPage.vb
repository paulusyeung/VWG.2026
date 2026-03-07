Namespace CompanionKit.Concepts.ClientAPI.PictureBox

	Public Class PictureBoxPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjListBox.SelectedIndexChanged
            VWGClientContext.Current.Invoke("onSelectedChanged")
        End Sub
    End Class

End Namespace