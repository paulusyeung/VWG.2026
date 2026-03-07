Namespace CompanionKit.Controls.PropertyGrid.Functionality

	Public Class ResetPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the objComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Assigns control to PropertyGrid.SelectedObject according to selected comboBox's item
            Select Case mobjComboBox.SelectedIndex
                'Button
                Case 0
                    mobjPropertyGrid.SelectedObject = mobjButton
                    Exit Select
                    'Panel
                Case 1
                    mobjPropertyGrid.SelectedObject = mobjPanel
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ResetPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ResetPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            mobjComboBox.SelectedIndex = 0
        End Sub

	End Class

End Namespace