Namespace CompanionKit.Controls.TrackBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class OrientationPage
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
            Me.mobjOrientationTrackBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOrientationTrackBarComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjOrientationPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjHorizontalPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjVerticalPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjOrientationPanel.SuspendLayout()
            Me.mobjHorizontalPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTrackBar
            ' 
            Me.mobjDemoTrackBar.AllowDrag = False
            Me.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTrackBar.Location = New System.Drawing.Point(0, 0)
            Me.mobjDemoTrackBar.Maximum = 100
            Me.mobjDemoTrackBar.Name = "mobjDemoTrackBar"
            Me.mobjDemoTrackBar.Size = New System.Drawing.Size(250, 40)
            Me.mobjDemoTrackBar.TabIndex = 0
            Me.mobjDemoTrackBar.TickFrequency = 5
            ' 
            ' mobjOrientationTrackBarLabel
            ' 
            Me.mobjOrientationTrackBarLabel.AutoSize = True
            Me.mobjOrientationTrackBarLabel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand
            Me.mobjOrientationTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjOrientationTrackBarLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjOrientationTrackBarLabel.Name = "mobjOrientationTrackBarLabel"
            Me.mobjOrientationTrackBarLabel.Size = New System.Drawing.Size(104, 13)
            Me.mobjOrientationTrackBarLabel.TabIndex = 1
            Me.mobjOrientationTrackBarLabel.Text = "TrackBar orientation"
            ' 
            ' mobjOrientationTrackBarComboBox
            ' 
            Me.mobjOrientationTrackBarComboBox.AllowDrag = False
            Me.mobjOrientationTrackBarComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjOrientationTrackBarComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjOrientationTrackBarComboBox.Location = New System.Drawing.Point(0, 39)
            Me.mobjOrientationTrackBarComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjOrientationTrackBarComboBox.Name = "mobjOrientationTrackBarComboBox"
            Me.mobjOrientationTrackBarComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjOrientationTrackBarComboBox.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 250.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOrientationPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjHorizontalPanel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjVerticalPanel, 3, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(580, 306)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjOrientationPanel
            ' 
            Me.mobjOrientationPanel.Controls.Add(Me.mobjOrientationTrackBarLabel)
            Me.mobjOrientationPanel.Controls.Add(Me.mobjOrientationTrackBarComboBox)
            Me.mobjOrientationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOrientationPanel.Location = New System.Drawing.Point(130, 123)
            Me.mobjOrientationPanel.Name = "mobjOrientationPanel"
            Me.mobjOrientationPanel.Size = New System.Drawing.Size(250, 60)
            Me.mobjOrientationPanel.TabIndex = 0
            ' 
            ' mobjHorizontalPanel
            ' 
            Me.mobjHorizontalPanel.Controls.Add(Me.mobjDemoTrackBar)
            Me.mobjHorizontalPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHorizontalPanel.Location = New System.Drawing.Point(130, 203)
            Me.mobjHorizontalPanel.Name = "mobjHorizontalPanel"
            Me.mobjHorizontalPanel.Size = New System.Drawing.Size(250, 40)
            Me.mobjHorizontalPanel.TabIndex = 0
            ' 
            ' mobjVerticalPanel
            ' 
            Me.mobjVerticalPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjVerticalPanel.Location = New System.Drawing.Point(400, 63)
            Me.mobjVerticalPanel.Name = "mobjVerticalPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjVerticalPanel, 5)
            Me.mobjVerticalPanel.Size = New System.Drawing.Size(50, 180)
            Me.mobjVerticalPanel.TabIndex = 0
            ' 
            ' OrientationPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(580, 306)
            Me.Text = "OrientationPage"
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjOrientationPanel.ResumeLayout(False)
            Me.mobjHorizontalPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjOrientationTrackBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjOrientationTrackBarComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjOrientationPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjHorizontalPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjVerticalPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace