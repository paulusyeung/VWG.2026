Namespace CompanionKit.Controls.StackPanel.Functionality

	Public Class StackPanelDemonstrationPage

		Public Sub New()
			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjHorizontalRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjHorizontalRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjHorizontalRadioButton.CheckedChanged
            'Changes StackPanel's orientation to Horizontal
            Me.mobjStackPanel.Orientation = Orientation.Horizontal
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjVerticalRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjVerticalRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjVerticalRadioButton.CheckedChanged
            'Changes StackPanel's orientation to Vertical
            Me.mobjStackPanel.Orientation = Orientation.Vertical
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjAddButton.Click
            'Adds new label to StackPanel's controls collection
            Dim objLabel As New Label()
            objLabel.Text = "Label#" & Convert.ToString((Me.mobjStackPanel.Controls.Count + 1))
            objLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            objLabel.BackColor = Drawing.Color.LightBlue
            Me.mobjStackPanel.Controls.Add(objLabel)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRemoveButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjRemoveButton.Click
            'If control collection is not empty - remove last item
            If Me.mobjStackPanel.Controls.Count > 0 Then
                Me.mobjStackPanel.Controls.RemoveAt(Me.mobjStackPanel.Controls.Count - 1)
            End If
        End Sub
    End Class

End Namespace