Namespace CompanionKit.Concepts.ControlBehavior.Droppable

	Public Class DroppablePage
        'Define bool value indicating whether Label already exists on panel
        Public blnLabelExists As Boolean
        'Define Labels array
        Public mobjLabelsArray As Label()
		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill Labels array
            mobjLabelsArray = New Label() {mobjRedLbl1, mobjYellowLbl1, mobjYellowLbl2, mobjBlueLbl, mobjRedLbl2}

		End Sub

        ''' <summary>
        ''' Handles the ControlDropped event of the mobjPanel control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        Private Sub mobjPanel_ControlDropped(sender As System.Object, e As Gizmox.WebGUI.Forms.ControlEventArgs) Handles mobjPanel.ControlDropped
            blnLabelExists = False
            'For each Label on Panel
            For Each mobjLabel As Control In mobjPanel.Controls
                'If label with this name is already on panel
                If mobjLabel.Text = e.Control.Text Then
                    'Show warning message
                    MessageBox.Show(e.Control.Text + " already exists")
                    'Change blnLabelExists value
                    blnLabelExists = True
                    'Change the Text property of the same label on panel
                    mobjLabel.Text += "(2)"
                    'Hide duplicated Label
                    e.Control.Hide()
                End If
            Next

            'If dropped Label doesn't exist on Panel
            If Not blnLabelExists Then
                'Add dropped Label to Panel
                mobjPanel.Controls.Add(e.Control)
                e.Control.Dock = DockStyle.Top
                e.Control.BringToFront()
            End If

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjClearButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjClearButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjClearButton.Click
            'Define Labels counter
            Dim i As Integer = 0
            'For each Label in array
            For j As Integer = 0 To mobjLabelsArray.Length - 1
                'Bring the Label back on its default location with default Text
                mobjLabelsArray(i).Show()
                mobjLabelsArray(i).Text = mobjLabelsArray(i).Text.Replace("(2)", "")
                mobjLabelsArray(i).Parent = Me
                mobjLabelsArray(i).Dock = DockStyle.None
                mobjLabelsArray(i).Location = New Drawing.Point(10, 70 + 45 * i)
                i += 1
            Next
        End Sub
    End Class

End Namespace