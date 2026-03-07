Namespace CompanionKit.Controls.LinkLabel.Functionality

	Public Class ClientModePage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Update Label text
            Me.mobjStatusLabel.Text = String.Format("Current client-mode status: {0}", Me.mobjLinkLabel.ClientMode)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCheckBox.CheckedChanged
            ' Set ClientMode property value for LinkLabel
            Me.mobjLinkLabel.ClientMode = Me.mobjCheckBox.Checked
            ' Update Label text
            Me.mobjStatusLabel.Text = String.Format("Current client-mode status: {0}", Me.mobjLinkLabel.ClientMode)
        End Sub

	End Class

End Namespace