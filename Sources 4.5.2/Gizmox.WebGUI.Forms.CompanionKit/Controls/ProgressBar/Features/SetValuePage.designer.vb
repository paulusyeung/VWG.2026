Namespace CompanionKit.Controls.ProgressBar.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SetValuePage
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
            Me.mobjDemoProgressBar = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjChangevalueTrackBar = New Gizmox.WebGUI.Forms.TrackBar()
            Me.mobjDemoProgressBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeValueLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTrackBarPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjProgressBarPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjChangevalueTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjProgressBarPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoProgressBar
            ' 
            Me.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBar.Location = New System.Drawing.Point(122, 70)
            Me.mobjDemoProgressBar.Maximum = 200
            Me.mobjDemoProgressBar.Name = "mobjDemoProgressBar"
            Me.mobjDemoProgressBar.Size = New System.Drawing.Size(570, 30)
            Me.mobjDemoProgressBar.TabIndex = 0
            ' 
            ' mobjChangevalueTrackBar
            ' 
            Me.mobjChangevalueTrackBar.AllowDrag = False
            Me.mobjChangevalueTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangevalueTrackBar.Location = New System.Drawing.Point(122, 170)
            Me.mobjChangevalueTrackBar.Name = "mobjChangevalueTrackBar"
            Me.mobjChangevalueTrackBar.Size = New System.Drawing.Size(570, 30)
            Me.mobjChangevalueTrackBar.TabIndex = 1
            ' 
            ' mobjDemoProgressBarLabel
            ' 
            Me.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoProgressBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel"
            Me.mobjDemoProgressBarLabel.Size = New System.Drawing.Size(130, 13)
            Me.mobjDemoProgressBarLabel.TabIndex = 2
            Me.mobjDemoProgressBarLabel.Text = "Demonstrate ProgressBar"
            Me.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjChangeValueLabel
            ' 
            Me.mobjChangeValueLabel.AutoSize = True
            Me.mobjChangeValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeValueLabel.Location = New System.Drawing.Point(122, 120)
            Me.mobjChangeValueLabel.Name = "mobjChangeValueLabel"
            Me.mobjChangeValueLabel.Size = New System.Drawing.Size(570, 50)
            Me.mobjChangeValueLabel.TabIndex = 4
            Me.mobjChangeValueLabel.Text = "Change value of the ProgressBar"
            Me.mobjChangeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoProgressBar, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangevalueTrackBar, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTrackBarPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeValueLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjProgressBarPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(815, 222)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjTrackBarPanel
            ' 
            Me.mobjTrackBarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTrackBarPanel.Location = New System.Drawing.Point(122, 170)
            Me.mobjTrackBarPanel.Name = "mobjTrackBarPanel"
            Me.mobjTrackBarPanel.Size = New System.Drawing.Size(570, 30)
            Me.mobjTrackBarPanel.TabIndex = 0
            ' 
            ' mobjProgressBarPanel
            ' 
            Me.mobjProgressBarPanel.Controls.Add(Me.mobjDemoProgressBarLabel)
            Me.mobjProgressBarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBarPanel.Location = New System.Drawing.Point(122, 20)
            Me.mobjProgressBarPanel.Name = "mobjProgressBarPanel"
            Me.mobjProgressBarPanel.Size = New System.Drawing.Size(570, 50)
            Me.mobjProgressBarPanel.TabIndex = 0
            ' 
            ' SetValuePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(815, 222)
            Me.Text = "SetValuePage"
            DirectCast(Me.mobjChangevalueTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjProgressBarPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoProgressBar As Gizmox.WebGUI.Forms.ProgressBar
        Private WithEvents mobjChangevalueTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjDemoProgressBarLabel As Gizmox.WebGUI.Forms.Label
        Private mobjChangeValueLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTrackBarPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjProgressBarPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace