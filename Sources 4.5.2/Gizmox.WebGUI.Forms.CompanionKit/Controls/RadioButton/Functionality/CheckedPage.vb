Namespace CompanionKit.Controls.RadioButton.Functionality

	Public Class CheckedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Update label text with initial state of demonstrated RadioButton
			Me.UpdateLabelText()


		End Sub

        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            'Updates label text, that indicates state of demonstrated CheckBox.
            Me.UpdateLabelText()
        End Sub

		''' <summary>
		''' Updates label text, that indicates state of demonstrated RadioButton.
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdateLabelText()
            Me.mobjInfoLabel.Text = String.Format("RadioButton1 is {0}!", IIf(Me.mobjRadioButton1.Checked, "checked", "unchecked"))
		End Sub

	End Class

End Namespace