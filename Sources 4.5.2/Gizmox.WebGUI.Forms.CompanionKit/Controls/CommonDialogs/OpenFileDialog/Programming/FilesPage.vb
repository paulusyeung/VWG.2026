Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	Public Class FilesPage

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
            ' Clear ListBox items from previously selected files and 
            ' set a new  collection of selected files
            Me.mobjSelectedFilesListView.Items.Clear()

            For Each fileKey As String In Me.mobjDemoOpenFileDialog.Files
                Dim file As FileHandle = Me.mobjDemoOpenFileDialog.Files(fileKey)
                Dim origFileName As String = DirectCast(file, Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle).OriginalFileName
                Dim fileListViewItem As New ListViewItem(New String() {origFileName, file.ContentLength.ToString()})

                Me.mobjSelectedFilesListView.Items.Add(fileListViewItem)
            Next
        End Sub
    End Class

End Namespace
