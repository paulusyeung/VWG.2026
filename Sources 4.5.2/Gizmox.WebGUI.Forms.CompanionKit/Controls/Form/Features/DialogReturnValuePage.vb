Namespace CompanionKit.Controls.Form.Features

	Public Class DialogReturnValuePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens a form with register closed event.
        ''' And the form defines dialog result value while closing.
        ''' </summary>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            Dim mobjDialogWithReturnValueForm As New DialogReturnValueForm()
            AddHandler mobjDialogWithReturnValueForm.Closed, AddressOf Me.mobjDialogWithReturnValueForm_Closed
            mobjDialogWithReturnValueForm.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Closed event for the form with defined dialog result.
        ''' Shows message that informs about the form dialog result.
        ''' </summary>
        Private Sub mobjDialogWithReturnValueForm_Closed(sender As Object, e As EventArgs)
            Dim mobjDialogWithReturnValueForm As DialogReturnValueForm = TryCast(sender, DialogReturnValueForm)
            If mobjDialogWithReturnValueForm.DialogResult = DialogResult.OK Then
                MessageBox.Show(String.Format("Saving {0} user with E-mail: {1} and Phone: {2}!", mobjDialogWithReturnValueForm.UserFullName, mobjDialogWithReturnValueForm.Email, mobjDialogWithReturnValueForm.Phone))
            Else
                MessageBox.Show("Cancel editing user data...")
            End If

        End Sub

	End Class

End Namespace