namespace CompanionKit.Controls.FolderBrowserDialog.Features
{
    partial class SelectedPathPropertyPage
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
            this.mobjFolderBrowserDialog = new Gizmox.WebGUI.Forms.FolderBrowserDialog();
            this.mobjBrowseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPathTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSelectedDirectoryLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPathPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjPathPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjBrowseButton
            // 
            this.mobjBrowseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBrowseButton.Location = new System.Drawing.Point(421, 47);
            this.mobjBrowseButton.Name = "mobjBrowseButton";
            this.mobjBrowseButton.Size = new System.Drawing.Size(167, 50);
            this.mobjBrowseButton.TabIndex = 0;
            this.mobjBrowseButton.Text = "Browse";
            this.mobjBrowseButton.Click += new System.EventHandler(this.mobjBrowseButton_Click);
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(131, 13);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "Write your own path here";
            // 
            // mobjPathTextBox
            // 
            this.mobjPathTextBox.AllowDrag = false;
            this.mobjPathTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPathTextBox.Location = new System.Drawing.Point(0, 20);
            this.mobjPathTextBox.Name = "mobjPathTextBox";
            this.mobjPathTextBox.Size = new System.Drawing.Size(301, 30);
            this.mobjPathTextBox.TabIndex = 2;
            this.mobjPathTextBox.Text = "C:\\Users\\";
            // 
            // mobjSelectedDirectoryLabel
            // 
            this.mobjSelectedDirectoryLabel.AutoSize = true;
            this.mobjSelectedDirectoryLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedDirectoryLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjSelectedDirectoryLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSelectedDirectoryLabel.Name = "lblSelectedDirectory";
            this.mobjSelectedDirectoryLabel.Size = new System.Drawing.Size(0, 13);
            this.mobjSelectedDirectoryLabel.TabIndex = 3;
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
            this.mobjLayoutPanel.Controls.Add(this.mobjPathPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(691, 205);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjPathTextBox);
            this.mobjPanel.Controls.Add(this.mobjDescriptionLabel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(100, 47);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(301, 50);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjPathPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPathPanel, 3);
            this.mobjPathPanel.Controls.Add(this.mobjSelectedDirectoryLabel);
            this.mobjPathPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPathPanel.Location = new System.Drawing.Point(100, 117);
            this.mobjPathPanel.Name = "mobjPathPanel";
            this.mobjPathPanel.Size = new System.Drawing.Size(488, 40);
            this.mobjPathPanel.TabIndex = 0;
            // 
            // SelectedPathPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(691, 205);
            this.Text = "SelectedPathPropertyPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjPathPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.FolderBrowserDialog mobjFolderBrowserDialog;
        private Gizmox.WebGUI.Forms.Button mobjBrowseButton;
        private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjPathTextBox;
        private Gizmox.WebGUI.Forms.Label mobjSelectedDirectoryLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPathPanel;



    }
}