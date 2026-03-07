Namespace CompanionKit.Controls.TrackBar.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ServerSideEventsPage
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
            Me.mobjValueTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoTrackBar = New Gizmox.WebGUI.Forms.TrackBar()
            Me.mobjValueTrackBarNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjValueTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjValueTrackBarLabel
            ' 
            Me.mobjValueTrackBarLabel.AutoSize = True
            Me.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjValueTrackBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel"
            Me.mobjValueTrackBarLabel.Size = New System.Drawing.Size(78, 13)
            Me.mobjValueTrackBarLabel.TabIndex = 1
            Me.mobjValueTrackBarLabel.Text = "TrackBar value"
            ' 
            ' mobjDemoTrackBar
            ' 
            Me.mobjDemoTrackBar.AllowDrag = False
            Me.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTrackBar.Location = New System.Drawing.Point(74, 132)
            Me.mobjDemoTrackBar.Maximum = 100
            Me.mobjDemoTrackBar.Name = "mobjDemoTrackBar"
            Me.mobjDemoTrackBar.Size = New System.Drawing.Size(347, 40)
            Me.mobjDemoTrackBar.TabIndex = 3
            Me.mobjDemoTrackBar.TickFrequency = 5
            ' 
            ' mobjValueTrackBarNumericUpDown
            ' 
            Me.mobjValueTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjValueTrackBarNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjValueTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjValueTrackBarNumericUpDown.Location = New System.Drawing.Point(0, 39)
            Me.mobjValueTrackBarNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTrackBarNumericUpDown.Name = "mobjValueTrackBarNumericUpDown"
            Me.mobjValueTrackBarNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjValueTrackBarNumericUpDown.TabIndex = 4
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoTrackBar, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(497, 225)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjValueTrackBarLabel)
            Me.mobjPanel.Controls.Add(Me.mobjValueTrackBarNumericUpDown)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(74, 52)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(347, 60)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' ServerSideEventsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(497, 225)
            Me.Text = "ServerSideEventsPage"
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjValueTrackBarNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjValueTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDemoTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private WithEvents mobjValueTrackBarNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
