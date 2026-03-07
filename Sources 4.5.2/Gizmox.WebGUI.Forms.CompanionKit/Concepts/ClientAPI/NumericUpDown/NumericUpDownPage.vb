Namespace CompanionKit.Concepts.ClientAPI.NumericUpDown

	Public Class NumericUpDownPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles mobjListBox.SelectedIndexChanged
            VWGClientContext.Current.Invoke("onListBoxSelectedChanged")
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNumericUpDown_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjNumericUpDown.ValueChanged
            VWGClientContext.Current.Invoke("onNUDValueChanged")
        End Sub
    End Class

End Namespace