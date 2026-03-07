namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    partial class BackColorPropertyPage
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
            this.mobjBackColorLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjBackColorComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(63, 183);
            this.mobjDemoDateTimePicker.Name = "mobjDemoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(294, 21);
            this.mobjDemoDateTimePicker.TabIndex = 0;
            // 
            // mobjBackColorLabel
            // 
            this.mobjBackColorLabel.AutoSize = true;
            this.mobjBackColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBackColorLabel.Location = new System.Drawing.Point(63, 33);
            this.mobjBackColorLabel.Name = "mobjBackColorLabel";
            this.mobjBackColorLabel.Size = new System.Drawing.Size(294, 50);
            this.mobjBackColorLabel.TabIndex = 1;
            this.mobjBackColorLabel.Text = "Background color";
            this.mobjBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjBackColorComboBox
            // 
            this.mobjBackColorComboBox.AllowDrag = false;
            this.mobjBackColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjBackColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBackColorComboBox.Location = new System.Drawing.Point(63, 83);
            this.mobjBackColorComboBox.Name = "mobjBackColorComboBox";
            this.mobjBackColorComboBox.Size = new System.Drawing.Size(294, 21);
            this.mobjBackColorComboBox.TabIndex = 2;
            this.mobjBackColorComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjBackColorComboBox_SelectedIndexChanged);
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(63, 133);
            this.mobjDemoDateTimePickerLabel.Name = "mobjDemoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(294, 50);
            this.mobjDemoDateTimePickerLabel.TabIndex = 3;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            this.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjBackColorLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjBackColorComboBox, 1, 2);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(420, 246);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // BackColorPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(353, 246);
            this.Size = new System.Drawing.Size(420, 246);
            this.Text = "BackColorPropertyPage";
            this.Load += new System.EventHandler(this.BackColorPropertyPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjBackColorLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjBackColorComboBox;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}