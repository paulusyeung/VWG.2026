Namespace CompanionKit.Controls.RadioButton.Appearance

	Public Class ButtonAppearancePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Applies selected ButtonAppearance type
            Dim mobjAppearanceType As Gizmox.WebGUI.Forms.Appearance
            If (mobjComboBox.SelectedIndex = 0) Then
                mobjAppearanceType = Gizmox.WebGUI.Forms.Appearance.Normal
            Else
                mobjAppearanceType = Gizmox.WebGUI.Forms.Appearance.Button
            End If

            mobjRadioButton1.Appearance = mobjAppearanceType
            mobjRadioButton2.Appearance = mobjAppearanceType
            mobjRadioButton3.Appearance = mobjAppearanceType
        End Sub
    End Class

End Namespace