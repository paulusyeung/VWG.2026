namespace CompanionKit.Controls.NumericUpDown.Programming
{
    partial class FormatPage
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
            this.demoNumericUpDownLabel = new Gizmox.WebGUI.Forms.Label();
            this.demoNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.decimalPlacesNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.decimalPlacesLabel = new Gizmox.WebGUI.Forms.Label();
            this.thousandsSeparatorCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimalPlacesNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(0, 0);
            this.demoNumericUpDownLabel.Name = "label1";
            this.demoNumericUpDownLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.demoNumericUpDownLabel.Size = new System.Drawing.Size(160, 120);
            this.demoNumericUpDownLabel.TabIndex = 0;
            this.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown";
            this.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // demoNumericUpDown
            // 
            this.demoNumericUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.demoNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.demoNumericUpDown.CurrentValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.demoNumericUpDown.DecimalPlaces = 3;
            this.demoNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.demoNumericUpDown.Location = new System.Drawing.Point(160, 49);
            this.demoNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.demoNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.demoNumericUpDown.Name = "numericUpDown1";
            this.demoNumericUpDown.Size = new System.Drawing.Size(160, 21);
            this.demoNumericUpDown.TabIndex = 1;
            this.demoNumericUpDown.ThousandsSeparator = true;
            this.demoNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // decimalPlacesNumericUpDown
            // 
            this.decimalPlacesNumericUpDown.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.decimalPlacesNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.decimalPlacesNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.decimalPlacesNumericUpDown.Location = new System.Drawing.Point(160, 169);
            this.decimalPlacesNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.decimalPlacesNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.decimalPlacesNumericUpDown.Name = "decimalPlacesNumericUpDown";
            this.decimalPlacesNumericUpDown.Size = new System.Drawing.Size(160, 21);
            this.decimalPlacesNumericUpDown.TabIndex = 3;
            this.decimalPlacesNumericUpDown.ValueChanged += new System.EventHandler(this.decimalPlacesNumericUpDown_ValueChanged);
            // 
            // decimalPlacesLabel
            // 
            this.decimalPlacesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.decimalPlacesLabel.Location = new System.Drawing.Point(0, 120);
            this.decimalPlacesLabel.Name = "decimalPlacesLabel";
            this.decimalPlacesLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.decimalPlacesLabel.Size = new System.Drawing.Size(160, 120);
            this.decimalPlacesLabel.TabIndex = 5;
            this.decimalPlacesLabel.Text = "Decimal places";
            this.decimalPlacesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thousandsSeparatorCheckBox
            // 
            this.thousandsSeparatorCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.thousandsSeparatorCheckBox.Checked = true;
            this.thousandsSeparatorCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjTLP.SetColumnSpan(this.thousandsSeparatorCheckBox, 2);
            this.thousandsSeparatorCheckBox.Location = new System.Drawing.Point(60, 295);
            this.thousandsSeparatorCheckBox.Name = "thousandsSeparatorCheckBox";
            this.thousandsSeparatorCheckBox.Size = new System.Drawing.Size(200, 50);
            this.thousandsSeparatorCheckBox.TabIndex = 6;
            this.thousandsSeparatorCheckBox.Text = "Enable thousands separator";
            this.thousandsSeparatorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thousandsSeparatorCheckBox.UseVisualStyleBackColor = true;
            this.thousandsSeparatorCheckBox.CheckedChanged += new System.EventHandler(this.thousandsSeparatorCheckBox_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.thousandsSeparatorCheckBox, 0, 2);
            this.mobjTLP.Controls.Add(this.decimalPlacesLabel, 0, 1);
            this.mobjTLP.Controls.Add(this.decimalPlacesNumericUpDown, 1, 1);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 1, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 7;
            // 
            // FormatPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "FormatPage";
            this.Load += new System.EventHandler(this.FormatPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimalPlacesNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label demoNumericUpDownLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown demoNumericUpDown;
        private Gizmox.WebGUI.Forms.NumericUpDown decimalPlacesNumericUpDown;
        private Gizmox.WebGUI.Forms.Label decimalPlacesLabel;
        private Gizmox.WebGUI.Forms.CheckBox thousandsSeparatorCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;


    }
}
