Namespace CompanionKit.Controls.GoogleMap.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MapLayersCollectionPage
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
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGoogleMap
            ' 
            Me.mobjGoogleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGoogleMap.Location = New System.Drawing.Point(30, 30)
            Me.mobjGoogleMap.MapControlMaps = New Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(True, False, False, False)
            Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(37.819722, -122.478611)
            Me.mobjGoogleMap.Name = "mobjGoogleMap"
            Me.mobjGoogleMap.Size = New System.Drawing.Size(634, 245)
            Me.mobjGoogleMap.TabIndex = 0
            ' 
            ' mobjCheckedListBox
            ' 
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(15, 29)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(604, 180)
            Me.mobjCheckedListBox.TabIndex = 1
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjCheckedListBox)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(30, 295)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjGroupBox.Size = New System.Drawing.Size(634, 225)
            Me.mobjGroupBox.TabIndex = 2
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "MapLayers"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGoogleMap, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupBox, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 225.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(694, 540)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' MapLayersCollectionPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(694, 540)
            Me.Text = "MapLayersCollectionPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGoogleMap As Gizmox.WebGUI.Forms.Professional.GoogleMap
        Private WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace