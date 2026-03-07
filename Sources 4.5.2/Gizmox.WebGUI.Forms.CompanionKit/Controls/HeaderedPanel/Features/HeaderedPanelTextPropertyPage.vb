Namespace CompanionKit.Controls.HeaderedPanel.Features

	Public Class HeaderedPanelTextPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' </summary>
        Private Sub mobjButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButton.Click
            ' Set header text for HeaderedPanel control
            Me.mobjHeaderedPanel.Text = Me.mobjTextBox.Text
        End Sub

	End Class

End Namespace