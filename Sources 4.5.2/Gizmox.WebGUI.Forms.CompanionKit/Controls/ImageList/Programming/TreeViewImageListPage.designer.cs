namespace CompanionKit.Controls.ImageListFolder.Programming
{
    partial class TreeViewImageListPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewImageListPage));
            this.mobjImageList = new Gizmox.WebGUI.Forms.ImageList(this.components);
            this.mobjTreeViewMessages = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // mobjImageList
            // 
            this.mobjImageList.Images.AddRange(new Gizmox.WebGUI.Common.Resources.ResourceHandle[] {
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images1")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images2")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images3")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images4")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images5")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images6"))});
            this.mobjImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.mobjImageList.Images.SetKeyName(0, "16x16.Inbox.png");
            this.mobjImageList.Images.SetKeyName(1, "16x16.Outbox.png");
            this.mobjImageList.Images.SetKeyName(2, "16x16.SentItems.png");
            this.mobjImageList.Images.SetKeyName(3, "16x16.Junk.png");
            this.mobjImageList.Images.SetKeyName(4, "16x16.RecoverDeletedItems.png");
            this.mobjImageList.Images.SetKeyName(5, "16x16.ClosedEmail.png");
            this.mobjImageList.Images.SetKeyName(6, "16x16.OpenedEmail.png");
            // 
            // mobjTreeViewMessages
            // 
            this.mobjTreeViewMessages.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeViewMessages.Location = new System.Drawing.Point(20, 20);
            this.mobjTreeViewMessages.Name = "mobjTreeViewMessages";
            this.mobjTreeViewMessages.Size = new System.Drawing.Size(351, 266);
            this.mobjTreeViewMessages.TabIndex = 1;
            // 
            // TreeViewImageListPage
            // 
            this.Controls.Add(this.mobjTreeViewMessages);
            this.DockPadding.All = 20;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "TreeViewImageListPage";
            this.Load += new System.EventHandler(this.TreeViewImageListPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ImageList mobjImageList;
        private Gizmox.WebGUI.Forms.TreeView mobjTreeViewMessages;



    }
}