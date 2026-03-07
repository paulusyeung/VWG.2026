Namespace CompanionKit.Controls.TabControl.Appearance

	Public Class TabsAlignmentPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub



        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjTopRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTopRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjTopRadioButton.CheckedChanged
            'Changes tabs alignment
            If (mobjTopRadioButton.Checked) Then
                mobjTabControl.Alignment = TabAlignment.Top
            Else
                mobjTabControl.Alignment = TabAlignment.Bottom
            End If
            'Changes tabPage image
            ChangeTabImages()
        End Sub

        Private Sub ChangeTabImages()
            'Gets image name string 
            Dim strImageName As String
            If (mobjTabControl.Alignment = TabAlignment.Top) Then
                strImageName = "Images.TabTop.png"
            Else
                strImageName = "Images.TabBottom.png"
            End If
            'Changes each item's image
            For Each mobjTabPage As TabPage In mobjTabControl.TabPages
                mobjTabPage.BackgroundImage = strImageName
            Next
        End Sub

    End Class

End Namespace