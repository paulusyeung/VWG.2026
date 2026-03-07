Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.GoogleMap.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DraggingEnabledPropertyPage
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
            Me.mobjAllowDraggingCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
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
            Me.mobjGoogleMap.Size = New System.Drawing.Size(341, 246)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjAllowDraggingCheckBox
            ' 
            Me.mobjAllowDraggingCheckBox.AutoSize = True
            Me.mobjAllowDraggingCheckBox.Checked = True
            Me.mobjAllowDraggingCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjAllowDraggingCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjAllowDraggingCheckBox.Location = New System.Drawing.Point(30, 289)
            Me.mobjAllowDraggingCheckBox.Name = "mobjAllowDraggingCheckBox"
            Me.mobjAllowDraggingCheckBox.Size = New System.Drawing.Size(341, 17)
            Me.mobjAllowDraggingCheckBox.TabIndex = 2
            Me.mobjAllowDraggingCheckBox.Text = "Allow dragging"
            Me.mobjAllowDraggingCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowDraggingCheckBox, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(401, 336)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' DraggingEnabledPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(401, 336)
            Me.Size = New System.Drawing.Size(401, 336)
            Me.Text = "DraggingEnabledPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private WithEvents mobjAllowDraggingCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace