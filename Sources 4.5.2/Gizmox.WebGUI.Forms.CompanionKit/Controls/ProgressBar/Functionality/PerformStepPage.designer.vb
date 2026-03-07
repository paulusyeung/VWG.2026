Namespace CompanionKit.Controls.ProgressBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PerformStepPage
		Inherits UserControl

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
                End If
                Me.mobjIncrementTimer.Stop()

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
            Me.components = New System.ComponentModel.Container()
            Me.mobjDemoProgressBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjStepNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjStepProgressBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIncrementTimer = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjStepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoProgressBarLabel
            ' 
            Me.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel"
            Me.mobjDemoProgressBarLabel.Size = New System.Drawing.Size(136, 13)
            Me.mobjDemoProgressBarLabel.TabIndex = 0
            Me.mobjDemoProgressBarLabel.Text = "Demonstrated ProgressBar"
            Me.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoProgressBar
            ' 
            Me.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBar.Location = New System.Drawing.Point(112, 79)
            Me.mobjDemoProgressBar.Name = "mobjDemoProgressBar"
            Me.mobjDemoProgressBar.Size = New System.Drawing.Size(525, 30)
            Me.mobjDemoProgressBar.TabIndex = 1
            ' 
            ' mobjStepNumericUpDown
            ' 
            Me.mobjStepNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjStepNumericUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjStepNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStepNumericUpDown.Location = New System.Drawing.Point(112, 179)
            Me.mobjStepNumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.mobjStepNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjStepNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjStepNumericUpDown.Name = "mobjStepNumericUpDown"
            Me.mobjStepNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjStepNumericUpDown.TabIndex = 2
            Me.mobjStepNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' mobjStepProgressBarLabel
            ' 
            Me.mobjStepProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStepProgressBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjStepProgressBarLabel.Name = "mobjStepProgressBarLabel"
            Me.mobjStepProgressBarLabel.Size = New System.Drawing.Size(125, 13)
            Me.mobjStepProgressBarLabel.TabIndex = 3
            Me.mobjStepProgressBarLabel.Text = "Step of the ProgressBar "
            Me.mobjStepProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjIncrementTimer
            ' 
            Me.mobjIncrementTimer.Enabled = True
            Me.mobjIncrementTimer.Interval = 500
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBar, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStepNumericUpDown, 1, 5)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 52.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(751, 237)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjDemoProgressBarLabel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(112, 27)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(525, 52)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.Controls.Add(Me.mobjStepProgressBarLabel)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(112, 129)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(525, 50)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' PerformStepPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(751, 237)
            Me.Text = "PerformStepPage"
            Me.RegisteredTimers = New Gizmox.WebGUI.Forms.Timer() {Me.mobjIncrementTimer}
            DirectCast(Me.mobjStepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDemoProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private WithEvents mobjStepNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjStepProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIncrementTimer As Gizmox.WebGUI.Forms.Timer
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace