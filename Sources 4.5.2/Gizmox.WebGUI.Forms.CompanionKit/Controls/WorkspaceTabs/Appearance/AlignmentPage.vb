Namespace CompanionKit.Controls.WorkspaceTabs.Appearance

    Public Class AlignmentPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjTopRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTopRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjTopRadioButton.CheckedChanged
            If (mobjTopRadioButton.Checked) Then
                mobjWorkspaceTabs.Alignment = TabAlignment.Top
            Else
                mobjWorkspaceTabs.Alignment = TabAlignment.Bottom
            End If
        End Sub
    End Class

End Namespace