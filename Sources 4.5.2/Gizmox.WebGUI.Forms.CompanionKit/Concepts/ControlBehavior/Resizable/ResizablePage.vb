Namespace CompanionKit.Concepts.ControlBehavior.Resizable

	Public Class ResizablePage
        Public objResizeOptions As New ResizableOptions(True, New Gizmox.WebGUI.Forms.Component(-1) {}, False, 500, False, False, Gizmox.WebGUI.Forms.ContainmentMode.None, False, 0, 0)
		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub


        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAspectRatio control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjAspectRatio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjAspectRatio.CheckedChanged
            'Change AspectRatio value
            objResizeOptions.AspectRatio = mobjAspectRatio.Checked
            mobjPanel.Resizable = objResizeOptions
            mobjPanel.Update()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsGhost control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjIsGhost_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjIsGhost.CheckedChanged
            'Change Ghost value
            objResizeOptions.Ghost = mobjIsGhost.Checked
            mobjPanel.Resizable = objResizeOptions
            mobjPanel.Update()
            'Disable Grid NumericUpDown if Ghost = true or Animate = true
            mobjGridNUD.Enabled = Not (mobjIsAnimated.Checked OrElse mobjIsGhost.Checked)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsAnimated control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjIsAnimated_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjIsAnimated.CheckedChanged
            'Change Animate value
            objResizeOptions.Animate = mobjIsAnimated.Checked
            mobjPanel.Resizable = objResizeOptions
            mobjPanel.Update()
            'Disable Grid NumericUpDown if Ghost = true or Animate = true
            mobjGridNUD.Enabled = Not (mobjIsAnimated.Checked OrElse mobjIsGhost.Checked)
        End Sub


        ''' <summary>
        ''' Handles the Resize event of the mobjPanel control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjPanel_Resize(sender As System.Object, e As System.EventArgs) Handles mobjPanel.Resize
            'Update text of Label representing current panel size
            mobjLabelSize.Text = "Size: {" + mobjPanel.Width.ToString() + ", " + mobjPanel.Height.ToString() + "}"
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjResetButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjResetButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjResetButton.Click
            'Reset panel size
            mobjPanel.Size = New Drawing.Size(100, 100)
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjDurationNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjDurationNUD_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjDurationNUD.ValueChanged
            'Change AnimateDuration value
            objResizeOptions.AnimateDuration = CInt(mobjDurationNUD.Value)
            mobjPanel.Resizable = objResizeOptions
            mobjPanel.Update()
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjXgridNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        Private Sub mobjGridNUD_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjGridNUD.ValueChanged
            'Change Xgrid and Ygrid values
            Dim intGrid As Integer = CInt(mobjGridNUD.Value)
            objResizeOptions.Xgrid = intGrid
            objResizeOptions.Ygrid = intGrid
            mobjPanel.Resizable = objResizeOptions
            mobjPanel.Update()
        End Sub
	End Class

End Namespace