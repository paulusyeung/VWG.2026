Namespace CompanionKit.Controls.ListBox.Features

	Public Class SelectionModesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill ComboBox with SelectionMode values
            mobjModeCB.DataSource = [Enum].GetValues(GetType(SelectionMode))
		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjModeCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjModeCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjModeCB.SelectedIndexChanged
            'Set SelectionMode
            mobjListBox.SelectionMode = DirectCast(mobjModeCB.SelectedItem, SelectionMode)
        End Sub
    End Class

End Namespace