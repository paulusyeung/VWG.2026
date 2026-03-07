Namespace CompanionKit.Controls.NumericUpDown.Functionality

	Public Class IncrementPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the incrementalNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub incrementalNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles incrementalNumericUpDown.ValueChanged
            Me.demoNumericUpDown.Increment = Me.incrementalNumericUpDown.Value

        End Sub

        ''' <summary>
        ''' Handles the Load event of the IncrementPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub IncrementPropertyPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set initial value for the NumericUpDown that 
            ' represents incremental for the demonstrated NumericUpDown.
            Me.incrementalNumericUpDown.Value = Me.demoNumericUpDown.Increment

        End Sub
    End Class

End Namespace