Namespace CompanionKit.Controls.Button.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DropDownMenuPage
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
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.contextMenu1 = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.menuItem1 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.menuItem2 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.menuItem3 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.menuItem4 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.DropDownMenu = Me.contextMenu1
            Me.mobjButton.Location = New System.Drawing.Point(46, 87)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(228, 76)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Button with DropDown Menu"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'contextMenu1
            '
            Me.contextMenu1.AllowDrop = True
            Me.contextMenu1.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.menuItem1, Me.menuItem2, Me.menuItem3, Me.menuItem4})
            '
            'menuItem1
            '
            Me.menuItem1.Index = 0
            Me.menuItem1.Text = "MenuItem1"
            '
            'menuItem2
            '
            Me.menuItem2.Index = 1
            Me.menuItem2.Text = "MenuItem2"
            '
            'menuItem3
            '
            Me.menuItem3.Index = 2
            Me.menuItem3.Text = "MenuItem3"
            '
            'menuItem4
            '
            Me.menuItem4.Index = 3
            Me.menuItem4.Text = "MenuItem4"
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 50)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Button with defined DropDownMenu property as ContextMenu:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 200)
            Me.mobjTLP.TabIndex = 2
            '
            'DropDownMenuPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 200)
            Me.Text = "DropDownMenuPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents contextMenu1 As Gizmox.WebGUI.Forms.ContextMenu
        Friend WithEvents menuItem1 As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents menuItem2 As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents menuItem3 As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents menuItem4 As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
