

Namespace CompanionKit.Controls.CheckBox.Appearance

	Public Class CheckAlignPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Populate Text Align and Check Align ComboBoxes with appropriate values and set default selected items
            mobjTextCB.DataSource = [Enum].GetValues(GetType(Drawing.ContentAlignment))
            mobjCheckCB.DataSource = [Enum].GetValues(GetType(Drawing.ContentAlignment))
		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjTextCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjTextCB.SelectedIndexChanged
            'Change TextAlign property of CheckBox
            mobjCheckBox.TextAlign = DirectCast(mobjTextCB.SelectedItem, Drawing.ContentAlignment)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjCheckCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjCheckCB.SelectedIndexChanged
            'Change CheckAlign property of CheckBox
            mobjCheckBox.CheckAlign = DirectCast(mobjCheckCB.SelectedItem, Drawing.ContentAlignment)
        End Sub
    End Class

End Namespace