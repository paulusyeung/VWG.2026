Namespace CompanionKit.Controls.TabControl.Appearance

	Public Class SpreadAppearancePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the objNormalRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNormalRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjNormalRadioButton.CheckedChanged
            'Switches TabControl appearance mode
            mobjTabControl.Appearance = IIf(mobjNormalRadioButton.Checked, TabAppearance.Normal, TabAppearance.Spread)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SpreadAppearancePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub SpreadAppearancePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Adds label to each tabPage control
            For i As Integer = 0 To mobjTabControl.TabPages.Count - 1
                Dim mobjLabel As New Label()
                mobjLabel.Text = mobjTabControl.TabPages(i).Text
                mobjLabel.Dock = DockStyle.Fill
                mobjLabel.AutoSize = False
                mobjLabel.TextAlign = Drawing.ContentAlignment.MiddleCenter
                mobjTabControl.TabPages(i).Controls.Add(mobjLabel)
            Next
        End Sub
    End Class
End Namespace