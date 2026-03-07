Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeographicLocationForm
    Inherits Gizmox.WebGUI.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Visual WebGui Designer
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Visual WebGui Designer
    'It can be modified using the Visual WebGui Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mobjTimeoutNullCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
        Me.mobjMaxAgeNullCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
        Me.mobjTimeoutNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
        Me.mobjMaxAgeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
        Me.mobjRepeatCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
        Me.mobjHighAccuracyCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
        Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
        Me.mobjTimeoutLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjMaximumAgeLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjGoogleMap = New Gizmox.WebGUI.Forms.Professional.GoogleMap()
        Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
        Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
        DirectCast(Me.mobjTimeoutNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        DirectCast(Me.mobjMaxAgeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mobjGroupBox.SuspendLayout()
        Me.mobjTopPanel.SuspendLayout()
        Me.mobjBottomPanel.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' mobjTimeoutNullCheckBox
        ' 
        Me.mobjTimeoutNullCheckBox.AccessibleDescription = ""
        Me.mobjTimeoutNullCheckBox.AccessibleName = ""
        Me.mobjTimeoutNullCheckBox.AutoSize = True
        Me.mobjTimeoutNullCheckBox.Checked = True
        Me.mobjTimeoutNullCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
        Me.mobjTimeoutNullCheckBox.Location = New System.Drawing.Point(190, 124)
        Me.mobjTimeoutNullCheckBox.Name = "objTimeoutNullCheckBox"
        Me.mobjTimeoutNullCheckBox.Size = New System.Drawing.Size(43, 17)
        Me.mobjTimeoutNullCheckBox.TabIndex = 5
        Me.mobjTimeoutNullCheckBox.Text = "Null"
        ' 
        ' mobjMaxAgeNullCheckBox
        ' 
        Me.mobjMaxAgeNullCheckBox.AccessibleDescription = ""
        Me.mobjMaxAgeNullCheckBox.AccessibleName = ""
        Me.mobjMaxAgeNullCheckBox.AutoSize = True
        Me.mobjMaxAgeNullCheckBox.Checked = True
        Me.mobjMaxAgeNullCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
        Me.mobjMaxAgeNullCheckBox.Location = New System.Drawing.Point(190, 96)
        Me.mobjMaxAgeNullCheckBox.Name = "objMaxAgeNullCheckBox"
        Me.mobjMaxAgeNullCheckBox.Size = New System.Drawing.Size(43, 17)
        Me.mobjMaxAgeNullCheckBox.TabIndex = 4
        Me.mobjMaxAgeNullCheckBox.Text = "Null"
        ' 
        ' mobjTimeoutNUD
        ' 
        Me.mobjTimeoutNUD.AccessibleDescription = ""
        Me.mobjTimeoutNUD.AccessibleName = ""
        Me.mobjTimeoutNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
        Me.mobjTimeoutNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.mobjTimeoutNUD.Enabled = False
        Me.mobjTimeoutNUD.Location = New System.Drawing.Point(103, 120)
        Me.mobjTimeoutNUD.Name = "objTimeoutNUD"
        Me.mobjTimeoutNUD.Size = New System.Drawing.Size(77, 21)
        Me.mobjTimeoutNUD.TabIndex = 3
        ' 
        ' mobjMaxAgeNUD
        ' 
        Me.mobjMaxAgeNUD.AccessibleDescription = ""
        Me.mobjMaxAgeNUD.AccessibleName = ""
        Me.mobjMaxAgeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
        Me.mobjMaxAgeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.mobjMaxAgeNUD.Enabled = False
        Me.mobjMaxAgeNUD.Location = New System.Drawing.Point(103, 95)
        Me.mobjMaxAgeNUD.Name = "objMaxAgeNUD"
        Me.mobjMaxAgeNUD.Size = New System.Drawing.Size(77, 21)
        Me.mobjMaxAgeNUD.TabIndex = 2
        ' 
        ' mobjRepeatCheckBox
        ' 
        Me.mobjRepeatCheckBox.AccessibleDescription = ""
        Me.mobjRepeatCheckBox.AccessibleName = ""
        Me.mobjRepeatCheckBox.AutoSize = True
        Me.mobjRepeatCheckBox.Location = New System.Drawing.Point(19, 61)
        Me.mobjRepeatCheckBox.Name = "objRepeatCheckBox"
        Me.mobjRepeatCheckBox.Size = New System.Drawing.Size(90, 17)
        Me.mobjRepeatCheckBox.TabIndex = 1
        Me.mobjRepeatCheckBox.Text = "RepeatCheck"
        ' 
        ' mobjHighAccuracyCheckBox
        ' 
        Me.mobjHighAccuracyCheckBox.AccessibleDescription = ""
        Me.mobjHighAccuracyCheckBox.AccessibleName = ""
        Me.mobjHighAccuracyCheckBox.AutoSize = True
        Me.mobjHighAccuracyCheckBox.Location = New System.Drawing.Point(19, 30)
        Me.mobjHighAccuracyCheckBox.Name = "objHighAccuracyCheckBox"
        Me.mobjHighAccuracyCheckBox.Size = New System.Drawing.Size(123, 17)
        Me.mobjHighAccuracyCheckBox.TabIndex = 0
        Me.mobjHighAccuracyCheckBox.Text = "EnableHighAccuracy"
        ' 
        ' mobjGroupBox
        ' 
        Me.mobjGroupBox.AccessibleDescription = ""
        Me.mobjGroupBox.AccessibleName = ""
        Me.mobjGroupBox.Controls.Add(Me.mobjTimeoutLabel)
        Me.mobjGroupBox.Controls.Add(Me.mobjMaximumAgeLabel)
        Me.mobjGroupBox.Controls.Add(Me.mobjTimeoutNullCheckBox)
        Me.mobjGroupBox.Controls.Add(Me.mobjMaxAgeNullCheckBox)
        Me.mobjGroupBox.Controls.Add(Me.mobjTimeoutNUD)
        Me.mobjGroupBox.Controls.Add(Me.mobjMaxAgeNUD)
        Me.mobjGroupBox.Controls.Add(Me.mobjRepeatCheckBox)
        Me.mobjGroupBox.Controls.Add(Me.mobjHighAccuracyCheckBox)
        Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
        Me.mobjGroupBox.Location = New System.Drawing.Point(20, 20)
        Me.mobjGroupBox.Name = "objGroupBox"
        Me.mobjGroupBox.Size = New System.Drawing.Size(262, 146)
        Me.mobjGroupBox.TabIndex = 1
        Me.mobjGroupBox.TabStop = False
        Me.mobjGroupBox.Text = "GeographicLocationOptions"
        ' 
        ' mobjTimeoutLabel
        ' 
        Me.mobjTimeoutLabel.AccessibleDescription = ""
        Me.mobjTimeoutLabel.AccessibleName = ""
        Me.mobjTimeoutLabel.AutoSize = True
        Me.mobjTimeoutLabel.Location = New System.Drawing.Point(16, 120)
        Me.mobjTimeoutLabel.Name = "objTimeoutLabel"
        Me.mobjTimeoutLabel.Size = New System.Drawing.Size(35, 13)
        Me.mobjTimeoutLabel.TabIndex = 7
        Me.mobjTimeoutLabel.Text = "Timeout"
        ' 
        ' mobjMaximumAgeLabel
        ' 
        Me.mobjMaximumAgeLabel.AccessibleDescription = ""
        Me.mobjMaximumAgeLabel.AccessibleName = ""
        Me.mobjMaximumAgeLabel.AutoSize = True
        Me.mobjMaximumAgeLabel.Location = New System.Drawing.Point(16, 95)
        Me.mobjMaximumAgeLabel.Name = "objMaximumAgeLabel"
        Me.mobjMaximumAgeLabel.Size = New System.Drawing.Size(35, 13)
        Me.mobjMaximumAgeLabel.TabIndex = 6
        Me.mobjMaximumAgeLabel.Text = "MaximumAge"
        ' 
        ' mobjGoogleMap
        ' 
        Me.mobjGoogleMap.AccessibleDescription = ""
        Me.mobjGoogleMap.AccessibleName = ""
        Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjGoogleMap.Location = New System.Drawing.Point(20, 20)
        Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
        Me.mobjGoogleMap.MapZoomLevel = 15
        Me.mobjGoogleMap.Name = "objGoogleMap"
        Me.mobjGoogleMap.Size = New System.Drawing.Size(262, 240)
        Me.mobjGoogleMap.TabIndex = 0
        ' 
        ' mobjTopPanel
        ' 
        Me.mobjTopPanel.AccessibleDescription = ""
        Me.mobjTopPanel.AccessibleName = ""
        Me.mobjTopPanel.Controls.Add(Me.mobjGoogleMap)
        Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
        Me.mobjTopPanel.DockPadding.All = 20
        Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.mobjTopPanel.MaximumSize = New System.Drawing.Size(440, 280)
        Me.mobjTopPanel.Name = "objTopPanel"
        Me.mobjTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20)
        Me.mobjTopPanel.Size = New System.Drawing.Size(302, 280)
        Me.mobjTopPanel.TabIndex = 2
        ' 
        ' mobjBottomPanel
        ' 
        Me.mobjBottomPanel.AccessibleDescription = ""
        Me.mobjBottomPanel.AccessibleName = ""
        Me.mobjBottomPanel.Controls.Add(Me.mobjGroupBox)
        Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjBottomPanel.DockPadding.All = 20
        Me.mobjBottomPanel.Location = New System.Drawing.Point(0, 284)
        Me.mobjBottomPanel.Name = "objBottomPanel"
        Me.mobjBottomPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20)
        Me.mobjBottomPanel.Size = New System.Drawing.Size(302, 186)
        Me.mobjBottomPanel.TabIndex = 3
        ' 
        ' GeographicLocationForm
        ' 
        Me.Controls.Add(Me.mobjBottomPanel)
        Me.Controls.Add(Me.mobjTopPanel)
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Location = New System.Drawing.Point(0, -37)
        Me.Size = New System.Drawing.Size(302, 466)
        Me.Text = "GeographicLocationForm"
        DirectCast(Me.mobjTimeoutNUD, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.mobjMaxAgeNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mobjGroupBox.ResumeLayout(False)
        Me.mobjTopPanel.ResumeLayout(False)
        Me.mobjBottomPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Private WithEvents mobjTimeoutNullCheckBox As Gizmox.WebGUI.Forms.CheckBox
    Private WithEvents mobjMaxAgeNullCheckBox As Gizmox.WebGUI.Forms.CheckBox
    Private WithEvents mobjTimeoutNUD As Gizmox.WebGUI.Forms.NumericUpDown
    Private WithEvents mobjMaxAgeNUD As Gizmox.WebGUI.Forms.NumericUpDown
    Private WithEvents mobjRepeatCheckBox As Gizmox.WebGUI.Forms.CheckBox
    Private WithEvents mobjHighAccuracyCheckBox As Gizmox.WebGUI.Forms.CheckBox
    Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
    Private mobjTimeoutLabel As Gizmox.WebGUI.Forms.Label
    Private mobjMaximumAgeLabel As Gizmox.WebGUI.Forms.Label
    Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
    Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
    Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel

End Class