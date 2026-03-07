Namespace CompanionKit.Controls.TrackBar.Functionality

	Public Class SettingValueAndRangePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the TrackBar. 
        ''' Changes value of the 'TrackBar value' NumericUpDown to a new value of the TrackBar.
        ''' </summary>
        Private Sub mobjDemoTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles mobjDemoTrackBar.ValueChanged
            Me.mobjValueTrackBarNumericUpDown.Value = Me.mobjDemoTrackBar.Value
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event of the 'TrackBar value' NumericUpDown. 
        ''' Changes value of the TrackBar to a new value of the 'TrackBar value' NumericUpDown.
        ''' </summary>
        Private Sub mobjValueTrackBarNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjValueTrackBarNumericUpDown.ValueChanged
            Me.mobjDemoTrackBar.Value = Decimal.ToInt32(Me.mobjValueTrackBarNumericUpDown.Value)
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event NumericupDown that sets minimum value for 
        ''' the demonstrated TrackBar. If value of the TrackBar is less than a 
        ''' new minimum value, the value will be changed to a new minimum value.
        ''' </summary>
        Private Sub mobjMinTrackBarNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjMinTrackBarNumericUpDown.ValueChanged
            If Me.mobjMaxTrackBarNumericUpDown.Value < Me.mobjMinTrackBarNumericUpDown.Value Then
                Me.mobjMinTrackBarNumericUpDown.Value = Me.mobjMaxTrackBarNumericUpDown.Value
            End If
            Me.mobjDemoTrackBar.Minimum = Decimal.ToInt32(Me.mobjMinTrackBarNumericUpDown.Value)
            Me.mobjValueTrackBarNumericUpDown.Minimum = Me.mobjMinTrackBarNumericUpDown.Value
            'if (this.demoTrackBar.Value < this.demoTrackBar.Minimum)
            '{
            '    this.demoTrackBar.Value = this.demoTrackBar.Minimum;
            '}
        End Sub

        ''' <summary>
        ''' Handles ValueChanged event NumericupDown that sets maximum value for 
        ''' the demonstrated TrackBar. If value of the TrackBar is more than a 
        ''' new maximum value, the value will be changed to a new maximum value.
        ''' </summary>
        Private Sub mobjMaxTrackBarNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjMaxTrackBarNumericUpDown.ValueChanged
            If Me.mobjMaxTrackBarNumericUpDown.Value < Me.mobjMinTrackBarNumericUpDown.Value Then
                Me.mobjMaxTrackBarNumericUpDown.Value = Me.mobjMinTrackBarNumericUpDown.Value
            End If
            Me.mobjDemoTrackBar.Maximum = Decimal.ToInt32(Me.mobjMaxTrackBarNumericUpDown.Value)
            Me.mobjValueTrackBarNumericUpDown.Maximum = Me.mobjMaxTrackBarNumericUpDown.Value
            'if (this.demoTrackBar.Value > this.demoTrackBar.Maximum)
            '{
            '    this.demoTrackBar.Value = this.demoTrackBar.Maximum;
            '}

        End Sub

        Private Sub SettingValueAndRangePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial values for NumericUpDown 
            Me.mobjMinTrackBarNumericUpDown.Value = Me.mobjDemoTrackBar.Minimum
            Me.mobjMaxTrackBarNumericUpDown.Value = Me.mobjDemoTrackBar.Maximum
            Me.mobjValueTrackBarNumericUpDown.Value = Me.mobjDemoTrackBar.Value
            Me.mobjValueTrackBarNumericUpDown.Minimum = Me.mobjDemoTrackBar.Minimum
            Me.mobjValueTrackBarNumericUpDown.Maximum = Me.mobjDemoTrackBar.Maximum
        End Sub
	End Class
End Namespace
