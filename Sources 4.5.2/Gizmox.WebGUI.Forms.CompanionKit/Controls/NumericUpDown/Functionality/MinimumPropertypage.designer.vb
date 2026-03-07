Namespace CompanionKit.Controls.NumericUpDown.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MinimumPropertypage
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
            Me.minimumLabel = New Gizmox.WebGUI.Forms.Label()
            Me.minimumNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.demoNumericUpDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.demoNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.minimumNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'minimumLabel
            '
            Me.minimumLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.minimumLabel.Location = New System.Drawing.Point(10, 10)
            Me.minimumLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.minimumLabel.Name = "minimumLabel"
            Me.minimumLabel.Size = New System.Drawing.Size(300, 67)
            Me.minimumLabel.TabIndex = 0
            Me.minimumLabel.Text = "Minimum value"
            Me.minimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'minimumNumericUpDown
            '
            Me.minimumNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top
            Me.minimumNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.minimumNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.minimumNumericUpDown.Location = New System.Drawing.Point(60, 97)
            Me.minimumNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.minimumNumericUpDown.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
            Me.minimumNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.minimumNumericUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me.minimumNumericUpDown.Name = "minimumNumericUpDown"
            Me.minimumNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.minimumNumericUpDown.TabIndex = 1
            '
            'demoNumericUpDownLabel
            '
            Me.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoNumericUpDownLabel.Location = New System.Drawing.Point(10, 184)
            Me.demoNumericUpDownLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel"
            Me.demoNumericUpDownLabel.Size = New System.Drawing.Size(300, 67)
            Me.demoNumericUpDownLabel.TabIndex = 2
            Me.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown"
            Me.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'demoNumericUpDown
            '
            Me.demoNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top
            Me.demoNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.demoNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.demoNumericUpDown.Location = New System.Drawing.Point(60, 271)
            Me.demoNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.demoNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoNumericUpDown.Name = "demoNumericUpDown"
            Me.demoNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.demoNumericUpDown.TabIndex = 3
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.minimumLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDown, 0, 3)
            Me.mobjTLP.Controls.Add(Me.minimumNumericUpDown, 0, 1)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDownLabel, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "tableLayoutPanel1"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 4
            '
            'MinimumPropertypage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "MinimumPropertypage"
            CType(Me.minimumNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents minimumLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents minimumNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents demoNumericUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace