Namespace CompanionKit.Controls.CheckBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckAlignPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCheckCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
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
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 77)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "CheckBox with changing Check Align and Text Align properties:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextCB
            '
            Me.mobjTextCB.AllowDrag = False
            Me.mobjTextCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextCB.FormattingEnabled = True
            Me.mobjTextCB.Location = New System.Drawing.Point(170, 221)
            Me.mobjTextCB.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjTextCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextCB.Name = "mobjTextCB"
            Me.mobjTextCB.Size = New System.Drawing.Size(140, 25)
            Me.mobjTextCB.TabIndex = 2
            '
            'mobjCheckCB
            '
            Me.mobjCheckCB.AllowDrag = False
            Me.mobjCheckCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjCheckCB.FormattingEnabled = True
            Me.mobjCheckCB.Location = New System.Drawing.Point(170, 299)
            Me.mobjCheckCB.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjCheckCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCheckCB.Name = "mobjCheckCB"
            Me.mobjCheckCB.Size = New System.Drawing.Size(140, 25)
            Me.mobjCheckCB.TabIndex = 3
            '
            'mobjTextLbl
            '
            Me.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLbl.Location = New System.Drawing.Point(0, 193)
            Me.mobjTextLbl.Name = "mobjTextLbl"
            Me.mobjTextLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextLbl.Size = New System.Drawing.Size(160, 77)
            Me.mobjTextLbl.TabIndex = 4
            Me.mobjTextLbl.Text = "Text Align"
            Me.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjCheckLbl
            '
            Me.mobjCheckLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckLbl.Location = New System.Drawing.Point(0, 270)
            Me.mobjCheckLbl.Name = "mobjCheckLbl"
            Me.mobjCheckLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjCheckLbl.Size = New System.Drawing.Size(160, 80)
            Me.mobjCheckLbl.TabIndex = 5
            Me.mobjCheckLbl.Text = "Check Align"
            Me.mobjCheckLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Teal)
            Me.mobjCheckBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTLP.SetColumnSpan(Me.mobjCheckBox, 2)
            Me.mobjCheckBox.Location = New System.Drawing.Point(75, 110)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(170, 50)
            Me.mobjCheckBox.TabIndex = 6
            Me.mobjCheckBox.Text = "Test Text Alignment"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCheckCB, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjCheckLbl, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjTextCB, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjTextLbl, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 7
            '
            'CheckAlignPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "CheckAlignPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjTextCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjCheckCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTextLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjCheckLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
