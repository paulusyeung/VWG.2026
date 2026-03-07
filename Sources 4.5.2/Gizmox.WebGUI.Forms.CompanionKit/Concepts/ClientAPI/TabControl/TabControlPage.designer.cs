namespace CompanionKit.Concepts.ClientAPI.TabControl
{
    partial class TabControlPage
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
            this.objTabControl = new Gizmox.WebGUI.Forms.TabControl();
            this.objTabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.objTabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.objTabPage3 = new Gizmox.WebGUI.Forms.TabPage();
            this.objTabPage4 = new Gizmox.WebGUI.Forms.TabPage();
            this.objTabPage5 = new Gizmox.WebGUI.Forms.TabPage();
            this.objSelectedIndexLabelText = new Gizmox.WebGUI.Forms.Label();
            this.objPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.objTabControl)).BeginInit();
            this.objTabControl.SuspendLayout();
            this.objPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objTabControl
            // 
            this.objTabControl.AccessibleDescription = "";
            this.objTabControl.AccessibleName = "";
            this.objTabControl.ClientId = "tab";
            this.objTabControl.Controls.Add(this.objTabPage1);
            this.objTabControl.Controls.Add(this.objTabPage2);
            this.objTabControl.Controls.Add(this.objTabPage3);
            this.objTabControl.Controls.Add(this.objTabPage4);
            this.objTabControl.Controls.Add(this.objTabPage5);
            this.objTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabControl.Location = new System.Drawing.Point(15, 15);
            this.objTabControl.MaximumSize = new System.Drawing.Size(325, 217);
            this.objTabControl.Name = "objTabControl";
            this.objTabControl.SelectedIndex = 0;
            this.objTabControl.Size = new System.Drawing.Size(325, 217);
            this.objTabControl.TabIndex = 0;
            this.objTabControl.ClientSelectedIndexChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objTabControl_ClientSelectedIndexChanged);
            // 
            // objTabPage1
            // 
            this.objTabPage1.AccessibleDescription = "";
            this.objTabPage1.AccessibleName = "";
            this.objTabPage1.BackColor = System.Drawing.Color.Yellow;
            this.objTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage1.Location = new System.Drawing.Point(4, 22);
            this.objTabPage1.Name = "objTabPage1";
            this.objTabPage1.Size = new System.Drawing.Size(317, 191);
            this.objTabPage1.TabIndex = 0;
            this.objTabPage1.Text = "tabPage1";
            // 
            // objTabPage2
            // 
            this.objTabPage2.AccessibleDescription = "";
            this.objTabPage2.AccessibleName = "";
            this.objTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.objTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage2.Location = new System.Drawing.Point(4, 22);
            this.objTabPage2.Name = "objTabPage2";
            this.objTabPage2.Size = new System.Drawing.Size(289, 229);
            this.objTabPage2.TabIndex = 1;
            this.objTabPage2.Text = "tabPage2";
            // 
            // objTabPage3
            // 
            this.objTabPage3.AccessibleDescription = "";
            this.objTabPage3.AccessibleName = "";
            this.objTabPage3.BackColor = System.Drawing.Color.Red;
            this.objTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage3.Location = new System.Drawing.Point(0, 0);
            this.objTabPage3.Name = "objTabPage3";
            this.objTabPage3.Size = new System.Drawing.Size(289, 229);
            this.objTabPage3.TabIndex = 2;
            this.objTabPage3.Text = "tabPage3";
            // 
            // objTabPage4
            // 
            this.objTabPage4.AccessibleDescription = "";
            this.objTabPage4.AccessibleName = "";
            this.objTabPage4.BackColor = System.Drawing.Color.Purple;
            this.objTabPage4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage4.Location = new System.Drawing.Point(0, 0);
            this.objTabPage4.Name = "objTabPage4";
            this.objTabPage4.Size = new System.Drawing.Size(289, 229);
            this.objTabPage4.TabIndex = 3;
            this.objTabPage4.Text = "tabPage4";
            // 
            // objTabPage5
            // 
            this.objTabPage5.AccessibleDescription = "";
            this.objTabPage5.AccessibleName = "";
            this.objTabPage5.BackColor = System.Drawing.Color.Blue;
            this.objTabPage5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage5.Location = new System.Drawing.Point(0, 0);
            this.objTabPage5.Name = "objTabPage5";
            this.objTabPage5.Size = new System.Drawing.Size(283, 191);
            this.objTabPage5.TabIndex = 4;
            this.objTabPage5.Text = "tabPage5";
            // 
            // objSelectedIndexLabelText
            // 
            this.objSelectedIndexLabelText.AccessibleDescription = "";
            this.objSelectedIndexLabelText.AccessibleName = "";
            this.objSelectedIndexLabelText.ClientId = "indexLabel";
            this.objSelectedIndexLabelText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.objSelectedIndexLabelText.Location = new System.Drawing.Point(20, 20);
            this.objSelectedIndexLabelText.Name = "objSelectedIndexLabelText";
            this.objSelectedIndexLabelText.Size = new System.Drawing.Size(285, 60);
            this.objSelectedIndexLabelText.TabIndex = 2;
            this.objSelectedIndexLabelText.Text = "Index of selected tabPage:<index>";
            // 
            // objPanel
            // 
            this.objPanel.AccessibleDescription = "";
            this.objPanel.AccessibleName = "";
            this.objPanel.Controls.Add(this.objSelectedIndexLabelText);
            this.objPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objPanel.DockPadding.All = 20;
            this.objPanel.Location = new System.Drawing.Point(15, 232);
            this.objPanel.Name = "objPanel";
            this.objPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.objPanel.Size = new System.Drawing.Size(325, 100);
            this.objPanel.TabIndex = 5;
            // 
            // TabControlPage
            // 
            this.Controls.Add(this.objTabControl);
            this.Controls.Add(this.objPanel);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(355, 347);
            this.Text = "TabPagesExamplePage";
            ((System.ComponentModel.ISupportInitialize)(this.objTabControl)).EndInit();
            this.objTabControl.ResumeLayout(false);
            this.objPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl objTabControl;
        private Gizmox.WebGUI.Forms.TabPage objTabPage1;
        private Gizmox.WebGUI.Forms.TabPage objTabPage2;
        private Gizmox.WebGUI.Forms.TabPage objTabPage3;
        private Gizmox.WebGUI.Forms.TabPage objTabPage4;
        private Gizmox.WebGUI.Forms.TabPage objTabPage5;
        private Gizmox.WebGUI.Forms.Label objSelectedIndexLabelText;
        private Gizmox.WebGUI.Forms.Panel objPanel;



    }
}