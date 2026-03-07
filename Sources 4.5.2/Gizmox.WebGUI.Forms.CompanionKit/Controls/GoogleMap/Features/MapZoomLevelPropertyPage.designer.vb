Namespace CompanionKit.Controls.GoogleMap.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MapZoomLevelPropertyPage
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
            Me.mobjGoogleMap = New Gizmox.WebGUI.Forms.Professional.GoogleMap()
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGoogleMap.Location = New System.Drawing.Point(30, 30)
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
            Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722, -122.478611)
            Me.mobjGoogleMap.Name = "mobjGoogleMap"
            Me.mobjGoogleMap.ShowMapZoomControl = False
            Me.mobjGoogleMap.Size = New System.Drawing.Size(676, 242)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjNumericUpDown
            ' 
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(30, 352)
            Me.mobjNumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.mobjNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNumericUpDown.Name = "mobjNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjNumericUpDown.TabIndex = 1
            Me.mobjNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' mobjCheckBox
            ' 
            Me.mobjCheckBox.AutoSize = True
            Me.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjCheckBox.Location = New System.Drawing.Point(30, 375)
            Me.mobjCheckBox.MaximumSize = New System.Drawing.Size(250, 0)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(250, 17)
            Me.mobjCheckBox.TabIndex = 2
            Me.mobjCheckBox.Text = "MapDoubleClickZooms"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjLabel.Location = New System.Drawing.Point(30, 299)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(676, 13)
            Me.mobjLabel.TabIndex = 3
            Me.mobjLabel.Text = "ZoomLevel:"
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.ColumnCount = 3
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjLabel, 1, 2)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjCheckBox, 1, 4)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjNumericUpDown, 1, 3)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 6
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(736, 422)
            Me.mobjCommonLayoutPanel.TabIndex = 4
            ' 
            ' MapZoomLevelPropertyPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.Size = New System.Drawing.Size(736, 422)
            Me.Text = "MapZoomLevelPropertyPage"
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private WithEvents mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace