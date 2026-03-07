Namespace CompanionKit.Controls.LinkLabel.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ClientModePage
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
            Me.mobjLinkLabel = New Gizmox.WebGUI.Forms.LinkLabel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjStatusLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLinkLabel
            '
            Me.mobjLinkLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLinkLabel.LinkColor = System.Drawing.Color.Blue
            Me.mobjLinkLabel.Location = New System.Drawing.Point(85, 325)
            Me.mobjLinkLabel.Name = "mobjLinkLabel"
            Me.mobjLinkLabel.Size = New System.Drawing.Size(150, 50)
            Me.mobjLinkLabel.TabIndex = 0
            Me.mobjLinkLabel.TabStop = True
            Me.mobjLinkLabel.Text = "VisualWebGui"
            Me.mobjLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjLinkLabel.Url = "http://www.visualwebgui.com/"
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 100)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Click the LinkLabel to open external URL resource on mouse click:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.Location = New System.Drawing.Point(100, 225)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(120, 50)
            Me.mobjCheckBox.TabIndex = 1
            Me.mobjCheckBox.Text = "Use Client mode"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjStatusLabel
            '
            Me.mobjStatusLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStatusLabel.Location = New System.Drawing.Point(0, 100)
            Me.mobjStatusLabel.Name = "mobjStatusLabel"
            Me.mobjStatusLabel.Size = New System.Drawing.Size(320, 100)
            Me.mobjStatusLabel.TabIndex = 2
            Me.mobjStatusLabel.Text = "Current client-mode status: False"
            Me.mobjStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjLinkLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjStatusLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 3
            '
            'ClientModePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ClientModePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjLinkLabel As Gizmox.WebGUI.Forms.LinkLabel
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjStatusLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
