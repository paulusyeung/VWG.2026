Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewOverlayForm
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
        Me.components = New System.ComponentModel.Container()
        Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
        Me.mobjDescriptionTextBox = New Gizmox.WebGUI.Forms.TextBox()
        Me.mobjLongitudeLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjLatitudeLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjLongitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
        Me.mobjLatitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
        Me.mobjOverlayLocationGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
        Me.mobjLocationNameAddressTextBox = New Gizmox.WebGUI.Forms.TextBox()
        Me.mobjAddressLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjLocationNameAddressRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
        Me.mobjCoordinatesRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
        Me.mobjOverlayDescriptionGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
        Me.mobjCancelButton = New Gizmox.WebGUI.Forms.Button()
        Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
        DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mobjOverlayLocationGroupBox.SuspendLayout()
        Me.mobjOverlayDescriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' mobjAddButton
        ' 
        Me.mobjAddButton.Location = New System.Drawing.Point(7, 272)
        Me.mobjAddButton.Name = "mobjAddButton"
        Me.mobjAddButton.Size = New System.Drawing.Size(100, 23)
        Me.mobjAddButton.TabIndex = 3
        Me.mobjAddButton.Text = "Add Overlay"
        Me.mobjAddButton.UseVisualStyleBackColor = True
        ' 
        ' mobjDescriptionTextBox
        ' 
        Me.mobjDescriptionTextBox.AllowDrag = False
        Me.mobjDescriptionTextBox.Location = New System.Drawing.Point(6, 20)
        Me.mobjDescriptionTextBox.Multiline = True
        Me.mobjDescriptionTextBox.Name = "mobjDescriptionTextBox"
        Me.mobjDescriptionTextBox.Size = New System.Drawing.Size(254, 74)
        Me.mobjDescriptionTextBox.TabIndex = 9
        ' 
        ' mobjLongitudeLabel
        ' 
        Me.mobjLongitudeLabel.AutoSize = True
        Me.mobjLongitudeLabel.Location = New System.Drawing.Point(3, 47)
        Me.mobjLongitudeLabel.Name = "mobjLongitudeLabel"
        Me.mobjLongitudeLabel.Size = New System.Drawing.Size(54, 13)
        Me.mobjLongitudeLabel.TabIndex = 2
        Me.mobjLongitudeLabel.Text = "Longitude"
        ' 
        ' mobjLatitudeLabel
        ' 
        Me.mobjLatitudeLabel.AutoSize = True
        Me.mobjLatitudeLabel.Location = New System.Drawing.Point(3, 73)
        Me.mobjLatitudeLabel.Name = "mobjLatitudeLabel"
        Me.mobjLatitudeLabel.Size = New System.Drawing.Size(46, 13)
        Me.mobjLatitudeLabel.TabIndex = 3
        Me.mobjLatitudeLabel.Text = "Latitude"
        ' 
        ' mobjLongitudeNUD
        ' 
        Me.mobjLongitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
        Me.mobjLongitudeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.mobjLongitudeNUD.DecimalPlaces = 6
        Me.mobjLongitudeNUD.Location = New System.Drawing.Point(65, 45)
        Me.mobjLongitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.mobjLongitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.mobjLongitudeNUD.Name = "mobjLongitudeNUD"
        Me.mobjLongitudeNUD.Size = New System.Drawing.Size(100, 21)
        Me.mobjLongitudeNUD.TabIndex = 7
        ' 
        ' mobjLatitudeNUD
        ' 
        Me.mobjLatitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
        Me.mobjLatitudeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.mobjLatitudeNUD.DecimalPlaces = 6
        Me.mobjLatitudeNUD.Location = New System.Drawing.Point(65, 71)
        Me.mobjLatitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.mobjLatitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.mobjLatitudeNUD.Name = "mobjLatitudeNUD"
        Me.mobjLatitudeNUD.Size = New System.Drawing.Size(100, 21)
        Me.mobjLatitudeNUD.TabIndex = 8
        ' 
        ' mobjOverlayLocationGroupBox
        ' 
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLocationNameAddressTextBox)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjAddressLabel)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLocationNameAddressRadioButton)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjCoordinatesRadioButton)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLongitudeLabel)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLatitudeLabel)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLongitudeNUD)
        Me.mobjOverlayLocationGroupBox.Controls.Add(Me.mobjLatitudeNUD)
        Me.mobjOverlayLocationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
        Me.mobjOverlayLocationGroupBox.Location = New System.Drawing.Point(7, 9)
        Me.mobjOverlayLocationGroupBox.Name = "mobjOverlayLocationGroupBox"
        Me.mobjOverlayLocationGroupBox.Size = New System.Drawing.Size(266, 153)
        Me.mobjOverlayLocationGroupBox.TabIndex = 4
        Me.mobjOverlayLocationGroupBox.TabStop = False
        Me.mobjOverlayLocationGroupBox.Text = "Overlay location"
        ' 
        ' mobjLocationNameAddressTextBox
        ' 
        Me.mobjLocationNameAddressTextBox.AllowDrag = False
        Me.mobjLocationNameAddressTextBox.Enabled = False
        Me.mobjLocationNameAddressTextBox.Location = New System.Drawing.Point(99, 124)
        Me.mobjLocationNameAddressTextBox.Name = "mobjLocationNameAddressTextBox"
        Me.mobjLocationNameAddressTextBox.Size = New System.Drawing.Size(161, 20)
        Me.mobjLocationNameAddressTextBox.TabIndex = 10
        ' 
        ' mobjAddressLabel
        ' 
        Me.mobjAddressLabel.AutoSize = True
        Me.mobjAddressLabel.Location = New System.Drawing.Point(3, 127)
        Me.mobjAddressLabel.Name = "mobjAddressLabel"
        Me.mobjAddressLabel.Size = New System.Drawing.Size(46, 13)
        Me.mobjAddressLabel.TabIndex = 3
        Me.mobjAddressLabel.Text = "Name / Address"
        ' 
        ' mobjLocationNameAddressRadioButton
        ' 
        Me.mobjLocationNameAddressRadioButton.AutoSize = True
        Me.mobjLocationNameAddressRadioButton.Location = New System.Drawing.Point(3, 100)
        Me.mobjLocationNameAddressRadioButton.Name = "mobjLocationNameAddressRadioButton"
        Me.mobjLocationNameAddressRadioButton.Size = New System.Drawing.Size(250, 17)
        Me.mobjLocationNameAddressRadioButton.TabIndex = 9
        Me.mobjLocationNameAddressRadioButton.Text = "Location name / address"
        ' 
        ' mobjCoordinatesRadioButton
        ' 
        Me.mobjCoordinatesRadioButton.AutoSize = True
        Me.mobjCoordinatesRadioButton.Checked = True
        Me.mobjCoordinatesRadioButton.Location = New System.Drawing.Point(3, 19)
        Me.mobjCoordinatesRadioButton.Name = "mobjCoordinatesRadioButton"
        Me.mobjCoordinatesRadioButton.Size = New System.Drawing.Size(83, 17)
        Me.mobjCoordinatesRadioButton.TabIndex = 9
        Me.mobjCoordinatesRadioButton.Text = "Coordinates"
        Me.mobjCoordinatesRadioButton.UseVisualStyleBackColor = True
        ' 
        ' mobjOverlayDescriptionGroupBox
        ' 
        Me.mobjOverlayDescriptionGroupBox.Controls.Add(Me.mobjDescriptionTextBox)
        Me.mobjOverlayDescriptionGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
        Me.mobjOverlayDescriptionGroupBox.Location = New System.Drawing.Point(7, 168)
        Me.mobjOverlayDescriptionGroupBox.Name = "mobjOverlayDescriptionGroupBox"
        Me.mobjOverlayDescriptionGroupBox.Size = New System.Drawing.Size(266, 100)
        Me.mobjOverlayDescriptionGroupBox.TabIndex = 10
        Me.mobjOverlayDescriptionGroupBox.TabStop = False
        Me.mobjOverlayDescriptionGroupBox.Text = "Overlay description"
        ' 
        ' mobjCancelButton
        ' 
        Me.mobjCancelButton.Location = New System.Drawing.Point(173, 272)
        Me.mobjCancelButton.Name = "mobjCancelButton"
        Me.mobjCancelButton.Size = New System.Drawing.Size(100, 23)
        Me.mobjCancelButton.TabIndex = 3
        Me.mobjCancelButton.Text = "Cancel"
        ' 
        ' mobjErrorProvider
        ' 
        Me.mobjErrorProvider.BlinkRate = 3
        ' 
        ' NewOverlayForm
        ' 
        Me.Controls.Add(Me.mobjCancelButton)
        Me.Controls.Add(Me.mobjOverlayDescriptionGroupBox)
        Me.Controls.Add(Me.mobjOverlayLocationGroupBox)
        Me.Controls.Add(Me.mobjAddButton)
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Size = New System.Drawing.Size(280, 300)
        Me.Text = "NewOverlayForm"
        DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mobjOverlayLocationGroupBox.ResumeLayout(False)
        Me.mobjOverlayDescriptionGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents mobjAddButton As Button
    Private mobjDescriptionTextBox As TextBox
    Private mobjLongitudeLabel As Label
    Private mobjLatitudeLabel As Label
    Private WithEvents mobjLongitudeNUD As NumericUpDown
    Private WithEvents mobjLatitudeNUD As NumericUpDown
    Private mobjOverlayLocationGroupBox As GroupBox
    Private mobjLocationNameAddressTextBox As TextBox
    Private mobjAddressLabel As Label
    Private WithEvents mobjLocationNameAddressRadioButton As RadioButton
    Private WithEvents mobjCoordinatesRadioButton As RadioButton
    Private mobjOverlayDescriptionGroupBox As GroupBox
    Private WithEvents mobjCancelButton As Button
    Private WithEvents mobjErrorProvider As ErrorProvider

End Class