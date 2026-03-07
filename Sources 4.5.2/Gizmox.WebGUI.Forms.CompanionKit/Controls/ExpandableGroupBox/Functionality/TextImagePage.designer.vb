Namespace CompanionKit.Controls.ExpandableGroupBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextImagePage
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
            Me.mobjExpandableGroupBox = New Gizmox.WebGUI.Forms.ExpandableGroupBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIsSpreadCheck = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjImageBeforeRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTextBeforeRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTIRelationGB = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjExpandableGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTIRelationGB.SuspendLayout()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjExpandableGroupBox
            '
            Me.mobjExpandableGroupBox.CustomStyle = "X"
            Me.mobjExpandableGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjExpandableGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjExpandableGroupBox.Location = New System.Drawing.Point(0, 70)
            Me.mobjExpandableGroupBox.Name = "mobjExpandableGroupBox"
            Me.mobjExpandableGroupBox.Size = New System.Drawing.Size(320, 100)
            Me.mobjExpandableGroupBox.TabIndex = 0
            Me.mobjExpandableGroupBox.Text = "ExpandableGroupBox"
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 70)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Change IsTextImageSpread and TextImageRelation property:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjIsSpreadCheck
            '
            Me.mobjIsSpreadCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjIsSpreadCheck.Location = New System.Drawing.Point(85, 292)
            Me.mobjIsSpreadCheck.Name = "mobjIsSpreadCheck"
            Me.mobjIsSpreadCheck.Size = New System.Drawing.Size(150, 45)
            Me.mobjIsSpreadCheck.TabIndex = 2
            Me.mobjIsSpreadCheck.Text = "Is Text Image Spread"
            Me.mobjIsSpreadCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjImageBeforeRB
            '
            Me.mobjImageBeforeRB.AutoSize = True
            Me.mobjImageBeforeRB.Checked = True
            Me.mobjImageBeforeRB.Location = New System.Drawing.Point(12, 30)
            Me.mobjImageBeforeRB.Name = "mobjImageBeforeRB"
            Me.mobjImageBeforeRB.Size = New System.Drawing.Size(120, 17)
            Me.mobjImageBeforeRB.TabIndex = 5
            Me.mobjImageBeforeRB.Text = "ImageBeforeText"
            '
            'mobjTextBeforeRB
            '
            Me.mobjTextBeforeRB.AutoSize = True
            Me.mobjTextBeforeRB.Location = New System.Drawing.Point(12, 65)
            Me.mobjTextBeforeRB.Name = "mobjTextBeforeRB"
            Me.mobjTextBeforeRB.Size = New System.Drawing.Size(120, 17)
            Me.mobjTextBeforeRB.TabIndex = 6
            Me.mobjTextBeforeRB.Text = "TextBeforeImage"
            '
            'mobjTIRelationGB
            '
            Me.mobjTIRelationGB.Controls.Add(Me.mobjImageBeforeRB)
            Me.mobjTIRelationGB.Controls.Add(Me.mobjTextBeforeRB)
            Me.mobjTIRelationGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTIRelationGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjTIRelationGB.Location = New System.Drawing.Point(0, 175)
            Me.mobjTIRelationGB.Name = "mobjTIRelationGB"
            Me.mobjTIRelationGB.Size = New System.Drawing.Size(320, 105)
            Me.mobjTIRelationGB.TabIndex = 7
            Me.mobjTIRelationGB.TabStop = False
            Me.mobjTIRelationGB.Text = "TextImageRelation:"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTIRelationGB, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjIsSpreadCheck, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjExpandableGroupBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 8
            '
            'TextImagePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "TextImagePage"
            CType(Me.mobjExpandableGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTIRelationGB.ResumeLayout(False)
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjExpandableGroupBox As Gizmox.WebGUI.Forms.ExpandableGroupBox
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIsSpreadCheck As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjImageBeforeRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjTextBeforeRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjTIRelationGB As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace