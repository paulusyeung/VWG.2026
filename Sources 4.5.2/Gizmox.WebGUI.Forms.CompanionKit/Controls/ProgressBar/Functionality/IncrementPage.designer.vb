Namespace CompanionKit.Controls.ProgressBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class IncrementPage
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
            Me.mobjDemoProgressBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjStepProgressBarNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjStepProgressBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIncrementButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjNUDPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjStepProgressBarNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjNUDPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoProgressBarLabel
            ' 
            Me.mobjDemoProgressBarLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBarLabel, 4)
            Me.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarLabel.Location = New System.Drawing.Point(177, 30)
            Me.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel"
            Me.mobjDemoProgressBarLabel.Size = New System.Drawing.Size(710, 50)
            Me.mobjDemoProgressBarLabel.TabIndex = 0
            Me.mobjDemoProgressBarLabel.Text = "Demonstrated of the ProgressBar"
            Me.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoProgressBar
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBar, 3)
            Me.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBar.Location = New System.Drawing.Point(177, 80)
            Me.mobjDemoProgressBar.Name = "mobjDemoProgressBar"
            Me.mobjDemoProgressBar.Size = New System.Drawing.Size(530, 30)
            Me.mobjDemoProgressBar.TabIndex = 1
            ' 
            ' mobjStepProgressBarNumericUpDown
            ' 
            Me.mobjStepProgressBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjStepProgressBarNumericUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjStepProgressBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjStepProgressBarNumericUpDown.Location = New System.Drawing.Point(0, 39)
            Me.mobjStepProgressBarNumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.mobjStepProgressBarNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjStepProgressBarNumericUpDown.Name = "mobjStepProgressBarNumericUpDown"
            Me.mobjStepProgressBarNumericUpDown.Size = New System.Drawing.Size(221, 21)
            Me.mobjStepProgressBarNumericUpDown.TabIndex = 2
            Me.mobjStepProgressBarNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' mobjStepProgressBarLabel
            ' 
            Me.mobjStepProgressBarLabel.AutoSize = True
            Me.mobjStepProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjStepProgressBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjStepProgressBarLabel.Name = "mobjStepProgressBarLabel"
            Me.mobjStepProgressBarLabel.Size = New System.Drawing.Size(29, 13)
            Me.mobjStepProgressBarLabel.TabIndex = 3
            Me.mobjStepProgressBarLabel.Text = "Step"
            ' 
            ' mobjIncrementButton
            ' 
            Me.mobjIncrementButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjIncrementButton.Location = New System.Drawing.Point(486, 130)
            Me.mobjIncrementButton.Name = "mobjIncrementButton"
            Me.mobjIncrementButton.Size = New System.Drawing.Size(221, 60)
            Me.mobjIncrementButton.TabIndex = 4
            Me.mobjIncrementButton.Text = "Increment value"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBar, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjIncrementButton, 3, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNUDPanel, 1, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(887, 221)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjNUDPanel
            ' 
            Me.mobjNUDPanel.Controls.Add(Me.mobjStepProgressBarNumericUpDown)
            Me.mobjNUDPanel.Controls.Add(Me.mobjStepProgressBarLabel)
            Me.mobjNUDPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNUDPanel.Location = New System.Drawing.Point(177, 130)
            Me.mobjNUDPanel.Name = "mobjNUDPanel"
            Me.mobjNUDPanel.Size = New System.Drawing.Size(221, 60)
            Me.mobjNUDPanel.TabIndex = 0
            ' 
            ' IncrementPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(887, 221)
            Me.Text = "IncrementPage"
            DirectCast(Me.mobjStepProgressBarNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjNUDPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDemoProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjStepProgressBarNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjStepProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIncrementButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjNUDPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace