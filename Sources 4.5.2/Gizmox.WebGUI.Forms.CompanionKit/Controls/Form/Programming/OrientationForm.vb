Namespace CompanionKit.Controls.Form.Programming

Public Class OrientationForm


    ''' <summary>
    ''' Handles the OrientationChanged event of the OrientationForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="Gizmox.WebGUI.Forms.OrientationChangedEventArgs"/> instance containing the event data.</param>
        Private Sub FormOrientationChanged(sender As System.Object, e As Gizmox.WebGUI.Forms.OrientationChangedEventArgs) Handles MyBase.OrientationChanged
            'Change Label text
            If e.Orientation.Value = 0 OrElse e.Orientation.Value = 180 Then
                mobjOrientationLabel.Text = ("Orientation: Portrait")
            End If
            If e.Orientation.Value = 90 OrElse e.Orientation.Value = -90 Then
                mobjOrientationLabel.Text = ("Orientation: Landscape")
            End If

        End Sub

    ''' <summary>
    ''' Handles the Click event of the mobjCloseButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub mobjCloseButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjCloseButton.Click

        'Close form
        Me.Close()
    End Sub
    End Class
End Namespace
