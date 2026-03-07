Namespace CompanionKit.Controls.ContextMenu.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CollapsePage
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
            Me.mobjContextMenu = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.mobjMenuItem1 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem2 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjMenuItem3 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjContextMenu
            ' 
            Me.mobjContextMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjMenuItem1, Me.mobjMenuItem2, Me.mobjMenuItem3})
            ' 
            ' mobjMenuItem1
            ' 
            Me.mobjMenuItem1.Index = 0
            Me.mobjMenuItem1.Text = "Menu Item1"
            ' 
            ' mobjMenuItem2
            ' 
            Me.mobjMenuItem2.Index = 1
            Me.mobjMenuItem2.Text = "Menu Item2"
            ' 
            ' mobjMenuItem3
            ' 
            Me.mobjMenuItem3.Index = 2
            Me.mobjMenuItem3.Text = "Menu Item3"
            ' 
            ' mobjLabel2
            ' 
            Me.mobjLabel2.AutoSize = True
            Me.mobjLabel2.ContextMenu = Me.mobjContextMenu
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Font = New System.Drawing.Font("Tahoma", 12.25F, System.Drawing.FontStyle.Bold)
            Me.mobjLabel2.Location = New System.Drawing.Point(132, 27)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(397, 63)
            Me.mobjLabel2.TabIndex = 1
            Me.mobjLabel2.Text = "Right click to see a context menu"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel1
            ' 
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(132, 110)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(397, 63)
            Me.mobjLabel1.TabIndex = 2
            Me.mobjLabel1.Text = "Represents information about selected menu item"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ContextMenu = Me.mobjContextMenu
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel1, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel2, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(663, 200)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' CollapsePage
            ' 
            Me.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.ContextMenu = Me.mobjContextMenu
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(663, 200)
            Me.Text = "CollapsePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjContextMenu As Global.Gizmox.WebGUI.Forms.ContextMenu
        Private WithEvents mobjMenuItem1 As Global.Gizmox.WebGUI.Forms.MenuItem
        Private WithEvents mobjMenuItem2 As Global.Gizmox.WebGUI.Forms.MenuItem
        Private WithEvents mobjMenuItem3 As Global.Gizmox.WebGUI.Forms.MenuItem
        Private mobjLabel2 As Global.Gizmox.WebGUI.Forms.Label
        Private mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
