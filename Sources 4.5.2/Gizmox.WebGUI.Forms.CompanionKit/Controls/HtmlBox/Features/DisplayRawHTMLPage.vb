Namespace CompanionKit.Controls.HtmlBox.Features

	Public Class DisplayRawHTMLPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set raw HTML content for HTMLBox control
            Me.mobjHtmlBox.Html = "<HTML><CENTER><IMG src=""/Resources/Images/AboutVWGLogo.jpg"" WIDTH=""382"" HEIGHT=""100"" ALT=""VWGLogo"" HSPACE=""10"" ALIGN=""middle""></CENTER><BR><BR><BR>Visual WebGui is a platform for rapid development, simple deployment and easy migration of desktop applications & abilities to the web, enabling secure and responsive desktop-like RIAs (Rich Internet Applications).<BR></HTML>"

		End Sub
	End Class

End Namespace