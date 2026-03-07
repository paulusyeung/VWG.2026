Namespace CompanionKit.Controls.RadioButton.Programming

	Public Class CheckStateChangedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
            'Update labels text with initial checked state of demonstrated RadioButtons
            UpdateLabelText(Me.mobjLabel1, Me.mobjRadioButton1)
            UpdateLabelText(Me.mobjLabel2, Me.mobjRadioButton2)
        End Sub

        Private Sub mobjRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles mobjRadioButton2.CheckedChanged
            'Updates label text, that indicates checked state of demonstrated RadioButton2.
            UpdateLabelText(Me.mobjLabel2, Me.mobjRadioButton2)
            mobjCheckBox1.Checked = mobjRadioButton1.Checked
        End Sub

        Private Sub mobjRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles mobjRadioButton1.CheckedChanged
            'Updates label text, that indicates checked state of demonstrated RadioButton1.
            UpdateLabelText(Me.mobjLabel1, Me.mobjRadioButton1)
            mobjCheckBox2.Checked = mobjRadioButton2.Checked
        End Sub

        ''' <summary>
        ''' Updates specified label text, that indicates state of defined RadioButton.
        ''' </summary>
        ''' <param name="label">label that represents checked state of passed RadioButton</param>
        ''' <param name="radioButton">demonstrated RadioButton</param>
        Private Sub UpdateLabelText(label As Label, radioButton As Global.Gizmox.WebGUI.Forms.RadioButton)
            label.Text = [String].Format("{0} is {1}!", radioButton.Text, (IIf(radioButton.Checked, "checked", "unchecked")))
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the checkBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox1.CheckedChanged
            'Changes RadioButton's state according to appropriate checkBox 
            mobjRadioButton1.Checked = mobjCheckBox1.Checked
            'If current checkBox is checked, then uncheck another one
            If mobjCheckBox1.Checked Then
                mobjCheckBox2.Checked = False
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the checkBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox2.CheckedChanged
            'Changes RadioButton's state according to appropriate checkBox 
            mobjRadioButton2.Checked = mobjCheckBox2.Checked
            'If current checkBox is checked, then uncheck another one
            If mobjCheckBox2.Checked Then
                mobjCheckBox1.Checked = False
            End If
        End Sub

	End Class

End Namespace
