namespace CompanionKit.Concepts.ClientAPI.EnabledAndVisible
{
    partial class EnabledVisiblePage
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
            this.mobjEnabledCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjVisibleCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabelEnabled = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabelVisible = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel4 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel3 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel1.SuspendLayout();
            this.mobjPanel2.SuspendLayout();
            this.mobjPanel4.SuspendLayout();
            this.mobjPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjEnabledCheckBox
            // 
            this.mobjEnabledCheckBox.AutoSize = true;
            this.mobjEnabledCheckBox.Checked = true;
            this.mobjEnabledCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjEnabledCheckBox.Location = new System.Drawing.Point(50, 50);
            this.mobjEnabledCheckBox.Name = "mobjEnabledCheckBox";
            this.mobjEnabledCheckBox.Size = new System.Drawing.Size(64, 17);
            this.mobjEnabledCheckBox.TabIndex = 1;
            this.mobjEnabledCheckBox.Text = "Enabled";
            this.mobjEnabledCheckBox.ClientCheckedChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjEnabledCheckBox_ClientCheckedChanged);
            // 
            // mobjVisibleCheckBox
            // 
            this.mobjVisibleCheckBox.AutoSize = true;
            this.mobjVisibleCheckBox.Checked = true;
            this.mobjVisibleCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjVisibleCheckBox.Location = new System.Drawing.Point(50, 17);
            this.mobjVisibleCheckBox.Name = "mobjVisibleCheckBox";
            this.mobjVisibleCheckBox.Size = new System.Drawing.Size(53, 17);
            this.mobjVisibleCheckBox.TabIndex = 2;
            this.mobjVisibleCheckBox.Text = "Visibe";
            this.mobjVisibleCheckBox.ClientCheckedChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjVisibleCheckBox_ClientCheckedChanged);
            // 
            // mobjButton
            // 
            this.mobjButton.ClientId = "btn";
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(10, 0);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(119, 75);
            this.mobjButton.TabIndex = 3;
            this.mobjButton.Text = "Button";
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 15, 0, 15);
            this.mobjLabel.Size = new System.Drawing.Size(818, 70);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Check/uncheck to change appropriate property of Button:";
            // 
            // mobjLabelEnabled
            // 
            this.mobjLabelEnabled.ClientId = "lblEnabled";
            this.mobjLabelEnabled.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelEnabled.Location = new System.Drawing.Point(10, 0);
            this.mobjLabelEnabled.Name = "mobjLabelEnabled";
            this.mobjLabelEnabled.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 5);
            this.mobjLabelEnabled.Size = new System.Drawing.Size(679, 34);
            this.mobjLabelEnabled.TabIndex = 4;
            this.mobjLabelEnabled.Text = "Button is enabled";
            // 
            // mobjLabelVisible
            // 
            this.mobjLabelVisible.ClientId = "lblVisible";
            this.mobjLabelVisible.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelVisible.Location = new System.Drawing.Point(10, 34);
            this.mobjLabelVisible.Name = "mobjLabelVisible";
            this.mobjLabelVisible.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 5);
            this.mobjLabelVisible.Size = new System.Drawing.Size(679, 41);
            this.mobjLabelVisible.TabIndex = 5;
            this.mobjLabelVisible.Text = "Button is visible";
            // 
            // mobjPanel1
            // 
            this.mobjPanel1.Controls.Add(this.mobjEnabledCheckBox);
            this.mobjPanel1.Controls.Add(this.mobjVisibleCheckBox);
            this.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel1.Location = new System.Drawing.Point(0, 60);
            this.mobjPanel1.Name = "mobjPanel1";
            this.mobjPanel1.Size = new System.Drawing.Size(818, 85);
            this.mobjPanel1.TabIndex = 6;
            // 
            // mobjPanel2
            // 
            this.mobjPanel2.Controls.Add(this.mobjPanel4);
            this.mobjPanel2.Controls.Add(this.mobjPanel3);
            this.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel2.Location = new System.Drawing.Point(0, 145);
            this.mobjPanel2.Name = "mobjPanel2";
            this.mobjPanel2.Size = new System.Drawing.Size(818, 75);
            this.mobjPanel2.TabIndex = 7;
            // 
            // mobjPanel4
            // 
            this.mobjPanel4.Controls.Add(this.mobjLabelVisible);
            this.mobjPanel4.Controls.Add(this.mobjLabelEnabled);
            this.mobjPanel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel4.DockPadding.Left = 10;
            this.mobjPanel4.Location = new System.Drawing.Point(129, 0);
            this.mobjPanel4.Name = "mobjPanel4";
            this.mobjPanel4.Padding = new Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0);
            this.mobjPanel4.Size = new System.Drawing.Size(689, 75);
            this.mobjPanel4.TabIndex = 1;
            // 
            // mobjPanel3
            // 
            this.mobjPanel3.Controls.Add(this.mobjButton);
            this.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPanel3.DockPadding.Left = 10;
            this.mobjPanel3.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel3.Name = "mobjPanel3";
            this.mobjPanel3.Padding = new Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0);
            this.mobjPanel3.Size = new System.Drawing.Size(129, 75);
            this.mobjPanel3.TabIndex = 0;
            // 
            // EnabledVisiblePage
            // 
            this.Controls.Add(this.mobjPanel2);
            this.Controls.Add(this.mobjPanel1);
            this.Controls.Add(this.mobjLabel);
            this.Size = new System.Drawing.Size(818, 361);
            this.Text = "EnabledVisiblePage";
            this.mobjPanel1.ResumeLayout(false);
            this.mobjPanel2.ResumeLayout(false);
            this.mobjPanel4.ResumeLayout(false);
            this.mobjPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjEnabledCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjVisibleCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Label mobjLabelEnabled;
        private Gizmox.WebGUI.Forms.Label mobjLabelVisible;
        private Gizmox.WebGUI.Forms.Panel mobjPanel1;
        private Gizmox.WebGUI.Forms.Panel mobjPanel2;
        private Gizmox.WebGUI.Forms.Panel mobjPanel4;
        private Gizmox.WebGUI.Forms.Panel mobjPanel3;



    }
}