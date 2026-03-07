Namespace CompanionKit.Controls.PropertyGrid.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HidingPropertiesPage
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
            Me.objPropertiesLabel = New Gizmox.WebGUI.Forms.Label
            Me.objPropertiesComboBox = New Gizmox.WebGUI.Forms.ComboBox
            Me.showPropertyCheckBox = New Gizmox.WebGUI.Forms.CheckBox
            Me.objPropGrid = New Gizmox.WebGUI.Forms.PropertyGrid
            Me.lblDemoObject = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'objPropertiesLabel
            '
            Me.objPropertiesLabel.AutoSize = True
            Me.objPropertiesLabel.Location = New System.Drawing.Point(34, 4)
            Me.objPropertiesLabel.Name = "objPropertiesLabel"
            Me.objPropertiesLabel.Size = New System.Drawing.Size(38, 13)
            Me.objPropertiesLabel.TabIndex = 0
            Me.objPropertiesLabel.Text = "Selected object properties"
            '
            'objPropertiesComboBox
            '
            Me.objPropertiesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.objPropertiesComboBox.Location = New System.Drawing.Point(34, 22)
            Me.objPropertiesComboBox.MaxDropDownItems = 8
            Me.objPropertiesComboBox.Name = "objPropertiesComboBox"
            Me.objPropertiesComboBox.Size = New System.Drawing.Size(153, 21)
            Me.objPropertiesComboBox.TabIndex = 1
            '
            'showPropertyCheckBox
            '
            Me.showPropertyCheckBox.AutoSize = True
            Me.showPropertyCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked
            Me.showPropertyCheckBox.Location = New System.Drawing.Point(193, 24)
            Me.showPropertyCheckBox.Name = "showPropertyCheckBox"
            Me.showPropertyCheckBox.Size = New System.Drawing.Size(140, 17)
            Me.showPropertyCheckBox.TabIndex = 2
            Me.showPropertyCheckBox.Text = "Show selected property"
            Me.showPropertyCheckBox.UseVisualStyleBackColor = True
            '
            'objPropGrid
            '
            Me.objPropGrid.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                        Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.objPropGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.objPropGrid.CategoryForeColor = System.Drawing.Color.Empty
            Me.objPropGrid.CommandsVisibleIfAvailable = False
            Me.objPropGrid.HelpBackColor = System.Drawing.Color.Transparent
            Me.objPropGrid.HelpForeColor = System.Drawing.Color.Black
            Me.objPropGrid.LineColor = System.Drawing.Color.Empty
            Me.objPropGrid.Location = New System.Drawing.Point(368, 3)
            Me.objPropGrid.Name = "objPropGrid"
            Me.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical
            Me.objPropGrid.Size = New System.Drawing.Size(282, 320)
            Me.objPropGrid.TabIndex = 3
            Me.objPropGrid.ViewBackColor = System.Drawing.Color.White
            Me.objPropGrid.ViewForeColor = System.Drawing.Color.Black
            '
            'lblDemoObject
            '
            Me.lblDemoObject.Location = New System.Drawing.Point(14, 90)
            Me.lblDemoObject.Name = "lblDemoObject"
            Me.lblDemoObject.Size = New System.Drawing.Size(348, 207)
            Me.lblDemoObject.TabIndex = 4
            '
            'HidingPropertiesPage
            '
            Me.Controls.Add(Me.lblDemoObject)
            Me.Controls.Add(Me.objPropGrid)
            Me.Controls.Add(Me.showPropertyCheckBox)
            Me.Controls.Add(Me.objPropertiesComboBox)
            Me.Controls.Add(Me.objPropertiesLabel)
            Me.Size = New System.Drawing.Size(653, 328)
            Me.Tag = ""
            Me.Text = "HidingPropertiesPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents objPropertiesLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents objPropertiesComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents showPropertyCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents objPropGrid As Gizmox.WebGUI.Forms.PropertyGrid
        Friend WithEvents lblDemoObject As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace