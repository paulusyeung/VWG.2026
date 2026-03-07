Namespace CompanionKit.Controls.ComboBox.Functionality

	Public Class ForceSelectedIndexChangedOnClickPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox.CheckedChanged
            mobjComboBox.ForceSelectedIndexChangedOnClick = mobjCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            mobjTextBox.Text += "Selected index changed:" + mobjComboBox.SelectedIndex.ToString() + vbCr & vbLf
        End Sub

	End Class

End Namespace