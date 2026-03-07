using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.NavigationTabs.Appearance
{
    public partial class TextWithImagePage : UserControl
    {
		// A control to display when there is no associated snippet
		private UserControl mobjStubControl = null;

        public TextWithImagePage()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Populate Extra tab - Data Controls
		/// </summary>
		private NavigationTab CreateDataControlsTab()
		{
            Gizmox.WebGUI.Forms.TreeView objTree = new Gizmox.WebGUI.Forms.TreeView();
            InitTree(objTree);
            
			TreeNode objData = Add(objTree, "Data Controls",2,2);
            Add(objData, "TreeView", "CompanionKit.Controls.TreeView.Features.CheckBoxesPage");
            objTree.SelectedNode = Add(objData, "ListView", "CompanionKit.Controls.ListView.Features.ChangeColumnOptionsPage");
            Add(objData, "DataGridView", "CompanionKit.Controls.DataGridView.Appearance.AlternatingStylePage");
            Add(objData, "Charting", "");
            Add(objData, "ScheduleBox", "CompanionKit.Controls.ScheduleBox.Appearance.ScheduleBoxViewPropertiesPage");
            Add(objData, "PropertyGrid", "CompanionKit.Controls.PropertyGrid.Functionality.PropertyDescriptionPage");
			
            objData.Expand();

			// Create a tab and add populated tree
            mobjExtraTab1.Controls.Add(objTree);

			return mobjExtraTab1;
		}

		/// <summary>
		/// Populate Extra tab - Host Controls
		/// </summary>
		private NavigationTab CreateHostControlsTab()
		{
            Gizmox.WebGUI.Forms.TreeView objTree = new Gizmox.WebGUI.Forms.TreeView();
            InitTree(objTree);

            TreeNode objHost = Add(objTree, "Host Controls",2,2);
            Add(objHost, "XamlBox", "CompanionKit.Controls.XamlBox.Programming.ProvideParametersPage");
            objTree.SelectedNode = Add(objHost, "FlashBox", "CompanionKit.Controls.FlashBox.Programming.ProvideParametersPage");
            Add(objHost, "Graph", "");
            Add(objHost, "AspPageBox", "CompanionKit.Controls.AspPageBox.Functionality.InteractWithASPNETPage");

			objHost.Expand();

			// Create a tab and add populated tree
            mobjExtraTab2.Controls.Add(objTree);

			return mobjExtraTab1;
		}

		/// <summary>
		/// Populate Controls tab
		/// </summary>
        private NavigationTab CreateControlsTab()
        {
            Gizmox.WebGUI.Forms.TreeView objTree = new Gizmox.WebGUI.Forms.TreeView();
            InitTree(objTree);

            TreeNode objInput = Add(objTree, "Input Controls",2,2);
            Add(objInput, "Text", "CompanionKit.Controls.TextBox.Functionality.CharacterCasingPage");
            Add(objInput, "Lists", "CompanionKit.Controls.ListBox.Appearance.TextWithColorPage");
            Add(objInput, "DateTimePicker", "CompanionKit.Controls.DateTimePicker.Features.FormatPropertyPage");
            Add(objInput, "MonthCalendar", "CompanionKit.Controls.MonthCalendar.Programming.SettingValuePage");
            Add(objInput, "TrackBar", "CompanionKit.Controls.TrackBar.Functionality.BoundsPage");
            Add(objInput, "RichTextBox", "CompanionKit.Controls.RichTextBox.Functionality.AddingToFormPage");
            Add(objInput, "RichTextEditor", "CompanionKit.Controls.RibbonBar.ApplicationScenario.TextEditingApplicationPage");

			objInput.Expand();

            TreeNode objAction = Add(objTree,"Action Controls",2,2);
            Add(objAction, "ContextMenu", "CompanionKit.Controls.ContextMenu.Programming.CollapsePage");
            Add(objAction, "Button", "CompanionKit.Controls.Button.Functionality.DropDownMenuPage");
            Add(objAction, "ToolBar", "CompanionKit.Controls.ToolBar.Appearance.ToolBarButtonStylePage");
            objTree.SelectedNode = Add(objAction, "RibbonBar", "CompanionKit.Controls.RibbonBar.ApplicationScenario.TextEditingApplicationPage");
			objAction.Expand();

            TreeNode objNavigation = Add(objTree,"Navigation Controls",2,2);
            Add(objNavigation, "TabControl", "CompanionKit.Controls.TabControl.Appearance.TextWithImagePage");
            Add(objNavigation, "NavigationTabs", "CompanionKit.Controls.NavigationTabs.Appearance.TextWithImagePage");
            Add(objNavigation, "WorkspaceTabs", "");
            objNavigation.Collapse();

			// Create a tab and add populated tree
            NavigationTab objTabControls = new NavigationTab("Controls");
            objTabControls.Controls.Add(objTree);

			return objTabControls;
        }

        private NavigationTab CreateBehaviorsTab()
        {
            Gizmox.WebGUI.Forms.TreeView objTree = new Gizmox.WebGUI.Forms.TreeView();
            InitTree(objTree);

            TreeNode objVisual= Add(objTree, "Visual Behaviors",2,2);
            Add(objVisual, "Background Image", "");

            TreeNode objMisc = Add(objTree, "Misc Behaviors",2,2);
            Add(objMisc, "Timers", "");
            Add(objMisc, "Context", "");
            Add(objMisc, "Resources", "");
            Add(objMisc, "Results", "CompanionKit.Controls.Form.Features.DialogReturnValuePage");
            objTree.SelectedNode = Add(objMisc, "Upload", "CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios.DisplayPicturePage");
            Add(objMisc, "Drag and Drop", "CompanionKit.Controls.TreeView.Features.NodesDragingPage");
            Add(objMisc, "Error Provider", "");

            TreeNode objLayout = Add(objTree, "Layout Behaviors",2,2);
            Add(objLayout, "Docking", "CompanionKit.Controls.StatusBar.Layouts.Docking");
            Add(objLayout, "SplitContainer", "CompanionKit.Controls.SplitContainer.Features.NestedSplittersPage");
            Add(objLayout, "Ancoring", "");
            Add(objLayout, "Flow Layout", "CompanionKit.Controls.FlowLayoutPanel.Functionality.FlowDirectionPage");
            Add(objLayout, "Table Layout", "CompanionKit.Controls.TableLayoutPanel.Functionality.AddingControlPage");
            Add(objLayout, "Windows Layout", "");

            TreeNode objData = Add(objTree, "Data Behaviors",2,2);
            Add(objData, "List Data Binding", "");
            Add(objData, "Binding Navigator", "");

            objTree.ExpandAll();

            NavigationTab objBehaviorsTab = new NavigationTab("Behaviors");
            objBehaviorsTab.Controls.Add(objTree);

            return objBehaviorsTab;
        }

        private NavigationTab CreateDialogsTab()
        {
            Gizmox.WebGUI.Forms.TreeView objTree = new Gizmox.WebGUI.Forms.TreeView();
            InitTree(objTree);

            TreeNode objDialogs = Add(objTree, "Dialogs",2,2);
            Add(objDialogs, "MessageBox", "");
            objTree.SelectedNode = Add(objDialogs, "Font Dialog", "CompanionKit.Controls.CommonDialogs.FontDialog.Features.ShowEffectsPage");
            Add(objDialogs, "Search Dialog", "");
            Add(objDialogs, "Color Dialog", "CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality.SettingColorPage");
			objDialogs.Expand();

            NavigationTab objDialogsTab = new NavigationTab("Dialogs");
            objDialogsTab.Controls.Add(objTree);
			
			return objDialogsTab;
        }

		/// <summary>
		/// Loads the associated snippet, when the node clicked
		/// </summary>
		void AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode objNode = e.Node;

			// Expand on click if collapsed
			if(objNode.Nodes.Count >0 && !objNode.IsExpanded)
				objNode.Expand();
			
			UserControl objControl = objNode.Tag as UserControl;

			// Initialize snippet(control) to display
			if (objControl == null)
			{
				string strUC = objNode.Tag as string;
				if (!string.IsNullOrEmpty(strUC))
				{
					string strType = string.Format("{1},{0}", "Gizmox.WebGUI.Forms.CompanionKit", strUC);
					Type objType = Type.GetType(strType, false);
					if (objType != null)
					{
						// Instantiate snippet(control) with border
						objControl = (UserControl)Activator.CreateInstance(objType);
						objControl.BorderStyle = BorderStyle.FixedSingle;
						objControl.BorderWidth = 1;
						objControl.BorderColor = Color.LightSteelBlue;
						if (objControl != null)
							objNode.Tag = objControl;
					}
				}

				// Instantiate stub-control if no associated control available
				if (string.IsNullOrEmpty(strUC) || objControl == null)
				{
						if (mobjStubControl == null)
							mobjStubControl = CreateStub();
						objControl = mobjStubControl;
				}
			}

			// Add snippet(control) to the right-side panel
			mobjSplitContainer.Panel2.Controls.Clear();
			if (objControl != null)
			{
				mobjSplitContainer.Panel2.Controls.Add(objControl);
				objControl.Dock = DockStyle.Fill;
			}

		}

		/// <summary>
		/// Create a stub control
		/// </summary>
		private UserControl CreateStub()
		{
			UserControl objControl = new UserControl();
			objControl.BorderStyle = BorderStyle.FixedSingle;
			objControl.BorderWidth = 1;
			objControl.BorderColor = Color.LightSteelBlue;

			Label objLabel = new Label(
				string.Concat(
				"There is no snippet associated with clicked node.", Environment.NewLine,
				"It's under construction.", Environment.NewLine,
				"Feel free to send us interesting snippets and code fragments!"));

			objLabel.ForeColor = Color.Blue;
			objLabel.Location = new Point(10,10);
			objLabel.Size = new Size(300,50);

			objLabel.TextAlign = ContentAlignment.MiddleLeft;
			objControl.Controls.Add(objLabel);

			// Add "under construction image"
			Gizmox.WebGUI.Forms.PictureBox image = new Gizmox.WebGUI.Forms.PictureBox();
			image.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("uc.jpg");
			image.Location = new Point(10,70);
			image.Size = new Size(210,240);
			objControl.Controls.Add(image);

			return objControl;
		}

		/// <summary>
		/// Add node to tree
		/// </summary>
		TreeNode Add(Gizmox.WebGUI.Forms.TreeView objTree, string strText, int intImageIndex, int intSelectedImageIndex)
		{
			TreeNode objAdded = new TreeNode(strText);
			objAdded.ImageIndex = intImageIndex;
			objAdded.SelectedImageIndex = intSelectedImageIndex;
			objTree.Nodes.Add(objAdded);
			return objAdded;
		}

		/// <summary>
		/// Add node to parent node
		/// </summary>
        private TreeNode Add(TreeNode objParentNode, string strText, string strTag)
        {
            TreeNode objNewNode = new TreeNode(strText);
            objNewNode.Tag = strTag;
			if (String.IsNullOrEmpty(strTag))
			{
				objNewNode.ImageIndex = 
				objNewNode.ExpandedImageIndex =
				objNewNode.SelectedImageIndex =2;
			}
            objParentNode.Nodes.Add(objNewNode);
			return objNewNode;
        }

		/// <summary>
		/// Initialize tree  - images, border, event handler
		/// </summary>
		void InitTree(Gizmox.WebGUI.Forms.TreeView objTree)
		{
            objTree.BorderStyle = BorderStyle.None;
			objTree.Dock = DockStyle.Fill;
            objTree.ImageList = new ImageList();
            objTree.ImageList.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.SelectedTreeNode.gif"));
            objTree.ImageList.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.DefaultTreeNode.gif"));
            objTree.ImageList.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.EmptyTreeNode.gif"));
			objTree.ImageIndex = 1;
            objTree.SelectedImageIndex = 0;
			objTree.AfterSelect += new TreeViewEventHandler(AfterSelect);
		}

        private void FillNavigationTabs(object sender, EventArgs e)
        {
            // Create ImageList for the demo NavigationTabs
            ImageList tabImages = new ImageList();
            tabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("24X24.Controls.gif"));
            tabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("24X24.Behaviors.gif"));
            tabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("24X24.Folders.gif"));

            this.mobjNavigationTabs.ImageList = tabImages;
			this.mobjNavigationTabs.SelectedIndexChanged += new EventHandler(NavigationTabs_IndexChanged);

			// Add populated tabs to NavigationTabs control
            NavigationTab objTabControls = CreateControlsTab();
            NavigationTab objTabBehaviors = CreateBehaviorsTab();
            NavigationTab objTabDialogs = CreateDialogsTab();

			objTabControls.ImageIndex = 0;
            objTabBehaviors.ImageIndex = 1;
            objTabDialogs.ImageIndex = 2;
			
            this.mobjNavigationTabs.Controls.Add(objTabControls);
            this.mobjNavigationTabs.Controls.Add(objTabBehaviors);
            this.mobjNavigationTabs.Controls.Add(objTabDialogs);
			
			// Extra tabs created with Designer
            this.mobjExtraTab1.ImageIndex = 1;
            this.mobjExtraTab2.ImageIndex = 2;
			
			// Populate content of extra tabs
			CreateDataControlsTab();
			CreateHostControlsTab();
			
			// Set initial Tab to display
            this.mobjNavigationTabs.SelectedItem = objTabControls;
        }

		/// <summary>
		/// Handles the IndexChanged event of the NavigationTabs control.
		/// Raise AfterSelect event to ensure redraw of right-side panel.
		/// </summary>
		void NavigationTabs_IndexChanged(object sender, EventArgs e)
		{
			Gizmox.WebGUI.Forms.NavigationTabs tabs = sender as Gizmox.WebGUI.Forms.NavigationTabs;
			if (tabs != null)
			{
				NavigationTab tab = tabs.SelectedItem as NavigationTab;
				if (tab != null && tab.Controls.Count >0)
				{
					Gizmox.WebGUI.Forms.TreeView objTree = tab.Controls[0] as Gizmox.WebGUI.Forms.TreeView;

					if (objTree != null && objTree.SelectedNode != null)
						AfterSelect(objTree, new TreeViewEventArgs(objTree.SelectedNode));
				}
			}
		}
    }
}