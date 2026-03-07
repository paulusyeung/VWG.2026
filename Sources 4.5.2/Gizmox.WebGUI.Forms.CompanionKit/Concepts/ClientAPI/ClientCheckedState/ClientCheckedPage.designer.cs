namespace CompanionKit.Concepts.ClientAPI.ClientCheckedState
{
    partial class ClientCheckedPage
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
            this.objStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.objCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.objTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objLeftPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objRightPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objCenterPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            this.objTopPanel.SuspendLayout();
            this.objCenterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objStateLabel
            // 
            this.objStateLabel.ClientId = "label";
            this.objStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objStateLabel.Location = new System.Drawing.Point(123, 0);
            this.objStateLabel.Name = "objStateLabel";
            this.objStateLabel.Size = new System.Drawing.Size(171, 100);
            this.objStateLabel.TabIndex = 0;
            this.objStateLabel.Text = "false";
            // 
            // objCheckBox
            // 
            this.objCheckBox.ClientId = "checkBox";
            this.objCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objCheckBox.Location = new System.Drawing.Point(0, 0);
            this.objCheckBox.Name = "objCheckBox";
            this.objCheckBox.Size = new System.Drawing.Size(294, 96);
            this.objCheckBox.TabIndex = 1;
            this.objCheckBox.Text = "Test CheckBox";
            this.objCheckBox.ClientCheckedChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.testCheckBox_ClientCheckedChanged);
            // 
            // objTopPanel
            // 
            this.objTopPanel.Controls.Add(this.objCheckBox);
            this.objTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.objTopPanel.Location = new System.Drawing.Point(36, 0);
            this.objTopPanel.Name = "objTopPanel";
            this.objTopPanel.Size = new System.Drawing.Size(294, 96);
            this.objTopPanel.TabIndex = 2;
            // 
            // objLeftPanel
            // 
            this.objLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.objLeftPanel.Name = "objLeftPanel";
            this.objLeftPanel.Size = new System.Drawing.Size(36, 306);
            this.objLeftPanel.TabIndex = 3;
            // 
            // objRightPanel
            // 
            this.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.objRightPanel.Location = new System.Drawing.Point(330, 0);
            this.objRightPanel.Name = "objRightPanel";
            this.objRightPanel.Size = new System.Drawing.Size(47, 306);
            this.objRightPanel.TabIndex = 4;
            // 
            // objCenterPanel
            // 
            this.objCenterPanel.Controls.Add(this.objStateLabel);
            this.objCenterPanel.Controls.Add(this.objLabel);
            this.objCenterPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.objCenterPanel.Location = new System.Drawing.Point(36, 96);
            this.objCenterPanel.Name = "objCenterPanel";
            this.objCenterPanel.Size = new System.Drawing.Size(294, 100);
            this.objCenterPanel.TabIndex = 5;
            // 
            // objLabel
            // 
            this.objLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objLabel.Location = new System.Drawing.Point(0, 0);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(123, 100);
            this.objLabel.TabIndex = 0;
            this.objLabel.Text = "Is CheckBox checked:";
            // 
            // ClientCheckedPage
            // 
            this.Controls.Add(this.objCenterPanel);
            this.Controls.Add(this.objTopPanel);
            this.Controls.Add(this.objRightPanel);
            this.Controls.Add(this.objLeftPanel);
            this.Size = new System.Drawing.Size(377, 306);
            this.Text = "CheckedClientPage";
            this.objTopPanel.ResumeLayout(false);
            this.objCenterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label objStateLabel;
        private Gizmox.WebGUI.Forms.CheckBox objCheckBox;
        private Gizmox.WebGUI.Forms.Panel objTopPanel;
        private Gizmox.WebGUI.Forms.Panel objLeftPanel;
        private Gizmox.WebGUI.Forms.Panel objRightPanel;
        private Gizmox.WebGUI.Forms.Panel objCenterPanel;
        private Gizmox.WebGUI.Forms.Label objLabel;
    }
}