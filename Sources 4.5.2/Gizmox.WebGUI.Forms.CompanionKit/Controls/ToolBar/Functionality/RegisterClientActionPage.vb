Namespace CompanionKit.Controls.ToolBar.Functionality

	Public Class RegisterClientActionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Register opening action for each ToolBar buttons
			Me.ToolBarButton1.RegisterClientAction("open", New String() {"http://www.visualwebgui.com"})
			Me.ToolBarButton2.RegisterClientAction("open", New String() {"http://www.google.com"})
			Me.ToolBarButton3.RegisterClientAction("open", New String() {"http://www.microsoft.com"})

		End Sub
	End Class

End Namespace