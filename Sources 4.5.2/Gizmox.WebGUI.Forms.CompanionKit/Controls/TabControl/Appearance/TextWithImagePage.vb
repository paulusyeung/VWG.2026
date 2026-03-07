Namespace CompanionKit.Controls.TabControl.Appearance

	Public Class TextWithImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
			Me.mobjTextBox.Text = "Visual WebGui is a platform for rapid development, simple deployment and easy migration of desktop applications & abilities to the web, enabling secure and responsive desktop-like RIAs (Rich Internet Applications)." + "This area explores the technological aspect of those and other features, benefits and usage scenarios of Visual WebGui."
        End Sub

        ''' <summary>
        '''  Handles Load event of the example's UserControl
        ''' </summary>
        Private Sub TextWithImagePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up images list for th demonstrated TabControl
            Dim mobjTabImages As New ImageList()
            mobjTabImages.Images.Add(New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.About.png"))
            mobjTabImages.Images.Add(New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Sea.png"))
            mobjTabImages.Images.Add(New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Stone.png"))
            mobjTabImages.Images.Add(New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.View.png"))

            Me.mobjDemoTabControl.ImageList = mobjTabImages

            ' Sets image indices for Tab
            Me.mobjVWGTabPage.ImageIndex = 0
            Me.mobjSeaTabPage.ImageIndex = 1
            Me.mobjStoneTabPage.ImageIndex = 2
            Me.mobjViewTabPage.ImageIndex = 3
        End Sub
    End Class

End Namespace