Namespace CompanionKit.Concepts.ControlBehavior.DraggableFeature

	Public Class DraggableFeaturePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the LocationChanged event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_LocationChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButton.LocationChanged
            If (IsInBounds(mobjButton, mobjTargetPanel)) Then
                mobjTargetPanel.BorderColor = Drawing.Color.Green
            Else
                mobjTargetPanel.BorderColor = Drawing.Color.Red
            End If
        End Sub

        ''' <summary>
        ''' Determines whether [is in bounds] [the specified obj source control].
        ''' </summary>
        ''' <param name="objDraggedControl">The obj source control.</param>
        ''' <param name="objDropTargetControl">The obj comparative control.</param>
        ''' <returns>
        '''   <c>true</c> if [is in bounds] [the specified obj source control]; otherwise, <c>false</c>.
        ''' </returns>
        Private Function IsInBounds(ByVal objDraggedControl As Control, ByVal objDropTargetControl As Control) As Boolean
            'Defines as half of button's height(width)
            Dim mintDeltaDistance As Integer = mobjButton.Size.Height / 2
            'Point, which located into center of source control(button)
            Dim mobjMiddlePointLocation As New Drawing.Point(objDraggedControl.Location.X + mintDeltaDistance, objDraggedControl.Location.Y + mintDeltaDistance)
            'If "middle point" is located inside of comparative control -- place source control fully inside and return true
            If mobjMiddlePointLocation.X > objDropTargetControl.Location.X AndAlso mobjMiddlePointLocation.X < objDropTargetControl.Location.X + objDropTargetControl.Size.Width AndAlso mobjMiddlePointLocation.Y > objDropTargetControl.Location.Y AndAlso mobjMiddlePointLocation.Y < objDropTargetControl.Location.Y + objDropTargetControl.Size.Height Then
                objDraggedControl.Location = New Drawing.Point(objDropTargetControl.Location.X + 1, objDropTargetControl.Location.Y + 1)
                Return True
            Else
                'otherwise -- return false
                Return False
            End If
        End Function

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCheckBox.CheckedChanged
            'Changes button's text
            mobjButton.Text = IIf(mobjCheckBox.Checked, "Draggable Button", "Non-Draggable Button")
            'Toggles IsDraggable property's state
            mobjButton.Draggable.IsDraggable = mobjCheckBox.Checked
            mobjButton.Update()
        End Sub

        Private Sub mobjRevertModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjRevertModeComboBox.SelectedIndexChanged
            'Defines RevertMode property
            Select Case mobjRevertModeComboBox.SelectedIndex
                'None(default)
                Case 0
                    mobjButton.Draggable.RevertMode = RevertMode.None
                    Exit Select
                    'Always
                Case 1
                    mobjButton.Draggable.RevertMode = RevertMode.Always
                    Exit Select
                    'Invalid
                Case 2
                    mobjButton.Draggable.RevertMode = RevertMode.Invalid
                    Exit Select
                    'Valid
                Case 3
                    mobjButton.Draggable.RevertMode = RevertMode.Valid
                    Exit Select

            End Select
            'Updates control
            mobjButton.Update()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjSnapModeComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjSnapModeComboBox.SelectedIndexChanged
            'Defines SnapMode property
            Select Case mobjSnapModeComboBox.SelectedIndex
                'Both(default)
                Case 0
                    mobjButton.Draggable.SnapMode = SnapMode.Both
                    Exit Select
                    'Inner
                Case 1
                    mobjButton.Draggable.SnapMode = SnapMode.Inner
                    Exit Select
                    'Outer
                Case 2
                    mobjButton.Draggable.SnapMode = SnapMode.Outer
                    Exit Select

            End Select
            'Updates control
            mobjButton.Update()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjSnapToComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSnapToComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjSnapToComboBox.SelectedIndexChanged
            'Defines SnapTo property
            Select Case mobjSnapToComboBox.SelectedIndex
                'None(default)
                Case 0
                    mobjButton.Draggable.SnapTo = SnapTo.None
                    Exit Select
                    'All
                Case 1
                    mobjButton.Draggable.SnapTo = SnapTo.All
                    Exit Select
                    'Siblings
                Case 2
                    mobjButton.Draggable.SnapTo = SnapTo.Siblings
                    Exit Select
            End Select
            'Updates control
            mobjButton.Update()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the DraggableFeaturePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub DraggableFeaturePage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            'Calculating and placing button and panel controls
            mobjButton.Location = New Drawing.Point(CInt(mobjContainerPanel.Size.Width * 0.1F), mobjTargetPanel.Location.Y - 1)
            mobjTargetPanel.Location = New Drawing.Point(CInt(mobjContainerPanel.Size.Width - (mobjContainerPanel.Size.Width * 0.1F) - mobjButton.Size.Width), mobjTargetPanel.Location.Y)
        End Sub
	End Class

End Namespace