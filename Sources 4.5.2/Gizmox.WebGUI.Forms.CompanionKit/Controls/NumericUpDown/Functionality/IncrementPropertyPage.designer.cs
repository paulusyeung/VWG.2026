namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    partial class IncrementPropertyPage
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
            this.incrementalLabel = new Gizmox.WebGUI.Forms.Label();
            this.demoNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.incrementalNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementalNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(10, 10);
            this.demoNumericUpDownLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel";
            this.demoNumericUpDownLabel.Size = new System.Drawing.Size(300, 67);
            this.demoNumericUpDownLabel.TabIndex = 0;
            this.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown";
            this.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // incrementalLabel
            // 
            this.incrementalLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.incrementalLabel.Location = new System.Drawing.Point(10, 184);
            this.incrementalLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.incrementalLabel.Name = "incrementalLabel";
            this.incrementalLabel.Size = new System.Drawing.Size(300, 67);
            this.incrementalLabel.TabIndex = 1;
            this.incrementalLabel.Text = "Incremental";
            this.incrementalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.demoNumericUpDown.DecimalPlaces = 2;
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
            this.demoNumericUpDown.Name = "demoNumericUpDown";
            this.demoNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.demoNumericUpDown.TabIndex = 2;
            // 
            // incrementalNumericUpDown
            // 
            this.incrementalNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.incrementalNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.incrementalNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.incrementalNumericUpDown.DecimalPlaces = 2;
            this.incrementalNumericUpDown.Location = new System.Drawing.Point(60, 271);
            this.incrementalNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.incrementalNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.incrementalNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.incrementalNumericUpDown.Name = "incrementalNumericUpDown";
            this.incrementalNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.incrementalNumericUpDown.TabIndex = 3;
            this.incrementalNumericUpDown.ValueChanged += new System.EventHandler(this.incrementalNumericUpDown_ValueChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.incrementalNumericUpDown, 0, 3);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 0, 1);
            this.mobjTLP.Controls.Add(this.incrementalLabel, 0, 2);
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
            this.mobjTLP.TabIndex = 4;
            // 
            // IncrementPropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "IncrementPropertyPage";
            this.Load += new System.EventHandler(this.IncrementPropertyPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementalNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label demoNumericUpDownLabel;
        private Gizmox.WebGUI.Forms.Label incrementalLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown demoNumericUpDown;
        private Gizmox.WebGUI.Forms.NumericUpDown incrementalNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}