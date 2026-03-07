namespace CompanionKit.Concepts.ClientAPI.ChangingDockStyle
{
    partial class DockStylesPage
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
            this.objCommonPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objMiddlePanel = new Gizmox.WebGUI.Forms.Panel();
            this.objFillButton = new Gizmox.WebGUI.Forms.Button();
            this.objBottomButton = new Gizmox.WebGUI.Forms.Button();
            this.objTopButton = new Gizmox.WebGUI.Forms.Button();
            this.objLeftButton = new Gizmox.WebGUI.Forms.Button();
            this.objRightButton = new Gizmox.WebGUI.Forms.Button();
            this.objRightPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objLeftPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objTestLabel = new Gizmox.WebGUI.Forms.Label();
            this.objCommonPanel.SuspendLayout();
            this.objMiddlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objCommonPanel
            // 
            this.objCommonPanel.Controls.Add(this.objMiddlePanel);
            this.objCommonPanel.Controls.Add(this.objRightPanel);
            this.objCommonPanel.Controls.Add(this.objLeftPanel);
            this.objCommonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objCommonPanel.Location = new System.Drawing.Point(0, 142);
            this.objCommonPanel.Name = "objCommonPanel";
            this.objCommonPanel.Size = new System.Drawing.Size(266, 100);
            this.objCommonPanel.TabIndex = 0;
            // 
            // objMiddlePanel
            // 
            this.objMiddlePanel.Controls.Add(this.objFillButton);
            this.objMiddlePanel.Controls.Add(this.objBottomButton);
            this.objMiddlePanel.Controls.Add(this.objTopButton);
            this.objMiddlePanel.Controls.Add(this.objLeftButton);
            this.objMiddlePanel.Controls.Add(this.objRightButton);
            this.objMiddlePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objMiddlePanel.DockPadding.All = 5;
            this.objMiddlePanel.Location = new System.Drawing.Point(10, 0);
            this.objMiddlePanel.Name = "objMiddlePanel";
            this.objMiddlePanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.objMiddlePanel.Size = new System.Drawing.Size(246, 100);
            this.objMiddlePanel.TabIndex = 2;
            // 
            // objFillButton
            // 
            this.objFillButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objFillButton.Location = new System.Drawing.Point(73, 33);
            this.objFillButton.Name = "fillButton";
            this.objFillButton.Size = new System.Drawing.Size(93, 39);
            this.objFillButton.TabIndex = 4;
            this.objFillButton.Text = "Fill";
            this.objFillButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objFillButton_ClientClick);
            // 
            // objBottomButton
            // 
            this.objBottomButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objBottomButton.Location = new System.Drawing.Point(73, 72);
            this.objBottomButton.Name = "bottomButton";
            this.objBottomButton.Size = new System.Drawing.Size(93, 23);
            this.objBottomButton.TabIndex = 2;
            this.objBottomButton.Text = "Bottom";
            this.objBottomButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objBottomButton_ClientClick);
            // 
            // objTopButton
            // 
            this.objTopButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.objTopButton.Location = new System.Drawing.Point(73, 5);
            this.objTopButton.Name = "topButton";
            this.objTopButton.Size = new System.Drawing.Size(93, 28);
            this.objTopButton.TabIndex = 0;
            this.objTopButton.Text = "Top";
            this.objTopButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objTopButton_ClientClick);
            // 
            // objLeftButton
            // 
            this.objLeftButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objLeftButton.Location = new System.Drawing.Point(5, 5);
            this.objLeftButton.Name = "leftButton";
            this.objLeftButton.Size = new System.Drawing.Size(68, 90);
            this.objLeftButton.TabIndex = 3;
            this.objLeftButton.Text = "Left";
            this.objLeftButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objLeftButton_ClientClick);
            // 
            // objRightButton
            // 
            this.objRightButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.objRightButton.Location = new System.Drawing.Point(166, 5);
            this.objRightButton.Name = "rightButton";
            this.objRightButton.Size = new System.Drawing.Size(75, 90);
            this.objRightButton.TabIndex = 1;
            this.objRightButton.Text = "Right";
            this.objRightButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objRightButton_ClientClick);
            // 
            // objRightPanel
            // 
            this.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.objRightPanel.Location = new System.Drawing.Point(256, 0);
            this.objRightPanel.Name = "objRightPanel";
            this.objRightPanel.Size = new System.Drawing.Size(10, 100);
            this.objRightPanel.TabIndex = 1;
            // 
            // objLeftPanel
            // 
            this.objLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.objLeftPanel.Name = "objLeftPanel";
            this.objLeftPanel.Size = new System.Drawing.Size(10, 100);
            this.objLeftPanel.TabIndex = 0;
            // 
            // objTestLabel
            // 
            this.objTestLabel.AutoSize = true;
            this.objTestLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.objTestLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.objTestLabel.ClientId = "label";
            this.objTestLabel.ForeColor = System.Drawing.Color.Black;
            this.objTestLabel.Location = new System.Drawing.Point(20, 20);
            this.objTestLabel.Name = "testLabel";
            this.objTestLabel.Size = new System.Drawing.Size(35, 13);
            this.objTestLabel.TabIndex = 1;
            this.objTestLabel.Text = "Test Label";
            this.objTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DockStylesPage
            // 
            this.Controls.Add(this.objTestLabel);
            this.Controls.Add(this.objCommonPanel);
            this.Size = new System.Drawing.Size(266, 242);
            this.Text = "DockStylesPage";
            this.objCommonPanel.ResumeLayout(false);
            this.objMiddlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel objCommonPanel;
        private Gizmox.WebGUI.Forms.Panel objMiddlePanel;
        private Gizmox.WebGUI.Forms.Button objFillButton;
        private Gizmox.WebGUI.Forms.Button objBottomButton;
        private Gizmox.WebGUI.Forms.Button objTopButton;
        private Gizmox.WebGUI.Forms.Button objLeftButton;
        private Gizmox.WebGUI.Forms.Button objRightButton;
        private Gizmox.WebGUI.Forms.Panel objRightPanel;
        private Gizmox.WebGUI.Forms.Panel objLeftPanel;
        private Gizmox.WebGUI.Forms.Label objTestLabel;


    }
}