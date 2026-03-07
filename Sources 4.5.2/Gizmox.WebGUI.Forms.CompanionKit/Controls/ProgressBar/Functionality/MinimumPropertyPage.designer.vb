Namespace CompanionKit.Controls.ProgressBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MinimumPropertyPage
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
            Me.mobjDemoMin0ProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjDemoMin75ProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjDemoProgressBarMin0label = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoProgressBarMin75label = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIncrementTimer = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoMin0ProgressBar
            ' 
            Me.mobjDemoMin0ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoMin0ProgressBar.Location = New System.Drawing.Point(0, 10)
            Me.mobjDemoMin0ProgressBar.Name = "mobjDemoMin0ProgressBar"
            Me.mobjDemoMin0ProgressBar.Size = New System.Drawing.Size(518, 20)
            Me.mobjDemoMin0ProgressBar.[Step] = 5
            Me.mobjDemoMin0ProgressBar.TabIndex = 0
            ' 
            ' mobjDemoMin75ProgressBar
            ' 
            Me.mobjDemoMin75ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoMin75ProgressBar.Location = New System.Drawing.Point(0, 10)
            Me.mobjDemoMin75ProgressBar.Minimum = 75
            Me.mobjDemoMin75ProgressBar.Name = "mobjDemoMin75ProgressBar"
            Me.mobjDemoMin75ProgressBar.Size = New System.Drawing.Size(518, 20)
            Me.mobjDemoMin75ProgressBar.[Step] = 5
            Me.mobjDemoMin75ProgressBar.TabIndex = 1
            Me.mobjDemoMin75ProgressBar.Value = 75
            ' 
            ' mobjDemoProgressBarMin0label
            ' 
            Me.mobjDemoProgressBarMin0label.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBarMin0label, 2)
            Me.mobjDemoProgressBarMin0label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarMin0label.Location = New System.Drawing.Point(111, 22)
            Me.mobjDemoProgressBarMin0label.Name = "mobjDemoProgressBarMin0label"
            Me.mobjDemoProgressBarMin0label.Size = New System.Drawing.Size(629, 50)
            Me.mobjDemoProgressBarMin0label.TabIndex = 2
            Me.mobjDemoProgressBarMin0label.Text = "Demonstrated ProgressBar(Minimum - 0)"
            ' 
            ' mobjDemoProgressBarMin75label
            ' 
            Me.mobjDemoProgressBarMin75label.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDemoProgressBarMin75label, 2)
            Me.mobjDemoProgressBarMin75label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarMin75label.Location = New System.Drawing.Point(111, 122)
            Me.mobjDemoProgressBarMin75label.Name = "mobjDemoProgressBarMin75label"
            Me.mobjDemoProgressBarMin75label.Size = New System.Drawing.Size(629, 50)
            Me.mobjDemoProgressBarMin75label.TabIndex = 3
            Me.mobjDemoProgressBarMin75label.Text = "Demonstrated ProgressBar(Minimum - 75)"
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
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarMin0label, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarMin75label, 1, 4)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(818, 221)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjDemoMin0ProgressBar)
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
            Me.mobjBottomPanel.Controls.Add(Me.mobjDemoMin75ProgressBar)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.DockPadding.Top = 10
            Me.mobjBottomPanel.Location = New System.Drawing.Point(111, 172)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.mobjBottomPanel.Size = New System.Drawing.Size(518, 30)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' MinimumPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(740, 225)
            Me.Text = "MinimumPropertyPage"
            Me.RegisteredTimers = New Gizmox.WebGUI.Forms.Timer() {Me.mobjIncrementTimer}
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoMin0ProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjDemoMin75ProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjDemoProgressBarMin0label As Gizmox.WebGUI.Forms.Label
        Private mobjDemoProgressBarMin75label As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIncrementTimer As Gizmox.WebGUI.Forms.Timer
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace