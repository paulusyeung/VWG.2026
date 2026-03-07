Namespace CompanionKit.Controls.NumericUpDown.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaximumPropertyPage
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
            Me.demoNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.maximumNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.maximumLabel = New Gizmox.WebGUI.Forms.Label()
            Me.demoNumericUpDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.maximumNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
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
            Me.demoNumericUpDown.TabIndex = 0
            '
            'maximumNumericUpDown
            '
            Me.maximumNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top
            Me.maximumNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.maximumNumericUpDown.CurrentValue = New Decimal(New Integer() {10, 0, 0, 0})
            Me.maximumNumericUpDown.Location = New System.Drawing.Point(60, 97)
            Me.maximumNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.maximumNumericUpDown.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
            Me.maximumNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.maximumNumericUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.maximumNumericUpDown.Name = "maximumNumericUpDown"
            Me.maximumNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.maximumNumericUpDown.TabIndex = 1
            Me.maximumNumericUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
            '
            'maximumLabel
            '
            Me.maximumLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.maximumLabel.Location = New System.Drawing.Point(10, 10)
            Me.maximumLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.maximumLabel.Name = "maximumLabel"
            Me.maximumLabel.Size = New System.Drawing.Size(300, 67)
            Me.maximumLabel.TabIndex = 2
            Me.maximumLabel.Text = "Maximum value"
            Me.maximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'demoNumericUpDownLabel
            '
            Me.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoNumericUpDownLabel.Location = New System.Drawing.Point(10, 184)
            Me.demoNumericUpDownLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel"
            Me.demoNumericUpDownLabel.Size = New System.Drawing.Size(300, 67)
            Me.demoNumericUpDownLabel.TabIndex = 3
            Me.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown"
            Me.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.maximumLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDown, 0, 3)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDownLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.maximumNumericUpDown, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 4
            '
            'MaximumPropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "MaximumPropertyPage"
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.maximumNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents maximumNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents maximumLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoNumericUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace