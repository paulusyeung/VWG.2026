Namespace CompanionKit.Controls.TreeView.Features

	Public Class TreeViewItemsSortingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjSortCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSortCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjSortCheckBox.CheckedChanged
            'Gets CheckBox's state
            Dim mblnState As Boolean = DirectCast(sender, Gizmox.WebGUI.Forms.CheckBox).Checked
            'Changes label text accrding to checked state
            mobjLabel.Text = IIf(mblnState, "Nodes are sorted", "Nodes are not sorted")
            'Sets sorted state
            mobjTreeView.Sorted = mblnState
            'If Sorted = false - clear all nodes and new ones (unsorted list)
            If Not mobjTreeView.Sorted Then
                mobjTreeView.Nodes.Clear()
                mobjTreeView.Nodes.AddRange(New TreeNode() {New TreeNode("A item"), New TreeNode("X item"), New TreeNode("Y item"), New TreeNode("I item"), New TreeNode("J item"), New TreeNode("K item"), _
                 New TreeNode("L item"), New TreeNode("M item"), New TreeNode("N item"), New TreeNode("O item"), New TreeNode("B item"), New TreeNode("C item"), _
                 New TreeNode("T item"), New TreeNode("U item"), New TreeNode("V item"), New TreeNode("D item"), New TreeNode("H item"), New TreeNode("E item"), _
                 New TreeNode("F item"), New TreeNode("G item"), New TreeNode("P item"), New TreeNode("Q item"), New TreeNode("R item"), New TreeNode("S item"), _
                 New TreeNode("W item"), New TreeNode("Z item")})
            End If
        End Sub
    End Class

End Namespace