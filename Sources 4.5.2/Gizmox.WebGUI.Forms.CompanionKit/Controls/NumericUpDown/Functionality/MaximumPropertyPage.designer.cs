namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    partial class MaximumPropertyPage
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
            this.demoNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.maximumNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.maximumLabel = new Gizmox.WebGUI.Forms.Label();
            this.demoNumericUpDownLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
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
            this.demoNumericUpDown.Location = new System.Drawing.Point(60, 271);
            this.demoNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoNumericUpDown.Name = "demoNumericUpDown";
            this.demoNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.demoNumericUpDown.TabIndex = 0;
            // 
            // maximumNumericUpDown
            // 
            this.maximumNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.maximumNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.maximumNumericUpDown.CurrentValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumNumericUpDown.Location = new System.Drawing.Point(60, 97);
            this.maximumNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.maximumNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.maximumNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.maximumNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumNumericUpDown.Name = "maximumNumericUpDown";
            this.maximumNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.maximumNumericUpDown.TabIndex = 1;
            this.maximumNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumNumericUpDown.ValueChanged += new System.EventHandler(this.maximumNumericUpDown_ValueChanged);
            // 
            // maximumLabel
            // 
            this.maximumLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.maximumLabel.Location = new System.Drawing.Point(10, 10);
            this.maximumLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(300, 67);
            this.maximumLabel.TabIndex = 2;
            this.maximumLabel.Text = "Maximum value";
            this.maximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(10, 184);
            this.demoNumericUpDownLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel";
            this.demoNumericUpDownLabel.Size = new System.Drawing.Size(300, 67);
            this.demoNumericUpDownLabel.TabIndex = 3;
            this.demoNumericUpDownLabel.Text = "Demonstrated NumericUpDown";
            this.demoNumericUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.maximumLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 0, 3);
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.maximumNumericUpDown, 0, 1);
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
            // MaximumPropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "MaximumPropertyPage";
            this.Load += new System.EventHandler(this.MaximumPropertyPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.NumericUpDown demoNumericUpDown;
        private Gizmox.WebGUI.Forms.NumericUpDown maximumNumericUpDown;
        private Gizmox.WebGUI.Forms.Label maximumLabel;
        private Gizmox.WebGUI.Forms.Label demoNumericUpDownLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}