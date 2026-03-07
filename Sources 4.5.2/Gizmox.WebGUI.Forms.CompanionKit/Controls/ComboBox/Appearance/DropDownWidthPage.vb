Namespace CompanionKit.Controls.ComboBox.Appearance

	Public Class DropDownWidthPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Load event of the DropDownWidthPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub DropDownWidthPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Nuds value initialization
            mobjNumericUpDown.Value = mobjComboBox.DropDownWidth
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjNumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles mobjNumericUpDown.ValueChanged
            'Sets DropDownWidth using NUD's value
            mobjComboBox.DropDownWidth = CInt(mobjNumericUpDown.Value)
        End Sub
    End Class

End Namespace