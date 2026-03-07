namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    partial class DecimalPlacesPropertyPage
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
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decimalPlacesNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(10, 10);
            this.demoNumericUpDownLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDownLabel.Name = "label1";
            this.demoNumericUpDownLabel.Size = new System.Drawing.Size(300, 67);
            this.demoNumericUpDownLabel.TabIndex = 0;
            this.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown";
            this.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // demoNumericUpDown
            // 
            this.demoNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.demoNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.demoNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.demoNumericUpDown.DecimalPlaces = 3;
            this.demoNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.demoNumericUpDown.Location = new System.Drawing.Point(60, 97);
            this.demoNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.demoNumericUpDown.Name = "numericUpDown1";
            this.demoNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.demoNumericUpDown.TabIndex = 1;
            // 
            // decimalPlacesNumericUpDown
            // 
            this.decimalPlacesNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.decimalPlacesNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.decimalPlacesNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.decimalPlacesNumericUpDown.Location = new System.Drawing.Point(60, 271);
            this.decimalPlacesNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.decimalPlacesNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.decimalPlacesNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.decimalPlacesNumericUpDown.Name = "decimalPlacesNumericUpDown";
            this.decimalPlacesNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.decimalPlacesNumericUpDown.TabIndex = 3;
            this.decimalPlacesNumericUpDown.ValueChanged += new System.EventHandler(this.decimalPlacesNumericUpDown_ValueChanged);
            // 
            // decimalPlacesLabel
            // 
            this.decimalPlacesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.decimalPlacesLabel.Location = new System.Drawing.Point(10, 184);
            this.decimalPlacesLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.decimalPlacesLabel.Name = "decimalPlacesLabel";
            this.decimalPlacesLabel.Size = new System.Drawing.Size(300, 67);
            this.decimalPlacesLabel.TabIndex = 5;
            this.decimalPlacesLabel.Text = "Decimal places";
            this.decimalPlacesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.decimalPlacesNumericUpDown, 0, 3);
            this.mobjTLP.Controls.Add(this.decimalPlacesLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 6;
            // 
            // DecimalPlacesPropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "DecimalPlacesPropertyPage";
            this.Load += new System.EventHandler(this.DecimalPlacesPropertyPage_Load);
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
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}