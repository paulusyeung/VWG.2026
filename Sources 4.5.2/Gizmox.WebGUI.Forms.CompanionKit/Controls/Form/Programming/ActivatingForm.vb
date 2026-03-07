Namespace CompanionKit.Controls.Form.Programming
	Public Class ActivatingForm

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Closes the Form.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            MyBase.Close()
        End Sub

        ''' <summary>
        ''' Handles Activated event of the form.
        ''' Updates text of the form label.
        ''' </summary>
		Private Sub ActivatingForm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

            Me.mobjLabel.Text = "This form is Activated!"

		End Sub

        ''' <summary>
        ''' Handles Deactivate event of the form.
        ''' Updates text of the form label.
        ''' </summary>
		Private Sub ActivatingForm_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate

            Me.mobjLabel.Text = "This form is Deactivated!"

		End Sub
	End Class
End Namespace
