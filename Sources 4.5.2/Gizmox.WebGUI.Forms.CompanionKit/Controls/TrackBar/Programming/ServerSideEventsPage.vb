Namespace CompanionKit.Controls.TrackBar.Programming

	Public Class ServerSideEventsPage

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

        Private Sub ServerSideEventsPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial value for NumericUpDown 
            Me.mobjValueTrackBarNumericUpDown.Value = Me.mobjDemoTrackBar.Value
        End Sub
	End Class

End Namespace