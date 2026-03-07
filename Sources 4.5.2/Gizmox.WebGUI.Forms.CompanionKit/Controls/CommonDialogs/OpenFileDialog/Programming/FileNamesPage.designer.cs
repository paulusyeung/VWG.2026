namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    partial class FileNamesPage
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
            this.mobjSelectedFilesLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjSelectedFileNamesListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjTempFileNameColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjOrigFileNameColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjSelectedFilesLabel
            // 
            this.mobjSelectedFilesLabel.AutoSize = true;
            this.mobjSelectedFilesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedFilesLabel.Location = new System.Drawing.Point(94, 13);
            this.mobjSelectedFilesLabel.Name = "mobjSelectedFilesLabel";
            this.mobjSelectedFilesLabel.Size = new System.Drawing.Size(442, 50);
            this.mobjSelectedFilesLabel.TabIndex = 0;
            this.mobjSelectedFilesLabel.Text = "Selected file names";
            this.mobjSelectedFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(94, 197);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(442, 50);
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
            // mobjSelectedFileNamesListView
            // 
            this.mobjSelectedFileNamesListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjTempFileNameColumn,
            this.mobjOrigFileNameColumn});
            this.mobjSelectedFileNamesListView.DataMember = null;
            this.mobjSelectedFileNamesListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectedFileNamesListView.Location = new System.Drawing.Point(94, 73);
            this.mobjSelectedFileNamesListView.Name = "mobjSelectedFileNamesListView";
            this.mobjSelectedFileNamesListView.Size = new System.Drawing.Size(442, 104);
            this.mobjSelectedFileNamesListView.TabIndex = 3;
            this.mobjSelectedFileNamesListView.TotalItems = 1;
            // 
            // mobjTempFileNameColumn
            // 
            this.mobjTempFileNameColumn.Text = "Temporary file name";
            this.mobjTempFileNameColumn.Width = 212;
            // 
            // mobjOrigFileNameColumn
            // 
            this.mobjOrigFileNameColumn.Text = "Original file name";
            this.mobjOrigFileNameColumn.Width = 224;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectedFilesLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectedFileNamesListView, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(632, 261);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // FileNamesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(632, 261);
            this.Text = "FileNamesPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjSelectedFilesLabel;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.ListView mobjSelectedFileNamesListView;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjTempFileNameColumn;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjOrigFileNameColumn;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
