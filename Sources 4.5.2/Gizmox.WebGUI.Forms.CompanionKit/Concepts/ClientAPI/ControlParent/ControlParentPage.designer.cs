namespace CompanionKit.Concepts.ClientAPI.ControlParent
{
    partial class ControlParentPage
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
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel3 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjShowParentButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabelInfo = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel.SuspendLayout();
            this.mobjPanel1.SuspendLayout();
            this.mobjPanel2.SuspendLayout();
            this.mobjPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjPanel1);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel.DockPadding.All = 15;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjPanel.Size = new System.Drawing.Size(457, 204);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjPanel1
            // 
            this.mobjPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel1.ClientId = "p1";
            this.mobjPanel1.Controls.Add(this.mobjLabel1);
            this.mobjPanel1.Controls.Add(this.mobjPanel2);
            this.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel1.DockPadding.All = 30;
            this.mobjPanel1.Location = new System.Drawing.Point(15, 15);
            this.mobjPanel1.Name = "mobjPanel1";
            this.mobjPanel1.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.mobjPanel1.Size = new System.Drawing.Size(427, 174);
            this.mobjPanel1.TabIndex = 0;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.AutoSize = true;
            this.mobjLabel1.ClientId = "l1";
            this.mobjLabel1.Location = new System.Drawing.Point(0, -1);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel1.TabIndex = 1;
            this.mobjLabel1.Text = "label1";
            // 
            // mobjPanel2
            // 
            this.mobjPanel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel2.ClientId = "p2";
            this.mobjPanel2.Controls.Add(this.mobjLabel2);
            this.mobjPanel2.Controls.Add(this.mobjPanel3);
            this.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel2.DockPadding.All = 30;
            this.mobjPanel2.Location = new System.Drawing.Point(30, 30);
            this.mobjPanel2.Name = "mobjPanel2";
            this.mobjPanel2.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.mobjPanel2.Size = new System.Drawing.Size(365, 112);
            this.mobjPanel2.TabIndex = 0;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.AutoSize = true;
            this.mobjLabel2.ClientId = "l2";
            this.mobjLabel2.Location = new System.Drawing.Point(-1, -1);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel2.TabIndex = 1;
            this.mobjLabel2.Text = "label2";
            // 
            // mobjPanel3
            // 
            this.mobjPanel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel3.ClientId = "p3";
            this.mobjPanel3.Controls.Add(this.mobjLabel3);
            this.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel3.Location = new System.Drawing.Point(30, 30);
            this.mobjPanel3.Name = "mobjPanel3";
            this.mobjPanel3.Size = new System.Drawing.Size(303, 50);
            this.mobjPanel3.TabIndex = 0;
            // 
            // mobjLabel3
            // 
            this.mobjLabel3.AutoSize = true;
            this.mobjLabel3.ClientId = "l3";
            this.mobjLabel3.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel3.Name = "mobjLabel3";
            this.mobjLabel3.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel3.TabIndex = 0;
            this.mobjLabel3.Text = "label3";
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.ClientId = "cb";
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "label1",
            "label2",
            "label3"});
            this.mobjComboBox.Location = new System.Drawing.Point(16, 245);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(131, 21);
            this.mobjComboBox.TabIndex = 1;
            this.mobjComboBox.Text = "-";
            // 
            // mobjShowParentButton
            // 
            this.mobjShowParentButton.Location = new System.Drawing.Point(16, 283);
            this.mobjShowParentButton.Name = "mobjShowParentButton";
            this.mobjShowParentButton.Size = new System.Drawing.Size(131, 23);
            this.mobjShowParentButton.TabIndex = 2;
            this.mobjShowParentButton.Text = "Show parent";
            this.mobjShowParentButton.Click += new System.EventHandler(this.mobjShowParentButton_Click);
            // 
            // mobjLabelInfo
            // 
            this.mobjLabelInfo.AutoSize = true;
            this.mobjLabelInfo.Location = new System.Drawing.Point(16, 218);
            this.mobjLabelInfo.Name = "mobjLabelInfo";
            this.mobjLabelInfo.Size = new System.Drawing.Size(35, 13);
            this.mobjLabelInfo.TabIndex = 3;
            this.mobjLabelInfo.Text = "Select label and click button:";
            // 
            // ControlParentPage
            // 
            this.ClientId = "uc";
            this.Controls.Add(this.mobjLabelInfo);
            this.Controls.Add(this.mobjShowParentButton);
            this.Controls.Add(this.mobjComboBox);
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(457, 420);
            this.Text = "ControlParentPage";
            this.mobjPanel.ResumeLayout(false);
            this.mobjPanel1.ResumeLayout(false);
            this.mobjPanel2.ResumeLayout(false);
            this.mobjPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel1;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.Panel mobjPanel2;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.Panel mobjPanel3;
        private Gizmox.WebGUI.Forms.Label mobjLabel3;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Button mobjShowParentButton;
        private Gizmox.WebGUI.Forms.Label mobjLabelInfo;



    }
}