namespace CompanionKit.Controls.ListView.Features
{
    partial class ChangeColumnOptionsPage
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
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnImportant = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnOpened = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnAttached = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnSubject = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnFrom = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnReceived = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.mobjColumnControl = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Column options...";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mobjListView
            // 
            this.mobjListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjListView.AutoGenerateColumns = true;
            this.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnImportant,
            this.mobjColumnOpened,
            this.mobjColumnAttached,
            this.mobjColumnSubject,
            this.mobjColumnFrom,
            this.mobjColumnReceived,
            this.mobjColumnSize,
            this.mobjColumnControl});
            this.mobjListView.ContextMenu = this.contextMenu1;
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.GridLines = false;
            this.mobjListView.ItemsPerPage = 20;
            this.mobjListView.Location = new System.Drawing.Point(0, 0);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.ShowItemToolTips = false;
            this.mobjListView.Size = new System.Drawing.Size(702, 401);
            this.mobjListView.TabIndex = 0;
            this.mobjListView.UseInternalPaging = true;
            this.mobjListView.FullRowSelect = true;
            // 
            // mobjColumnImportant
            // 
            this.mobjColumnImportant.ContextMenu = this.contextMenu1;
            this.mobjColumnImportant.Image = null;
            this.mobjColumnImportant.Text = "";
            this.mobjColumnImportant.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnImportant.Width = 20;
            // 
            // mobjColumnOpened
            // 
            this.mobjColumnOpened.ContextMenu = this.contextMenu1;
            this.mobjColumnOpened.Image = null;
            this.mobjColumnOpened.Text = "";
            this.mobjColumnOpened.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnOpened.Width = 20;
            // 
            // mobjColumnAttached
            // 
            this.mobjColumnAttached.ContextMenu = this.contextMenu1;
            this.mobjColumnAttached.Image = null;
            this.mobjColumnAttached.Text = "";
            this.mobjColumnAttached.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnAttached.Width = 20;
            // 
            // mobjColumnSubject
            // 
            this.mobjColumnSubject.ContextMenu = this.contextMenu1;
            this.mobjColumnSubject.Image = null;
            this.mobjColumnSubject.Text = "Subject";
            this.mobjColumnSubject.Width = 250;
            // 
            // mobjColumnFrom
            // 
            this.mobjColumnFrom.ContextMenu = this.contextMenu1;
            this.mobjColumnFrom.Image = null;
            this.mobjColumnFrom.Text = "From";
            this.mobjColumnFrom.Width = 150;
            // 
            // mobjColumnReceived
            // 
            this.mobjColumnReceived.ContextMenu = this.contextMenu1;
            this.mobjColumnReceived.Image = null;
            this.mobjColumnReceived.Text = "Received";
            this.mobjColumnReceived.Width = 150;
            // 
            // mobjColumnSize
            // 
            this.mobjColumnSize.ContextMenu = this.contextMenu1;
            this.mobjColumnSize.Image = null;
            this.mobjColumnSize.Text = "Size";
            this.mobjColumnSize.Width = 50;
            // 
            // mobjColumnControl
            // 
            this.mobjColumnControl.ContextMenu = this.contextMenu1;
            this.mobjColumnControl.Image = null;
            this.mobjColumnControl.PreferedItemHeight = 23;
            this.mobjColumnControl.Text = "Action";
            this.mobjColumnControl.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.mobjColumnControl.Width = 200;
            // 
            // ChangeColumnOptionsPage
            // 
            this.Controls.Add(this.mobjListView);
            this.Size = new System.Drawing.Size(702, 401);
            this.Text = "ColumnReorderingWithDialogPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ContextMenu contextMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnFrom;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSubject;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnReceived;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSize;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnImportant;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnOpened;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnAttached;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnControl;



    }
}