namespace CompanionKit.Controls.DataGridView.Features
{
    partial class ExtendedHeadersPage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDGV = new Gizmox.WebGUI.Forms.DataGridView();
            this.Column1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjColIndexLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjIsExtHeaderVisible = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(419, 61);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Extended Header contains two buttons for adding and removing rows in DataGridView" +
    ". Use NumericUpDown to change the number of column extended header belongs to:";
            // 
            // mobjDGV
            // 
            this.mobjDGV.AccessibleDescription = "";
            this.mobjDGV.AccessibleName = "";
            this.mobjDGV.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDGV.Location = new System.Drawing.Point(0, 61);
            this.mobjDGV.Name = "mobjDGV";
            this.mobjDGV.Size = new System.Drawing.Size(419, 273);
            this.mobjDGV.TabIndex = 2;
            this.mobjDGV.ExtendedColumnHeaders.ShowExtendedColumnHeader = true;
            // 
            // Column1
            // 
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column3.Name = "Column3";
            // 
            // mobjNUD
            // 
            this.mobjNUD.AccessibleDescription = "";
            this.mobjNUD.AccessibleName = "";
            this.mobjNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNUD.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNUD.Location = new System.Drawing.Point(165, 354);
            this.mobjNUD.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.mobjNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNUD.Name = "mobjNUD";
            this.mobjNUD.Size = new System.Drawing.Size(120, 21);
            this.mobjNUD.TabIndex = 3;
            this.mobjNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNUD.ValueChanged += new System.EventHandler(this.mobjNUD_ValueChanged);
            // 
            // mobjColIndexLabel
            // 
            this.mobjColIndexLabel.AccessibleDescription = "";
            this.mobjColIndexLabel.AccessibleName = "";
            this.mobjColIndexLabel.Location = new System.Drawing.Point(29, 356);
            this.mobjColIndexLabel.Name = "mobjColIndexLabel";
            this.mobjColIndexLabel.Size = new System.Drawing.Size(136, 23);
            this.mobjColIndexLabel.TabIndex = 4;
            this.mobjColIndexLabel.Text = "Column Number:";
            // 
            // mobjIsExtHeaderVisible
            // 
            this.mobjIsExtHeaderVisible.AccessibleDescription = "";
            this.mobjIsExtHeaderVisible.AccessibleName = "";
            this.mobjIsExtHeaderVisible.Location = new System.Drawing.Point(32, 406);
            this.mobjIsExtHeaderVisible.Name = "mobjIsExtHeaderVisible";
            this.mobjIsExtHeaderVisible.Size = new System.Drawing.Size(253, 41);
            this.mobjIsExtHeaderVisible.TabIndex = 5;
            this.mobjIsExtHeaderVisible.Text = "Show Extended Column Header";
            this.mobjIsExtHeaderVisible.Checked = true;
            this.mobjIsExtHeaderVisible.CheckedChanged += new System.EventHandler(this.mobjIsExtHeaderVisible_CheckedChanged);
            // 
            // ExtendedHeadersPage
            // 
            this.Controls.Add(this.mobjIsExtHeaderVisible);
            this.Controls.Add(this.mobjColIndexLabel);
            this.Controls.Add(this.mobjNUD);
            this.Controls.Add(this.mobjDGV);
            this.Controls.Add(this.mobjInfoLabel);
            this.Size = new System.Drawing.Size(391, 460);
            this.Text = "ExtendedHeadersPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNUD)).EndInit();
            this.Load += new System.EventHandler(ExtendedHeadersPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.DataGridView mobjDGV;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn Column1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn Column2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn Column3;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNUD;
        private Gizmox.WebGUI.Forms.Label mobjColIndexLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsExtHeaderVisible;
    }
}