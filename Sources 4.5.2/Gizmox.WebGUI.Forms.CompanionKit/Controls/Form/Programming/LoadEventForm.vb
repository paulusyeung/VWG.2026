Namespace CompanionKit.Controls.Form.Programming
	Public Class LoadEventForm

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Closes the Form.
        ''' </summary>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            MyBase.Close()
        End Sub

        ''' <summary>
        ''' andles Load event for the form.
        ''' Shows infomation message.
        ''' </summary>
		Private Sub LoadEventForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			MessageBox.Show("Form is loaded!")
		End Sub
	End Class
End Namespace
