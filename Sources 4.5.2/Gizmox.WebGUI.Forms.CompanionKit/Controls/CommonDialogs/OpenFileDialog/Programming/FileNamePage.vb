Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	Public Class FileNamePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Closed event of the demonstrated FileDialog.
        ''' </summary>
        Private Sub mobjDemoOpenFileDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoOpenFileDialog.Closed
            ' Update text of the TextBox with the selected file name.
            If Me.mobjDemoOpenFileDialog.DialogResult = DialogResult.OK Then
                Me.mobjSelectedFileTextBox.Text = Me.mobjDemoOpenFileDialog.FileName
                Me.mobjOrigFileNameTextBox.Text = DirectCast((Me.mobjDemoOpenFileDialog).File, Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle).OriginalFileName
            End If
        End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace
