Namespace CompanionKit.Controls.CheckBox.Appearance

	Public Class SwitchAppPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjCheckBox.CheckedChanged
            'Change Label Text in accordance to CheckedState of CheckBox
            If mobjCheckBox.Checked Then mobjCheckedLabel.Text = "Checked" Else mobjCheckedLabel.Text = "Unchecked"
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjNormalRB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNormalRB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjNormalRB.CheckedChanged
            'Switch CheckBox appearance
            If mobjNormalRB.Checked Then
                mobjCheckBox.Appearance = Gizmox.WebGUI.Forms.Appearance.Normal
            Else
                mobjCheckBox.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            End If
        End Sub
    End Class

End Namespace