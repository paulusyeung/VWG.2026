Namespace CompanionKit.Controls.PropertyGrid.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class Categorization
		Inherits UserControl

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		'Required by the Visual WebGui UserControl Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the WebGui UserControl Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Categorization))
			Me.lblDemoObject = New Gizmox.WebGUI.Forms.Label
			Me.lblDescription = New Gizmox.WebGUI.Forms.Label
			Me.objPropGrid = New Gizmox.WebGUI.Forms.PropertyGrid
			Me.SuspendLayout()
			'
			'lblDemoObject
			'
			Me.lblDemoObject.Location = New System.Drawing.Point(14, 85)
			Me.lblDemoObject.Name = "lblDemoObject"
			Me.lblDemoObject.Size = New System.Drawing.Size(348, 212)
			Me.lblDemoObject.TabIndex = 0
			'
			'lblDescription
			'
			Me.lblDescription.AutoSize = True
			Me.lblDescription.Location = New System.Drawing.Point(14, 12)
			Me.lblDescription.Name = "Label2"
			Me.lblDescription.Size = New System.Drawing.Size(38, 13)
			Me.lblDescription.TabIndex = 1
			Me.lblDescription.Text = resources.GetString("lblDescription.Text")
			'
			'objPropGrid
			'
			Me.objPropGrid.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
						Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
			Me.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty
			Me.objPropGrid.CommandsVisibleIfAvailable = False
			Me.objPropGrid.HelpBackColor = System.Drawing.Color.Transparent
			Me.objPropGrid.HelpForeColor = System.Drawing.Color.Black
			Me.objPropGrid.LineColor = System.Drawing.Color.Empty
			Me.objPropGrid.Location = New System.Drawing.Point(395, 0)
			Me.objPropGrid.Name = "objPropGrid"
			Me.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical
			Me.objPropGrid.Size = New System.Drawing.Size(258, 328)
			Me.objPropGrid.TabIndex = 2
			Me.objPropGrid.ViewBackColor = System.Drawing.Color.White
			Me.objPropGrid.ViewForeColor = System.Drawing.Color.Black
			'
			'Categorization
			'
			Me.Controls.Add(Me.objPropGrid)
			Me.Controls.Add(Me.lblDescription)
			Me.Controls.Add(Me.lblDemoObject)
			Me.Size = New System.Drawing.Size(653, 328)
			Me.Text = "Categorization"
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents lblDemoObject As Gizmox.WebGUI.Forms.Label
		Friend WithEvents lblDescription As Gizmox.WebGUI.Forms.Label
		Friend WithEvents objPropGrid As Gizmox.WebGUI.Forms.PropertyGrid

	End Class

End Namespace