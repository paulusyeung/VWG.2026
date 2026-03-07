Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	Public Class MaxFileSizePage

        ''' <summary>
        ''' Represents minimum value for the MaxFileSize property of the OpenFileDialog.
        ''' </summary>
        Private MINIMUM_MAX_FILE_SIZE As Integer = 40

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles Load event of the example UserControl
        ''' </summary>
        Private Sub MaxFileSizePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set validator for demo TexBoxt that it will allow to enter only number 
            Me.mobjMaximumFileSizeTextBox.Validator = New TextBoxValidation("", "", String.Concat("0-9"))

            ' Set initial MaxFileSize into TextBox.
            Me.mobjMaximumFileSizeTextBox.Text = Me.mobjDemoOpenFileDialog.MaxFileSize.ToString()
        End Sub

        ''' <summary>
        ''' Handles TextChanged event for the TextBox.
        ''' Validates whether value of the TextBox Text property is empty, 
        ''' null or less than minimum MinFileSize. If it is, maximum file 
        ''' size is set to minimum file size value.
        ''' </summary>
        Private Sub mobjMaximumFileSizeTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjMaximumFileSizeTextBox.TextChanged
            If String.IsNullOrEmpty(Me.mobjMaximumFileSizeTextBox.Text) Then
                Me.mobjMaximumFileSizeTextBox.Text = MINIMUM_MAX_FILE_SIZE.ToString()
            Else
                Dim mintMaxFileSize As Integer = Integer.Parse(Me.mobjMaximumFileSizeTextBox.Text)
                If mintMaxFileSize < MINIMUM_MAX_FILE_SIZE Then
                    Me.mobjMaximumFileSizeTextBox.Text = MINIMUM_MAX_FILE_SIZE.ToString()
                End If
            End If
        End Sub

        ''' <summary>
        ''' Handles the click event of the open file dialog box button.
        ''' Opens the demonstrated OpenFileDialog dialog box.
        ''' </summary>
        Private Sub mobjOpenFileDialogButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileDialogButton.Click
            ' Set the Maximum file size allowed in kilobytes.
            Me.mobjDemoOpenFileDialog.MaxFileSize = Integer.Parse(Me.mobjMaximumFileSizeTextBox.Text)

            ' Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub
    End Class

End Namespace