Namespace CompanionKit.Concepts.VisualEffects.BorderImage

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BorderImagePage
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
            Me.mobjBorderRepeatComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjBorderRepeatLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjVisualButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBorderRepeatPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBorderRepeatPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjBorderRepeatComboBox
            ' 
            Me.mobjBorderRepeatComboBox.AccessibleDescription = ""
            Me.mobjBorderRepeatComboBox.AccessibleName = ""
            Me.mobjBorderRepeatComboBox.AllowDrag = False
            Me.mobjBorderRepeatComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjBorderRepeatComboBox.FormattingEnabled = True
            Me.mobjBorderRepeatComboBox.Items.AddRange(New Object() {"None", "Stretch", "Repeat", "Round"})
            Me.mobjBorderRepeatComboBox.Location = New System.Drawing.Point(30, 53)
            Me.mobjBorderRepeatComboBox.Name = "objBorderRepeatComboBox"
            Me.mobjBorderRepeatComboBox.Size = New System.Drawing.Size(196, 21)
            Me.mobjBorderRepeatComboBox.TabIndex = 5
            Me.mobjBorderRepeatComboBox.Text = "None"
            ' 
            ' mobjBorderRepeatLabel
            ' 
            Me.mobjBorderRepeatLabel.AccessibleDescription = ""
            Me.mobjBorderRepeatLabel.AccessibleName = ""
            Me.mobjBorderRepeatLabel.AutoSize = True
            Me.mobjBorderRepeatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjBorderRepeatLabel.Location = New System.Drawing.Point(30, 30)
            Me.mobjBorderRepeatLabel.Name = "objBorderRepeatLabel"
            Me.mobjBorderRepeatLabel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjBorderRepeatLabel.Size = New System.Drawing.Size(87, 23)
            Me.mobjBorderRepeatLabel.TabIndex = 4
            Me.mobjBorderRepeatLabel.Text = "Border Repeat"
            ' 
            ' mobjVisualButton
            ' 
            Me.mobjVisualButton.AccessibleDescription = ""
            Me.mobjVisualButton.AccessibleName = ""
            Me.mobjVisualButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjVisualButton.Location = New System.Drawing.Point(30, 30)
            Me.mobjVisualButton.Name = "objVisualButton"
            Me.mobjVisualButton.Size = New System.Drawing.Size(196, 86)
            Me.mobjVisualButton.TabIndex = 0
            Me.mobjVisualButton.Text = "Button"
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.Controls.Add(Me.mobjBorderRepeatPanel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTopPanel.Location = New System.Drawing.Point(30, 30)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(256, 125)
            Me.mobjTopPanel.TabIndex = 7
            ' 
            ' mobjBorderRepeatPanel
            ' 
            Me.mobjBorderRepeatPanel.AccessibleDescription = ""
            Me.mobjBorderRepeatPanel.AccessibleName = ""
            Me.mobjBorderRepeatPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjBorderRepeatPanel.Controls.Add(Me.mobjBorderRepeatComboBox)
            Me.mobjBorderRepeatPanel.Controls.Add(Me.mobjBorderRepeatLabel)
            Me.mobjBorderRepeatPanel.DockPadding.Bottom = 15
            Me.mobjBorderRepeatPanel.DockPadding.Left = 30
            Me.mobjBorderRepeatPanel.DockPadding.Right = 30
            Me.mobjBorderRepeatPanel.DockPadding.Top = 30
            Me.mobjBorderRepeatPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjBorderRepeatPanel.Name = "objBorderRepeatPanel"
            Me.mobjBorderRepeatPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 30, 30, 15)
            Me.mobjBorderRepeatPanel.Size = New System.Drawing.Size(256, 130)
            Me.mobjBorderRepeatPanel.TabIndex = 8
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjVisualButton)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.DockPadding.All = 30
            Me.mobjBottomPanel.Location = New System.Drawing.Point(30, 155)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30)
            Me.mobjBottomPanel.Size = New System.Drawing.Size(256, 146)
            Me.mobjBottomPanel.TabIndex = 8
            ' 
            ' BorderImagePage
            ' 
            Me.Controls.Add(Me.mobjBottomPanel)
            Me.Controls.Add(Me.mobjTopPanel)
            Me.DockPadding.All = 30
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(30)
            Me.Size = New System.Drawing.Size(316, 331)
            Me.Text = "BorderImagePage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBorderRepeatPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjBorderRepeatComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjBorderRepeatLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjVisualButton As Gizmox.WebGUI.Forms.Button
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBorderRepeatPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace