namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    partial class TitlePage
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
            this.mobjTitleFileDialogLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTitleFileDialogTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.Title = "Open File Dialog";
            // 
            // mobjTitleFileDialogLabel
            // 
            this.mobjTitleFileDialogLabel.AutoSize = true;
            this.mobjTitleFileDialogLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTitleFileDialogLabel.Location = new System.Drawing.Point(88, 32);
            this.mobjTitleFileDialogLabel.Name = "mobjTitleFileDialogLabel";
            this.mobjTitleFileDialogLabel.Size = new System.Drawing.Size(237, 50);
            this.mobjTitleFileDialogLabel.TabIndex = 0;
            this.mobjTitleFileDialogLabel.Text = "Title of the open file dialog";
            // 
            // mobjTitleFileDialogTextBox
            // 
            this.mobjTitleFileDialogTextBox.AllowDrag = false;
            this.mobjTitleFileDialogTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTitleFileDialogTextBox.Location = new System.Drawing.Point(328, 35);
            this.mobjTitleFileDialogTextBox.Name = "mobjTitleFileDialogTextBox";
            this.mobjTitleFileDialogTextBox.Size = new System.Drawing.Size(171, 30);
            this.mobjTitleFileDialogTextBox.TabIndex = 1;
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjOpenFileDialogButton, 2);
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(88, 102);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(414, 50);
            this.mobjOpenFileDialogButton.TabIndex = 2;
            this.mobjOpenFileDialogButton.Text = "Open file dialog with custom title";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjTitleFileDialogLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTitleFileDialogTextBox, 2, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(593, 185);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // TitlePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(593, 185);
            this.Text = "TitlePage";
            this.Load += new System.EventHandler(this.TitlePage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.Label mobjTitleFileDialogLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTitleFileDialogTextBox;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
