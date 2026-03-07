Namespace CompanionKit.Controls.NumericUpDown.Programming

	Public Class NumericValuesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the demoNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub demoNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles demoNumericUpDown.ValueChanged
            ' Update text of label that represents current value of the demonstrated NumericUpDown
            Me.currentValueLabel.Text = String.Format("Current value - {0}", Me.demoNumericUpDown.Value.ToString)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the NumericValuesPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub NumericValuesPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Update text of label that represents current value of the demonstrated NumericUpDown
            Me.currentValueLabel.Text = String.Format("Current value - {0}", Me.demoNumericUpDown.Value.ToString)

        End Sub
    End Class

End Namespace