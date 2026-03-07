namespace CompanionKit.Controls.DateTimePicker.Functionality
{
    partial class CheckedPropertyPage
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
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjDateTimePickerCheckBoxStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(75, 49);
            this.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(350, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 0;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(75, 99);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.ShowCheckBox = true;
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(350, 21);
            this.mobjDemoDateTimePicker.TabIndex = 1;
            this.mobjDemoDateTimePicker.CheckedChanged += new System.EventHandler(this.mobjDemoDateTimePicker_CheckedChanged);
            // 
            // mobjDateTimePickerCheckBoxStateLabel
            // 
            this.mobjDateTimePickerCheckBoxStateLabel.AutoSize = true;
            this.mobjDateTimePickerCheckBoxStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateTimePickerCheckBoxStateLabel.Location = new System.Drawing.Point(75, 149);
            this.mobjDateTimePickerCheckBoxStateLabel.Name = "dateTimePickerCheckBoxStateLabel";
            this.mobjDateTimePickerCheckBoxStateLabel.Size = new System.Drawing.Size(350, 50);
            this.mobjDateTimePickerCheckBoxStateLabel.TabIndex = 2;
            this.mobjDateTimePickerCheckBoxStateLabel.Text = "The DateTimePicker is checked/unchecked now";
            this.mobjDateTimePickerCheckBoxStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDateTimePickerCheckBoxStateLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(500, 249);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // CheckedPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(305, 180);
            this.Size = new System.Drawing.Size(500, 249);
            this.Text = "CheckedPropertyPage";
            this.Load += new System.EventHandler(this.CheckedPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjDateTimePickerCheckBoxStateLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}