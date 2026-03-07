Namespace CompanionKit.Concepts.ClientAPI.ParentChild

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ParentChildPage
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
            Me.objCheckBox2_4 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox2_3 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox2_2 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox2_1 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objSecondParentPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objCheckBox1_4 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox1_3 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox1_2 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objCheckBox1_1 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objFirstParentPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objToSecondPanelButton = New Gizmox.WebGUI.Forms.Button()
            Me.objToFirstPanelButton = New Gizmox.WebGUI.Forms.Button()
            Me.objSecondParentPanel.SuspendLayout()
            Me.objFirstParentPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objCheckBox2_4
            '
            Me.objCheckBox2_4.AutoSize = True
            Me.objCheckBox2_4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox2_4.Location = New System.Drawing.Point(5, 56)
            Me.objCheckBox2_4.Name = "objCheckBox2_4"
            Me.objCheckBox2_4.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox2_4.TabIndex = 11
            Me.objCheckBox2_4.Text = "Control2_4"
            '
            'objCheckBox2_3
            '
            Me.objCheckBox2_3.AutoSize = True
            Me.objCheckBox2_3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox2_3.Location = New System.Drawing.Point(5, 39)
            Me.objCheckBox2_3.Name = "objCheckBox2_3"
            Me.objCheckBox2_3.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox2_3.TabIndex = 2
            Me.objCheckBox2_3.Text = "Control2_3"
            '
            'objCheckBox2_2
            '
            Me.objCheckBox2_2.AutoSize = True
            Me.objCheckBox2_2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox2_2.Location = New System.Drawing.Point(5, 22)
            Me.objCheckBox2_2.Name = "objCheckBox2_2"
            Me.objCheckBox2_2.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox2_2.TabIndex = 1
            Me.objCheckBox2_2.Text = "Control2_2"
            '
            'objCheckBox2_1
            '
            Me.objCheckBox2_1.AutoSize = True
            Me.objCheckBox2_1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox2_1.Location = New System.Drawing.Point(5, 5)
            Me.objCheckBox2_1.Name = "objCheckBox2_1"
            Me.objCheckBox2_1.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox2_1.TabIndex = 0
            Me.objCheckBox2_1.Text = "Control2_1"
            '
            'objSecondParentPanel
            '
            Me.objSecondParentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objSecondParentPanel.ClientId = "secondPanel"
            Me.objSecondParentPanel.Controls.Add(Me.objCheckBox2_4)
            Me.objSecondParentPanel.Controls.Add(Me.objCheckBox2_3)
            Me.objSecondParentPanel.Controls.Add(Me.objCheckBox2_2)
            Me.objSecondParentPanel.Controls.Add(Me.objCheckBox2_1)
            Me.objSecondParentPanel.DockPadding.All = 5
            Me.objSecondParentPanel.Location = New System.Drawing.Point(194, 23)
            Me.objSecondParentPanel.Name = "objSecondParentPanel"
            Me.objSecondParentPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.objSecondParentPanel.Size = New System.Drawing.Size(131, 185)
            Me.objSecondParentPanel.TabIndex = 4
            '
            'objCheckBox1_4
            '
            Me.objCheckBox1_4.AutoSize = True
            Me.objCheckBox1_4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox1_4.Location = New System.Drawing.Point(5, 56)
            Me.objCheckBox1_4.Name = "objCheckBox1_4"
            Me.objCheckBox1_4.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox1_4.TabIndex = 11
            Me.objCheckBox1_4.Text = "Control1_4"
            '
            'objCheckBox1_3
            '
            Me.objCheckBox1_3.AutoSize = True
            Me.objCheckBox1_3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox1_3.Location = New System.Drawing.Point(5, 39)
            Me.objCheckBox1_3.Name = "objCheckBox1_3"
            Me.objCheckBox1_3.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox1_3.TabIndex = 13
            Me.objCheckBox1_3.Text = "Control1_3"
            '
            'objCheckBox1_2
            '
            Me.objCheckBox1_2.AutoSize = True
            Me.objCheckBox1_2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox1_2.Location = New System.Drawing.Point(5, 22)
            Me.objCheckBox1_2.Name = "objCheckBox1_2"
            Me.objCheckBox1_2.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox1_2.TabIndex = 12
            Me.objCheckBox1_2.Text = "Control1_2"
            '
            'objCheckBox1_1
            '
            Me.objCheckBox1_1.AutoSize = True
            Me.objCheckBox1_1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCheckBox1_1.Location = New System.Drawing.Point(5, 5)
            Me.objCheckBox1_1.Name = "objCheckBox1_1"
            Me.objCheckBox1_1.Size = New System.Drawing.Size(121, 17)
            Me.objCheckBox1_1.TabIndex = 11
            Me.objCheckBox1_1.Text = "Control1_1"
            '
            'objFirstParentPanel
            '
            Me.objFirstParentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.objFirstParentPanel.ClientId = "firstPanel"
            Me.objFirstParentPanel.Controls.Add(Me.objCheckBox1_4)
            Me.objFirstParentPanel.Controls.Add(Me.objCheckBox1_3)
            Me.objFirstParentPanel.Controls.Add(Me.objCheckBox1_2)
            Me.objFirstParentPanel.Controls.Add(Me.objCheckBox1_1)
            Me.objFirstParentPanel.DockPadding.All = 5
            Me.objFirstParentPanel.Location = New System.Drawing.Point(7, 23)
            Me.objFirstParentPanel.Name = "objFirstParentPanel"
            Me.objFirstParentPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.objFirstParentPanel.Size = New System.Drawing.Size(131, 185)
            Me.objFirstParentPanel.TabIndex = 3
            '
            'objToSecondPanelButton
            '
            Me.objToSecondPanelButton.ClientId = "toSecond"
            Me.objToSecondPanelButton.Location = New System.Drawing.Point(149, 77)
            Me.objToSecondPanelButton.Name = "objToSecondPanelButton"
            Me.objToSecondPanelButton.Size = New System.Drawing.Size(36, 23)
            Me.objToSecondPanelButton.TabIndex = 7
            Me.objToSecondPanelButton.Text = ">"
            '
            'objToFirstPanelButton
            '
            Me.objToFirstPanelButton.ClientId = "toFirst"
            Me.objToFirstPanelButton.Location = New System.Drawing.Point(149, 110)
            Me.objToFirstPanelButton.Name = "objToFirstPanelButton"
            Me.objToFirstPanelButton.Size = New System.Drawing.Size(36, 23)
            Me.objToFirstPanelButton.TabIndex = 9
            Me.objToFirstPanelButton.Text = "<"
            '
            'ParentChildPage
            '
            Me.Controls.Add(Me.objToFirstPanelButton)
            Me.Controls.Add(Me.objToSecondPanelButton)
            Me.Controls.Add(Me.objFirstParentPanel)
            Me.Controls.Add(Me.objSecondParentPanel)
            Me.Size = New System.Drawing.Size(340, 217)
            Me.Text = "ParentChildPage"
            Me.objSecondParentPanel.ResumeLayout(False)
            Me.objFirstParentPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objCheckBox2_4 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox2_3 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox2_2 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox2_1 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objSecondParentPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objCheckBox1_4 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox1_3 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox1_2 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objCheckBox1_1 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objFirstParentPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objToSecondPanelButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objToFirstPanelButton As Gizmox.WebGUI.Forms.Button

	End Class

End Namespace