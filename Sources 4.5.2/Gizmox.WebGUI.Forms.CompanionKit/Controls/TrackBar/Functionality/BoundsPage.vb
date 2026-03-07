Namespace CompanionKit.Controls.TrackBar.Functionality

	Public Class BoundsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
' Set initial values for NumericUpDown and ToolTip.
            Me.mobjMinBoundNumUpDown.Value = Me.mobjDemoTrackBar.Minimum
            Me.mobjMaxBoundNumUpDown.Value = Me.mobjDemoTrackBar.Maximum
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjDemoTrackBar, String.Format("Value: {0}", Me.mobjDemoTrackBar.Value))
        End Sub
        ''' <summary>
        ''' Handles ValueChanged event NumericupDown that sets minimum value for 
        ''' the demonstrated TrackBar. If value of the TrackBar is less than a 
        ''' new minimum value, the value will be changed to a new minimum value.
        ''' </summary>
        Private Sub mobjMinBoundNumUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjMinBoundNumUpDown.ValueChanged
            Me.mobjDemoTrackBar.Minimum = Decimal.ToInt32(Me.mobjMinBoundNumUpDown.Value)
            Me.mobjMaxBoundNumUpDown.Minimum = Me.mobjMinBoundNumUpDown.Value
            If Me.mobjDemoTrackBar.Value < Me.mobjDemoTrackBar.Minimum Then
                Me.mobjDemoTrackBar.Value = Me.mobjDemoTrackBar.Minimum
            End If
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event NumericupDown that sets maximum value for 
        ''' the demonstrated TrackBar. If value of the TrackBar is more than a 
        ''' new maximum value, the value will be changed to a new maximum value.
        ''' </summary>
        Private Sub mobjMaxBoundNumUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjMaxBoundNumUpDown.ValueChanged
            Me.mobjDemoTrackBar.Maximum = Decimal.ToInt32(Me.mobjMaxBoundNumUpDown.Value)
            Me.mobjMinBoundNumUpDown.Maximum = Me.mobjMaxBoundNumUpDown.Value
            If Me.mobjDemoTrackBar.Value > Me.mobjDemoTrackBar.Maximum Then
                Me.mobjDemoTrackBar.Value = Me.mobjDemoTrackBar.Maximum
            End If
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the TrackBar. 
        ''' Changes text of the textBox to a new value of the TrackBar.
        ''' </summary>
        Private Sub mobjDemoTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles mobjDemoTrackBar.ValueChanged
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjDemoTrackBar, String.Format("Value: {0}", Me.mobjDemoTrackBar.Value))
            Me.mobjTextBox.Text = Me.mobjDemoTrackBar.Value.ToString()
        End Sub
	End Class

End Namespace