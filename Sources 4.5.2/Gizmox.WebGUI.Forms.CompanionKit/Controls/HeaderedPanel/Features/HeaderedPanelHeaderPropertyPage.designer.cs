namespace CompanionKit.Controls.HeaderedPanel.Features
{
    partial class HeaderedPanelHeaderPropertyPage
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
            this.mobjHeaderedPanel = new Gizmox.WebGUI.Forms.HeaderedPanel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjHeaderedPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjHeaderedPanel
            // 
            this.mobjHeaderedPanel.Controls.Add(this.mobjLabel);
            this.mobjHeaderedPanel.CustomStyle = "HeaderedPanel";
            this.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHeaderedPanel.Location = new System.Drawing.Point(65, 20);
            this.mobjHeaderedPanel.Name = "mobjHeaderedPanel";
            this.mobjHeaderedPanel.Size = new System.Drawing.Size(522, 86);
            this.mobjHeaderedPanel.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(213, 32);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Panel content";
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjTextBox.Location = new System.Drawing.Point(45, 53);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(207, 30);
            this.mobjTextBox.TabIndex = 1;
            this.mobjTextBox.Text = "Custom Text";
            this.mobjTextBox.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Work",
            "Friends",
            "Family"});
            this.mobjComboBox.Location = new System.Drawing.Point(42, 22);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(213, 30);
            this.mobjComboBox.TabIndex = 2;
            this.mobjComboBox.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // mobjDateTimePicker
            // 
            this.mobjDateTimePicker.CustomFormat = "";
            this.mobjDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.mobjDateTimePicker.Location = new System.Drawing.Point(265, 22);
            this.mobjDateTimePicker.Name = "mobjDateTimePicker";
            this.mobjDateTimePicker.Size = new System.Drawing.Size(213, 30);
            this.mobjDateTimePicker.TabIndex = 3;
            this.mobjDateTimePicker.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjButton.Location = new System.Drawing.Point(65, 228);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(522, 50);
            this.mobjButton.TabIndex = 4;
            this.mobjButton.Text = "Reset Controls";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjHeaderedPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjAdditionalLayoutPanel, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(653, 300);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.ColumnCount = 5;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 8.333333F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 41.66667F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 41.66667F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 8.333333F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjComboBox, 1, 0);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjTextBox, 1, 1);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjDateTimePicker, 3, 0);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(65, 106);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 2;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(522, 86);
            this.mobjAdditionalLayoutPanel.TabIndex = 0;
            // 
            // HeaderedPanelHeaderPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(653, 300);
            this.Text = "HeaderedPanelHeaderPropertyPage";
            this.Load += new System.EventHandler(this.HeaderedPanelHeaderPropertyPage_Load);
            this.mobjHeaderedPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.HeaderedPanel mobjHeaderedPanel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDateTimePicker;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;



    }
}