namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ResourcesEditView
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
            Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
            Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
            Gizmox.WebGUI.Forms.ColumnHeader columnHeader3;
            this.mobjListResources = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader4 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader5 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader6 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader9 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader8 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader7 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjListMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem15 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem10 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem11 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem12 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem13 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem14 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem16 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem19 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem20 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjButtonAdd = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonDelete = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonView = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonDownload = new Gizmox.WebGUI.Forms.Button();
            this.mobjUploadDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjButtonEdit = new Gizmox.WebGUI.Forms.Button();
            this.menuItem17 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem18 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjLinkResource = new Gizmox.WebGUI.Forms.Button();
            columnHeader1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            columnHeader2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            columnHeader3 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "Name";
            columnHeader1.Text = "Name";
            columnHeader1.Width = 164;
            // 
            // columnHeader2
            // 
            columnHeader2.Tag = "SiteMap";
            columnHeader2.Text = "SiteMap";
            columnHeader2.Width = 42;
            // 
            // columnHeader3
            // 
            columnHeader3.Tag = "Visible";
            columnHeader3.Text = "Visible";
            columnHeader3.Width = 33;
            // 
            // mobjListResources
            // 
            this.mobjListResources.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjListResources.AutoGenerateColumns = false;
            this.mobjListResources.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader7});
            this.mobjListResources.DataMember = null;
            this.mobjListResources.FullRowSelect = true;
            this.mobjListResources.ItemsPerPage = 20;
            this.mobjListResources.Location = new System.Drawing.Point(4, 4);
            this.mobjListResources.Name = "listView1";
            this.mobjListResources.ShowItemToolTips = false;
            this.mobjListResources.Size = new System.Drawing.Size(555, 241);
            this.mobjListResources.TabIndex = 0;
            this.mobjListResources.TotalItems = 1;
            this.mobjListResources.SelectedIndexChanged += new System.EventHandler(this.OnResourcesSelectedIndexChanged);
            this.mobjListResources.DoubleClick += new System.EventHandler(this.mobjListFields_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Order";
            this.columnHeader4.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            this.columnHeader5.Width = 39;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Lang";
            this.columnHeader6.Width = 39;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Page Script";
            this.columnHeader9.Width = 66;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "View";
            this.columnHeader8.Width = 42;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Title";
            this.columnHeader7.Width = 110;
            // 
            // mobjListMenu
            // 
            this.mobjListMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem7,
            this.menuItem10,
            this.menuItem16});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.menuItem1.Text = "Visiblity";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Set Visible";
            this.menuItem2.Click += new System.EventHandler(this.OnSetVisible);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Set Invisible";
            this.menuItem3.Click += new System.EventHandler(this.OnSetInvisible);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem6});
            this.menuItem4.Text = "SiteMap";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "Include";
            this.menuItem5.Click += new System.EventHandler(this.OnIncludeInSiteMap);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "Exclude";
            this.menuItem6.Click += new System.EventHandler(this.OnExcludeFromSiteMap);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem9,
            this.menuItem15});
            this.menuItem7.Text = "Order";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "Upper";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "Lower";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 2;
            this.menuItem15.Text = "Default";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem14});
            this.menuItem10.Text = "Language";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "C#";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "VB.NET";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "All";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "From Name";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 4;
            this.menuItem16.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem19,
            this.menuItem20});
            this.menuItem16.Text = "View Type";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 0;
            this.menuItem19.Text = "Default";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.Text = "NoView";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // mobjButtonAdd
            // 
            this.mobjButtonAdd.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonAdd.Location = new System.Drawing.Point(579, 4);
            this.mobjButtonAdd.Name = "mobjButtonAdd";
            this.mobjButtonAdd.Size = new System.Drawing.Size(83, 23);
            this.mobjButtonAdd.TabIndex = 1;
            this.mobjButtonAdd.Text = "Add File";
            this.mobjButtonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjButtonAdd.UseVisualStyleBackColor = true;
            this.mobjButtonAdd.Click += new System.EventHandler(this.OnAddResource);
            // 
            // mobjButtonDelete
            // 
            this.mobjButtonDelete.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonDelete.Enabled = false;
            this.mobjButtonDelete.Location = new System.Drawing.Point(579, 108);
            this.mobjButtonDelete.Name = "mobjButtonDelete";
            this.mobjButtonDelete.Size = new System.Drawing.Size(83, 23);
            this.mobjButtonDelete.TabIndex = 2;
            this.mobjButtonDelete.Text = "Remove";
            this.mobjButtonDelete.UseVisualStyleBackColor = true;
            this.mobjButtonDelete.Click += new System.EventHandler(this.OnDeleteResource);
            // 
            // mobjButtonView
            // 
            this.mobjButtonView.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonView.Enabled = false;
            this.mobjButtonView.Location = new System.Drawing.Point(579, 153);
            this.mobjButtonView.Name = "mobjButtonView";
            this.mobjButtonView.Size = new System.Drawing.Size(83, 23);
            this.mobjButtonView.TabIndex = 3;
            this.mobjButtonView.Text = "View";
            this.mobjButtonView.UseVisualStyleBackColor = true;
            this.mobjButtonView.Click += new System.EventHandler(this.OnViewResource);
            // 
            // mobjButtonDownload
            // 
            this.mobjButtonDownload.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonDownload.Enabled = false;
            this.mobjButtonDownload.Location = new System.Drawing.Point(579, 179);
            this.mobjButtonDownload.Name = "mobjButtonDownload";
            this.mobjButtonDownload.Size = new System.Drawing.Size(83, 23);
            this.mobjButtonDownload.TabIndex = 4;
            this.mobjButtonDownload.Text = "Download";
            this.mobjButtonDownload.UseVisualStyleBackColor = true;
            this.mobjButtonDownload.Click += new System.EventHandler(this.OnDownloadResource);
            // 
            // mobjUploadDialog
            // 
            this.mobjUploadDialog.Multiselect = true;
            this.mobjUploadDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OnResourceAdded);
            // 
            // mobjButtonEdit
            // 
            this.mobjButtonEdit.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonEdit.Enabled = false;
            this.mobjButtonEdit.Location = new System.Drawing.Point(579, 81);
            this.mobjButtonEdit.Name = "mobjButtonDelete";
            this.mobjButtonEdit.Size = new System.Drawing.Size(83, 23);
            this.mobjButtonEdit.TabIndex = 2;
            this.mobjButtonEdit.Text = "Edit";
            this.mobjButtonEdit.UseVisualStyleBackColor = true;
            this.mobjButtonEdit.Click += new System.EventHandler(this.mobjButtonEdit_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = -1;
            this.menuItem17.Text = "Default";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = -1;
            this.menuItem18.Text = "NoView";
            // 
            // mobjLinkResource
            // 
            this.mobjLinkResource.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjLinkResource.Location = new System.Drawing.Point(579, 32);
            this.mobjLinkResource.Name = "mobjLinkResource";
            this.mobjLinkResource.Size = new System.Drawing.Size(83, 23);
            this.mobjLinkResource.TabIndex = 1;
            this.mobjLinkResource.Text = "Link Resource";
            this.mobjLinkResource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjLinkResource.UseVisualStyleBackColor = true;
            this.mobjLinkResource.Click += new System.EventHandler(this.LinkResource_Click);
            // 
            // ResourcesEditView
            // 
            this.Controls.Add(this.mobjLinkResource);
            this.Controls.Add(this.mobjButtonEdit);
            this.Controls.Add(this.mobjButtonDownload);
            this.Controls.Add(this.mobjButtonView);
            this.Controls.Add(this.mobjButtonDelete);
            this.Controls.Add(this.mobjButtonAdd);
            this.Controls.Add(this.mobjListResources);
            this.Size = new System.Drawing.Size(681, 253);
            this.Text = "ResourcesEditView";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView mobjListResources;
        private Button mobjButtonAdd;
        private Button mobjButtonDelete;
        private Button mobjButtonView;
        private Button mobjButtonDownload;
        private OpenFileDialog mobjUploadDialog;
        private ContextMenu mobjListMenu;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private Button mobjButtonEdit;
        private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
		private MenuItem menuItem7;
		private MenuItem menuItem8;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private MenuItem menuItem12;
		private MenuItem menuItem13;
		private MenuItem menuItem14;
		private MenuItem menuItem15;
		private ColumnHeader columnHeader8;
		private MenuItem menuItem16;
		private MenuItem menuItem17;
		private MenuItem menuItem18;
		private MenuItem menuItem19;
		private MenuItem menuItem20;
		private Button mobjLinkResource;
        private ColumnHeader columnHeader9;


    }
}
