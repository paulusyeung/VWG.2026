namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    partial class CheckFileExistsPage
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
            this.mobjAllowCheckFileExistsCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjAllowCheckFileExistsCheckBox
            // 
            this.mobjAllowCheckFileExistsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjAllowCheckFileExistsCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowCheckFileExistsCheckBox.Location = new System.Drawing.Point(90, 33);
            this.mobjAllowCheckFileExistsCheckBox.Name = "mobjAllowCheckFileExistsCheckBox";
            this.mobjAllowCheckFileExistsCheckBox.Size = new System.Drawing.Size(420, 70);
            this.mobjAllowCheckFileExistsCheckBox.TabIndex = 1;
            this.mobjAllowCheckFileExistsCheckBox.Text = "Enable CheckFileExists for OpenFileDialog";
            this.mobjAllowCheckFileExistsCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(90, 123);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(420, 50);
            this.mobjOpenFileDialogButton.TabIndex = 3;
            this.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with enable/disable CheckFileExists property";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowCheckFileExistsCheckBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(600, 207);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // CheckFileExistsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(600, 207);
            this.Text = "CheckFileExistsPage";
            this.Load += new System.EventHandler(this.CheckFileExistsPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.CheckBox mobjAllowCheckFileExistsCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
