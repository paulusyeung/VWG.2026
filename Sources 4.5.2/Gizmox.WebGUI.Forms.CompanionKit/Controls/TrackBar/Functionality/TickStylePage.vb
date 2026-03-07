Namespace CompanionKit.Controls.TrackBar.Functionality

	Public Class TickStylePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox.
        ''' Changes tick style of the TrackBar according to selected value.
        ''' </summary>
        Private Sub mobjTickStyleComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjTickStyleComboBox.SelectedIndexChanged
            Me.mobjDemoTrackBar.TickStyle = DirectCast(Me.mobjTickStyleComboBox.SelectedItem, TickStyle)
        End Sub

        Private Sub TickStylePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up the ComboBox with enabled TickStyle values.
            Dim mobjDefaultTrackBarTickStyle As TickStyle = Me.mobjDemoTrackBar.TickStyle
            Me.mobjTickStyleComboBox.DataSource = Global.System.Enum.GetValues(GetType(TickStyle))
            Me.mobjTickStyleComboBox.SelectedItem = mobjDefaultTrackBarTickStyle

        End Sub
	End Class

End Namespace