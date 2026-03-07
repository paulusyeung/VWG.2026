Namespace CompanionKit.Controls.TrackBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BoundsPage
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
            Me.mobjDemoTrackBar = New Gizmox.WebGUI.Forms.TrackBar()
            Me.mobjMinBoundLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMinBoundNumUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjMaxBoundLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaxBoundNumUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjTrackBarToolTip = New Gizmox.WebGUI.Forms.ToolTip()
            Me.mobjValueTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjMinBoundNumUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjMaxBoundNumUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTrackBar
            ' 
            Me.mobjDemoTrackBar.AllowDrag = False
            Me.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDemoTrackBar.Location = New System.Drawing.Point(0, 0)
            Me.mobjDemoTrackBar.Maximum = 255
            Me.mobjDemoTrackBar.Minimum = -255
            Me.mobjDemoTrackBar.Name = "mobjDemoTrackBar"
            Me.mobjDemoTrackBar.Size = New System.Drawing.Size(490, 42)
            Me.mobjDemoTrackBar.TabIndex = 0
            Me.mobjDemoTrackBar.TickFrequency = 10
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjDemoTrackBar, Nothing)
            ' 
            ' mobjMinBoundLabel
            ' 
            Me.mobjMinBoundLabel.AutoSize = True
            Me.mobjMinBoundLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMinBoundLabel.Location = New System.Drawing.Point(105, 64)
            Me.mobjMinBoundLabel.Name = "mobjMinBoundLabel"
            Me.mobjMinBoundLabel.Size = New System.Drawing.Size(245, 13)
            Me.mobjMinBoundLabel.TabIndex = 1
            Me.mobjMinBoundLabel.Text = "Minimum value"
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjMinBoundLabel, Nothing)
            ' 
            ' mobjMinBoundNumUpDown
            ' 
            Me.mobjMinBoundNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMinBoundNumUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjMinBoundNumUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMinBoundNumUpDown.Location = New System.Drawing.Point(350, 64)
            Me.mobjMinBoundNumUpDown.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjMinBoundNumUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMinBoundNumUpDown.Minimum = New Decimal(New Integer() {300, 0, 0, -2147483648})
            Me.mobjMinBoundNumUpDown.Name = "mobjMinBoundNumUpDown"
            Me.mobjMinBoundNumUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjMinBoundNumUpDown.TabIndex = 2
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjMinBoundNumUpDown, Nothing)
            ' 
            ' mobjMaxBoundLabel
            ' 
            Me.mobjMaxBoundLabel.AutoSize = True
            Me.mobjMaxBoundLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaxBoundLabel.Location = New System.Drawing.Point(105, 104)
            Me.mobjMaxBoundLabel.Name = "mobjMaxBoundLabel"
            Me.mobjMaxBoundLabel.Size = New System.Drawing.Size(245, 13)
            Me.mobjMaxBoundLabel.TabIndex = 3
            Me.mobjMaxBoundLabel.Text = "Maximum value"
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjMaxBoundLabel, Nothing)
            ' 
            ' mobjMaxBoundNumUpDown
            ' 
            Me.mobjMaxBoundNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMaxBoundNumUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjMaxBoundNumUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaxBoundNumUpDown.Location = New System.Drawing.Point(350, 104)
            Me.mobjMaxBoundNumUpDown.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
            Me.mobjMaxBoundNumUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaxBoundNumUpDown.Name = "mobjMaxBoundNumUpDown"
            Me.mobjMaxBoundNumUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjMaxBoundNumUpDown.TabIndex = 4
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjMaxBoundNumUpDown, Nothing)
            ' 
            ' mobjValueTrackBarLabel
            ' 
            Me.mobjValueTrackBarLabel.AutoSize = True
            Me.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjValueTrackBarLabel.Location = New System.Drawing.Point(105, 24)
            Me.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel"
            Me.mobjValueTrackBarLabel.Size = New System.Drawing.Size(245, 13)
            Me.mobjValueTrackBarLabel.TabIndex = 6
            Me.mobjValueTrackBarLabel.Text = "TrackBar Value"
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjValueTrackBarLabel, Nothing)
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBox.Location = New System.Drawing.Point(353, 27)
            Me.mobjTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.[ReadOnly] = True
            Me.mobjTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjTextBox.TabIndex = 7
            Me.mobjTrackBarToolTip.SetToolTip(Me.mobjTextBox, Nothing)
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxBoundNumUpDown, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxBoundLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueTrackBarLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinBoundLabel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinBoundNumUpDown, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(700, 208)
            Me.mobjLayoutPanel.TabIndex = 8
            ' 
            ' mobjPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel, 2)
            Me.mobjPanel.Controls.Add(Me.mobjDemoTrackBar)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(105, 144)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(490, 40)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' BoundsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(700, 208)
            Me.Text = "BoundsPage"
            Me.mobjTrackBarToolTip.SetToolTip(Me, Nothing)
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjMinBoundNumUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjMaxBoundNumUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjMinBoundLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMinBoundNumUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjMaxBoundLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMaxBoundNumUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjTrackBarToolTip As Gizmox.WebGUI.Forms.ToolTip
        Private mobjValueTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
