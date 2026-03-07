Namespace CompanionKit.Controls.Form.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MinimumSizePage
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
            Me.mobjWidthNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjHeightNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjOpenDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBorderButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBorderPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjWidthLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjHeightLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjWidthPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjHeightPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjContainerBorderPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjDialogPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjMinPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjWidthNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjHeightNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.mobjWidthPanel.SuspendLayout()
            Me.mobjHeightPanel.SuspendLayout()
            Me.mobjContainerBorderPanel.SuspendLayout()
            Me.mobjDialogPanel.SuspendLayout()
            Me.mobjMinPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWidthNUD
            ' 
            Me.mobjWidthNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjWidthNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjWidthNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjWidthNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjWidthNUD.Location = New System.Drawing.Point(0, 29)
            Me.mobjWidthNUD.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
            Me.mobjWidthNUD.Name = "objWidthNUD"
            Me.mobjWidthNUD.Size = New System.Drawing.Size(288, 17)
            Me.mobjWidthNUD.TabIndex = 0
            ' 
            ' mobjHeightNUD
            ' 
            Me.mobjHeightNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjHeightNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjHeightNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjHeightNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjHeightNUD.Location = New System.Drawing.Point(0, 29)
            Me.mobjHeightNUD.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
            Me.mobjHeightNUD.Name = "objHeightNUD"
            Me.mobjHeightNUD.Size = New System.Drawing.Size(288, 17)
            Me.mobjHeightNUD.TabIndex = 1
            ' 
            ' mobjOpenDialogButton
            ' 
            Me.mobjOpenDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenDialogButton.Location = New System.Drawing.Point(5, 5)
            Me.mobjOpenDialogButton.Name = "mobjOpenDialogButton"
            Me.mobjOpenDialogButton.Size = New System.Drawing.Size(278, 70)
            Me.mobjOpenDialogButton.TabIndex = 2
            Me.mobjOpenDialogButton.Text = "Open dialog"
            ' 
            ' mobjBorderButton
            ' 
            Me.mobjBorderButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBorderButton.Location = New System.Drawing.Point(5, 5)
            Me.mobjBorderButton.Name = "mobjBorderButton"
            Me.mobjBorderButton.Size = New System.Drawing.Size(278, 70)
            Me.mobjBorderButton.TabIndex = 3
            Me.mobjBorderButton.Text = "Show minimum size border"
            ' 
            ' mobjBorderPanel
            ' 
            Me.mobjBorderPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjBorderPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed
            Me.mobjBorderPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjBorderPanel.Location = New System.Drawing.Point(18, 13)
            Me.mobjBorderPanel.Name = "objBorderPanel"
            Me.mobjBorderPanel.Size = New System.Drawing.Size(0, 0)
            Me.mobjBorderPanel.TabIndex = 4
            Me.mobjBorderPanel.Visible = False
            ' 
            ' mobjWidthLabel
            ' 
            Me.mobjWidthLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjWidthLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjWidthLabel.Name = "objWidthLabel"
            Me.mobjWidthLabel.Size = New System.Drawing.Size(288, 29)
            Me.mobjWidthLabel.TabIndex = 5
            Me.mobjWidthLabel.Text = "MIN width"
            Me.mobjWidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' mobjHeightLabel
            ' 
            Me.mobjHeightLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjHeightLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjHeightLabel.Name = "objHeightLabel"
            Me.mobjHeightLabel.Size = New System.Drawing.Size(288, 29)
            Me.mobjHeightLabel.TabIndex = 5
            Me.mobjHeightLabel.Text = "MIN height"
            Me.mobjHeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerBorderPanel, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDialogPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinPanel, 1, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(742, 285)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjAdditionalLayoutPanel)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(20, 60)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(288, 100)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjAdditionalLayoutPanel.ColumnCount = 1
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjWidthPanel, 0, 0)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjHeightPanel, 0, 1)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 2
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(288, 100)
            Me.mobjAdditionalLayoutPanel.TabIndex = 6
            ' 
            ' mobjWidthPanel
            ' 
            Me.mobjWidthPanel.Controls.Add(Me.mobjWidthLabel)
            Me.mobjWidthPanel.Controls.Add(Me.mobjWidthNUD)
            Me.mobjWidthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjWidthPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjWidthPanel.Name = "mobjWidthPanel"
            Me.mobjWidthPanel.Size = New System.Drawing.Size(288, 50)
            Me.mobjWidthPanel.TabIndex = 0
            ' 
            ' mobjHeightPanel
            ' 
            Me.mobjHeightPanel.Controls.Add(Me.mobjHeightLabel)
            Me.mobjHeightPanel.Controls.Add(Me.mobjHeightNUD)
            Me.mobjHeightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHeightPanel.Location = New System.Drawing.Point(0, 50)
            Me.mobjHeightPanel.Name = "mobjHeightPanel"
            Me.mobjHeightPanel.Size = New System.Drawing.Size(288, 50)
            Me.mobjHeightPanel.TabIndex = 0
            ' 
            ' mobjContainerBorderPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjContainerBorderPanel, 2)
            Me.mobjContainerBorderPanel.Controls.Add(Me.mobjBorderPanel)
            Me.mobjContainerBorderPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerBorderPanel.Location = New System.Drawing.Point(308, 60)
            Me.mobjContainerBorderPanel.Name = "mobjBorderPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjContainerBorderPanel, 5)
            Me.mobjContainerBorderPanel.Size = New System.Drawing.Size(434, 340)
            Me.mobjContainerBorderPanel.TabIndex = 0
            ' 
            ' mobjDialogPanel
            ' 
            Me.mobjDialogPanel.Controls.Add(Me.mobjOpenDialogButton)
            Me.mobjDialogPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDialogPanel.DockPadding.All = 5
            Me.mobjDialogPanel.Location = New System.Drawing.Point(20, 180)
            Me.mobjDialogPanel.Name = "mobjDialogPanel"
            Me.mobjDialogPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjDialogPanel.Size = New System.Drawing.Size(288, 80)
            Me.mobjDialogPanel.TabIndex = 0
            ' 
            ' mobjMinPanel
            ' 
            Me.mobjMinPanel.Controls.Add(Me.mobjBorderButton)
            Me.mobjMinPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMinPanel.DockPadding.All = 5
            Me.mobjMinPanel.Location = New System.Drawing.Point(20, 260)
            Me.mobjMinPanel.Name = "mobjMinPanel"
            Me.mobjMinPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjMinPanel.Size = New System.Drawing.Size(288, 80)
            Me.mobjMinPanel.TabIndex = 0
            ' 
            ' MinimumSizePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(742, 400)
            Me.Text = "MinimumSizePage"
            DirectCast(Me.mobjWidthNUD, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjHeightNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.mobjWidthPanel.ResumeLayout(False)
            Me.mobjHeightPanel.ResumeLayout(False)
            Me.mobjContainerBorderPanel.ResumeLayout(False)
            Me.mobjDialogPanel.ResumeLayout(False)
            Me.mobjMinPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjWidthNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjHeightNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjOpenDialogButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjBorderButton As Gizmox.WebGUI.Forms.Button
        Private mobjBorderPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjWidthLabel As Gizmox.WebGUI.Forms.Label
        Private mobjHeightLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjContainerBorderPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjDialogPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjMinPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjWidthPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjHeightPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace