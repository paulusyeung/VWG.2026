Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class AddExtensionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        Private Sub AddExtensionPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Set checked state for CheckBox according to OpenFileDialog AddExtension property value
            Me.mobjAllowAddExtensionCheckBox.Checked = Me.mobjDemoOpenFileDialog.AddExtension
        End Sub

        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            'Set OpenFileDialog AddExtension property value according to checked state of CheckBox
            Me.mobjDemoOpenFileDialog.AddExtension = Me.mobjAllowAddExtensionCheckBox.Checked
            'Set images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp"
            'Set index of default images file Filter for Open File Dialog
            Me.mobjDemoOpenFileDialog.FilterIndex = 1
            'Set default file extension Open File Dialog
            Me.mobjDemoOpenFileDialog.DefaultExt = "*.jpg"
            'Set initial directory for Open File Dialog
            Me.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            'Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
	End Class

End Namespace