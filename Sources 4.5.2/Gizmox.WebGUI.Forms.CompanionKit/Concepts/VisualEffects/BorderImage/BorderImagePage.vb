Namespace CompanionKit.Concepts.VisualEffects.BorderImage

	Public Class BorderImagePage

        'Constants of BorderImage's parameters
        Const mintBorderOffset As Integer = 5
        Const mintBorderSize As Integer = 15

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

      ''' <summary>
        ''' Handles the SelectedIndexChanged event of the objBorderRepeatComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjBorderRepeatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjBorderRepeatComboBox.SelectedIndexChanged
            If mobjBorderRepeatComboBox.SelectedIndex > 0 Then
                'Applies parameter of BorderRepeat to BorderImage visual effect, if such effect already exists
                mobjVisualButton.VisualEffect = New Gizmox.WebGUI.Common.Forms.VisualEffects.BorderImageVisualEffect(New ImageResourceHandle("border.png"), mintBorderOffset, mintBorderOffset, mintBorderOffset, mintBorderOffset, (mobjBorderRepeatComboBox.SelectedIndex - 1), _
                 (mobjBorderRepeatComboBox.SelectedIndex - 1), mintBorderSize, mintBorderSize, mintBorderSize, mintBorderSize)
                mobjVisualButton.Update()
            Else
                mobjVisualButton.VisualEffect = Nothing
                mobjVisualButton.Update()
            End If
        End Sub

	End Class

End Namespace