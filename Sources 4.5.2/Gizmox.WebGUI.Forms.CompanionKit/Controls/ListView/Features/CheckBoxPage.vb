Namespace CompanionKit.Controls.ListView.Features

	Public Class CheckBoxPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjGridCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjGridCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjGridCheck.CheckedChanged
            'Change ListView.GridLines property
            mobjListView.GridLines = mobjGridCheck.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjBoxesCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjBoxesCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjBoxesCheck.CheckedChanged
            'Change ListView.CheckBoxes property
            mobjListView.CheckBoxes = mobjBoxesCheck.Checked
        End Sub
    End Class

End Namespace