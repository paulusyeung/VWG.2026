Namespace CompanionKit.Controls.ExpandableGroupBox.Functionality

	Public Class TextImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsSpreadCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIsSpreadCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjIsSpreadCheck.CheckedChanged
            'Change ExpandableGroupBox.IsTextImageSpread property
            mobjExpandableGroupBox.IsTextImageSpread = mobjIsSpreadCheck.Checked
        End Sub

       
        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjImageBeforeRB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjImageBeforeRB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjImageBeforeRB.CheckedChanged
            'Change ExpandableGroupBox.TextImageRelation property
            If mobjImageBeforeRB.Checked Then
                mobjExpandableGroupBox.TextImageRelation = Gizmox.WebGUI.Forms.ExpandableGroupBox.HorizontalTextImageRelation.ImageBeforeText
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjTextBeforeRB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextBeforeRB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjTextBeforeRB.CheckedChanged
            'Change ExpandableGroupBox.TextImageRelation property
            If mobjTextBeforeRB.Checked Then
                mobjExpandableGroupBox.TextImageRelation = Gizmox.WebGUI.Forms.ExpandableGroupBox.HorizontalTextImageRelation.TextBeforeImage

            End If
        End Sub
    End Class

End Namespace