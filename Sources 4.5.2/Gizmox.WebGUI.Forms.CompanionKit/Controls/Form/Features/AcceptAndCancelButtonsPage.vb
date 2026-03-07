Namespace CompanionKit.Controls.Form.Features

	Public Class AcceptAndCancelButtonsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event for the button.
        ''' Opens the form with assigned accept and cancel buttons.
        ''' </summary>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            Dim mobjAcceptAndCancelForm As New AcceptAndCancelButtonsForm()
            AddHandler mobjAcceptAndCancelForm.Closed, AddressOf mobjAcceptAndCancelForm_Closed
            mobjAcceptAndCancelForm.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles closed event for the form with assigned accept and cancel buttons.
        ''' Check the dialog result for the form and
        ''' shows saving or canceling message according to the dialog result.
        ''' </summary>
        Private Sub mobjAcceptAndCancelForm_Closed(sender As Object, e As EventArgs)
            Dim mobjAcceptAndCancelButtonsForm As AcceptAndCancelButtonsForm = TryCast(sender, AcceptAndCancelButtonsForm)
            If mobjAcceptAndCancelButtonsForm.DialogResult = DialogResult.OK Then
                MessageBox.Show(mobjAcceptAndCancelButtonsForm.GetSavingUserMessage())
            Else
                MessageBox.Show("Cancel editing user data...")
            End If

        End Sub

	End Class

End Namespace