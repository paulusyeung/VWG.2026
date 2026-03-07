Namespace CompanionKit.Controls.ListBox.Functionality

	Public Class DragDropPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        ''' <summary>
        ''' Handles the DragDrop event of the mobjListBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="global.Gizmox.WebGUI.Forms.DragEventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox2_DragDrop(ByVal sender As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.DragEventArgs) Handles mobjListBox2.DragDrop
            If TypeOf e Is DragDropEventArgs Then
                Dim dragDropEventArgs As DragDropEventArgs = TryCast(e, DragDropEventArgs)
                If TypeOf dragDropEventArgs.Source Is Global.Gizmox.WebGUI.Forms.ListBox Then
                    Dim addedItem As String = TryCast(DirectCast(dragDropEventArgs.Source, Global.Gizmox.WebGUI.Forms.ListBox).SelectedItem, String)
                    If (Not addedItem Is Nothing) Then
                        Me.mobjListBox2.Items.Add(addedItem)
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAllowDrop control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAllowDrop_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjAllowDrop.CheckedChanged
            mobjListBox2.AllowDrop = mobjAllowDrop.Checked
        End Sub
    End Class

End Namespace