Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.GoogleMap.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MapLocationPropertyPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLonLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLatLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSetCoordinatesButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjLongitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLatitudeNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjButtonPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.mobjLabelPanel.SuspendLayout()
            Me.mobjButtonPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(192)), CInt(CByte(128))))
            Me.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGoogleMap.Location = New System.Drawing.Point(30, 30)
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
            Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722, -122.478611)
            Me.mobjGoogleMap.Name = "mobjGoogleMap"
            Me.mobjGoogleMap.Size = New System.Drawing.Size(532, 195)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(132, 13)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Enter location coordinates"
            ' 
            ' mobjLonLabel
            ' 
            Me.mobjLonLabel.AutoSize = True
            Me.mobjLonLabel.Location = New System.Drawing.Point(0, 37)
            Me.mobjLonLabel.Name = "mobjLonLabel"
            Me.mobjLonLabel.Size = New System.Drawing.Size(54, 13)
            Me.mobjLonLabel.TabIndex = 2
            Me.mobjLonLabel.Text = "Longitude"
            ' 
            ' mobjLatLabel
            ' 
            Me.mobjLatLabel.AutoSize = True
            Me.mobjLatLabel.Location = New System.Drawing.Point(0, 74)
            Me.mobjLatLabel.Name = "mobjLatLabel"
            Me.mobjLatLabel.Size = New System.Drawing.Size(46, 13)
            Me.mobjLatLabel.TabIndex = 3
            Me.mobjLatLabel.Text = "Latitude"
            ' 
            ' mobjSetCoordinatesButton
            ' 
            Me.mobjSetCoordinatesButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSetCoordinatesButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjSetCoordinatesButton.Name = "mobjSetCoordinatesButton"
            Me.mobjSetCoordinatesButton.Size = New System.Drawing.Size(532, 39)
            Me.mobjSetCoordinatesButton.TabIndex = 6
            Me.mobjSetCoordinatesButton.Text = "Set Coordinates"
            Me.mobjSetCoordinatesButton.UseVisualStyleBackColor = True
            ' 
            ' mobjErrorProvider
            ' 
            Me.mobjErrorProvider.BlinkRate = 3
            ' 
            ' mobjLongitudeNUD
            ' 
            Me.mobjLongitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjLongitudeNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjLongitudeNUD.DecimalPlaces = 6
            Me.mobjLongitudeNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLongitudeNUD.Location = New System.Drawing.Point(266, 37)
            Me.mobjLongitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjLongitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
            Me.mobjLongitudeNUD.Name = "mobjLongitudeNUD"
            Me.mobjLongitudeNUD.Size = New System.Drawing.Size(266, 21)
            Me.mobjLongitudeNUD.TabIndex = 7
            ' 
            ' mobjLatitudeNUD
            ' 
            Me.mobjLatitudeNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjLatitudeNUD.CurrentValue = New Decimal(New Integer() {38, 0, 0, 0})
            Me.mobjLatitudeNUD.DecimalPlaces = 6
            Me.mobjLatitudeNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLatitudeNUD.Location = New System.Drawing.Point(266, 74)
            Me.mobjLatitudeNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjLatitudeNUD.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
            Me.mobjLatitudeNUD.Name = "mobjLatitudeNUD"
            Me.mobjLatitudeNUD.Size = New System.Drawing.Size(266, 21)
            Me.mobjLatitudeNUD.TabIndex = 8
            Me.mobjLatitudeNUD.Value = New Decimal(New Integer() {38, 0, 0, 0})
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.ColumnCount = 3
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjAdditionalLayoutPanel, 1, 3)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 5
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 150.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(592, 425)
            Me.mobjCommonLayoutPanel.TabIndex = 9
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.ColumnCount = 2
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLabelPanel, 0, 0)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjButtonPanel, 0, 3)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLonLabel, 0, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLongitudeNUD, 1, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLatitudeNUD, 1, 2)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLatLabel, 0, 2)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(30, 245)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 4
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(532, 150)
            Me.mobjAdditionalLayoutPanel.TabIndex = 10
            ' 
            ' mobjLabelPanel
            ' 
            Me.mobjAdditionalLayoutPanel.SetColumnSpan(Me.mobjLabelPanel, 2)
            Me.mobjLabelPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabelPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabelPanel.Name = "mobjLabelPanel"
            Me.mobjLabelPanel.Size = New System.Drawing.Size(532, 37)
            Me.mobjLabelPanel.TabIndex = 0
            ' 
            ' mobjButtonPanel
            ' 
            Me.mobjAdditionalLayoutPanel.SetColumnSpan(Me.mobjButtonPanel, 2)
            Me.mobjButtonPanel.Controls.Add(Me.mobjSetCoordinatesButton)
            Me.mobjButtonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButtonPanel.Location = New System.Drawing.Point(0, 111)
            Me.mobjButtonPanel.Name = "mobjButtonPanel"
            Me.mobjButtonPanel.Size = New System.Drawing.Size(532, 39)
            Me.mobjButtonPanel.TabIndex = 0
            ' 
            ' MapLocationPropertyPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.Size = New System.Drawing.Size(592, 425)
            Me.Text = "MapLocationPropertyPage"
            DirectCast(Me.mobjLongitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjLatitudeNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.mobjLabelPanel.ResumeLayout(False)
            Me.mobjButtonPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLonLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLatLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjSetCoordinatesButton As Gizmox.WebGUI.Forms.Button
        Private mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private mobjLongitudeNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjLatitudeNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjLabelPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjButtonPanel As Gizmox.WebGUI.Forms.Panel

    End Class

End Namespace