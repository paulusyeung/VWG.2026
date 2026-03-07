Namespace CompanionKit.Controls.ActiveXBox.ApplicationScenario

	Public Class ExampleApplicationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl
        ''' Set parameters for the demonstrated ActiveXBox
        ''' </summary>
        Private Sub ExampleApplicationPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '  Set parameters for the AciveXBox  
            Me.demoActiveXBox.AddParameter("autoStart", "False")
            Me.demoActiveXBox.AddParameter("URL", "../../../../../../Resources/video/Example.wpl")
            Me.demoActiveXBox.AddParameter("enabled", "True")
            Me.demoActiveXBox.AddParameter("balance", "0")
            Me.demoActiveXBox.AddParameter("currentPosition", "0")
            Me.demoActiveXBox.AddParameter("enableContextMenu", "True")
            Me.demoActiveXBox.AddParameter("fullScreen", "False")
            Me.demoActiveXBox.AddParameter("mute", "False")
            Me.demoActiveXBox.AddParameter("rate", "1")
            Me.demoActiveXBox.AddParameter("stretchToFit", "False")
            Me.demoActiveXBox.AddParameter("uiMode", "full")
        End Sub
    End Class

End Namespace