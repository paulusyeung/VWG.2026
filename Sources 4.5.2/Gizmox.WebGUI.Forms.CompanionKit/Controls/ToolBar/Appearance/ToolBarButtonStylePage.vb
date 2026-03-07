Namespace CompanionKit.Controls.ToolBar.Appearance

	Public Class ToolBarButtonStylePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

		''' <summary>
		''' Handles Click event of DropDown menu items
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <remarks></remarks>
		Private Sub MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click, MenuItem4.Click, MenuItem3.Click, MenuItem2.Click
			Dim menuItem As MenuItem = TryCast(sender, MenuItem)
			MessageBox.Show(String.Format("Menu Item {0} has been clicked!", menuItem.Text))

		End Sub

        ''' <summary>
        ''' Handles click event for ToolBars' Buttons.
        ''' </summary>
        Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
            If (Not e.Button Is Nothing) Then
                Select Case e.Button.Style
                    Case ToolBarButtonStyle.PushButton
                        MessageBox.Show("Pushed button has been clicked!")
                        Return
                    Case ToolBarButtonStyle.ToggleButton
                        MessageBox.Show(String.Format("Toggle button is turn {0}!", IIf(e.Button.Pushed, "on", "off")))
                        Return
                End Select
                MessageBox.Show(String.Format("ToolBar button '{0}' is clicked with {1} style!", e.Button.Name, e.Button.Style))
            End If
        End Sub
    End Class

End Namespace