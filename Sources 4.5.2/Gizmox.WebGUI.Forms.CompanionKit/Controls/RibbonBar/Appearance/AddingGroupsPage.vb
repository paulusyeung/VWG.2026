Namespace CompanionKit.Controls.RibbonBar.Appearance

	Public Class AddingGroupsPage
		Inherits UserControl
		' Methods
		Public Sub New()
			Me.InitializeComponent()
			Me.demoRibbonBar.SelectedIndex = 0
			Me.SelectedIndexChanged(Me.demoRibbonBar, New EventArgs)
		End Sub

		Private Sub AdvancedClicked(ByVal sender As Object, ByVal e As RibbonBarGroupArgs)
			If ((Not e Is Nothing) AndAlso (Not e.Group Is Nothing)) Then
				Me.lblAdvanced.Visible = True
				Me.lblAdvanced.Text = String.Format("The advanced anchor: {0}", e.Group.Text)
			End If
		End Sub

		Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.demoRibbonBar.SelectedIndex > -1) Then
				Dim objPage As RibbonBarPage = Me.demoRibbonBar.Pages.Item(Me.demoRibbonBar.SelectedIndex)
				If (Not objPage Is Nothing) Then
					Me.lblStatus.Text = String.Format("The active page: {0}", objPage.Text)
				End If
			End If
		End Sub
	End Class

End Namespace

