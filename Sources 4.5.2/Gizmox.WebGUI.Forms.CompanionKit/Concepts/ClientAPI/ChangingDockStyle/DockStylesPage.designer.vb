Namespace CompanionKit.Concepts.ClientAPI.ChangingDockStyle

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DockStylesPage
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
            Me.objFillButton = New Gizmox.WebGUI.Forms.Button()
            Me.objBottomButton = New Gizmox.WebGUI.Forms.Button()
            Me.objTopButton = New Gizmox.WebGUI.Forms.Button()
            Me.objLeftButton = New Gizmox.WebGUI.Forms.Button()
            Me.objRightButton = New Gizmox.WebGUI.Forms.Button()
            Me.objMiddlePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objRightPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objLeftPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objCommonPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objTestLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objMiddlePanel.SuspendLayout()
            Me.objCommonPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objFillButton
            '
            Me.objFillButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objFillButton.Location = New System.Drawing.Point(73, 33)
            Me.objFillButton.Name = "objFillButton"
            Me.objFillButton.Size = New System.Drawing.Size(93, 39)
            Me.objFillButton.TabIndex = 4
            Me.objFillButton.Text = "Fill"
            '
            'objBottomButton
            '
            Me.objBottomButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objBottomButton.Location = New System.Drawing.Point(73, 72)
            Me.objBottomButton.Name = "objBottomButton"
            Me.objBottomButton.Size = New System.Drawing.Size(93, 23)
            Me.objBottomButton.TabIndex = 2
            Me.objBottomButton.Text = "Bottom"
            '
            'objTopButton
            '
            Me.objTopButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objTopButton.Location = New System.Drawing.Point(73, 5)
            Me.objTopButton.Name = "objTopButton"
            Me.objTopButton.Size = New System.Drawing.Size(93, 28)
            Me.objTopButton.TabIndex = 0
            Me.objTopButton.Text = "Top"
            '
            'objLeftButton
            '
            Me.objLeftButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLeftButton.Location = New System.Drawing.Point(5, 5)
            Me.objLeftButton.Name = "objLeftButton"
            Me.objLeftButton.Size = New System.Drawing.Size(68, 90)
            Me.objLeftButton.TabIndex = 3
            Me.objLeftButton.Text = "Left"
            '
            'objRightButton
            '
            Me.objRightButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objRightButton.Location = New System.Drawing.Point(166, 5)
            Me.objRightButton.Name = "objRightButton"
            Me.objRightButton.Size = New System.Drawing.Size(75, 90)
            Me.objRightButton.TabIndex = 1
            Me.objRightButton.Text = "Right"
            '
            'objMiddlePanel
            '
            Me.objMiddlePanel.Controls.Add(Me.objFillButton)
            Me.objMiddlePanel.Controls.Add(Me.objBottomButton)
            Me.objMiddlePanel.Controls.Add(Me.objTopButton)
            Me.objMiddlePanel.Controls.Add(Me.objLeftButton)
            Me.objMiddlePanel.Controls.Add(Me.objRightButton)
            Me.objMiddlePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objMiddlePanel.DockPadding.All = 5
            Me.objMiddlePanel.Location = New System.Drawing.Point(10, 0)
            Me.objMiddlePanel.Name = "objMiddlePanel"
            Me.objMiddlePanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.objMiddlePanel.Size = New System.Drawing.Size(246, 100)
            Me.objMiddlePanel.TabIndex = 2
            '
            'objRightPanel
            '
            Me.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.objRightPanel.Location = New System.Drawing.Point(256, 0)
            Me.objRightPanel.Name = "objRightPanel"
            Me.objRightPanel.Size = New System.Drawing.Size(10, 100)
            Me.objRightPanel.TabIndex = 1
            '
            'objLeftPanel
            '
            Me.objLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objLeftPanel.Location = New System.Drawing.Point(0, 0)
            Me.objLeftPanel.Name = "objLeftPanel"
            Me.objLeftPanel.Size = New System.Drawing.Size(10, 100)
            Me.objLeftPanel.TabIndex = 0
            '
            'objCommonPanel
            '
            Me.objCommonPanel.Controls.Add(Me.objMiddlePanel)
            Me.objCommonPanel.Controls.Add(Me.objRightPanel)
            Me.objCommonPanel.Controls.Add(Me.objLeftPanel)
            Me.objCommonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objCommonPanel.Location = New System.Drawing.Point(0, 142)
            Me.objCommonPanel.Name = "objCommonPanel"
            Me.objCommonPanel.Size = New System.Drawing.Size(266, 100)
            Me.objCommonPanel.TabIndex = 0
            '
            'objTestLabel
            '
            Me.objTestLabel.AutoSize = True
            Me.objTestLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.objTestLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.objTestLabel.ClientId = "label"
            Me.objTestLabel.ForeColor = System.Drawing.Color.Black
            Me.objTestLabel.Location = New System.Drawing.Point(20, 20)
            Me.objTestLabel.Name = "objTestLabel"
            Me.objTestLabel.Size = New System.Drawing.Size(35, 13)
            Me.objTestLabel.TabIndex = 1
            Me.objTestLabel.Text = "Test Label"
            Me.objTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DockStylesPage
            '
            Me.Controls.Add(Me.objTestLabel)
            Me.Controls.Add(Me.objCommonPanel)
            Me.Size = New System.Drawing.Size(266, 242)
            Me.objMiddlePanel.ResumeLayout(False)
            Me.objCommonPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objFillButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objBottomButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objTopButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objLeftButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objRightButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objMiddlePanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objRightPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objLeftPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objCommonPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objTestLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace