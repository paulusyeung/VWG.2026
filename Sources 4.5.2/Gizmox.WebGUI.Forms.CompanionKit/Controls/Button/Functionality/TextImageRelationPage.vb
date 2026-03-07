Namespace CompanionKit.Controls.Button.Functionality

	Public Class TextImageRelationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill ComboBoxes with appropriate data
            mobjTextImageCB.DataSource = [Enum].GetValues(GetType(TextImageRelation))
            mobjTextCB.DataSource = [Enum].GetValues(GetType(Drawing.ContentAlignment))
            mobjImageCB.DataSource = [Enum].GetValues(GetType(Drawing.ContentAlignment))
		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjTextImageCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextImageCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjTextImageCB.SelectedIndexChanged
            mobjButton.TextImageRelation = DirectCast(mobjTextImageCB.SelectedItem, TextImageRelation)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjImageCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjImageCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjImageCB.SelectedIndexChanged
            mobjButton.ImageAlign = DirectCast(mobjImageCB.SelectedItem, Drawing.ContentAlignment)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjTextCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjTextCB.SelectedIndexChanged
            mobjButton.TextAlign = DirectCast(mobjTextCB.SelectedItem, Drawing.ContentAlignment)
        End Sub
    End Class

End Namespace