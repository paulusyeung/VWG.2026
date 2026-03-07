Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.GoogleMap.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OverLaysPropertyPage
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
            Me.mobjGoogleMap = New Gizmox.WebGUI.Forms.Professional.GoogleMap()
            Me.mobjOverlaysLabel = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjMapLocationGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjAddressLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLocationNameAddressTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLocationNameAddressRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjSetMapLocationButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCoordinatesRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLatitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLatitudeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLongitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLongitudeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMapOverlaysGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjRemoveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjEditButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjMapLocationGroupBox.SuspendLayout()
            DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjMapOverlaysGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(192)), CInt(CByte(128))))
            Me.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjGoogleMap.Location = New System.Drawing.Point(12, 11)
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
            Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722, -122.478611)
            Me.mobjGoogleMap.MapZoomControlType = Gizmox.WebGUI.Forms.Google.GoogleMapZoomControlType.Large
            Me.mobjGoogleMap.Name = "googleMap1"
            Me.mobjGoogleMap.Size = New System.Drawing.Size(630, 480)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjOverlaysLabel
            ' 
            Me.mobjOverlaysLabel.DisplayMember = "WindowInfoContent"
            Me.mobjOverlaysLabel.Location = New System.Drawing.Point(10, 17)
            Me.mobjOverlaysLabel.Name = "lbOverlays"
            Me.mobjOverlaysLabel.Size = New System.Drawing.Size(180, 433)
            Me.mobjOverlaysLabel.TabIndex = 1
            Me.mobjOverlaysLabel.ValueMember = "WindowInfoContent"
            ' 
            ' mobjErrorProvider
            ' 
            Me.mobjErrorProvider.BlinkRate = 3
            ' 
            ' mobjMapLocationGroupBox
            ' 
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjAddressLabel)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLocationNameAddressTextBox)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLocationNameAddressRadioButton)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjSetMapLocationButton)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjCoordinatesRadioButton)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLatitudeNUD)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLatitudeLabel)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLongitudeNUD)
            Me.mobjMapLocationGroupBox.Controls.Add(Me.mobjLongitudeLabel)
            Me.mobjMapLocationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjMapLocationGroupBox.Location = New System.Drawing.Point(12, 491)
            Me.mobjMapLocationGroupBox.Name = "gtbMapLocation"
            Me.mobjMapLocationGroupBox.Size = New System.Drawing.Size(630, 125)
            Me.mobjMapLocationGroupBox.TabIndex = 5
            Me.mobjMapLocationGroupBox.TabStop = False
            Me.mobjMapLocationGroupBox.Text = "Map Location"
            ' 
            ' mobjAddressLabel
            ' 
            Me.mobjAddressLabel.AutoSize = True
            Me.mobjAddressLabel.Location = New System.Drawing.Point(30, 98)
            Me.mobjAddressLabel.Name = "mobjAddressLabel"
            Me.mobjAddressLabel.Size = New System.Drawing.Size(46, 13)
            Me.mobjAddressLabel.TabIndex = 3
            Me.mobjAddressLabel.Text = "Name / Address:"
            ' 
            ' mobjLocationNameAddressTextBox
            ' 
            Me.mobjLocationNameAddressTextBox.AllowDrag = False
            Me.mobjLocationNameAddressTextBox.Enabled = False
            Me.mobjLocationNameAddressTextBox.Location = New System.Drawing.Point(115, 95)
            Me.mobjLocationNameAddressTextBox.Name = "mobjLocationNameAddressTextBox"
            Me.mobjLocationNameAddressTextBox.Size = New System.Drawing.Size(316, 20)
            Me.mobjLocationNameAddressTextBox.TabIndex = 10
            ' 
            ' mobjLocationNameAddressRadioButton
            ' 
            Me.mobjLocationNameAddressRadioButton.AutoSize = True
            Me.mobjLocationNameAddressRadioButton.Location = New System.Drawing.Point(13, 69)
            Me.mobjLocationNameAddressRadioButton.Name = "mobjLocationNameAddressRadioButton"
            Me.mobjLocationNameAddressRadioButton.Size = New System.Drawing.Size(250, 17)
            Me.mobjLocationNameAddressRadioButton.TabIndex = 9
            Me.mobjLocationNameAddressRadioButton.Text = "Location name / address"
            ' 
            ' mobjSetMapLocationButton
            ' 
            Me.mobjSetMapLocationButton.Location = New System.Drawing.Point(512, 96)
            Me.mobjSetMapLocationButton.Name = "btnSetMapLocation"
            Me.mobjSetMapLocationButton.Size = New System.Drawing.Size(112, 23)
            Me.mobjSetMapLocationButton.TabIndex = 3
            Me.mobjSetMapLocationButton.Text = "Set Map Location"
            ' 
            ' mobjCoordinatesRadioButton
            ' 
            Me.mobjCoordinatesRadioButton.AutoSize = True
            Me.mobjCoordinatesRadioButton.Checked = True
            Me.mobjCoordinatesRadioButton.Location = New System.Drawing.Point(13, 15)
            Me.mobjCoordinatesRadioButton.Name = "mobjCoordinatesRadioButton"
            Me.mobjCoordinatesRadioButton.Size = New System.Drawing.Size(83, 17)
            Me.mobjCoordinatesRadioButton.TabIndex = 9
            Me.mobjCoordinatesRadioButton.Text = "Coordinates"
            ' 
            ' mobjLatitudeNUD
            ' 
            Me.mobjLatitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjLatitudeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjLatitudeNUD.DecimalPlaces = 6
            Me.mobjLatitudeNUD.Location = New System.Drawing.Point(331, 42)
            Me.mobjLatitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjLatitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
            Me.mobjLatitudeNUD.Name = "nudLatitude"
            Me.mobjLatitudeNUD.Size = New System.Drawing.Size(100, 21)
            Me.mobjLatitudeNUD.TabIndex = 8
            ' 
            ' mobjLatitudeLabel
            ' 
            Me.mobjLatitudeLabel.AutoSize = True
            Me.mobjLatitudeLabel.Location = New System.Drawing.Point(262, 44)
            Me.mobjLatitudeLabel.Name = "mobjLatitudeLabel"
            Me.mobjLatitudeLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLatitudeLabel.TabIndex = 3
            Me.mobjLatitudeLabel.Text = "Latitude:"
            ' 
            ' mobjLongitudeNUD
            ' 
            Me.mobjLongitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjLongitudeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjLongitudeNUD.DecimalPlaces = 6
            Me.mobjLongitudeNUD.Location = New System.Drawing.Point(115, 42)
            Me.mobjLongitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjLongitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
            Me.mobjLongitudeNUD.Name = "mobjLongitudeNUD"
            Me.mobjLongitudeNUD.Size = New System.Drawing.Size(100, 21)
            Me.mobjLongitudeNUD.TabIndex = 7
            ' 
            ' mobjLongitudeLabel
            ' 
            Me.mobjLongitudeLabel.AutoSize = True
            Me.mobjLongitudeLabel.Location = New System.Drawing.Point(30, 44)
            Me.mobjLongitudeLabel.Name = "mobjLongitudeLabel"
            Me.mobjLongitudeLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLongitudeLabel.TabIndex = 2
            Me.mobjLongitudeLabel.Text = "Longitude:"
            ' 
            ' mobjMapOverlaysGroupBox
            ' 
            Me.mobjMapOverlaysGroupBox.Controls.Add(Me.mobjRemoveButton)
            Me.mobjMapOverlaysGroupBox.Controls.Add(Me.mobjEditButton)
            Me.mobjMapOverlaysGroupBox.Controls.Add(Me.mobjAddButton)
            Me.mobjMapOverlaysGroupBox.Controls.Add(Me.mobjOverlaysLabel)
            Me.mobjMapOverlaysGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjMapOverlaysGroupBox.Location = New System.Drawing.Point(650, 11)
            Me.mobjMapOverlaysGroupBox.Name = "mobjMapOverlaysGroupBox"
            Me.mobjMapOverlaysGroupBox.Size = New System.Drawing.Size(200, 480)
            Me.mobjMapOverlaysGroupBox.TabIndex = 6
            Me.mobjMapOverlaysGroupBox.TabStop = False
            Me.mobjMapOverlaysGroupBox.Text = "Map Overlays"
            ' 
            ' mobjRemoveButton
            ' 
            Me.mobjRemoveButton.Location = New System.Drawing.Point(130, 454)
            Me.mobjRemoveButton.Name = "mobjRemoveButton"
            Me.mobjRemoveButton.Size = New System.Drawing.Size(60, 23)
            Me.mobjRemoveButton.TabIndex = 4
            Me.mobjRemoveButton.Text = "Remove"
            Me.mobjRemoveButton.UseVisualStyleBackColor = True
            ' 
            ' mobjEditButton
            ' 
            Me.mobjEditButton.Location = New System.Drawing.Point(70, 454)
            Me.mobjEditButton.Name = "mobjEditButton"
            Me.mobjEditButton.Size = New System.Drawing.Size(60, 23)
            Me.mobjEditButton.TabIndex = 3
            Me.mobjEditButton.Text = "Edit"
            Me.mobjEditButton.UseVisualStyleBackColor = True
            ' 
            ' mobjAddButton
            ' 
            Me.mobjAddButton.Location = New System.Drawing.Point(10, 454)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(60, 23)
            Me.mobjAddButton.TabIndex = 2
            Me.mobjAddButton.Text = "Add"
            Me.mobjAddButton.UseVisualStyleBackColor = True
            ' 
            ' OverLaysPropertyPage
            ' 
            Me.Controls.Add(Me.mobjMapOverlaysGroupBox)
            Me.Controls.Add(Me.mobjMapLocationGroupBox)
            Me.Controls.Add(Me.mobjGoogleMap)
            Me.Size = New System.Drawing.Size(715, 650)
            Me.Text = "OverLaysPropertyPage"
            Me.mobjMapLocationGroupBox.ResumeLayout(False)
            DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjMapOverlaysGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private mobjOverlaysLabel As Gizmox.WebGUI.Forms.ListBox
        Private mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private mobjMapLocationGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjSetMapLocationButton As Gizmox.WebGUI.Forms.Button
        Private mobjLatitudeNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLatitudeLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLongitudeNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLongitudeLabel As Gizmox.WebGUI.Forms.Label
        Private mobjMapOverlaysGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjRemoveButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjEditButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjCoordinatesRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjLocationNameAddressRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjAddressLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLocationNameAddressTextBox As Gizmox.WebGUI.Forms.TextBox

    End Class

End Namespace