Namespace CompanionKit.Controls.TreeView.Features

	Public Class NodesDragingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles DragDrop event that is fired when a drag-and-drop operation is completed.
        ''' Adds draged TreeView node in to ListBox
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub mobjAllowedDropListBox_DragDrop(sender As Object, e As DragEventArgs) Handles mobjAllowedDropListBox.DragDrop
            Dim mobjDragDropEventArgs As DragDropEventArgs = TryCast(e, DragDropEventArgs)
            If mobjDragDropEventArgs IsNot Nothing Then
                Me.mobjAllowedDropListBox.Items.Add(DirectCast(mobjDragDropEventArgs.Source, TreeNode).Text)
            End If
        End Sub
	End Class

End Namespace