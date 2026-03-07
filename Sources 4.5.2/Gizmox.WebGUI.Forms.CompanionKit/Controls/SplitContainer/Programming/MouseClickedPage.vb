Namespace CompanionKit.Controls.SplitContainer.Programming

	Public Class MouseClickedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        Private Sub mobjSplitContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSplitContainer.Click
            MessageBox.Show("You have clicked on SplitContainer!")
        End Sub


        Private Sub mobjSplitContainer1_Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSplitContainer.Panel1.Click
            MessageBox.Show("You have clicked on left panel!")
        End Sub

        Private Sub mobjSplitContainer_Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSplitContainer.Panel2.Click
            MessageBox.Show("You have clicked on right panel!")
        End Sub
	End Class

End Namespace