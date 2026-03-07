Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class ValidateNamesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example UserControl
        ''' </summary>
        Private Sub ValidateNamesPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set checked state for CheckBox according to OpenFileDialog ValidateNames property value
            Me.mobjEnableValidationNamesCheckBox.Checked = Me.mobjDemoOpenFileDialog.ValidateNames
        End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set OpenFileDialog ValidateNames property value according to checked state of CheckBox
            Me.mobjDemoOpenFileDialog.ValidateNames = Me.mobjEnableValidationNamesCheckBox.Checked
            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace