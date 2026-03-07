Namespace CompanionKit.Controls.StatusBar.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ShowPageStatusPage
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
            Me.components = New System.ComponentModel.Container()
            Me.mobjUpdateStatusBarTimer = New Gizmox.WebGUI.Forms.Timer(Me.components)
            Me.mobjDemoStatusBar = New Gizmox.WebGUI.Forms.StatusBar()
            Me.mobjProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjUpdateStatusBarTimer
            ' 
            Me.mobjUpdateStatusBarTimer.Enabled = True
            Me.mobjUpdateStatusBarTimer.Interval = 500
            ' 
            ' mobjDemoStatusBar
            ' 
            Me.mobjDemoStatusBar.Location = New System.Drawing.Point(0, 149)
            Me.mobjDemoStatusBar.Name = "mobjDemoStatusBar"
            Me.mobjDemoStatusBar.Size = New System.Drawing.Size(391, 22)
            Me.mobjDemoStatusBar.TabIndex = 1
            Me.mobjDemoStatusBar.Text = "Starting"
            ' 
            ' mobjProgressBar
            ' 
            Me.mobjProgressBar.Anchor = DirectCast(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Left) Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjProgressBar.Location = New System.Drawing.Point(38, 81)
            Me.mobjProgressBar.Name = "mobjProgressBar"
            Me.mobjProgressBar.Size = New System.Drawing.Size(317, 23)
            Me.mobjProgressBar.TabIndex = 2
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(35, 57)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 3
            Me.mobjLabel.Text = "Loading, please wait..."
            ' 
            ' ShowPageStatusPage
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjProgressBar)
            Me.Controls.Add(Me.mobjDemoStatusBar)
            Me.Size = New System.Drawing.Size(390, 171)
            Me.Text = "ShowPageStatusPage"
            Me.RegisteredTimers = New Gizmox.WebGUI.Forms.Timer() {Me.mobjUpdateStatusBarTimer}
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjUpdateStatusBarTimer As Gizmox.WebGUI.Forms.Timer
        Private mobjDemoStatusBar As Gizmox.WebGUI.Forms.StatusBar
        Private mobjProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace
