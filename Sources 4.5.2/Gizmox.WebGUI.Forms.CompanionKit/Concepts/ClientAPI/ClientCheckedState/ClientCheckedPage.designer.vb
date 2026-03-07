Namespace CompanionKit.Concepts.ClientAPI.ClientCheckedState

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ClientCheckedPage
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
            Me.objRightPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.objStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objCenterPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objLeftPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objCenterPanel.SuspendLayout()
            Me.objTopPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objRightPanel
            '
            Me.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objRightPanel.Location = New System.Drawing.Point(330, 0)
            Me.objRightPanel.Name = "objRightPanel"
            Me.objRightPanel.Size = New System.Drawing.Size(47, 306)
            Me.objRightPanel.TabIndex = 4
            '
            'objLabel
            '
            Me.objLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLabel.Location = New System.Drawing.Point(0, 0)
            Me.objLabel.Name = "objLabel"
            Me.objLabel.Size = New System.Drawing.Size(123, 100)
            Me.objLabel.TabIndex = 0
            Me.objLabel.Text = "Is CheckBox checked:"
            '
            'objCheckBox
            '
            Me.objCheckBox.ClientId = "checkBox"
            Me.objCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.objCheckBox.Name = "objCheckBox"
            Me.objCheckBox.Size = New System.Drawing.Size(294, 96)
            Me.objCheckBox.TabIndex = 1
            Me.objCheckBox.Text = "Test CheckBox"
            '
            'objStateLabel
            '
            Me.objStateLabel.ClientId = "label"
            Me.objStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objStateLabel.Location = New System.Drawing.Point(123, 0)
            Me.objStateLabel.Name = "objStateLabel"
            Me.objStateLabel.Size = New System.Drawing.Size(294, 100)
            Me.objStateLabel.TabIndex = 0
            Me.objStateLabel.Text = "false"
            '
            'objCenterPanel
            '
            Me.objCenterPanel.Controls.Add(Me.objStateLabel)
            Me.objCenterPanel.Controls.Add(Me.objLabel)
            Me.objCenterPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objCenterPanel.Location = New System.Drawing.Point(36, 96)
            Me.objCenterPanel.Name = "objCenterPanel"
            Me.objCenterPanel.Size = New System.Drawing.Size(294, 100)
            Me.objCenterPanel.TabIndex = 5
            '
            'objTopPanel
            '
            Me.objTopPanel.Controls.Add(Me.objCheckBox)
            Me.objTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objTopPanel.Location = New System.Drawing.Point(36, 0)
            Me.objTopPanel.Name = "objTopPanel"
            Me.objTopPanel.Size = New System.Drawing.Size(294, 96)
            Me.objTopPanel.TabIndex = 2
            '
            'objLeftPanel
            '
            Me.objLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLeftPanel.Location = New System.Drawing.Point(0, 0)
            Me.objLeftPanel.Name = "objLeftPanel"
            Me.objLeftPanel.Size = New System.Drawing.Size(36, 306)
            Me.objLeftPanel.TabIndex = 3
            '
            'ClientCheckedPage
            '
            Me.Controls.Add(Me.objCenterPanel)
            Me.Controls.Add(Me.objTopPanel)
            Me.Controls.Add(Me.objLeftPanel)
            Me.Controls.Add(Me.objRightPanel)
            Me.Size = New System.Drawing.Size(377, 306)
            Me.objCenterPanel.ResumeLayout(False)
            Me.objTopPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objRightPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents objStateLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objCenterPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objTopPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objLeftPanel As Gizmox.WebGUI.Forms.Panel

    End Class


End Namespace