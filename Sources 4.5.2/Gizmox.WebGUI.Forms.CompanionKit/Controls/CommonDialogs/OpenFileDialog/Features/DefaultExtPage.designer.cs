namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    partial class DefaultExtPage
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
            this.mobjDefaultExtLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDefaultExtTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDefaultExtLabel
            // 
            this.mobjDefaultExtLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDefaultExtLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDefaultExtLabel.Name = "mobjDefaultExtLabel";
            this.mobjDefaultExtLabel.Size = new System.Drawing.Size(261, 50);
            this.mobjDefaultExtLabel.TabIndex = 0;
            this.mobjDefaultExtLabel.Text = "Default extension";
            // 
            // mobjDefaultExtTextBox
            // 
            this.mobjDefaultExtTextBox.AllowDrag = false;
            this.mobjDefaultExtTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjDefaultExtTextBox.Location = new System.Drawing.Point(261, 0);
            this.mobjDefaultExtTextBox.MaximumSize = new System.Drawing.Size(0, 30);
            this.mobjDefaultExtTextBox.Name = "mobjDefaultExtTextBox";
            this.mobjDefaultExtTextBox.Size = new System.Drawing.Size(119, 30);
            this.mobjDefaultExtTextBox.TabIndex = 1;
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(81, 95);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(380, 50);
            this.mobjOpenFileDialogButton.TabIndex = 2;
            this.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with specified DefaultExt";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(543, 171);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjDefaultExtLabel);
            this.mobjPanel.Controls.Add(this.mobjDefaultExtTextBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(81, 25);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(380, 50);
            this.mobjPanel.TabIndex = 0;
            // 
            // DefaultExtPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(543, 171);
            this.Text = "DefaultExtPage";
            this.Load += new System.EventHandler(this.DefaultExtPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDefaultExtLabel;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        public Gizmox.WebGUI.Forms.TextBox mobjDefaultExtTextBox;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
