Namespace CompanionKit.Controls.Form.Features
	Public Class AcceptAndCancelButtonsForm


        ''' <summary>
        ''' Handles Click event for Save button.
        ''' Sets OK dialog result for form and closes it.
        ''' </summary>
        Private Sub mobjSaveButton_Click(sender As Object, e As EventArgs) Handles mobjSaveButton.Click
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        ''' <summary>
        ''' Handles Click event for Cancel button.
        ''' Sets Cancel dialog result for form and closes it.
        ''' </summary>
        Private Sub mobjCancelButton_Click(sender As Object, e As EventArgs) Handles mobjCancelButton.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        ''' <summary>
        ''' Gets information about saving user.
        ''' </summary>
        Public Function GetSavingUserMessage() As String
            Return String.Format("Saving {0} {1} user with E-mail: {2} and Phone: {3}!", mobjUserFirstNameTextBox.Text, mobjUserLastNameTextBox.Text, mobjEmailTextBox.Text, mobjPhoneTextBox.Text)
        End Function

	End Class

End Namespace
