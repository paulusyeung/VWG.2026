using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.HelpLibrary;
using Gizmox.WebGUI.Forms.Skins;
using HtmlHelp;

namespace Gizmox.WebGUI.Forms;

[Skin(typeof(HelpFormBaseSkin))]
public abstract class HelpFormBase : Form, IRequiresRegistration
{
	[NonSerialized]
	private Container components = null;

	private MainMenu mobjMainMenu;

	private MenuItem mobjMenuFile;

	private MenuItem mobjMenuPrint;

	private MenuItem mobjMenuFileSep;

	private MenuItem mobjMenuExit;

	private MenuItem mobjMenuEdit;

	private MenuItem mobjMenuCopy;

	private MenuItem mobjMenuSelectAll;

	private MenuItem mobjMenuEditSep;

	private MenuItem mobjMenuFindInTopic;

	private MenuItem mobjMenuView;

	private MenuItem mobjMenuGo;

	private MenuItem mobjMenuHelp;

	private MenuItem monjMenuNavigationTabs;

	private MenuItem mobjMenuViewSep1;

	private MenuItem monjMenuContents;

	private MenuItem monjMenuIndex;

	private MenuItem monjMenuSearch;

	private MenuItem monjMenuFavorites;

	private MenuItem mobjMenuBack;

	private MenuItem mobjMenuForward;

	private MenuItem mobjMenuNextInContents;

	private MenuItem mobjMenuPreviousInContents;

	private MenuItem mobjMenuHome;

	private MenuItem mobjMenuGoSep;

	private MenuItem mobjMenuJumpToURL;

	private MenuItem mobjMenuAboutHTMLHelp;

	private ToolBar mobToolBar;

	private ToolBarButton mobjTBButtonHide;

	private ToolBarButton mobjTBButtonLocate;

	private ToolBarButton mobjTBButtonPrevious;

	private ToolBarButton mobjTBButtonNext;

	private ToolBarButton mobjTBButtonBack;

	private ToolBarButton mobjTBButtonForward;

	private ToolBarButton mobjTBButtonHome;

	private ToolBarButton mobjTBButtonPrint;

	private ToolBarButton mobjTBButtonSep1;

	private ToolBarButton mobjTBButtonSep2;

	private Panel mobjPanelMainSpace;

	private TabControl mobjTabControl;

	private TabPage mobjTabContents;

	private TabPage mobjTabIndex;

	private TabPage mobjTabSearch;

	private TabPage mobjTabFavorites;

	private Splitter mobjSplitterMain;

	private HtmlBox mobjHtml;

	private TreeView mobjTreeView;

	private TextBox mobjTextBoxIndex;

	private Panel mobjPanelIndexBottom;

	private Panel mobjPanelIndexSpace;

	private ListView mobjListSearch;

	private Panel mobjPanelSearchBottom;

	private Panel mobjPanelSeachTop;

	private Label mobjLabelIndex;

	private Label mobjLabelSearch;

	private Label mobjLabelFavorites;

	private CheckBox mobjCheckSeachTitles;

	private CheckBox mobjCheckMatchSimilarWords;

	private CheckBox mobjCheckSearchPreviousResults;

	private Panel mobjPanelFavoritesBottom;

	private Label mobjLabelFavoritesCurrentTopic;

	private TextBox mobjTextFavoritesCurrentTopic;

	private Button mobjButtonFavoritesAdd;

	private Button mobjButtonFavoritesRemove;

	private Button mobjButtonFavoritesDisplay;

	private ListBox mobjListFavorites;

	private ColumnHeader mobjColumnSearchTitle;

	private ColumnHeader mobjColumnSearchLocation;

	private ColumnHeader mobjColumnSearchRank;

	private ToolBarButton mobjTBButtonFind;

	private Button mobjButtonIndexDisplay;

	private Button mobjButtonSearchOperators;

	private ComboBox mobjComboSearchWildcard;

	private Label mobjLabelSearchFound;

	private Label mobjLabelSearchSelectTopic;

	private Button mobjButtonSeachListTopics;

	private Button mobjButtonSearchDisplay;

	private ContextMenu mobjMenuSearchOperators;

	private MenuItem mobjMenuSearchAND;

	private MenuItem mobjMenuSearchOR;

	private MenuItem mobjMenuSearchNEAR;

	private MenuItem mobjMenuSearchNOT;

	private ListView mobjListIndex;

	private ColumnHeader mobjColumnIndexText;

	private string mstrCHMDefaultHash = null;

	private bool mblnTestingMode = false;

	private static SkinResourceHandle mobjOpenBookResourceHandle = new SkinResourceHandle(typeof(HelpFormBaseSkin), "OpenBook.gif");

	private static SkinResourceHandle mobjClosedBookResourceHandle = new SkinResourceHandle(typeof(HelpFormBaseSkin), "ClosedBook.gif");

	private static SkinResourceHandle mobjTopicResourceHandle = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Topic.gif");

	private CHMExplorerController mobjController = null;

	protected abstract HelpNavigator InitializationCommand { get; }

	protected abstract object InitializationParam { get; }

	protected abstract string CHMLocation { get; }

	internal HelpFormBase()
	{
		InitializeComponent();
		RemoveNotImplemented();
	}

