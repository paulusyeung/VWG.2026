Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class TitlePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles Load event of example UserControl.
        ''' Sets initial title of the open file dialog.
        ''' </summary>
        Private Sub TitlePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial title of the open file dialog.
            Me.mobjTitleFileDialogTextBox.Text = Me.mobjDemoOpenFileDialog.Title
        End Sub

        ''' <summary>
        ''' Handles Click event of the Button.
        ''' Sets specified title for open file dialog and open it.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set specified title for open file dialog and open it.
            Me.mobjDemoOpenFileDialog.Title = Me.mobjTitleFileDialogTextBox.Text
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace