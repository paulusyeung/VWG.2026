Namespace CompanionKit.Controls.CheckBox.Functionality

	Public Class AutoCheckPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjSetAutoCheck control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSetAutoCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSetAutoCheck.Click
            'Change AutoCheck value of Approval CheckBox
            Me.mobjChkApprove.AutoCheck = Me.mobjSetAutoCheck.Checked
            Me.mobjChkApprove.Text = String.Format("Approve loan [auto check - {0}]", Me.mobjChkApprove.AutoCheck)

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjChkApprove control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjChkApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjChkApprove.Click

            'if AutoCheck is set to false the code have to set
            ' correct appearance, else we don't need to change it
            ' because will be set automatically
            If (Not Me.mobjChkApprove.AutoCheck) Then
                If (Integer.Parse(Me.mobjTxtScore.Text) >= Me.mobjMinScore.Value) Then
                    Me.mobjChkApprove.Checked = Not Me.mobjChkApprove.Checked
                End If
            End If

        End Sub

    End Class

End Namespace