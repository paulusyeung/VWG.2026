Namespace CompanionKit.Controls.TabControl.Functionality

	Public Class MultiRowPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjMultilineCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMultilineCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMultilineCheckBox.CheckedChanged
            If (mobjMultilineCheckBox.Checked) Then
                mobjDemoTabControl.Multiline = True
            Else
                mobjDemoTabControl.Multiline = False
            End If
        End Sub
    End Class

End Namespace