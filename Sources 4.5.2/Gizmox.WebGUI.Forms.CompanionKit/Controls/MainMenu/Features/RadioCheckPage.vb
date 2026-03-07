Namespace CompanionKit.Controls.MainMenu.Features

	Public Class RadioCheckPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        ''' <summary>
        ''' Handles the Click event of the openFormWithMainMenuButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub openFormWithMainMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openFormWithMainMenuButton.Click
            Dim demoForm As New MainMenuForm(MainMenuForm.MainMenuSampleTypes.RadioBox)
            demoForm.ShowDialog()
        End Sub
    End Class

End Namespace