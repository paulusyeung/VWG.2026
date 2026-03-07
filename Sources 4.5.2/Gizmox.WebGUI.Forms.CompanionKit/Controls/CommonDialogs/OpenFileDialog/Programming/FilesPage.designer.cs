namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    partial class FilesPage
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
            this.mobjSelectedFilesListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjFileNameColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjFileSizeColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjSelectedFilesLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjSelectedFilesListView
            // 
            this.mobjSelectedFilesListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent;
            this.mobjSelectedFilesListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjFileNameColumn,
            this.mobjFileSizeColumn});
            this.mobjSelectedFilesListView.DataMember = null;
            this.mobjSelectedFilesListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedFilesListView.Location = new System.Drawing.Point(81, 78);
            this.mobjSelectedFilesListView.Name = "mobjSelectedFilesListView";
            this.mobjSelectedFilesListView.Size = new System.Drawing.Size(380, 84);
            this.mobjSelectedFilesListView.TabIndex = 0;
            this.mobjSelectedFilesListView.TotalItems = 1;
            // 
            // mobjFileNameColumn
            // 
            this.mobjFileNameColumn.Text = "File Name";
            this.mobjFileNameColumn.Width = 179;
            // 
            // mobjFileSizeColumn
            // 
            this.mobjFileSizeColumn.Text = "File Size";
            this.mobjFileSizeColumn.Width = 190;
            // 
            // mobjSelectedFilesLabel
            // 
            this.mobjSelectedFilesLabel.AutoSize = true;
            this.mobjSelectedFilesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedFilesLabel.Location = new System.Drawing.Point(81, 18);
            this.mobjSelectedFilesLabel.Name = "mobjSelectedFilesLabel";
            this.mobjSelectedFilesLabel.Size = new System.Drawing.Size(380, 50);
            this.mobjSelectedFilesLabel.TabIndex = 1;
            this.mobjSelectedFilesLabel.Text = "Selection files\' name and size";
            this.mobjSelectedFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(81, 182);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(380, 50);
            this.mobjOpenFileDialogButton.TabIndex = 2;
            this.mobjOpenFileDialogButton.Text = "Open selection file dialog";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.Multiselect = true;
            this.mobjDemoOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.mobjDemoOpenFileDialog_FileOk);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectedFilesLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectedFilesListView, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(544, 250);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // FilesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(544, 250);
            this.Text = "FilesPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView mobjSelectedFilesListView;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjFileNameColumn;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjFileSizeColumn;
        private Gizmox.WebGUI.Forms.Label mobjSelectedFilesLabel;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
