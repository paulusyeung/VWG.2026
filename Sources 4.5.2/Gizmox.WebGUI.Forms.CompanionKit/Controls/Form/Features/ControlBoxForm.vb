Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Public Class ControlBoxForm


    ''' <summary>
    ''' Handles the CheckedChanged event of the objCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox.CheckedChanged
        'Toggles ControlBox visibility
        Me.ControlBox = DirectCast(sender, Gizmox.WebGUI.Forms.CheckBox).Checked
        'Toggles close button visibility
        Me.mobjCloseButton.Visible = Not DirectCast(sender, Gizmox.WebGUI.Forms.CheckBox).Checked
    End Sub

    ''' <summary>
    ''' Handles the Click event of the objCloseButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjCloseButton_Click(sender As Object, e As EventArgs) Handles mobjCloseButton.Click
        'Closes form
        Me.Close()
    End Sub
End Class
