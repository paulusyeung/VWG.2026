Namespace CompanionKit.Controls.Button.Functionality

	Public Class ClickOncePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
            

			'Set initial check state that indicates whethet ClickOnce property is enabled
            Me.mobjAllowCheckOnceCheckBox.Checked = Me.mobjButton.ClickOnce
		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>m
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            'Show messge to indicate that clicl event is fired
            MessageBox.Show("Button 'Click Once' has been clicked!")

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAllowCheckOnceCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAllowCheckOnceCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjAllowCheckOnceCheckBox.CheckedChanged
            'Switch ClickOnce property for Button with CheckBox
            Me.mobjButton.ClickOnce = Me.mobjAllowCheckOnceCheckBox.Checked
            If Not (Me.mobjButton.ClickOnce OrElse Me.mobjButton.Enabled) Then
                Me.mobjButton.Enabled = True
            End If

        End Sub
	End Class

End Namespace