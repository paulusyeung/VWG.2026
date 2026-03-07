Namespace CompanionKit.Controls.DataGridView.Features

	Public Class ResizeAllRowsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill DGV with 3 rows
            mobjDGV.Rows.Add("value 1", "item 1", "row 1")
            mobjDGV.Rows.Add("value 2", "item 2", "row 2")
            mobjDGV.Rows.Add("value 3", "item 3", "row 3")

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjResizeAllCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjResizeAllCB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjResizeAllCB.CheckedChanged
            'Set the value of EnforceEqualRowSize property
            mobjDGV.EnforceEqualRowSize = mobjResizeAllCB.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjStandardTabCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjStandardTabCB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjStandardTabCB.CheckedChanged
            'Set the value of StandardTab property
            mobjDGV.StandardTab = mobjStandardTabCB.Checked
        End Sub
    End Class

End Namespace