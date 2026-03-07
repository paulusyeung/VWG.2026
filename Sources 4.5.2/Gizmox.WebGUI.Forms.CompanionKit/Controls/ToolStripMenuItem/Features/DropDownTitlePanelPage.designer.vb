Namespace CompanionKit.Controls.ToolStripMenuItem.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DropDownTitlePanelPage
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
            Me.mobjMenuStrip = New Gizmox.WebGUI.Forms.MenuStrip()
            Me.mobjToolStripMenuItem1 = New Gizmox.WebGUI.Forms.ToolStripMenuItem()
            Me.mobjToolStripMenuItem3 = New Gizmox.WebGUI.Forms.ToolStripMenuItem()
            Me.mobjToolStripMenuItem4 = New Gizmox.WebGUI.Forms.ToolStripMenuItem()
            Me.mobjToolStripMenuItem5 = New Gizmox.WebGUI.Forms.ToolStripMenuItem()
            Me.mobjToolStripMenuItem6 = New Gizmox.WebGUI.Forms.ToolStripMenuItem()
            Me.mobjToolStripSeparator1 = New Gizmox.WebGUI.Forms.ToolStripSeparator()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjMenuStrip
            ' 
            Me.mobjMenuStrip.DockPadding.Bottom = 2
            Me.mobjMenuStrip.DockPadding.Left = 6
            Me.mobjMenuStrip.DockPadding.Top = 2
            Me.mobjMenuStrip.Items.AddRange(New Gizmox.WebGUI.Forms.ToolStripItem() {Me.mobjToolStripMenuItem1})
            Me.mobjMenuStrip.Location = New System.Drawing.Point(0, 0)
            Me.mobjMenuStrip.Name = "mobjMenuStrip"
            Me.mobjMenuStrip.Size = New System.Drawing.Size(391, 24)
            Me.mobjMenuStrip.TabIndex = 0
            Me.mobjMenuStrip.Text = "menuStrip1"
            ' 
            ' mobjToolStripMenuItem1
            ' 
            Me.mobjToolStripMenuItem1.DropDownItems.AddRange(New Gizmox.WebGUI.Forms.ToolStripItem() {Me.mobjToolStripMenuItem3, Me.mobjToolStripMenuItem4, Me.mobjToolStripMenuItem5, Me.mobjToolStripMenuItem6, Me.mobjToolStripSeparator1})
            Me.mobjToolStripMenuItem1.Name = "mobjToolStripMenuItem1"
            Me.mobjToolStripMenuItem1.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)
            Me.mobjToolStripMenuItem1.Size = New System.Drawing.Size(56, 17)
            Me.mobjToolStripMenuItem1.Text = "RootItem"
            Me.mobjToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjToolStripMenuItem3
            ' 
            Me.mobjToolStripMenuItem3.Name = "mobjToolStripMenuItem3"
            Me.mobjToolStripMenuItem3.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)
            Me.mobjToolStripMenuItem3.Size = New System.Drawing.Size(120, 20)
            Me.mobjToolStripMenuItem3.Text = "SubItem1"
            Me.mobjToolStripMenuItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjToolStripMenuItem4
            ' 
            Me.mobjToolStripMenuItem4.Name = "mobjToolStripMenuItem4"
            Me.mobjToolStripMenuItem4.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)
            Me.mobjToolStripMenuItem4.Size = New System.Drawing.Size(120, 20)
            Me.mobjToolStripMenuItem4.Text = "SubItem2"
            Me.mobjToolStripMenuItem4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjToolStripMenuItem5
            ' 
            Me.mobjToolStripMenuItem5.Name = "mobjToolStripMenuItem5"
            Me.mobjToolStripMenuItem5.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)
            Me.mobjToolStripMenuItem5.Size = New System.Drawing.Size(120, 20)
            Me.mobjToolStripMenuItem5.Text = "SubItem3"
            Me.mobjToolStripMenuItem5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjToolStripMenuItem6
            ' 
            Me.mobjToolStripMenuItem6.Name = "mobjToolStripMenuItem6"
            Me.mobjToolStripMenuItem6.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0)
            Me.mobjToolStripMenuItem6.Size = New System.Drawing.Size(120, 20)
            Me.mobjToolStripMenuItem6.Text = "SubItem4"
            Me.mobjToolStripMenuItem6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjToolStripSeparator1
            ' 
            Me.mobjToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDark
            Me.mobjToolStripSeparator1.Name = "mobjToolStripSeparator1"
            Me.mobjToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 24)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(409, 13)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Tip: You should reopen dropdown list after adding or removing item, to see change" + "s"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' DropDownTitlePanelPage
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjMenuStrip)
            Me.Size = New System.Drawing.Size(450, 150)
            Me.Text = "DropDownTitlePanelPage"
            Me.ResumeLayout(False)

        End Sub

        Private mobjMenuStrip As Gizmox.WebGUI.Forms.MenuStrip
        Private mobjToolStripMenuItem1 As Gizmox.WebGUI.Forms.ToolStripMenuItem
        Private mobjToolStripMenuItem3 As Gizmox.WebGUI.Forms.ToolStripMenuItem
        Private mobjToolStripMenuItem4 As Gizmox.WebGUI.Forms.ToolStripMenuItem
        Private mobjToolStripMenuItem5 As Gizmox.WebGUI.Forms.ToolStripMenuItem
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRemoveButton As Gizmox.WebGUI.Forms.Button
        Private mobjToolStripMenuItem6 As Gizmox.WebGUI.Forms.ToolStripMenuItem
        Private mobjToolStripSeparator1 As Gizmox.WebGUI.Forms.ToolStripSeparator
        Private mobjLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace