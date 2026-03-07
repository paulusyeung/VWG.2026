Namespace CompanionKit.Controls.ListView.Features

	Public Class ItemPositionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill ComboBox with values of ListView.View property
            For Each obj As View In [Enum].GetValues(GetType(View))
                'Ignore View.Tile because it's not implemented
                If obj <> View.Tile Then
                    mobjViewCB.Items.Add(obj)
                End If
            Next
            'Define default selected item
            mobjListView.SelectedIndex = 0

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjViewCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjViewCB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjViewCB.SelectedIndexChanged
            'Set ListView.View to selected value
            mobjListView.View = DirectCast(mobjViewCB.SelectedItem, View)

            'Update NumericUpDowns values
            mobjXNumeric.Value = mobjListView.SelectedItem.Position.X
            mobjYNumeric.Value = mobjListView.SelectedItem.Position.Y
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListView control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjListView.SelectedIndexChanged
            'Update NumericUpDowns values
            mobjXNumeric.Value = mobjListView.SelectedItem.Position.X
            mobjYNumeric.Value = mobjListView.SelectedItem.Position.Y
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjXNumeric control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjXNumeric_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjXNumeric.ValueChanged
            mobjListView.SelectedItem.Position = New System.Drawing.Point(Convert.ToInt32(mobjXNumeric.Value), Convert.ToInt32(mobjYNumeric.Value))
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjYNumeric control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjYNumeric_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjYNumeric.ValueChanged
            mobjListView.SelectedItem.Position = New System.Drawing.Point(Convert.ToInt32(mobjXNumeric.Value), Convert.ToInt32(mobjYNumeric.Value))
        End Sub
    End Class

End Namespace