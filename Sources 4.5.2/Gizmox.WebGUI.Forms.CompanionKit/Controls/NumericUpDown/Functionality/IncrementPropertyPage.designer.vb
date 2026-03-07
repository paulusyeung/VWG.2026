Namespace CompanionKit.Controls.NumericUpDown.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class IncrementPropertyPage
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
            Me.incrementalLabel = New Gizmox.WebGUI.Forms.Label()
            Me.demoNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.incrementalNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.incrementalNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'demoNumericUpDownLabel
            '
            Me.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoNumericUpDownLabel.Location = New System.Drawing.Point(10, 10)
            Me.demoNumericUpDownLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel"
            Me.demoNumericUpDownLabel.Size = New System.Drawing.Size(200, 67)
            Me.demoNumericUpDownLabel.TabIndex = 0
            Me.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown"
            Me.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'incrementalLabel
            '
            Me.incrementalLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.incrementalLabel.Location = New System.Drawing.Point(10, 184)
            Me.incrementalLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.incrementalLabel.Name = "incrementalLabel"
            Me.incrementalLabel.Size = New System.Drawing.Size(200, 67)
            Me.incrementalLabel.TabIndex = 1
            Me.incrementalLabel.Text = "Incremental"
            Me.incrementalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'demoNumericUpDown
            '
            Me.demoNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top
            Me.demoNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.demoNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.demoNumericUpDown.DecimalPlaces = 2
            Me.demoNumericUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
            Me.demoNumericUpDown.Location = New System.Drawing.Point(60, 97)
            Me.demoNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.demoNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoNumericUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me.demoNumericUpDown.Name = "demoNumericUpDown"
            Me.demoNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.demoNumericUpDown.TabIndex = 2
            '
            'incrementalNumericUpDown
            '
            Me.incrementalNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top
            Me.incrementalNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.incrementalNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.incrementalNumericUpDown.DecimalPlaces = 2
            Me.incrementalNumericUpDown.Location = New System.Drawing.Point(60, 271)
            Me.incrementalNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.incrementalNumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.incrementalNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.incrementalNumericUpDown.Name = "incrementalNumericUpDown"
            Me.incrementalNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.incrementalNumericUpDown.TabIndex = 3
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDownLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.incrementalNumericUpDown, 0, 3)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDown, 0, 1)
            Me.mobjTLP.Controls.Add(Me.incrementalLabel, 0, 2)
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
            'IncrementPropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "IncrementPropertyPage"
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.incrementalNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoNumericUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents incrementalLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents incrementalNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace