Namespace CompanionKit.Controls.Form.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MDIParentForm
		Inherits Global.Gizmox.WebGUI.Forms.Form

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Visual WebGui Designer
		Private Shadows components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Visual WebGui Designer
		'It can be modified using the Visual WebGui Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.mobjMainMenu = New Gizmox.WebGUI.Forms.MainMenu()
            Me.mobjMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjOpenMDIChildFormMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjCloseActiveMDIChildFormMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjCloseAllMDIChildFormsMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.SuspendLayout()
            '
            'mobjMainMenu
            '
            Me.mobjMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMainMenu.Location = New System.Drawing.Point(0, 0)
            Me.mobjMainMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjMenuItem})
            Me.mobjMainMenu.Name = "mainMenu1"
            Me.mobjMainMenu.Size = New System.Drawing.Size(100, 100)
            '
            'mobjMenuItem
            '
            Me.mobjMenuItem.Index = 0
            Me.mobjMenuItem.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjOpenMDIChildFormMenuItem, Me.mobjCloseActiveMDIChildFormMenuItem, Me.mobjCloseAllMDIChildFormsMenuItem})
            Me.mobjMenuItem.Text = "Form"
            '
            'mobjOpenMDIChildFormMenuItem
            '
            Me.mobjOpenMDIChildFormMenuItem.Index = 0
            Me.mobjOpenMDIChildFormMenuItem.Text = "Open MDI Child Form"
            '
            'mobjCloseActiveMDIChildFormMenuItem
            '
            Me.mobjCloseActiveMDIChildFormMenuItem.Enabled = False
            Me.mobjCloseActiveMDIChildFormMenuItem.Index = 1
            Me.mobjCloseActiveMDIChildFormMenuItem.Text = "Close Active MDI Child Form"
            '
            'mobjCloseAllMDIChildFormsMenuItem
            '
            Me.mobjCloseAllMDIChildFormsMenuItem.Enabled = False
            Me.mobjCloseAllMDIChildFormsMenuItem.Index = 2
            Me.mobjCloseAllMDIChildFormsMenuItem.Text = "Close All MDI Child Forms"
            '
            'MDIParentForm
            '
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.IsMdiContainer = True
            Me.Menu = Me.mobjMainMenu
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "MDIParentForm"
            Me.ResumeLayout(False)

        End Sub

        Private mobjMainMenu As Gizmox.WebGUI.Forms.MainMenu
        Private mobjMenuItem As MenuItem
        Private WithEvents mobjOpenMDIChildFormMenuItem As MenuItem
        Private WithEvents mobjCloseActiveMDIChildFormMenuItem As MenuItem
        Private WithEvents mobjCloseAllMDIChildFormsMenuItem As MenuItem

	End Class
End Namespace
