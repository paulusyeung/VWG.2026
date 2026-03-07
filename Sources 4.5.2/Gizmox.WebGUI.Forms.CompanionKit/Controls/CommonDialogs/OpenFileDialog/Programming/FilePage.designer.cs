namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    partial class FilePage
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
            this.mobjFileNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjFileNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjFileSizeTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjFileSizeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOrigFileNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOrigFileNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjFileNameLabel
            // 
            this.mobjFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileNameLabel.Location = new System.Drawing.Point(93, 83);
            this.mobjFileNameLabel.Name = "mobjFileNameLabel";
            this.mobjFileNameLabel.Size = new System.Drawing.Size(248, 50);
            this.mobjFileNameLabel.TabIndex = 0;
            this.mobjFileNameLabel.Text = "Selected file name";
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjOpenFileDialogButton, 2);
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(93, 213);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(434, 50);
            this.mobjOpenFileDialogButton.TabIndex = 1;
            this.mobjOpenFileDialogButton.Text = "Open selection file dialog";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.mobjDemoOpenFileDialog_FileOk);
            // 
            // mobjFileNameTextBox
            // 
            this.mobjFileNameTextBox.AllowDrag = false;
            this.mobjFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileNameTextBox.Location = new System.Drawing.Point(344, 86);
            this.mobjFileNameTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjFileNameTextBox.Name = "mobjFileNameTextBox";
            this.mobjFileNameTextBox.ReadOnly = true;
            this.mobjFileNameTextBox.Size = new System.Drawing.Size(180, 30);
            this.mobjFileNameTextBox.TabIndex = 2;
            // 
            // mobjFileSizeTextBox
            // 
            this.mobjFileSizeTextBox.AllowDrag = false;
            this.mobjFileSizeTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileSizeTextBox.Location = new System.Drawing.Point(344, 146);
            this.mobjFileSizeTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjFileSizeTextBox.Name = "mobjFileSizeTextBox";
            this.mobjFileSizeTextBox.ReadOnly = true;
            this.mobjFileSizeTextBox.Size = new System.Drawing.Size(180, 30);
            this.mobjFileSizeTextBox.TabIndex = 4;
            // 
            // mobjFileSizeLabel
            // 
            this.mobjFileSizeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileSizeLabel.Location = new System.Drawing.Point(93, 143);
            this.mobjFileSizeLabel.Name = "mobjFileSizeLabel";
            this.mobjFileSizeLabel.Size = new System.Drawing.Size(248, 50);
            this.mobjFileSizeLabel.TabIndex = 6;
            this.mobjFileSizeLabel.Text = "Selected file size";
            // 
            // mobjOrigFileNameLabel
            // 
            this.mobjOrigFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOrigFileNameLabel.Location = new System.Drawing.Point(93, 23);
            this.mobjOrigFileNameLabel.Name = "mobjOrigFileNameLabel";
            this.mobjOrigFileNameLabel.Size = new System.Drawing.Size(248, 50);
            this.mobjOrigFileNameLabel.TabIndex = 7;
            this.mobjOrigFileNameLabel.Text = "Original file name";
            // 
            // mobjOrigFileNameTextBox
            // 
            this.mobjOrigFileNameTextBox.AllowDrag = false;
            this.mobjOrigFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOrigFileNameTextBox.Location = new System.Drawing.Point(344, 26);
            this.mobjOrigFileNameTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjOrigFileNameTextBox.Name = "mobjOrigFileNameTextBox";
            this.mobjOrigFileNameTextBox.Size = new System.Drawing.Size(180, 30);
            this.mobjOrigFileNameTextBox.TabIndex = 8;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjOrigFileNameTextBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileSizeLabel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjOrigFileNameLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileSizeTextBox, 2, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileNameLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileNameTextBox, 2, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 9;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(622, 287);
            this.mobjLayoutPanel.TabIndex = 9;
            // 
            // FilePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Location = new System.Drawing.Point(0, -63);
            this.Size = new System.Drawing.Size(622, 287);
            this.Text = "FilePage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjFileNameLabel;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.TextBox mobjFileNameTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjFileSizeTextBox;
        private Gizmox.WebGUI.Forms.Label mobjFileSizeLabel;
        private Gizmox.WebGUI.Forms.Label mobjOrigFileNameLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjOrigFileNameTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
