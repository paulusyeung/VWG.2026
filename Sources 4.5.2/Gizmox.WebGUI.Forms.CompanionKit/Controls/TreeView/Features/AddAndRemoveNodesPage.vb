Namespace CompanionKit.Controls.TreeView.Features

	Public Class AddAndRemoveNodesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles click event for the button that removes selected node from the TreeView
        ''' </summary>
        Private Sub mobjRemoveButton_Click(sender As Object, e As EventArgs) Handles mobjRemoveButton.Click
            Dim mobjSelectedNode As TreeNode = Me.mobjTreeView.SelectedNode
            If mobjSelectedNode IsNot Nothing Then
                Dim mobjParentNode As TreeNode = mobjSelectedNode.Parent
                If mobjParentNode IsNot Nothing Then
                    mobjParentNode.Nodes.Remove(mobjSelectedNode)
                Else
                    Me.mobjTreeView.Nodes.Remove(mobjSelectedNode)
                End If
                Me.mobjTreeView.SelectedNode = Nothing
            Else
                MessageBox.Show("Please selected node, that should be removed!")
            End If
        End Sub

        ''' <summary>
        ''' Handles click event for the button that adds selected node from the TreeView
        ''' </summary>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            ' Get added node name.
            Dim mstrAddedNodeText As String = Me.mobjTextBox.Text

            ' Check whether added node name was entered. 
            ' If the name hasn't been entered show error message.
            If String.IsNullOrEmpty(mstrAddedNodeText) Then
                MessageBox.Show("Please input text for added item!")
                Return
            End If
            ' Create a new node and add to TreeView as child node of selected node.
            Dim mobjAddedNode As New TreeNode(mstrAddedNodeText)
            Dim mobjSelectedNode As TreeNode = Me.mobjTreeView.SelectedNode
            If mobjSelectedNode IsNot Nothing Then
                mobjSelectedNode.Nodes.Add(mobjAddedNode)
            Else
                Me.mobjTreeView.Nodes.Add(mobjAddedNode)
            End If

            Me.mobjTreeView.SelectedNode = mobjAddedNode
        End Sub
	End Class

End Namespace