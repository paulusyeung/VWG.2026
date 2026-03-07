Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.GoogleMap.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MapControlTypePropertyPage
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
            Me.mobjFirstLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMapControlTypeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjSecondLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMapZoomControlTypeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjBottomLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.mobjTopLayoutPanel.SuspendLayout()
            Me.mobjBottomLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(192)), CInt(CByte(128))))
            Me.mobjGoogleMap.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGoogleMap.Location = New System.Drawing.Point(30, 30)
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, True, True, True)
            Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722, -122.478611)
            Me.mobjGoogleMap.Name = "mobjGoogleMap"
            Me.mobjGoogleMap.Size = New System.Drawing.Size(523, 324)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjFirstLabel
            ' 
            Me.mobjFirstLabel.AutoSize = True
            Me.mobjFirstLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjFirstLabel.Location = New System.Drawing.Point(0, 17)
            Me.mobjFirstLabel.Name = "mobjFirstLabel"
            Me.mobjFirstLabel.Size = New System.Drawing.Size(523, 13)
            Me.mobjFirstLabel.TabIndex = 1
            Me.mobjFirstLabel.Text = "Please select MapControlType"
            ' 
            ' mobjMapControlTypeComboBox
            ' 
            Me.mobjMapControlTypeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjMapControlTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjMapControlTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjMapControlTypeComboBox.FormattingEnabled = True
            Me.mobjMapControlTypeComboBox.Items.AddRange(New Object() {"Default", "DropdownMenu ", "HorizontalBar"})
            Me.mobjMapControlTypeComboBox.Location = New System.Drawing.Point(0, 60)
            Me.mobjMapControlTypeComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMapControlTypeComboBox.Name = "mobjMapControlTypeComboBox"
            Me.mobjMapControlTypeComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjMapControlTypeComboBox.TabIndex = 2
            Me.mobjMapControlTypeComboBox.Text = "Default"
            ' 
            ' mobjSecondLabel
            ' 
            Me.mobjSecondLabel.AutoSize = True
            Me.mobjSecondLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSecondLabel.Location = New System.Drawing.Point(0, 17)
            Me.mobjSecondLabel.Name = "mobjSecondLabel"
            Me.mobjSecondLabel.Size = New System.Drawing.Size(523, 13)
            Me.mobjSecondLabel.TabIndex = 3
            Me.mobjSecondLabel.Text = "Please select MapZoomControlType"
            ' 
            ' mobjMapZoomControlTypeComboBox
            ' 
            Me.mobjMapZoomControlTypeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjMapZoomControlTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjMapZoomControlTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjMapZoomControlTypeComboBox.FormattingEnabled = True
            Me.mobjMapZoomControlTypeComboBox.Items.AddRange(New Object() {"Default", "Large", "Small"})
            Me.mobjMapZoomControlTypeComboBox.Location = New System.Drawing.Point(0, 39)
            Me.mobjMapZoomControlTypeComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMapZoomControlTypeComboBox.Name = "mobjMapZoomControlTypeComboBox"
            Me.mobjMapZoomControlTypeComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjMapZoomControlTypeComboBox.TabIndex = 4
            Me.mobjMapZoomControlTypeComboBox.Text = "Default"
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.ColumnCount = 3
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjTopLayoutPanel, 1, 2)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjBottomLayoutPanel, 1, 3)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 5
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(583, 504)
            Me.mobjCommonLayoutPanel.TabIndex = 5
            ' 
            ' mobjTopLayoutPanel
            ' 
            Me.mobjTopLayoutPanel.ColumnCount = 1
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjFirstLabel, 0, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjMapControlTypeComboBox, 0, 1)
            Me.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopLayoutPanel.Location = New System.Drawing.Point(30, 354)
            Me.mobjTopLayoutPanel.Name = "mobjTopLayoutPanel"
            Me.mobjTopLayoutPanel.RowCount = 2
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.Size = New System.Drawing.Size(523, 60)
            Me.mobjTopLayoutPanel.TabIndex = 0
            ' 
            ' mobjBottomLayoutPanel
            ' 
            Me.mobjBottomLayoutPanel.ColumnCount = 1
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjSecondLabel, 0, 0)
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjMapZoomControlTypeComboBox, 0, 1)
            Me.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomLayoutPanel.Location = New System.Drawing.Point(30, 414)
            Me.mobjBottomLayoutPanel.Name = "mobjBottomLayoutPanel"
            Me.mobjBottomLayoutPanel.RowCount = 2
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.Size = New System.Drawing.Size(523, 60)
            Me.mobjBottomLayoutPanel.TabIndex = 0
            ' 
            ' MapControlTypePropertyPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.Location = New System.Drawing.Point(0, -194)
            Me.Size = New System.Drawing.Size(583, 504)
            Me.Text = "MapControlTypePropertyPage"
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.mobjTopLayoutPanel.ResumeLayout(False)
            Me.mobjBottomLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private mobjFirstLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMapControlTypeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjSecondLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMapZoomControlTypeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjBottomLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace