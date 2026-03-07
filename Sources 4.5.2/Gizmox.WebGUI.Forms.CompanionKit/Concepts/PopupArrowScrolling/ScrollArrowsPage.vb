Namespace CompanionKit.Concepts.PopupArrowScrolling

	Public Class ScrollArrowsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjArrowsRB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjArrowsRB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjArrowsRB.CheckedChanged
            'If Arrows ScrollerType is chosen
            If mobjArrowsRB.Checked Then
                mobjPanel.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.Arrows
            Else
                'If Default ScrollerType is chosen
                mobjPanel.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.[Default]
            End If
        End Sub
    End Class

End Namespace