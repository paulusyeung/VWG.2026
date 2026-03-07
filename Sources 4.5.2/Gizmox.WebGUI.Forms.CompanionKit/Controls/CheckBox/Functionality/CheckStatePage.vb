Namespace CompanionKit.Controls.CheckBox.Functionality

	Public Class CheckStatePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Update label text with initial state of demonstrated CheckBox
			UpdateLabelText()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjCheckStateButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckStateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCheckStateButton.Click
            UpdateLabelText()
        End Sub


		''' <summary>
		''' Updates label text, that indicates state of demonstrated CheckBox.
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdateLabelText()
            Me.mobjStateLabel.Text = String.Format("CheckBox state is {0}!", Me.mobjCheckBox.CheckState)
		End Sub
	End Class

End Namespace