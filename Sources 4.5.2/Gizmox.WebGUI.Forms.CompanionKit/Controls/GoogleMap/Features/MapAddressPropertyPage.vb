Namespace CompanionKit.Controls.GoogleMap.Features

	Public Class MapAddressPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click for Button control
        ''' </summary>
        Private Sub mobjSetAddressButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSetAddressButton.Click
            ' Set map address for GoogleMap control
            Me.mobjGoogleMap.MapAddress = mobjAddressTextBox.Text
        End Sub
    End Class

End Namespace