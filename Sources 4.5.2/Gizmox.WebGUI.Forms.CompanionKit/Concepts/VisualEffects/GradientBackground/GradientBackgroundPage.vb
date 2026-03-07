Namespace CompanionKit.Concepts.VisualEffects.GradientBackground

	Public Class GradientBackgroundPage

        'Global variables: color1, color2, enmGradienType 
        Private mobjColor1 As Drawing.Color = Drawing.Color.Black
        Private mobjColor2 As Drawing.Color = Drawing.Color.White
        Private mobjGradientType As Gizmox.WebGUI.Forms.VisualEffects.GradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Linear

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

       ''' <summary>
        ''' Handles the Click event of the mobjToggleButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjToggleButton_Click(sender As Object, e As EventArgs) Handles mobjToggleButton.Click
            'If ListBox doesn't have effect -- applies GradientBackground visual effect, otherwise -- remove it
            mobjListBox.VisualEffect = IIf(mobjListBox.VisualEffect IsNot Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.GradientBackgroundVisualEffect(mobjGradientType, Nothing, Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, New Gizmox.WebGUI.Forms.VisualEffects.GradientStop() {New Gizmox.WebGUI.Forms.VisualEffects.GradientStop(Nothing, mobjColor1, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent), New Gizmox.WebGUI.Forms.VisualEffects.GradientStop(Nothing, mobjColor2, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent)}, Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle, _
             Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.ExtentKeyword.FarthestCorner, Nothing, Nothing))
            mobjListBox.Update()

            'Toggles button's text
            mobjToggleButton.Text = IIf(mobjListBox.VisualEffect Is Nothing, "Show GradientBackground", "Hide GradientBackground")
        End Sub


        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjGradientTypeComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjGradientTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjGradientTypeComboBox.SelectedIndexChanged
            'Defines enmGradientType variable according to selected comboBox item
            Select Case mobjGradientTypeComboBox.SelectedIndex
                Case 0
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Linear
                    Exit Select
                Case 1
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Radial
                    Exit Select
                Case 2
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.RepeatingLinearGradient
                    Exit Select
                Case 3
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.RepeatingRadialGradient
                    Exit Select
            End Select
            'Updates GradientBackground visual effect
            UpdateGradientBackgroundVisualEffect()
        End Sub

        ''' <summary>
        ''' Handles the Closed event of the mobjColorDialog1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColorDialog1_Closed(sender As Object, e As EventArgs) Handles mobjColor1Dialog.Closed
            mobjColor1 = mobjColor1Dialog.Color
            mobjColor1Panel.BackColor = mobjColor1
        End Sub

        ''' <summary>
        ''' Handles the Closed event of the mobjColorDialog2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColorDialog2_Closed(sender As Object, e As EventArgs) Handles mobjColor2Dialog.Closed
            mobjColor2 = mobjColor2Dialog.Color
            mobjColor2Panel.BackColor = mobjColor2
        End Sub

        ''' <summary>
        ''' Updates the gradient background visual effect.
        ''' </summary>
        Private Sub UpdateGradientBackgroundVisualEffect()
            'Updates GradientBackground visual effect, if such effect already exists
            If mobjListBox.VisualEffect IsNot Nothing Then
                mobjListBox.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.GradientBackgroundVisualEffect(mobjGradientType, Nothing, Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, New Gizmox.WebGUI.Forms.VisualEffects.GradientStop() {New Gizmox.WebGUI.Forms.VisualEffects.GradientStop(Nothing, mobjColor1, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent), New Gizmox.WebGUI.Forms.VisualEffects.GradientStop(Nothing, mobjColor2, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent)}, Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle, _
                 Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.ExtentKeyword.FarthestCorner, Nothing, Nothing)
                mobjListBox.Update()
            End If
        End Sub

        ''' <summary>
        ''' Handles the BackColorChanged event of the panel controls
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ColorPanelBackColorChanged(sender As Object, e As EventArgs) Handles mobjColor1Panel.BackColorChanged, mobjColor2Panel.BackColorChanged
            UpdateGradientBackgroundVisualEffect()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjColor1ChooseButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColor1ChooseButton_Click(sender As Object, e As EventArgs) Handles mobjColor1ChooseButton.Click
            mobjColor1Dialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjColor2ChooseButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColor2ChooseButton_Click(sender As Object, e As EventArgs) Handles mobjColor2ChooseButton.Click
            mobjColor2Dialog.ShowDialog()
        End Sub

	End Class

End Namespace