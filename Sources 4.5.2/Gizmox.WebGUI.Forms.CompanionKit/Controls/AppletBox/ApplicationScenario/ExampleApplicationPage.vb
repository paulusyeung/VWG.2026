Namespace CompanionKit.Controls.AppletBox.ApplicationScenario

	Public Class ExampleApplicationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        Private Sub ExampleApplicationPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.demoAppletBox.AddParameter("cabbase", "viewone.cab")
            Me.demoAppletBox.AddParameter("demo", "document")
            Me.demoAppletBox.AddParameter("backcolor", "192,192,192")
            Me.demoAppletBox.AddParameter("activecolor", "154,156,206")
            Me.demoAppletBox.AddParameter("flipOptions", "true")
            Me.demoAppletBox.AddParameter("scale", "ftow")
            Me.demoAppletBox.AddParameter("viewmode", "thumbsleft")
            Me.demoAppletBox.AddParameter("pagekeys", "true")
            Me.demoAppletBox.AddParameter("defaultprintdoc", "true")
            Me.demoAppletBox.AddParameter("externalMagnifier", "false")
            Me.demoAppletBox.AddParameter("page1", "../docs/mixed/p1.tif")
            Me.demoAppletBox.AddParameter("page2", "../docs/mixed/p2.jpg")
            Me.demoAppletBox.AddParameter("page3", "../docs/mixed/p3.tif")
            Me.demoAppletBox.AddParameter("page4", "../docs/mixed/p4.jpg")
            Me.demoAppletBox.AddParameter("thumb1", "../docs/mixed/p1-t.tif")
            Me.demoAppletBox.AddParameter("thumb2", "../docs/mixed/p2-t.jpg")
            Me.demoAppletBox.AddParameter("thumb3", "../docs/mixed/p3-t.tif")
            Me.demoAppletBox.AddParameter("thumb4", "../docs/mixed/p4-t.jpg")
            Me.demoAppletBox.AddParameter("thumbLabel1", "Features")
            Me.demoAppletBox.AddParameter("thumbLabel2", "Fruit")
            Me.demoAppletBox.AddParameter("thumbLabel3", "High resolution")
            Me.demoAppletBox.AddParameter("thumbLabel4", "Daeja Image")
            Me.demoAppletBox.AddParameter("enhance", "true")
            Me.demoAppletBox.AddParameter("enhancemode", "1")
            Me.demoAppletBox.AddParameter("allowSelectAnnotation", "true")
            Me.demoAppletBox.AddParameter("version3Features", "true")
            Me.demoAppletBox.AddParameter("annotationEncoding", "UTF8")
            Me.demoAppletBox.AddParameter("annotate", "true")
            Me.demoAppletBox.AddParameter("annotateEdit", "true")
        End Sub
    End Class

End Namespace