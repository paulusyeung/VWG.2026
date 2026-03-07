namespace CompanionKit.Controls.UploadControl.Functionality
{
    partial class UploadControlPage
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
            this.mobjUploadControl = new Gizmox.WebGUI.Forms.UploadControl();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjDefinedRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjCustomRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjExpandableGroupBox = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.mobjMiddleLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjFileTypeLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjCustomInputPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSetButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDefinedOptionPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjCustomOptionPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjShowSpeedCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjShowFileNameCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox)).BeginInit();
            this.mobjExpandableGroupBox.SuspendLayout();
            this.mobjMiddleLayoutPanel.SuspendLayout();
            this.mobjGroupBox.SuspendLayout();
            this.mobjFileTypeLayoutPanel.SuspendLayout();
            this.mobjCustomInputPanel.SuspendLayout();
            this.mobjDefinedOptionPanel.SuspendLayout();
            this.mobjCustomOptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjUploadControl
            // 
            this.mobjUploadControl.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Green);
            this.mobjUploadControl.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjUploadControl.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(3);
            this.mobjUploadControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjUploadControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mobjUploadControl.Location = new System.Drawing.Point(0, 0);
            this.mobjUploadControl.Name = "mobjUploadControl";
            this.mobjUploadControl.Size = new System.Drawing.Size(1162, 130);
            this.mobjUploadControl.TabIndex = 0;
            this.mobjUploadControl.UploadMaxFileSize = 50000000;
            this.mobjUploadControl.UploadMaxNumberOfFiles = 100;
            this.mobjUploadControl.UploadTempFilePath = "C:\\Users\\ygusak\\AppData\\Local\\Temp\\";
            this.mobjUploadControl.UploadText = "Select or drop files into the \"green zone\"";
            this.mobjUploadControl.UploadFileCompleted += new Gizmox.WebGUI.Forms.UploadFileCompletedHandler(this.mobjUploadControl_UploadFileCompleted);
            this.mobjUploadControl.UploadError += new Gizmox.WebGUI.Forms.UploadErrorHandler(this.mobjUploadControl_UploadError);
            // 
            // mobjListView
            // 
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(0, 396);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(1162, 273);
            this.mobjListView.TabIndex = 3;
            // 
            // mobjDefinedRadioButton
            // 
            this.mobjDefinedRadioButton.AutoSize = true;
            this.mobjDefinedRadioButton.Checked = true;
            this.mobjDefinedRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDefinedRadioButton.Location = new System.Drawing.Point(0, 0);
            this.mobjDefinedRadioButton.Name = "mobjDefinedRadioButton";
            this.mobjDefinedRadioButton.Size = new System.Drawing.Size(400, 30);
            this.mobjDefinedRadioButton.TabIndex = 7;
            this.mobjDefinedRadioButton.Text = "Defined";
            this.mobjDefinedRadioButton.CheckedChanged += new System.EventHandler(this.mobjDefinedRadioButton_CheckedChanged);
            // 
            // mobjCustomRadioButton
            // 
            this.mobjCustomRadioButton.AutoSize = true;
            this.mobjCustomRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomRadioButton.Location = new System.Drawing.Point(0, 0);
            this.mobjCustomRadioButton.Name = "mobjCustomRadioButton";
            this.mobjCustomRadioButton.Size = new System.Drawing.Size(400, 30);
            this.mobjCustomRadioButton.TabIndex = 8;
            this.mobjCustomRadioButton.Text = "Custom";
            this.mobjCustomRadioButton.CheckedChanged += new System.EventHandler(this.mobjCustomRadioButton_CheckedChanged);
            // 
            // mobjListBox
            // 
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "^.*$",
            "^.*\\.(gif|png|.jpe?g)$",
            "^.*\\.(zip|rar)$"});
            this.mobjListBox.Location = new System.Drawing.Point(20, 70);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(400, 95);
            this.mobjListBox.TabIndex = 9;
            this.mobjListBox.SelectedIndexChanged += new System.EventHandler(this.mobjListBox_SelectedIndexChanged);
            // 
            // mobjExpandableGroupBox
            // 
            this.mobjExpandableGroupBox.Controls.Add(this.mobjMiddleLayoutPanel);
            this.mobjExpandableGroupBox.CustomStyle = "X";
            this.mobjExpandableGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjExpandableGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjExpandableGroupBox.IsExpanded = false;
            this.mobjExpandableGroupBox.Location = new System.Drawing.Point(0, 130);
            this.mobjExpandableGroupBox.Name = "mobjExpandableGroupBox";
            this.mobjExpandableGroupBox.Size = new System.Drawing.Size(1162, 266);
            this.mobjExpandableGroupBox.TabIndex = 10;
            this.mobjExpandableGroupBox.Text = "Options";
            // 
            // mobjMiddleLayoutPanel
            // 
            this.mobjMiddleLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjMiddleLayoutPanel.ColumnCount = 5;
            this.mobjMiddleLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjMiddleLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjMiddleLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.Controls.Add(this.mobjGroupBox, 3, 1);
            this.mobjMiddleLayoutPanel.Controls.Add(this.mobjShowSpeedCheckBox, 1, 3);
            this.mobjMiddleLayoutPanel.Controls.Add(this.mobjShowFileNameCheckBox, 1, 1);
            this.mobjMiddleLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMiddleLayoutPanel.Location = new System.Drawing.Point(3, 17);
            this.mobjMiddleLayoutPanel.Name = "mobjMiddleLayoutPanel";
            this.mobjMiddleLayoutPanel.RowCount = 5;
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjMiddleLayoutPanel.Size = new System.Drawing.Size(1156, 246);
            this.mobjMiddleLayoutPanel.TabIndex = 14;
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjFileTypeLayoutPanel);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(259, 20);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjMiddleLayoutPanel.SetRowSpan(this.mobjGroupBox, 3);
            this.mobjGroupBox.Size = new System.Drawing.Size(876, 206);
            this.mobjGroupBox.TabIndex = 0;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "File type:";
            // 
            // mobjFileTypeLayoutPanel
            // 
            this.mobjFileTypeLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjFileTypeLayoutPanel.ColumnCount = 5;
            this.mobjFileTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjFileTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjFileTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjFileTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjFileTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjFileTypeLayoutPanel.Controls.Add(this.mobjListBox, 1, 3);
            this.mobjFileTypeLayoutPanel.Controls.Add(this.mobjCustomInputPanel, 3, 3);
            this.mobjFileTypeLayoutPanel.Controls.Add(this.mobjDefinedOptionPanel, 1, 1);
            this.mobjFileTypeLayoutPanel.Controls.Add(this.mobjCustomOptionPanel, 3, 1);
            this.mobjFileTypeLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFileTypeLayoutPanel.Location = new System.Drawing.Point(3, 17);
            this.mobjFileTypeLayoutPanel.Name = "mobjFileTypeLayoutPanel";
            this.mobjFileTypeLayoutPanel.RowCount = 5;
            this.mobjFileTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjFileTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjFileTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjFileTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjFileTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjFileTypeLayoutPanel.Size = new System.Drawing.Size(870, 186);
            this.mobjFileTypeLayoutPanel.TabIndex = 11;
            // 
            // mobjCustomInputPanel
            // 
            this.mobjCustomInputPanel.Controls.Add(this.mobjSetButton);
            this.mobjCustomInputPanel.Controls.Add(this.mobjTextBox);
            this.mobjCustomInputPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomInputPanel.Location = new System.Drawing.Point(450, 70);
            this.mobjCustomInputPanel.Name = "mobjCustomInputPanel";
            this.mobjCustomInputPanel.Size = new System.Drawing.Size(400, 96);
            this.mobjCustomInputPanel.TabIndex = 0;
            // 
            // mobjSetButton
            // 
            this.mobjSetButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSetButton.Enabled = false;
            this.mobjSetButton.Location = new System.Drawing.Point(0, 56);
            this.mobjSetButton.MinimumSize = new System.Drawing.Size(0, 40);
            this.mobjSetButton.Name = "mobjSetButton";
            this.mobjSetButton.Size = new System.Drawing.Size(400, 40);
            this.mobjSetButton.TabIndex = 0;
            this.mobjSetButton.Text = "Set";
            this.mobjSetButton.Click += new System.EventHandler(this.mobjSetButton_Click);
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBox.Enabled = false;
            this.mobjTextBox.Location = new System.Drawing.Point(0, 0);
            this.mobjTextBox.MinimumSize = new System.Drawing.Size(0, 30);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(400, 30);
            this.mobjTextBox.TabIndex = 10;
            // 
            // mobjDefinedOptionPanel
            // 
            this.mobjDefinedOptionPanel.Controls.Add(this.mobjDefinedRadioButton);
            this.mobjDefinedOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDefinedOptionPanel.Location = new System.Drawing.Point(20, 20);
            this.mobjDefinedOptionPanel.Name = "mobjDefinedOptionPanel";
            this.mobjDefinedOptionPanel.Size = new System.Drawing.Size(400, 30);
            this.mobjDefinedOptionPanel.TabIndex = 0;
            // 
            // mobjCustomOptionPanel
            // 
            this.mobjCustomOptionPanel.Controls.Add(this.mobjCustomRadioButton);
            this.mobjCustomOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCustomOptionPanel.Location = new System.Drawing.Point(450, 20);
            this.mobjCustomOptionPanel.Name = "mobjCustomOptionPanel";
            this.mobjCustomOptionPanel.Size = new System.Drawing.Size(400, 30);
            this.mobjCustomOptionPanel.TabIndex = 0;
            // 
            // mobjShowSpeedCheckBox
            // 
            this.mobjShowSpeedCheckBox.AutoSize = true;
            this.mobjMiddleLayoutPanel.SetColumnSpan(this.mobjShowSpeedCheckBox, 2);
            this.mobjShowSpeedCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowSpeedCheckBox.Location = new System.Drawing.Point(20, 133);
            this.mobjShowSpeedCheckBox.Name = "mobjShowSpeedCheckBox";
            this.mobjShowSpeedCheckBox.Size = new System.Drawing.Size(239, 93);
            this.mobjShowSpeedCheckBox.TabIndex = 13;
            this.mobjShowSpeedCheckBox.Text = "Show Speed";
            this.mobjShowSpeedCheckBox.CheckedChanged += new System.EventHandler(this.mobjShowSpeedCheckBox_CheckedChanged);
            // 
            // mobjShowFileNameCheckBox
            // 
            this.mobjShowFileNameCheckBox.AutoSize = true;
            this.mobjMiddleLayoutPanel.SetColumnSpan(this.mobjShowFileNameCheckBox, 2);
            this.mobjShowFileNameCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowFileNameCheckBox.Location = new System.Drawing.Point(20, 20);
            this.mobjShowFileNameCheckBox.Name = "mobjShowFileNameCheckBox";
            this.mobjShowFileNameCheckBox.Size = new System.Drawing.Size(239, 93);
            this.mobjShowFileNameCheckBox.TabIndex = 13;
            this.mobjShowFileNameCheckBox.Text = "Show File Name";
            this.mobjShowFileNameCheckBox.CheckedChanged += new System.EventHandler(this.mobjShowFileNameCheckBox_CheckedChanged);
            // 
            // UploadControlPage
            // 
            this.Controls.Add(this.mobjListView);
            this.Controls.Add(this.mobjExpandableGroupBox);
            this.Controls.Add(this.mobjUploadControl);
            this.Location = new System.Drawing.Point(0, -142);
            this.Size = new System.Drawing.Size(1162, 669);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UploadControlPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox)).EndInit();
            this.mobjExpandableGroupBox.ResumeLayout(false);
            this.mobjMiddleLayoutPanel.ResumeLayout(false);
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjFileTypeLayoutPanel.ResumeLayout(false);
            this.mobjCustomInputPanel.ResumeLayout(false);
            this.mobjDefinedOptionPanel.ResumeLayout(false);
            this.mobjCustomOptionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.UploadControl mobjUploadControl;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.RadioButton mobjDefinedRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjCustomRadioButton;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.ExpandableGroupBox mobjExpandableGroupBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjFileTypeLayoutPanel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjMiddleLayoutPanel;
        private Gizmox.WebGUI.Forms.CheckBox mobjShowSpeedCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjShowFileNameCheckBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.Panel mobjCustomInputPanel;
        private Gizmox.WebGUI.Forms.Button mobjSetButton;
        private Gizmox.WebGUI.Forms.Panel mobjDefinedOptionPanel;
        private Gizmox.WebGUI.Forms.Panel mobjCustomOptionPanel;

    }
}