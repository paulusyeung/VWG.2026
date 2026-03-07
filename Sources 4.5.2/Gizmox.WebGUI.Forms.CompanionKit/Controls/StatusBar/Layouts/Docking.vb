Namespace CompanionKit.Controls.StatusBar.Layouts

	Public Class Docking

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub Docking_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up the ComboBox with enable docking styles.
            Dim mobjDefaultDockStatusBar As DockStyle = Me.mobjTestStatusBar.Dock
            Me.mobjDockComboBox.DataSource = [Enum].GetValues(GetType(DockStyle))
            Me.mobjDockComboBox.SelectedItem = mobjDefaultDockStatusBar
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox.
        ''' Changes docking style for the StatusBar.
        ''' </summary>
        Private Sub mobjDockComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjDockComboBox.SelectedIndexChanged
            'Change docking style of the StatusBar.
            Me.mobjTestStatusBar.Dock = DirectCast(Me.mobjDockComboBox.SelectedItem, DockStyle)
        End Sub
	End Class

End Namespace