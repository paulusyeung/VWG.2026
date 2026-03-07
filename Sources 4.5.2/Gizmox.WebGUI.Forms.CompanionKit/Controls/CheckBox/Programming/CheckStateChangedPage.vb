Namespace CompanionKit.Controls.CheckBox.Programming

	Public Class CheckStateChangedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Update label text with initial state of demonstrated CheckBox
			Me.UpdateLabelText()

		End Sub

        ''' <summary>
        ''' Handles the CheckStateChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCheckBox.CheckStateChanged
            'Update Label text
            Me.UpdateLabelText()
        End Sub

        ''' <summary>
        ''' Updates the label text.
        ''' </summary>
		Private Sub UpdateLabelText()
            Me.mobjStateLabel.Text = String.Format("CheckBox state is {0}!", Me.mobjCheckBox.CheckState)
		End Sub

	End Class

End Namespace