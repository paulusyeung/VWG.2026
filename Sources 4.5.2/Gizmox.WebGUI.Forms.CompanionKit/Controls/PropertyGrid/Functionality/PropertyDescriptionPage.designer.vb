Namespace CompanionKit.Controls.PropertyGrid.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PropertyDescriptionPage
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
            Me.objPropGrid = New Gizmox.WebGUI.Forms.PropertyGrid
            Me.lblDemoObject = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'objPropGrid
            '
            Me.objPropGrid.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                        Or Gizmox.WebGUI.Forms.AnchorStyles.Left), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.objPropGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty
            Me.objPropGrid.CommandsVisibleIfAvailable = False
            Me.objPropGrid.HelpBackColor = System.Drawing.Color.Transparent
            Me.objPropGrid.HelpForeColor = System.Drawing.Color.Black
            Me.objPropGrid.LineColor = System.Drawing.Color.Empty
            Me.objPropGrid.Location = New System.Drawing.Point(3, 4)
            Me.objPropGrid.Name = "objPropGrid"
            Me.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical
            Me.objPropGrid.Size = New System.Drawing.Size(282, 320)
            Me.objPropGrid.TabIndex = 0
            Me.objPropGrid.ViewBackColor = System.Drawing.Color.White
            Me.objPropGrid.ViewForeColor = System.Drawing.Color.Black
            '
            'lblDemoObject
            '
            Me.lblDemoObject.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                        Or Gizmox.WebGUI.Forms.AnchorStyles.Left), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.lblDemoObject.Location = New System.Drawing.Point(295, 107)
            Me.lblDemoObject.Name = "lblDemoObject"
            Me.lblDemoObject.Size = New System.Drawing.Size(348, 212)
            Me.lblDemoObject.TabIndex = 1
            '
            'PropertyDescriptionPage
            '
            Me.Controls.Add(Me.lblDemoObject)
            Me.Controls.Add(Me.objPropGrid)
            Me.Size = New System.Drawing.Size(653, 328)
            Me.Text = "PropertyDescriptionPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents objPropGrid As Gizmox.WebGUI.Forms.PropertyGrid
        Friend WithEvents lblDemoObject As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace