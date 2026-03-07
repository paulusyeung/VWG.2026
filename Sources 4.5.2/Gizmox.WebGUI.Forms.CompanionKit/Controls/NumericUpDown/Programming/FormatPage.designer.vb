Namespace CompanionKit.Controls.NumericUpDown.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FormatPage
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
            Me.decimalPlacesNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.decimalPlacesLabel = New Gizmox.WebGUI.Forms.Label()
            Me.thousandsSeparatorCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.decimalPlacesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'demoNumericUpDownLabel
            '
            Me.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoNumericUpDownLabel.Location = New System.Drawing.Point(0, 0)
            Me.demoNumericUpDownLabel.Name = "label1"
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
            Me.demoNumericUpDown.CurrentValue = New Decimal(New Integer() {100, 0, 0, 0})
            Me.demoNumericUpDown.DecimalPlaces = 3
            Me.demoNumericUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
            Me.demoNumericUpDown.Location = New System.Drawing.Point(160, 49)
            Me.demoNumericUpDown.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
            Me.demoNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoNumericUpDown.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
            Me.demoNumericUpDown.Name = "numericUpDown1"
            Me.demoNumericUpDown.Size = New System.Drawing.Size(160, 21)
            Me.demoNumericUpDown.TabIndex = 1
            Me.demoNumericUpDown.ThousandsSeparator = True
            Me.demoNumericUpDown.Value = New Decimal(New Integer() {100, 0, 0, 0})
            '
            'decimalPlacesNumericUpDown
            '
            Me.decimalPlacesNumericUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.decimalPlacesNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.decimalPlacesNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.decimalPlacesNumericUpDown.Location = New System.Drawing.Point(160, 169)
            Me.decimalPlacesNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
            Me.decimalPlacesNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.decimalPlacesNumericUpDown.Name = "decimalPlacesNumericUpDown"
            Me.decimalPlacesNumericUpDown.Size = New System.Drawing.Size(160, 21)
            Me.decimalPlacesNumericUpDown.TabIndex = 3
            '
            'decimalPlacesLabel
            '
            Me.decimalPlacesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.decimalPlacesLabel.Location = New System.Drawing.Point(0, 120)
            Me.decimalPlacesLabel.Name = "decimalPlacesLabel"
            Me.decimalPlacesLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.decimalPlacesLabel.Size = New System.Drawing.Size(160, 120)
            Me.decimalPlacesLabel.TabIndex = 5
            Me.decimalPlacesLabel.Text = "Decimal places"
            Me.decimalPlacesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'thousandsSeparatorCheckBox
            '
            Me.thousandsSeparatorCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.thousandsSeparatorCheckBox.Checked = True
            Me.thousandsSeparatorCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjTLP.SetColumnSpan(Me.thousandsSeparatorCheckBox, 2)
            Me.thousandsSeparatorCheckBox.Location = New System.Drawing.Point(60, 295)
            Me.thousandsSeparatorCheckBox.Name = "thousandsSeparatorCheckBox"
            Me.thousandsSeparatorCheckBox.Size = New System.Drawing.Size(200, 50)
            Me.thousandsSeparatorCheckBox.TabIndex = 6
            Me.thousandsSeparatorCheckBox.Text = "Enable thousands separator"
            Me.thousandsSeparatorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.thousandsSeparatorCheckBox.UseVisualStyleBackColor = True
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDownLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.thousandsSeparatorCheckBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.decimalPlacesLabel, 0, 1)
            Me.mobjTLP.Controls.Add(Me.decimalPlacesNumericUpDown, 1, 1)
            Me.mobjTLP.Controls.Add(Me.demoNumericUpDown, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 7
            '
            'FormatPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "FormatPage"
            CType(Me.demoNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.decimalPlacesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoNumericUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents decimalPlacesNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents decimalPlacesLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents thousandsSeparatorCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
