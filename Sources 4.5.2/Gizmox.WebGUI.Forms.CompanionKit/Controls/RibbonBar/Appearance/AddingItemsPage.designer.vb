Imports System.Drawing
Imports Gizmox.WebGUI.Forms
Imports System.ComponentModel

Namespace CompanionKit.Controls.RibbonBar.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddingItemsPage
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
			Dim manager As New ComponentResourceManager(GetType(AddingItemsPage))
			Me.demoRibbonBar = New Gizmox.WebGUI.Forms.RibbonBar
			Me.rbEmail = New RibbonBarPage
			Me.rbGroupActions = New RibbonBarGroup
			Me.rbItemMoveTo = New RibbonBarButtonItem
			Me.rbItemDelete = New RibbonBarButtonItem
			Me.rbItemReply = New RibbonBarButtonItem
			Me.rbItemFollowUp = New RibbonBarButtonItem
			Me.rbGroupTools = New RibbonBarGroup
			Me.rbItemApps = New RibbonBarDropDownButtonItem
			Me.mobjToolsMenu = New Gizmox.WebGUI.Forms.ContextMenu
			Me.menuAddressBook = New MenuItem
			Me.menuCalendar = New MenuItem
			Me.menuSignature = New MenuItem
			Me.menuImageEditor = New MenuItem
			Me.rbEdit = New RibbonBarPage
			Me.rbGroupFind = New RibbonBarGroup
			Me.rbItemStack = New RibbonBarStackItem
			Me.rbSItemWhere = New RibbonBarDropDownButtonItem
			Me.mobjWhereFind = New Gizmox.WebGUI.Forms.ContextMenu
			Me.menuWhereAll = New MenuItem
			Me.menuWhereImages = New MenuItem
			Me.menuWhereDocs = New MenuItem
			Me.menuWhereCode = New MenuItem
			Me.rbSItemCase = New RibbonBarCheckBoxItem
			Me.rbSItemQuickFind = New RibbonBarButtonItem
			Me.rbGroupIntelliSence = New RibbonBarGroup
			Me.rbIntelliSense = New RibbonBarFlowItem
			Me.rbSItemBar1 = New RibbonBarToolBarItem
			Me.rbSItemListMembers = New RibbonBarToolBarButtonItem
			Me.rbSItemsParameterInfo = New RibbonBarToolBarButtonItem
			Me.rbSItemQuickInfo = New RibbonBarToolBarButtonItem
			Me.rbSItemBar2 = New RibbonBarToolBarItem
			Me.ribbonBarToolBarButtonItem4 = New RibbonBarToolBarButtonItem
			Me.ribbonBarToolBarButtonItem5 = New RibbonBarToolBarButtonItem
			Me.rbSItemBar3 = New RibbonBarToolBarItem
			Me.rbSItemEnableBookmark = New RibbonBarToolBarButtonItem
			Me.rbSItemEnableAll = New RibbonBarToolBarButtonItem
			Me.rbSItemToggle = New RibbonBarToolBarButtonItem
			Me.rbSItemTXTSearch = New RibbonBarTextBoxItem
			Me.rbSItemCmb = New RibbonBarComboBoxItem
			Me.groupBox1 = New Gizmox.WebGUI.Forms.GroupBox
			Me.groupBox2 = New Gizmox.WebGUI.Forms.GroupBox
			Me.lblStatus = New Label
			Me.lblEventHandler = New Label
			Me.mobjGrpWidth = New Gizmox.WebGUI.Forms.GroupBox
			Me.mobjCmdInitial = New Gizmox.WebGUI.Forms.Button
			Me.mobjTrackWidth = New Gizmox.WebGUI.Forms.TrackBar
			Me.lblWidth = New Label
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.mobjGrpWidth.SuspendLayout()
			Me.mobjTrackWidth.BeginInit()
			MyBase.SuspendLayout()
			Me.demoRibbonBar.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.demoRibbonBar.Location = New Point(0, 0)
			Me.demoRibbonBar.Name = "demoRibbonBar"
			Me.demoRibbonBar.Pages.Add(Me.rbEmail)
			Me.demoRibbonBar.Pages.Add(Me.rbEdit)
			Me.demoRibbonBar.SelectedIndex = 0
			Me.demoRibbonBar.TabIndex = 0
			AddHandler Me.demoRibbonBar.CheckChanged, New EventHandler(Of RibbonBarCheckBoxItemArgs)(AddressOf Me.rb_CheckedChanged)
			AddHandler Me.demoRibbonBar.SelectedIndexChanged, New EventHandler(AddressOf Me.SelectedIndexChanged)
			AddHandler Me.demoRibbonBar.ButtonClick, New EventHandler(Of RibbonBarButtonItemArgs)(AddressOf Me.rb_ButtonClick)
			AddHandler Me.demoRibbonBar.AdvancedClicked, New EventHandler(Of RibbonBarGroupArgs)(AddressOf Me.AdvancedClicked)
			AddHandler Me.demoRibbonBar.TextChanged, New EventHandler(Of RibbonBarTextBoxItemArgs)(AddressOf Me.rb_TextChanged)
			Me.rbEmail.Groups.Add(Me.rbGroupActions)
			Me.rbEmail.Groups.Add(Me.rbGroupTools)
			Me.rbEmail.Text = "Email"
			Me.rbGroupActions.Items.Add(Me.rbItemMoveTo)
			Me.rbGroupActions.Items.Add(Me.rbItemDelete)
			Me.rbGroupActions.Items.Add(Me.rbItemReply)
			Me.rbGroupActions.Items.Add(Me.rbItemFollowUp)
			Me.rbGroupActions.Text = "Actions"
			Me.rbItemMoveTo.ClientAction = Nothing
			Me.rbItemMoveTo.Image = New ImageResourceHandle(manager.GetString("rbItemMoveTo.Image"))
			Me.rbItemMoveTo.Text = "Move To"
			Me.rbItemMoveTo.ToolTip = "Move To Folder"
			Me.rbItemDelete.ClientAction = Nothing
			Me.rbItemDelete.Image = New ImageResourceHandle(manager.GetString("rbItemDelete.Image"))
			Me.rbItemDelete.Text = "Delete"
			Me.rbItemDelete.ToolTip = "Dlete"
			Me.rbItemReply.ClientAction = Nothing
			Me.rbItemReply.Image = New ImageResourceHandle(manager.GetString("rbItemReply.Image"))
			Me.rbItemReply.Text = "Reply"
			Me.rbItemReply.ToolTip = "Reply"
			Me.rbItemFollowUp.ClientAction = Nothing
			Me.rbItemFollowUp.Image = New ImageResourceHandle(manager.GetString("rbItemFollowUp.Image"))
			Me.rbItemFollowUp.Text = "Follow Up"
			Me.rbItemFollowUp.ToolTip = "Follow Up"
			Me.rbGroupTools.HasAdvanced = True
			Me.rbGroupTools.Items.Add(Me.rbItemApps)
			Me.rbGroupTools.Text = "Tools"
			Me.rbItemApps.ClientAction = Nothing
			Me.rbItemApps.DropDownMenu = Me.mobjToolsMenu
			Me.rbItemApps.Image = New ImageResourceHandle(manager.GetString("rbItemApps.Image"))
			Me.rbItemApps.Tag = "Tools"
			Me.rbItemApps.ToolTip = "Available Tools"
			AddHandler Me.rbItemApps.MenuClick, New MenuEventHandler(AddressOf Me.rb_MenuClick)
			Me.mobjToolsMenu.MenuItems.AddRange(New MenuItem() {Me.menuAddressBook, Me.menuCalendar, Me.menuSignature, Me.menuImageEditor})
			Me.menuAddressBook.Icon = New ImageResourceHandle(manager.GetString("menuAddressBook.Icon"))
			Me.menuAddressBook.Index = 0
			Me.menuAddressBook.Text = "Address Book"
			Me.menuCalendar.Icon = New ImageResourceHandle(manager.GetString("menuCalendar.Icon"))
			Me.menuCalendar.Index = 1
			Me.menuCalendar.Text = "Calendar"
			Me.menuSignature.Icon = New ImageResourceHandle(manager.GetString("menuSignature.Icon"))
			Me.menuSignature.Index = 2
			Me.menuSignature.Text = "Signature"
			Me.menuImageEditor.Icon = New ImageResourceHandle(manager.GetString("menuImageEditor.Icon"))
			Me.menuImageEditor.Index = 3
			Me.menuImageEditor.Text = "Image Editor"
			Me.rbEdit.Groups.Add(Me.rbGroupFind)
			Me.rbEdit.Groups.Add(Me.rbGroupIntelliSence)
			Me.rbEdit.Text = "Edit"
			Me.rbGroupFind.HasAdvanced = True
			Me.rbGroupFind.Items.Add(Me.rbItemStack)
			Me.rbGroupFind.Text = "Find and Replace"
			Me.rbItemStack.Items.Add(Me.rbSItemWhere)
			Me.rbItemStack.Items.Add(Me.rbSItemCase)
			Me.rbItemStack.Items.Add(Me.rbSItemQuickFind)
			Me.rbSItemWhere.ClientAction = Nothing
			Me.rbSItemWhere.DropDownMenu = Me.mobjWhereFind
			Me.rbSItemWhere.Image = New IconResourceHandle(manager.GetString("rbSItemWhere.Image"))
			Me.rbSItemWhere.Text = "Where"
			Me.rbSItemWhere.ToolTip = "Where to search"
			AddHandler Me.rbSItemWhere.MenuClick, New MenuEventHandler(AddressOf Me.rb_MenuClick)
			Me.mobjWhereFind.MenuItems.AddRange(New MenuItem() {Me.menuWhereAll, Me.menuWhereImages, Me.menuWhereDocs, Me.menuWhereCode})
			Me.menuWhereAll.Checked = True
			Me.menuWhereAll.Index = 0
			Me.menuWhereAll.Text = "All"
			AddHandler Me.menuWhereAll.Click, New EventHandler(AddressOf Me.menuWhere_Click)
			Me.menuWhereImages.Index = 1
			Me.menuWhereImages.Text = "Images"
			AddHandler Me.menuWhereImages.Click, New EventHandler(AddressOf Me.menuWhere_Click)
			Me.menuWhereDocs.Index = 2
			Me.menuWhereDocs.Text = "Documents"
			AddHandler Me.menuWhereDocs.Click, New EventHandler(AddressOf Me.menuWhere_Click)
			Me.menuWhereCode.Index = 3
			Me.menuWhereCode.Text = "Code"
			AddHandler Me.menuWhereCode.Click, New EventHandler(AddressOf Me.menuWhere_Click)
			Me.rbSItemCase.Text = "Case sensitive"
			Me.rbSItemCase.ToolTip = "Run case sensitive search"
			Me.rbSItemQuickFind.ClientAction = Nothing
			Me.rbSItemQuickFind.Image = New IconResourceHandle(manager.GetString("rbSItemQuickFind.Image"))
			Me.rbSItemQuickFind.Text = "Quick Find"
			Me.rbSItemQuickFind.ToolTip = "Quick Find"
			Me.rbGroupIntelliSence.Items.Add(Me.rbIntelliSense)
			Me.rbGroupIntelliSence.Text = "IntelliSence"
			Me.rbIntelliSense.Items.Add(Me.rbSItemBar1)
			Me.rbIntelliSense.Items.Add(Me.rbSItemBar2)
			Me.rbIntelliSense.Items.Add(Me.rbSItemBar3)
			Me.rbIntelliSense.Items.Add(Me.rbSItemTXTSearch)
			Me.rbIntelliSense.Items.Add(Me.rbSItemCmb)
			Me.rbIntelliSense.Width = 230
			Me.rbSItemBar1.Items.Add(Me.rbSItemListMembers)
			Me.rbSItemBar1.Items.Add(Me.rbSItemsParameterInfo)
			Me.rbSItemBar1.Items.Add(Me.rbSItemQuickInfo)
			Me.rbSItemListMembers.ClientAction = Nothing
			Me.rbSItemListMembers.Image = New IconResourceHandle(manager.GetString("rbSItemListMembers.Image"))
			Me.rbSItemListMembers.Tag = "List Members"
			Me.rbSItemListMembers.ToolTip = "List Members"
			Me.rbSItemsParameterInfo.ClientAction = Nothing
			Me.rbSItemsParameterInfo.Image = New IconResourceHandle(manager.GetString("rbSItemsParameterInfo.Image"))
			Me.rbSItemsParameterInfo.Tag = "Parameter Info"
			Me.rbSItemsParameterInfo.ToolTip = "Parameter Info"
			Me.rbSItemQuickInfo.ClientAction = Nothing
			Me.rbSItemQuickInfo.Image = New IconResourceHandle(manager.GetString("rbSItemQuickInfo.Image"))
			Me.rbSItemQuickInfo.Tag = "Quick Info"
			Me.rbSItemQuickInfo.ToolTip = "Quick Info"
			Me.rbSItemBar2.Enabled = False
			Me.rbSItemBar2.Items.Add(Me.ribbonBarToolBarButtonItem4)
			Me.rbSItemBar2.Items.Add(Me.ribbonBarToolBarButtonItem5)
			Me.ribbonBarToolBarButtonItem4.ClientAction = Nothing
			Me.ribbonBarToolBarButtonItem4.Image = New IconResourceHandle(manager.GetString("ribbonBarToolBarButtonItem4.Image"))
			Me.ribbonBarToolBarButtonItem5.ClientAction = Nothing
			Me.ribbonBarToolBarButtonItem5.Image = New IconResourceHandle(manager.GetString("ribbonBarToolBarButtonItem5.Image"))
			Me.rbSItemBar3.Items.Add(Me.rbSItemEnableBookmark)
			Me.rbSItemBar3.Items.Add(Me.rbSItemEnableAll)
			Me.rbSItemBar3.Items.Add(Me.rbSItemToggle)
			Me.rbSItemEnableBookmark.ClientAction = Nothing
			Me.rbSItemEnableBookmark.Image = New IconResourceHandle(manager.GetString("rbSItemEnableBookmark.Image"))
			Me.rbSItemEnableBookmark.Tag = "Enable Bookmark"
			Me.rbSItemEnableBookmark.ToolTip = "Enable Bookmark"
			Me.rbSItemEnableAll.ClientAction = Nothing
			Me.rbSItemEnableAll.Image = New IconResourceHandle(manager.GetString("rbSItemEnableAll.Image"))
			Me.rbSItemEnableAll.Tag = "Enable All Bookmarks"
			Me.rbSItemEnableAll.ToolTip = "Enable All Bookmarks"
			Me.rbSItemToggle.ClientAction = Nothing
			Me.rbSItemToggle.Image = New IconResourceHandle(manager.GetString("rbSItemToggle.Image"))
			Me.rbSItemToggle.Tag = "Toggle Bookmark"
			Me.rbSItemToggle.ToolTip = "Toggle Bookmark"
			Me.rbSItemTXTSearch.Text = "Search..."
			Me.rbSItemTXTSearch.ToolTip = "Enter text to search"
			Me.rbSItemCmb.Items.AddRange(New Object() {"Solution", "Project", "File"})
			Me.rbSItemCmb.ToolTip = "Select scope to search"
			Me.groupBox1.Controls.Add(Me.groupBox2)
			Me.groupBox1.Controls.Add(Me.mobjGrpWidth)
			Me.groupBox1.Dock = DockStyle.Fill
			Me.groupBox1.FlatStyle = FlatStyle.Flat
			Me.groupBox1.Location = New Point(0, &H73)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New Size(&H2AE, &HDB)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.groupBox2.Controls.Add(Me.lblStatus)
			Me.groupBox2.Controls.Add(Me.lblEventHandler)
			Me.groupBox2.FlatStyle = FlatStyle.Flat
			Me.groupBox2.Location = New Point(9, &H11)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New Size(&H201, 100)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = " Event handlers "
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Location = New Point(9, &H16)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Size(&H23, 13)
			Me.lblStatus.TabIndex = 0
			Me.lblStatus.Text = "The Active page:"
			Me.lblEventHandler.AutoSize = True
			Me.lblEventHandler.Location = New Point(9, &H2E)
			Me.lblEventHandler.Name = "lblEventHandler"
			Me.lblEventHandler.Size = New Size(&H23, 13)
			Me.lblEventHandler.TabIndex = 0
			Me.lblEventHandler.Text = "Event Handler:"
			Me.mobjGrpWidth.Controls.Add(Me.mobjCmdInitial)
			Me.mobjGrpWidth.Controls.Add(Me.mobjTrackWidth)
			Me.mobjGrpWidth.Controls.Add(Me.lblWidth)
			Me.mobjGrpWidth.FlatStyle = FlatStyle.Flat
			Me.mobjGrpWidth.Location = New Point(9, &H7C)
			Me.mobjGrpWidth.Name = "mobjGrpWidth"
			Me.mobjGrpWidth.Size = New Size(&H201, &H41)
			Me.mobjGrpWidth.TabIndex = 1
			Me.mobjGrpWidth.TabStop = False
			Me.mobjGrpWidth.Text = " IntelliSense Item width "
			Me.mobjGrpWidth.Visible = False
			Me.mobjCmdInitial.CustomStyle = "F"
			Me.mobjCmdInitial.FlatStyle = FlatStyle.Flat
			Me.mobjCmdInitial.Location = New Point(&H1D8, &H17)
			Me.mobjCmdInitial.Name = "mobjCmdInitial"
			Me.mobjCmdInitial.Size = New Size(&H26, &H17)
			Me.mobjCmdInitial.TabIndex = 3
			Me.mobjCmdInitial.Text = "..."
			Me.mobjCmdInitial.UseVisualStyleBackColor = True
			AddHandler Me.mobjCmdInitial.Click, New EventHandler(AddressOf Me.Width_SetInitial)
			Me.mobjTrackWidth.Location = New Point(&HB2, &H16)
			Me.mobjTrackWidth.Maximum = 500
			Me.mobjTrackWidth.Minimum = 100
			Me.mobjTrackWidth.Name = "mobjTrackWidth"
			Me.mobjTrackWidth.Size = New Size(290, &H24)
			Me.mobjTrackWidth.TabIndex = 1
			Me.mobjTrackWidth.TickFrequency = 20
			Me.mobjTrackWidth.Value = 230
			AddHandler Me.mobjTrackWidth.ValueChanged, New EventHandler(AddressOf Me.Width_ValueChanged)
			Me.lblWidth.AutoSize = True
			Me.lblWidth.Location = New Point(9, &H1C)
			Me.lblWidth.Name = "lblWidth"
			Me.lblWidth.Size = New Size(&H23, 13)
			Me.lblWidth.TabIndex = 2
			Me.lblWidth.Text = "RibbonBarFlowItem width:"
			MyBase.Controls.Add(Me.groupBox1)
			MyBase.Controls.Add(Me.demoRibbonBar)
			MyBase.Size = New Size(&H2AE, &H14E)
			Me.Text = "AddingItemsPage"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.mobjGrpWidth.ResumeLayout(False)
			Me.mobjTrackWidth.EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Fields
		Private demoRibbonBar As Gizmox.WebGUI.Forms.RibbonBar
		Private groupBox1 As Gizmox.WebGUI.Forms.GroupBox
		Private groupBox2 As Gizmox.WebGUI.Forms.GroupBox
		Private lblEventHandler As Label
		Private lblStatus As Label
		Private lblWidth As Label
		Private menuAddressBook As MenuItem
		Private menuCalendar As MenuItem
		Private menuImageEditor As MenuItem
		Private menuSignature As MenuItem
		Private menuWhereAll As MenuItem
		Private menuWhereCode As MenuItem
		Private menuWhereDocs As MenuItem
		Private menuWhereImages As MenuItem
		Private mobjCmdInitial As Gizmox.WebGUI.Forms.Button
		Private mobjGrpWidth As Gizmox.WebGUI.Forms.GroupBox
		Private mobjToolsMenu As Gizmox.WebGUI.Forms.ContextMenu
		Private mobjTrackWidth As Gizmox.WebGUI.Forms.TrackBar
		Private mobjWhereFind As Gizmox.WebGUI.Forms.ContextMenu
		Private rbEdit As RibbonBarPage
		Private rbEmail As RibbonBarPage
		Private rbGroupActions As RibbonBarGroup
		Private rbGroupFind As RibbonBarGroup
		Private rbGroupIntelliSence As RibbonBarGroup
		Private rbGroupTools As RibbonBarGroup
		Private rbIntelliSense As RibbonBarFlowItem
		Private rbItemApps As RibbonBarDropDownButtonItem
		Private rbItemDelete As RibbonBarButtonItem
		Private rbItemFollowUp As RibbonBarButtonItem
		Private rbItemMoveTo As RibbonBarButtonItem
		Private rbItemReply As RibbonBarButtonItem
		Private rbItemStack As RibbonBarStackItem
		Private rbSItemBar1 As RibbonBarToolBarItem
		Private rbSItemBar2 As RibbonBarToolBarItem
		Private rbSItemBar3 As RibbonBarToolBarItem
		Private rbSItemCase As RibbonBarCheckBoxItem
		Private rbSItemCmb As RibbonBarComboBoxItem
		Private rbSItemEnableAll As RibbonBarToolBarButtonItem
		Private rbSItemEnableBookmark As RibbonBarToolBarButtonItem
		Private rbSItemListMembers As RibbonBarToolBarButtonItem
		Private rbSItemQuickFind As RibbonBarButtonItem
		Private rbSItemQuickInfo As RibbonBarToolBarButtonItem
		Private rbSItemsParameterInfo As RibbonBarToolBarButtonItem
		Private rbSItemToggle As RibbonBarToolBarButtonItem
		Private rbSItemTXTSearch As RibbonBarTextBoxItem
		Private rbSItemWhere As RibbonBarDropDownButtonItem
		Private ribbonBarToolBarButtonItem4 As RibbonBarToolBarButtonItem
		Private ribbonBarToolBarButtonItem5 As RibbonBarToolBarButtonItem

	End Class

End Namespace