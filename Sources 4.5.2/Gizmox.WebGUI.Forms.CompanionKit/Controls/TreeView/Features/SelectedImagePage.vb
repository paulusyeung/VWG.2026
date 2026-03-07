Namespace CompanionKit.Controls.TreeView.Features

	Public Class SelectedImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Sets image list that is used for TreeView node
            Me.mobjTreeView.ImageList = New ImageList
            Me.mobjTreeView.ImageList.Images.Add(New ImageResourceHandle("16x16.SelectedTreeNode.gif"))
            Me.mobjTreeView.ImageList.Images.Add(New ImageResourceHandle("16x16.DefaultTreeNode.gif"))

            ' Sets image index for tree node of normal and selected node.
            Me.mobjTreeView.ImageIndex = 1
            Me.mobjTreeView.SelectedImageIndex = 0

		End Sub
	End Class

End Namespace