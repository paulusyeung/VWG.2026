namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    partial class InitialDirectoryPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialDirectoryPage));
            this.mobjInitialDirectoryLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjInitialDirectoryTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjInitialDirectoryFolderBrowserDialog = new Gizmox.WebGUI.Forms.FolderBrowserDialog();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjInitialDirectoryButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInitialDirectoryLabel
            // 
            this.mobjInitialDirectoryLabel.AutoSize = true;
            this.mobjInitialDirectoryLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInitialDirectoryLabel.Location = new System.Drawing.Point(75, 39);
            this.mobjInitialDirectoryLabel.Name = "mobjInitialDirectoryLabel";
            this.mobjInitialDirectoryLabel.Size = new System.Drawing.Size(201, 50);
            this.mobjInitialDirectoryLabel.TabIndex = 0;
            this.mobjInitialDirectoryLabel.Text = "Initial directory";
            // 
            // mobjInitialDirectoryTextBox
            // 
            this.mobjInitialDirectoryTextBox.AllowDrag = false;
            this.mobjInitialDirectoryTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInitialDirectoryTextBox.Location = new System.Drawing.Point(279, 42);
            this.mobjInitialDirectoryTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjInitialDirectoryTextBox.Name = "mobjInitialDirectoryTextBox";
            this.mobjInitialDirectoryTextBox.Size = new System.Drawing.Size(145, 30);
            this.mobjInitialDirectoryTextBox.TabIndex = 1;
            // 
            // mobjInitialDirectoryFolderBrowserDialog
            // 
            this.mobjInitialDirectoryFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            this.mobjInitialDirectoryFolderBrowserDialog.Closed += new System.EventHandler(this.mobjInitialDirectoryFolderBrowserDialog_Closed);
            // 
            // mobjInitialDirectoryButton
            // 
            this.mobjInitialDirectoryButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInitialDirectoryButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjInitialDirectoryButton.Image"));
            this.mobjInitialDirectoryButton.Location = new System.Drawing.Point(437, 39);
            this.mobjInitialDirectoryButton.MaximumSize = new System.Drawing.Size(30, 30);
            this.mobjInitialDirectoryButton.Name = "mobjInitialDirectoryButton";
            this.mobjInitialDirectoryButton.Size = new System.Drawing.Size(30, 30);
            this.mobjInitialDirectoryButton.TabIndex = 2;
            this.mobjInitialDirectoryButton.UseVisualStyleBackColor = true;
            this.mobjInitialDirectoryButton.Click += new System.EventHandler(this.mobjInitialDirectoryButton_Click);
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjOpenFileDialogButton, 4);
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(75, 109);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(392, 50);
            this.mobjOpenFileDialogButton.TabIndex = 3;
            this.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with specified initial directory";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 6;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjInitialDirectoryButton, 4, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjInitialDirectoryTextBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjInitialDirectoryLabel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(544, 199);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // InitialDirectoryPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(544, 199);
            this.Text = "InitialDirectoryPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInitialDirectoryLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjInitialDirectoryTextBox;
        private Gizmox.WebGUI.Forms.FolderBrowserDialog mobjInitialDirectoryFolderBrowserDialog;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.Button mobjInitialDirectoryButton;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
