using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxBitmap(typeof(RibbonBar), "Office.RibbonBar_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
[ToolboxItem(true)]
[Skin(typeof(RibbonBarSkin))]
[MetadataTag("RBB")]
public class RibbonBar : UserControl, IRequiresRegistration
{
	public enum QuickAccessToolBarLocation
	{
		AboveRibbon,
		BellowRibbon
	}

	[Serializable]
	[Skin(typeof(RibbonBarTabControlSkin))]
	[ToolboxItem(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarTabControlController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarTabControlController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	public class RibbonBarTabControl : TabControl
	{
		public RibbonBarTabControl()
		{
			CustomStyle = "RibbonBar";
		}

		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.Parent is RibbonBar ribbonBar && ribbonBar.GetCriticalEventsData().HasEvent("SC"))
			{
				criticalEventsData.Set("SC");
			}
			return criticalEventsData;
		}

		protected override void OnExpand(bool blnClientSource)
		{
			base.OnExpand(blnClientSource);
			ValidateParentRibbon(blnClientSource);
		}

		protected override void OnCollapse(bool blnClientSource)
		{
			base.OnCollapse(blnClientSource);
			ValidateParentRibbon(blnClientSource);
		}

		private void ValidateParentRibbon(bool blnClientSource)
		{
			if (base.Parent is RibbonBar ribbonBar)
			{
				ribbonBar.ValidateRibbonLayout(blnClientSource);
			}
		}

		internal override void ValidateExpandAndDock(bool blnIsExpanded, DockStyle enmDockStyle, bool blnShowExpandButton)
		{
		}
	}

	[Serializable]
	[Skin(typeof(RibbonBarGroupBoxSkin))]
	[ToolboxItem(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarGroupBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarGroupBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	public class RibbonBarGroupBox : GroupBox
	{
		private bool mblnHasAdvanced;

		public bool HasAdvanced
		{
			get
			{
				return mblnHasAdvanced;
			}
			set
			{
				if (!mblnHasAdvanced)
				{
					mblnHasAdvanced = value;
					Update();
				}
			}
		}

		public event EventHandler AdvancedClicked;

		public RibbonBarGroupBox()
		{
			CustomStyle = "RibbonBar";
			Padding = new Padding(0);
		}

		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			if (objEvent.Type == "AdvancedClicked" && this.AdvancedClicked != null)
			{
				this.AdvancedClicked(this, EventArgs.Empty);
			}
		}

		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("ADV", mblnHasAdvanced ? "1" : "0");
		}
	}

	[Serializable]
	[Skin(typeof(RibbonBarButtonSkin))]
	[ToolboxItem(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarButtonController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarButtonController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	public class RibbonBarButton : Button
	{
		protected override bool SupportsKeyNavigation => true;

		public RibbonBarButton(string strCustomStyle)
		{
			CustomStyle = strCustomStyle;
		}
	}

	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarFlowLayoutPanelController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarFlowLayoutPanelController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ToolboxItem(false)]
	public class RibbonBarFlowLayoutPanel : FlowLayoutPanel
	{
	}

	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarPanelController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarPanelController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ToolboxItem(false)]
	public class RibbonBarPanel : Panel
	{
	}

	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarTextBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarTextBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ToolboxItem(false)]
	public class RibbonBarTextBox : TextBox
	{
	}

	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarCheckBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarCheckBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ToolboxItem(false)]
	public class RibbonBarCheckBox : CheckBox
	{
	}

	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarComboBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ClientController("Gizmox.WebGUI.Forms.Office.Design.Controllers.RibbonBarComboBoxController, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726")]
	[ToolboxItem(false)]
	public class RibbonBarComboBox : ComboBox
	{
	}

	private static SerializableProperty QuickAccessToolBarLocationProperty = SerializableProperty.Register("QuickAccessToolBarLocationProperty", typeof(QuickAccessToolBarLocation), typeof(RibbonBar), new SerializablePropertyMetadata(QuickAccessToolBarLocation.AboveRibbon));

	private static SerializableProperty ContextMenuItemsProperty = SerializableProperty.Register("ContextMenuItemsProperty", typeof(string[]), typeof(RibbonBar), new SerializablePropertyMetadata(null));

	private static SerializableProperty ShowQuickAccessToolbarProperty = SerializableProperty.Register("ShowQuickAccessToolbarProperty", typeof(bool), typeof(RibbonBar), new SerializablePropertyMetadata(false));

	private static SerializableProperty ShowStartButtonProperty = SerializableProperty.Register("ShowStartButtonProperty", typeof(bool[]), typeof(RibbonBar), new SerializablePropertyMetadata(false));

	private static SerializableProperty StartButtonOffsetProperty = SerializableProperty.Register("StartButtonOffsetProperty", typeof(int), typeof(RibbonBar), new SerializablePropertyMetadata(40));

	private static SerializableProperty RibbonBarStartMenuProperty = SerializableProperty.Register("RibbonBarStartMenuProperty", typeof(RibbonBarStartMenu), typeof(RibbonBar), new SerializablePropertyMetadata(null));

	private static SerializableProperty RibbonBarStartMenuPropertiesProperty = SerializableProperty.Register("RibbonBarStartMenuPropertiesProperty", typeof(RibbonBarStartMenuProperties), typeof(RibbonBar), new SerializablePropertyMetadata(null));

	private RibbonBarPageCollection mobjPages;

	private ToolTip mobjToolTipService;

	private bool mblnIsExpanding;

	private bool mblnOnResize;

	[NonSerialized]
	private IContainer components;

	private QuickAccessToolBar mobjQuickAccessToolBar;

	private RibbonBarStartButton mobjRibbonBarStartButton;

	private Panel mobjTopPanel;

	private RibbonBarTabControl mobjMainRibbonTabControl;

	[DefaultValue(DockStyle.Top)]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
			ValidateExpandAndDock(IsExpanded, value, ShowExpandButton);
			base.Dock = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonBarPageCollection Pages
	{
		get
		{
			if (mobjPages == null)
			{
				mobjPages = CreateTabPageCollection();
			}
			return mobjPages;
		}
	}

	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	public ContextualTabGroupCollection ContextualTabGroups => mobjMainRibbonTabControl.ContextualTabGroups;

	internal TabControl TabControl => mobjMainRibbonTabControl;

	public int SelectedIndex
	{
		get
		{
			return TabControl.SelectedIndex;
		}
		set
		{
			TabControl.SelectedIndex = value;
		}
	}

	internal ToolTip ToolTipService => mobjToolTipService;

	[Editor("Gizmox.WebGUI.Forms.Office.Design.Editors.QuickAccessToolBarContextMenuItemsEditor, Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726", typeof(UITypeEditor))]
	[DefaultValue(null)]
	public string[] QuickAccessToolBarContextMenuItems
	{
		get
		{
			return GetValue<string[]>(ContextMenuItemsProperty);
		}
		set
		{
			SetValue(ContextMenuItemsProperty, value);
		}
	}

	[DefaultValue(QuickAccessToolBarLocation.AboveRibbon)]
	public QuickAccessToolBarLocation ToolBarLocation
	{
		get
		{
			return GetValue<QuickAccessToolBarLocation>(QuickAccessToolBarLocationProperty);
		}
		set
		{
			if (SetValue(QuickAccessToolBarLocationProperty, value))
			{
				OnQuickAccessToolBarLocationChange(value);
			}
		}
	}

	[DefaultValue(false)]
	public bool ShowQuickAccessToolbar
	{
		get
		{
			return GetValue<bool>(ShowQuickAccessToolbarProperty);
		}
		set
		{
			if (SetValue(ShowQuickAccessToolbarProperty, value))
			{
				ValidateRibbonLayout(blnClientSource: false);
			}
		}
	}

	[DefaultValue(false)]
	public bool ShowStartButton
	{
		get
		{
			return GetValue<bool>(ShowStartButtonProperty);
		}
		set
		{
			if (SetValue(ShowStartButtonProperty, value))
			{
				ValidateRibbonLayout(blnClientSource: false);
			}
		}
	}

	[DefaultValue(40)]
	public int StartButtonOffset
	{
		get
		{
			return GetValue<int>(StartButtonOffsetProperty);
		}
		set
		{
			if (SetValue(StartButtonOffsetProperty, value))
			{
				ValidateRibbonLayout(blnClientSource: false);
			}
		}
	}

	[DefaultValue(50)]
	public int StartButtonDiameterSize
	{
		get
		{
			return mobjRibbonBarStartButton.Height;
		}
		set
		{
			mobjRibbonBarStartButton.Height = value;
			mobjRibbonBarStartButton.Width = value;
		}
	}

	[DefaultValue(30)]
	public int QuickAccessToolBarPanelHeight
	{
		get
		{
			return mobjTopPanel.Height;
		}
		set
		{
			if (mobjTopPanel.Height != value)
			{
				mobjTopPanel.Height = value;
				ValidateRibbonLayout(blnClientSource: false);
			}
		}
	}

	[DefaultValue(true)]
	private bool IsExpanded
	{
		get
		{
			return mobjMainRibbonTabControl.IsExpanded;
		}
		set
		{
			mobjMainRibbonTabControl.IsExpanded = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowExpandButton
	{
		get
		{
			return mobjMainRibbonTabControl.ShowExpandButton;
		}
		set
		{
			ValidateExpandAndDock(IsExpanded, Dock, value);
			mobjMainRibbonTabControl.ShowExpandButton = value;
		}
	}

	[MergableProperty(false)]
	[Category("CatData")]
	[Description("ToolStripItemsDescr")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
	public ToolStripItemCollection QuickAccessToolBarItems => mobjQuickAccessToolBar.Items;

	[Description("ButtonImageDescr")]
	[Category("CatAppearance")]
	[DefaultValue(null)]
	public ResourceHandle StartButtonImage
	{
		get
		{
			return mobjRibbonBarStartButton.Image;
		}
		set
		{
			mobjRibbonBarStartButton.Image = value;
		}
	}

	private RibbonBarStartMenu StartMenu
	{
		get
		{
			RibbonBarStartMenu ribbonBarStartMenu = GetValue<RibbonBarStartMenu>(RibbonBarStartMenuProperty);
			if (ribbonBarStartMenu == null)
			{
				ribbonBarStartMenu = new RibbonBarStartMenu();
				SetValue(RibbonBarStartMenuProperty, ribbonBarStartMenu);
			}
			return ribbonBarStartMenu;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonBarStartMenuProperties StartMenuProperties
	{
		get
		{
			RibbonBarStartMenuProperties ribbonBarStartMenuProperties = GetValue<RibbonBarStartMenuProperties>(RibbonBarStartMenuPropertiesProperty);
			if (ribbonBarStartMenuProperties == null)
			{
				ribbonBarStartMenuProperties = new RibbonBarStartMenuProperties(StartMenu);
				SetValue(RibbonBarStartMenuPropertiesProperty, ribbonBarStartMenuProperties);
			}
			return ribbonBarStartMenuProperties;
		}
	}

	public event EventHandler SelectedIndexChanged;

	public event EventHandler<RibbonBarButtonItemArgs> ButtonClick;

	private event EventHandler<RibbonBarButtonItemMenuClickArgs> ButtonMenuClick;

	public event EventHandler<RibbonBarCheckBoxItemArgs> CheckChanged;

	public new event EventHandler<RibbonBarTextBoxItemArgs> TextChanged;

	public event EventHandler<RibbonBarGroupArgs> AdvancedClicked;

	public RibbonBar()
	{
		mobjToolTipService = new ToolTip();
		InitializeComponent();
		ValidateRibbonLayout(blnClientSource: false);
		Dock = DockStyle.Top;
	}

	protected virtual RibbonBarPageCollection CreateTabPageCollection()
	{
		return new RibbonBarPageCollection(this);
	}

	protected virtual void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		this.SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
	}

	protected virtual void OnButtonClick(object sender, RibbonBarButtonItemArgs e)
	{
		this.ButtonClick?.Invoke(sender, e);
	}

	protected virtual void OnTextChanged(object sender, RibbonBarTextBoxItemArgs e)
	{
		this.TextChanged?.Invoke(sender, e);
	}

	protected internal void OnButtonMenuClick(RibbonBarButtonItem objButtonItem, MenuItem objMenuItem)
	{
		OnButtonMenuClick(this, new RibbonBarButtonItemMenuClickArgs(objButtonItem, objMenuItem));
	}

	protected virtual void OnButtonMenuClick(object sender, RibbonBarButtonItemMenuClickArgs e)
	{
		this.ButtonMenuClick?.Invoke(sender, e);
	}

	internal void OnTextChanged(RibbonBarTextBoxItem ribbonBarTextBoxItem)
	{
		OnTextChanged(this, new RibbonBarTextBoxItemArgs(ribbonBarTextBoxItem));
	}

	protected virtual void OnAdvancedClicked(object sender, RibbonBarGroupArgs e)
	{
		this.AdvancedClicked?.Invoke(sender, e);
	}

	internal void OnAdvancedClicked(RibbonBarGroup ribbonGroupBox)
	{
		OnAdvancedClicked(this, new RibbonBarGroupArgs(ribbonGroupBox));
	}

	protected internal void OnButtonClick(RibbonBarButtonItem objButton)
	{
		OnButtonClick(this, new RibbonBarButtonItemArgs(objButton));
	}

	protected virtual void OnCheckedChanged(object sender, RibbonBarCheckBoxItemArgs e)
	{
		this.CheckChanged?.Invoke(sender, e);
	}

	internal void OnCheckedChanged(RibbonBarCheckBoxItem objCheckBox)
	{
		OnCheckedChanged(this, new RibbonBarCheckBoxItemArgs(objCheckBox));
	}

	protected override bool ShouldSerializeSize()
	{
		return false;
	}

	protected override bool ShouldSerializeClientSize()
	{
		return false;
	}

	private void OnToggleRibbonExpandedMenuItemClick(object sender, EventArgs e)
	{
		IsExpanded = !IsExpanded;
		ValidateRibbonLayout(blnClientSource: false);
	}

	private void OnToggleQuickAccessToolStripPositionMenuItemClick(object sender, EventArgs e)
	{
		if (ToolBarLocation == QuickAccessToolBarLocation.AboveRibbon)
		{
			ToolBarLocation = QuickAccessToolBarLocation.BellowRibbon;
		}
		else
		{
			ToolBarLocation = QuickAccessToolBarLocation.AboveRibbon;
		}
	}

	private void OnQuickAccessContextMenuItemClick(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem toolStripMenuItem)
		{
			ToolStripItem toolStripItem = QuickAccessToolBarItems[toolStripMenuItem.Name];
			if (toolStripItem != null)
			{
				toolStripItem.Visible = !toolStripItem.Visible;
				mobjQuickAccessToolBar.Update();
			}
		}
	}

	private void mobjQuickAccessToolBar_DropDownButtonClick(object sender, EventArgs e)
	{
		ContextMenuStrip quickAccessContextMenuStrip = mobjQuickAccessToolBar.QuickAccessContextMenuStrip;
		quickAccessContextMenuStrip.Items.Clear();
		string[] quickAccessToolBarContextMenuItems = QuickAccessToolBarContextMenuItems;
		if (quickAccessToolBarContextMenuItems != null && quickAccessToolBarContextMenuItems.Length != 0)
		{
			ToolStripItemCollection quickAccessToolBarItems = QuickAccessToolBarItems;
			string[] array = quickAccessToolBarContextMenuItems;
			foreach (string key in array)
			{
				ToolStripItem toolStripItem = quickAccessToolBarItems[key];
				if (toolStripItem != null)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(toolStripItem.Text);
					toolStripMenuItem.Name = toolStripItem.Name;
					if (toolStripItem.Visible)
					{
						toolStripMenuItem.Checked = true;
					}
					toolStripMenuItem.Click += OnQuickAccessContextMenuItemClick;
					quickAccessContextMenuStrip.Items.Add(toolStripMenuItem);
				}
			}
			ToolStripSeparator value = new ToolStripSeparator();
			quickAccessContextMenuStrip.Items.Add(value);
		}
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
		toolStripMenuItem2.Name = "ToggleQuickAccessToolStripPositionMenuItem";
		if (ToolBarLocation == QuickAccessToolBarLocation.BellowRibbon)
		{
			toolStripMenuItem2.Text = SR.GetString("RibbonBarShowAboveTheRibbon");
		}
		else
		{
			toolStripMenuItem2.Text = SR.GetString("RibbonBarShowBelowTheRibbon");
		}
		toolStripMenuItem2.Click += OnToggleQuickAccessToolStripPositionMenuItemClick;
		quickAccessContextMenuStrip.Items.Add(toolStripMenuItem2);
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
		toolStripMenuItem3.Name = "ToggleRibbonExpandedMenuItem";
		if (IsExpanded)
		{
			toolStripMenuItem3.Text = SR.GetString("RibbonBarMinimizeTheRibbon");
		}
		else
		{
			toolStripMenuItem3.Text = SR.GetString("RibbonBarMaximizeTheRibbon");
		}
		toolStripMenuItem3.Click += OnToggleRibbonExpandedMenuItemClick;
		quickAccessContextMenuStrip.Items.Add(toolStripMenuItem3);
	}

	internal void ValidateRibbonLayout(bool blnClientSource)
	{
		bool showStartButton = ShowStartButton;
		bool showQuickAccessToolbar = ShowQuickAccessToolbar;
		QuickAccessToolBarLocation toolBarLocation = ToolBarLocation;
		int startButtonOffset = StartButtonOffset;
		bool num = showQuickAccessToolbar || showStartButton;
		if (num)
		{
			mobjTopPanel.Visible = true;
		}
		else
		{
			mobjTopPanel.Visible = false;
		}
		mobjRibbonBarStartButton.Visible = showStartButton;
		mobjQuickAccessToolBar.Visible = showQuickAccessToolbar;
		if (showQuickAccessToolbar)
		{
			if (toolBarLocation == QuickAccessToolBarLocation.AboveRibbon)
			{
				if (showStartButton)
				{
					mobjTopPanel.Padding = new Padding(startButtonOffset, 0, 0, 0);
					mobjQuickAccessToolBar.InitPictures(blnFlatLeftPicture: false);
				}
				else
				{
					mobjTopPanel.Padding = Padding.Empty;
					mobjQuickAccessToolBar.InitPictures(blnFlatLeftPicture: true);
				}
			}
			else
			{
				mobjQuickAccessToolBar.InitPictures(blnFlatLeftPicture: true);
			}
		}
		if (showStartButton)
		{
			mobjMainRibbonTabControl.HeadersOffset = startButtonOffset;
		}
		else
		{
			mobjMainRibbonTabControl.HeadersOffset = -1;
		}
		int num2 = 0;
		num2 = ((!mobjMainRibbonTabControl.IsExpanded) ? mobjMainRibbonTabControl.SkinHeaderHeight : mobjMainRibbonTabControl.RestoredHeight);
		if (num)
		{
			num2 += mobjTopPanel.Height;
		}
		if (showQuickAccessToolbar && toolBarLocation == QuickAccessToolBarLocation.BellowRibbon)
		{
			num2 += mobjQuickAccessToolBar.Height;
		}
		mblnIsExpanding = true;
		SetHeight(num2, !blnClientSource);
		mblnIsExpanding = false;
	}

	private void OnQuickAccessToolBarLocationChange(QuickAccessToolBarLocation objQuickAccessToolBarLocation)
	{
		if (objQuickAccessToolBarLocation == QuickAccessToolBarLocation.AboveRibbon)
		{
			mobjTopPanel.Controls.Add(mobjQuickAccessToolBar);
			mobjQuickAccessToolBar.Dock = DockStyle.Top;
		}
		else
		{
			mobjQuickAccessToolBar.Dock = DockStyle.Bottom;
			base.Controls.Add(mobjQuickAccessToolBar);
		}
		ValidateRibbonLayout(blnClientSource: false);
	}

	public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
	{
		if (!base.DesignMode && (enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && !mblnIsExpanding)
		{
			bool showQuickAccessToolbar = ShowQuickAccessToolbar;
			int num = intHeight;
			if (showQuickAccessToolbar || ShowStartButton)
			{
				num -= mobjTopPanel.Height;
			}
			if (showQuickAccessToolbar && ToolBarLocation == QuickAccessToolBarLocation.BellowRibbon)
			{
				num -= mobjQuickAccessToolBar.Height;
			}
			mobjMainRibbonTabControl.RestoredHeight = num;
			if (!IsExpanded)
			{
				enmSpecified &= (BoundsSpecified)(-9);
			}
		}
		return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified);
	}

	private void mobjRibbonBarStartButton_Click(object sender, EventArgs e)
	{
		StartMenu.ShowPopup(mobjRibbonBarStartButton);
	}

	internal void ValidateExpandAndDock(bool blnIsExpanded, DockStyle enmDockStyle, bool blnShowExpandButton)
	{
		if ((!blnIsExpanded || blnShowExpandButton) && (enmDockStyle == DockStyle.Fill || enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right))
		{
			throw new NotSupportedException(SR.GetString("RibbonBarValidateExpandAndDock", enmDockStyle));
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
		mobjMainRibbonTabControl = new RibbonBarTabControl();
		mobjTopPanel = new Panel();
		mobjQuickAccessToolBar = new QuickAccessToolBar(this);
		mobjRibbonBarStartButton = new RibbonBarStartButton();
		((ISupportInitialize)mobjMainRibbonTabControl).BeginInit();
		mobjMainRibbonTabControl.SuspendLayout();
		mobjTopPanel.SuspendLayout();
		SuspendLayout();
		mobjMainRibbonTabControl.Alignment = TabAlignment.Top;
		mobjMainRibbonTabControl.CustomStyle = "RibbonBar";
		mobjMainRibbonTabControl.Dock = DockStyle.Fill;
		mobjMainRibbonTabControl.Location = new Point(0, 35);
		mobjMainRibbonTabControl.Name = "mobjMainRibbonTabControl";
		mobjMainRibbonTabControl.SelectedIndex = 0;
		mobjMainRibbonTabControl.Size = new Size(100, 115);
		mobjMainRibbonTabControl.TabIndex = 1;
		mobjMainRibbonTabControl.SelectedIndexChanged += OnSelectedIndexChanged;
		mobjTopPanel.Controls.Add(mobjQuickAccessToolBar);
		mobjTopPanel.Dock = DockStyle.Top;
		mobjTopPanel.Location = new Point(0, 0);
		mobjTopPanel.Name = "mobjTopPanel";
		mobjTopPanel.Size = new Size(250, 30);
		mobjTopPanel.TabIndex = 2;
		mobjTopPanel.Visible = false;
		mobjQuickAccessToolBar.AutoSize = true;
		mobjQuickAccessToolBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		mobjQuickAccessToolBar.AutoValidate = AutoValidate.EnablePreventFocusChange;
		mobjQuickAccessToolBar.Dock = DockStyle.Top;
		mobjQuickAccessToolBar.Location = new Point(0, 0);
		mobjQuickAccessToolBar.MinimumSize = new Size(25, 25);
		mobjQuickAccessToolBar.Name = "mobjQuickAccessToolBar";
		mobjQuickAccessToolBar.Size = new Size(250, 25);
		mobjQuickAccessToolBar.TabIndex = 0;
		mobjQuickAccessToolBar.Text = "QuickAccessToolBar";
		mobjQuickAccessToolBar.Visible = false;
		mobjQuickAccessToolBar.DropDownButtonClick += mobjQuickAccessToolBar_DropDownButtonClick;
		mobjRibbonBarStartButton.CustomStyle = "RibbonBarStartButtonSkin";
		mobjRibbonBarStartButton.Location = new Point(0, 0);
		mobjRibbonBarStartButton.Name = "mobjRibbonBarStartButton";
		mobjRibbonBarStartButton.Size = new Size(50, 50);
		mobjRibbonBarStartButton.TabIndex = 0;
		mobjRibbonBarStartButton.Visible = false;
		mobjRibbonBarStartButton.Click += mobjRibbonBarStartButton_Click;
		base.Controls.Add(mobjRibbonBarStartButton);
		base.Controls.Add(mobjMainRibbonTabControl);
		base.Controls.Add(mobjTopPanel);
		base.Size = new Size(250, 115);
		base.Name = "RibbonBar";
		((ISupportInitialize)mobjMainRibbonTabControl).EndInit();
		mobjMainRibbonTabControl.ResumeLayout(blnPerformLayout: false);
		mobjTopPanel.ResumeLayout(blnPerformLayout: false);
		ResumeLayout(blnPerformLayout: false);
	}
}
