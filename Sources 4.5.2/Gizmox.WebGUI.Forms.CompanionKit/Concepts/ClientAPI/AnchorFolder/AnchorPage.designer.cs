namespace CompanionKit.Concepts.ClientAPI.AnchorFolder
{
    partial class AnchorPage
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
            this.objCustomAnchorListBox = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.AnchorFolder.CustomAnchorListBox();
            this.objAnchorGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.objAnchorPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objAnchorDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.objAnchorGroupBox.SuspendLayout();
            this.objAnchorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objCustomAnchorListBox
            // 
            this.objCustomAnchorListBox.CustomStyle = "CustomAnchorListBoxSkin";
            this.objCustomAnchorListBox.Items.AddRange(new object[] {
            "left: true",
            "right: false",
            "top: true",
            "bottom: false "});
            this.objCustomAnchorListBox.Location = new System.Drawing.Point(29, 18);
            this.objCustomAnchorListBox.Name = "objCustomAnchorListBox";
            this.objCustomAnchorListBox.Size = new System.Drawing.Size(136, 108);
            this.objCustomAnchorListBox.TabIndex = 5;
            // 
            // objAnchorGroupBox
            // 
            this.objAnchorGroupBox.Controls.Add(this.objAnchorPanel);
            this.objAnchorGroupBox.Controls.Add(this.objAnchorDescriptionLabel);
            this.objAnchorGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objAnchorGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objAnchorGroupBox.Location = new System.Drawing.Point(15, 15);
            this.objAnchorGroupBox.Name = "objAnchorGroupBox";
            this.objAnchorGroupBox.Size = new System.Drawing.Size(320, 275);
            this.objAnchorGroupBox.TabIndex = 4;
            this.objAnchorGroupBox.TabStop = false;
            this.objAnchorGroupBox.Text = "Anchor";
            // 
            // objAnchorPanel
            // 
            this.objAnchorPanel.Controls.Add(this.objCustomAnchorListBox);
            this.objAnchorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objAnchorPanel.Location = new System.Drawing.Point(3, 119);
            this.objAnchorPanel.Name = "objAnchorPanel";
            this.objAnchorPanel.Size = new System.Drawing.Size(314, 153);
            this.objAnchorPanel.TabIndex = 2;
            // 
            // objAnchorDescriptionLabel
            // 
            this.objAnchorDescriptionLabel.AutoSize = true;
            this.objAnchorDescriptionLabel.Location = new System.Drawing.Point(11, 26);
            this.objAnchorDescriptionLabel.Name = "objAnchorDescriptionLabel";
            this.objAnchorDescriptionLabel.Size = new System.Drawing.Size(35, 13);
            this.objAnchorDescriptionLabel.TabIndex = 1;
            this.objAnchorDescriptionLabel.Text = "To change anchor press:\r\nLeft key - left\r\nRight key - right\r\nUp key - top\r\nDown k" +
    "ey - bottom\r\n";
            // 
            // AnchorPage
            // 
            this.Controls.Add(this.objAnchorGroupBox);
            this.DockPadding.All = 15;
            this.MaximumSize = new System.Drawing.Size(350, 448);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(350, 305);
            this.Text = "AnchorAndPaddingPage";
            this.objAnchorGroupBox.ResumeLayout(false);
            this.objAnchorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.AnchorFolder.CustomAnchorListBox objCustomAnchorListBox;
        private Gizmox.WebGUI.Forms.GroupBox objAnchorGroupBox;
        private Gizmox.WebGUI.Forms.Label objAnchorDescriptionLabel;
        private Gizmox.WebGUI.Forms.Panel objAnchorPanel;



    }
}