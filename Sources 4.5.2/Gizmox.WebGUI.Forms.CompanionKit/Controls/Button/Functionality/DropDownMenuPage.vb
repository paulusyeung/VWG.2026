Namespace CompanionKit.Controls.Button.Functionality

	Public Class DropDownMenuPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the MenuItem control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem1.Click, menuItem4.Click, menuItem3.Click, menuItem2.Click
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)
            MessageBox.Show(String.Format("Menu Item '{0}' has been clicked!", menuItem.Text))
        End Sub
	End Class

End Namespace