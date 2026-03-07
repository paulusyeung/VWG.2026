namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    partial class FileOkPage
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
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFileNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFileNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjFileSizeTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjFileSizeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.mobjDemoOpenFileDialog_FileOk);
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjOpenFileDialogButton, 2);
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(106, 161);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(494, 80);
            this.mobjOpenFileDialogButton.TabIndex = 0;
            this.mobjOpenFileDialogButton.Text = "Open selection file dialog with Visual WebGui Upload Dialog";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjFileNameLabel
            // 
            this.mobjFileNameLabel.AllowDrop = true;
            this.mobjFileNameLabel.AutoSize = true;
            this.mobjFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileNameLabel.Location = new System.Drawing.Point(106, 21);
            this.mobjFileNameLabel.Name = "mobjFileNameLabel";
            this.mobjFileNameLabel.Size = new System.Drawing.Size(282, 50);
            this.mobjFileNameLabel.TabIndex = 1;
            this.mobjFileNameLabel.Text = "Selected file name";
            // 
            // mobjFileNameTextBox
            // 
            this.mobjFileNameTextBox.AllowDrag = false;
            this.mobjFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFileNameTextBox.Location = new System.Drawing.Point(391, 24);
            this.mobjFileNameTextBox.Name = "mobjFileNameTextBox";
            this.mobjFileNameTextBox.ReadOnly = true;
            this.mobjFileNameTextBox.Size = new System.Drawing.Size(206, 30);
            this.mobjFileNameTextBox.TabIndex = 2;
            // 
            // mobjFileSizeTextBox
            // 
            this.mobjFileSizeTextBox.AllowDrag = false;
            this.mobjFileSizeTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFileSizeTextBox.Location = new System.Drawing.Point(391, 94);
            this.mobjFileSizeTextBox.Name = "mobjFileSizeTextBox";
            this.mobjFileSizeTextBox.ReadOnly = true;
            this.mobjFileSizeTextBox.Size = new System.Drawing.Size(206, 30);
            this.mobjFileSizeTextBox.TabIndex = 4;
            // 
            // mobjFileSizeLabel
            // 
            this.mobjFileSizeLabel.AutoSize = true;
            this.mobjFileSizeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileSizeLabel.Location = new System.Drawing.Point(106, 91);
            this.mobjFileSizeLabel.Name = "mobjFileSizeLabel";
            this.mobjFileSizeLabel.Size = new System.Drawing.Size(282, 50);
            this.mobjFileSizeLabel.TabIndex = 6;
            this.mobjFileSizeLabel.Text = "Selected file size";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjFileNameTextBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileSizeLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileNameLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjFileSizeTextBox, 2, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(707, 262);
            this.mobjLayoutPanel.TabIndex = 7;
            // 
            // FileOkPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(707, 262);
            this.Text = "FileOkPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.Label mobjFileNameLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjFileNameTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjFileSizeTextBox;
        private Gizmox.WebGUI.Forms.Label mobjFileSizeLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
