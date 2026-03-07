Namespace CompanionKit.Controls.TabControl.Appearance

	Public Class ExpandCollapsePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Expand event of the mobjTabControl control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTabControl_Expand(sender As Object, e As EventArgs) Handles mobjTabControl.Expand
            SetLabelText("Expanded")
        End Sub

        ''' <summary>
        ''' Handles the Collapse event of the mobjTabControl control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTabControl_Collapse(sender As Object, e As EventArgs) Handles mobjTabControl.Collapse
            SetLabelText("Collapsed")
        End Sub


        ''' <summary>
        ''' Sets the label text.
        ''' </summary>
        ''' <param name="strState">String value of state.</param>
        Private Sub SetLabelText(strState As String)
            mobjStateLabel.Text = String.Format("Now TabControl is:{0}", strState)
        End Sub
    End Class

End Namespace