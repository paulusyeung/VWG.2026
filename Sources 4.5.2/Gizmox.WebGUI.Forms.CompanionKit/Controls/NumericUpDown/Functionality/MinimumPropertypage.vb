Namespace CompanionKit.Controls.NumericUpDown.Functionality

	Public Class MinimumPropertypage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the minimumNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub minimumNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minimumNumericUpDown.ValueChanged
            Me.demoNumericUpDown.Minimum = Me.minimumNumericUpDown.Value
        End Sub

        ''' <summary>
        ''' Handles the Load event of the MinimumPropertypage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MinimumPropertypage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set initial value for NumericUpDown that represents 
            ' minimum for the demonstrated NumericUpDown.
            Me.minimumNumericUpDown.Value = Me.demoNumericUpDown.Minimum
        End Sub
    End Class

End Namespace