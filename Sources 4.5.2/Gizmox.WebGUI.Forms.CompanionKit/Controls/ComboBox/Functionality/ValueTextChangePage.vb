Namespace CompanionKit.Controls.ComboBox.Functionality

	Public Class ValueTextChangePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
			'Set DataSource as array of Colors.
            Me.mobjComboBox.DataSource = [Enum].GetValues(GetType(Drawing.KnownColor))
        End Sub

        Private Sub mobjComboBox_TextChanged(sender As Object, e As EventArgs) Handles mobjComboBox.TextChanged
            'Set text of tested ComboBox as text of indicator TextBox.
            Me.mobjComboBoxTextTextBox.Text = Me.mobjComboBox.Text
        End Sub

        Private Sub mobjComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedValueChanged
            If Me.mobjComboBox.SelectedValue IsNot Nothing Then
                'Set text of tested ComboBox SelectedValue as text of indicator TextBox.
                Me.mobjValueTextBox.Text = Me.mobjComboBox.SelectedValue.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjTextTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjTextTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjTextTextBox.Text) Then
                mobjComboBox.Text = mobjTextTextBox.Text
            End If
        End Sub

	End Class

End Namespace