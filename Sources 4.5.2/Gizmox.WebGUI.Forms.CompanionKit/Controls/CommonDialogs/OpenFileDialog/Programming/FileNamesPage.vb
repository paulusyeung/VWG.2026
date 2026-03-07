Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	Public Class FileNamesPage

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
            Me.mobjSelectedFileNamesListView.Items.Clear()
            For Each tempFileName As String In Me.mobjDemoOpenFileDialog.FileNames
                Me.mobjSelectedFileNamesListView.Items.Add(New ListViewItem(New String() {tempFileName, GetOriginalFileName(tempFileName)}))
            Next
        End Sub

        Private Function GetOriginalFileName(tempFileName As String) As String
            If Not String.IsNullOrEmpty(tempFileName) Then
                For Each fileKey As String In Me.mobjDemoOpenFileDialog.Files
                    Dim file As FileHandle = Me.mobjDemoOpenFileDialog.Files(fileKey)
                    If tempFileName.Equals(file.FileName) Then
                        Return DirectCast(file, Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle).OriginalFileName
                    End If
                Next
            End If
            Return String.Empty
        End Function
    End Class

End Namespace
