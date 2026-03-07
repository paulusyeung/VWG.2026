namespace CompanionKit.Controls.ComboBox.Appearance
{
    partial class DropDownWidthPage
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
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjDropDownWidthLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4",
            "Item5"});
            this.mobjComboBox.Location = new System.Drawing.Point(45, 165);
            this.mobjComboBox.Name = "objComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.Text = "Item1";
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNumericUpDown.Location = new System.Drawing.Point(45, 65);
            this.mobjNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.mobjNumericUpDown.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mobjNumericUpDown.Name = "objNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjNumericUpDown.TabIndex = 1;
            this.mobjNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mobjNumericUpDown.ValueChanged += new System.EventHandler(this.mobjNumericUpDown_ValueChanged);
            // 
            // mobjDropDownWidthLabel
            // 
            this.mobjDropDownWidthLabel.AutoSize = true;
            this.mobjDropDownWidthLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDropDownWidthLabel.Location = new System.Drawing.Point(45, 15);
            this.mobjDropDownWidthLabel.Name = "objDropDownWidthLabel";
            this.mobjDropDownWidthLabel.Size = new System.Drawing.Size(200, 50);
            this.mobjDropDownWidthLabel.TabIndex = 2;
            this.mobjDropDownWidthLabel.Text = "DropDownWidth:";
            this.mobjDropDownWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjComboBoxLabel
            // 
            this.mobjComboBoxLabel.AutoSize = true;
            this.mobjComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBoxLabel.Location = new System.Drawing.Point(45, 115);
            this.mobjComboBoxLabel.Name = "objComboBoxLabel";
            this.mobjComboBoxLabel.Size = new System.Drawing.Size(200, 50);
            this.mobjComboBoxLabel.TabIndex = 3;
            this.mobjComboBoxLabel.Text = "ComboBox:";
            this.mobjComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDropDownWidthLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBoxLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjNumericUpDown, 1, 2);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(291, 210);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // DropDownWidthPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(291, 210);
            this.Text = "DropDownWidthPage";
            this.Load += new System.EventHandler(this.DropDownWidthPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjDropDownWidthLabel;
        private Gizmox.WebGUI.Forms.Label mobjComboBoxLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}