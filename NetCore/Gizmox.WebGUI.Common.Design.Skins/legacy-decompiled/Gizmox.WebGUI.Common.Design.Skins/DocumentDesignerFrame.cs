using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Gizmox.WebGUI.Common.Design.Skins.Forms;
using Gizmox.WebGUI.Common.Design.Skins.Properties;

namespace Gizmox.WebGUI.Common.Design.Skins;

internal class DocumentDesignerFrame : UserControl
{
	private DesignerVerb mobjDeleteResourcesVerb;

	private DocumentDesinger mobjDocumentDesinger;

	private DesignerVerb mobjOverrideResourcesVerb;

	private DesignerVerb mobjResetAllSkinVerb;

	private IContainer components;

	private SplitContainer mobjMainSplitContainer;

	private Panel groupBox1;

	private DocumentDesignerTree mobjDocumentDesignerTree;

	private ToolStrip mobjSkinsToolStrip;

	private Panel groupBox2;

	private DocumentDesignerList mobjDocumentDesignerList;

	private ToolStrip toolStrip1;

	private ToolStripDropDownButton toolStripDropDownButton1;

	private ToolStripMenuItem imagesToolStripMenuItem;

	private ToolStripMenuItem styleSheetsToolStripMenuItem;

	private ToolStripMenuItem scriptsToolStripMenuItem;

	private ToolStripMenuItem templatesXSLTToolStripMenuItem;

	private ToolStripMenuItem otherToolStripMenuItem;

	private ToolStripDropDownButton toolStripDropDownButton2;

	private ToolStripMenuItem addExistingFileToolStripMenuItem;

	private ToolStripSeparator toolStripMenuItem1;

	private ToolStripMenuItem addNewToolStripMenuItem;

	private ToolStripButton mobjRemoveResourceButton;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripDropDownButton toolStripDropDownButton3;

	private ToolStripMenuItem viewInListToolStripMenuItem;

	private ToolStripMenuItem viewDetailsToolStripMenuItem;

	private ToolStripMenuItem viewAsThumbnailsToolStripMenuItem;

	private Label label2;

	private Label label1;

	private ToolStripMenuItem htmlToolStripMenuItem;

	private ToolStripSeparator toolStripMenuItem3;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripButton mobjHelpToolStripButton;

	private FolderBrowserDialog mobjFolderBrowserDialog;

	private ToolStripButton mobjImportToolStripDropDownButton;

	private ToolStripButton mobjExportToolStripDropDownButton;

	private ToolStripMenuItem textToolStripMenuItem;

	internal IComponent Component => mobjDocumentDesinger.Component;

	public Graphics DrawingGraphics => Graphics.FromHwnd(base.Handle);

	private bool IsSkinDesigner => mobjDocumentDesinger is SkinDocumentDesigner;

	internal bool IsThemeDesigner => mobjDocumentDesinger is ThemeDocumentDesigner;

	public DocumentDesignerList List => mobjDocumentDesignerList;

	public ToolStripButton RemoveResourceButton => mobjRemoveResourceButton;

	public DocumentDesignerTree Tree => mobjDocumentDesignerTree;

	public DocumentDesignerFrame(DocumentDesinger objDocumentDesinger)
	{
		mobjDocumentDesinger = objDocumentDesinger;
		InitializeComponent();
		InitializeVerbs();
	}

	public DocumentDesignerFrame()
	{
		InitializeComponent();
	}

	public void ResumeDesignerNotifications()
	{
		if (mobjDocumentDesinger != null)
		{
			mobjDocumentDesinger.ResumeDesignerNotifications();
		}
	}

	public void SuspendDesignerNotifications()
	{
		if (mobjDocumentDesinger != null)
		{
			mobjDocumentDesinger.SuspendDesignerNotifications();
		}
	}

