Namespace CompanionKit.Concepts.VisualEffects.TextShadow

	Public Class TextShadowPage

        'Constants of TextShadow's parameters
        Const mintHorizontalShadow As Integer = 5
        Const mintVerticalShadow As Integer = 5
        Const mintBlurDistance As Integer = 2

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Closed event of the mobjColorDialog control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColorDialog_Closed(sender As Object, e As EventArgs) Handles mobjColorDialog.Closed
            'Applies selected color to preview panel
            mobjColorPanel.BackColor = mobjColorDialog.Color
            'Updates Label's TextShadow visual effect, if such already exists
            If mobjTextLabel.VisualEffect IsNot Nothing Then
                mobjTextLabel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.TextShadowVisualEffect(mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mobjColorPanel.BackColor)
                mobjTextLabel.Update()
            End If

        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjToggleButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjToggleButton_Click(sender As Object, e As EventArgs) Handles mobjToggleButton.Click
            'If Label doesn't have effect -- applies TextShadow visual effect, otherwise -- remove it
            mobjTextLabel.VisualEffect = IIf(mobjTextLabel.VisualEffect IsNot Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.TextShadowVisualEffect(mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mobjColorPanel.BackColor))
            mobjTextLabel.Update()

            'Toggles button's text
            mobjToggleButton.Text = IIf(mobjTextLabel.VisualEffect Is Nothing, "Show TextShadow", "Hide TextShadow")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjShadowColorButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShadowColorButton_Click(sender As Object, e As EventArgs) Handles mobjShadowColorButton.Click
            'Opens dialog
            mobjColorDialog.ShowDialog()
        End Sub

	End Class

End Namespace