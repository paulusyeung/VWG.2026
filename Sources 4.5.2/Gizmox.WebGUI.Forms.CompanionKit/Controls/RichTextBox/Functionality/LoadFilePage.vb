Namespace CompanionKit.Controls.RichTextBox.Functionality

	Public Class LoadFilePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjLoadButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjLoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjLoadButton.Click
            'Define full path of selected rtf file
            'NOTE: in order to use this code in your project, just edit the path below
            'NOTE: if you add rtf files in the base directory, just remove "Controls", "RichTextBox", "Functionality" part
            Dim mobjFilePath As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.IO.Path.Combine("Controls", System.IO.Path.Combine("RichTextBox", System.IO.Path.Combine("Functionality", mobjListView.SelectedItem.Text))))
            'Load file to RichTextBox
            mobjRichTextBox.LoadFile(mobjFilePath)
        End Sub
	End Class

End Namespace