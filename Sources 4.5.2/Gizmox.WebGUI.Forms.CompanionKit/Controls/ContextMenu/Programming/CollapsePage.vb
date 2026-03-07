Namespace CompanionKit.Controls.ContextMenu.Programming

	Public Class CollapsePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

       ''' <summary>
        ''' Handles Collapse event for ContextMenu.
        ''' Changes text of the label that indicates whether ContextMenu is collapsed.
        ''' </summary>
        Private Sub mobjContextMenu_Collapse(sender As Object, e As EventArgs) Handles mobjContextMenu.Collapse
            UpdateLabel(False)
        End Sub

        ''' <summary>
        ''' Handles Click event for Menu item.
        ''' Changes text of label that represents information abour clicked item.
        ''' </summary>
        Private Sub mobjMenuItem_Click(sender As Object, e As EventArgs) Handles mobjMenuItem1.Click, mobjMenuItem2.Click, mobjMenuItem3.Click
            Dim mobjMenuItem As MenuItem = TryCast(sender, MenuItem)
            If mobjMenuItem IsNot Nothing Then
                Me.mobjLabel1.Text = String.Format("You've selected '{0}' menu item.", mobjMenuItem.Text)
                CenterLabel(mobjLabel1)
            End If
        End Sub

        ''' <summary>
        ''' Handles Popup event for ContextMenu.
        ''' Changes text of the label that indicates whether ContextMenu is popped up.
        ''' </summary>
        Private Sub mobjContextMenu_Popup(sender As Object, e As EventArgs) Handles mobjContextMenu.Popup
            UpdateLabel(True)
        End Sub

        ''' <summary>
        ''' Update text and location of the label.
        ''' </summary>
        ''' <param name="isPopuped">Indicates whether context menu is popped up</param>
        Private Sub UpdateLabel(isPopuped As Boolean)
            Me.mobjLabel2.Text = String.Format("ContexMenu is{0} shown!", IIf(isPopuped, "", "n't"))
            CenterLabel(mobjLabel2)
        End Sub

        ''' <summary>
        ''' Centers label on the user control.
        ''' </summary>
        ''' <param name="ctrLabel">the label that should be centered</param>
        Private Sub CenterLabel(ctrLabel As Label)
            ctrLabel.Location = New System.Drawing.Point((637 - ctrLabel.Width) / 2, ctrLabel.Location.Y)
        End Sub
    End Class
End Namespace
