namespace CompanionKit.Concepts.ClientAPI.ListView
{
    partial class ListViewPage
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
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjAddItemButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRemoveItemButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRemoveAllButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFillListViewButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjListView
            // 
            this.mobjListView.ClientId = "lw";
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.mobjListView.DataMember = null;
            this.mobjListView.Location = new System.Drawing.Point(17, 62);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(243, 190);
            this.mobjListView.TabIndex = 0;
            this.mobjListView.ClientSelectedIndexChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjListView_ClientSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.ClientId = "col1";
            this.columnHeader1.Text = "column1";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.ClientId = "col2";
            this.columnHeader2.Text = "column2";
            this.columnHeader2.Width = 105;
            // 
            // mobjAddItemButton
            // 
            this.mobjAddItemButton.Location = new System.Drawing.Point(147, 15);
            this.mobjAddItemButton.Name = "mobjAddItemButton";
            this.mobjAddItemButton.Size = new System.Drawing.Size(113, 30);
            this.mobjAddItemButton.TabIndex = 1;
            this.mobjAddItemButton.Text = "Add item";
            this.mobjAddItemButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjAddItemButton_ClientClick);
            // 
            // mobjRemoveItemButton
            // 
            this.mobjRemoveItemButton.Location = new System.Drawing.Point(147, 263);
            this.mobjRemoveItemButton.Name = "mobjRemoveItemButton";
            this.mobjRemoveItemButton.Size = new System.Drawing.Size(113, 30);
            this.mobjRemoveItemButton.TabIndex = 2;
            this.mobjRemoveItemButton.Text = "Remove one";
            this.mobjRemoveItemButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjRemoveItemButton_ClientClick);
            // 
            // mobjRemoveAllButton
            // 
            this.mobjRemoveAllButton.Location = new System.Drawing.Point(17, 263);
            this.mobjRemoveAllButton.Name = "mobjRemoveAllButton";
            this.mobjRemoveAllButton.Size = new System.Drawing.Size(113, 30);
            this.mobjRemoveAllButton.TabIndex = 3;
            this.mobjRemoveAllButton.Text = "Remove All";
            this.mobjRemoveAllButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjRemoveAllButton_ClientClick);
            // 
            // mobjFillListViewButton
            // 
            this.mobjFillListViewButton.Location = new System.Drawing.Point(17, 15);
            this.mobjFillListViewButton.Name = "mobjFillListViewButton";
            this.mobjFillListViewButton.Size = new System.Drawing.Size(113, 30);
            this.mobjFillListViewButton.TabIndex = 4;
            this.mobjFillListViewButton.Text = "Initialize List";
            this.mobjFillListViewButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjFillListViewButton_ClientClick);
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.ClientId = "lbl";
            this.mobjInfoLabel.Location = new System.Drawing.Point(17, 304);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(243, 50);
            this.mobjInfoLabel.TabIndex = 5;
            this.mobjInfoLabel.Text = "--";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListViewPage
            // 
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjFillListViewButton);
            this.Controls.Add(this.mobjRemoveAllButton);
            this.Controls.Add(this.mobjRemoveItemButton);
            this.Controls.Add(this.mobjAddItemButton);
            this.Controls.Add(this.mobjListView);
            this.ClientId = "uc";
            this.Size = new System.Drawing.Size(493, 403);
            this.Text = "ListViewPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.Button mobjAddItemButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveItemButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveAllButton;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
        private Gizmox.WebGUI.Forms.Button mobjFillListViewButton;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;



    }
}