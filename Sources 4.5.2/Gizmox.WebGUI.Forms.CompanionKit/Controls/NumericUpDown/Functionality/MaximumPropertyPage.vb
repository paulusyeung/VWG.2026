Namespace CompanionKit.Controls.NumericUpDown.Functionality

	Public Class MaximumPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the maximumNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub maximumNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maximumNumericUpDown.ValueChanged
            Me.demoNumericUpDown.Maximum = Me.maximumNumericUpDown.Value
        End Sub

        ''' <summary>
        ''' Handles the Load event of the MaximumPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MaximumPropertyPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set initial value for NumericUpDown that represents 
            ' maximum for the demonstrated NumericUpDown.
            Me.maximumNumericUpDown.Value = Me.demoNumericUpDown.Maximum
        End Sub
    End Class

End Namespace