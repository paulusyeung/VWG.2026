namespace CompanionKit.Controls.RibbonBar.Appearance
{
    partial class AddingPagePage
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
			this.rbPageClipboard = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbPageFormatting = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.rbPageTools = new Gizmox.WebGUI.Forms.RibbonBarPage();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.lblStatus = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// demoRibbonBar
			// 
			this.demoRibbonBar.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.demoRibbonBar.Location = new System.Drawing.Point(0, 0);
			this.demoRibbonBar.Name = "demoRibbonBar";
			this.demoRibbonBar.Pages.Add(this.rbPageClipboard);
			this.demoRibbonBar.Pages.Add(this.rbPageFormatting);
			this.demoRibbonBar.Pages.Add(this.rbPageTools);
			this.demoRibbonBar.SelectedIndex = 0;
			this.demoRibbonBar.TabIndex = 0;
			this.demoRibbonBar.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// rbPageClipboard
			// 
			this.rbPageClipboard.Text = "Clipboard";
			// 
			// rbPageFormatting
			// 
			this.rbPageFormatting.Text = "Formatting";
			// 
			// rbPageTools
			// 
			this.rbPageTools.Text = "Tools";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblStatus);
			this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(0, 115);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(686, 111);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(8, 17);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(35, 13);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "The Active page:";
			// 
			// AddingPagePage
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.demoRibbonBar);
			this.Size = new System.Drawing.Size(686, 226);
			this.Text = "AddingPagePage";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RibbonBar demoRibbonBar;
        private Gizmox.WebGUI.Forms.RibbonBarPage rbPageClipboard;
        private Gizmox.WebGUI.Forms.RibbonBarPage rbPageFormatting;
		private Gizmox.WebGUI.Forms.RibbonBarPage rbPageTools;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.Label lblStatus;



    }
}