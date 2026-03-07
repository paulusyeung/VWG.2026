Namespace CompanionKit.Controls.LabelFolder.Features

    Public Class LabelUseMnemonicPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the chbUseMnemonic control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub chbUseMnemonic_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chbUseMnemonic.CheckedChanged
            mobjNicknameLabel.UseMnemonic = chbUseMnemonic.Checked
            mobjPassLabel.UseMnemonic = chbUseMnemonic.Checked
            mobjEmailLabel.UseMnemonic = chbUseMnemonic.Checked
            mobjAddressLabel.UseMnemonic = chbUseMnemonic.Checked
        End Sub

    End Class

End Namespace