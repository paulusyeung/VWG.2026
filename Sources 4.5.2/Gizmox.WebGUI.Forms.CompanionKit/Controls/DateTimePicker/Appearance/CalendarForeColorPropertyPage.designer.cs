namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    partial class CalendarForeColorPropertyPage
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
            this.mobjForeColorLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjForeColorComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjForeColorLabel
            // 
            this.mobjForeColorLabel.AutoSize = true;
            this.mobjForeColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjForeColorLabel.Location = new System.Drawing.Point(66, 43);
            this.mobjForeColorLabel.Name = "foreColorLabel";
            this.mobjForeColorLabel.Size = new System.Drawing.Size(310, 30);
            this.mobjForeColorLabel.TabIndex = 0;
            this.mobjForeColorLabel.Text = "Calendar foreground color";
            // 
            // mobjForeColorComboBox
            // 
            this.mobjForeColorComboBox.AllowDrag = false;
            this.mobjForeColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjForeColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjForeColorComboBox.Location = new System.Drawing.Point(66, 73);
            this.mobjForeColorComboBox.Name = "foreColorComboBox";
            this.mobjForeColorComboBox.Size = new System.Drawing.Size(310, 21);
            this.mobjForeColorComboBox.TabIndex = 1;
            this.mobjForeColorComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjForeColorComboBox_SelectedIndexChanged);
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(66, 123);
            this.mobjDemoDateTimePickerLabel.Name = "demoDataTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(310, 30);
            this.mobjDemoDateTimePickerLabel.TabIndex = 2;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(66, 153);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(310, 21);
            this.mobjDemoDateTimePicker.TabIndex = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjForeColorLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjForeColorComboBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(444, 226);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // CalendarForeColorPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(323, 226);
            this.Size = new System.Drawing.Size(444, 226);
            this.Text = "CalendarForeColorPropertyPage";
            this.Load += new System.EventHandler(this.CalendarForeColorPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjForeColorLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjForeColorComboBox;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}