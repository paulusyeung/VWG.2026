Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MinSizePage
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
            Me.mobjSetMinSizeFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMinSizeFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjSetMinSizeFontNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjSetMinSizeFontNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSetMinSizeFontLabel
            ' 
            Me.mobjSetMinSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSetMinSizeFontLabel.Location = New System.Drawing.Point(59, 101)
            Me.mobjSetMinSizeFontLabel.Name = "mobjSetMinSizeFontLabel"
            Me.mobjSetMinSizeFontLabel.Size = New System.Drawing.Size(298, 50)
            Me.mobjSetMinSizeFontLabel.TabIndex = 1
            Me.mobjSetMinSizeFontLabel.Text = "Minimum font size for label"
            ' 
            ' mobjMinSizeFontLabel
            ' 
            Me.mobjMinSizeFontLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjMinSizeFontLabel, 2)
            Me.mobjMinSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMinSizeFontLabel.Location = New System.Drawing.Point(59, 11)
            Me.mobjMinSizeFontLabel.Name = "mobjMinSizeFontLabel"
            Me.mobjMinSizeFontLabel.Size = New System.Drawing.Size(477, 50)
            Me.mobjMinSizeFontLabel.TabIndex = 3
            Me.mobjMinSizeFontLabel.Text = "Font selected in the dialog: "
            ' 
            ' mobjChangeFontButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjChangeFontButton, 2)
            Me.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeFontButton.Location = New System.Drawing.Point(59, 171)
            Me.mobjChangeFontButton.Name = "mobjChangeFontButton"
            Me.mobjChangeFontButton.Size = New System.Drawing.Size(477, 50)
            Me.mobjChangeFontButton.TabIndex = 4
            Me.mobjChangeFontButton.Text = "Open FontDialog to change font of the label"
            Me.mobjChangeFontButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoFontDialog
            ' 
            Me.mobjDemoFontDialog.MaxSize = 28
            Me.mobjDemoFontDialog.MinSize = 8
            ' 
            ' mobjSetMinSizeFontNumericUpDown
            ' 
            Me.mobjSetMinSizeFontNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSetMinSizeFontNumericUpDown.CurrentValue = New Decimal(New Integer() {20, 0, 0, 0})
            Me.mobjSetMinSizeFontNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSetMinSizeFontNumericUpDown.Location = New System.Drawing.Point(357, 101)
            Me.mobjSetMinSizeFontNumericUpDown.Maximum = New Decimal(New Integer() {28, 0, 0, 0})
            Me.mobjSetMinSizeFontNumericUpDown.Name = "mobjSetMinSizeFontNumericUpDown"
            Me.mobjSetMinSizeFontNumericUpDown.Size = New System.Drawing.Size(179, 21)
            Me.mobjSetMinSizeFontNumericUpDown.TabIndex = 5
            Me.mobjSetMinSizeFontNumericUpDown.Value = New Decimal(New Integer() {20, 0, 0, 0})
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeFontButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetMinSizeFontNumericUpDown, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetMinSizeFontLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinSizeFontLabel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(597, 232)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' MinSizePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(583, 374)
            Me.Text = "MinSizePage"
            DirectCast(Me.mobjSetMinSizeFontNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjSetMinSizeFontLabel As Gizmox.WebGUI.Forms.Label
        Private mobjMinSizeFontLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjChangeFontButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjSetMinSizeFontNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
