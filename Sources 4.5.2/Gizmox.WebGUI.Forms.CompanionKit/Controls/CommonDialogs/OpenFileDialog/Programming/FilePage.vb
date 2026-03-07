Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	Public Class FilePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles FileOK event of the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjDemoOpenFileDialog_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles mobjDemoOpenFileDialog.FileOk
            ' Change text of TextBoxes to the file name and the file size.
            Me.mobjOrigFileNameTextBox.Text = DirectCast((Me.mobjDemoOpenFileDialog).File, Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle).OriginalFileName
            Me.mobjFileNameTextBox.Text = Me.mobjDemoOpenFileDialog.File.FileName
            Me.mobjFileSizeTextBox.Text = Me.mobjDemoOpenFileDialog.File.ContentLength.ToString()
        End Sub
    End Class

End Namespace