	private void RemoveNotImplemented()
	{
		if (!mblnTestingMode)
		{
			mobjMenuGo.Visible = false;
			mobjMenuEdit.Visible = false;
			mobjMenuView.Visible = false;
			mobjTabFavorites.Visible = false;
			mobjCheckSearchPreviousResults.Visible = false;
			mobjTBButtonBack.Visible = false;
			mobjTBButtonNext.Visible = false;
			mobjTBButtonPrevious.Visible = false;
			mobjTBButtonForward.Visible = false;
			mobjTBButtonHide.Visible = false;
			mobjTBButtonSep1.Visible = false;
			mobjTBButtonSep2.Visible = false;
			mobjTBButtonLocate.Visible = false;
			mobjTBButtonFind.Visible = false;
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
		SkinResourceHandle image = new SkinResourceHandle(typeof(HelpFormBaseSkin), "TableOfContent.gif");
		SkinResourceHandle image2 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Sync.gif");
		SkinResourceHandle image3 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Next.gif");
		SkinResourceHandle image4 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Back.gif");
		SkinResourceHandle image5 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Up.gif");
		SkinResourceHandle image6 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Down.gif");
		SkinResourceHandle image7 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Find.gif");
		SkinResourceHandle image8 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Home.gif");
		SkinResourceHandle image9 = new SkinResourceHandle(typeof(HelpFormBaseSkin), "Print.gif");
		mobjMainMenu = new MainMenu();
		mobjMenuFile = new MenuItem();
		mobjMenuPrint = new MenuItem();
		mobjMenuFileSep = new MenuItem();
		mobjMenuExit = new MenuItem();
		mobjMenuEdit = new MenuItem();
		mobjMenuCopy = new MenuItem();
		mobjMenuSelectAll = new MenuItem();
		mobjMenuEditSep = new MenuItem();
		mobjMenuFindInTopic = new MenuItem();
		mobjMenuView = new MenuItem();
		monjMenuNavigationTabs = new MenuItem();
		mobjMenuViewSep1 = new MenuItem();
		monjMenuContents = new MenuItem();
		monjMenuIndex = new MenuItem();
		monjMenuSearch = new MenuItem();
		monjMenuFavorites = new MenuItem();
		mobjMenuGo = new MenuItem();
		mobjMenuBack = new MenuItem();
		mobjMenuForward = new MenuItem();
		mobjMenuNextInContents = new MenuItem();
		mobjMenuPreviousInContents = new MenuItem();
		mobjMenuHome = new MenuItem();
		mobjMenuGoSep = new MenuItem();
		mobjMenuJumpToURL = new MenuItem();
		mobjMenuHelp = new MenuItem();
		mobjMenuAboutHTMLHelp = new MenuItem();
		mobToolBar = new ToolBar();
		mobjTBButtonHide = new ToolBarButton();
		mobjTBButtonLocate = new ToolBarButton();
		mobjTBButtonSep1 = new ToolBarButton();
		mobjTBButtonNext = new ToolBarButton();
		mobjTBButtonBack = new ToolBarButton();
		mobjTBButtonPrevious = new ToolBarButton();
		mobjTBButtonForward = new ToolBarButton();
		mobjTBButtonSep2 = new ToolBarButton();
		mobjTBButtonFind = new ToolBarButton();
		mobjTBButtonHome = new ToolBarButton();
		mobjTBButtonPrint = new ToolBarButton();
		mobjPanelMainSpace = new Panel();
		mobjTabControl = new TabControl();
		mobjTabContents = new TabPage();
		mobjTreeView = new TreeView();
		mobjTabIndex = new TabPage();
		mobjListIndex = new ListView();
		mobjColumnIndexText = new ColumnHeader();
		mobjPanelIndexBottom = new Panel();
		mobjButtonIndexDisplay = new Button();
		mobjPanelIndexSpace = new Panel();
		mobjTextBoxIndex = new TextBox();
		mobjLabelIndex = new Label();
		mobjTabSearch = new TabPage();
		mobjListSearch = new ListView();
		mobjColumnSearchTitle = new ColumnHeader();
		mobjColumnSearchLocation = new ColumnHeader();
		mobjColumnSearchRank = new ColumnHeader();
		mobjPanelSearchBottom = new Panel();
		mobjCheckSeachTitles = new CheckBox();
		mobjCheckMatchSimilarWords = new CheckBox();
		mobjCheckSearchPreviousResults = new CheckBox();
		mobjPanelSeachTop = new Panel();
		mobjLabelSearchFound = new Label();
		mobjLabelSearchSelectTopic = new Label();
		mobjButtonSeachListTopics = new Button();
		mobjButtonSearchDisplay = new Button();
		mobjButtonSearchOperators = new Button();
		mobjMenuSearchOperators = new ContextMenu();
		mobjMenuSearchAND = new MenuItem();
		mobjMenuSearchOR = new MenuItem();
		mobjMenuSearchNEAR = new MenuItem();
		mobjMenuSearchNOT = new MenuItem();
		mobjComboSearchWildcard = new ComboBox();
		mobjLabelSearch = new Label();
		mobjTabFavorites = new TabPage();
		mobjPanelFavoritesBottom = new Panel();
		mobjLabelFavoritesCurrentTopic = new Label();
		mobjTextFavoritesCurrentTopic = new TextBox();
		mobjButtonFavoritesAdd = new Button();
		mobjButtonFavoritesRemove = new Button();
		mobjButtonFavoritesDisplay = new Button();
		mobjListFavorites = new ListBox();
		mobjLabelFavorites = new Label();
		mobjSplitterMain = new Splitter();
		mobjHtml = new HtmlBox();
		SuspendLayout();
		mobjMainMenu.BackgroundImageLayout = ImageLayout.Tile;
		mobjMainMenu.ClientSize = new Size(472, 22);
		mobjMainMenu.Cursor = Cursors.Default;
		mobjMainMenu.Dock = DockStyle.Top;
		mobjMainMenu.Location = new Point(0, 0);
		mobjMainMenu.Margin = new Padding(0);
		mobjMainMenu.MenuItems.AddRange(new MenuItem[5] { mobjMenuFile, mobjMenuEdit, mobjMenuView, mobjMenuGo, mobjMenuHelp });
		mobjMainMenu.Name = "mobjMainMenu";
		mobjMainMenu.Size = new Size(472, 22);
		mobjMainMenu.MenuClick += mobjMainMenu_MenuClick;
		mobjMenuFile.MenuItems.AddRange(new MenuItem[3] { mobjMenuPrint, mobjMenuFileSep, mobjMenuExit });
		mobjMenuFile.Tag = "File";
		mobjMenuFile.Text = "File";
		mobjMenuPrint.Tag = "Print";
		mobjMenuPrint.Text = "Print";
		mobjMenuFileSep.Text = "-";
		mobjMenuExit.Tag = "Exit";
		mobjMenuExit.Text = "Exit";
		mobjMenuEdit.MenuItems.AddRange(new MenuItem[4] { mobjMenuCopy, mobjMenuSelectAll, mobjMenuEditSep, mobjMenuFindInTopic });
		mobjMenuEdit.Tag = "Edit";
		mobjMenuEdit.Text = "Edit";
		mobjMenuCopy.Tag = "Copy";
		mobjMenuCopy.Text = "Copy";
		mobjMenuSelectAll.Tag = "SelectAll";
		mobjMenuSelectAll.Text = "Select All";
		mobjMenuEditSep.Text = "-";
		mobjMenuFindInTopic.Tag = "FindInTopic";
		mobjMenuFindInTopic.Text = "Find In Topic...";
		mobjMenuView.MenuItems.AddRange(new MenuItem[6] { monjMenuNavigationTabs, mobjMenuViewSep1, monjMenuContents, monjMenuIndex, monjMenuSearch, monjMenuFavorites });
		mobjMenuView.Tag = "View";
		mobjMenuView.Text = "View";
		monjMenuNavigationTabs.Checked = true;
		monjMenuNavigationTabs.Text = "Navigation Tabs";
		mobjMenuViewSep1.Text = "-";
		monjMenuContents.Checked = true;
		monjMenuContents.Text = "Contents";
		monjMenuIndex.Text = "Index";
		monjMenuSearch.Text = "Search";
		monjMenuFavorites.Text = "Favorites";
		mobjMenuGo.MenuItems.AddRange(new MenuItem[7] { mobjMenuBack, mobjMenuForward, mobjMenuNextInContents, mobjMenuPreviousInContents, mobjMenuHome, mobjMenuGoSep, mobjMenuJumpToURL });
		mobjMenuGo.Tag = "Go";
		mobjMenuGo.Text = "Go";
		mobjMenuBack.Tag = "Back";
		mobjMenuBack.Text = "Back";
		mobjMenuForward.Tag = "Forward";
		mobjMenuForward.Text = "Forward";
		mobjMenuNextInContents.Text = "Next";
		mobjMenuPreviousInContents.Text = "Previous";
		mobjMenuHome.Text = "Home";
		mobjMenuGoSep.Text = "-";
		mobjMenuJumpToURL.Tag = "JumpToURL";
		mobjMenuJumpToURL.Text = "Jump To URL";
		mobjMenuHelp.MenuItems.AddRange(new MenuItem[1] { mobjMenuAboutHTMLHelp });
		mobjMenuHelp.Tag = "Help";
		mobjMenuHelp.Text = "Help";
		mobjMenuAboutHTMLHelp.Tag = "AboutHTMLHelp";
		mobjMenuAboutHTMLHelp.Text = "About HTML Help...";
		mobToolBar.Appearance = ToolBarAppearance.Flat;
		mobToolBar.BackgroundImageLayout = ImageLayout.Tile;
		mobToolBar.Buttons.AddRange(new ToolBarButton[11]
		{
			mobjTBButtonHide, mobjTBButtonLocate, mobjTBButtonSep1, mobjTBButtonNext, mobjTBButtonBack, mobjTBButtonPrevious, mobjTBButtonForward, mobjTBButtonSep2, mobjTBButtonFind, mobjTBButtonHome,
			mobjTBButtonPrint
		});
		mobToolBar.Cursor = Cursors.Default;
		mobToolBar.Dock = DockStyle.Top;
		mobToolBar.DragHandle = true;
		mobToolBar.DropDownArrows = false;
		mobToolBar.ImageList = null;
		mobToolBar.Location = new Point(3, 3);
		mobToolBar.Margin = new Padding(0);
		mobToolBar.MenuHandle = true;
		mobToolBar.Name = "mobToolBar";
		mobToolBar.RightToLeft = RightToLeft.No;
		mobToolBar.ShowToolTips = true;
		mobToolBar.TabIndex = 0;
		mobToolBar.ButtonClick += mobToolBar_ButtonClick;
		mobjTBButtonHide.CustomStyle = "";
		mobjTBButtonHide.Image = image;
		mobjTBButtonHide.ImageKey = null;
		mobjTBButtonHide.Name = "mobjTBButtonHide";
		mobjTBButtonHide.Pushed = true;
		mobjTBButtonHide.Size = 24;
		mobjTBButtonHide.Tag = "Hide";
		mobjTBButtonHide.ToolTipText = "Hide";
		mobjTBButtonLocate.CustomStyle = "";
		mobjTBButtonLocate.Image = image2;
		mobjTBButtonLocate.ImageKey = null;
		mobjTBButtonLocate.Name = "mobjTBButtonLocate";
		mobjTBButtonLocate.Pushed = true;
		mobjTBButtonLocate.Size = 24;
		mobjTBButtonLocate.Tag = "Locate";
		mobjTBButtonLocate.ToolTipText = "Hide";
		mobjTBButtonSep1.CustomStyle = "";
		mobjTBButtonSep1.ImageKey = null;
		mobjTBButtonSep1.Name = "mobjTBButtonSep1";
		mobjTBButtonSep1.Pushed = true;
		mobjTBButtonSep1.Size = 24;
		mobjTBButtonSep1.Style = ToolBarButtonStyle.Separator;
		mobjTBButtonSep1.ToolTipText = "";
		mobjTBButtonNext.CustomStyle = "";
		mobjTBButtonNext.Image = image3;
		mobjTBButtonNext.ImageKey = null;
		mobjTBButtonNext.Name = "mobjTBButtonNext";
		mobjTBButtonNext.Pushed = true;
		mobjTBButtonNext.Size = 24;
		mobjTBButtonNext.Tag = "Next";
		mobjTBButtonNext.ToolTipText = "Next";
		mobjTBButtonBack.CustomStyle = "";
		mobjTBButtonBack.Image = image4;
		mobjTBButtonBack.ImageKey = null;
		mobjTBButtonBack.Name = "mobjTBButtonBack";
		mobjTBButtonBack.Pushed = true;
		mobjTBButtonBack.Size = 24;
		mobjTBButtonBack.Tag = "Back";
		mobjTBButtonBack.ToolTipText = "Back";
		mobjTBButtonPrevious.CustomStyle = "";
		mobjTBButtonPrevious.Image = image5;
		mobjTBButtonPrevious.ImageKey = null;
		mobjTBButtonPrevious.Name = "mobjTBButtonPrevious";
		mobjTBButtonPrevious.Pushed = true;
		mobjTBButtonPrevious.Size = 24;
		mobjTBButtonPrevious.Tag = "Previous";
		mobjTBButtonPrevious.ToolTipText = "Previous";
		mobjTBButtonForward.CustomStyle = "";
		mobjTBButtonForward.Image = image6;
		mobjTBButtonForward.ImageKey = null;
		mobjTBButtonForward.Name = "mobjTBButtonForward";
		mobjTBButtonForward.Pushed = true;
		mobjTBButtonForward.Size = 24;
		mobjTBButtonForward.Tag = "Forward";
		mobjTBButtonForward.ToolTipText = "Forward";
		mobjTBButtonSep2.CustomStyle = "";
		mobjTBButtonSep2.ImageKey = null;
		mobjTBButtonSep2.Name = "mobjTBButtonSep2";
		mobjTBButtonSep2.Pushed = true;
		mobjTBButtonSep2.Size = 24;
		mobjTBButtonSep2.Style = ToolBarButtonStyle.Separator;
		mobjTBButtonSep2.ToolTipText = "";
		mobjTBButtonFind.CustomStyle = "";
		mobjTBButtonFind.Image = image7;
		mobjTBButtonFind.ImageKey = null;
		mobjTBButtonFind.Name = "mobjTBButtonFind";
		mobjTBButtonFind.Pushed = true;
		mobjTBButtonFind.Size = 24;
		mobjTBButtonFind.Tag = "Find";
		mobjTBButtonFind.ToolTipText = "Find";
		mobjTBButtonHome.CustomStyle = "";
		mobjTBButtonHome.Image = image8;
		mobjTBButtonHome.ImageKey = null;
		mobjTBButtonHome.Name = "mobjTBButtonHome";
		mobjTBButtonHome.Pushed = true;
		mobjTBButtonHome.Size = 24;
		mobjTBButtonHome.Tag = "Home";
		mobjTBButtonHome.ToolTipText = "Home";
		mobjTBButtonPrint.CustomStyle = "";
		mobjTBButtonPrint.Image = image9;
		mobjTBButtonPrint.ImageKey = null;
		mobjTBButtonPrint.Name = "mobjTBButtonPrint";
		mobjTBButtonPrint.Pushed = true;
		mobjTBButtonPrint.Size = 24;
		mobjTBButtonPrint.Tag = "Print";
		mobjTBButtonPrint.ToolTipText = "Print";
		mobjPanelMainSpace.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelMainSpace.ClientSize = new Size(730, 3);
		mobjPanelMainSpace.Cursor = Cursors.Default;
		mobjPanelMainSpace.Dock = DockStyle.Top;
		mobjPanelMainSpace.Location = new Point(3, 31);
		mobjPanelMainSpace.Margin = new Padding(0);
		mobjPanelMainSpace.Name = "mobjPanelMainSpace";
		mobjPanelMainSpace.Size = new Size(730, 3);
		mobjPanelMainSpace.TabIndex = 0;
		mobjTabControl.BackgroundImageLayout = ImageLayout.Tile;
		mobjTabControl.ClientSize = new Size(255, 699);
		mobjTabControl.Controls.Add(mobjTabContents);
		mobjTabControl.Controls.Add(mobjTabIndex);
		mobjTabControl.Controls.Add(mobjTabSearch);
		mobjTabControl.Controls.Add(mobjTabFavorites);
		mobjTabControl.Cursor = Cursors.Default;
		mobjTabControl.Dock = DockStyle.Left;
		mobjTabControl.Location = new Point(3, 34);
		mobjTabControl.Margin = new Padding(0);
		mobjTabControl.Name = "mobjTabControl";
		mobjTabControl.SelectedIndex = 0;
		mobjTabControl.Size = new Size(255, 699);
		mobjTabControl.TabIndex = 0;
		mobjTabContents.BackgroundImageLayout = ImageLayout.Tile;
		mobjTabContents.ClientSize = new Size(247, 521);
		mobjTabContents.Controls.Add(mobjTreeView);
		mobjTabContents.Cursor = Cursors.Default;
		mobjTabContents.DockPadding.All = 3;
		mobjTabContents.Location = new Point(4, 22);
		mobjTabContents.Margin = new Padding(0);
		mobjTabContents.Name = "mobjTabContents";
		mobjTabContents.Size = new Size(247, 521);
		mobjTabContents.TabIndex = 0;
		mobjTabContents.Text = "Contents";
		mobjTreeView.BackgroundImageLayout = ImageLayout.Tile;
		mobjTreeView.BorderStyle = BorderStyle.None;
		mobjTreeView.ClientSize = new Size(241, 241);
		mobjTreeView.Cursor = Cursors.Default;
		mobjTreeView.Dock = DockStyle.Fill;
		mobjTreeView.Location = new Point(0, 0);
		mobjTreeView.Margin = new Padding(0);
		mobjTreeView.Name = "mobjTreeView";
		mobjTreeView.Size = new Size(241, 241);
		mobjTreeView.TabIndex = 0;
		mobjTabIndex.BackgroundImageLayout = ImageLayout.Tile;
		mobjTabIndex.ClientSize = new Size(247, 521);
		mobjTabIndex.Controls.Add(mobjListIndex);
		mobjTabIndex.Controls.Add(mobjPanelIndexBottom);
		mobjTabIndex.Controls.Add(mobjPanelIndexSpace);
		mobjTabIndex.Controls.Add(mobjTextBoxIndex);
		mobjTabIndex.Controls.Add(mobjLabelIndex);
		mobjTabIndex.Cursor = Cursors.Default;
		mobjTabIndex.DockPadding.All = 3;
		mobjTabIndex.Location = new Point(4, 22);
		mobjTabIndex.Margin = new Padding(0);
		mobjTabIndex.Name = "mobjTabIndex";
		mobjTabIndex.Size = new Size(247, 521);
		mobjTabIndex.TabIndex = 1;
		mobjTabIndex.Text = "Index";
		mobjListIndex.BackgroundImageLayout = ImageLayout.Tile;
		mobjListIndex.ClientSize = new Size(241, 159);
		mobjListIndex.Columns.AddRange(new ColumnHeader[1] { mobjColumnIndexText });
		mobjListIndex.Cursor = Cursors.Default;
		mobjListIndex.Dock = DockStyle.Fill;
		mobjListIndex.HeaderStyle = ColumnHeaderStyle.None;
		mobjListIndex.ItemsPerPage = 20;
		mobjListIndex.Location = new Point(0, 46);
		mobjListIndex.Margin = new Padding(0);
		mobjListIndex.MultiSelect = false;
		mobjListIndex.Name = "mobjListIndex";
		mobjListIndex.Size = new Size(241, 159);
		mobjListIndex.TabIndex = 0;
		mobjListIndex.UseInternalPaging = true;
		mobjListIndex.DoubleClick += mobjListIndex_DoubleClick;
		mobjColumnIndexText.Image = null;
		mobjColumnIndexText.Text = "";
		mobjColumnIndexText.Width = 250;
		mobjPanelIndexBottom.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelIndexBottom.ClientSize = new Size(241, 36);
		mobjPanelIndexBottom.Controls.Add(mobjButtonIndexDisplay);
		mobjPanelIndexBottom.Cursor = Cursors.Default;
		mobjPanelIndexBottom.Dock = DockStyle.Bottom;
		mobjPanelIndexBottom.Location = new Point(0, 485);
		mobjPanelIndexBottom.Margin = new Padding(0);
		mobjPanelIndexBottom.Name = "mobjPanelIndexBottom";
		mobjPanelIndexBottom.Size = new Size(241, 36);
		mobjPanelIndexBottom.TabIndex = 0;
		mobjButtonIndexDisplay.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonIndexDisplay.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonIndexDisplay.ClientSize = new Size(69, 23);
		mobjButtonIndexDisplay.Cursor = Cursors.Default;
		mobjButtonIndexDisplay.Location = new Point(173, 3);
		mobjButtonIndexDisplay.Margin = new Padding(0);
		mobjButtonIndexDisplay.Name = "mobjButtonIndexDisplay";
		mobjButtonIndexDisplay.Size = new Size(69, 23);
		mobjButtonIndexDisplay.TabIndex = 0;
		mobjButtonIndexDisplay.Text = "Display";
		mobjButtonIndexDisplay.Click += mobjButtonIndexDisplay_Click;
		mobjPanelIndexSpace.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelIndexSpace.ClientSize = new Size(241, 3);
		mobjPanelIndexSpace.Cursor = Cursors.Default;
		mobjPanelIndexSpace.Dock = DockStyle.Top;
		mobjPanelIndexSpace.Location = new Point(0, 43);
		mobjPanelIndexSpace.Margin = new Padding(0);
		mobjPanelIndexSpace.Name = "mobjPanelIndexSpace";
		mobjPanelIndexSpace.Size = new Size(241, 3);
		mobjPanelIndexSpace.TabIndex = 0;
		mobjTextBoxIndex.AcceptsReturn = true;
		mobjTextBoxIndex.AcceptsTab = true;
		mobjTextBoxIndex.BackgroundImageLayout = ImageLayout.Tile;
		mobjTextBoxIndex.ClientSize = new Size(241, 20);
		mobjTextBoxIndex.Cursor = Cursors.Default;
		mobjTextBoxIndex.Dock = DockStyle.Top;
		mobjTextBoxIndex.Lines = new string[0];
		mobjTextBoxIndex.Location = new Point(0, 23);
		mobjTextBoxIndex.Margin = new Padding(0);
		mobjTextBoxIndex.MaxLength = 0;
		mobjTextBoxIndex.Multiline = false;
		mobjTextBoxIndex.Name = "mobjTextBoxIndex";
		mobjTextBoxIndex.ReadOnly = false;
		mobjTextBoxIndex.ScrollBars = ScrollBars.Both;
		mobjTextBoxIndex.Size = new Size(241, 20);
		mobjTextBoxIndex.TabIndex = 0;
		mobjTextBoxIndex.TextAlign = HorizontalAlignment.Left;
		mobjTextBoxIndex.Validator = null;
		mobjTextBoxIndex.WordWrap = false;
		mobjTextBoxIndex.EnterKeyDown += mobjTextBoxIndex_EnterKeyDown;
		mobjLabelIndex.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelIndex.ClientSize = new Size(241, 23);
		mobjLabelIndex.Cursor = Cursors.Default;
		mobjLabelIndex.Dock = DockStyle.Top;
		mobjLabelIndex.FlatStyle = FlatStyle.Flat;
		mobjLabelIndex.Location = new Point(0, 0);
		mobjLabelIndex.Margin = new Padding(0);
		mobjLabelIndex.Name = "mobjLabelIndex";
		mobjLabelIndex.Size = new Size(241, 23);
		mobjLabelIndex.TabIndex = 0;
		mobjLabelIndex.Text = "Type in keywords to find:";
		mobjLabelIndex.TextAlign = ContentAlignment.MiddleLeft;
		mobjTabSearch.BackgroundImageLayout = ImageLayout.Tile;
		mobjTabSearch.ClientSize = new Size(247, 521);
		mobjTabSearch.Controls.Add(mobjListSearch);
		mobjTabSearch.Controls.Add(mobjPanelSearchBottom);
		mobjTabSearch.Controls.Add(mobjPanelSeachTop);
		mobjTabSearch.Controls.Add(mobjLabelSearch);
		mobjTabSearch.Cursor = Cursors.Default;
		mobjTabSearch.DockPadding.All = 3;
		mobjTabSearch.Location = new Point(4, 22);
		mobjTabSearch.Margin = new Padding(0);
		mobjTabSearch.Name = "mobjTabSearch";
		mobjTabSearch.Size = new Size(247, 521);
		mobjTabSearch.TabIndex = 2;
		mobjTabSearch.Text = "Search";
		mobjListSearch.BackgroundImageLayout = ImageLayout.Tile;
		mobjListSearch.ClientSize = new Size(241, 57);
		mobjListSearch.Columns.AddRange(new ColumnHeader[3] { mobjColumnSearchTitle, mobjColumnSearchLocation, mobjColumnSearchRank });
		mobjListSearch.Cursor = Cursors.Default;
		mobjListSearch.Dock = DockStyle.Fill;
		mobjListSearch.ItemsPerPage = 20;
		mobjListSearch.Location = new Point(0, 106);
		mobjListSearch.Margin = new Padding(0);
		mobjListSearch.MultiSelect = false;
		mobjListSearch.Name = "mobjListSearch";
		mobjListSearch.Size = new Size(241, 57);
		mobjListSearch.TabIndex = 0;
		mobjListSearch.UseInternalPaging = true;
		mobjListSearch.DoubleClick += mobjListSearch_DoubleClick;
		mobjListSearch.ListViewItemSorter = new ListViewItemSorter(mobjListSearch);
		mobjColumnSearchTitle.Image = null;
		mobjColumnSearchTitle.Text = "Title";
		mobjColumnSearchTitle.Width = 110;
		mobjColumnSearchLocation.Image = null;
		mobjColumnSearchLocation.Text = "Location";
		mobjColumnSearchLocation.Width = 80;
		mobjColumnSearchRank.Image = null;
		mobjColumnSearchRank.Text = "Rank";
		mobjColumnSearchRank.Width = 50;
		mobjPanelSearchBottom.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelSearchBottom.ClientSize = new Size(241, 78);
		mobjPanelSearchBottom.Controls.Add(mobjCheckSeachTitles);
		mobjPanelSearchBottom.Controls.Add(mobjCheckMatchSimilarWords);
		mobjPanelSearchBottom.Controls.Add(mobjCheckSearchPreviousResults);
		mobjPanelSearchBottom.Cursor = Cursors.Default;
		mobjPanelSearchBottom.Dock = DockStyle.Bottom;
		mobjPanelSearchBottom.Location = new Point(0, 443);
		mobjPanelSearchBottom.Margin = new Padding(0);
		mobjPanelSearchBottom.Name = "mobjPanelSearchBottom";
		mobjPanelSearchBottom.Size = new Size(241, 78);
		mobjPanelSearchBottom.TabIndex = 0;
		mobjCheckSeachTitles.BackgroundImageLayout = ImageLayout.Tile;
		mobjCheckSeachTitles.Checked = false;
		mobjCheckSeachTitles.CheckState = CheckState.Unchecked;
		mobjCheckSeachTitles.ClientSize = new Size(172, 24);
		mobjCheckSeachTitles.Cursor = Cursors.Default;
		mobjCheckSeachTitles.FlatStyle = FlatStyle.Standard;
		mobjCheckSeachTitles.Location = new Point(3, 49);
		mobjCheckSeachTitles.Margin = new Padding(0);
		mobjCheckSeachTitles.Name = "mobjCheckSeachTitles";
		mobjCheckSeachTitles.Size = new Size(172, 24);
		mobjCheckSeachTitles.TabIndex = 0;
		mobjCheckSeachTitles.Text = "Search titles only";
		mobjCheckSeachTitles.ThreeState = false;
		mobjCheckMatchSimilarWords.BackgroundImageLayout = ImageLayout.Tile;
		mobjCheckMatchSimilarWords.Checked = false;
		mobjCheckMatchSimilarWords.CheckState = CheckState.Unchecked;
		mobjCheckMatchSimilarWords.ClientSize = new Size(172, 24);
		mobjCheckMatchSimilarWords.Cursor = Cursors.Default;
		mobjCheckMatchSimilarWords.FlatStyle = FlatStyle.Standard;
		mobjCheckMatchSimilarWords.Location = new Point(3, 28);
		mobjCheckMatchSimilarWords.Margin = new Padding(0);
		mobjCheckMatchSimilarWords.Name = "mobjCheckMatchSimilarWords";
		mobjCheckMatchSimilarWords.Size = new Size(172, 24);
		mobjCheckMatchSimilarWords.TabIndex = 0;
		mobjCheckMatchSimilarWords.Text = "Match similar words";
		mobjCheckMatchSimilarWords.ThreeState = false;
		mobjCheckSearchPreviousResults.BackgroundImageLayout = ImageLayout.Tile;
		mobjCheckSearchPreviousResults.Checked = false;
		mobjCheckSearchPreviousResults.CheckState = CheckState.Unchecked;
		mobjCheckSearchPreviousResults.ClientSize = new Size(191, 24);
		mobjCheckSearchPreviousResults.Cursor = Cursors.Default;
		mobjCheckSearchPreviousResults.FlatStyle = FlatStyle.Standard;
		mobjCheckSearchPreviousResults.Location = new Point(4, 7);
		mobjCheckSearchPreviousResults.Margin = new Padding(0);
		mobjCheckSearchPreviousResults.Name = "mobjCheckSearchPreviousResults";
		mobjCheckSearchPreviousResults.Size = new Size(191, 24);
		mobjCheckSearchPreviousResults.TabIndex = 0;
		mobjCheckSearchPreviousResults.Text = "Search previous results";
		mobjCheckSearchPreviousResults.ThreeState = false;
		mobjPanelSeachTop.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelSeachTop.ClientSize = new Size(241, 83);
		mobjPanelSeachTop.Controls.Add(mobjLabelSearchFound);
		mobjPanelSeachTop.Controls.Add(mobjLabelSearchSelectTopic);
		mobjPanelSeachTop.Controls.Add(mobjButtonSeachListTopics);
		mobjPanelSeachTop.Controls.Add(mobjButtonSearchDisplay);
		mobjPanelSeachTop.Controls.Add(mobjButtonSearchOperators);
		mobjPanelSeachTop.Controls.Add(mobjComboSearchWildcard);
		mobjPanelSeachTop.Cursor = Cursors.Default;
		mobjPanelSeachTop.Dock = DockStyle.Top;
		mobjPanelSeachTop.Location = new Point(0, 23);
		mobjPanelSeachTop.Margin = new Padding(0);
		mobjPanelSeachTop.Name = "mobjPanelSeachTop";
		mobjPanelSeachTop.Size = new Size(241, 83);
		mobjPanelSeachTop.TabIndex = 0;
		mobjLabelSearchFound.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelSearchFound.ClientSize = new Size(100, 15);
		mobjLabelSearchFound.Cursor = Cursors.Default;
		mobjLabelSearchFound.FlatStyle = FlatStyle.Flat;
		mobjLabelSearchFound.Location = new Point(135, 65);
		mobjLabelSearchFound.Margin = new Padding(0);
		mobjLabelSearchFound.Name = "mobjLabelSearchFound";
		mobjLabelSearchFound.Size = new Size(100, 15);
		mobjLabelSearchFound.TabIndex = 0;
		mobjLabelSearchFound.Text = "Found: 0";
		mobjLabelSearchSelectTopic.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelSearchSelectTopic.ClientSize = new Size(82, 15);
		mobjLabelSearchSelectTopic.Cursor = Cursors.Default;
		mobjLabelSearchSelectTopic.FlatStyle = FlatStyle.Flat;
		mobjLabelSearchSelectTopic.Location = new Point(3, 65);
		mobjLabelSearchSelectTopic.Margin = new Padding(0);
		mobjLabelSearchSelectTopic.Name = "mobjLabelSearchSelectTopic";
		mobjLabelSearchSelectTopic.Size = new Size(82, 15);
		mobjLabelSearchSelectTopic.TabIndex = 0;
		mobjLabelSearchSelectTopic.Text = "Select topic:";
		mobjButtonSeachListTopics.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonSeachListTopics.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonSeachListTopics.ClientSize = new Size(69, 23);
		mobjButtonSeachListTopics.Cursor = Cursors.Default;
		mobjButtonSeachListTopics.Location = new Point(100, 31);
		mobjButtonSeachListTopics.Margin = new Padding(0);
		mobjButtonSeachListTopics.Name = "mobjButtonSeachListTopics";
		mobjButtonSeachListTopics.Size = new Size(69, 23);
		mobjButtonSeachListTopics.TabIndex = 0;
		mobjButtonSeachListTopics.Text = "List Topics";
		mobjButtonSeachListTopics.Click += mobjButtonSeachListTopics_Click;
		mobjButtonSearchDisplay.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonSearchDisplay.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonSearchDisplay.ClientSize = new Size(69, 23);
		mobjButtonSearchDisplay.Cursor = Cursors.Default;
		mobjButtonSearchDisplay.Location = new Point(173, 31);
		mobjButtonSearchDisplay.Margin = new Padding(0);
		mobjButtonSearchDisplay.Name = "mobjButtonSearchDisplay";
		mobjButtonSearchDisplay.Size = new Size(69, 23);
		mobjButtonSearchDisplay.TabIndex = 0;
		mobjButtonSearchDisplay.Text = "Display";
		mobjButtonSearchDisplay.Click += mobjButtonSearchDisplay_Click;
		mobjButtonSearchOperators.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonSearchOperators.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonSearchOperators.ClientSize = new Size(17, 23);
		mobjButtonSearchOperators.Cursor = Cursors.Default;
		mobjButtonSearchOperators.DropDownMenu = mobjMenuSearchOperators;
		mobjButtonSearchOperators.Location = new Point(225, 4);
		mobjButtonSearchOperators.Margin = new Padding(0);
		mobjButtonSearchOperators.Name = "mobjButtonSearchOperators";
		mobjButtonSearchOperators.Size = new Size(17, 23);
		mobjButtonSearchOperators.TabIndex = 0;
		mobjButtonSearchOperators.MenuClick += mobjButtonSearchOperators_MenuClick;
		mobjMenuSearchOperators.MenuItems.AddRange(new MenuItem[4] { mobjMenuSearchAND, mobjMenuSearchOR, mobjMenuSearchNEAR, mobjMenuSearchNOT });
		mobjMenuSearchAND.Tag = "AND";
		mobjMenuSearchAND.Text = "AND";
		mobjMenuSearchOR.Tag = "OR";
		mobjMenuSearchOR.Text = "OR";
		mobjMenuSearchNEAR.Tag = "NEAR";
		mobjMenuSearchNEAR.Text = "NEAR";
		mobjMenuSearchNOT.Tag = "NOT";
		mobjMenuSearchNOT.Text = "NOT";
		mobjComboSearchWildcard.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
		mobjComboSearchWildcard.BackgroundImageLayout = ImageLayout.Tile;
		mobjComboSearchWildcard.BorderStyle = BorderStyle.Fixed3D;
		mobjComboSearchWildcard.ClientSize = new Size(223, 21);
		mobjComboSearchWildcard.Cursor = Cursors.Default;
		mobjComboSearchWildcard.Location = new Point(0, 4);
		mobjComboSearchWildcard.Margin = new Padding(0);
		mobjComboSearchWildcard.Name = "mobjComboSearchWildcard";
		mobjComboSearchWildcard.Size = new Size(223, 21);
		mobjComboSearchWildcard.TabIndex = 0;
		mobjLabelSearch.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelSearch.ClientSize = new Size(241, 23);
		mobjLabelSearch.Cursor = Cursors.Default;
		mobjLabelSearch.Dock = DockStyle.Top;
		mobjLabelSearch.FlatStyle = FlatStyle.Flat;
		mobjLabelSearch.Location = new Point(0, 0);
		mobjLabelSearch.Margin = new Padding(0);
		mobjLabelSearch.Name = "mobjLabelSearch";
		mobjLabelSearch.Size = new Size(241, 23);
		mobjLabelSearch.TabIndex = 0;
		mobjLabelSearch.Text = "Type in the word(s) to search for:";
		mobjLabelSearch.TextAlign = ContentAlignment.MiddleLeft;
		mobjTabFavorites.BackgroundImageLayout = ImageLayout.Tile;
		mobjTabFavorites.ClientSize = new Size(247, 521);
		mobjTabFavorites.Controls.Add(mobjPanelFavoritesBottom);
		mobjTabFavorites.Controls.Add(mobjListFavorites);
		mobjTabFavorites.Controls.Add(mobjLabelFavorites);
		mobjTabFavorites.Cursor = Cursors.Default;
		mobjTabFavorites.DockPadding.All = 3;
		mobjTabFavorites.Location = new Point(4, 22);
		mobjTabFavorites.Margin = new Padding(0);
		mobjTabFavorites.Name = "mobjTabFavorites";
		mobjTabFavorites.Size = new Size(247, 521);
		mobjTabFavorites.TabIndex = 3;
		mobjTabFavorites.Text = "Favorites";
		mobjPanelFavoritesBottom.BackgroundImageLayout = ImageLayout.Tile;
		mobjPanelFavoritesBottom.ClientSize = new Size(241, 113);
		mobjPanelFavoritesBottom.Controls.Add(mobjLabelFavoritesCurrentTopic);
		mobjPanelFavoritesBottom.Controls.Add(mobjTextFavoritesCurrentTopic);
		mobjPanelFavoritesBottom.Controls.Add(mobjButtonFavoritesAdd);
		mobjPanelFavoritesBottom.Controls.Add(mobjButtonFavoritesRemove);
		mobjPanelFavoritesBottom.Controls.Add(mobjButtonFavoritesDisplay);
		mobjPanelFavoritesBottom.Cursor = Cursors.Default;
		mobjPanelFavoritesBottom.Dock = DockStyle.Bottom;
		mobjPanelFavoritesBottom.Location = new Point(0, 408);
		mobjPanelFavoritesBottom.Margin = new Padding(0);
		mobjPanelFavoritesBottom.Name = "mobjPanelFavoritesBottom";
		mobjPanelFavoritesBottom.Size = new Size(241, 113);
		mobjPanelFavoritesBottom.TabIndex = 0;
		mobjLabelFavoritesCurrentTopic.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelFavoritesCurrentTopic.ClientSize = new Size(97, 16);
		mobjLabelFavoritesCurrentTopic.Cursor = Cursors.Default;
		mobjLabelFavoritesCurrentTopic.FlatStyle = FlatStyle.Flat;
		mobjLabelFavoritesCurrentTopic.Location = new Point(4, 42);
		mobjLabelFavoritesCurrentTopic.Margin = new Padding(0);
		mobjLabelFavoritesCurrentTopic.Name = "mobjLabelFavoritesCurrentTopic";
		mobjLabelFavoritesCurrentTopic.Size = new Size(97, 16);
		mobjLabelFavoritesCurrentTopic.TabIndex = 0;
		mobjLabelFavoritesCurrentTopic.Text = "Current Topic:";
		mobjTextFavoritesCurrentTopic.AcceptsReturn = true;
		mobjTextFavoritesCurrentTopic.AcceptsTab = true;
		mobjTextFavoritesCurrentTopic.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
		mobjTextFavoritesCurrentTopic.BackgroundImageLayout = ImageLayout.Tile;
		mobjTextFavoritesCurrentTopic.ClientSize = new Size(240, 20);
		mobjTextFavoritesCurrentTopic.Cursor = Cursors.Default;
		mobjTextFavoritesCurrentTopic.Lines = new string[0];
		mobjTextFavoritesCurrentTopic.Location = new Point(0, 61);
		mobjTextFavoritesCurrentTopic.Margin = new Padding(0);
		mobjTextFavoritesCurrentTopic.MaxLength = 0;
		mobjTextFavoritesCurrentTopic.Multiline = false;
		mobjTextFavoritesCurrentTopic.Name = "mobjTextFavoritesCurrentTopic";
		mobjTextFavoritesCurrentTopic.ReadOnly = false;
		mobjTextFavoritesCurrentTopic.ScrollBars = ScrollBars.Both;
		mobjTextFavoritesCurrentTopic.Size = new Size(240, 20);
		mobjTextFavoritesCurrentTopic.TabIndex = 0;
		mobjTextFavoritesCurrentTopic.TextAlign = HorizontalAlignment.Left;
		mobjTextFavoritesCurrentTopic.Validator = null;
		mobjTextFavoritesCurrentTopic.WordWrap = false;
		mobjButtonFavoritesAdd.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonFavoritesAdd.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonFavoritesAdd.ClientSize = new Size(65, 23);
		mobjButtonFavoritesAdd.Cursor = Cursors.Default;
		mobjButtonFavoritesAdd.Location = new Point(175, 87);
		mobjButtonFavoritesAdd.Margin = new Padding(0);
		mobjButtonFavoritesAdd.Name = "mobjButtonFavoritesAdd";
		mobjButtonFavoritesAdd.Size = new Size(65, 23);
		mobjButtonFavoritesAdd.TabIndex = 0;
		mobjButtonFavoritesAdd.Text = "Add";
		mobjButtonFavoritesAdd.Click += mobjButtonFavoritesAdd_Click;
		mobjButtonFavoritesRemove.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonFavoritesRemove.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonFavoritesRemove.ClientSize = new Size(69, 23);
		mobjButtonFavoritesRemove.Cursor = Cursors.Default;
		mobjButtonFavoritesRemove.Location = new Point(103, 3);
		mobjButtonFavoritesRemove.Margin = new Padding(0);
		mobjButtonFavoritesRemove.Name = "mobjButtonFavoritesRemove";
		mobjButtonFavoritesRemove.Size = new Size(69, 23);
		mobjButtonFavoritesRemove.TabIndex = 0;
		mobjButtonFavoritesRemove.Text = "Remove";
		mobjButtonFavoritesRemove.Click += mobjButtonFavoritesRemove_Click;
		mobjButtonFavoritesDisplay.Anchor = AnchorStyles.Right | AnchorStyles.Top;
		mobjButtonFavoritesDisplay.BackgroundImageLayout = ImageLayout.Tile;
		mobjButtonFavoritesDisplay.ClientSize = new Size(66, 23);
		mobjButtonFavoritesDisplay.Cursor = Cursors.Default;
		mobjButtonFavoritesDisplay.Location = new Point(175, 3);
		mobjButtonFavoritesDisplay.Margin = new Padding(0);
		mobjButtonFavoritesDisplay.Name = "mobjButtonFavoritesDisplay";
		mobjButtonFavoritesDisplay.Size = new Size(66, 23);
		mobjButtonFavoritesDisplay.TabIndex = 0;
		mobjButtonFavoritesDisplay.Text = "Display";
		mobjButtonFavoritesDisplay.Click += mobjButtonFavoritesDisplay_Click;
		mobjListFavorites.BackgroundImageLayout = ImageLayout.Tile;
		mobjListFavorites.BorderStyle = BorderStyle.Fixed3D;
		mobjListFavorites.ClientSize = new Size(241, 218);
		mobjListFavorites.Cursor = Cursors.Default;
		mobjListFavorites.Dock = DockStyle.Fill;
		mobjListFavorites.Location = new Point(0, 23);
		mobjListFavorites.Margin = new Padding(0);
		mobjListFavorites.Name = "mobjListFavorites";
		mobjListFavorites.SelectionMode = SelectionMode.One;
		mobjListFavorites.Size = new Size(241, 218);
		mobjListFavorites.TabIndex = 0;
		mobjLabelFavorites.BackgroundImageLayout = ImageLayout.Tile;
		mobjLabelFavorites.ClientSize = new Size(241, 23);
		mobjLabelFavorites.Cursor = Cursors.Default;
		mobjLabelFavorites.Dock = DockStyle.Top;
		mobjLabelFavorites.FlatStyle = FlatStyle.Flat;
		mobjLabelFavorites.Location = new Point(0, 0);
		mobjLabelFavorites.Margin = new Padding(0);
		mobjLabelFavorites.Name = "mobjLabelFavorites";
		mobjLabelFavorites.Size = new Size(241, 23);
		mobjLabelFavorites.TabIndex = 0;
		mobjLabelFavorites.Text = "Topics:";
		mobjLabelFavorites.TextAlign = ContentAlignment.MiddleLeft;
		mobjSplitterMain.BackgroundImageLayout = ImageLayout.Tile;
		mobjSplitterMain.ClientSize = new Size(3, 699);
		mobjSplitterMain.Cursor = Cursors.Default;
		mobjSplitterMain.Dock = DockStyle.Left;
		mobjSplitterMain.Location = new Point(258, 34);
		mobjSplitterMain.Margin = new Padding(0);
		mobjSplitterMain.Name = "mobjSplitterMain";
		mobjSplitterMain.Size = new Size(3, 699);
		mobjSplitterMain.TabIndex = 0;
		mobjHtml.BackgroundImageLayout = ImageLayout.Tile;
		mobjHtml.ClientSize = new Size(472, 699);
		mobjHtml.ContentType = "text/html";
		mobjHtml.Cursor = Cursors.Default;
		mobjHtml.Dock = DockStyle.Fill;
		mobjHtml.Expires = -1;
		mobjHtml.Html = "";
		mobjHtml.Location = new Point(261, 34);
		mobjHtml.Margin = new Padding(0);
		mobjHtml.Name = "mobjHtml";
		mobjHtml.Path = "";
		mobjHtml.Resource = null;
		mobjHtml.Size = new Size(472, 699);
		mobjHtml.TabIndex = 0;
		mobjHtml.Text = "htmlBox1";
		mobjHtml.Url = "";
		base.ClientSize = new Size(736, 584);
		base.Controls.Add(mobjHtml);
		base.Controls.Add(mobjSplitterMain);
		base.Controls.Add(mobjTabControl);
		base.Controls.Add(mobjPanelMainSpace);
		base.Controls.Add(mobToolBar);
		base.DockPadding.All = 3;
		base.Location = new Point(15, 15);
		base.Menu = mobjMainMenu;
		base.Size = new Size(736, 584);
		Text = "Help";
		ResumeLayout(blnPerformLayout: false);
		base.Load += HelpDialog_Load;
	}

	private void EnsureCHMReady()
	{
		mstrCHMDefaultHash = CHMExplorerController.Create(CHMLocation, mstrCHMDefaultHash);
		mobjController = CHMExplorerController.Get(mstrCHMDefaultHash);
	}

	private void EnsureCHMToc()
	{
		LoadCHMToc(mobjTreeView.Nodes, mobjController.Root);
	}

	private void NavigateCHMHome()
	{
		NavigateCHMHome(blnFirstTime: false);
	}

	private void NavigateCHMHome(bool blnFirstTime)
	{
		bool flag = false;
		string text = InitializationParam as string;
		if (blnFirstTime)
		{
			switch (InitializationCommand)
			{
			case HelpNavigator.Topic:
				mobjTabControl.SelectedItem = mobjTabIndex;
				break;
			case HelpNavigator.KeywordIndex:
				mobjTabControl.SelectedItem = mobjTabIndex;
				if (text != null)
				{
					IndexItem indexItem = mobjController.PerformSingleIndexSearch(text);
					if (indexItem != null && indexItem.Topics.Count > 0)
					{
						NavigateLocal(((IndexTopic)indexItem.Topics[0]).Local);
						flag = true;
					}
				}
				break;
			case HelpNavigator.Index:
				mobjTabControl.SelectedItem = mobjTabIndex;
				break;
			case HelpNavigator.Find:
				mobjTabControl.SelectedItem = mobjTabSearch;
				break;
			case HelpNavigator.AssociateIndex:
				mobjTabControl.SelectedItem = mobjTabIndex;
				break;
			}
		}
		if (!flag && mobjController != null && mobjController.DefaultLocal != null)
		{
			NavigateLocal(mobjController.DefaultLocal);
		}
	}

	private void NavigateLocal(string strLocal)
	{
		mobjHtml.Url = GetCHMContentUrl(strLocal);
		mobjHtml.Update();
	}

	private string GetCHMContentUrl(string strLocal)
	{
		return $"{CHMExplorerController.RedirectionTemplateRoot}?chm={mstrCHMDefaultHash}&src={CHMExplorerController.ExtractLocal(strLocal)}";
	}

	private string GetCHMResourceUrl(string strLocal)
	{
		return $"{CHMExplorerController.ResourceTemplateRoot}?chm={mstrCHMDefaultHash}&src={strLocal}";
	}

	private void LoadCHMToc(TreeNodeCollection objTreeNodes, CHMExplorerNode objNode)
	{
		objTreeNodes.Clear();
		CHMExplorerNode[] nodes = objNode.Nodes;
		foreach (CHMExplorerNode cHMExplorerNode in nodes)
		{
			bool flag = cHMExplorerNode.Nodes.Length != 0;
			TreeNode treeNode = new TreeNode(cHMExplorerNode.Name);
			treeNode.Tag = cHMExplorerNode;
			treeNode.HasNodes = flag;
			treeNode.Loaded = !flag;
			treeNode.IsExpanded = !flag;
			treeNode.BeforeExpand += objTreeNode_BeforeExpand;
			treeNode.BeforeSelect += objTreeNode_BeforeSelect;
			if (cHMExplorerNode.HasNodes)
			{
				treeNode.Image = mobjClosedBookResourceHandle;
				treeNode.ExpandedImage = mobjOpenBookResourceHandle;
			}
			else
			{
				treeNode.Image = mobjTopicResourceHandle;
			}
			objTreeNodes.Add(treeNode);
		}
	}

	private void objTreeNode_BeforeSelect(object objSource, TreeViewCancelEventArgs objArgs)
	{
		if (objArgs.Node.Tag is CHMExplorerNode cHMExplorerNode)
		{
			mobjHtml.Url = GetCHMContentUrl(cHMExplorerNode.Local);
			mobjHtml.Update();
		}
	}

	private void objTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
	{
		if (!objArgs.Node.Loaded)
		{
			LoadCHMToc(objArgs.Node.Nodes, objArgs.Node.Tag as CHMExplorerNode);
			objArgs.Node.Loaded = true;
		}
	}

	private void HelpDialog_Load(object sender, EventArgs e)
	{
		EnsureCHMReady();
		EnsureCHMToc();
		NavigateCHMHome(blnFirstTime: true);
		Text = mobjController.Title;
	}

	private void PerformAction(string strAction)
	{
		switch (strAction)
		{
		case "Print":
			mobjHtml.Print();
			break;
		case "Home":
			NavigateCHMHome();
			break;
		case "NEAR":
		case "OR":
		case "AND":
		case "NOT":
			mobjComboSearchWildcard.Text += $" {strAction} ";
			break;
		case "Exit":
			Close();
			break;
		default:
			MessageBox.Show("This ");
			break;
		}
	}

	private void mobjButtonSeachListTopics_Click(object sender, EventArgs e)
	{
		if (!(mobjComboSearchWildcard.Text != ""))
		{
			return;
		}
		if (!mobjComboSearchWildcard.Items.Contains(mobjComboSearchWildcard.Text))
		{
			mobjComboSearchWildcard.Items.Add(mobjComboSearchWildcard.Text);
			mobjComboSearchWildcard.Update();
		}
		if (mobjComboSearchWildcard.Items.Count > 7)
		{
			mobjComboSearchWildcard.Items.RemoveAt(0);
		}
		mobjListSearch.Items.Clear();
		int num = 0;
		DataTable dataTable = mobjController.PerformSearch(mobjComboSearchWildcard.Text, 300, mobjCheckMatchSimilarWords.Checked, mobjCheckSeachTitles.Checked);
		if (dataTable != null)
		{
			num = dataTable.DefaultView.Count;
			for (int i = 0; i < num; i++)
			{
				ListViewItem listViewItem = mobjListSearch.Items.Add(dataTable.DefaultView[i].Row["Title"].ToString());
				listViewItem.SubItems.Add(dataTable.DefaultView[i].Row["Location"].ToString());
				listViewItem.SubItems.Add(dataTable.DefaultView[i].Row["Rating"].ToString());
				listViewItem.Tag = new CHMSearchItem(dataTable.DefaultView[i].Row["Title"].ToString(), dataTable.DefaultView[i].Row["URL"].ToString(), dataTable.DefaultView[i].Row["Location"].ToString(), (double)dataTable.DefaultView[i].Row["Rating"]);
			}
		}
		mobjLabelSearchFound.Text = $"Found: {num}";
	}

	private void mobjButtonSearchDisplay_Click(object sender, EventArgs e)
	{
		if (mobjListSearch.SelectedItem != null)
		{
			NavigateLocal(((CHMSearchItem)mobjListSearch.SelectedItem.Tag).URL);
		}
	}

	private void mobjTextBoxIndex_EnterKeyDown(object objSender, KeyEventArgs objArgs)
	{
		mobjListIndex.Items.Clear();
		ArrayList arrayList = mobjController.PerformIndexSearch(mobjTextBoxIndex.Text, 300);
		foreach (IndexItem item in arrayList)
		{
			ListViewItem listViewItem = mobjListIndex.Items.Add(item.IndentKeyWord);
			listViewItem.Tag = item;
		}
	}

	private void mobjButtonFavoritesRemove_Click(object sender, EventArgs e)
	{
	}

	private void mobjButtonFavoritesDisplay_Click(object sender, EventArgs e)
	{
	}

	private void mobjButtonFavoritesAdd_Click(object sender, EventArgs e)
	{
	}

	private void mobjButtonIndexDisplay_Click(object sender, EventArgs e)
	{
		if (mobjListIndex.SelectedItem != null)
		{
			IndexItem indexItem = (IndexItem)mobjListIndex.SelectedItem.Tag;
			if (indexItem.Topics.Count == 1)
			{
				NavigateLocal(((IndexTopic)indexItem.Topics[0]).Local);
				return;
			}
			TopicsDialog topicsDialog = new TopicsDialog(indexItem.Topics);
			topicsDialog.Closed += TopicsDialog_Closed;
			topicsDialog.ShowDialog();
		}
	}

	private void TopicsDialog_Closed(object sender, EventArgs e)
	{
		TopicsDialog topicsDialog = (TopicsDialog)sender;
		if (topicsDialog.IsCompleted)
		{
			NavigateLocal(topicsDialog.SelectedItem.Local);
		}
	}

	private void mobjButtonSearchOperators_MenuClick(object objSource, MenuItemEventArgs objArgs)
	{
		PerformAction((string)objArgs.MenuItem.Tag);
	}

	private void mobToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
	{
		PerformAction((string)e.Button.Tag);
	}

	private void mobjMainMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
	{
		PerformAction((string)objArgs.MenuItem.Tag);
	}

	private void mobjListIndex_DoubleClick(object sender, EventArgs e)
	{
		mobjButtonIndexDisplay_Click(mobjButtonIndexDisplay, EventArgs.Empty);
	}

	private void mobjListSearch_DoubleClick(object sender, EventArgs e)
	{
		if (mobjListSearch.SelectedItem != null)
		{
			NavigateLocal(((CHMSearchItem)mobjListSearch.SelectedItem.Tag).URL);
		}
	}
}
