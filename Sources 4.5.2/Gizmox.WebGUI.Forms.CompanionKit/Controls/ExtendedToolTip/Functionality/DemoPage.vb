Namespace CompanionKit.Controls.ExtendedToolTip.Functionality

	Public Class DemoPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Set ExtendedToolTip as default
            SetExtendedToolTip(mobjContentText.Text)

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSetButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSetButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjSetButton.Click

            'If ToolTip should be extended
            If mobjIsExtended.Checked Then
                SetExtendedToolTip(mobjContentText.Text)
            End If
        End Sub

        ''' <summary>
        ''' Sets the extended tool tip.
        ''' </summary>
        ''' <param name="objText">The obj text.</param>
        Private Sub SetExtendedToolTip(objText As String)
            'Set extendedToolTip for button with Header and Content
            mobjExtendedToolTip.SetToolTipTemplateName(mobjButton, "Default")
            mobjExtendedToolTip.SetHeader(mobjButton, "<b>Bold Header</b>")
            mobjExtendedToolTip.SetContent(mobjButton, (Convert.ToString("<div  style=""width:200px; height:150px; border:1px solid #ccc; background:#B3D4C4"">") & objText) + "</div>")
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsExtended control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIsExtended_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjIsExtended.CheckedChanged
            'If ToolTip should be simple
            If Not mobjIsExtended.Checked Then
                mobjExtendedToolTip.SetToolTipTemplateName(mobjButton, "")
                mobjExtendedToolTip.SetToolTip(mobjButton, "Simple ToolTip Text")
            Else
                SetExtendedToolTip(mobjContentText.Text)
            End If
        End Sub
    End Class

End Namespace