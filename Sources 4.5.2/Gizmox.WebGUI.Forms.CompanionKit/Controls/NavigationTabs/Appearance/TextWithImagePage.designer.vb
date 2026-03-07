Imports System.Drawing
Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.NavigationTabs.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextWithImagePage
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
		Private Sub InitializeComponent()
			Me.mobjSplitContainer = New Gizmox.WebGUI.Forms.SplitContainer
			Me.mobjExtraTab1 = New NavigationTab
			Me.mobjExtraTab2 = New NavigationTab
			Me.mobjNavigationTabs = New Gizmox.WebGUI.Forms.NavigationTabs
			Me.mobjNavigationTabs.SuspendLayout()
			MyBase.SuspendLayout()
			Me.mobjSplitContainer.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.mobjSplitContainer.BorderStyle = BorderStyle.None
			Me.mobjSplitContainer.Dock = DockStyle.Fill
			Me.mobjSplitContainer.FixedPanel = FixedPanel.None
			Me.mobjSplitContainer.Location = New Point(0, 0)
			Me.mobjSplitContainer.Name = "mobjSplitContainer"
			Me.mobjSplitContainer.Orientation = Orientation.Vertical
			Me.mobjSplitContainer.Panel1.Controls.Add(Me.mobjNavigationTabs)
			Me.mobjSplitContainer.Size = New Size(&H2F0, 510)
			Me.mobjSplitContainer.SplitterDistance = 210
			Me.mobjSplitContainer.TabIndex = 0
			Me.mobjExtraTab1.CustomStyle = "Navigation"
			Me.mobjExtraTab1.Dock = DockStyle.Fill
			Me.mobjExtraTab1.Extra = True
			Me.mobjExtraTab1.Label = "Data Controls"
			Me.mobjExtraTab1.Location = New Point(0, 0)
			Me.mobjExtraTab1.Name = "mobjExtraTab1"
			Me.mobjExtraTab1.Size = New Size(&HD5, &H141)
			Me.mobjExtraTab1.TabIndex = 0
			Me.mobjExtraTab1.Text = "Data Controls"
			Me.mobjExtraTab2.CustomStyle = "Navigation"
			Me.mobjExtraTab2.Dock = DockStyle.Fill
			Me.mobjExtraTab2.Extra = True
			Me.mobjExtraTab2.Label = "Host Controls"
			Me.mobjExtraTab2.Location = New Point(0, 0)
			Me.mobjExtraTab2.Name = "mobjExtraTab2"
			Me.mobjExtraTab2.Size = New Size(&HD5, &H141)
			Me.mobjExtraTab2.TabIndex = 1
			Me.mobjExtraTab2.Text = "Host Controls"
			Me.mobjNavigationTabs.Controls.Add(Me.mobjExtraTab1)
			Me.mobjNavigationTabs.Controls.Add(Me.mobjExtraTab2)
			Me.mobjNavigationTabs.CustomStyle = "Navigation"
			Me.mobjNavigationTabs.Dock = DockStyle.Fill
			Me.mobjNavigationTabs.Location = New Point(0, 0)
			Me.mobjNavigationTabs.Name = "mobjNavigationTabs"
			Me.mobjNavigationTabs.SelectedIndex = 0
			Me.mobjNavigationTabs.Size = New Size(210, 510)
			Me.mobjNavigationTabs.TabIndex = 0
			MyBase.Controls.Add(Me.mobjSplitContainer)
			MyBase.Size = New Size(&H2F0, 510)
			Me.Text = "TextWithImagePage"
			AddHandler MyBase.Load, New EventHandler(AddressOf Me.FillNavigationTabs)
			Me.mobjNavigationTabs.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Friend WithEvents mobjExtraTab1 As NavigationTab
		Friend WithEvents mobjExtraTab2 As NavigationTab
		Friend WithEvents mobjNavigationTabs As Gizmox.WebGUI.Forms.NavigationTabs
		Friend WithEvents mobjSplitContainer As Gizmox.WebGUI.Forms.SplitContainer

	End Class

End Namespace