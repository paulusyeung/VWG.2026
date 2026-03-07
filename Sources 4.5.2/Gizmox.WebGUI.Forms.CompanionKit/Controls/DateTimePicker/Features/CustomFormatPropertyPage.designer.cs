namespace CompanionKit.Controls.DateTimePicker.Features
{
    partial class CustomFormatPropertyPage
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
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDateFormatsListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjDateFormatLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(79, 307);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(368, 21);
            this.mobjDemoDateTimePicker.TabIndex = 2;
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(79, 257);
            this.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(368, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 3;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDateFormatsListBox
            // 
            this.mobjDateFormatsListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateFormatsListBox.Location = new System.Drawing.Point(79, 83);
            this.mobjDateFormatsListBox.Name = "dateFormatsListBox";
            this.mobjDateFormatsListBox.Size = new System.Drawing.Size(368, 147);
            this.mobjDateFormatsListBox.TabIndex = 4;
            this.mobjDateFormatsListBox.SelectedIndexChanged += new System.EventHandler(this.mobjDateFormatsListBox_SelectedIndexChanged);
            // 
            // mobjDateFormatLabel
            // 
            this.mobjDateFormatLabel.AutoSize = true;
            this.mobjDateFormatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateFormatLabel.Location = new System.Drawing.Point(79, 33);
            this.mobjDateFormatLabel.Name = "dateFormatLabel";
            this.mobjDateFormatLabel.Size = new System.Drawing.Size(368, 50);
            this.mobjDateFormatLabel.TabIndex = 5;
            this.mobjDateFormatLabel.Text = "Select a custom date format";
            this.mobjDateFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDateFormatLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDateFormatsListBox, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(527, 371);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // CustomFormatPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(338, 371);
            this.Size = new System.Drawing.Size(527, 371);
            this.Text = "CustomFormatPropertyPage";
            this.Load += new System.EventHandler(this.CustomFormatPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.ListBox mobjDateFormatsListBox;
        private Gizmox.WebGUI.Forms.Label mobjDateFormatLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}