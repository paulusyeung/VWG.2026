namespace CompanionKit.Controls.DateTimePicker.Features
{
    partial class MaxDatePropertyPage
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
            this.mobjMaxDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjMaxDateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaxDateTimePicker
            // 
            this.mobjMaxDateTimePicker.CustomFormat = "";
            this.mobjMaxDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaxDateTimePicker.Location = new System.Drawing.Point(68, 75);
            this.mobjMaxDateTimePicker.Name = "maxDateTimePicker";
            this.mobjMaxDateTimePicker.Size = new System.Drawing.Size(321, 21);
            this.mobjMaxDateTimePicker.TabIndex = 0;
            this.mobjMaxDateTimePicker.ValueChanged += new System.EventHandler(this.mobjMaxDateTimePicker_ValueChanged);
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(68, 175);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(321, 21);
            this.mobjDemoDateTimePicker.TabIndex = 2;
            // 
            // mobjMaxDateLabel
            // 
            this.mobjMaxDateLabel.AutoSize = true;
            this.mobjMaxDateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaxDateLabel.Location = new System.Drawing.Point(68, 25);
            this.mobjMaxDateLabel.Name = "maxDatelabel";
            this.mobjMaxDateLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjMaxDateLabel.TabIndex = 3;
            this.mobjMaxDateLabel.Text = "Maximum date";
            this.mobjMaxDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(68, 125);
            this.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(321, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 5;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxDateLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxDateTimePicker, 1, 2);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(459, 230);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // MaxDatePropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(330, 230);
            this.Size = new System.Drawing.Size(459, 230);
            this.Text = "MaxDatePropertyPage";
            this.Load += new System.EventHandler(this.MaxDatePropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker mobjMaxDateTimePicker;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjMaxDateLabel;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}