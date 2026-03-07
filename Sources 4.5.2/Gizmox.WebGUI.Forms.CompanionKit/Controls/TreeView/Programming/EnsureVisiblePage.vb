Namespace CompanionKit.Controls.TreeView.Programming

	Public Class EnsureVisiblePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            Me.mobjTreeView.ExpandAll()

            ' Fills up the ComboBox with tree nodes.
            AddTreeNodesToComboBox(Me.mobjTreeView.Nodes)
            Me.mobjComboBox.DisplayMember = "Text"
            Me.mobjComboBox.Sorted = True
        End Sub

        ''' <summary>
        ''' Fills up the ComboBox with tree nodes.
        ''' </summary>
        ''' <param name="treeNodes">Tree nodes collection</param>
        Private Sub AddTreeNodesToComboBox(treeNodes As TreeNodeCollection)
            For Each mobjTreeNode As TreeNode In treeNodes
                Me.mobjComboBox.Items.Add(mobjTreeNode)
                If mobjTreeNode.Nodes IsNot Nothing AndAlso mobjTreeNode.Nodes.Count > 0 Then
                    AddTreeNodesToComboBox(mobjTreeNode.Nodes)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox that 
        ''' selects selected node in the TreeView
        ''' </summary>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            If Me.mobjComboBox.SelectedItem IsNot Nothing Then
                Me.mobjTreeView.SelectedNode = DirectCast(Me.mobjComboBox.SelectedItem, TreeNode)
                If Me.mobjTreeView.SelectedNode IsNot Nothing Then
                    ' Ensure selected node scrolled into view and visible
                    Me.mobjTreeView.SelectedNode.EnsureVisible()
                End If
            End If
        End Sub

        ''' <summary>
        ''' Handles AfterSelect event of the TreeView that 
        ''' changed selected node in the ComboBox
        ''' </summary>
        Private Sub mobjTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles mobjTreeView.AfterSelect
            If Me.mobjTreeView.SelectedNode IsNot Nothing Then
                Me.mobjComboBox.SelectedItem = Me.mobjTreeView.SelectedNode
            End If
        End Sub

	End Class

End Namespace
