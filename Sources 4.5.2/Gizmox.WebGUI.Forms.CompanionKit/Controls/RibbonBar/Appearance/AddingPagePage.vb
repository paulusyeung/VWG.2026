Namespace CompanionKit.Controls.RibbonBar.Appearance

	Public Class AddingPagePage
		Inherits UserControl

		Public Sub New()
			Me.InitializeComponent()
			Me.demoRibbonBar.SelectedIndex = 0
			Me.SelectedIndexChanged(Me.demoRibbonBar, New EventArgs)
		End Sub

		Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.demoRibbonBar.SelectedIndex > -1) Then
				Dim page As RibbonBarPage = Me.demoRibbonBar.Pages.Item(Me.demoRibbonBar.SelectedIndex)
				If (Not page Is Nothing) Then
					Me.lblStatus.Text = String.Format("The active page: {0}", page.Text)
				End If
			End If
		End Sub

	End Class

End Namespace