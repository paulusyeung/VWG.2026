Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class InitialDirectoryPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the FolderBrowserDialog dialog box to select initial directory.
        ''' </summary>
        Private Sub mobjInitialDirectoryButton_Click(sender As Object, e As EventArgs) Handles mobjInitialDirectoryButton.Click
            ' Opens the folder browser dialog with initial selected path
            Me.mobjInitialDirectoryFolderBrowserDialog.SelectedPath = Me.mobjInitialDirectoryTextBox.Text

            Me.mobjInitialDirectoryFolderBrowserDialog.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles the Closed event of the FolderBrowserDialog dialog box.
        ''' </summary>
        Private Sub mobjInitialDirectoryFolderBrowserDialog_Closed(sender As Object, e As EventArgs) Handles mobjInitialDirectoryFolderBrowserDialog.Closed
            ' On success closing of the Folder Browser Dialog, 
            ' Change selected path in the TextBox.
            If Me.mobjInitialDirectoryFolderBrowserDialog.DialogResult = DialogResult.OK Then
                Me.mobjInitialDirectoryTextBox.Text = Me.mobjInitialDirectoryFolderBrowserDialog.SelectedPath
            End If
        End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set initial directory for Open File Dialog
            Me.mobjDemoOpenFileDialog.InitialDirectory = Me.mobjInitialDirectoryTextBox.Text

            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace