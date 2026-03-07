namespace CompanionKit.Concepts.PopupArrowScrolling
{
    partial class ScrollArrowsPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjDefaultRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjArrowsRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(419, 50);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Chose ScrollerType value for panel:";
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.AutoScroll = true;
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.Controls.Add(this.mobjTextBox);
            this.mobjPanel.Controls.Add(this.mobjLabel);
            this.mobjPanel.Controls.Add(this.mobjButton);
            this.mobjPanel.Location = new System.Drawing.Point(15, 50);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(213, 160);
            this.mobjPanel.TabIndex = 1;
            // 
            // mobjDefaultRB
            // 
            this.mobjDefaultRB.AccessibleDescription = "";
            this.mobjDefaultRB.AccessibleName = "";
            this.mobjDefaultRB.Checked = true;
            this.mobjDefaultRB.Location = new System.Drawing.Point(15, 234);
            this.mobjDefaultRB.Name = "mobjDefaultRB";
            this.mobjDefaultRB.Size = new System.Drawing.Size(190, 40);
            this.mobjDefaultRB.TabIndex = 2;
            this.mobjDefaultRB.Text = "Default";
            // 
            // mobjArrowsRB
            // 
            this.mobjArrowsRB.AccessibleDescription = "";
            this.mobjArrowsRB.AccessibleName = "";
            this.mobjArrowsRB.Location = new System.Drawing.Point(15, 284);
            this.mobjArrowsRB.Name = "mobjArrowsRB";
            this.mobjArrowsRB.Size = new System.Drawing.Size(190, 40);
            this.mobjArrowsRB.TabIndex = 3;
            this.mobjArrowsRB.Text = "Arrows";
            this.mobjArrowsRB.CheckedChanged += new System.EventHandler(this.mobjArrowsRB_CheckedChanged);
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Location = new System.Drawing.Point(15, 24);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(156, 29);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Button";
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.BackColor = System.Drawing.Color.PapayaWhip;
            this.mobjLabel.Location = new System.Drawing.Point(15, 68);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(156, 49);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Test Label";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AccessibleDescription = "";
            this.mobjTextBox.AccessibleName = "";
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Location = new System.Drawing.Point(18, 132);
            this.mobjTextBox.Multiline = true;
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(153, 141);
            this.mobjTextBox.TabIndex = 2;
            this.mobjTextBox.Text = "Text Box...";
            // 
            // ScrollArrowsPage
            // 
            this.Controls.Add(this.mobjArrowsRB);
            this.Controls.Add(this.mobjDefaultRB);
            this.Controls.Add(this.mobjPanel);
            this.Controls.Add(this.mobjInfoLabel);
            this.Size = new System.Drawing.Size(391, 380);
            this.Text = "ScrollArrowsPage";
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.RadioButton mobjDefaultRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjArrowsRB;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Button mobjButton;

    }
}