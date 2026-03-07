namespace CompanionKit.Controls.FolderBrowserDialog.Features
{
    partial class ShowNewFolderButtonPropertyPage
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
            this.mobjPathTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjBrowseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjShowNewFolderButtonCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjFolderBrowserDialog = new Gizmox.WebGUI.Forms.FolderBrowserDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjCheckBoxPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjCheckBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPathTextBox
            // 
            this.mobjPathTextBox.AllowDrag = false;
            this.mobjPathTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPathTextBox.Location = new System.Drawing.Point(0, 20);
            this.mobjPathTextBox.Name = "mobjPathTextBox";
            this.mobjPathTextBox.Size = new System.Drawing.Size(241, 30);
            this.mobjPathTextBox.TabIndex = 2;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(77, 13);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "Selected path:";
            // 
            // mobjBrowseButton
            // 
            this.mobjBrowseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBrowseButton.Location = new System.Drawing.Point(341, 21);
            this.mobjBrowseButton.Name = "mobjBrowseButton";
            this.mobjBrowseButton.Size = new System.Drawing.Size(134, 50);
            this.mobjBrowseButton.TabIndex = 0;
            this.mobjBrowseButton.Text = "Browse";
            this.mobjBrowseButton.Click += new System.EventHandler(this.mobjBrowseButton_Click);
            // 
            // mobjShowNewFolderButtonCheckBox
            // 
            this.mobjShowNewFolderButtonCheckBox.AutoSize = true;
            this.mobjShowNewFolderButtonCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowNewFolderButtonCheckBox.Location = new System.Drawing.Point(0, 0);
            this.mobjShowNewFolderButtonCheckBox.Name = "mobjShowNewFolderButtonCheckBox";
            this.mobjShowNewFolderButtonCheckBox.Size = new System.Drawing.Size(395, 40);
            this.mobjShowNewFolderButtonCheckBox.TabIndex = 3;
            this.mobjShowNewFolderButtonCheckBox.Text = "Show New Folder Button";
            this.mobjShowNewFolderButtonCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjBrowseButton, 3, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBoxPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(557, 153);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjDescriptionLabel);
            this.mobjPanel.Controls.Add(this.mobjPathTextBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(80, 21);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(241, 50);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjCheckBoxPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjCheckBoxPanel, 3);
            this.mobjCheckBoxPanel.Controls.Add(this.mobjShowNewFolderButtonCheckBox);
            this.mobjCheckBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckBoxPanel.Location = new System.Drawing.Point(80, 91);
            this.mobjCheckBoxPanel.Name = "mobjCheckBoxPanel";
            this.mobjCheckBoxPanel.Size = new System.Drawing.Size(395, 40);
            this.mobjCheckBoxPanel.TabIndex = 0;
            // 
            // ShowNewFolderButtonPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(557, 153);
            this.Text = "ShowNewFolderButtonPropertyPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjCheckBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox mobjPathTextBox;
        private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.Button mobjBrowseButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjShowNewFolderButtonCheckBox;
        private Gizmox.WebGUI.Forms.FolderBrowserDialog mobjFolderBrowserDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjCheckBoxPanel;



    }
}