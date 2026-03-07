Namespace CompanionKit.Controls.ProgressBar.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ChangeValuePage
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
            Me.mobjIncrementTimer = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoProgressBarLabel
            ' 
            Me.mobjDemoProgressBarLabel.AutoSize = True
            Me.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarLabel.Location = New System.Drawing.Point(122, 45)
            Me.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel"
            Me.mobjDemoProgressBarLabel.Size = New System.Drawing.Size(569, 50)
            Me.mobjDemoProgressBarLabel.TabIndex = 0
            Me.mobjDemoProgressBarLabel.Text = "Demonstrated ProgressBar"
            Me.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoProgressBar
            ' 
            Me.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBar.Location = New System.Drawing.Point(122, 95)
            Me.mobjDemoProgressBar.Name = "mobjDemoProgressBar"
            Me.mobjDemoProgressBar.Size = New System.Drawing.Size(569, 30)
            Me.mobjDemoProgressBar.TabIndex = 1
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
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBarLabel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(814, 170)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' ChangeValuePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(814, 170)
            Me.Text = "ChangeValuePage"
            Me.RegisteredTimers = New Gizmox.WebGUI.Forms.Timer() {Me.mobjIncrementTimer}
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDemoProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private WithEvents mobjIncrementTimer As Gizmox.WebGUI.Forms.Timer
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace