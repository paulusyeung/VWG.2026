namespace CompanionKit.Controls.RibbonBar.Appearance
{
    partial class AddingGroupsPage
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
			this.demoRibbonBar = new Gizmox.WebGUI.Forms.RibbonBar();
			this.rbView = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbGroupBookmarks = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbGroupAdvanced = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbEdit = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbGroupFind = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.rbGroupIntelliSence = new Gizmox.WebGUI.Forms.RibbonBarGroup();
			this.lblStatus = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.lblAdvanced = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// demoRibbonBar
			// 
			this.demoRibbonBar.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.demoRibbonBar.Location = new System.Drawing.Point(0, 0);
			this.demoRibbonBar.Name = "demoRibbonBar";
			this.demoRibbonBar.Pages.Add(this.rbView);
			this.demoRibbonBar.Pages.Add(this.rbEdit);
			this.demoRibbonBar.SelectedIndex = 0;
			this.demoRibbonBar.TabIndex = 0;
			this.demoRibbonBar.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.demoRibbonBar.AdvancedClicked += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarGroupArgs>(this.AdvancedClicked);
			// 
			// rbView
			// 
			this.rbView.Groups.Add(this.rbGroupBookmarks);
			this.rbView.Groups.Add(this.rbGroupAdvanced);
			this.rbView.Text = "View";
			// 
			// rbGroupBookmarks
			// 
			this.rbGroupBookmarks.Text = "Bookmarks";
			// 
			// rbGroupAdvanced
			// 
			this.rbGroupAdvanced.HasAdvanced = true;
			this.rbGroupAdvanced.Text = "Advanced";
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
			this.rbGroupFind.Text = "Find and Replace";
			// 
			// rbGroupIntelliSence
			// 
			this.rbGroupIntelliSence.Text = "IntelliSence";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
			this.lblStatus.Location = new System.Drawing.Point(8, 17);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(35, 13);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "The Active page:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblAdvanced);
			this.groupBox1.Controls.Add(this.lblStatus);
			this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(0, 115);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(686, 142);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// lblAdvanced
			// 
			this.lblAdvanced.AutoSize = true;
			this.lblAdvanced.ForeColor = System.Drawing.Color.SlateBlue;
			this.lblAdvanced.Location = new System.Drawing.Point(8, 40);
			this.lblAdvanced.Name = "lblAdvanced";
			this.lblAdvanced.Size = new System.Drawing.Size(35, 13);
			this.lblAdvanced.TabIndex = 0;
			this.lblAdvanced.Text = "Advanced clicked:";
			this.lblAdvanced.Visible = false;
			// 
			// AddingContainersPagePage
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.demoRibbonBar);
			this.Size = new System.Drawing.Size(686, 257);
			this.Text = "AddingGroupsPage";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private Gizmox.WebGUI.Forms.RibbonBar demoRibbonBar;
		private Gizmox.WebGUI.Forms.RibbonBarPage rbView;
		private Gizmox.WebGUI.Forms.RibbonBarPage rbEdit;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupBookmarks;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupAdvanced;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupFind;
		private Gizmox.WebGUI.Forms.RibbonBarGroup rbGroupIntelliSence;
		private Gizmox.WebGUI.Forms.Label lblStatus;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.Label lblAdvanced;

	}
}