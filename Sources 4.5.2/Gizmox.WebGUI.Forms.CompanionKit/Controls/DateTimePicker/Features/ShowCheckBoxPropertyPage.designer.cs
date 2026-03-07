namespace CompanionKit.Controls.DateTimePicker.Features
{
    partial class ShowCheckBoxPropertyPage
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
            this.mobjAllowCheckBoxForDateTimePickerCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjAllowCheckBoxForDateTimePickerCheckBox
            // 
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.AutoSize = true;
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Location = new System.Drawing.Point(76, 30);
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Name = "allowCheckBoxForDateTimePickerCheckBox";
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Size = new System.Drawing.Size(359, 40);
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.TabIndex = 0;
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Text = "Enable CheckBox";
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.UseVisualStyleBackColor = true;
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.CheckedChanged += new System.EventHandler(this.mobjAllowCheckBoxForDateTimePickerCheckBox_CheckedChanged);
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(76, 140);
            this.mobjDemoDateTimePicker.Name = "demoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(359, 21);
            this.mobjDemoDateTimePicker.TabIndex = 1;
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(76, 90);
            this.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(359, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 2;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowCheckBoxForDateTimePickerCheckBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(513, 200);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // ShowCheckBoxPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(340, 200);
            this.Size = new System.Drawing.Size(513, 200);
            this.Text = "ShowCheckBoxPropertyPage";
            this.Load += new System.EventHandler(this.ShowCheckBoxPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjAllowCheckBoxForDateTimePickerCheckBox;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}