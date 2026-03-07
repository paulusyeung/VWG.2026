Imports System.Drawing
Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.NavigationTabs.Appearance

	Public Class TextWithImagePage

		'A control to display when there is no associated snippet
		Friend mobjStubControl As UserControl = Nothing

		' Methods
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		''' <summary>
		''' Add node to parent node
		''' </summary>
		Private Function Add(ByVal objParentNode As TreeNode, ByVal strText As String, ByVal strTag As String) As TreeNode
			Dim objNewNode As New TreeNode(strText)
			objNewNode.Tag = strTag
			If String.IsNullOrEmpty(strTag) Then
				objNewNode.ImageIndex = objNewNode.ExpandedImageIndex = objNewNode.SelectedImageIndex = 2
			End If
			objParentNode.Nodes.Add(objNewNode)
			Return objNewNode
		End Function

		''' <summary>
		''' Add node to tree
		''' </summary>
		Private Function Add(ByVal objTree As Gizmox.WebGUI.Forms.TreeView, ByVal strText As String, ByVal intImageIndex As Integer, ByVal intSelectedImageIndex As Integer) As TreeNode
			Dim objAdded As New TreeNode(strText)
			objAdded.ImageIndex = intImageIndex
			objAdded.SelectedImageIndex = intSelectedImageIndex
			objTree.Nodes.Add(objAdded)
			Return objAdded
		End Function

		''' <summary>
		''' Loads the associated snippet, when the node clicked
		''' </summary>
		Private Sub AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
			Dim objNode As TreeNode = e.Node
			If Not ((objNode.Nodes.Count <= 0) OrElse objNode.IsExpanded) Then
				objNode.Expand()
			End If
			Dim objControl As UserControl = TryCast(objNode.Tag, UserControl)
			If (objControl Is Nothing) Then
				Dim strUC As String = TryCast(objNode.Tag, String)
				If Not String.IsNullOrEmpty(strUC) Then
					Dim objType As Type = Type.GetType(String.Format("{1},{0}", "Gizmox.WebGUI.Forms.CompanionKit", strUC), False)
					If (Not objType Is Nothing) Then
						objControl = DirectCast(Activator.CreateInstance(objType), UserControl)
						objControl.BorderStyle = BorderStyle.FixedSingle
						objControl.BorderWidth = 1
						objControl.BorderColor = Color.LightSteelBlue
						If (Not objControl Is Nothing) Then
							objNode.Tag = objControl
						End If
					End If
				End If
				If (String.IsNullOrEmpty(strUC) OrElse (objControl Is Nothing)) Then
					If (Me.mobjStubControl Is Nothing) Then
						Me.mobjStubControl = Me.CreateStub
					End If
					objControl = Me.mobjStubControl
				End If
			End If
			Me.mobjSplitContainer.Panel2.Controls.Clear()
			If (Not objControl Is Nothing) Then
				Me.mobjSplitContainer.Panel2.Controls.Add(objControl)
				objControl.Dock = DockStyle.Fill
			End If
		End Sub

		''' <summary>
		''' 
		''' </summary>
		Private Function CreateBehaviorsTab() As NavigationTab
			Dim objTree As New Gizmox.WebGUI.Forms.TreeView
			Me.InitTree(objTree)
			Dim objVisual As TreeNode = Me.Add(objTree, "Visual Behaviors", 2, 2)
			Me.Add(objVisual, "Background Image", "")
			Dim objMisc As TreeNode = Me.Add(objTree, "Misc Behaviors", 2, 2)
			Me.Add(objMisc, "Timers", "")
			Me.Add(objMisc, "Context", "")
			Me.Add(objMisc, "Resources", "")
			Me.Add(objMisc, "Results", "CompanionKit.Controls.Form.Features.DialogReturnValuePage")
			objTree.SelectedNode = Me.Add(objMisc, "Upload", "CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios.DisplayPicturePage")
			Me.Add(objMisc, "Drag and Drop", "CompanionKit.Controls.TreeView.Features.NodesDragingPage")
			Me.Add(objMisc, "Error Provider", "")
			Dim objLayout As TreeNode = Me.Add(objTree, "Layout Behaviors", 2, 2)
			Me.Add(objLayout, "Docking", "CompanionKit.Controls.StatusBar.Layouts.Docking")
			Me.Add(objLayout, "SplitContainer", "CompanionKit.Controls.SplitContainer.Features.NestedSplittersPage")
			Me.Add(objLayout, "Ancoring", "")
			Me.Add(objLayout, "Flow Layout", "CompanionKit.Controls.FlowLayoutPanel.Functionality.FlowDirectionPage")
			Me.Add(objLayout, "Table Layout", "CompanionKit.Controls.TableLayoutPanel.Functionality.AddingControlPage")
			Me.Add(objLayout, "Windows Layout", "")
			Dim objData As TreeNode = Me.Add(objTree, "Data Behaviors", 2, 2)
			Me.Add(objData, "List Data Binding", "")
			Me.Add(objData, "Binding Navigator", "")
			objTree.ExpandAll()
			Dim objBehaviorsTab As New NavigationTab("Behaviors")
			objBehaviorsTab.Controls.Add(objTree)
			Return objBehaviorsTab
		End Function

		''' <summary>
		''' Populate Controls tab
		''' </summary>
		Private Function CreateControlsTab() As NavigationTab
			Dim objTree As New Gizmox.WebGUI.Forms.TreeView
			Me.InitTree(objTree)
			Dim objInput As TreeNode = Me.Add(objTree, "Input Controls", 2, 2)
			Me.Add(objInput, "Text", "CompanionKit.Controls.TextBox.Functionality.CharacterCasingPage")
			Me.Add(objInput, "Lists", "CompanionKit.Controls.ListBox.Appearance.TextWithColorPage")
			Me.Add(objInput, "DateTimePicker", "CompanionKit.Controls.DateTimePicker.Features.FormatPropertyPage")
			Me.Add(objInput, "MonthCalendar", "CompanionKit.Controls.MonthCalendar.Programming.SettingValuePage")
			Me.Add(objInput, "TrackBar", "CompanionKit.Controls.TrackBar.Functionality.BoundsPage")
			Me.Add(objInput, "RichTextBox", "CompanionKit.Controls.RichTextBox.Functionality.AddingToFormPage")
			Me.Add(objInput, "RichTextEditor", "CompanionKit.Controls.RibbonBar.ApplicationScenario.TextEditingApplicationPage")
			objInput.Expand()
			Dim objAction As TreeNode = Me.Add(objTree, "Action Controls", 2, 2)
			Me.Add(objAction, "ContextMenu", "CompanionKit.Controls.ContextMenu.Programming.CollapsePage")
			Me.Add(objAction, "Button", "CompanionKit.Controls.Button.Functionality.DropDownMenuPage")
			Me.Add(objAction, "ToolBar", "CompanionKit.Controls.ToolBar.Appearance.ToolBarButtonStylePage")
			objTree.SelectedNode = Me.Add(objAction, "RibbonBar", "CompanionKit.Controls.RibbonBar.ApplicationScenario.TextEditingApplicationPage")
			objAction.Expand()
			Dim objNavigation As TreeNode = Me.Add(objTree, "Navigation Controls", 2, 2)
			Me.Add(objNavigation, "TabControl", "CompanionKit.Controls.TabControl.Appearance.TextWithImagePage")
			Me.Add(objNavigation, "NavigationTabs", "CompanionKit.Controls.NavigationTabs.Appearance.TextWithImagePage")
			Me.Add(objNavigation, "WorkspaceTabs", "")
			objNavigation.Collapse()
			Dim objTabControls As New NavigationTab("Controls")
			objTabControls.Controls.Add(objTree)
			Return objTabControls
		End Function

		''' <summary>
		''' Populate Extra tab - Data Controls
		''' </summary>
		Private Function CreateDataControlsTab() As NavigationTab
			Dim objTree As New Gizmox.WebGUI.Forms.TreeView
			Me.InitTree(objTree)
			Dim objData As TreeNode = Me.Add(objTree, "Data Controls", 2, 2)
			Me.Add(objData, "TreeView", "CompanionKit.Controls.TreeView.Features.CheckBoxesPage")
			objTree.SelectedNode = Me.Add(objData, "ListView", "CompanionKit.Controls.ListView.Features.ChangeColumnOptionsPage")
			Me.Add(objData, "DataGridView", "CompanionKit.Controls.DataGridView.Appearance.AlternatingStylePage")
			Me.Add(objData, "Charting", "")
			Me.Add(objData, "ScheduleBox", "CompanionKit.Controls.ScheduleBox.Appearance.ScheduleBoxViewPropertiesPage")
			Me.Add(objData, "PropertyGrid", "CompanionKit.Controls.PropertyGrid.Functionality.PropertyDescriptionPage")
			objData.Expand()
			Me.mobjExtraTab1.Controls.Add(objTree)
			Return Me.mobjExtraTab1
		End Function

		''' <summary>
		''' 
		''' </summary>
		Private Function CreateDialogsTab() As NavigationTab
			Dim objTree As New Gizmox.WebGUI.Forms.TreeView
			Me.InitTree(objTree)
			Dim objDialogs As TreeNode = Me.Add(objTree, "Dialogs", 2, 2)
			Me.Add(objDialogs, "MessageBox", "")
			objTree.SelectedNode = Me.Add(objDialogs, "Font Dialog", "CompanionKit.Controls.CommonDialogs.FontDialog.Features.ShowEffectsPage")
			Me.Add(objDialogs, "Search Dialog", "")
			Me.Add(objDialogs, "Color Dialog", "CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality.SettingColorPage")
			objDialogs.Expand()
			Dim objDialogsTab As New NavigationTab("Dialogs")
			objDialogsTab.Controls.Add(objTree)
			Return objDialogsTab
		End Function

		''' <summary>
		''' Populate Extra tab - Host Controls
		''' </summary>
		Private Function CreateHostControlsTab() As NavigationTab
			Dim objTree As New Gizmox.WebGUI.Forms.TreeView
			Me.InitTree(objTree)
			Dim objHost As TreeNode = Me.Add(objTree, "Host Controls", 2, 2)
			Me.Add(objHost, "XamlBox", "CompanionKit.Controls.XamlBox.Programming.ProvideParametersPage")
			objTree.SelectedNode = Me.Add(objHost, "FlashBox", "CompanionKit.Controls.FlashBox.Programming.ProvideParametersPage")
			Me.Add(objHost, "Graph", "")
			Me.Add(objHost, "AspPageBox", "CompanionKit.Controls.AspPageBox.Functionality.InteractWithASPNETPage")
			objHost.Expand()
			Me.mobjExtraTab2.Controls.Add(objTree)
			Return Me.mobjExtraTab1
		End Function

		Private Function CreateStub() As UserControl
			Dim objControl As New UserControl
			objControl.BorderStyle = BorderStyle.FixedSingle
			objControl.BorderWidth = 1
			objControl.BorderColor = Color.LightSteelBlue
			Dim objLabel As New Label(String.Concat(New String() {"There is no snippet associated with clicked node.", Environment.NewLine, "It's under construction.", Environment.NewLine, "Feel free to send us interesting snippets and code fragments!"}))
			objLabel.ForeColor = Color.Blue
			objLabel.Location = New Point(10, 10)
			objLabel.Size = New Size(300, 50)
			objLabel.TextAlign = ContentAlignment.MiddleLeft
			objControl.Controls.Add(objLabel)
			Dim image As New Gizmox.WebGUI.Forms.PictureBox
			image.Image = New ImageResourceHandle("uc.jpg")
			image.Location = New Point(10, 70)
			image.Size = New Size(210, 240)
			objControl.Controls.Add(image)
			Return objControl
		End Function

		Private Sub FillNavigationTabs(ByVal sender As Object, ByVal e As EventArgs)
			Dim tabImages As New ImageList
			tabImages.Images.Add(New ImageResourceHandle("24X24.Controls.gif"))
			tabImages.Images.Add(New ImageResourceHandle("24X24.Behaviors.gif"))
			tabImages.Images.Add(New ImageResourceHandle("24X24.Folders.gif"))
			Me.mobjNavigationTabs.ImageList = tabImages
			AddHandler Me.mobjNavigationTabs.SelectedIndexChanged, New EventHandler(AddressOf Me.NavigationTabs_IndexChanged)
			Dim objTabControls As NavigationTab = Me.CreateControlsTab
			Dim objTabBehaviors As NavigationTab = Me.CreateBehaviorsTab
			Dim objTabDialogs As NavigationTab = Me.CreateDialogsTab
			objTabControls.ImageIndex = 0
			objTabBehaviors.ImageIndex = 1
			objTabDialogs.ImageIndex = 2
			Me.mobjNavigationTabs.Controls.Add(objTabControls)
			Me.mobjNavigationTabs.Controls.Add(objTabBehaviors)
			Me.mobjNavigationTabs.Controls.Add(objTabDialogs)
			Me.mobjExtraTab1.ImageIndex = 1
			Me.mobjExtraTab2.ImageIndex = 2
			Me.CreateDataControlsTab()
			Me.CreateHostControlsTab()
			Me.mobjNavigationTabs.SelectedItem = objTabControls
		End Sub

		''' <summary>
		''' Initialize tree  - images, border, event handler
		''' </summary>
		Private Sub InitTree(ByVal objTree As Gizmox.WebGUI.Forms.TreeView)
			objTree.BorderStyle = BorderStyle.None
			objTree.Dock = DockStyle.Fill
			objTree.ImageList = New ImageList
			objTree.ImageList.Images.Add(New ImageResourceHandle("16x16.SelectedTreeNode.gif"))
			objTree.ImageList.Images.Add(New ImageResourceHandle("16x16.DefaultTreeNode.gif"))
			objTree.ImageList.Images.Add(New ImageResourceHandle("16x16.EmptyTreeNode.gif"))
			objTree.ImageIndex = 1
			objTree.SelectedImageIndex = 0
			AddHandler objTree.AfterSelect, New TreeViewEventHandler(AddressOf Me.AfterSelect)
		End Sub

		''' <summary>
		''' Handles the IndexChanged event of the NavigationTabs control.
		''' Raise AfterSelect event to ensure redraw of right-side panel.
		''' </summary>
		Private Sub NavigationTabs_IndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim tabs As Gizmox.WebGUI.Forms.NavigationTabs = TryCast(sender, Gizmox.WebGUI.Forms.NavigationTabs)
			If (Not tabs Is Nothing) Then
				Dim tab As NavigationTab = TryCast(tabs.SelectedItem, NavigationTab)
				If ((Not tab Is Nothing) AndAlso (tab.Controls.Count > 0)) Then
					Dim objTree As Gizmox.WebGUI.Forms.TreeView = TryCast(tab.Controls.Item(0), Gizmox.WebGUI.Forms.TreeView)
					If ((Not objTree Is Nothing) AndAlso (Not objTree.SelectedNode Is Nothing)) Then
						Me.AfterSelect(objTree, New TreeViewEventArgs(objTree.SelectedNode))
					End If
				End If
			End If
		End Sub

	End Class



End Namespace