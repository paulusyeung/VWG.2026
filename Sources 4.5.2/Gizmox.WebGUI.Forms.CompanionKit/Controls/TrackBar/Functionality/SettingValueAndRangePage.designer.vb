Namespace CompanionKit.Controls.TrackBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SettingValueAndRangePage
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
            Me.mobjValueTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueTrackBarNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjMinTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaxTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMinTrackBarNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjMaxTrackBarNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjValueTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjMinTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjMaxTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTrackBar
            ' 
            Me.mobjDemoTrackBar.AllowDrag = False
            Me.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTrackBar.Location = New System.Drawing.Point(0, 0)
            Me.mobjDemoTrackBar.Maximum = 100
            Me.mobjDemoTrackBar.Name = "mobjDemoTrackBar"
            Me.mobjDemoTrackBar.Size = New System.Drawing.Size(454, 40)
            Me.mobjDemoTrackBar.TabIndex = 0
            Me.mobjDemoTrackBar.TickFrequency = 5
            Me.mobjDemoTrackBar.TickStyle = Gizmox.WebGUI.Forms.TickStyle.Both
            ' 
            ' mobjValueTrackBarLabel
            ' 
            Me.mobjValueTrackBarLabel.AutoSize = True
            Me.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjValueTrackBarLabel.Location = New System.Drawing.Point(97, 26)
            Me.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel"
            Me.mobjValueTrackBarLabel.Size = New System.Drawing.Size(227, 13)
            Me.mobjValueTrackBarLabel.TabIndex = 2
            Me.mobjValueTrackBarLabel.Text = "TrackBar value"
            ' 
            ' mobjValueTrackBarNumericUpDown
            ' 
            Me.mobjValueTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjValueTrackBarNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjValueTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjValueTrackBarNumericUpDown.Location = New System.Drawing.Point(324, 26)
            Me.mobjValueTrackBarNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTrackBarNumericUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me.mobjValueTrackBarNumericUpDown.Name = "mobjValueTrackBarNumericUpDown"
            Me.mobjValueTrackBarNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjValueTrackBarNumericUpDown.TabIndex = 3
            ' 
            ' mobjMinTrackBarLabel
            ' 
            Me.mobjMinTrackBarLabel.AutoSize = True
            Me.mobjMinTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMinTrackBarLabel.Location = New System.Drawing.Point(97, 66)
            Me.mobjMinTrackBarLabel.Name = "mobjMinTrackBarLabel"
            Me.mobjMinTrackBarLabel.Size = New System.Drawing.Size(227, 13)
            Me.mobjMinTrackBarLabel.TabIndex = 4
            Me.mobjMinTrackBarLabel.Text = "Minimum value"
            ' 
            ' mobjMaxTrackBarLabel
            ' 
            Me.mobjMaxTrackBarLabel.AutoSize = True
            Me.mobjMaxTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaxTrackBarLabel.Location = New System.Drawing.Point(97, 106)
            Me.mobjMaxTrackBarLabel.Name = "mobjMaxTrackBarLabel"
            Me.mobjMaxTrackBarLabel.Size = New System.Drawing.Size(227, 13)
            Me.mobjMaxTrackBarLabel.TabIndex = 5
            Me.mobjMaxTrackBarLabel.Text = "Maximum value"
            ' 
            ' mobjMinTrackBarNumericUpDown
            ' 
            Me.mobjMinTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMinTrackBarNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjMinTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMinTrackBarNumericUpDown.Location = New System.Drawing.Point(324, 66)
            Me.mobjMinTrackBarNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMinTrackBarNumericUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me.mobjMinTrackBarNumericUpDown.Name = "mobjMinTrackBarNumericUpDown"
            Me.mobjMinTrackBarNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjMinTrackBarNumericUpDown.TabIndex = 6
            ' 
            ' mobjMaxTrackBarNumericUpDown
            ' 
            Me.mobjMaxTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMaxTrackBarNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjMaxTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaxTrackBarNumericUpDown.Location = New System.Drawing.Point(324, 106)
            Me.mobjMaxTrackBarNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaxTrackBarNumericUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me.mobjMaxTrackBarNumericUpDown.Name = "mobjMaxTrackBarNumericUpDown"
            Me.mobjMaxTrackBarNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjMaxTrackBarNumericUpDown.TabIndex = 7
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxTrackBarNumericUpDown, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueTrackBarLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinTrackBarLabel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxTrackBarLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinTrackBarNumericUpDown, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueTrackBarNumericUpDown, 2, 1)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(650, 212)
            Me.mobjLayoutPanel.TabIndex = 8
            ' 
            ' mobjPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel, 2)
            Me.mobjPanel.Controls.Add(Me.mobjDemoTrackBar)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(97, 146)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(454, 40)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' SettingValueAndRangePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(650, 212)
            Me.Text = "SettingValueAndRangePage"
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjValueTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjMinTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjMaxTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjValueTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjValueTrackBarNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjMinTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private mobjMaxTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMinTrackBarNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjMaxTrackBarNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
