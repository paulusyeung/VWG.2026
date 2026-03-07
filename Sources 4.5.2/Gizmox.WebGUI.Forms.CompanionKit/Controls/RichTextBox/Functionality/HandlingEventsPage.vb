Namespace CompanionKit.Controls.RichTextBox.Functionality

	Public Class HandlingEventsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Set default html for both RichTextBoxes
            mobjDemoRTB.Html = "<b><em>Visual WebGui</em></b> is a platform for rapid development of desktop applications"
            mobjSaverRTB.Html = mobjDemoRTB.Html

		End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjSendButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSendButton.Click
            'Updates Demo RichTextBox to raise its HtmlChanged event
            mobjDemoRTB.Update()

        End Sub

        ''' <summary>
        ''' Handles the HtmlChanged event of the mobjDemoRTB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjDemoRTB_HtmlChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjDemoRTB.HtmlChanged
            'Change Html property of the lower RichTextBox
            mobjSaverRTB.Html = mobjDemoRTB.Html

        End Sub

    End Class

End Namespace
