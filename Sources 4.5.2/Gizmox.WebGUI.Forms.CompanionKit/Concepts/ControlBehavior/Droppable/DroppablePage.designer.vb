Namespace CompanionKit.Concepts.ControlBehavior.Droppable

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DroppablePage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjRedLbl2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjYellowLbl1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjBlueLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjYellowLbl2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRedLbl1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjClearButton = New Gizmox.WebGUI.Forms.Button()
            Me.SuspendLayout()
            '
            'mobjPanel
            '
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.AllowDrop = True
            Me.mobjPanel.BackColor = System.Drawing.Color.Transparent
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.Location = New System.Drawing.Point(150, 70)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(140, 215)
            Me.mobjPanel.TabIndex = 1
            '
            'mobjRedLbl2
            '
            Me.mobjRedLbl2.AccessibleDescription = ""
            Me.mobjRedLbl2.AccessibleName = ""
            Me.mobjRedLbl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.mobjRedLbl2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjRedLbl2.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjRedLbl2.Location = New System.Drawing.Point(10, 250)
            Me.mobjRedLbl2.Name = "mobjRedLbl2"
            Me.mobjRedLbl2.Size = New System.Drawing.Size(100, 35)
            Me.mobjRedLbl2.TabIndex = 3
            Me.mobjRedLbl2.Text = "label1"
            '
            'mobjYellowLbl1
            '
            Me.mobjYellowLbl1.AccessibleDescription = ""
            Me.mobjYellowLbl1.AccessibleName = ""
            Me.mobjYellowLbl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.mobjYellowLbl1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjYellowLbl1.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjYellowLbl1.Location = New System.Drawing.Point(10, 160)
            Me.mobjYellowLbl1.Name = "mobjYellowLbl1"
            Me.mobjYellowLbl1.Size = New System.Drawing.Size(100, 35)
            Me.mobjYellowLbl1.TabIndex = 4
            Me.mobjYellowLbl1.Text = "label2"
            '
            'mobjBlueLbl
            '
            Me.mobjBlueLbl.AccessibleDescription = ""
            Me.mobjBlueLbl.AccessibleName = ""
            Me.mobjBlueLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.mobjBlueLbl.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjBlueLbl.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjBlueLbl.Location = New System.Drawing.Point(10, 205)
            Me.mobjBlueLbl.Name = "mobjBlueLbl"
            Me.mobjBlueLbl.Size = New System.Drawing.Size(100, 35)
            Me.mobjBlueLbl.TabIndex = 5
            Me.mobjBlueLbl.Text = "label3"
            '
            'mobjYellowLbl2
            '
            Me.mobjYellowLbl2.AccessibleDescription = ""
            Me.mobjYellowLbl2.AccessibleName = ""
            Me.mobjYellowLbl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.mobjYellowLbl2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjYellowLbl2.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjYellowLbl2.Location = New System.Drawing.Point(10, 115)
            Me.mobjYellowLbl2.Name = "mobjYellowLbl2"
            Me.mobjYellowLbl2.Size = New System.Drawing.Size(100, 35)
            Me.mobjYellowLbl2.TabIndex = 6
            Me.mobjYellowLbl2.Text = "label2"
            '
            'mobjRedLbl1
            '
            Me.mobjRedLbl1.AccessibleDescription = ""
            Me.mobjRedLbl1.AccessibleName = ""
            Me.mobjRedLbl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.mobjRedLbl1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjRedLbl1.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjRedLbl1.Location = New System.Drawing.Point(10, 70)
            Me.mobjRedLbl1.Name = "mobjRedLbl1"
            Me.mobjRedLbl1.Size = New System.Drawing.Size(100, 35)
            Me.mobjRedLbl1.TabIndex = 7
            Me.mobjRedLbl1.Text = "label1"
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(414, 65)
            Me.mobjInfoLabel.TabIndex = 8
            Me.mobjInfoLabel.Text = "Drop Labels on Panel. Labels with the same text are not duplicated:"
            '
            'mobjClearButton
            '
            Me.mobjClearButton.AccessibleDescription = ""
            Me.mobjClearButton.AccessibleName = ""
            Me.mobjClearButton.Location = New System.Drawing.Point(150, 296)
            Me.mobjClearButton.Name = "mobjClearButton"
            Me.mobjClearButton.Size = New System.Drawing.Size(140, 30)
            Me.mobjClearButton.TabIndex = 9
            Me.mobjClearButton.Text = "Clear"
            '
            'DroppablePage
            '
            Me.Controls.Add(Me.mobjClearButton)
            Me.Controls.Add(Me.mobjRedLbl2)
            Me.Controls.Add(Me.mobjBlueLbl)
            Me.Controls.Add(Me.mobjYellowLbl1)
            Me.Controls.Add(Me.mobjYellowLbl2)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjRedLbl1)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(391, 370)
            Me.Text = "DroppablePage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjRedLbl2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjYellowLbl1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjBlueLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjYellowLbl2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjRedLbl1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjClearButton As Gizmox.WebGUI.Forms.Button
	End Class

End Namespace