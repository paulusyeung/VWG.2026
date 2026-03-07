Namespace CompanionKit.Controls.GroupBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ContextMenuPage
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
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjContextMenu = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.mobjMenuItem1 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem2 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem3 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem4 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem5 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContainerPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.ContextMenu = Me.mobjContextMenu
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(144, 37)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(288, 75)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "GroupBox"
            ' 
            ' mobjContextMenu
            ' 
            Me.mobjContextMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjMenuItem1, Me.mobjMenuItem4, Me.mobjMenuItem5})
            ' 
            ' mobjMenuItem1
            ' 
            Me.mobjMenuItem1.Index = 0
            Me.mobjMenuItem1.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjMenuItem2, Me.mobjMenuItem3})
            Me.mobjMenuItem1.Text = "Menu Item1"
            ' 
            ' mobjMenuItem2
            ' 
            Me.mobjMenuItem2.Index = 0
            Me.mobjMenuItem2.Text = "Menu Sub Item1"
            ' 
            ' mobjMenuItem3
            ' 
            Me.mobjMenuItem3.Index = 1
            Me.mobjMenuItem3.Text = "Menu Sub Item2"
            ' 
            ' mobjMenuItem4
            ' 
            Me.mobjMenuItem4.Index = 1
            Me.mobjMenuItem4.Text = "Menu Item2"
            ' 
            ' mobjMenuItem5
            ' 
            Me.mobjMenuItem5.Index = 2
            Me.mobjMenuItem5.Text = "Menu Item3"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(165, 13)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Right click to see a context menu"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.Controls.Add(Me.mobjLabel)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.Location = New System.Drawing.Point(144, 112)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Size = New System.Drawing.Size(288, 50)
            Me.mobjContainerPanel.TabIndex = 2
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerPanel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupBox, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(576, 200)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ContextMenuPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(576, 200)
            Me.Text = "ContextMenuPage"
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjGroupBox As Global.Gizmox.WebGUI.Forms.GroupBox
        Private mobjContextMenu As Global.Gizmox.WebGUI.Forms.ContextMenu
        Private WithEvents mobjMenuItem1 As MenuItem
        Private WithEvents mobjMenuItem2 As MenuItem
        Private WithEvents mobjMenuItem3 As MenuItem
        Private WithEvents mobjMenuItem4 As MenuItem
        Private WithEvents mobjMenuItem5 As MenuItem
        Private mobjLabel As Label
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
