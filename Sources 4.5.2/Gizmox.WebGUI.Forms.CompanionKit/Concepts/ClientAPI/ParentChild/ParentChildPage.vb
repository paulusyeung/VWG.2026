Namespace CompanionKit.Concepts.ClientAPI.ParentChild

	Public Class ParentChildPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the objToSecondPanelButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub objToSecondPanelButton_Click(sender As System.Object, e As System.EventArgs) Handles objToSecondPanelButton.Click
            VWGClientContext.Current.Invoke("sendCheckedControls", objFirstParentPanel.ID, objSecondParentPanel.ID)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objToFirstPanelButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub objToFirstPanelButton_Click(sender As System.Object, e As System.EventArgs) Handles objToFirstPanelButton.Click
            VWGClientContext.Current.Invoke("sendCheckedControls", objSecondParentPanel.ID, objFirstParentPanel.ID)
        End Sub
    End Class

End Namespace