Namespace CompanionKit.Controls.CheckBox.Functionality

	Public Class CheckedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Update label text with initial state of demonstrated CheckBox
			Me.UpdateLabelText()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCheckBox.CheckedChanged
            'Update State Label text
            UpdateLabelText()
        End Sub


        ''' <summary>
        ''' Updates the label text defining current value of Checked property.
        ''' </summary>
		Private Sub UpdateLabelText()
            Me.mobjStateLabel.Text = String.Format("CheckBox is {0}!", IIf(Me.mobjCheckBox.Checked, "checked", "unchecked"))
		End Sub

	End Class

End Namespace