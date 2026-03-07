Namespace CompanionKit.Controls.GroupBox.Features

	Public Class ContextMenuPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handels Click event for Context menu item.
        ''' Shows message box.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMenuItem1.Click, mobjMenuItem2.Click, mobjMenuItem3.Click, mobjMenuItem4.Click, mobjMenuItem5.Click
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)
            If (Not menuItem Is Nothing) Then
                Me.mobjLabel.Text = String.Format("You've selected '{0}' menu item.", menuItem.Text)
            End If

        End Sub
	End Class

End Namespace