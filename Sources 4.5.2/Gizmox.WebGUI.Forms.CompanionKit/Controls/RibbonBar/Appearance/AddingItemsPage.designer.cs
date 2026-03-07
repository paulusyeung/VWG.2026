namespace CompanionKit.Controls.RibbonBar.Appearance
{
    partial class AddingItemsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingItemsPage));
			this.demoRibbonBar = new Gizmox.WebGUI.Forms.RibbonBar();
			this.rbEmail = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbGroupActions = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbItemMoveTo = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
			this.rbItemDelete = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
			this.rbItemReply = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
			this.rbItemFollowUp = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
			this.rbGroupTools = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbItemApps = new Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem();
			this.mobjToolsMenu = new Gizmox.WebGUI.Forms.ContextMenu();
			this.menuAddressBook = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuCalendar = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuSignature = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuImageEditor = new Gizmox.WebGUI.Forms.MenuItem();
			this.rbEdit = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbGroupFind = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbItemStack = new Gizmox.WebGUI.Forms.RibbonBarStackItem();
			this.rbSItemWhere = new Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem();
			this.mobjWhereFind = new Gizmox.WebGUI.Forms.ContextMenu();
			this.menuWhereAll = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuWhereImages = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuWhereDocs = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuWhereCode = new Gizmox.WebGUI.Forms.MenuItem();
			this.rbSItemCase = new Gizmox.WebGUI.Forms.RibbonBarCheckBoxItem();
			this.rbSItemQuickFind = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
			this.rbGroupIntelliSence = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbIntelliSense = new Gizmox.WebGUI.Forms.RibbonBarFlowItem();
			this.rbSItemBar1 = new Gizmox.WebGUI.Forms.RibbonBarToolBarItem();
			this.rbSItemListMembers = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemsParameterInfo = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemQuickInfo = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemBar2 = new Gizmox.WebGUI.Forms.RibbonBarToolBarItem();
			this.ribbonBarToolBarButtonItem4 = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.ribbonBarToolBarButtonItem5 = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemBar3 = new Gizmox.WebGUI.Forms.RibbonBarToolBarItem();
			this.rbSItemEnableBookmark = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemEnableAll = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemToggle = new Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem();
			this.rbSItemTXTSearch = new Gizmox.WebGUI.Forms.RibbonBarTextBoxItem();
			this.rbSItemCmb = new Gizmox.WebGUI.Forms.RibbonBarComboBoxItem();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.lblStatus = new Gizmox.WebGUI.Forms.Label();
			this.lblEventHandler = new Gizmox.WebGUI.Forms.Label();
			this.mobjGrpWidth = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjCmdInitial = new Gizmox.WebGUI.Forms.Button();
			this.mobjTrackWidth = new Gizmox.WebGUI.Forms.TrackBar();
			this.lblWidth = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.mobjGrpWidth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// demoRibbonBar
			// 
			this.demoRibbonBar.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.demoRibbonBar.Location = new System.Drawing.Point(0, 0);
			this.demoRibbonBar.Name = "demoRibbonBar";
			this.demoRibbonBar.Pages.Add(this.rbEmail);
			this.demoRibbonBar.Pages.Add(this.rbEdit);
			this.demoRibbonBar.SelectedIndex = 0;
			this.demoRibbonBar.TabIndex = 0;
			this.demoRibbonBar.CheckChanged += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarCheckBoxItemArgs>(this.rb_CheckedChanged);
			this.demoRibbonBar.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.demoRibbonBar.ButtonClick += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarButtonItemArgs>(this.rb_ButtonClick);
			this.demoRibbonBar.AdvancedClicked += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarGroupArgs>(this.AdvancedClicked);
			this.demoRibbonBar.TextChanged += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarTextBoxItemArgs>(this.rb_TextChanged);
			// 
			// rbEmail
			// 
			this.rbEmail.Groups.Add(this.rbGroupActions);
			this.rbEmail.Groups.Add(this.rbGroupTools);
			this.rbEmail.Text = "Email";
			// 
			// rbGroupActions
			// 
			this.rbGroupActions.Items.Add(this.rbItemMoveTo);
			this.rbGroupActions.Items.Add(this.rbItemDelete);
			this.rbGroupActions.Items.Add(this.rbItemReply);
			this.rbGroupActions.Items.Add(this.rbItemFollowUp);
			this.rbGroupActions.Text = "Actions";
			// 
			// rbItemMoveTo
			// 
			this.rbItemMoveTo.ClientAction = null;
			this.rbItemMoveTo.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbItemMoveTo.Image"));
			this.rbItemMoveTo.Text = "Move To";
			this.rbItemMoveTo.ToolTip = "Move To Folder";
			// 
			// rbItemDelete
			// 
			this.rbItemDelete.ClientAction = null;
			this.rbItemDelete.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbItemDelete.Image"));
			this.rbItemDelete.Text = "Delete";
			this.rbItemDelete.ToolTip = "Dlete";
			// 
			// rbItemReply
			// 
			this.rbItemReply.ClientAction = null;
			this.rbItemReply.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbItemReply.Image"));
			this.rbItemReply.Text = "Reply";
			this.rbItemReply.ToolTip = "Reply";
			// 
			// rbItemFollowUp
			// 
			this.rbItemFollowUp.ClientAction = null;
			this.rbItemFollowUp.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbItemFollowUp.Image"));
			this.rbItemFollowUp.Text = "Follow Up";
			this.rbItemFollowUp.ToolTip = "Follow Up";
			// 
			// rbGroupTools
			// 
			this.rbGroupTools.HasAdvanced = true;
			this.rbGroupTools.Items.Add(this.rbItemApps);
			this.rbGroupTools.Text = "Tools";
			// 
			// rbItemApps
			// 
			this.rbItemApps.ClientAction = null;
			this.rbItemApps.DropDownMenu = this.mobjToolsMenu;
			this.rbItemApps.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbItemApps.Image"));
			this.rbItemApps.Tag = "Tools";
			this.rbItemApps.ToolTip = "Available Tools";
			this.rbItemApps.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.rb_MenuClick);
			// 
			// mobjToolsMenu
			// 
			this.mobjToolsMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuAddressBook,
            this.menuCalendar,
            this.menuSignature,
            this.menuImageEditor});
			// 
			// menuAddressBook
			// 
			this.menuAddressBook.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuAddressBook.Icon"));
			this.menuAddressBook.Index = 0;
			this.menuAddressBook.Text = "Address Book";
			// 
			// menuCalendar
			// 
			this.menuCalendar.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuCalendar.Icon"));
			this.menuCalendar.Index = 1;
			this.menuCalendar.Text = "Calendar";
			// 
			// menuSignature
			// 
			this.menuSignature.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuSignature.Icon"));
			this.menuSignature.Index = 2;
			this.menuSignature.Text = "Signature";
			// 
			// menuImageEditor
			// 
			this.menuImageEditor.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuImageEditor.Icon"));
			this.menuImageEditor.Index = 3;
			this.menuImageEditor.Text = "Image Editor";
			// 
			// rbEdit
			// 
			this.rbEdit.Groups.Add(this.rbGroupFind);
			this.rbEdit.Groups.Add(this.rbGroupIntelliSence);
			this.rbEdit.Text = "Edit";
			// 
			// rbGroupFind
			// 
			this.rbGroupFind.HasAdvanced = true;
			this.rbGroupFind.Items.Add(this.rbItemStack);
			this.rbGroupFind.Text = "Find and Replace";
			// 
			// rbItemStack
			// 
			this.rbItemStack.Items.Add(this.rbSItemWhere);
			this.rbItemStack.Items.Add(this.rbSItemCase);
			this.rbItemStack.Items.Add(this.rbSItemQuickFind);
			// 
			// rbSItemWhere
			// 
			this.rbSItemWhere.ClientAction = null;
			this.rbSItemWhere.DropDownMenu = this.mobjWhereFind;
			this.rbSItemWhere.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemWhere.Image"));
			this.rbSItemWhere.Text = "Where";
			this.rbSItemWhere.ToolTip = "Where to search";
			this.rbSItemWhere.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.rb_MenuClick);
			// 
			// mobjWhereFind
			// 
			this.mobjWhereFind.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuWhereAll,
            this.menuWhereImages,
            this.menuWhereDocs,
            this.menuWhereCode});
			// 
			// menuWhereAll
			// 
			this.menuWhereAll.Checked = true;
			this.menuWhereAll.Index = 0;
			this.menuWhereAll.Text = "All";
			this.menuWhereAll.Click += new System.EventHandler(this.menuWhere_Click);
			// 
			// menuWhereImages
			// 
			this.menuWhereImages.Index = 1;
			this.menuWhereImages.Text = "Images";
			this.menuWhereImages.Click += new System.EventHandler(this.menuWhere_Click);
			// 
			// menuWhereDocs
			// 
			this.menuWhereDocs.Index = 2;
			this.menuWhereDocs.Text = "Documents";
			this.menuWhereDocs.Click += new System.EventHandler(this.menuWhere_Click);
			// 
			// menuWhereCode
			// 
			this.menuWhereCode.Index = 3;
			this.menuWhereCode.Text = "Code";
			this.menuWhereCode.Click += new System.EventHandler(this.menuWhere_Click);
			// 
			// rbSItemCase
			// 
			this.rbSItemCase.Text = "Case sensitive";
			this.rbSItemCase.ToolTip = "Run case sensitive search";
			// 
			// rbSItemQuickFind
			// 
			this.rbSItemQuickFind.ClientAction = null;
			this.rbSItemQuickFind.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemQuickFind.Image"));
			this.rbSItemQuickFind.Text = "Quick Find";
			this.rbSItemQuickFind.ToolTip = "Quick Find";
			// 
			// rbGroupIntelliSence
			// 
			this.rbGroupIntelliSence.Items.Add(this.rbIntelliSense);
			this.rbGroupIntelliSence.Text = "IntelliSence";
			// 
			// rbIntelliSense
			// 
			this.rbIntelliSense.Items.Add(this.rbSItemBar1);
			this.rbIntelliSense.Items.Add(this.rbSItemBar2);
			this.rbIntelliSense.Items.Add(this.rbSItemBar3);
			this.rbIntelliSense.Items.Add(this.rbSItemTXTSearch);
			this.rbIntelliSense.Items.Add(this.rbSItemCmb);
			this.rbIntelliSense.Width = 230;
			// 
			// rbSItemBar1
			// 
			this.rbSItemBar1.Items.Add(this.rbSItemListMembers);
			this.rbSItemBar1.Items.Add(this.rbSItemsParameterInfo);
			this.rbSItemBar1.Items.Add(this.rbSItemQuickInfo);
			// 
			// rbSItemListMembers
			// 
			this.rbSItemListMembers.ClientAction = null;
			this.rbSItemListMembers.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemListMembers.Image"));
			this.rbSItemListMembers.Tag = "List Members";
			this.rbSItemListMembers.ToolTip = "List Members";
			// 
			// rbSItemsParameterInfo
			// 
			this.rbSItemsParameterInfo.ClientAction = null;
			this.rbSItemsParameterInfo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemsParameterInfo.Image"));
			this.rbSItemsParameterInfo.Tag = "Parameter Info";
			this.rbSItemsParameterInfo.ToolTip = "Parameter Info";
			// 
			// rbSItemQuickInfo
			// 
			this.rbSItemQuickInfo.ClientAction = null;
			this.rbSItemQuickInfo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemQuickInfo.Image"));
			this.rbSItemQuickInfo.Tag = "Quick Info";
			this.rbSItemQuickInfo.ToolTip = "Quick Info";
			// 
			// rbSItemBar2
			// 
			this.rbSItemBar2.Enabled = false;
			this.rbSItemBar2.Items.Add(this.ribbonBarToolBarButtonItem4);
			this.rbSItemBar2.Items.Add(this.ribbonBarToolBarButtonItem5);
			// 
			// ribbonBarToolBarButtonItem4
			// 
			this.ribbonBarToolBarButtonItem4.ClientAction = null;
			this.ribbonBarToolBarButtonItem4.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("ribbonBarToolBarButtonItem4.Image"));
			// 
			// ribbonBarToolBarButtonItem5
			// 
			this.ribbonBarToolBarButtonItem5.ClientAction = null;
			this.ribbonBarToolBarButtonItem5.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("ribbonBarToolBarButtonItem5.Image"));
			// 
			// rbSItemBar3
			// 
			this.rbSItemBar3.Items.Add(this.rbSItemEnableBookmark);
			this.rbSItemBar3.Items.Add(this.rbSItemEnableAll);
			this.rbSItemBar3.Items.Add(this.rbSItemToggle);
			// 
			// rbSItemEnableBookmark
			// 
			this.rbSItemEnableBookmark.ClientAction = null;
			this.rbSItemEnableBookmark.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemEnableBookmark.Image"));
			this.rbSItemEnableBookmark.Tag = "Enable Bookmark";
			this.rbSItemEnableBookmark.ToolTip = "Enable Bookmark";
			// 
			// rbSItemEnableAll
			// 
			this.rbSItemEnableAll.ClientAction = null;
			this.rbSItemEnableAll.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemEnableAll.Image"));
			this.rbSItemEnableAll.Tag = "Enable All Bookmarks";
			this.rbSItemEnableAll.ToolTip = "Enable All Bookmarks";
			// 
			// rbSItemToggle
			// 
			this.rbSItemToggle.ClientAction = null;
			this.rbSItemToggle.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("rbSItemToggle.Image"));
			this.rbSItemToggle.Tag = "Toggle Bookmark";
			this.rbSItemToggle.ToolTip = "Toggle Bookmark";
			// 
			// rbSItemTXTSearch
			// 
			this.rbSItemTXTSearch.Text = "Search...";
			this.rbSItemTXTSearch.ToolTip = "Enter text to search";
			// 
			// rbSItemCmb
			// 
			this.rbSItemCmb.Items.AddRange(new object[] {
            "Solution",
            "Project",
            "File"});
			this.rbSItemCmb.ToolTip = "Select scope to search";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.mobjGrpWidth);
			this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(0, 115);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(686, 219);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblStatus);
			this.groupBox2.Controls.Add(this.lblEventHandler);
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(9, 17);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(513, 100);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = " Event handlers ";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(9, 22);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(35, 13);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "The Active page:";
			// 
			// lblEventHandler
			// 
			this.lblEventHandler.AutoSize = true;
			this.lblEventHandler.Location = new System.Drawing.Point(9, 46);
			this.lblEventHandler.Name = "lblEventHandler";
			this.lblEventHandler.Size = new System.Drawing.Size(35, 13);
			this.lblEventHandler.TabIndex = 0;
			this.lblEventHandler.Text = "Event Handler:";
			// 
			// mobjGrpWidth
			// 
			this.mobjGrpWidth.Controls.Add(this.mobjCmdInitial);
			this.mobjGrpWidth.Controls.Add(this.mobjTrackWidth);
			this.mobjGrpWidth.Controls.Add(this.lblWidth);
			this.mobjGrpWidth.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjGrpWidth.Location = new System.Drawing.Point(9, 124);
			this.mobjGrpWidth.Name = "mobjGrpWidth";
			this.mobjGrpWidth.Size = new System.Drawing.Size(513, 65);
			this.mobjGrpWidth.TabIndex = 1;
			this.mobjGrpWidth.TabStop = false;
			this.mobjGrpWidth.Text = " IntelliSense Item width ";
			this.mobjGrpWidth.Visible = false;
			// 
			// mobjCmdInitial
			// 
			this.mobjCmdInitial.CustomStyle = "F";
			this.mobjCmdInitial.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjCmdInitial.Location = new System.Drawing.Point(472, 23);
			this.mobjCmdInitial.Name = "mobjCmdInitial";
			this.mobjCmdInitial.Size = new System.Drawing.Size(38, 23);
			this.mobjCmdInitial.TabIndex = 3;
			this.mobjCmdInitial.Text = "...";
			this.mobjCmdInitial.UseVisualStyleBackColor = true;
			this.mobjCmdInitial.Click += new System.EventHandler(this.Width_SetInitial);
			// 
			// mobjTrackWidth
			// 
			this.mobjTrackWidth.Location = new System.Drawing.Point(178, 22);
			this.mobjTrackWidth.Maximum = 500;
			this.mobjTrackWidth.Minimum = 100;
			this.mobjTrackWidth.Name = "mobjTrackWidth";
			this.mobjTrackWidth.Size = new System.Drawing.Size(290, 36);
			this.mobjTrackWidth.TabIndex = 1;
			this.mobjTrackWidth.TickFrequency = 20;
			this.mobjTrackWidth.Value = 230;
			this.mobjTrackWidth.ValueChanged += new System.EventHandler(this.Width_ValueChanged);
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(9, 28);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(35, 13);
			this.lblWidth.TabIndex = 2;
			this.lblWidth.Text = "RibbonBarFlowItem width:";
			// 
			// AddingItemsPage
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.demoRibbonBar);
			this.Size = new System.Drawing.Size(686, 334);
			this.Text = "AddingItemsPage";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.mobjGrpWidth.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackWidth)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Gizmox.WebGUI.Forms.RibbonBar demoRibbonBar;
		private Gizmox.WebGUI.Forms.RibbonBarPage rbEmail;
		private Gizmox.WebGUI.Forms.RibbonBarPage rbEdit;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupActions;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupTools;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupFind;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupIntelliSence;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbItemDelete;
		private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbItemReply;
		private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbItemMoveTo;
		private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbItemFollowUp;
		private Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem rbItemApps;
		private Gizmox.WebGUI.Forms.ContextMenu mobjToolsMenu;
		private Gizmox.WebGUI.Forms.MenuItem menuCalendar;
		private Gizmox.WebGUI.Forms.MenuItem menuSignature;
		private Gizmox.WebGUI.Forms.MenuItem menuAddressBook;
		private Gizmox.WebGUI.Forms.MenuItem menuImageEditor;
		private Gizmox.WebGUI.Forms.RibbonBarStackItem rbItemStack;
		private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbSItemQuickFind;
		private Gizmox.WebGUI.Forms.RibbonBarCheckBoxItem rbSItemCase;
		private Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem rbSItemWhere;
		private Gizmox.WebGUI.Forms.ContextMenu mobjWhereFind;
		private Gizmox.WebGUI.Forms.MenuItem menuWhereAll;
		private Gizmox.WebGUI.Forms.MenuItem menuWhereImages;
		private Gizmox.WebGUI.Forms.MenuItem menuWhereDocs;
		private Gizmox.WebGUI.Forms.MenuItem menuWhereCode;
		private Gizmox.WebGUI.Forms.RibbonBarFlowItem rbIntelliSense;
		private Gizmox.WebGUI.Forms.RibbonBarTextBoxItem rbSItemTXTSearch;
		private Gizmox.WebGUI.Forms.RibbonBarComboBoxItem rbSItemCmb;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarItem rbSItemBar1;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemListMembers;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemsParameterInfo;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemQuickInfo;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarItem rbSItemBar2;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem ribbonBarToolBarButtonItem4;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem ribbonBarToolBarButtonItem5;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarItem rbSItemBar3;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemEnableBookmark;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemEnableAll;
		private Gizmox.WebGUI.Forms.RibbonBarToolBarButtonItem rbSItemToggle;
		private Gizmox.WebGUI.Forms.GroupBox mobjGrpWidth;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackWidth;
		private Gizmox.WebGUI.Forms.Label lblWidth;
		private Gizmox.WebGUI.Forms.Button mobjCmdInitial;
		private Gizmox.WebGUI.Forms.GroupBox groupBox2;
		private Gizmox.WebGUI.Forms.Label lblStatus;
		private Gizmox.WebGUI.Forms.Label lblEventHandler;
    }
}