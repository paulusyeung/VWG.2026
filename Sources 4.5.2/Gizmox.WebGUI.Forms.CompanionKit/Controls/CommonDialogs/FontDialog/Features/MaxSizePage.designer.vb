Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaxSizePage
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
            Me.mobjDemoFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjSetMaxSizeFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaxSizeFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSetMaxSizeFontNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjSetMaxSizeFontNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoFontDialog
            ' 
            Me.mobjDemoFontDialog.MaxSize = 28
            Me.mobjDemoFontDialog.MinSize = 8
            ' 
            ' mobjSetMaxSizeFontLabel
            ' 
            Me.mobjSetMaxSizeFontLabel.AutoSize = True
            Me.mobjSetMaxSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSetMaxSizeFontLabel.Location = New System.Drawing.Point(58, 172)
            Me.mobjSetMaxSizeFontLabel.Name = "mobjSetMaxSizeFontLabel"
            Me.mobjSetMaxSizeFontLabel.Size = New System.Drawing.Size(291, 50)
            Me.mobjSetMaxSizeFontLabel.TabIndex = 1
            Me.mobjSetMaxSizeFontLabel.Text = "Maximum font size for label"
            ' 
            ' mobjMaxSizeFontLabel
            ' 
            Me.mobjMaxSizeFontLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjMaxSizeFontLabel, 2)
            Me.mobjMaxSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaxSizeFontLabel.Location = New System.Drawing.Point(58, 82)
            Me.mobjMaxSizeFontLabel.Name = "mobjMaxSizeFontLabel"
            Me.mobjMaxSizeFontLabel.Size = New System.Drawing.Size(465, 50)
            Me.mobjMaxSizeFontLabel.TabIndex = 3
            Me.mobjMaxSizeFontLabel.Text = "Font selected in the dialog:"
            ' 
            ' mobjChangeFontButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjChangeFontButton, 2)
            Me.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeFontButton.Location = New System.Drawing.Point(58, 242)
            Me.mobjChangeFontButton.Name = "mobjChangeFontButton"
            Me.mobjChangeFontButton.Size = New System.Drawing.Size(465, 50)
            Me.mobjChangeFontButton.TabIndex = 4
            Me.mobjChangeFontButton.Text = "Open FontDialog to change font of the label"
            Me.mobjChangeFontButton.UseVisualStyleBackColor = True
            ' 
            ' mobjSetMaxSizeFontNumericUpDown
            ' 
            Me.mobjSetMaxSizeFontNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSetMaxSizeFontNumericUpDown.CurrentValue = New Decimal(New Integer() {28, 0, 0, 0})
            Me.mobjSetMaxSizeFontNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSetMaxSizeFontNumericUpDown.Location = New System.Drawing.Point(349, 172)
            Me.mobjSetMaxSizeFontNumericUpDown.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.mobjSetMaxSizeFontNumericUpDown.MinimumSize = New System.Drawing.Size(100, 0)
            Me.mobjSetMaxSizeFontNumericUpDown.Name = "mobjSetMaxSizeFontNumericUpDown"
            Me.mobjSetMaxSizeFontNumericUpDown.Size = New System.Drawing.Size(174, 21)
            Me.mobjSetMaxSizeFontNumericUpDown.TabIndex = 5
            Me.mobjSetMaxSizeFontNumericUpDown.Value = New Decimal(New Integer() {28, 0, 0, 0})
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxSizeFontLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeFontButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetMaxSizeFontNumericUpDown, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetMaxSizeFontLabel, 1, 3)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(583, 374)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' MaxSizePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(583, 374)
            Me.Text = "MaxSizePage"
            DirectCast(Me.mobjSetMaxSizeFontNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjSetMaxSizeFontLabel As Gizmox.WebGUI.Forms.Label
        Private mobjMaxSizeFontLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjChangeFontButton As Gizmox.WebGUI.Forms.Button
        Private mobjSetMaxSizeFontNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
