Namespace CompanionKit.Controls.TreeView.Features

	Public Class ContextMenuPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles click event for menu item that adds node to TreeView.
        ''' If TreeView contains selected node, a new node is added as child of selected node. 
        ''' Otherwise, a new node is added as parent node into the TreeView.
        ''' </summary>
        Private Sub mobjAddNodeMenuItem_Click(sender As Object, e As EventArgs) Handles mobjAddNodeMenuItem.Click
            ' Create a new node
            Dim mobjAddedNode As New TreeNode("Added Node")
            Dim mobjSelectedNode As TreeNode = Me.mobjTreeView.SelectedNode

            ' Check whether TreeView contains selected node.
            ' If TreeView contains selected node, a new node is added as child of selected node. 
            ' Otherwise, a new node is added as parent node into the TreeView.
            If mobjSelectedNode IsNot Nothing Then
                mobjSelectedNode.Nodes.Add(mobjAddedNode)
            Else
                Me.mobjTreeView.Nodes.Add(mobjAddedNode)
            End If

            Me.mobjTreeView.SelectedNode = mobjAddedNode
        End Sub

        ''' <summary>
        ''' Handles click event for menu item that removes seleted node to TreeView.
        ''' </summary>
        Private Sub mobjRemoveNadeMenuItem_Click(sender As Object, e As EventArgs) Handles mobjRemoveNadeMenuItem.Click
            Dim mobjSelectedNode As TreeNode = Me.mobjTreeView.SelectedNode
            If mobjSelectedNode IsNot Nothing Then
                Dim mobjParentNode As TreeNode = mobjSelectedNode.Parent
                If mobjParentNode IsNot Nothing Then
                    mobjParentNode.Nodes.Remove(mobjSelectedNode)
                Else
                    Me.mobjTreeView.Nodes.Remove(mobjSelectedNode)
                End If
                Me.mobjTreeView.SelectedNode = Nothing
            End If

        End Sub

        ''' <summary>
        ''' Handles click event for menu item that shows informations about seleted 
        ''' node of the TreeView.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub mobjViewNodeMenuItem_Click(sender As Object, e As EventArgs) Handles mobjViewNodeMenuItem.Click
            Dim mobjSelectedNode As TreeNode = Me.mobjTreeView.SelectedNode
            If mobjSelectedNode IsNot Nothing Then
                MessageBox.Show(String.Format("You are viewing information about '{0}' tree node.", mobjSelectedNode.Text))
            Else
                MessageBox.Show("Please select node for viewing!")
            End If
        End Sub

        ''' <summary>
        ''' Disabels or enable view and remove context menu items according
        ''' to whether TreeView contains selected node.
        ''' </summary>
        Private Sub mobjContextMenu_Popup(sender As Object, e As EventArgs) Handles mobjContextMenu.Popup
            If Me.mobjTreeView.SelectedNode IsNot Nothing Then
                If Not Me.mobjRemoveNadeMenuItem.Enabled Then
                    Me.mobjRemoveNadeMenuItem.Enabled = True
                End If

                If Not Me.mobjViewNodeMenuItem.Enabled Then
                    Me.mobjViewNodeMenuItem.Enabled = True
                End If
            Else
                If Me.mobjRemoveNadeMenuItem.Enabled Then
                    Me.mobjRemoveNadeMenuItem.Enabled = False
                End If

                If Me.mobjViewNodeMenuItem.Enabled Then
                    Me.mobjViewNodeMenuItem.Enabled = False
                End If
            End If
        End Sub
    End Class

End Namespace