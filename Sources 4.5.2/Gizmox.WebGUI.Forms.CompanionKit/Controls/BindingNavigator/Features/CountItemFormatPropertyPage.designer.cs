namespace CompanionKit.Controls.BindingNavigator.Features
{
    partial class CountItemFormatPropertyPage
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
            this.components = new System.ComponentModel.Container();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBindingNavigator = new Gizmox.WebGUI.Forms.BindingNavigator(this.components);
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjSuffixTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPrefixLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCenterTextTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjCenterLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPrefixTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSuffixLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjButton);
            this.mobjPanel.Controls.Add(this.mobjBindingNavigator);
            this.mobjPanel.Controls.Add(this.mobjSuffixTextBox);
            this.mobjPanel.Controls.Add(this.mobjPrefixLabel);
            this.mobjPanel.Controls.Add(this.mobjCenterTextTextBox);
            this.mobjPanel.Controls.Add(this.mobjCenterLabel);
            this.mobjPanel.Controls.Add(this.mobjPrefixTextBox);
            this.mobjPanel.Controls.Add(this.mobjSuffixLabel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(500, 286);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjButton
            // 
            this.mobjButton.Location = new System.Drawing.Point(11, 220);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(150, 50);
            this.mobjButton.TabIndex = 7;
            this.mobjButton.Text = "Set";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjBindingNavigator
            // 
            this.mobjBindingNavigator.BindingSource = this.mobjBindingSource;
            this.mobjBindingNavigator.DragHandle = true;
            this.mobjBindingNavigator.DropDownArrows = true;
            this.mobjBindingNavigator.ImageSize = new System.Drawing.Size(16, 16);
            this.mobjBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.mobjBindingNavigator.MenuHandle = true;
            this.mobjBindingNavigator.Name = "mobjBindingNavigator";
            this.mobjBindingNavigator.ShowToolTips = true;
            this.mobjBindingNavigator.Size = new System.Drawing.Size(500, 28);
            this.mobjBindingNavigator.TabIndex = 0;
            this.mobjBindingNavigator.AddStandardItems();
            // 
            // mobjSuffixTextBox
            // 
            this.mobjSuffixTextBox.AllowDrag = false;
            this.mobjSuffixTextBox.Location = new System.Drawing.Point(11, 172);
            this.mobjSuffixTextBox.Name = "mobjSuffixTextBox";
            this.mobjSuffixTextBox.Size = new System.Drawing.Size(150, 30);
            this.mobjSuffixTextBox.TabIndex = 6;
            this.mobjSuffixTextBox.Text = "Pages";
            // 
            // mobjPrefixLabel
            // 
            this.mobjPrefixLabel.AutoSize = true;
            this.mobjPrefixLabel.Location = new System.Drawing.Point(11, 36);
            this.mobjPrefixLabel.Name = "mobjPrefixLabel";
            this.mobjPrefixLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjPrefixLabel.TabIndex = 1;
            this.mobjPrefixLabel.Text = "Prefix";
            // 
            // mobjCenterTextTextBox
            // 
            this.mobjCenterTextTextBox.AllowDrag = false;
            this.mobjCenterTextTextBox.Location = new System.Drawing.Point(11, 114);
            this.mobjCenterTextTextBox.Name = "mobjCenterTextTextBox";
            this.mobjCenterTextTextBox.Size = new System.Drawing.Size(150, 30);
            this.mobjCenterTextTextBox.TabIndex = 5;
            this.mobjCenterTextTextBox.Text = "of";
            // 
            // mobjCenterLabel
            // 
            this.mobjCenterLabel.AutoSize = true;
            this.mobjCenterLabel.Location = new System.Drawing.Point(11, 94);
            this.mobjCenterLabel.Name = "mobjCenterLabel";
            this.mobjCenterLabel.Size = new System.Drawing.Size(63, 13);
            this.mobjCenterLabel.TabIndex = 2;
            this.mobjCenterLabel.Text = "Center text";
            // 
            // mobjPrefixTextBox
            // 
            this.mobjPrefixTextBox.AllowDrag = false;
            this.mobjPrefixTextBox.Location = new System.Drawing.Point(11, 56);
            this.mobjPrefixTextBox.Name = "mobjPrefixTextBox";
            this.mobjPrefixTextBox.Size = new System.Drawing.Size(150, 30);
            this.mobjPrefixTextBox.TabIndex = 4;
            this.mobjPrefixTextBox.Text = "Page";
            // 
            // mobjSuffixLabel
            // 
            this.mobjSuffixLabel.AutoSize = true;
            this.mobjSuffixLabel.Location = new System.Drawing.Point(11, 152);
            this.mobjSuffixLabel.Name = "mobjSuffixLabel";
            this.mobjSuffixLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjSuffixLabel.TabIndex = 3;
            this.mobjSuffixLabel.Text = "Suffix";
            // 
            // CountItemFormatPropertyPage
            // 
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(500, 286);
            this.Text = "CountItemFormatPropertyPage";
            this.Load += new System.EventHandler(this.CountItemFormatPropertyPage_Load);
            this.mobjPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.BindingNavigator mobjBindingNavigator;
        private Gizmox.WebGUI.Forms.Label mobjPrefixLabel;
        private Gizmox.WebGUI.Forms.Label mobjCenterLabel;
        private Gizmox.WebGUI.Forms.Label mobjSuffixLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjPrefixTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjCenterTextTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjSuffixTextBox;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.BindingSource mobjBindingSource;



    }
}