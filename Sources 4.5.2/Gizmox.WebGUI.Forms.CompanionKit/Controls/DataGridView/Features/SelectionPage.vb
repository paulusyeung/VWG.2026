Namespace CompanionKit.Controls.DataGridView.Features

	Public Class SelectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub SelectionPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up the DataGridView.
            For i As Integer = 1 To 19
                mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), String.Format("8-800-236589{0}", i), "Franklin", String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                 "Tennessee", "37064")
            Next

            ' Fill up the ComboBox with available selection modes
            Me.mobjSelectionModeComboBox.Items.Add(DataGridViewSelectionMode.CellSelect)
            Me.mobjSelectionModeComboBox.Items.Add(DataGridViewSelectionMode.FullRowSelect)
            Me.mobjSelectionModeComboBox.Items.Add(DataGridViewSelectionMode.RowHeaderSelect)
            Me.mobjSelectionModeComboBox.SelectedIndex = 0

        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox with selection modes.
        ''' </summary>
        Private Sub mobjSelectionModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjSelectionModeComboBox.SelectedIndexChanged
            ' Set selected selection mode to DataGridView.
            Me.mobjDataGridView.SelectionMode = DirectCast(Me.mobjSelectionModeComboBox.SelectedItem, DataGridViewSelectionMode)
            Me.mobjDataGridView.Update()
        End Sub
    End Class

End Namespace