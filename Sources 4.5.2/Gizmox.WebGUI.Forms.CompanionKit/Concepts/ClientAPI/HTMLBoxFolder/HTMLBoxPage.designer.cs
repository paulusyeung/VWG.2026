namespace CompanionKit.Concepts.ClientAPI.HTMLBoxFolder
{
    partial class HTMLBoxPage
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
            this.objHTMLBox = new Gizmox.WebGUI.Forms.HtmlBox();
            this.objNavigationPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objAddressPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.objButton = new Gizmox.WebGUI.Forms.Button();
            this.objButtonPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objNavigationPanel.SuspendLayout();
            this.objAddressPanel.SuspendLayout();
            this.objButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objHTMLBox
            // 
            this.objHTMLBox.ClientId = "htmlBox";
            this.objHTMLBox.ContentType = "text/html";
            this.objHTMLBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objHTMLBox.Html = "";
            this.objHTMLBox.Location = new System.Drawing.Point(0, 72);
            this.objHTMLBox.Name = "objHTMLBox";
            this.objHTMLBox.Size = new System.Drawing.Size(391, 360);
            this.objHTMLBox.TabIndex = 0;
            // 
            // objNavigationPanel
            // 
            this.objNavigationPanel.Controls.Add(this.objAddressPanel);
            this.objNavigationPanel.Controls.Add(this.objButtonPanel);
            this.objNavigationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.objNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.objNavigationPanel.Name = "objNavigationPanel";
            this.objNavigationPanel.Size = new System.Drawing.Size(391, 72);
            this.objNavigationPanel.TabIndex = 1;
            // 
            // objAddressPanel
            // 
            this.objAddressPanel.Controls.Add(this.objTextBox);
            this.objAddressPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objAddressPanel.DockPadding.Left = 15;
            this.objAddressPanel.DockPadding.Right = 15;
            this.objAddressPanel.DockPadding.Top = 25;
            this.objAddressPanel.Location = new System.Drawing.Point(0, 0);
            this.objAddressPanel.Name = "objAddressPanel";
            this.objAddressPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 25, 15, 0);
            this.objAddressPanel.Size = new System.Drawing.Size(316, 72);
            this.objAddressPanel.TabIndex = 1;
            // 
            // objTextBox
            // 
            this.objTextBox.AllowDrag = false;
            this.objTextBox.ClientId = "textBox";
            this.objTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTextBox.Location = new System.Drawing.Point(15, 25);
            this.objTextBox.MaximumSize = new System.Drawing.Size(0, 20);
            this.objTextBox.Name = "objTextBox";
            this.objTextBox.Size = new System.Drawing.Size(286, 20);
            this.objTextBox.TabIndex = 0;
            // 
            // objButton
            // 
            this.objButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objButton.Location = new System.Drawing.Point(5, 10);
            this.objButton.Name = "objButton";
            this.objButton.Size = new System.Drawing.Size(60, 52);
            this.objButton.TabIndex = 0;
            this.objButton.Text = "Navigate";
            this.objButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objButton_ClientClick);
            // 
            // objButtonPanel
            // 
            this.objButtonPanel.Controls.Add(this.objButton);
            this.objButtonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.objButtonPanel.DockPadding.Bottom = 10;
            this.objButtonPanel.DockPadding.Left = 5;
            this.objButtonPanel.DockPadding.Right = 10;
            this.objButtonPanel.DockPadding.Top = 10;
            this.objButtonPanel.Location = new System.Drawing.Point(316, 0);
            this.objButtonPanel.Name = "objButtonPanel";
            this.objButtonPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5, 10, 10, 10);
            this.objButtonPanel.Size = new System.Drawing.Size(75, 72);
            this.objButtonPanel.TabIndex = 2;
            // 
            // HTMLBoxPage
            // 
            this.Controls.Add(this.objHTMLBox);
            this.Controls.Add(this.objNavigationPanel);
            this.Size = new System.Drawing.Size(391, 432);
            this.Text = "HTMLBoxPage";
            this.objNavigationPanel.ResumeLayout(false);
            this.objAddressPanel.ResumeLayout(false);
            this.objButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.HtmlBox objHTMLBox;
        private Gizmox.WebGUI.Forms.Panel objNavigationPanel;
        private Gizmox.WebGUI.Forms.Panel objAddressPanel;
        private Gizmox.WebGUI.Forms.TextBox objTextBox;
        private Gizmox.WebGUI.Forms.Button objButton;
        private Gizmox.WebGUI.Forms.Panel objButtonPanel;



    }
}