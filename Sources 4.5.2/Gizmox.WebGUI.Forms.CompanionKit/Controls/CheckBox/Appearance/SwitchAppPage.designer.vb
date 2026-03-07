Namespace CompanionKit.Controls.CheckBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SwitchAppPage
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
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjSwitchRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjNormalRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjCheckedLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Use RadioBoxes to swith between Button and Normal Appearance:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.Location = New System.Drawing.Point(113, 257)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(94, 26)
            Me.mobjCheckBox.TabIndex = 1
            Me.mobjCheckBox.Text = "Test"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjGroupBox
            '
            Me.mobjGroupBox.Controls.Add(Me.mobjSwitchRB)
            Me.mobjGroupBox.Controls.Add(Me.mobjNormalRB)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 52)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(320, 192)
            Me.mobjGroupBox.TabIndex = 2
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "CheckBox Appearance:"
            '
            'mobjSwitchRB
            '
            Me.mobjSwitchRB.Location = New System.Drawing.Point(16, 78)
            Me.mobjSwitchRB.Name = "mobjSwitchRB"
            Me.mobjSwitchRB.Size = New System.Drawing.Size(100, 40)
            Me.mobjSwitchRB.TabIndex = 1
            Me.mobjSwitchRB.Text = "Button"
            '
            'mobjNormalRB
            '
            Me.mobjNormalRB.Checked = True
            Me.mobjNormalRB.Location = New System.Drawing.Point(16, 38)
            Me.mobjNormalRB.Name = "mobjNormalRB"
            Me.mobjNormalRB.Size = New System.Drawing.Size(100, 40)
            Me.mobjNormalRB.TabIndex = 0
            Me.mobjNormalRB.Text = "Normal"
            '
            'mobjCheckedLabel
            '
            Me.mobjCheckedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedLabel.Location = New System.Drawing.Point(0, 296)
            Me.mobjCheckedLabel.Name = "mobjCheckedLabel"
            Me.mobjCheckedLabel.Size = New System.Drawing.Size(320, 54)
            Me.mobjCheckedLabel.TabIndex = 3
            Me.mobjCheckedLabel.Text = "Unchecked"
            Me.mobjCheckedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjGroupBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 4
            '
            'SwitchAppPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "SwitchAppPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjSwitchRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjNormalRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjCheckedLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace