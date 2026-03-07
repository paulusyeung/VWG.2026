namespace CompanionKit.Controls.DateTimePicker.Features
{
    partial class FormatPropertyPage
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
            this.mobjDateFormatLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDateFormatComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDateFormatLabel
            // 
            this.mobjDateFormatLabel.AutoSize = true;
            this.mobjDateFormatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateFormatLabel.Location = new System.Drawing.Point(78, 28);
            this.mobjDateFormatLabel.Name = "dateFormatLabel";
            this.mobjDateFormatLabel.Size = new System.Drawing.Size(368, 50);
            this.mobjDateFormatLabel.TabIndex = 0;
            this.mobjDateFormatLabel.Text = "Select the date format to apply:";
            this.mobjDateFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDateFormatComboBox
            // 
            this.mobjDateFormatComboBox.AllowDrag = false;
            this.mobjDateFormatComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjDateFormatComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateFormatComboBox.Location = new System.Drawing.Point(78, 78);
            this.mobjDateFormatComboBox.Name = "dateFormatComboBox";
            this.mobjDateFormatComboBox.Size = new System.Drawing.Size(368, 21);
            this.mobjDateFormatComboBox.TabIndex = 1;
            this.mobjDateFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjDateFormatComboBox_SelectedIndexChanged);
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(78, 128);
            this.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(368, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 2;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(78, 178);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(368, 21);
            this.mobjDemoDateTimePicker.TabIndex = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDateFormatLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDateFormatComboBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(526, 236);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // FormatPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(339, 236);
            this.Size = new System.Drawing.Size(526, 236);
            this.Text = "FormatPropertyPage";
            this.Load += new System.EventHandler(this.FormatPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDateFormatLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjDateFormatComboBox;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}