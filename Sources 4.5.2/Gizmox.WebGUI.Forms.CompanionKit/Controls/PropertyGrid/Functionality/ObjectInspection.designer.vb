Namespace CompanionKit.Controls.PropertyGrid.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ObjectInspection
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
            Me.objInitial = New Gizmox.WebGUI.Forms.Label
            Me.objGroupSelection = New Gizmox.WebGUI.Forms.GroupBox
            Me.objVWGLinkLabel = New Gizmox.WebGUI.Forms.LinkLabel
            Me.objMultiple = New Gizmox.WebGUI.Forms.Button
            Me.objAnotherLabel = New Gizmox.WebGUI.Forms.Label
            Me.objButton03 = New Gizmox.WebGUI.Forms.Button
            Me.objButton02 = New Gizmox.WebGUI.Forms.Button
            Me.objButton01 = New Gizmox.WebGUI.Forms.Button
            Me.objGroupSelection.SuspendLayout()
            Me.SuspendLayout()
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
            Me.objPropGrid.Name = "PropertyGrid1"
            Me.objPropGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical
            Me.objPropGrid.SelectedObject = Me.objInitial
            Me.objPropGrid.Size = New System.Drawing.Size(282, 322)
            Me.objPropGrid.TabIndex = 0
            Me.objPropGrid.ViewBackColor = System.Drawing.Color.White
            Me.objPropGrid.ViewForeColor = System.Drawing.Color.Black
            '
            'objInitial
            '
            Me.objInitial.AutoSize = True
            Me.objInitial.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.objInitial.Location = New System.Drawing.Point(118, 35)
            Me.objInitial.Name = "Label1"
            Me.objInitial.Size = New System.Drawing.Size(136, 15)
            Me.objInitial.TabIndex = 2
            Me.objInitial.Text = "The label selected on initialization"
            '
            'objGroupSelection
            '
            Me.objGroupSelection.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                        Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.objGroupSelection.Controls.Add(Me.objVWGLinkLabel)
            Me.objGroupSelection.Controls.Add(Me.objMultiple)
            Me.objGroupSelection.Controls.Add(Me.objAnotherLabel)
            Me.objGroupSelection.Controls.Add(Me.objButton03)
            Me.objGroupSelection.Controls.Add(Me.objButton02)
            Me.objGroupSelection.Controls.Add(Me.objButton01)
            Me.objGroupSelection.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objGroupSelection.Location = New System.Drawing.Point(3, 3)
            Me.objGroupSelection.Name = "objGroupSelection"
            Me.objGroupSelection.Size = New System.Drawing.Size(359, 322)
            Me.objGroupSelection.TabIndex = 1
            Me.objGroupSelection.TabStop = False
            Me.objGroupSelection.Text = "GroupBox1"
            '
            'objVWGLinkLabel
            '
            Me.objVWGLinkLabel.AutoSize = True
            Me.objVWGLinkLabel.ClientMode = False
            Me.objVWGLinkLabel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand
            Me.objVWGLinkLabel.LinkColor = System.Drawing.Color.Blue
            Me.objVWGLinkLabel.Location = New System.Drawing.Point(115, 101)
            Me.objVWGLinkLabel.Name = "objVWGLinkLabel"
            Me.objVWGLinkLabel.Size = New System.Drawing.Size(56, 13)
            Me.objVWGLinkLabel.TabIndex = 7
            Me.objVWGLinkLabel.TabStop = True
            Me.objVWGLinkLabel.Text = "Link label"
            Me.objVWGLinkLabel.Url = "http://www.visualwebgui.com"
            '
            'objMultiple
            '
            Me.objMultiple.Location = New System.Drawing.Point(18, 146)
            Me.objMultiple.Name = "Button4"
            Me.objMultiple.Size = New System.Drawing.Size(335, 40)
            Me.objMultiple.TabIndex = 6
            Me.objMultiple.Text = "Click to select simple and initial label to inspect and edit simultaneously"
            Me.objMultiple.UseVisualStyleBackColor = True
            '
            'objAnotherLabel
            '
            Me.objAnotherLabel.AutoSize = True
            Me.objAnotherLabel.Location = New System.Drawing.Point(115, 68)
            Me.objAnotherLabel.Name = "Label3"
            Me.objAnotherLabel.Size = New System.Drawing.Size(35, 13)
            Me.objAnotherLabel.TabIndex = 4
            Me.objAnotherLabel.Text = "A simple label"
            '
            'objButton03
            '
            Me.objButton03.AutoEllipsis = True
            Me.objButton03.Location = New System.Drawing.Point(18, 94)
            Me.objButton03.Name = "Button3"
            Me.objButton03.Size = New System.Drawing.Size(55, 27)
            Me.objButton03.TabIndex = 3
            Me.objButton03.Text = "select"
            Me.objButton03.UseVisualStyleBackColor = True
            '
            'objButton02
            '
            Me.objButton02.Location = New System.Drawing.Point(18, 61)
            Me.objButton02.Name = "Button2"
            Me.objButton02.Size = New System.Drawing.Size(55, 27)
            Me.objButton02.TabIndex = 2
            Me.objButton02.Text = "select"
            Me.objButton02.UseVisualStyleBackColor = True
            '
            'objButton01
            '
            Me.objButton01.Location = New System.Drawing.Point(18, 28)
            Me.objButton01.Name = "Button1"
            Me.objButton01.Size = New System.Drawing.Size(55, 27)
            Me.objButton01.TabIndex = 1
            Me.objButton01.Text = "select"
            Me.objButton01.UseVisualStyleBackColor = True
            '
            'ObjectInspection
            '
            Me.Controls.Add(Me.objInitial)
            Me.Controls.Add(Me.objGroupSelection)
            Me.Controls.Add(Me.objPropGrid)
            Me.Size = New System.Drawing.Size(653, 328)
            Me.Text = "Click to inspect and change with PropertyGrid"
            Me.objGroupSelection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
		Friend WithEvents objPropGrid As Gizmox.WebGUI.Forms.PropertyGrid
		Friend WithEvents objGroupSelection As Gizmox.WebGUI.Forms.GroupBox
		Friend WithEvents objInitial As Gizmox.WebGUI.Forms.Label
		Friend WithEvents objMultiple As Gizmox.WebGUI.Forms.Button
		Friend WithEvents objAnotherLabel As Gizmox.WebGUI.Forms.Label
		Friend WithEvents objButton03 As Gizmox.WebGUI.Forms.Button
		Friend WithEvents objButton02 As Gizmox.WebGUI.Forms.Button
		Friend WithEvents objButton01 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents objVWGLinkLabel As Gizmox.WebGUI.Forms.LinkLabel

	End Class

End Namespace