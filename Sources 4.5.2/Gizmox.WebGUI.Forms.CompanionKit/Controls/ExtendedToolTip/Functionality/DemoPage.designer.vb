Namespace CompanionKit.Controls.ExtendedToolTip.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DemoPage
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
            Me.mobjExtendedToolTip = New Gizmox.WebGUI.Forms.ExtendedToolTip()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjIsExtended = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjContentText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjContentLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSetButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 78)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Hover the button to see ExtendedToolTip. Content Html can be partly changed:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.Location = New System.Drawing.Point(5, 111)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjButton.TabIndex = 1
            Me.mobjButton.Text = "Hover me"
            '
            'mobjIsExtended
            '
            Me.mobjIsExtended.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjIsExtended.Checked = True
            Me.mobjIsExtended.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjIsExtended.Location = New System.Drawing.Point(190, 111)
            Me.mobjIsExtended.Name = "mobjIsExtended"
            Me.mobjIsExtended.Size = New System.Drawing.Size(100, 50)
            Me.mobjIsExtended.TabIndex = 2
            Me.mobjIsExtended.Text = "Extended"
            Me.mobjIsExtended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjContentText
            '
            Me.mobjContentText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContentText.Location = New System.Drawing.Point(3, 256)
            Me.mobjContentText.Multiline = True
            Me.mobjContentText.Name = "mobjContentText"
            Me.mobjContentText.Size = New System.Drawing.Size(154, 131)
            Me.mobjContentText.TabIndex = 3
            Me.mobjContentText.Text = "<h2 style = ""color:#A31947"">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Extended ToolTip" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</h2>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<p>Text</p>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            '
            'mobjContentLabel
            '
            Me.mobjContentLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContentLabel.Location = New System.Drawing.Point(0, 195)
            Me.mobjContentLabel.Name = "mobjContentLabel"
            Me.mobjContentLabel.Size = New System.Drawing.Size(160, 58)
            Me.mobjContentLabel.TabIndex = 4
            Me.mobjContentLabel.Text = "Content Html:"
            Me.mobjContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjSetButton
            '
            Me.mobjSetButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjSetButton.Location = New System.Drawing.Point(185, 281)
            Me.mobjSetButton.Name = "mobjSetButton"
            Me.mobjSetButton.Size = New System.Drawing.Size(110, 80)
            Me.mobjSetButton.TabIndex = 5
            Me.mobjSetButton.Text = "Set"
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjSetButton, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjContentLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjIsExtended, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjContentText, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 390)
            Me.mobjTLP.TabIndex = 6
            '
            'DemoPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 390)
            Me.Text = "DemoPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjExtendedToolTip As Gizmox.WebGUI.Forms.ExtendedToolTip
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjIsExtended As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjContentText As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjContentLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjSetButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace