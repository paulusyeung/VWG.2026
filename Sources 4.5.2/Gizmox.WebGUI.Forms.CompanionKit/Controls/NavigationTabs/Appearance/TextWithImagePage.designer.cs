namespace CompanionKit.Controls.NavigationTabs.Appearance
{
    partial class TextWithImagePage
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
			this.mobjSplitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
			this.mobjExtraTab1 = new Gizmox.WebGUI.Forms.NavigationTab();
			this.mobjExtraTab2 = new Gizmox.WebGUI.Forms.NavigationTab();
			this.mobjNavigationTabs = new Gizmox.WebGUI.Forms.NavigationTabs();
			this.mobjNavigationTabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.mobjSplitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjSplitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
			this.mobjSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjSplitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
			this.mobjSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mobjSplitContainer.Name = "mobjSplitContainer";
			this.mobjSplitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
			// 
			// splitContainer1.Panel1
			// 
			this.mobjSplitContainer.Panel1.Controls.Add(this.mobjNavigationTabs);
			this.mobjSplitContainer.Size = new System.Drawing.Size(752, 510);
			this.mobjSplitContainer.SplitterDistance = 210;
			this.mobjSplitContainer.TabIndex = 0;
			// 
			// mobjExtraTab1
			// 
			this.mobjExtraTab1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjExtraTab1.Extra = true;
			this.mobjExtraTab1.Label = "Data Controls";
			this.mobjExtraTab1.Location = new System.Drawing.Point(0, 0);
			this.mobjExtraTab1.Name = "mobjExtraTab1";
			this.mobjExtraTab1.Size = new System.Drawing.Size(213, 321);
			this.mobjExtraTab1.TabIndex = 0;
			this.mobjExtraTab1.Text = "Data Controls";
			// 
			// mobjExtraTab2
			// 
			this.mobjExtraTab2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjExtraTab2.Extra = true;
			this.mobjExtraTab2.Label = "Host Controls";
			this.mobjExtraTab2.Location = new System.Drawing.Point(0, 0);
			this.mobjExtraTab2.Name = "mobjExtraTab2";
			this.mobjExtraTab2.Size = new System.Drawing.Size(213, 321);
			this.mobjExtraTab2.TabIndex = 1;
			this.mobjExtraTab2.Text = "Host Controls";
			// 
			// demoNavigationTabs
			// 
			this.mobjNavigationTabs.Controls.Add(this.mobjExtraTab1);
			this.mobjNavigationTabs.Controls.Add(this.mobjExtraTab2);
			this.mobjNavigationTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjNavigationTabs.Location = new System.Drawing.Point(0, 0);
			this.mobjNavigationTabs.Name = "mobjNavigationTabs";
			this.mobjNavigationTabs.SelectedIndex = 0;
			this.mobjNavigationTabs.Size = new System.Drawing.Size(210, 510);
			this.mobjNavigationTabs.TabIndex = 0;
			// 
			// TextWithImagePage
			// 
			this.Controls.Add(this.mobjSplitContainer);
			this.Size = new System.Drawing.Size(752, 510);
			this.Text = "TextWithImagePage";
			this.Load += new System.EventHandler(this.FillNavigationTabs);
			this.mobjNavigationTabs.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private Gizmox.WebGUI.Forms.SplitContainer mobjSplitContainer;
		private Gizmox.WebGUI.Forms.NavigationTabs mobjNavigationTabs;
		private Gizmox.WebGUI.Forms.NavigationTab mobjExtraTab1;
		private Gizmox.WebGUI.Forms.NavigationTab mobjExtraTab2;




	}
}