Namespace CompanionKit.Controls.ToolBar.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ToolBarButtonStylePage
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
            Me.ToolBar1 = New Gizmox.WebGUI.Forms.ToolBar
            Me.ToolBarButton1 = New Gizmox.WebGUI.Forms.ToolBarButton
            Me.ToolBarButton2 = New Gizmox.WebGUI.Forms.ToolBarButton
            Me.ToolBarButton3 = New Gizmox.WebGUI.Forms.ToolBarButton
            Me.ContextMenu1 = New Gizmox.WebGUI.Forms.ContextMenu
            Me.MenuItem1 = New Gizmox.WebGUI.Forms.MenuItem
            Me.MenuItem2 = New Gizmox.WebGUI.Forms.MenuItem
            Me.MenuItem3 = New Gizmox.WebGUI.Forms.MenuItem
            Me.MenuItem4 = New Gizmox.WebGUI.Forms.MenuItem
            Me.descriptionLabel = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'ToolBar1
            '
            Me.ToolBar1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.ToolBar1.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal
            Me.ToolBar1.Buttons.AddRange(New Gizmox.WebGUI.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton2, Me.ToolBarButton3})
            Me.ToolBar1.ButtonSize = New System.Drawing.Size(0, 22)
            Me.ToolBar1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.ToolBar1.DragHandle = True
            Me.ToolBar1.DropDownArrows = True
            Me.ToolBar1.ImageSize = New System.Drawing.Size(16, 16)
            Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
            Me.ToolBar1.MenuHandle = True
            Me.ToolBar1.Name = "ToolBar1"
            Me.ToolBar1.ShowToolTips = True
            Me.ToolBar1.Size = New System.Drawing.Size(391, 42)
            Me.ToolBar1.TabIndex = 0
            '
            'ToolBarButton1
            '
            Me.ToolBarButton1.CustomStyle = ""
            Me.ToolBarButton1.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ToolBarButton1.Name = "ToolBarButton1"
            Me.ToolBarButton1.Size = 24
            Me.ToolBarButton1.Text = "Push"
            Me.ToolBarButton1.ToolTipText = ""
            '
            'ToolBarButton2
            '
            Me.ToolBarButton2.CustomStyle = ""
            Me.ToolBarButton2.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ToolBarButton2.Name = "ToolBarButton2"
            Me.ToolBarButton2.Size = 50
            Me.ToolBarButton2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton
            Me.ToolBarButton2.Text = "Toggle"
            Me.ToolBarButton2.ToolTipText = ""
            '
            'ToolBarButton3
            '
            Me.ToolBarButton3.CustomStyle = ""
            Me.ToolBarButton3.DropDownMenu = Me.ContextMenu1
            Me.ToolBarButton3.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ToolBarButton3.Name = "ToolBarButton3"
            Me.ToolBarButton3.Size = 50
            Me.ToolBarButton3.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.DropDownButton
            Me.ToolBarButton3.Text = "DropDown"
            Me.ToolBarButton3.ToolTipText = ""
            '
            'ContextMenu1
            '
            Me.ContextMenu1.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 0
            Me.MenuItem1.Text = "MenuItem1"
            '
            'MenuItem2
            '
            Me.MenuItem2.Index = 1
            Me.MenuItem2.Text = "MenuItem2"
            '
            'MenuItem3
            '
            Me.MenuItem3.Index = 2
            Me.MenuItem3.Text = "MenuItem3"
            '
            'MenuItem4
            '
            Me.MenuItem4.Index = 3
            Me.MenuItem4.Text = "MenuItem4"
            '
            'descriptionLabel
            '
            Me.descriptionLabel.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                        Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.descriptionLabel.Location = New System.Drawing.Point(22, 107)
            Me.descriptionLabel.Name = "descriptionLabel"
            Me.descriptionLabel.Size = New System.Drawing.Size(347, 120)
            Me.descriptionLabel.TabIndex = 1
            Me.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ToolBarButtonStylePage
            '
            Me.Controls.Add(Me.descriptionLabel)
            Me.Controls.Add(Me.ToolBar1)
            Me.Size = New System.Drawing.Size(391, 87)
            Me.Text = "ToolBarButtonStylePage"
            Me.ResumeLayout(False)

        End Sub
		Friend WithEvents ToolBar1 As Global.Gizmox.WebGUI.Forms.ToolBar
		Friend WithEvents ToolBarButton1 As Gizmox.WebGUI.Forms.ToolBarButton
		Friend WithEvents ToolBarButton2 As Gizmox.WebGUI.Forms.ToolBarButton
		Friend WithEvents ToolBarButton3 As Gizmox.WebGUI.Forms.ToolBarButton
		Friend WithEvents ContextMenu1 As Global.Gizmox.WebGUI.Forms.ContextMenu
		Friend WithEvents MenuItem1 As Gizmox.WebGUI.Forms.MenuItem
		Friend WithEvents MenuItem2 As Gizmox.WebGUI.Forms.MenuItem
		Friend WithEvents MenuItem3 As Gizmox.WebGUI.Forms.MenuItem
		Friend WithEvents MenuItem4 As Gizmox.WebGUI.Forms.MenuItem
		Friend WithEvents descriptionLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace
