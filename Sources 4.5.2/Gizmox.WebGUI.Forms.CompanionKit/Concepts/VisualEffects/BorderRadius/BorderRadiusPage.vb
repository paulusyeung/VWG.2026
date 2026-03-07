Namespace CompanionKit.Concepts.VisualEffects.BorderRadius

	Public Class BorderRadiusPage
        'Define RadiusAll value
        Public intRadius As Integer = 20
        'Define BorderRadius Visual Effect
        Public mobjVE As Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect
		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Set default Visual Effect for TextBox
            mobjVE = New Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect(intRadius)
            mobjTextBox.VisualEffect = mobjVE

        End Sub

       

        ''' <summary>
        ''' Handles the Click event of the mobjMinusButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMinusButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjMinusButton.Click
            'Decrease RadiusAll value

            If (intRadius >= 5) Then intRadius = intRadius - 5 Else intRadius = intRadius

            mobjVE.BorderRadiusAll = intRadius
            mobjTextBox.Update()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjPlusButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPlusButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjPlusButton.Click
            'Increase RadiusAll value

            If (intRadius <= 70) Then intRadius = intRadius + 5 Else intRadius = intRadius

            mobjVE.BorderRadiusAll = intRadius
            mobjTextBox.Update()
        End Sub
    End Class

End Namespace