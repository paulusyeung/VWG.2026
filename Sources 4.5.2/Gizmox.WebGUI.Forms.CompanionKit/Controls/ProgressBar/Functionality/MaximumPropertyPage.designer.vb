Namespace CompanionKit.Controls.ProgressBar.Functionality

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
            Me.mobjDemoMax100ProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjDemoMax25ProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjDemoProgressBarMax100label = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoProgressBarMax25label = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIncrementTimer = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoMax100ProgressBar
            ' 
            Me.mobjDemoMax100ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoMax100ProgressBar.Location = New System.Drawing.Point(0, 10)
            Me.mobjDemoMax100ProgressBar.Name = "mobjDemoMax100ProgressBar"
            Me.mobjDemoMax100ProgressBar.Size = New System.Drawing.Size(518, 20)
            Me.mobjDemoMax100ProgressBar.TabIndex = 0
            ' 
            ' mobjDemoMax25ProgressBar
            ' 
            Me.mobjDemoMax25ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoMax25ProgressBar.Location = New System.Drawing.Point(0, 10)
            Me.mobjDemoMax25ProgressBar.Maximum = 25
            Me.mobjDemoMax25ProgressBar.Name = "mobjDemoMax25ProgressBar"
            Me.mobjDemoMax25ProgressBar.Size = New System.Drawing.Size(518, 20)
            Me.mobjDemoMax25ProgressBar.TabIndex = 1
            ' 
            ' mobjDemoProgressBarMax100label
            ' 
            Me.mobjDemoProgressBarMax100label.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBarMax100label, 2)
            Me.mobjDemoProgressBarMax100label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarMax100label.Location = New System.Drawing.Point(111, 22)
            Me.mobjDemoProgressBarMax100label.Name = "mobjDemoProgressBarMax100label"
            Me.mobjDemoProgressBarMax100label.Size = New System.Drawing.Size(629, 50)
            Me.mobjDemoProgressBarMax100label.TabIndex = 2
            Me.mobjDemoProgressBarMax100label.Text = "Demonstrated ProgressBar(Maximum - 100)"
            ' 
            ' mobjDemoProgressBarMax25label
            ' 
            Me.mobjDemoProgressBarMax25label.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBarMax25label, 2)
            Me.mobjDemoProgressBarMax25label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarMax25label.Location = New System.Drawing.Point(111, 122)
            Me.mobjDemoProgressBarMax25label.Name = "mobjDemoProgressBarMax25label"
            Me.mobjDemoProgressBarMax25label.Size = New System.Drawing.Size(629, 50)
            Me.mobjDemoProgressBarMax25label.TabIndex = 3
            Me.mobjDemoProgressBarMax25label.Text = "Demonstrated ProgressBar(Maximum - 25)"
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
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarMax25label, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarMax100label, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 5)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(738, 221)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjDemoMax100ProgressBar)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.DockPadding.Top = 10
            Me.mobjTopPanel.Location = New System.Drawing.Point(111, 72)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.mobjTopPanel.Size = New System.Drawing.Size(518, 30)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.Controls.Add(Me.mobjDemoMax25ProgressBar)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.DockPadding.Top = 10
            Me.mobjBottomPanel.Location = New System.Drawing.Point(111, 172)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.mobjBottomPanel.Size = New System.Drawing.Size(518, 30)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' MaximumPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(740, 225)
            Me.Text = "MaximumPropertyPage"
            Me.RegisteredTimers = New Gizmox.WebGUI.Forms.Timer() {Me.mobjIncrementTimer}
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoMax100ProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjDemoMax25ProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjDemoProgressBarMax100label As Gizmox.WebGUI.Forms.Label
        Private mobjDemoProgressBarMax25label As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIncrementTimer As Gizmox.WebGUI.Forms.Timer
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace