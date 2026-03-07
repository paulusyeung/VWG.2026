Namespace CompanionKit.Concepts.VisualEffects.BoxShadow

    Public Class BoxShadowPage

        'Constants of BoxShadow's parameters
        Const mintHorizontalShadow As Integer = 15
        Const mintVericalShadow As Integer = 15
        Const mintBlurDistance As Integer = 5
        Const mintSpreadDistance As Integer = 5

        'Global variables
        Private mblnInset As Boolean
        Private mobjColorShadow As Drawing.Color = Drawing.Color.Black

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
        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjToggleButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjToggleButton_Click(sender As Object, e As EventArgs) Handles mobjToggleButton.Click
            'Applies/removes BoxShadow visual effect to/from MonthCalendar control
            mobjColorShadow = mobjColorDialog.Color
            mobjMonthCalendar.VisualEffect = IIf(mobjMonthCalendar.VisualEffect IsNot Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.BoxShadowVisualEffect(mintHorizontalShadow, mintVericalShadow, mintBlurDistance, mintSpreadDistance, mobjColorShadow, mblnInset))
            mobjMonthCalendar.Update()

            'Toggles button's text
            mobjToggleButton.Text = IIf(mobjMonthCalendar.VisualEffect Is Nothing, "Show BoxShadow", "Hide BoxShadow")
        End Sub


        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjShadowInsetCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShadowInsetCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjShadowInsetCheckBox.CheckedChanged
            'Updates boolean inset value
            mblnInset = mobjShadowInsetCheckBox.Checked
            'Updates BoxShadow visual effect
            UpdateBoxShadowVisualEffect()
        End Sub


        ''' <summary>
        ''' Handles the BackColorChanged event of the mobjColorPanel control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColorPanel_BackColorChanged(sender As Object, e As EventArgs) Handles mobjColorPanel.BackColorChanged
            'Updates shadow color value
            mobjColorShadow = mobjColorPanel.BackColor
            'Updates BoxShadow visual effect
            UpdateBoxShadowVisualEffect()
        End Sub

        ''' <summary>
        ''' Updates the box shadow visual effect.
        ''' </summary>
        Private Sub UpdateBoxShadowVisualEffect()
            'If MonthCalendar already has visual effect, then update it
            If mobjMonthCalendar.VisualEffect IsNot Nothing Then
                mobjMonthCalendar.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.BoxShadowVisualEffect(mintHorizontalShadow, mintVericalShadow, mintBlurDistance, mintSpreadDistance, mobjColorShadow, mblnInset)
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjChooseColorButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjChooseColorButton_Click(sender As Object, e As EventArgs) Handles mobjChooseColorButton.Click
            'Opens dialog
            mobjColorDialog.ShowDialog()
        End Sub

    End Class

End Namespace