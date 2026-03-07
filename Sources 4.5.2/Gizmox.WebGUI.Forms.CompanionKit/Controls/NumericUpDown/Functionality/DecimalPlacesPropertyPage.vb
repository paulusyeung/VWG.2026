Namespace CompanionKit.Controls.NumericUpDown.Functionality

	Public Class DecimalPlacesPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the decimalPlacesNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub decimalPlacesNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles decimalPlacesNumericUpDown.ValueChanged
            Dim decimalPlaces As Integer = Decimal.ToInt16(Me.decimalPlacesNumericUpDown.Value)
            Me.demoNumericUpDown.DecimalPlaces = decimalPlaces

            'Set incremental value for demonstrated NumericUpDown
            Me.demoNumericUpDown.Increment = CDec((1 / Math.Pow(10, CDbl(decimalPlaces))))
        End Sub

        ''' <summary>
        ''' Handles the Load event of the DecimalPlacesPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub DecimalPlacesPropertyPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set initial current value for NumericUpDown that 
            ' represents decimal places for demonstrated NumericUpDown.
            Me.decimalPlacesNumericUpDown.Value = Me.demoNumericUpDown.DecimalPlaces
        End Sub
    End Class

End Namespace