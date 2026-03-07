Namespace CompanionKit.Controls.WorkspaceTabs.PopulatingData

	Public Class TabPagesCollectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            'Adds to TabPages collection new WorkspaceTab item
            Dim mobjWorkspaceTab As New WorkspaceTab()
            mobjWorkspaceTab.Text = String.Format("workspaceTab{0}", mobjWorkspaceTabs.TabPages.Count + 1)
            mobjWorkspaceTab.BackColor = Drawing.Color.FromArgb(255, 255, 192)
            mobjWorkspaceTabs.TabPages.Add(mobjWorkspaceTab)
        End Sub

        ''' <summary>
        ''' Handles the CloseClick event of the mobjWorkspaceTabs control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjWorkspaceTabs_CloseClick(sender As Object, e As EventArgs) Handles mobjWorkspaceTabs.CloseClick
            'Gets index of last item
            Dim mintIndex As Integer = mobjWorkspaceTabs.TabPages.Count - 1
            'If index more or equal zero, then remove item with such an index
            If mintIndex >= 0 Then
                mobjWorkspaceTabs.TabPages.RemoveAt(mintIndex)
            End If
        End Sub
    End Class

End Namespace