namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    partial class FileNamePage
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
            this.mobjSelectedFileNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectedFileTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjOrigFileNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOrigFileNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.Closed += new System.EventHandler(this.mobjDemoOpenFileDialog_Closed);
            // 
            // mobjSelectedFileNameLabel
            // 
            this.mobjSelectedFileNameLabel.AutoSize = true;
            this.mobjSelectedFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSelectedFileNameLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSelectedFileNameLabel.Name = "mobjSelectedFileNameLabel";
            this.mobjSelectedFileNameLabel.Size = new System.Drawing.Size(109, 13);
            this.mobjSelectedFileNameLabel.TabIndex = 0;
            this.mobjSelectedFileNameLabel.Text = "Temporary file name:";
            // 
            // mobjSelectedFileTextBox
            // 
            this.mobjSelectedFileTextBox.AllowDrag = false;
            this.mobjSelectedFileTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSelectedFileTextBox.Location = new System.Drawing.Point(0, 40);
            this.mobjSelectedFileTextBox.Name = "mobjSelectedFileTextBox";
            this.mobjSelectedFileTextBox.ReadOnly = true;
            this.mobjSelectedFileTextBox.Size = new System.Drawing.Size(443, 30);
            this.mobjSelectedFileTextBox.TabIndex = 1;
            this.mobjSelectedFileTextBox.Text = "You haven\'t selected file.";
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(95, 181);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(443, 50);
            this.mobjOpenFileDialogButton.TabIndex = 2;
            this.mobjOpenFileDialogButton.Text = "Open selection file dialog";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjOrigFileNameLabel
            // 
            this.mobjOrigFileNameLabel.AutoSize = true;
            this.mobjOrigFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjOrigFileNameLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjOrigFileNameLabel.Name = "mobjOrigFileNameLabel";
            this.mobjOrigFileNameLabel.Size = new System.Drawing.Size(136, 13);
            this.mobjOrigFileNameLabel.TabIndex = 3;
            this.mobjOrigFileNameLabel.Text = "Original selected file name:";
            // 
            // mobjOrigFileNameTextBox
            // 
            this.mobjOrigFileNameTextBox.AllowDrag = false;
            this.mobjOrigFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjOrigFileNameTextBox.Location = new System.Drawing.Point(0, 40);
            this.mobjOrigFileNameTextBox.Name = "mobjOrigFileNameTextBox";
            this.mobjOrigFileNameTextBox.Size = new System.Drawing.Size(443, 30);
            this.mobjOrigFileNameTextBox.TabIndex = 4;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(634, 253);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjSelectedFileNameLabel);
            this.mobjTopPanel.Controls.Add(this.mobjSelectedFileTextBox);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(95, 21);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(443, 60);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjOrigFileNameLabel);
            this.mobjBottomPanel.Controls.Add(this.mobjOrigFileNameTextBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(95, 101);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(443, 60);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // FileNamePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(634, 253);
            this.Text = "FileNamePage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.Label mobjSelectedFileNameLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjSelectedFileTextBox;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.Label mobjOrigFileNameLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjOrigFileNameTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;



    }
}