	protected override object GetService(Type service)
	{
		if (service == typeof(ThemeDocumentDesigner) && IsThemeDesigner)
		{
			return mobjDocumentDesinger;
		}
		if (mobjDocumentDesinger != null)
		{
			object serviceInternal = mobjDocumentDesinger.GetServiceInternal(service);
			if (serviceInternal != null)
			{
				return serviceInternal;
			}
		}
		return base.GetService(service);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (IsThemeDesigner)
		{
			mobjMainSplitContainer.Panel1Collapsed = false;
			mobjDocumentDesignerList.Initialize(this);
			mobjDocumentDesignerTree.Initialize(this);
		}
		else if (IsSkinDesigner)
		{
			mobjMainSplitContainer.Panel1Collapsed = true;
			mobjDocumentDesignerList.Initialize(this);
			mobjDocumentDesignerList.SetSelection(Component);
		}
		UpdateToolStripMenus();
	}

	private void InitializeSkinsToolStrip(TreeNode objTreeNode)
	{
		bool enabled = objTreeNode != null && IsTheme(objTreeNode.Tag);
		mobjExportToolStripDropDownButton.Enabled = enabled;
		mobjImportToolStripDropDownButton.Enabled = enabled;
	}

	private void InitializeVerbs()
	{
		mobjOverrideResourcesVerb = new DesignerVerb("Override", OnExecuteVerb);
		mobjDeleteResourcesVerb = new DesignerVerb("Delete", OnExecuteVerb, StandardCommands.Delete);
		mobjResetAllSkinVerb = new DesignerVerb("Reset", OnExecuteVerb, StandardCommands.Delete);
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService != null)
		{
			selectionService.SelectionChanged += OnApplyVerbs;
		}
	}

	private bool IsDeletableResources(ISelectionService objSelectionService)
	{
		IComponent selectedComponent = mobjDocumentDesignerList.SelectedComponent;
		if (selectedComponent != null)
		{
			foreach (object selectedComponent2 in objSelectionService.GetSelectedComponents())
			{
				if (!IsResource(selectedComponent2))
				{
					return false;
				}
				if (DocumentUtils.IsInherited(selectedComponent, selectedComponent2))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool IsOverridableResources(ISelectionService objSelectionService)
	{
		IComponent selectedComponent = mobjDocumentDesignerList.SelectedComponent;
		if (selectedComponent != null)
		{
			foreach (object selectedComponent2 in objSelectionService.GetSelectedComponents())
			{
				if (!IsResource(selectedComponent2))
				{
					return false;
				}
				if (!DocumentUtils.IsInherited(selectedComponent, selectedComponent2))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool IsResource(object objComponent)
	{
		if (objComponent != null)
		{
			return mobjDocumentDesinger.ResourceType.IsAssignableFrom(objComponent.GetType());
		}
		return false;
	}

	private bool IsResourceSelection(ISelectionService objSelectionService)
	{
		foreach (object selectedComponent in objSelectionService.GetSelectedComponents())
		{
			if (IsResource(selectedComponent))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsSingleSelection(ISelectionService objSelectionService)
	{
		return objSelectionService.SelectionCount == 1;
	}

	internal bool IsSkin(object objComponent)
	{
		if (objComponent != null)
		{
			return mobjDocumentDesinger.SkinType.IsAssignableFrom(objComponent.GetType());
		}
		return false;
	}

	private bool IsSkinSelection(ISelectionService objSelectionService)
	{
		foreach (object selectedComponent in objSelectionService.GetSelectedComponents())
		{
			if (IsSkin(selectedComponent))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsTheme(object objComponent)
	{
		if (objComponent != null)
		{
			return mobjDocumentDesinger.ThemeType.IsAssignableFrom(objComponent.GetType());
		}
		return false;
	}

	private bool IsThemeSelection(ISelectionService objSelectionService)
	{
		foreach (object selectedComponent in objSelectionService.GetSelectedComponents())
		{
			if (IsTheme(selectedComponent))
			{
				return true;
			}
		}
		return false;
	}

	private void OnAddExistingFileClick(object sender, EventArgs e)
	{
		try
		{
			mobjDocumentDesignerList.AddExistingFile();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void OnAddNewFileClick(object sender, EventArgs e)
	{
		try
		{
			mobjDocumentDesignerList.AddNewFile();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void OnAfterTreeSelection(object sender, TreeViewEventArgs e)
	{
		InitializeSkinsToolStrip(e.Node);
		IServiceContainer serviceContainer = (IServiceContainer)GetService(typeof(IServiceContainer));
		if (serviceContainer != null)
		{
			if (serviceContainer.GetService(mobjDocumentDesinger.SkinType) != null)
			{
				serviceContainer.RemoveService(mobjDocumentDesinger.SkinType);
			}
			if (serviceContainer.GetService(mobjDocumentDesinger.ThemeType) != null)
			{
				serviceContainer.RemoveService(mobjDocumentDesinger.ThemeType);
			}
			if (IsSkin(e.Node.Tag))
			{
				serviceContainer.AddService(mobjDocumentDesinger.SkinType, e.Node.Tag);
			}
			else if (IsTheme(e.Node.Tag))
			{
				serviceContainer.AddService(mobjDocumentDesinger.ThemeType, e.Node.Tag);
			}
		}
		if (IsThemeDesigner)
		{
			mobjDocumentDesignerList.SetSelection(e.Node.Tag as IComponent);
		}
	}

	private void OnApplyVerbs(object sender, EventArgs e)
	{
		RefreshVerbs();
	}

	private void OnDeleteFileClick(object sender, EventArgs e)
	{
		mobjDocumentDesignerList.DeleteResources();
	}

	private void OnDeleteResourcesClick(ISelectionService objSelectionService)
	{
		mobjDocumentDesignerList.DeleteResources();
		mobjDocumentDesignerList.ResetSelection();
		RefreshVerbs();
	}

	private void OnExecuteVerb(object sender, EventArgs e)
	{
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService != null)
		{
			if (sender == mobjOverrideResourcesVerb)
			{
				OnOverrideResourcesClick(selectionService);
			}
			else if (sender == mobjDeleteResourcesVerb)
			{
				OnDeleteResourcesClick(selectionService);
			}
			else if (sender == mobjResetAllSkinVerb)
			{
				OnResetSkinClick(selectionService);
			}
		}
	}

	private void OnExportResources(object sender, EventArgs e)
	{
		ExportForm exportForm = new ExportForm();
		if (exportForm.ShowDialog() == DialogResult.OK && exportForm.SelectedResourceTypes.Length != 0 && mobjDocumentDesinger is ThemeDocumentDesigner objThemeDocumentDesigner)
		{
			mobjFolderBrowserDialog.Description = "Select a folder which will contain exported resources.";
			mobjFolderBrowserDialog.ShowNewFolderButton = true;
			if (mobjFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(mobjFolderBrowserDialog.SelectedPath))
			{
				new ProgressForm(objThemeDocumentDesigner, mobjFolderBrowserDialog.SelectedPath, exportForm.SelectedResourceTypes).ShowDialog();
			}
		}
	}

	private void OnHelpClick(object sender, EventArgs e)
	{
		object obj = null;
		obj = ((mobjDocumentDesignerTree == null || mobjDocumentDesignerTree.SelectedNode == null || mobjDocumentDesignerTree.SelectedNode.Tag == null) ? Component : mobjDocumentDesignerTree.SelectedNode.Tag);
		if (obj != null && GetService(typeof(IHelpService)) is IHelpService helpService)
		{
			Type type = obj.GetType();
			helpService.ShowHelpFromKeyword(type.FullName);
		}
	}

	private void OnImportResources(object sender, EventArgs e)
	{
		if (mobjDocumentDesinger is ThemeDocumentDesigner objThemeDocumentDesigner)
		{
			mobjFolderBrowserDialog.Description = "Select a folder which contains the resources to be imported.";
			mobjFolderBrowserDialog.ShowNewFolderButton = true;
			if (mobjFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(mobjFolderBrowserDialog.SelectedPath) && new ProgressForm(objThemeDocumentDesigner, mobjFolderBrowserDialog.SelectedPath).ShowDialog() == DialogResult.OK)
			{
				OnComponentChanged();
			}
		}
	}

	private void OnOverrideResourcesClick(ISelectionService objSelectionService)
	{
		foreach (object selectedComponent in objSelectionService.GetSelectedComponents())
		{
			if (IsResource(selectedComponent))
			{
				mobjDocumentDesignerList.OnResourceOverride(selectedComponent);
			}
		}
		mobjDocumentDesignerList.ResetSelection();
		RefreshVerbs();
	}

	private void OnResetSkinClick(ISelectionService objSelectionService)
	{
		SkinResourcesResetForm skinResourcesResetForm = new SkinResourcesResetForm();
		if (skinResourcesResetForm.ShowDialog() == DialogResult.OK)
		{
			if (mobjDocumentDesignerList.ResetSkinDefinitions(skinResourcesResetForm.ResetProperties, skinResourcesResetForm.ResetResources))
			{
				mobjDocumentDesignerTree.ResetSelection();
			}
			RefreshVerbs();
		}
	}

	private void OnResetSkinClick(object sender, EventArgs e)
	{
		mobjDocumentDesignerList.ResetSkinDefinitions(blnResetProperties: true, blnResetResources: true);
	}

	private void OnResetSkinPropertiesClick(object sender, EventArgs e)
	{
		mobjDocumentDesignerList.ResetSkinDefinitions(blnResetProperties: true, blnResetResources: false);
	}

	private void OnResetSkinResourcesClick(object sender, EventArgs e)
	{
		mobjDocumentDesignerList.ResetSkinDefinitions(blnResetProperties: false, blnResetResources: true);
	}

	private void OnResourceFilterChangeClick(object sender, EventArgs e)
	{
		if (!(sender is ToolStripMenuItem toolStripMenuItem))
		{
			return;
		}
		if (toolStripMenuItem.OwnerItem is ToolStripDropDownButton toolStripDropDownButton)
		{
			foreach (ToolStripItem dropDownItem in toolStripDropDownButton.DropDownItems)
			{
				if (dropDownItem is ToolStripMenuItem toolStripMenuItem2 && toolStripMenuItem2 != toolStripMenuItem)
				{
					toolStripMenuItem2.Checked = false;
				}
			}
			toolStripDropDownButton.Image = toolStripMenuItem.Image;
			toolStripDropDownButton.Text = toolStripMenuItem.Text;
			toolStripDropDownButton.Tag = toolStripMenuItem.Tag;
		}
		toolStripMenuItem.Checked = true;
		mobjDocumentDesignerList.SetFilter((string)toolStripMenuItem.Tag);
		UpdateToolStripMenus();
	}

	private void OnViewChangeClick(object sender, EventArgs e)
	{
		if (!(sender is ToolStripMenuItem toolStripMenuItem))
		{
			return;
		}
		if (toolStripMenuItem.OwnerItem is ToolStripDropDownButton toolStripDropDownButton)
		{
			foreach (ToolStripItem dropDownItem in toolStripDropDownButton.DropDownItems)
			{
				if (dropDownItem is ToolStripMenuItem toolStripMenuItem2 && toolStripMenuItem2 != toolStripMenuItem)
				{
					toolStripMenuItem2.Checked = false;
				}
			}
		}
		toolStripMenuItem.Checked = true;
		mobjDocumentDesignerList.SetView((string)toolStripMenuItem.Tag);
	}

	private void RefreshVerbs()
	{
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService == null || selectionService.SelectionCount <= 0)
		{
			return;
		}
		bool flag = IsSingleSelection(selectionService);
		bool flag2 = IsThemeSelection(selectionService);
		bool flag3 = IsSkinSelection(selectionService);
		bool flag4 = IsResourceSelection(selectionService);
		IMenuCommandService menuCommandService = (IMenuCommandService)GetService(typeof(IMenuCommandService));
		if (menuCommandService == null)
		{
			return;
		}
		if (flag4 && !flag3 && !flag2)
		{
			mobjOverrideResourcesVerb.Enabled = IsOverridableResources(selectionService);
			mobjDeleteResourcesVerb.Enabled = IsDeletableResources(selectionService);
			if (!menuCommandService.Verbs.Contains(mobjOverrideResourcesVerb))
			{
				menuCommandService.Verbs.Add(mobjOverrideResourcesVerb);
			}
			if (!menuCommandService.Verbs.Contains(mobjDeleteResourcesVerb))
			{
				menuCommandService.Verbs.Add(mobjDeleteResourcesVerb);
			}
		}
		if (flag3 && flag && !menuCommandService.Verbs.Contains(mobjResetAllSkinVerb))
		{
			menuCommandService.Verbs.Add(mobjResetAllSkinVerb);
		}
	}

	private void UpdateToolStripMenus()
	{
		switch (Convert.ToString(toolStripDropDownButton1.Tag))
		{
		case "ImageResource":
		case "StyleSheetResource":
		case "ScriptResource":
		case "TemplateResource":
		case "HtmlResource":
		case "KeyedTextFileResource":
			addNewToolStripMenuItem.Enabled = true;
			break;
		case "FileResource":
			addNewToolStripMenuItem.Enabled = false;
			break;
		}
	}

	internal object GetServiceInternal(Type objServiceType)
	{
		return GetService(objServiceType);
	}

	internal void OnComponentChanged()
	{
		((IComponentChangeService)GetService(typeof(IComponentChangeService)))?.OnComponentChanged(mobjDocumentDesinger.Component, null, null, null);
	}

	internal void ShowContextMenu()
	{
		((IMenuCommandService)GetService(typeof(IMenuCommandService)))?.ShowContextMenu(MenuCommands.SelectionMenu, Control.MousePosition.X, Control.MousePosition.Y);
	}

	public object GetSkinValueResources(object objSkinInstance)
	{
		return DocumentUtils.GetPropertyValue(objSkinInstance, "ValueResources");
	}

	internal void EnableDeleteResourcesVerb(bool blnEnable)
	{
		if (blnEnable)
		{
			ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
			if (selectionService != null)
			{
				mobjDeleteResourcesVerb.Enabled = IsDeletableResources(selectionService);
			}
		}
		else
		{
			mobjDeleteResourcesVerb.Enabled = false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.mobjMainSplitContainer = new System.Windows.Forms.SplitContainer();
		this.groupBox1 = new System.Windows.Forms.Panel();
		this.mobjDocumentDesignerTree = new Gizmox.WebGUI.Common.Design.Skins.DocumentDesignerTree();
		this.mobjSkinsToolStrip = new System.Windows.Forms.ToolStrip();
		this.mobjExportToolStripDropDownButton = new System.Windows.Forms.ToolStripButton();
		this.mobjImportToolStripDropDownButton = new System.Windows.Forms.ToolStripButton();
		this.label2 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.Panel();
		this.mobjDocumentDesignerList = new Gizmox.WebGUI.Common.Design.Skins.DocumentDesignerList();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
		this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.styleSheetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.templatesXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.htmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
		this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
		this.addExistingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mobjRemoveResourceButton = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
		this.viewInListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.viewAsThumbnailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.mobjHelpToolStripButton = new System.Windows.Forms.ToolStripButton();
		this.label1 = new System.Windows.Forms.Label();
		this.mobjFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
		((System.ComponentModel.ISupportInitialize)this.mobjMainSplitContainer).BeginInit();
		this.mobjMainSplitContainer.Panel1.SuspendLayout();
		this.mobjMainSplitContainer.Panel2.SuspendLayout();
		this.mobjMainSplitContainer.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.mobjSkinsToolStrip.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		base.SuspendLayout();
		this.mobjMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.mobjMainSplitContainer.Location = new System.Drawing.Point(6, 6);
		this.mobjMainSplitContainer.Name = "mobjMainSplitContainer";
		this.mobjMainSplitContainer.Panel1.Controls.Add(this.groupBox1);
		this.mobjMainSplitContainer.Panel2.Controls.Add(this.groupBox2);
		this.mobjMainSplitContainer.Size = new System.Drawing.Size(664, 506);
		this.mobjMainSplitContainer.SplitterDistance = 220;
		this.mobjMainSplitContainer.TabIndex = 0;
		this.groupBox1.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
		this.groupBox1.Controls.Add(this.mobjDocumentDesignerTree);
		this.groupBox1.Controls.Add(this.mobjSkinsToolStrip);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Location = new System.Drawing.Point(0, 0);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
		this.groupBox1.Size = new System.Drawing.Size(220, 506);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.Text = "Skins";
		this.mobjDocumentDesignerTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.mobjDocumentDesignerTree.Dock = System.Windows.Forms.DockStyle.Fill;
		this.mobjDocumentDesignerTree.HideSelection = false;
		this.mobjDocumentDesignerTree.ImageIndex = 0;
		this.mobjDocumentDesignerTree.Location = new System.Drawing.Point(1, 46);
		this.mobjDocumentDesignerTree.Name = "mobjDocumentDesignerTree";
		this.mobjDocumentDesignerTree.SelectedImageIndex = 0;
		this.mobjDocumentDesignerTree.ShowNodeToolTips = true;
		this.mobjDocumentDesignerTree.ShowRootLines = false;
		this.mobjDocumentDesignerTree.Size = new System.Drawing.Size(218, 459);
		this.mobjDocumentDesignerTree.TabIndex = 0;
		this.mobjDocumentDesignerTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(OnAfterTreeSelection);
		this.mobjSkinsToolStrip.AutoSize = false;
		this.mobjSkinsToolStrip.BackColor = System.Drawing.Color.FromArgb(220, 229, 239);
		this.mobjSkinsToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
		this.mobjSkinsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.mobjSkinsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.mobjExportToolStripDropDownButton, this.mobjImportToolStripDropDownButton });
		this.mobjSkinsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.mobjSkinsToolStrip.Location = new System.Drawing.Point(1, 18);
		this.mobjSkinsToolStrip.Name = "mobjSkinsToolStrip";
		this.mobjSkinsToolStrip.Padding = new System.Windows.Forms.Padding(0, 2, 1, 0);
		this.mobjSkinsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.mobjSkinsToolStrip.Size = new System.Drawing.Size(218, 28);
		this.mobjSkinsToolStrip.TabIndex = 1;
		this.mobjSkinsToolStrip.Text = "toolStrip1";
		this.mobjExportToolStripDropDownButton.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.export;
		this.mobjExportToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Transparent;
		this.mobjExportToolStripDropDownButton.Name = "mobjExportToolStripDropDownButton";
		this.mobjExportToolStripDropDownButton.Size = new System.Drawing.Size(60, 20);
		this.mobjExportToolStripDropDownButton.Tag = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.txt_Template;
		this.mobjExportToolStripDropDownButton.Text = "Export";
		this.mobjExportToolStripDropDownButton.ToolTipText = "Export";
		this.mobjExportToolStripDropDownButton.Click += new System.EventHandler(OnExportResources);
		this.mobjImportToolStripDropDownButton.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.import;
		this.mobjImportToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Transparent;
		this.mobjImportToolStripDropDownButton.Name = "mobjImportToolStripDropDownButton";
		this.mobjImportToolStripDropDownButton.Size = new System.Drawing.Size(63, 20);
		this.mobjImportToolStripDropDownButton.Text = "Import";
		this.mobjImportToolStripDropDownButton.Click += new System.EventHandler(OnImportResources);
		this.label2.BackColor = System.Drawing.Color.FromArgb(255, 233, 217);
		this.label2.Dock = System.Windows.Forms.DockStyle.Top;
		this.label2.Location = new System.Drawing.Point(1, 1);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(218, 17);
		this.label2.TabIndex = 3;
		this.label2.Text = "Skins";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.groupBox2.BackColor = System.Drawing.Color.FromArgb(228, 228, 228);
		this.groupBox2.Controls.Add(this.mobjDocumentDesignerList);
		this.groupBox2.Controls.Add(this.toolStrip1);
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(0, 0);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
		this.groupBox2.Size = new System.Drawing.Size(440, 506);
		this.groupBox2.TabIndex = 2;
		this.groupBox2.Text = "Skin Resources";
		this.mobjDocumentDesignerList.AllowDrop = true;
		this.mobjDocumentDesignerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.mobjDocumentDesignerList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.mobjDocumentDesignerList.LabelEdit = true;
		this.mobjDocumentDesignerList.Location = new System.Drawing.Point(1, 46);
		this.mobjDocumentDesignerList.Name = "mobjDocumentDesignerList";
		this.mobjDocumentDesignerList.ShowItemToolTips = true;
		this.mobjDocumentDesignerList.Size = new System.Drawing.Size(438, 459);
		this.mobjDocumentDesignerList.TabIndex = 0;
		this.mobjDocumentDesignerList.UseCompatibleStateImageBehavior = false;
		this.mobjDocumentDesignerList.VirtualMode = true;
		this.toolStrip1.AutoSize = false;
		this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(220, 229, 239);
		this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.toolStripDropDownButton1, this.toolStripDropDownButton2, this.mobjRemoveResourceButton, this.toolStripSeparator2, this.toolStripDropDownButton3, this.toolStripSeparator1, this.mobjHelpToolStripButton });
		this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.toolStrip1.Location = new System.Drawing.Point(1, 18);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 1, 0);
		this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.toolStrip1.Size = new System.Drawing.Size(438, 28);
		this.toolStrip1.TabIndex = 1;
		this.toolStrip1.Text = "toolStrip1";
		this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.imagesToolStripMenuItem, this.styleSheetsToolStripMenuItem, this.scriptsToolStripMenuItem, this.templatesXSLTToolStripMenuItem, this.textToolStripMenuItem, this.htmlToolStripMenuItem, this.toolStripMenuItem3, this.otherToolStripMenuItem });
		this.toolStripDropDownButton1.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.image;
		this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
		this.toolStripDropDownButton1.Size = new System.Drawing.Size(74, 20);
		this.toolStripDropDownButton1.Tag = "ImageResource";
		this.toolStripDropDownButton1.Text = "Images";
		this.imagesToolStripMenuItem.Checked = true;
		this.imagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
		this.imagesToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.image;
		this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
		this.imagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.imagesToolStripMenuItem.Tag = "ImageResource";
		this.imagesToolStripMenuItem.Text = "Images";
		this.imagesToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.styleSheetsToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.css;
		this.styleSheetsToolStripMenuItem.Name = "styleSheetsToolStripMenuItem";
		this.styleSheetsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.styleSheetsToolStripMenuItem.Tag = "StyleSheetResource";
		this.styleSheetsToolStripMenuItem.Text = "Style Sheets";
		this.styleSheetsToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.scriptsToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.scripts;
		this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
		this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.scriptsToolStripMenuItem.Tag = "ScriptResource";
		this.scriptsToolStripMenuItem.Text = "Scripts";
		this.scriptsToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.templatesXSLTToolStripMenuItem.Checked = true;
		this.templatesXSLTToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
		this.templatesXSLTToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.xslt;
		this.templatesXSLTToolStripMenuItem.Name = "templatesXSLTToolStripMenuItem";
		this.templatesXSLTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.templatesXSLTToolStripMenuItem.Tag = "TemplateResource";
		this.templatesXSLTToolStripMenuItem.Text = "Templates";
		this.templatesXSLTToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.textToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.text;
		this.textToolStripMenuItem.Name = "textToolStripMenuItem";
		this.textToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.textToolStripMenuItem.Tag = "KeyedTextFileResource";
		this.textToolStripMenuItem.Text = "Text";
		this.textToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.htmlToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.html;
		this.htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
		this.htmlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.htmlToolStripMenuItem.Tag = "HtmlResource";
		this.htmlToolStripMenuItem.Text = "Html";
		this.htmlToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
		this.otherToolStripMenuItem.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.files;
		this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
		this.otherToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.otherToolStripMenuItem.Tag = "BinaryResource";
		this.otherToolStripMenuItem.Text = "Other";
		this.otherToolStripMenuItem.Click += new System.EventHandler(OnResourceFilterChangeClick);
		this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.addExistingFileToolStripMenuItem, this.toolStripMenuItem1, this.addNewToolStripMenuItem });
		this.toolStripDropDownButton2.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.newresource;
		this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
		this.toolStripDropDownButton2.Size = new System.Drawing.Size(109, 20);
		this.toolStripDropDownButton2.Text = "Add Resource";
		this.addExistingFileToolStripMenuItem.Name = "addExistingFileToolStripMenuItem";
		this.addExistingFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.addExistingFileToolStripMenuItem.Text = "Add Existing File";
		this.addExistingFileToolStripMenuItem.Click += new System.EventHandler(OnAddExistingFileClick);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
		this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
		this.addNewToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.addNewToolStripMenuItem.Text = "Add New...";
		this.addNewToolStripMenuItem.Click += new System.EventHandler(OnAddNewFileClick);
		this.mobjRemoveResourceButton.Enabled = false;
		this.mobjRemoveResourceButton.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.delete;
		this.mobjRemoveResourceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mobjRemoveResourceButton.Name = "mobjRemoveResourceButton";
		this.mobjRemoveResourceButton.Size = new System.Drawing.Size(121, 20);
		this.mobjRemoveResourceButton.Text = "Remove Resource";
		this.mobjRemoveResourceButton.Click += new System.EventHandler(OnDeleteFileClick);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
		this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.viewInListToolStripMenuItem, this.viewDetailsToolStripMenuItem, this.viewAsThumbnailsToolStripMenuItem });
		this.toolStripDropDownButton3.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.views;
		this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
		this.toolStripDropDownButton3.Size = new System.Drawing.Size(29, 20);
		this.toolStripDropDownButton3.Text = "toolStripDropDownButton3";
		this.toolStripDropDownButton3.ToolTipText = "Views";
		this.viewInListToolStripMenuItem.Name = "viewInListToolStripMenuItem";
		this.viewInListToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.viewInListToolStripMenuItem.Tag = "ViewInList";
		this.viewInListToolStripMenuItem.Text = "View In List";
		this.viewInListToolStripMenuItem.Click += new System.EventHandler(OnViewChangeClick);
		this.viewDetailsToolStripMenuItem.AutoToolTip = true;
		this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
		this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.viewDetailsToolStripMenuItem.Tag = "ViewDetails";
		this.viewDetailsToolStripMenuItem.Text = "View Details";
		this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(OnViewChangeClick);
		this.viewAsThumbnailsToolStripMenuItem.AutoToolTip = true;
		this.viewAsThumbnailsToolStripMenuItem.Checked = true;
		this.viewAsThumbnailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
		this.viewAsThumbnailsToolStripMenuItem.Name = "viewAsThumbnailsToolStripMenuItem";
		this.viewAsThumbnailsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.viewAsThumbnailsToolStripMenuItem.Tag = "ViewAsThumbnails";
		this.viewAsThumbnailsToolStripMenuItem.Text = "View As Thumbnails";
		this.viewAsThumbnailsToolStripMenuItem.Click += new System.EventHandler(OnViewChangeClick);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
		this.mobjHelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.mobjHelpToolStripButton.Image = Gizmox.WebGUI.Common.Design.Skins.Properties.Resources.Help;
		this.mobjHelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mobjHelpToolStripButton.Name = "mobjHelpToolStripButton";
		this.mobjHelpToolStripButton.Size = new System.Drawing.Size(23, 20);
		this.mobjHelpToolStripButton.ToolTipText = "Help";
		this.mobjHelpToolStripButton.Click += new System.EventHandler(OnHelpClick);
		this.label1.BackColor = System.Drawing.Color.FromArgb(255, 233, 217);
		this.label1.Dock = System.Windows.Forms.DockStyle.Top;
		this.label1.Location = new System.Drawing.Point(1, 1);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(438, 17);
		this.label1.TabIndex = 3;
		this.label1.Text = "Resources";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.mobjMainSplitContainer);
		base.Name = "DocumentDesignerFrame";
		base.Padding = new System.Windows.Forms.Padding(6);
		base.Size = new System.Drawing.Size(676, 518);
		this.mobjMainSplitContainer.Panel1.ResumeLayout(false);
		this.mobjMainSplitContainer.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mobjMainSplitContainer).EndInit();
		this.mobjMainSplitContainer.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.mobjSkinsToolStrip.ResumeLayout(false);
		this.mobjSkinsToolStrip.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		base.ResumeLayout(false);
	}
}
