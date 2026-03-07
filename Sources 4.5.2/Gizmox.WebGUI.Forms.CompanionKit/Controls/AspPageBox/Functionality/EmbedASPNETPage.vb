Namespace CompanionKit.Controls.AspPageBox.Functionality

	Public Class EmbedASPNETPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        Private Sub EmbedASPNETPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.demoAspPageBox.Path = "Controls\AspPageBox\Functionality\AspViewPageVB.aspx"
        End Sub
    End Class

End Namespace