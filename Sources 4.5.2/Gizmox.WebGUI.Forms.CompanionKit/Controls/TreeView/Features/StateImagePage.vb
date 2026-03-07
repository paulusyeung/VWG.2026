Namespace CompanionKit.Controls.TreeView.Features

	Public Class StateImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Set the image list that is used to indicate the state of the TreeView and its nodes.
            Me.mobjTreeView.StateImageList = New ImageList
            Me.mobjTreeView.StateImageList.Images.Add(New ImageResourceHandle("16x16.DefaultTreeNode.gif"))
            Me.mobjTreeView.StateImageList.Images.Add(New ImageResourceHandle("16x16.SelectedTreeNode.gif"))

		End Sub
	End Class

End Namespace