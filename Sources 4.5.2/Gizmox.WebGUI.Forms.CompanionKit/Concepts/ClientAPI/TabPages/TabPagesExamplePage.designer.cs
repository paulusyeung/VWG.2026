namespace CompanionKit.Concepts.ClientAPI.TabPages
{
    partial class TabPagesExamplePage
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
            this.objCountLabel = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objTabControl)).BeginInit();
            this.objTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // objTabControl
            // 
            this.objTabControl.ClientId = "tab";
            this.objTabControl.Controls.Add(this.objTabPage1);
            this.objTabControl.Controls.Add(this.objTabPage2);
            this.objTabControl.Controls.Add(this.objTabPage3);
            this.objTabControl.Controls.Add(this.objTabPage4);
            this.objTabControl.Controls.Add(this.objTabPage5);
            this.objTabControl.Location = new System.Drawing.Point(29, 33);
            this.objTabControl.Name = "objTabControl";
            this.objTabControl.SelectedIndex = 0;
            this.objTabControl.ShowCloseButton = true;
            this.objTabControl.Size = new System.Drawing.Size(252, 251);
            this.objTabControl.TabIndex = 0;
            this.objTabControl.ClientCloseClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objTabControl_ClientCloseClick);
            // 
            // objTabPage1
            // 
            this.objTabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.objTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage1.Location = new System.Drawing.Point(4, 22);
            this.objTabPage1.Name = "objTabPage1";
            this.objTabPage1.Size = new System.Drawing.Size(244, 225);
            this.objTabPage1.TabIndex = 0;
            this.objTabPage1.Text = "tabPage1";
            // 
            // objTabPage2
            // 
            this.objTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.objTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage2.Location = new System.Drawing.Point(4, 22);
            this.objTabPage2.Name = "objTabPage2";
            this.objTabPage2.Size = new System.Drawing.Size(244, 225);
            this.objTabPage2.TabIndex = 1;
            this.objTabPage2.Text = "tabPage2";
            // 
            // objTabPage3
            // 
            this.objTabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.objTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage3.Location = new System.Drawing.Point(0, 0);
            this.objTabPage3.Name = "objTabPage3";
            this.objTabPage3.Size = new System.Drawing.Size(244, 225);
            this.objTabPage3.TabIndex = 2;
            this.objTabPage3.Text = "tabPage3";
            // 
            // objTabPage4
            // 
            this.objTabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.objTabPage4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage4.Location = new System.Drawing.Point(0, 0);
            this.objTabPage4.Name = "objTabPage4";
            this.objTabPage4.Size = new System.Drawing.Size(244, 225);
            this.objTabPage4.TabIndex = 3;
            this.objTabPage4.Text = "tabPage4";
            // 
            // objTabPage5
            // 
            this.objTabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.objTabPage5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objTabPage5.Location = new System.Drawing.Point(0, 0);
            this.objTabPage5.Name = "objTabPage5";
            this.objTabPage5.Size = new System.Drawing.Size(244, 225);
            this.objTabPage5.TabIndex = 4;
            this.objTabPage5.Text = "tabPage5";
            // 
            // objCountLabel
            // 
            this.objCountLabel.AutoSize = true;
            this.objCountLabel.ClientId = "countLabel";
            this.objCountLabel.Location = new System.Drawing.Point(30, 321);
            this.objCountLabel.Name = "objCountLabel";
            this.objCountLabel.Size = new System.Drawing.Size(35, 13);
            this.objCountLabel.TabIndex = 1;
            this.objCountLabel.Text = "5 page(s) left";
            // 
            // TabPagesExamplePage
            // 
            this.Controls.Add(this.objCountLabel);
            this.Controls.Add(this.objTabControl);
            this.Size = new System.Drawing.Size(332, 365);
            this.Text = "TabControlPage";
            ((System.ComponentModel.ISupportInitialize)(this.objTabControl)).EndInit();
            this.objTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl objTabControl;
        private Gizmox.WebGUI.Forms.TabPage objTabPage1;
        private Gizmox.WebGUI.Forms.TabPage objTabPage2;
        private Gizmox.WebGUI.Forms.TabPage objTabPage3;
        private Gizmox.WebGUI.Forms.TabPage objTabPage4;
        private Gizmox.WebGUI.Forms.TabPage objTabPage5;
        private Gizmox.WebGUI.Forms.Label objCountLabel;



    }
}