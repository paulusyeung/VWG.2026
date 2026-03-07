Namespace CompanionKit.Concepts.VisualEffects.Translate

	Public Class TranslatePage

        'Duration constant
        Const mintDuration As Integer = 3

        'Declares global variables: Horizontal and Vertical length 
        Private mfltHorizontalLength As Single
        Private mfltVerticalLength As Single

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
            'Clears all visual effects
            mobjPanel.VisualEffect = Nothing
            'Applies Translate visual effect to panel control
            mobjPanel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.TranslateVisualEffect(New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing), New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, mfltHorizontalLength, mfltVerticalLength, Nothing), New Decimal(New Integer() {mintDuration, 0, 0, 0}), New Decimal(New Integer() {0, 0, 0, 0}), Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease)
        End Sub


        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjHorizontalCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjHorizontalCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjHorizontalCheckBox.CheckedChanged
            'if mobjHorizontalCheckBox checked -- calculate and set horizontal length, otherwise -- set null
            If (mobjHorizontalCheckBox.Checked) Then
                mfltHorizontalLength = mobjBottomPanel.Size.Width * (1.9F / 3.0F)
            Else
                mfltHorizontalLength = Nothing
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjVerticalCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjVerticalCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjVerticalCheckBox.CheckedChanged
            'if mobjVerticalCheckBox checked -- calculate and set vertical length, otherwise -- set null
            If (mobjVerticalCheckBox.Checked) Then
                mfltVerticalLength = mobjBottomPanel.Size.Height * (1.7F / 3.0F)
            Else
                mfltVerticalLength = Nothing
            End If
        End Sub

        ''' <summary>
        ''' Handles the Load event of the TranslatePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub TranslatePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Changes checkBoxes's state to "true" 
            mobjVerticalCheckBox.Checked = True
            mobjHorizontalCheckBox.Checked = True
        End Sub

	End Class

End Namespace