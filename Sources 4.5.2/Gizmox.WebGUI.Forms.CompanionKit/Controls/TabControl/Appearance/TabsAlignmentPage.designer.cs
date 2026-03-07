namespace CompanionKit.Controls.TabControl.Appearance
{
    partial class TabsAlignmentPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabsAlignmentPage));
            this.mobjTabControl = new Gizmox.WebGUI.Forms.TabControl();
            this.mobjGreenTabPage = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjYellowTabPage = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjRedTabPage = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjTopRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjBottomRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjAlignmentGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.mobjTabControl)).BeginInit();
            this.mobjTabControl.SuspendLayout();
            this.mobjAlignmentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTabControl
            // 
            this.mobjTabControl.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTabControl.Controls.Add(this.mobjGreenTabPage);
            this.mobjTabControl.Controls.Add(this.mobjYellowTabPage);
            this.mobjTabControl.Controls.Add(this.mobjRedTabPage);
            this.mobjTabControl.Location = new System.Drawing.Point(58, 32);
            this.mobjTabControl.Name = "mobjTabControl";
            this.mobjTabControl.SelectedIndex = 0;
            this.mobjTabControl.Size = new System.Drawing.Size(270, 251);
            this.mobjTabControl.TabIndex = 0;
            // 
            // mobjGreenTabPage
            // 
            this.mobjGreenTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mobjGreenTabPage.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjGreenTabPage.BackgroundImage"));
            this.mobjGreenTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.mobjGreenTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGreenTabPage.Location = new System.Drawing.Point(4, 22);
            this.mobjGreenTabPage.Name = "mobjGreenTabPage";
            this.mobjGreenTabPage.Size = new System.Drawing.Size(262, 225);
            this.mobjGreenTabPage.TabIndex = 0;
            this.mobjGreenTabPage.Text = "GreenTabPage";
            // 
            // mobjYellowTabPage
            // 
            this.mobjYellowTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mobjYellowTabPage.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjYellowTabPage.BackgroundImage"));
            this.mobjYellowTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.mobjYellowTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjYellowTabPage.Location = new System.Drawing.Point(4, 22);
            this.mobjYellowTabPage.Name = "mobjYellowTabPage";
            this.mobjYellowTabPage.Size = new System.Drawing.Size(262, 225);
            this.mobjYellowTabPage.TabIndex = 1;
            this.mobjYellowTabPage.Text = "YellowTabPage";
            // 
            // mobjRedTabPage
            // 
            this.mobjRedTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.mobjRedTabPage.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRedTabPage.BackgroundImage"));
            this.mobjRedTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.mobjRedTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRedTabPage.Location = new System.Drawing.Point(0, 0);
            this.mobjRedTabPage.Name = "mobjRedTabPage";
            this.mobjRedTabPage.Size = new System.Drawing.Size(262, 225);
            this.mobjRedTabPage.TabIndex = 2;
            this.mobjRedTabPage.Text = "RedTabPage";
            // 
            // mobjTopRadioButton
            // 
            this.mobjTopRadioButton.AutoSize = true;
            this.mobjTopRadioButton.Checked = true;
            this.mobjTopRadioButton.Location = new System.Drawing.Point(40, 29);
            this.mobjTopRadioButton.Name = "mobjTopRadioButton";
            this.mobjTopRadioButton.Size = new System.Drawing.Size(43, 17);
            this.mobjTopRadioButton.TabIndex = 1;
            this.mobjTopRadioButton.Text = "Top";
            this.mobjTopRadioButton.CheckedChanged += new System.EventHandler(this.mobjTopRadioButton_CheckedChanged);
            // 
            // mobjBottomRadioButton
            // 
            this.mobjBottomRadioButton.AutoSize = true;
            this.mobjBottomRadioButton.Location = new System.Drawing.Point(40, 55);
            this.mobjBottomRadioButton.Name = "mobjBottomRadioButton";
            this.mobjBottomRadioButton.Size = new System.Drawing.Size(59, 17);
            this.mobjBottomRadioButton.TabIndex = 2;
            this.mobjBottomRadioButton.Text = "Bottom";
            // 
            // mobjAlignmentGroupBox
            // 
            this.mobjAlignmentGroupBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAlignmentGroupBox.Controls.Add(this.mobjTopRadioButton);
            this.mobjAlignmentGroupBox.Controls.Add(this.mobjBottomRadioButton);
            this.mobjAlignmentGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjAlignmentGroupBox.Location = new System.Drawing.Point(58, 310);
            this.mobjAlignmentGroupBox.Name = "mobjAlignmentGroupBox";
            this.mobjAlignmentGroupBox.Size = new System.Drawing.Size(150, 88);
            this.mobjAlignmentGroupBox.TabIndex = 3;
            this.mobjAlignmentGroupBox.TabStop = false;
            this.mobjAlignmentGroupBox.Text = "Tabs Alignment";
            // 
            // TabsAlignmentPage
            // 
            this.Controls.Add(this.mobjAlignmentGroupBox);
            this.Controls.Add(this.mobjTabControl);
            this.Size = new System.Drawing.Size(385, 427);
            this.Text = "TabsAlignmentPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjTabControl)).EndInit();
            this.mobjTabControl.ResumeLayout(false);
            this.mobjAlignmentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl mobjTabControl;
        private Gizmox.WebGUI.Forms.TabPage mobjGreenTabPage;
        private Gizmox.WebGUI.Forms.TabPage mobjYellowTabPage;
        private Gizmox.WebGUI.Forms.RadioButton mobjTopRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjBottomRadioButton;
        private Gizmox.WebGUI.Forms.GroupBox mobjAlignmentGroupBox;
        private Gizmox.WebGUI.Forms.TabPage mobjRedTabPage;



    }
}