namespace CompanionKit.Controls.ToolStripMenuItem.Features
{
    partial class DropDownTitlePanelPage
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
            this.mobjMenuStrip = new Gizmox.WebGUI.Forms.MenuStrip();
            this.mobjToolStripMenuItem1 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.mobjToolStripMenuItem3 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.mobjToolStripMenuItem4 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.mobjToolStripMenuItem5 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.mobjToolStripMenuItem6 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.mobjToolStripSeparator1 = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjMenuStrip
            // 
            this.mobjMenuStrip.DockPadding.Bottom = 2;
            this.mobjMenuStrip.DockPadding.Left = 6;
            this.mobjMenuStrip.DockPadding.Top = 2;
            this.mobjMenuStrip.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.mobjToolStripMenuItem1});
            this.mobjMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mobjMenuStrip.Name = "mobjMenuStrip";
            this.mobjMenuStrip.Size = new System.Drawing.Size(391, 24);
            this.mobjMenuStrip.TabIndex = 0;
            this.mobjMenuStrip.Text = "menuStrip1";
            // 
            // mobjToolStripMenuItem1
            // 
            this.mobjToolStripMenuItem1.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.mobjToolStripMenuItem3,
            this.mobjToolStripMenuItem4,
            this.mobjToolStripMenuItem5,
            this.mobjToolStripMenuItem6,
            this.mobjToolStripSeparator1});
            this.mobjToolStripMenuItem1.Name = "mobjToolStripMenuItem1";
            this.mobjToolStripMenuItem1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.mobjToolStripMenuItem1.Size = new System.Drawing.Size(56, 17);
            this.mobjToolStripMenuItem1.Text = "RootItem";
            this.mobjToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjToolStripMenuItem3
            // 
            this.mobjToolStripMenuItem3.Name = "mobjToolStripMenuItem3";
            this.mobjToolStripMenuItem3.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.mobjToolStripMenuItem3.Size = new System.Drawing.Size(120, 20);
            this.mobjToolStripMenuItem3.Text = "SubItem1";
            this.mobjToolStripMenuItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjToolStripMenuItem4
            // 
            this.mobjToolStripMenuItem4.Name = "mobjToolStripMenuItem4";
            this.mobjToolStripMenuItem4.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.mobjToolStripMenuItem4.Size = new System.Drawing.Size(120, 20);
            this.mobjToolStripMenuItem4.Text = "SubItem2";
            this.mobjToolStripMenuItem4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjToolStripMenuItem5
            // 
            this.mobjToolStripMenuItem5.Name = "mobjToolStripMenuItem5";
            this.mobjToolStripMenuItem5.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.mobjToolStripMenuItem5.Size = new System.Drawing.Size(120, 20);
            this.mobjToolStripMenuItem5.Text = "SubItem3";
            this.mobjToolStripMenuItem5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjToolStripMenuItem6
            // 
            this.mobjToolStripMenuItem6.Name = "mobjToolStripMenuItem6";
            this.mobjToolStripMenuItem6.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.mobjToolStripMenuItem6.Size = new System.Drawing.Size(120, 20);
            this.mobjToolStripMenuItem6.Text = "SubItem4";
            this.mobjToolStripMenuItem6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjToolStripSeparator1
            // 
            this.mobjToolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.mobjToolStripSeparator1.Name = "mobjToolStripSeparator1";
            this.mobjToolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 24);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(409, 13);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Tip: You should reopen dropdown list after adding or removing item, to see change" +
    "s";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DropDownTitlePanelPage
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjMenuStrip);
            this.Size = new System.Drawing.Size(450, 150);
            this.Text = "DropDownTitlePanelPage";
            this.Load += new System.EventHandler(this.DropDownTitlePanelPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MenuStrip mobjMenuStrip;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem mobjToolStripMenuItem1;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem mobjToolStripMenuItem3;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem mobjToolStripMenuItem4;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem mobjToolStripMenuItem5;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveButton;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem mobjToolStripMenuItem6;
        private Gizmox.WebGUI.Forms.ToolStripSeparator mobjToolStripSeparator1;
        private Gizmox.WebGUI.Forms.Label mobjLabel;


    }
}