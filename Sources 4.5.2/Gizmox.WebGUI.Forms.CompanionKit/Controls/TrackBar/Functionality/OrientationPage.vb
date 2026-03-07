Namespace CompanionKit.Controls.TrackBar.Functionality

	Public Class OrientationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub OrientationPage_Load(sender As Object, e As EventArgs) Handles Me.Load

            ' Fill up the ComboBox with enabled Orientation values.
            Dim mobjDefaultOrientationTrackBar As Orientation = Me.mobjDemoTrackBar.Orientation
            Me.mobjOrientationTrackBarComboBox.DataSource = [Enum].GetValues(GetType(Orientation))
            Me.mobjOrientationTrackBarComboBox.SelectedItem = mobjDefaultOrientationTrackBar

        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox.
        ''' Changes orientation of the TrackBar according to selected value.
        ''' </summary>
        Private Sub mobjOrientationTrackBarComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjOrientationTrackBarComboBox.SelectedIndexChanged
            Me.mobjDemoTrackBar.Orientation = DirectCast(Me.mobjOrientationTrackBarComboBox.SelectedItem, Orientation)
            Select Case Me.mobjDemoTrackBar.Orientation
                Case Orientation.Horizontal
                    Me.mobjDemoTrackBar.Parent = Me.mobjHorizontalPanel
                    Exit Select
                Case Orientation.Vertical
                    Me.mobjDemoTrackBar.Parent = Me.mobjVerticalPanel
                    Exit Select
            End Select
        End Sub
	End Class

End Namespace