Namespace CompanionKit.Controls.Form.Features


	Public Class WindowStateForm

        ''' <summary>
        ''' Represents current form sate.
        ''' </summary>
		Private _lastFormState As FormWindowState = FormWindowState.Normal

         ''' <summary>
        ''' Handles load evemt of the Form.
        ''' Sets initial state for the form.
        ''' </summary>
        Private Sub WindowStateForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim defaultFormState As FormWindowState = Me.WindowState
            Me.mobjComboBox.DataSource = [Enum].GetValues(GetType(FormWindowState))
            Me.mobjComboBox.SelectedItem = defaultFormState
            Me.mobjMaximizeCheckBox.Checked = Me.MaximizeBox
            Me.mobjMinimizeCheckBox.Checked = Me.MinimizeBox
            _lastFormState = Me.WindowState
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Close' button.
        ''' Closes the demonstrated Form.
        ''' </summary>
        Private Sub mobjCloseButton_Click(sender As Object, e As EventArgs) Handles mobjCloseButton.Click
            Me.Close()
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged of the ComboBox with form window state.
        ''' Updates the Form Window states.
        ''' </summary>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            Me.WindowState = DirectCast(Me.mobjComboBox.SelectedItem, FormWindowState)
            Me._lastFormState = Me.WindowState
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the 'Maximize button' CheckBox.
        ''' Enables/Disables MaximizeBox of the Form.
        ''' </summary>
        Private Sub mobjMaximizeBtnCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjMaximizeCheckBox.CheckedChanged
            Me.MaximizeBox = Me.mobjMaximizeCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the 'Minimize button' CheckBox.
        ''' Enables/Disables MinimizeBox of the Form.
        ''' </summary>
        Private Sub mobjMinimizeBtnCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjMinimizeCheckBox.CheckedChanged
            Me.MinimizeBox = Me.mobjMinimizeCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles Resize event of the Form.
        ''' Updates the form window state in ComboBox.
        ''' </summary>
        Private Sub WindowStateForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            If Me._lastFormState <> Me.WindowState Then
                Me.mobjComboBox.SelectedItem = Me.WindowState
                Me._lastFormState = Me.WindowState
            End If
        End Sub


	End Class
End Namespace
