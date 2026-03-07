Namespace CompanionKit.Controls.TrackBar.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TickStylePage
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
            Me.mobjTickStyleLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTickStyleComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTrackBar
            ' 
            Me.mobjDemoTrackBar.AllowDrag = False
            Me.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTrackBar.Location = New System.Drawing.Point(91, 106)
            Me.mobjDemoTrackBar.Maximum = 100
            Me.mobjDemoTrackBar.Name = "mobjDemoTrackBar"
            Me.mobjDemoTrackBar.Size = New System.Drawing.Size(424, 40)
            Me.mobjDemoTrackBar.TabIndex = 0
            Me.mobjDemoTrackBar.TickFrequency = 5
            ' 
            ' mobjTickStyleLabel
            ' 
            Me.mobjTickStyleLabel.AutoSize = True
            Me.mobjTickStyleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTickStyleLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTickStyleLabel.Name = "mobjTickStyleLabel"
            Me.mobjTickStyleLabel.Size = New System.Drawing.Size(126, 13)
            Me.mobjTickStyleLabel.TabIndex = 2
            Me.mobjTickStyleLabel.Text = "TickStyle of the TrackBar"
            ' 
            ' mobjTickStyleComboBox
            ' 
            Me.mobjTickStyleComboBox.AllowDrag = False
            Me.mobjTickStyleComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjTickStyleComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjTickStyleComboBox.Location = New System.Drawing.Point(0, 39)
            Me.mobjTickStyleComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTickStyleComboBox.Name = "mobjTickStyleComboBox"
            Me.mobjTickStyleComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjTickStyleComboBox.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoTrackBar, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(607, 172)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjTickStyleLabel)
            Me.mobjPanel.Controls.Add(Me.mobjTickStyleComboBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(91, 26)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(424, 60)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' TickStylePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(607, 172)
            Me.Text = "TickStylePage"
            DirectCast(Me.mobjDemoTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjTickStyleLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTickStyleComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
