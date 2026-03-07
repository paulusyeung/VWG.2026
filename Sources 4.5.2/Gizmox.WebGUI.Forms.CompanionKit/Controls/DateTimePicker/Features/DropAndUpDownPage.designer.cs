namespace CompanionKit.Controls.DateTimePicker.Features
{
    partial class DropAndUpDownPage
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
            this.mobjDTPLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDTPLabel
            // 
            this.mobjDTPLabel.AutoSize = true;
            this.mobjDTPLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDTPLabel.Location = new System.Drawing.Point(65, 134);
            this.mobjDTPLabel.Name = "objDTPLabel";
            this.mobjDTPLabel.Size = new System.Drawing.Size(307, 50);
            this.mobjDTPLabel.TabIndex = 0;
            this.mobjDTPLabel.Text = "DateTimePicker:";
            this.mobjDTPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjComboLabel
            // 
            this.mobjComboLabel.AutoSize = true;
            this.mobjComboLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboLabel.Location = new System.Drawing.Point(65, 34);
            this.mobjComboLabel.Name = "objComboLabel";
            this.mobjComboLabel.Size = new System.Drawing.Size(307, 50);
            this.mobjComboLabel.TabIndex = 1;
            this.mobjComboLabel.Text = "DateTimePicker\'s buttons structure:";
            this.mobjComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDateTimePicker
            // 
            this.mobjDateTimePicker.CustomFormat = "";
            this.mobjDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDateTimePicker.Location = new System.Drawing.Point(65, 184);
            this.mobjDateTimePicker.Name = "objDateTimePicker";
            this.mobjDateTimePicker.Size = new System.Drawing.Size(307, 21);
            this.mobjDateTimePicker.TabIndex = 2;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "DropDown",
            "UpDown",
            "Both"});
            this.mobjComboBox.Location = new System.Drawing.Point(65, 84);
            this.mobjComboBox.Name = "objComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(307, 21);
            this.mobjComboBox.TabIndex = 3;
            this.mobjComboBox.Text = "DropDown";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjComboLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDTPLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 2);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(439, 249);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // DropAndUpDownPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(439, 249);
            this.Text = "DropAndUpDownPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDTPLabel;
        private Gizmox.WebGUI.Forms.Label mobjComboLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDateTimePicker;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;

    }
}