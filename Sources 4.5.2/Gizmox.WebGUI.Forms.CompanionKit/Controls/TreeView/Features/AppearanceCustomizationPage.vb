Namespace CompanionKit.Controls.TreeView.Features

    Public Class AppearanceCustomizationPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjLinesCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjLinesCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjLinesCheckBox.CheckedChanged
            'Changes ShowLines property according to CheckBox state
            mobjTreeView.ShowLines = mobjLinesCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjPlusMinusCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPlusMinusCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjPlusMinusCheckBox.CheckedChanged
            'Changes ShowPlusMinus property according to CheckBox state
            mobjTreeView.ShowPlusMinus = mobjPlusMinusCheckBox.Checked
        End Sub
    End Class

End Namespace