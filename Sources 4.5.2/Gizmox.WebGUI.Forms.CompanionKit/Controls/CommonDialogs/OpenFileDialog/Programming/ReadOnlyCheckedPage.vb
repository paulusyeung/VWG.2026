Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	Public Class ReadOnlyCheckedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        '''  Handles Load event of the example UserControl
        ''' </summary>
        Private Sub ReadOnlyCheckedPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set checked state for CheckBox according to OpenFileDialog ReadOnlyChecked property value
            Me.mobjCheckedReaodOnlyCheckBox.Checked = Me.mobjDemoOpenFileDialog.ReadOnlyChecked
        End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set OpenFileDialog ReadOnlyChecked property value according to checked state of CheckBox
            Me.mobjDemoOpenFileDialog.ReadOnlyChecked = Me.mobjCheckedReaodOnlyCheckBox.Checked
            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace