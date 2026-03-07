Namespace CompanionKit.Controls.NumericUpDown.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class NumericValuesPage
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
            Me.demoNumericUpDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.demoNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.currentValueLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'demoNumericUpDownLabel
            '
            Me.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoNumericUpDownLabel.Location = New System.Drawing.Point(0, 0)
            Me.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel"
            Me.demoNumericUpDownLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.demoNumericUpDownLabel.Size = New System.Drawing.Size(160, 120)
            Me.demoNumericUpDownLabel.TabIndex = 0
            Me.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown"
            Me.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'demoNumericUpDown
            '
            Me.demoNumericUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.demoNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.demoNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.demoNumericUpDown.Location = New System.Drawing.Point(170, 49)
            Me.demoNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.demoNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoNumericUpDown.Name = "numericUpDown1"
            Me.demoNumericUpDown.Size = New System.Drawing.Size(140, 21)
            Me.demoNumericUpDown.TabIndex = 1
            '
            'currentValueLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.currentValueLabel, 2)
            Me.currentValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.currentValueLabel.Location = New System.Drawing.Point(0, 120)
            Me.currentValueLabel.Name = "currentValueLabel"
            Me.currentValueLabel.Size = New System.Drawing.Size(320, 280)
            Me.currentValueLabel.TabIndex = 2
            Me.currentValueLabel.Text = "Current value - "
            Me.currentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDownLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDown, 1, 0)
            Me.mobjTLP.Controls.Add(Me.currentValueLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 3
            '
            'NumericValuesPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "NumericValuesPage"
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoNumericUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents currentValueLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace