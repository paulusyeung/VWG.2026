Namespace CompanionKit.Controls.CheckBox.Functionality

	Public Class ThreeStatePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
            'Populate ComboBox with the values of CheckState property
            mobjStateCombo.DataSource = [Enum].GetValues(GetType(CheckState))

            'Update Label showing current CheckState
            UpdateLabelText()

		End Sub


        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjStateCombo control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjStateCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjStateCombo.SelectedIndexChanged

            'Change CheckBox.CheckState according to selected item in ComboBox
            mobjCheckBox.CheckState = DirectCast(mobjStateCombo.SelectedItem, CheckState)
        End Sub

        ''' <summary>
        ''' Updates the label text to show current CheckState property value.
        ''' </summary>
        Private Sub UpdateLabelText()
            mobjStateLabel.Text = "CheckBox State: " + mobjCheckBox.CheckState.ToString()
        End Sub

        ''' <summary>
        ''' Handles the CheckStateChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles mobjCheckBox.CheckStateChanged
            'Change selected item in ComboBox according to current CheckBox.CheckState
            mobjStateCombo.SelectedItem = mobjCheckBox.CheckState

            'Update Label showing current CheckState
            UpdateLabelText()
        End Sub
    End Class

End Namespace