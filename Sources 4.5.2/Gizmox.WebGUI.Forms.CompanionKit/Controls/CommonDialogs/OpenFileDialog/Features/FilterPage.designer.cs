namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    partial class FilterPage
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
            this.mobjFiltersOfFileTypesLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOpenFileDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFiltersOfFileTypesListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjFiltersOfFileTypesLabel
            // 
            this.mobjFiltersOfFileTypesLabel.AutoSize = true;
            this.mobjFiltersOfFileTypesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFiltersOfFileTypesLabel.Location = new System.Drawing.Point(72, 29);
            this.mobjFiltersOfFileTypesLabel.Name = "mobjFiltersOfFileTypesLabel";
            this.mobjFiltersOfFileTypesLabel.Size = new System.Drawing.Size(340, 50);
            this.mobjFiltersOfFileTypesLabel.TabIndex = 0;
            this.mobjFiltersOfFileTypesLabel.Text = "Filters of the file types for OpenFileDialog";
            // 
            // mobjOpenFileDialogButton
            // 
            this.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileDialogButton.Location = new System.Drawing.Point(72, 197);
            this.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton";
            this.mobjOpenFileDialogButton.Size = new System.Drawing.Size(340, 50);
            this.mobjOpenFileDialogButton.TabIndex = 2;
            this.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with specified Filter";
            this.mobjOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileDialogButton.Click += new System.EventHandler(this.mobjOpenFileDialogButton_Click);
            // 
            // mobjFiltersOfFileTypesListBox
            // 
            this.mobjFiltersOfFileTypesListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFiltersOfFileTypesListBox.Location = new System.Drawing.Point(72, 89);
            this.mobjFiltersOfFileTypesListBox.Name = "mobjFiltersOfFileTypesListBox";
            this.mobjFiltersOfFileTypesListBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiExtended;
            this.mobjFiltersOfFileTypesListBox.Size = new System.Drawing.Size(340, 82);
            this.mobjFiltersOfFileTypesListBox.TabIndex = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjFiltersOfFileTypesLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileDialogButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjFiltersOfFileTypesListBox, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(486, 277);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // FilterPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(486, 277);
            this.Text = "FilterPage";
            this.Load += new System.EventHandler(this.FilterPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjFiltersOfFileTypesLabel;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileDialogButton;
        private Gizmox.WebGUI.Forms.ListBox mobjFiltersOfFileTypesListBox;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
