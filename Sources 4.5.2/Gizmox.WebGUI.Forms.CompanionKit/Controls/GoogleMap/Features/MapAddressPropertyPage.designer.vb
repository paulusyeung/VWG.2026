Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.GoogleMap.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MapAddressPropertyPage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddressTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSetAddressButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondaryLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjContainerPanel.SuspendLayout()
            Me.mobjSecondaryLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(192)), CInt(CByte(128))))
            Me.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGoogleMap.Location = New System.Drawing.Point(30, 30)
            Me.mobjGoogleMap.MapAddress = "golden gate bridge"
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
            Me.mobjGoogleMap.Name = "mobjGoogleMap"
            Me.mobjGoogleMap.Size = New System.Drawing.Size(412, 230)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.mobjLabel.Location = New System.Drawing.Point(0, 20)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(168, 30)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Address"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjAddressTextBox
            ' 
            Me.mobjAddressTextBox.AllowDrag = False
            Me.mobjAddressTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjAddressTextBox.Location = New System.Drawing.Point(171, 17)
            Me.mobjAddressTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjAddressTextBox.Name = "mobjAddressTextBox"
            Me.mobjAddressTextBox.Size = New System.Drawing.Size(238, 30)
            Me.mobjAddressTextBox.TabIndex = 2
            Me.mobjAddressTextBox.Text = "golden gate bridge"
            ' 
            ' mobjSetAddressButton
            ' 
            Me.mobjSetAddressButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSetAddressButton.Location = New System.Drawing.Point(30, 320)
            Me.mobjSetAddressButton.Name = "mobjSetAddressButton"
            Me.mobjSetAddressButton.Size = New System.Drawing.Size(412, 50)
            Me.mobjSetAddressButton.TabIndex = 3
            Me.mobjSetAddressButton.Text = "Set Address"
            Me.mobjSetAddressButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetAddressButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerPanel, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(472, 400)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.Controls.Add(Me.mobjSecondaryLayoutPanel)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.Location = New System.Drawing.Point(30, 260)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Size = New System.Drawing.Size(412, 50)
            Me.mobjContainerPanel.TabIndex = 0
            ' 
            ' mobjSecondaryLayoutPanel
            ' 
            Me.mobjSecondaryLayoutPanel.ColumnCount = 2
            Me.mobjSecondaryLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.8F))
            Me.mobjSecondaryLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 59.2F))
            Me.mobjSecondaryLayoutPanel.Controls.Add(Me.mobjAddressTextBox, 1, 0)
            Me.mobjSecondaryLayoutPanel.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjSecondaryLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondaryLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSecondaryLayoutPanel.Name = "mobjSecondaryLayoutPanel"
            Me.mobjSecondaryLayoutPanel.RowCount = 1
            Me.mobjSecondaryLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjSecondaryLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjSecondaryLayoutPanel.Size = New System.Drawing.Size(412, 50)
            Me.mobjSecondaryLayoutPanel.TabIndex = 0
            ' 
            ' MapAddressPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Location = New System.Drawing.Point(0, -51)
            Me.Size = New System.Drawing.Size(472, 400)
            Me.Text = "MapAddressPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.mobjSecondaryLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjAddressTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjSetAddressButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondaryLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


    End Class

End Namespace