Namespace CompanionKit.Controls.PropertyGrid.Functionality

	Public Class Categorization

		''' <summary>
		''' Represents DemoObject that is used for demonstrating how to edit it with PropertyGrid
		''' </summary>
		''' <remarks></remarks>
		Private objDemoObject As DemoObject = Nothing

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Initialize and present the object
			Me.objDemoObject = New DemoObject
			Me.lblDemoObject.Text = Me.objDemoObject.ToString

		End Sub

		''' <summary>
		''' Update the object presentation after been changed
		''' </summary>
		Private Sub objPropGrid_PropertyValueChanged(ByVal s As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.PropertyValueChangedEventArgs) Handles objPropGrid.PropertyValueChanged
			Me.lblDemoObject.Text = Me.objDemoObject.ToString

		End Sub

		''' <summary>
		''' Init the PropertyGrid to inspect and edit the demoobject
		''' </summary>
		Private Sub Categorization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Me.objPropGrid.SelectedObject = Me.objDemoObject
		End Sub
	End Class

End Namespace