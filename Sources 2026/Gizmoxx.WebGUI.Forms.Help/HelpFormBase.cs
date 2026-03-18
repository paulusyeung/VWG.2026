#region Using

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.HelpLibrary;
using Gizmox.WebGUI.Common.Resources;
using System.IO;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region HelpFormBase Class

    /// <summary>
    /// Summary description for HelpFormBase.
	/// </summary>
    [Skin(typeof(HelpFormBaseSkin))]
	public abstract class HelpFormBase : Form, IRequiresRegistration
	{
		#region Class Members
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        private Gizmox.WebGUI.Forms.MainMenu mobjMainMenu;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuFile;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuPrint;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuFileSep;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuExit;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuEdit;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuCopy;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSelectAll;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuEditSep;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuFindInTopic;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuView;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuGo;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuHelp;
        private Gizmox.WebGUI.Forms.MenuItem monjMenuNavigationTabs;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuViewSep1;
        private Gizmox.WebGUI.Forms.MenuItem monjMenuContents;
        private Gizmox.WebGUI.Forms.MenuItem monjMenuIndex;
        private Gizmox.WebGUI.Forms.MenuItem monjMenuSearch;
        private Gizmox.WebGUI.Forms.MenuItem monjMenuFavorites;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuBack;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuForward;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuNextInContents;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuPreviousInContents;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuHome;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuGoSep;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuJumpToURL;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuAboutHTMLHelp;
        private Gizmox.WebGUI.Forms.ToolBar mobToolBar;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonHide;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonLocate;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonPrevious;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonNext;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonBack;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonForward;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonHome;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonPrint;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonSep1;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonSep2;
        private Gizmox.WebGUI.Forms.Panel mobjPanelMainSpace;
        private Gizmox.WebGUI.Forms.TabControl mobjTabControl;
        private Gizmox.WebGUI.Forms.TabPage mobjTabContents;
        private Gizmox.WebGUI.Forms.TabPage mobjTabIndex;
        private Gizmox.WebGUI.Forms.TabPage mobjTabSearch;
        private Gizmox.WebGUI.Forms.TabPage mobjTabFavorites;
        private Gizmox.WebGUI.Forms.Splitter mobjSplitterMain;
        private Gizmox.WebGUI.Forms.HtmlBox mobjHtml;
        private Gizmox.WebGUI.Forms.TreeView mobjTreeView;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBoxIndex;
        private Gizmox.WebGUI.Forms.Panel mobjPanelIndexBottom;
        private Gizmox.WebGUI.Forms.Panel mobjPanelIndexSpace;
        private Gizmox.WebGUI.Forms.ListView mobjListSearch;
        private Gizmox.WebGUI.Forms.Panel mobjPanelSearchBottom;
        private Gizmox.WebGUI.Forms.Panel mobjPanelSeachTop;
        private Gizmox.WebGUI.Forms.Label mobjLabelIndex;
        private Gizmox.WebGUI.Forms.Label mobjLabelSearch;
        private Gizmox.WebGUI.Forms.Label mobjLabelFavorites;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckSeachTitles;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckMatchSimilarWords;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckSearchPreviousResults;
        private Gizmox.WebGUI.Forms.Panel mobjPanelFavoritesBottom;
        private Gizmox.WebGUI.Forms.Label mobjLabelFavoritesCurrentTopic;
        private Gizmox.WebGUI.Forms.TextBox mobjTextFavoritesCurrentTopic;
        private Gizmox.WebGUI.Forms.Button mobjButtonFavoritesAdd;
        private Gizmox.WebGUI.Forms.Button mobjButtonFavoritesRemove;
        private Gizmox.WebGUI.Forms.Button mobjButtonFavoritesDisplay;
        private Gizmox.WebGUI.Forms.ListBox mobjListFavorites;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSearchTitle;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSearchLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSearchRank;
        private Gizmox.WebGUI.Forms.ToolBarButton mobjTBButtonFind;
        private Gizmox.WebGUI.Forms.Button mobjButtonIndexDisplay;
        private Gizmox.WebGUI.Forms.Button mobjButtonSearchOperators;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboSearchWildcard;
        private Gizmox.WebGUI.Forms.Label mobjLabelSearchFound;
        private Gizmox.WebGUI.Forms.Label mobjLabelSearchSelectTopic;
        private Gizmox.WebGUI.Forms.Button mobjButtonSeachListTopics;
        private Gizmox.WebGUI.Forms.Button mobjButtonSearchDisplay;
        private Gizmox.WebGUI.Forms.ContextMenu mobjMenuSearchOperators;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSearchAND;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSearchOR;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSearchNEAR;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSearchNOT;
        private Gizmox.WebGUI.Forms.ListView mobjListIndex;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnIndexText;
        
        private string mstrCHMDefaultHash = null;
        private bool mblnTestingMode = false;

        private static SkinResourceHandle mobjOpenBookResourceHandle = new SkinResourceHandle(typeof(Skins.HelpFormBaseSkin), "OpenBook.gif");
        private static SkinResourceHandle mobjClosedBookResourceHandle = new SkinResourceHandle(typeof(Skins.HelpFormBaseSkin), "ClosedBook.gif");
        private static SkinResourceHandle mobjTopicResourceHandle = new SkinResourceHandle(typeof(Skins.HelpFormBaseSkin), "Topic.gif");

        
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		///
		/// </summary>
		internal HelpFormBase()
		{
			// This call is required by the WebGUI Form Designer.
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
		
		
		#endregion C'Tor\D'Tor
		
		#region Form Designer generated code
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            SkinResourceHandle skinResourceHandle1 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "TableOfContent.gif");
            SkinResourceHandle skinResourceHandle2 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Sync.gif");
            SkinResourceHandle skinResourceHandle3 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Next.gif");
            SkinResourceHandle skinResourceHandle4 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Back.gif");
            SkinResourceHandle skinResourceHandle5 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Up.gif");
            SkinResourceHandle skinResourceHandle6 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Down.gif");
            SkinResourceHandle skinResourceHandle7 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Find.gif");
            SkinResourceHandle skinResourceHandle8 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Home.gif");
            SkinResourceHandle skinResourceHandle9 = new Gizmox.WebGUI.Common.Resources.SkinResourceHandle(typeof(HelpFormBaseSkin), "Print.gif");
            this.mobjMainMenu = new Gizmox.WebGUI.Forms.MainMenu();
            this.mobjMenuFile = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuPrint = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuFileSep = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuExit = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuEdit = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuCopy = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuSelectAll = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuEditSep = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuFindInTopic = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuView = new Gizmox.WebGUI.Forms.MenuItem();
            this.monjMenuNavigationTabs = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuViewSep1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.monjMenuContents = new Gizmox.WebGUI.Forms.MenuItem();
            this.monjMenuIndex = new Gizmox.WebGUI.Forms.MenuItem();
            this.monjMenuSearch = new Gizmox.WebGUI.Forms.MenuItem();
            this.monjMenuFavorites = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuGo = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuBack = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuForward = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuNextInContents = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuPreviousInContents = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuHome = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuGoSep = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuJumpToURL = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuHelp = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuAboutHTMLHelp = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobToolBar = new Gizmox.WebGUI.Forms.ToolBar();
            this.mobjTBButtonHide = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonLocate = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonSep1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonNext = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonBack = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonPrevious = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonForward = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonSep2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonFind = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonHome = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjTBButtonPrint = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mobjPanelMainSpace = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTabControl = new Gizmox.WebGUI.Forms.TabControl();
            this.mobjTabContents = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjTreeView = new Gizmox.WebGUI.Forms.TreeView();
            this.mobjTabIndex = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjListIndex = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnIndexText = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjPanelIndexBottom = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButtonIndexDisplay = new Gizmox.WebGUI.Forms.Button();
            this.mobjPanelIndexSpace = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTextBoxIndex = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabelIndex = new Gizmox.WebGUI.Forms.Label();
            this.mobjTabSearch = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjListSearch = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnSearchTitle = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnSearchLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnSearchRank = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjPanelSearchBottom = new Gizmox.WebGUI.Forms.Panel();
            this.mobjCheckSeachTitles = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckMatchSimilarWords = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckSearchPreviousResults = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjPanelSeachTop = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabelSearchFound = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabelSearchSelectTopic = new Gizmox.WebGUI.Forms.Label();
            this.mobjButtonSeachListTopics = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonSearchDisplay = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonSearchOperators = new Gizmox.WebGUI.Forms.Button();
            this.mobjMenuSearchOperators = new Gizmox.WebGUI.Forms.ContextMenu();
            this.mobjMenuSearchAND = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuSearchOR = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuSearchNEAR = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuSearchNOT = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjComboSearchWildcard = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabelSearch = new Gizmox.WebGUI.Forms.Label();
            this.mobjTabFavorites = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjPanelFavoritesBottom = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabelFavoritesCurrentTopic = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextFavoritesCurrentTopic = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonFavoritesAdd = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonFavoritesRemove = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonFavoritesDisplay = new Gizmox.WebGUI.Forms.Button();
            this.mobjListFavorites = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjLabelFavorites = new Gizmox.WebGUI.Forms.Label();
            this.mobjSplitterMain = new Gizmox.WebGUI.Forms.Splitter();
            this.mobjHtml = new Gizmox.WebGUI.Forms.HtmlBox();
            this.SuspendLayout();
            // 
            // mobjMainMenu
            // 
            this.mobjMainMenu.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjMainMenu.ClientSize = new System.Drawing.Size(472, 22);
            this.mobjMainMenu.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mobjMainMenu.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjMainMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuFile,
            this.mobjMenuEdit,
            this.mobjMenuView,
            this.mobjMenuGo,
            this.mobjMenuHelp});
            this.mobjMainMenu.Name = "mobjMainMenu";
            this.mobjMainMenu.Size = new System.Drawing.Size(472, 22);
            this.mobjMainMenu.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.mobjMainMenu_MenuClick);
            // 
            // mobjMenuFile
            // 
            this.mobjMenuFile.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuPrint,
            this.mobjMenuFileSep,
            this.mobjMenuExit});
            this.mobjMenuFile.Tag = "File";
            this.mobjMenuFile.Text = "File";
            // 
            // mobjMenuPrint
            // 
            this.mobjMenuPrint.Tag = "Print";
            this.mobjMenuPrint.Text = "Print";
            // 
            // mobjMenuFileSep
            // 
            this.mobjMenuFileSep.Text = "-";
            // 
            // mobjMenuExit
            // 
            this.mobjMenuExit.Tag = "Exit";
            this.mobjMenuExit.Text = "Exit";
            // 
            // mobjMenuEdit
            // 
            this.mobjMenuEdit.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuCopy,
            this.mobjMenuSelectAll,
            this.mobjMenuEditSep,
            this.mobjMenuFindInTopic});
            this.mobjMenuEdit.Tag = "Edit";
            this.mobjMenuEdit.Text = "Edit";
            // 
            // mobjMenuCopy
            // 
            this.mobjMenuCopy.Tag = "Copy";
            this.mobjMenuCopy.Text = "Copy";
            // 
            // mobjMenuSelectAll
            // 
            this.mobjMenuSelectAll.Tag = "SelectAll";
            this.mobjMenuSelectAll.Text = "Select All";
            // 
            // mobjMenuEditSep
            // 
            this.mobjMenuEditSep.Text = "-";
            // 
            // mobjMenuFindInTopic
            // 
            this.mobjMenuFindInTopic.Tag = "FindInTopic";
            this.mobjMenuFindInTopic.Text = "Find In Topic...";
            // 
            // mobjMenuView
            // 
            this.mobjMenuView.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.monjMenuNavigationTabs,
            this.mobjMenuViewSep1,
            this.monjMenuContents,
            this.monjMenuIndex,
            this.monjMenuSearch,
            this.monjMenuFavorites});
            this.mobjMenuView.Tag = "View";
            this.mobjMenuView.Text = "View";
            // 
            // monjMenuNavigationTabs
            // 
            this.monjMenuNavigationTabs.Checked = true;
            this.monjMenuNavigationTabs.Text = "Navigation Tabs";
            // 
            // mobjMenuViewSep1
            // 
            this.mobjMenuViewSep1.Text = "-";
            // 
            // monjMenuContents
            // 
            this.monjMenuContents.Checked = true;
            this.monjMenuContents.Text = "Contents";
            // 
            // monjMenuIndex
            // 
            this.monjMenuIndex.Text = "Index";
            // 
            // monjMenuSearch
            // 
            this.monjMenuSearch.Text = "Search";
            // 
            // monjMenuFavorites
            // 
            this.monjMenuFavorites.Text = "Favorites";
            // 
            // mobjMenuGo
            // 
            this.mobjMenuGo.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuBack,
            this.mobjMenuForward,
            this.mobjMenuNextInContents,
            this.mobjMenuPreviousInContents,
            this.mobjMenuHome,
            this.mobjMenuGoSep,
            this.mobjMenuJumpToURL});
            this.mobjMenuGo.Tag = "Go";
            this.mobjMenuGo.Text = "Go";
            // 
            // mobjMenuBack
            // 
            this.mobjMenuBack.Tag = "Back";
            this.mobjMenuBack.Text = "Back";
            // 
            // mobjMenuForward
            // 
            this.mobjMenuForward.Tag = "Forward";
            this.mobjMenuForward.Text = "Forward";
            // 
            // mobjMenuNextInContents
            // 
            this.mobjMenuNextInContents.Text = "Next";
            // 
            // mobjMenuPreviousInContents
            // 
            this.mobjMenuPreviousInContents.Text = "Previous";
            // 
            // mobjMenuHome
            // 
            this.mobjMenuHome.Text = "Home";
            // 
            // mobjMenuGoSep
            // 
            this.mobjMenuGoSep.Text = "-";
            // 
            // mobjMenuJumpToURL
            // 
            this.mobjMenuJumpToURL.Tag = "JumpToURL";
            this.mobjMenuJumpToURL.Text = "Jump To URL";
            // 
            // mobjMenuHelp
            // 
            this.mobjMenuHelp.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuAboutHTMLHelp});
            this.mobjMenuHelp.Tag = "Help";
            this.mobjMenuHelp.Text = "Help";
            // 
            // mobjMenuAboutHTMLHelp
            // 
            this.mobjMenuAboutHTMLHelp.Tag = "AboutHTMLHelp";
            this.mobjMenuAboutHTMLHelp.Text = "About HTML Help...";
            // 
            // mobToolBar
            // 
            this.mobToolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Flat;
            this.mobToolBar.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobToolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.mobjTBButtonHide,
            this.mobjTBButtonLocate,
            this.mobjTBButtonSep1,
            this.mobjTBButtonNext,
            this.mobjTBButtonBack,
            this.mobjTBButtonPrevious,
            this.mobjTBButtonForward,
            this.mobjTBButtonSep2,
            this.mobjTBButtonFind,
            this.mobjTBButtonHome,
            this.mobjTBButtonPrint});
            this.mobToolBar.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobToolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobToolBar.DragHandle = true;
            this.mobToolBar.DropDownArrows = false;
            this.mobToolBar.ImageList = null;
            this.mobToolBar.Location = new System.Drawing.Point(3, 3);
            this.mobToolBar.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobToolBar.MenuHandle = true;
            this.mobToolBar.Name = "mobToolBar";
            this.mobToolBar.RightToLeft = RightToLeft.No;
            this.mobToolBar.ShowToolTips = true;
            this.mobToolBar.TabIndex = 0;
            this.mobToolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.mobToolBar_ButtonClick);
            // 
            // mobjTBButtonHide
            // 
            this.mobjTBButtonHide.CustomStyle = "";
            this.mobjTBButtonHide.Image = skinResourceHandle1;
            this.mobjTBButtonHide.ImageKey = null;
            this.mobjTBButtonHide.Name = "mobjTBButtonHide";
            this.mobjTBButtonHide.Pushed = true;
            this.mobjTBButtonHide.Size = 24;
            this.mobjTBButtonHide.Tag = "Hide";
            this.mobjTBButtonHide.ToolTipText = "Hide";
            // 
            // mobjTBButtonLocate
            // 
            this.mobjTBButtonLocate.CustomStyle = "";
            this.mobjTBButtonLocate.Image = skinResourceHandle2;
            this.mobjTBButtonLocate.ImageKey = null;
            this.mobjTBButtonLocate.Name = "mobjTBButtonLocate";
            this.mobjTBButtonLocate.Pushed = true;
            this.mobjTBButtonLocate.Size = 24;
            this.mobjTBButtonLocate.Tag = "Locate";
            this.mobjTBButtonLocate.ToolTipText = "Hide";
            // 
            // mobjTBButtonSep1
            // 
            this.mobjTBButtonSep1.CustomStyle = "";
            this.mobjTBButtonSep1.ImageKey = null;
            this.mobjTBButtonSep1.Name = "mobjTBButtonSep1";
            this.mobjTBButtonSep1.Pushed = true;
            this.mobjTBButtonSep1.Size = 24;
            this.mobjTBButtonSep1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.mobjTBButtonSep1.ToolTipText = "";
            // 
            // mobjTBButtonNext
            // 
            this.mobjTBButtonNext.CustomStyle = "";
            this.mobjTBButtonNext.Image = skinResourceHandle3;
            this.mobjTBButtonNext.ImageKey = null;
            this.mobjTBButtonNext.Name = "mobjTBButtonNext";
            this.mobjTBButtonNext.Pushed = true;
            this.mobjTBButtonNext.Size = 24;
            this.mobjTBButtonNext.Tag = "Next";
            this.mobjTBButtonNext.ToolTipText = "Next";
            // 
            // mobjTBButtonBack
            // 
            this.mobjTBButtonBack.CustomStyle = "";
            this.mobjTBButtonBack.Image = skinResourceHandle4;
            this.mobjTBButtonBack.ImageKey = null;
            this.mobjTBButtonBack.Name = "mobjTBButtonBack";
            this.mobjTBButtonBack.Pushed = true;
            this.mobjTBButtonBack.Size = 24;
            this.mobjTBButtonBack.Tag = "Back";
            this.mobjTBButtonBack.ToolTipText = "Back";
            // 
            // mobjTBButtonPrevious
            // 
            this.mobjTBButtonPrevious.CustomStyle = "";
            this.mobjTBButtonPrevious.Image = skinResourceHandle5;
            this.mobjTBButtonPrevious.ImageKey = null;
            this.mobjTBButtonPrevious.Name = "mobjTBButtonPrevious";
            this.mobjTBButtonPrevious.Pushed = true;
            this.mobjTBButtonPrevious.Size = 24;
            this.mobjTBButtonPrevious.Tag = "Previous";
            this.mobjTBButtonPrevious.ToolTipText = "Previous";
            // 
            // mobjTBButtonForward
            // 
            this.mobjTBButtonForward.CustomStyle = "";
            this.mobjTBButtonForward.Image = skinResourceHandle6;
            this.mobjTBButtonForward.ImageKey = null;
            this.mobjTBButtonForward.Name = "mobjTBButtonForward";
            this.mobjTBButtonForward.Pushed = true;
            this.mobjTBButtonForward.Size = 24;
            this.mobjTBButtonForward.Tag = "Forward";
            this.mobjTBButtonForward.ToolTipText = "Forward";
            // 
            // mobjTBButtonSep2
            // 
            this.mobjTBButtonSep2.CustomStyle = "";
            this.mobjTBButtonSep2.ImageKey = null;
            this.mobjTBButtonSep2.Name = "mobjTBButtonSep2";
            this.mobjTBButtonSep2.Pushed = true;
            this.mobjTBButtonSep2.Size = 24;
            this.mobjTBButtonSep2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.mobjTBButtonSep2.ToolTipText = "";
            // 
            // mobjTBButtonFind
            // 
            this.mobjTBButtonFind.CustomStyle = "";
            this.mobjTBButtonFind.Image = skinResourceHandle7;
            this.mobjTBButtonFind.ImageKey = null;
            this.mobjTBButtonFind.Name = "mobjTBButtonFind";
            this.mobjTBButtonFind.Pushed = true;
            this.mobjTBButtonFind.Size = 24;
            this.mobjTBButtonFind.Tag = "Find";
            this.mobjTBButtonFind.ToolTipText = "Find";
            // 
            // mobjTBButtonHome
            // 
            this.mobjTBButtonHome.CustomStyle = "";
            this.mobjTBButtonHome.Image = skinResourceHandle8;
            this.mobjTBButtonHome.ImageKey = null;
            this.mobjTBButtonHome.Name = "mobjTBButtonHome";
            this.mobjTBButtonHome.Pushed = true;
            this.mobjTBButtonHome.Size = 24;
            this.mobjTBButtonHome.Tag = "Home";
            this.mobjTBButtonHome.ToolTipText = "Home";
            // 
            // mobjTBButtonPrint
            // 
            this.mobjTBButtonPrint.CustomStyle = "";
            this.mobjTBButtonPrint.Image = skinResourceHandle9;
            this.mobjTBButtonPrint.ImageKey = null;
            this.mobjTBButtonPrint.Name = "mobjTBButtonPrint";
            this.mobjTBButtonPrint.Pushed = true;
            this.mobjTBButtonPrint.Size = 24;
            this.mobjTBButtonPrint.Tag = "Print";
            this.mobjTBButtonPrint.ToolTipText = "Print";
            // 
            // mobjPanelMainSpace
            // 
            this.mobjPanelMainSpace.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelMainSpace.ClientSize = new System.Drawing.Size(730, 3);
            this.mobjPanelMainSpace.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelMainSpace.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanelMainSpace.Location = new System.Drawing.Point(3, 31);
            this.mobjPanelMainSpace.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelMainSpace.Name = "mobjPanelMainSpace";
            this.mobjPanelMainSpace.Size = new System.Drawing.Size(730, 3);
            this.mobjPanelMainSpace.TabIndex = 0;
            // 
            // mobjTabControl
            // 
            this.mobjTabControl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTabControl.ClientSize = new System.Drawing.Size(255, 699);
            this.mobjTabControl.Controls.Add(this.mobjTabContents);
            this.mobjTabControl.Controls.Add(this.mobjTabIndex);
            this.mobjTabControl.Controls.Add(this.mobjTabSearch);
            this.mobjTabControl.Controls.Add(this.mobjTabFavorites);
            this.mobjTabControl.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjTabControl.Location = new System.Drawing.Point(3, 34);
            this.mobjTabControl.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTabControl.Name = "mobjTabControl";
            this.mobjTabControl.SelectedIndex = 0;
            this.mobjTabControl.Size = new System.Drawing.Size(255, 699);
            this.mobjTabControl.TabIndex = 0;
            // 
            // mobjTabContents
            // 
            this.mobjTabContents.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTabContents.ClientSize = new System.Drawing.Size(247, 521);
            this.mobjTabContents.Controls.Add(this.mobjTreeView);
            this.mobjTabContents.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTabContents.DockPadding.All = 3;
            this.mobjTabContents.Location = new System.Drawing.Point(4, 22);
            this.mobjTabContents.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTabContents.Name = "mobjTabContents";
            this.mobjTabContents.Size = new System.Drawing.Size(247, 521);
            this.mobjTabContents.TabIndex = 0;
            this.mobjTabContents.Text = "Contents";
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTreeView.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjTreeView.ClientSize = new System.Drawing.Size(241, 241);
            this.mobjTreeView.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.Location = new System.Drawing.Point(0, 0);
            this.mobjTreeView.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Size = new System.Drawing.Size(241, 241);
            this.mobjTreeView.TabIndex = 0;

            // 
            // mobjTabIndex
            // 
            this.mobjTabIndex.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTabIndex.ClientSize = new System.Drawing.Size(247, 521);
            this.mobjTabIndex.Controls.Add(this.mobjListIndex);
            this.mobjTabIndex.Controls.Add(this.mobjPanelIndexBottom);
            this.mobjTabIndex.Controls.Add(this.mobjPanelIndexSpace);
            this.mobjTabIndex.Controls.Add(this.mobjTextBoxIndex);
            this.mobjTabIndex.Controls.Add(this.mobjLabelIndex);
            this.mobjTabIndex.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTabIndex.DockPadding.All = 3;
            this.mobjTabIndex.Location = new System.Drawing.Point(4, 22);
            this.mobjTabIndex.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTabIndex.Name = "mobjTabIndex";
            this.mobjTabIndex.Size = new System.Drawing.Size(247, 521);
            this.mobjTabIndex.TabIndex = 1;
            this.mobjTabIndex.Text = "Index";
            // 
            // mobjListIndex
            // 
            this.mobjListIndex.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjListIndex.ClientSize = new System.Drawing.Size(241, 159);
            this.mobjListIndex.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnIndexText});
            this.mobjListIndex.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjListIndex.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListIndex.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.None;
            this.mobjListIndex.ItemsPerPage = 20;
            this.mobjListIndex.Location = new System.Drawing.Point(0, 46);
            this.mobjListIndex.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjListIndex.MultiSelect = false;
            this.mobjListIndex.Name = "mobjListIndex";
            this.mobjListIndex.Size = new System.Drawing.Size(241, 159);
            this.mobjListIndex.TabIndex = 0;
            this.mobjListIndex.UseInternalPaging = true;
            this.mobjListIndex.DoubleClick += new System.EventHandler(this.mobjListIndex_DoubleClick);
            // 
            // mobjColumnIndexText
            // 
            this.mobjColumnIndexText.Image = null;
            this.mobjColumnIndexText.Text = "";
            this.mobjColumnIndexText.Width = 250;
            // 
            // mobjPanelIndexBottom
            // 
            this.mobjPanelIndexBottom.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelIndexBottom.ClientSize = new System.Drawing.Size(241, 36);
            this.mobjPanelIndexBottom.Controls.Add(this.mobjButtonIndexDisplay);
            this.mobjPanelIndexBottom.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelIndexBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPanelIndexBottom.Location = new System.Drawing.Point(0, 485);
            this.mobjPanelIndexBottom.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelIndexBottom.Name = "mobjPanelIndexBottom";
            this.mobjPanelIndexBottom.Size = new System.Drawing.Size(241, 36);
            this.mobjPanelIndexBottom.TabIndex = 0;
            // 
            // mobjButtonIndexDisplay
            // 
            this.mobjButtonIndexDisplay.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonIndexDisplay.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonIndexDisplay.ClientSize = new System.Drawing.Size(69, 23);
            this.mobjButtonIndexDisplay.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonIndexDisplay.Location = new System.Drawing.Point(173, 3);
            this.mobjButtonIndexDisplay.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonIndexDisplay.Name = "mobjButtonIndexDisplay";
            this.mobjButtonIndexDisplay.Size = new System.Drawing.Size(69, 23);
            this.mobjButtonIndexDisplay.TabIndex = 0;
            this.mobjButtonIndexDisplay.Text = "Display";
            this.mobjButtonIndexDisplay.Click += new System.EventHandler(this.mobjButtonIndexDisplay_Click);
            // 
            // mobjPanelIndexSpace
            // 
            this.mobjPanelIndexSpace.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelIndexSpace.ClientSize = new System.Drawing.Size(241, 3);
            this.mobjPanelIndexSpace.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelIndexSpace.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanelIndexSpace.Location = new System.Drawing.Point(0, 43);
            this.mobjPanelIndexSpace.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelIndexSpace.Name = "mobjPanelIndexSpace";
            this.mobjPanelIndexSpace.Size = new System.Drawing.Size(241, 3);
            this.mobjPanelIndexSpace.TabIndex = 0;
            // 
            // mobjTextBoxIndex
            // 
            this.mobjTextBoxIndex.AcceptsReturn = true;
            this.mobjTextBoxIndex.AcceptsTab = true;
            this.mobjTextBoxIndex.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTextBoxIndex.ClientSize = new System.Drawing.Size(241, 20);
            this.mobjTextBoxIndex.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTextBoxIndex.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBoxIndex.Lines = new string[0];
            this.mobjTextBoxIndex.Location = new System.Drawing.Point(0, 23);
            this.mobjTextBoxIndex.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTextBoxIndex.MaxLength = 0;
            this.mobjTextBoxIndex.Multiline = false;
            this.mobjTextBoxIndex.Name = "mobjTextBoxIndex";
            this.mobjTextBoxIndex.ReadOnly = false;
            this.mobjTextBoxIndex.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextBoxIndex.Size = new System.Drawing.Size(241, 20);
            this.mobjTextBoxIndex.TabIndex = 0;
            this.mobjTextBoxIndex.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.mobjTextBoxIndex.Validator = null;
            this.mobjTextBoxIndex.WordWrap = false;
            this.mobjTextBoxIndex.EnterKeyDown += new KeyEventHandler(mobjTextBoxIndex_EnterKeyDown);
            // 
            // mobjLabelIndex
            // 
            this.mobjLabelIndex.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelIndex.ClientSize = new System.Drawing.Size(241, 23);
            this.mobjLabelIndex.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelIndex.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelIndex.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelIndex.Location = new System.Drawing.Point(0, 0);
            this.mobjLabelIndex.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelIndex.Name = "mobjLabelIndex";
            this.mobjLabelIndex.Size = new System.Drawing.Size(241, 23);
            this.mobjLabelIndex.TabIndex = 0;
            this.mobjLabelIndex.Text = "Type in keywords to find:";
            this.mobjLabelIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTabSearch
            // 
            this.mobjTabSearch.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTabSearch.ClientSize = new System.Drawing.Size(247, 521);
            this.mobjTabSearch.Controls.Add(this.mobjListSearch);
            this.mobjTabSearch.Controls.Add(this.mobjPanelSearchBottom);
            this.mobjTabSearch.Controls.Add(this.mobjPanelSeachTop);
            this.mobjTabSearch.Controls.Add(this.mobjLabelSearch);
            this.mobjTabSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTabSearch.DockPadding.All = 3;
            this.mobjTabSearch.Location = new System.Drawing.Point(4, 22);
            this.mobjTabSearch.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTabSearch.Name = "mobjTabSearch";
            this.mobjTabSearch.Size = new System.Drawing.Size(247, 521);
            this.mobjTabSearch.TabIndex = 2;
            this.mobjTabSearch.Text = "Search";
            // 
            // mobjListSearch
            // 
            this.mobjListSearch.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjListSearch.ClientSize = new System.Drawing.Size(241, 57);
            this.mobjListSearch.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnSearchTitle,
            this.mobjColumnSearchLocation,
            this.mobjColumnSearchRank});
            this.mobjListSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjListSearch.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListSearch.ItemsPerPage = 20;
            this.mobjListSearch.Location = new System.Drawing.Point(0, 106);
            this.mobjListSearch.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjListSearch.MultiSelect = false;
            this.mobjListSearch.Name = "mobjListSearch";
            this.mobjListSearch.Size = new System.Drawing.Size(241, 57);
            this.mobjListSearch.TabIndex = 0;
            this.mobjListSearch.UseInternalPaging = true;
            this.mobjListSearch.DoubleClick += new System.EventHandler(this.mobjListSearch_DoubleClick);
            this.mobjListSearch.ListViewItemSorter = new ListViewItemSorter(this.mobjListSearch);
            // 
            // mobjColumnSearchTitle
            // 
            this.mobjColumnSearchTitle.Image = null;
            this.mobjColumnSearchTitle.Text = "Title";
            this.mobjColumnSearchTitle.Width = 110;
            // 
            // mobjColumnSearchLocation
            // 
            this.mobjColumnSearchLocation.Image = null;
            this.mobjColumnSearchLocation.Text = "Location";
            this.mobjColumnSearchLocation.Width = 80;
            // 
            // mobjColumnSearchRank
            // 
            this.mobjColumnSearchRank.Image = null;
            this.mobjColumnSearchRank.Text = "Rank";
            this.mobjColumnSearchRank.Width = 50;
            // 
            // mobjPanelSearchBottom
            // 
            this.mobjPanelSearchBottom.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelSearchBottom.ClientSize = new System.Drawing.Size(241, 78);
            this.mobjPanelSearchBottom.Controls.Add(this.mobjCheckSeachTitles);
            this.mobjPanelSearchBottom.Controls.Add(this.mobjCheckMatchSimilarWords);
            this.mobjPanelSearchBottom.Controls.Add(this.mobjCheckSearchPreviousResults);
            this.mobjPanelSearchBottom.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelSearchBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPanelSearchBottom.Location = new System.Drawing.Point(0, 443);
            this.mobjPanelSearchBottom.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelSearchBottom.Name = "mobjPanelSearchBottom";
            this.mobjPanelSearchBottom.Size = new System.Drawing.Size(241, 78);
            this.mobjPanelSearchBottom.TabIndex = 0;
            // 
            // mobjCheckSeachTitles
            // 
            this.mobjCheckSeachTitles.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjCheckSeachTitles.Checked = false;
            this.mobjCheckSeachTitles.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckSeachTitles.ClientSize = new System.Drawing.Size(172, 24);
            this.mobjCheckSeachTitles.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjCheckSeachTitles.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckSeachTitles.Location = new System.Drawing.Point(3, 49);
            this.mobjCheckSeachTitles.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjCheckSeachTitles.Name = "mobjCheckSeachTitles";
            this.mobjCheckSeachTitles.Size = new System.Drawing.Size(172, 24);
            this.mobjCheckSeachTitles.TabIndex = 0;
            this.mobjCheckSeachTitles.Text = "Search titles only";
            this.mobjCheckSeachTitles.ThreeState = false;
            // 
            // mobjCheckMatchSimilarWords
            // 
            this.mobjCheckMatchSimilarWords.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjCheckMatchSimilarWords.Checked = false;
            this.mobjCheckMatchSimilarWords.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckMatchSimilarWords.ClientSize = new System.Drawing.Size(172, 24);
            this.mobjCheckMatchSimilarWords.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjCheckMatchSimilarWords.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckMatchSimilarWords.Location = new System.Drawing.Point(3, 28);
            this.mobjCheckMatchSimilarWords.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjCheckMatchSimilarWords.Name = "mobjCheckMatchSimilarWords";
            this.mobjCheckMatchSimilarWords.Size = new System.Drawing.Size(172, 24);
            this.mobjCheckMatchSimilarWords.TabIndex = 0;
            this.mobjCheckMatchSimilarWords.Text = "Match similar words";
            this.mobjCheckMatchSimilarWords.ThreeState = false;
            // 
            // mobjCheckSearchPreviousResults
            // 
            this.mobjCheckSearchPreviousResults.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjCheckSearchPreviousResults.Checked = false;
            this.mobjCheckSearchPreviousResults.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckSearchPreviousResults.ClientSize = new System.Drawing.Size(191, 24);
            this.mobjCheckSearchPreviousResults.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjCheckSearchPreviousResults.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckSearchPreviousResults.Location = new System.Drawing.Point(4, 7);
            this.mobjCheckSearchPreviousResults.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjCheckSearchPreviousResults.Name = "mobjCheckSearchPreviousResults";
            this.mobjCheckSearchPreviousResults.Size = new System.Drawing.Size(191, 24);
            this.mobjCheckSearchPreviousResults.TabIndex = 0;
            this.mobjCheckSearchPreviousResults.Text = "Search previous results";
            this.mobjCheckSearchPreviousResults.ThreeState = false;
            // 
            // mobjPanelSeachTop
            // 
            this.mobjPanelSeachTop.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelSeachTop.ClientSize = new System.Drawing.Size(241, 83);
            this.mobjPanelSeachTop.Controls.Add(this.mobjLabelSearchFound);
            this.mobjPanelSeachTop.Controls.Add(this.mobjLabelSearchSelectTopic);
            this.mobjPanelSeachTop.Controls.Add(this.mobjButtonSeachListTopics);
            this.mobjPanelSeachTop.Controls.Add(this.mobjButtonSearchDisplay);
            this.mobjPanelSeachTop.Controls.Add(this.mobjButtonSearchOperators);
            this.mobjPanelSeachTop.Controls.Add(this.mobjComboSearchWildcard);
            this.mobjPanelSeachTop.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelSeachTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanelSeachTop.Location = new System.Drawing.Point(0, 23);
            this.mobjPanelSeachTop.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelSeachTop.Name = "mobjPanelSeachTop";
            this.mobjPanelSeachTop.Size = new System.Drawing.Size(241, 83);
            this.mobjPanelSeachTop.TabIndex = 0;
            // 
            // mobjLabelSearchFound
            // 
            this.mobjLabelSearchFound.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelSearchFound.ClientSize = new System.Drawing.Size(100, 15);
            this.mobjLabelSearchFound.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelSearchFound.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelSearchFound.Location = new System.Drawing.Point(135, 65);
            this.mobjLabelSearchFound.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelSearchFound.Name = "mobjLabelSearchFound";
            this.mobjLabelSearchFound.Size = new System.Drawing.Size(100, 15);
            this.mobjLabelSearchFound.TabIndex = 0;
            this.mobjLabelSearchFound.Text = "Found: 0";
            // 
            // mobjLabelSearchSelectTopic
            // 
            this.mobjLabelSearchSelectTopic.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelSearchSelectTopic.ClientSize = new System.Drawing.Size(82, 15);
            this.mobjLabelSearchSelectTopic.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelSearchSelectTopic.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelSearchSelectTopic.Location = new System.Drawing.Point(3, 65);
            this.mobjLabelSearchSelectTopic.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelSearchSelectTopic.Name = "mobjLabelSearchSelectTopic";
            this.mobjLabelSearchSelectTopic.Size = new System.Drawing.Size(82, 15);
            this.mobjLabelSearchSelectTopic.TabIndex = 0;
            this.mobjLabelSearchSelectTopic.Text = "Select topic:";
            // 
            // mobjButtonSeachListTopics
            // 
            this.mobjButtonSeachListTopics.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonSeachListTopics.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonSeachListTopics.ClientSize = new System.Drawing.Size(69, 23);
            this.mobjButtonSeachListTopics.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonSeachListTopics.Location = new System.Drawing.Point(100, 31);
            this.mobjButtonSeachListTopics.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonSeachListTopics.Name = "mobjButtonSeachListTopics";
            this.mobjButtonSeachListTopics.Size = new System.Drawing.Size(69, 23);
            this.mobjButtonSeachListTopics.TabIndex = 0;
            this.mobjButtonSeachListTopics.Text = "List Topics";
            this.mobjButtonSeachListTopics.Click += new System.EventHandler(this.mobjButtonSeachListTopics_Click);
            // 
            // mobjButtonSearchDisplay
            // 
            this.mobjButtonSearchDisplay.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonSearchDisplay.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonSearchDisplay.ClientSize = new System.Drawing.Size(69, 23);
            this.mobjButtonSearchDisplay.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonSearchDisplay.Location = new System.Drawing.Point(173, 31);
            this.mobjButtonSearchDisplay.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonSearchDisplay.Name = "mobjButtonSearchDisplay";
            this.mobjButtonSearchDisplay.Size = new System.Drawing.Size(69, 23);
            this.mobjButtonSearchDisplay.TabIndex = 0;
            this.mobjButtonSearchDisplay.Text = "Display";
            this.mobjButtonSearchDisplay.Click += new System.EventHandler(this.mobjButtonSearchDisplay_Click);
            // 
            // mobjButtonSearchOperators
            // 
            this.mobjButtonSearchOperators.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonSearchOperators.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonSearchOperators.ClientSize = new System.Drawing.Size(17, 23);
            this.mobjButtonSearchOperators.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonSearchOperators.DropDownMenu = this.mobjMenuSearchOperators;
            this.mobjButtonSearchOperators.Location = new System.Drawing.Point(225, 4);
            this.mobjButtonSearchOperators.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonSearchOperators.Name = "mobjButtonSearchOperators";
            this.mobjButtonSearchOperators.Size = new System.Drawing.Size(17, 23);
            this.mobjButtonSearchOperators.TabIndex = 0;
            this.mobjButtonSearchOperators.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.mobjButtonSearchOperators_MenuClick);
            // 
            // mobjMenuSearchOperators
            // 
            this.mobjMenuSearchOperators.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuSearchAND,
            this.mobjMenuSearchOR,
            this.mobjMenuSearchNEAR,
            this.mobjMenuSearchNOT});
            // 
            // mobjMenuSearchAND
            // 
            this.mobjMenuSearchAND.Tag = "AND";
            this.mobjMenuSearchAND.Text = "AND";
            // 
            // mobjMenuSearchOR
            // 
            this.mobjMenuSearchOR.Tag = "OR";
            this.mobjMenuSearchOR.Text = "OR";
            // 
            // mobjMenuSearchNEAR
            // 
            this.mobjMenuSearchNEAR.Tag = "NEAR";
            this.mobjMenuSearchNEAR.Text = "NEAR";
            // 
            // mobjMenuSearchNOT
            // 
            this.mobjMenuSearchNOT.Tag = "NOT";
            this.mobjMenuSearchNOT.Text = "NOT";
            // 
            // mobjComboSearchWildcard
            // 
            this.mobjComboSearchWildcard.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjComboSearchWildcard.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjComboSearchWildcard.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboSearchWildcard.ClientSize = new System.Drawing.Size(223, 21);
            this.mobjComboSearchWildcard.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjComboSearchWildcard.Location = new System.Drawing.Point(0, 4);
            this.mobjComboSearchWildcard.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjComboSearchWildcard.Name = "mobjComboSearchWildcard";
            this.mobjComboSearchWildcard.Size = new System.Drawing.Size(223, 21);
            this.mobjComboSearchWildcard.TabIndex = 0;
            // 
            // mobjLabelSearch
            // 
            this.mobjLabelSearch.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelSearch.ClientSize = new System.Drawing.Size(241, 23);
            this.mobjLabelSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelSearch.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelSearch.Location = new System.Drawing.Point(0, 0);
            this.mobjLabelSearch.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelSearch.Name = "mobjLabelSearch";
            this.mobjLabelSearch.Size = new System.Drawing.Size(241, 23);
            this.mobjLabelSearch.TabIndex = 0;
            this.mobjLabelSearch.Text = "Type in the word(s) to search for:";
            this.mobjLabelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTabFavorites
            // 
            this.mobjTabFavorites.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTabFavorites.ClientSize = new System.Drawing.Size(247, 521);
            this.mobjTabFavorites.Controls.Add(this.mobjPanelFavoritesBottom);
            this.mobjTabFavorites.Controls.Add(this.mobjListFavorites);
            this.mobjTabFavorites.Controls.Add(this.mobjLabelFavorites);
            this.mobjTabFavorites.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTabFavorites.DockPadding.All = 3;
            this.mobjTabFavorites.Location = new System.Drawing.Point(4, 22);
            this.mobjTabFavorites.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTabFavorites.Name = "mobjTabFavorites";
            this.mobjTabFavorites.Size = new System.Drawing.Size(247, 521);
            this.mobjTabFavorites.TabIndex = 3;
            this.mobjTabFavorites.Text = "Favorites";
            // 
            // mobjPanelFavoritesBottom
            // 
            this.mobjPanelFavoritesBottom.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjPanelFavoritesBottom.ClientSize = new System.Drawing.Size(241, 113);
            this.mobjPanelFavoritesBottom.Controls.Add(this.mobjLabelFavoritesCurrentTopic);
            this.mobjPanelFavoritesBottom.Controls.Add(this.mobjTextFavoritesCurrentTopic);
            this.mobjPanelFavoritesBottom.Controls.Add(this.mobjButtonFavoritesAdd);
            this.mobjPanelFavoritesBottom.Controls.Add(this.mobjButtonFavoritesRemove);
            this.mobjPanelFavoritesBottom.Controls.Add(this.mobjButtonFavoritesDisplay);
            this.mobjPanelFavoritesBottom.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjPanelFavoritesBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPanelFavoritesBottom.Location = new System.Drawing.Point(0, 408);
            this.mobjPanelFavoritesBottom.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjPanelFavoritesBottom.Name = "mobjPanelFavoritesBottom";
            this.mobjPanelFavoritesBottom.Size = new System.Drawing.Size(241, 113);
            this.mobjPanelFavoritesBottom.TabIndex = 0;
            // 
            // mobjLabelFavoritesCurrentTopic
            // 
            this.mobjLabelFavoritesCurrentTopic.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelFavoritesCurrentTopic.ClientSize = new System.Drawing.Size(97, 16);
            this.mobjLabelFavoritesCurrentTopic.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelFavoritesCurrentTopic.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelFavoritesCurrentTopic.Location = new System.Drawing.Point(4, 42);
            this.mobjLabelFavoritesCurrentTopic.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelFavoritesCurrentTopic.Name = "mobjLabelFavoritesCurrentTopic";
            this.mobjLabelFavoritesCurrentTopic.Size = new System.Drawing.Size(97, 16);
            this.mobjLabelFavoritesCurrentTopic.TabIndex = 0;
            this.mobjLabelFavoritesCurrentTopic.Text = "Current Topic:";
            // 
            // mobjTextFavoritesCurrentTopic
            // 
            this.mobjTextFavoritesCurrentTopic.AcceptsReturn = true;
            this.mobjTextFavoritesCurrentTopic.AcceptsTab = true;
            this.mobjTextFavoritesCurrentTopic.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextFavoritesCurrentTopic.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjTextFavoritesCurrentTopic.ClientSize = new System.Drawing.Size(240, 20);
            this.mobjTextFavoritesCurrentTopic.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjTextFavoritesCurrentTopic.Lines = new string[0];
            this.mobjTextFavoritesCurrentTopic.Location = new System.Drawing.Point(0, 61);
            this.mobjTextFavoritesCurrentTopic.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjTextFavoritesCurrentTopic.MaxLength = 0;
            this.mobjTextFavoritesCurrentTopic.Multiline = false;
            this.mobjTextFavoritesCurrentTopic.Name = "mobjTextFavoritesCurrentTopic";
            this.mobjTextFavoritesCurrentTopic.ReadOnly = false;
            this.mobjTextFavoritesCurrentTopic.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextFavoritesCurrentTopic.Size = new System.Drawing.Size(240, 20);
            this.mobjTextFavoritesCurrentTopic.TabIndex = 0;
            this.mobjTextFavoritesCurrentTopic.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.mobjTextFavoritesCurrentTopic.Validator = null;
            this.mobjTextFavoritesCurrentTopic.WordWrap = false;
            // 
            // mobjButtonFavoritesAdd
            // 
            this.mobjButtonFavoritesAdd.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonFavoritesAdd.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonFavoritesAdd.ClientSize = new System.Drawing.Size(65, 23);
            this.mobjButtonFavoritesAdd.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonFavoritesAdd.Location = new System.Drawing.Point(175, 87);
            this.mobjButtonFavoritesAdd.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonFavoritesAdd.Name = "mobjButtonFavoritesAdd";
            this.mobjButtonFavoritesAdd.Size = new System.Drawing.Size(65, 23);
            this.mobjButtonFavoritesAdd.TabIndex = 0;
            this.mobjButtonFavoritesAdd.Text = "Add";
            this.mobjButtonFavoritesAdd.Click += new System.EventHandler(this.mobjButtonFavoritesAdd_Click);
            // 
            // mobjButtonFavoritesRemove
            // 
            this.mobjButtonFavoritesRemove.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonFavoritesRemove.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonFavoritesRemove.ClientSize = new System.Drawing.Size(69, 23);
            this.mobjButtonFavoritesRemove.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonFavoritesRemove.Location = new System.Drawing.Point(103, 3);
            this.mobjButtonFavoritesRemove.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonFavoritesRemove.Name = "mobjButtonFavoritesRemove";
            this.mobjButtonFavoritesRemove.Size = new System.Drawing.Size(69, 23);
            this.mobjButtonFavoritesRemove.TabIndex = 0;
            this.mobjButtonFavoritesRemove.Text = "Remove";
            this.mobjButtonFavoritesRemove.Click += new System.EventHandler(this.mobjButtonFavoritesRemove_Click);
            // 
            // mobjButtonFavoritesDisplay
            // 
            this.mobjButtonFavoritesDisplay.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonFavoritesDisplay.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjButtonFavoritesDisplay.ClientSize = new System.Drawing.Size(66, 23);
            this.mobjButtonFavoritesDisplay.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjButtonFavoritesDisplay.Location = new System.Drawing.Point(175, 3);
            this.mobjButtonFavoritesDisplay.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjButtonFavoritesDisplay.Name = "mobjButtonFavoritesDisplay";
            this.mobjButtonFavoritesDisplay.Size = new System.Drawing.Size(66, 23);
            this.mobjButtonFavoritesDisplay.TabIndex = 0;
            this.mobjButtonFavoritesDisplay.Text = "Display";
            this.mobjButtonFavoritesDisplay.Click += new System.EventHandler(this.mobjButtonFavoritesDisplay_Click);
            // 
            // mobjListFavorites
            // 
            this.mobjListFavorites.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjListFavorites.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjListFavorites.ClientSize = new System.Drawing.Size(241, 218);
            this.mobjListFavorites.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjListFavorites.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListFavorites.Location = new System.Drawing.Point(0, 23);
            this.mobjListFavorites.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjListFavorites.Name = "mobjListFavorites";
            this.mobjListFavorites.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.mobjListFavorites.Size = new System.Drawing.Size(241, 218);
            this.mobjListFavorites.TabIndex = 0;
            // 
            // mobjLabelFavorites
            // 
            this.mobjLabelFavorites.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelFavorites.ClientSize = new System.Drawing.Size(241, 23);
            this.mobjLabelFavorites.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjLabelFavorites.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelFavorites.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjLabelFavorites.Location = new System.Drawing.Point(0, 0);
            this.mobjLabelFavorites.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjLabelFavorites.Name = "mobjLabelFavorites";
            this.mobjLabelFavorites.Size = new System.Drawing.Size(241, 23);
            this.mobjLabelFavorites.TabIndex = 0;
            this.mobjLabelFavorites.Text = "Topics:";
            this.mobjLabelFavorites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjSplitterMain
            // 
            this.mobjSplitterMain.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjSplitterMain.ClientSize = new System.Drawing.Size(3, 699);
            this.mobjSplitterMain.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjSplitterMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjSplitterMain.Location = new System.Drawing.Point(258, 34);
            this.mobjSplitterMain.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjSplitterMain.Name = "mobjSplitterMain";
            this.mobjSplitterMain.Size = new System.Drawing.Size(3, 699);
            this.mobjSplitterMain.TabIndex = 0;
            // 
            // mobjHtml
            // 
            this.mobjHtml.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjHtml.ClientSize = new System.Drawing.Size(472, 699);
            this.mobjHtml.ContentType = "text/html";
            this.mobjHtml.Cursor = Gizmox.WebGUI.Forms.Cursors.Default;
            this.mobjHtml.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHtml.Expires = -1;
            this.mobjHtml.Html = "";
            this.mobjHtml.Location = new System.Drawing.Point(261, 34);
            this.mobjHtml.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.mobjHtml.Name = "mobjHtml";
            this.mobjHtml.Path = "";
            this.mobjHtml.Resource = null;
            this.mobjHtml.Size = new System.Drawing.Size(472, 699);
            this.mobjHtml.TabIndex = 0;
            this.mobjHtml.Text = "htmlBox1";
            this.mobjHtml.Url = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(736, 584);
            this.Controls.Add(this.mobjHtml);
            this.Controls.Add(this.mobjSplitterMain);
            this.Controls.Add(this.mobjTabControl);
            this.Controls.Add(this.mobjPanelMainSpace);
            this.Controls.Add(this.mobToolBar);
            this.DockPadding.All = 3;
            this.Location = new System.Drawing.Point(15, 15);
            this.Menu = this.mobjMainMenu;
            this.Size = new System.Drawing.Size(736, 584);
            this.Text = "Help";
            this.ResumeLayout(false);
            this.Load += new EventHandler(HelpDialog_Load);
			
		}



		
		
		#endregion Form Designer generated code
		
		#region Methods

        #region CHM Methods

        private CHMExplorerController mobjController = null;

        private void EnsureCHMReady()
        {
            mstrCHMDefaultHash = CHMExplorerController.Create(this.CHMLocation, mstrCHMDefaultHash);
            mobjController = CHMExplorerController.Get(mstrCHMDefaultHash);            
        }

        private void EnsureCHMToc()
        {
            LoadCHMToc(mobjTreeView.Nodes, mobjController.Root);
        }

        private void NavigateCHMHome()
        {
            NavigateCHMHome(false);
        }

        private void NavigateCHMHome(bool blnFirstTime)
        {
            bool blnNavigationDone = false;
            string strParam = this.InitializationParam as string;
            if (blnFirstTime)
            {
                switch (this.InitializationCommand)
                {
                    case HelpNavigator.TableOfContents:
                        
                        break;
                    case HelpNavigator.Topic:
                        mobjTabControl.SelectedItem = mobjTabIndex;
                        break;
                    case HelpNavigator.KeywordIndex:
                        mobjTabControl.SelectedItem = mobjTabIndex;
                        if (strParam != null)
                        {
                            HtmlHelp.IndexItem objIndexItem = mobjController.PerformSingleIndexSearch(strParam);
                            if (objIndexItem != null)
                            {
                                if (objIndexItem.Topics.Count > 0)
                                {
                                    NavigateLocal(((HtmlHelp.IndexTopic)objIndexItem.Topics[0]).Local);
                                    blnNavigationDone = true;
                                }
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

            if (!blnNavigationDone)
            {
                if (mobjController != null && mobjController.DefaultLocal != null)
                {
                    NavigateLocal(mobjController.DefaultLocal);
                }
            }
        }

        private void NavigateLocal(string strLocal)
        {
            mobjHtml.Url = GetCHMContentUrl(strLocal);
            mobjHtml.Update();
        }

        private string GetCHMContentUrl(string strLocal)
        {
            return string.Format("{0}?chm={1}&src={2}", CHMExplorerController.RedirectionTemplateRoot, mstrCHMDefaultHash, CHMExplorerController.ExtractLocal(strLocal));
        }

        private string GetCHMResourceUrl(string strLocal)
        {
            return string.Format("{0}?chm={1}&src={2}", CHMExplorerController.ResourceTemplateRoot, mstrCHMDefaultHash, strLocal);
        }


        private void LoadCHMToc(TreeNodeCollection objTreeNodes, CHMExplorerNode objNode)
        {
            objTreeNodes.Clear();

            foreach (CHMExplorerNode objSubNode in objNode.Nodes)
            {
                bool blnHasNodes = objSubNode.Nodes.Length>0;

                TreeNode objTreeNode = new TreeNode(objSubNode.Name);
                objTreeNode.Tag = objSubNode;
                objTreeNode.HasNodes = blnHasNodes;
                objTreeNode.Loaded = !blnHasNodes;
                objTreeNode.IsExpanded = !blnHasNodes;
                objTreeNode.BeforeExpand += new TreeViewCancelEventHandler(objTreeNode_BeforeExpand);
                objTreeNode.BeforeSelect += new TreeViewCancelEventHandler(objTreeNode_BeforeSelect);
                if (objSubNode.HasNodes)
                {
                    objTreeNode.Image = mobjClosedBookResourceHandle;
                    objTreeNode.ExpandedImage = mobjOpenBookResourceHandle;
                }
                else
                {
                    objTreeNode.Image = mobjTopicResourceHandle;
                }
                objTreeNodes.Add(objTreeNode);
            }
        }

        void objTreeNode_BeforeSelect(object objSource, TreeViewCancelEventArgs objArgs)
        {
            CHMExplorerNode objCHMExplorerNode = objArgs.Node.Tag as CHMExplorerNode;
            if(objCHMExplorerNode!=null)
            {
                mobjHtml.Url = GetCHMContentUrl(objCHMExplorerNode.Local);
                mobjHtml.Update();
            }
        }



        void objTreeNode_BeforeExpand(object objSource, TreeViewCancelEventArgs objArgs)
        {
            if (!objArgs.Node.Loaded)
            {
                LoadCHMToc(objArgs.Node.Nodes,objArgs.Node.Tag as CHMExplorerNode);
                objArgs.Node.Loaded = true;
            }
        }

        #endregion CHM Methods


        private void HelpDialog_Load(object sender, EventArgs e)
        {
            EnsureCHMReady();
            EnsureCHMToc();
            NavigateCHMHome(true);

            this.Text = mobjController.Title;
            
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
                    this.mobjComboSearchWildcard.Text += string.Format(" {0} ", strAction);
                    break;
                case "Exit":
                    this.Close();
                    break;
                default:
                    MessageBox.Show("This ");
                    break;
            }
        }

        private void mobjButtonSeachListTopics_Click(object sender, EventArgs e)
        {
            if (this.mobjComboSearchWildcard.Text != "")
            {
                if (!this.mobjComboSearchWildcard.Items.Contains(this.mobjComboSearchWildcard.Text))
                {
                    this.mobjComboSearchWildcard.Items.Add(this.mobjComboSearchWildcard.Text);
                    this.mobjComboSearchWildcard.Update();
                }
                if (this.mobjComboSearchWildcard.Items.Count > 7)
                {
                    this.mobjComboSearchWildcard.Items.RemoveAt(0);
                }
                this.mobjListSearch.Items.Clear();

                int intFound = 0;

                DataTable objResults = mobjController.PerformSearch(this.mobjComboSearchWildcard.Text, 300, mobjCheckMatchSimilarWords.Checked, mobjCheckSeachTitles.Checked);
                if (objResults != null)
                {
                    intFound = objResults.DefaultView.Count;
                    for (int i = 0; i < intFound; i++)
                    {
                        ListViewItem lvItem = this.mobjListSearch.Items.Add(objResults.DefaultView[i].Row["Title"].ToString());
                        lvItem.SubItems.Add(objResults.DefaultView[i].Row["Location"].ToString());
                        lvItem.SubItems.Add(objResults.DefaultView[i].Row["Rating"].ToString());
                        lvItem.Tag = new CHMSearchItem(objResults.DefaultView[i].Row["Title"].ToString(),
                            objResults.DefaultView[i].Row["URL"].ToString(),
                            objResults.DefaultView[i].Row["Location"].ToString(), (double)objResults.DefaultView[i].Row["Rating"]);

                    }
                }

                this.mobjLabelSearchFound.Text = string.Format("Found: {0}", intFound);
            }
        }

        private void mobjButtonSearchDisplay_Click(object sender, EventArgs e)
        {
            if (this.mobjListSearch.SelectedItem != null)
            {
                NavigateLocal(((CHMSearchItem)this.mobjListSearch.SelectedItem.Tag).URL);
            }
        }

        private void mobjTextBoxIndex_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            mobjListIndex.Items.Clear();

            ArrayList objResults = mobjController.PerformIndexSearch(mobjTextBoxIndex.Text,300);
            foreach (HtmlHelp.IndexItem objIndexItem in objResults)
            {
                ListViewItem objListViewItem = mobjListIndex.Items.Add(objIndexItem.IndentKeyWord);
                objListViewItem.Tag = objIndexItem;
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
                HtmlHelp.IndexItem objIndexItem = (HtmlHelp.IndexItem)mobjListIndex.SelectedItem.Tag;
                if (objIndexItem.Topics.Count == 1)
                {
                    NavigateLocal(((HtmlHelp.IndexTopic)objIndexItem.Topics[0]).Local);
                }
                else
                {
                    TopicsDialog objTopicsDialog = new TopicsDialog(objIndexItem.Topics);
                    objTopicsDialog.Closed += new EventHandler(TopicsDialog_Closed);
                    objTopicsDialog.ShowDialog();
                }
            }
        }

        private void TopicsDialog_Closed(object sender, EventArgs e)
        {
            TopicsDialog objTopicsDialog = (TopicsDialog)sender;
            if (objTopicsDialog.IsCompleted)
            {
                NavigateLocal(objTopicsDialog.SelectedItem.Local);
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
            if (this.mobjListSearch.SelectedItem != null)
            {
                NavigateLocal(((CHMSearchItem)this.mobjListSearch.SelectedItem.Tag).URL);
            }
        }

		#endregion Methods

        /// <summary>
        /// Gets the help dialog initialization command.
        /// </summary>
        protected abstract HelpNavigator InitializationCommand
        {
            get;
        }

        /// <summary>
        /// Gets the help dialog initialization paramter.
        /// </summary>
        protected abstract object InitializationParam
        {
            get;
        }


        protected abstract string CHMLocation
        {
            get;
        }

    }

    #endregion HelpFormBase Class

}
