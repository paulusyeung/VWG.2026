Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class DefaultExtPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the click event of the button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp"
            ' Set index of default images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.FilterIndex = 1
            ' Set default file extension Open File Dialog
            Me.mobjDemoOpenFileDialog.DefaultExt = Me.mobjDefaultExtTextBox.Text
            ' Set initial directory for Open File Dialog
            Me.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Load event of the example UserControl
        ''' </summary>
        Private Sub DefaultExtPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial default extension for the TextBox as the OpenFileDialog DefaultExt property value.
            Me.mobjDefaultExtTextBox.Text = Me.mobjDemoOpenFileDialog.DefaultExt
        End Sub
    End Class

End Namespace