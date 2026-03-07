namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    partial class MinimumPropertypage
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
            this.minimumLabel = new Gizmox.WebGUI.Forms.Label();
            this.minimumNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.demoNumericUpDownLabel = new Gizmox.WebGUI.Forms.Label();
            this.demoNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.minimumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimumLabel
            // 
            this.minimumLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.minimumLabel.Location = new System.Drawing.Point(10, 10);
            this.minimumLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(300, 67);
            this.minimumLabel.TabIndex = 0;
            this.minimumLabel.Text = "Minimum value";
            this.minimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minimumNumericUpDown
            // 
            this.minimumNumericUpDown.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.minimumNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.minimumNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.minimumNumericUpDown.Location = new System.Drawing.Point(60, 97);
            this.minimumNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.minimumNumericUpDown.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.minimumNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.minimumNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minimumNumericUpDown.Name = "minimumNumericUpDown";
            this.minimumNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.minimumNumericUpDown.TabIndex = 1;
            this.minimumNumericUpDown.ValueChanged += new System.EventHandler(this.minimumNumericUpDown_ValueChanged);
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(10, 184);
            this.demoNumericUpDownLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel";
            this.demoNumericUpDownLabel.Size = new System.Drawing.Size(300, 67);
            this.demoNumericUpDownLabel.TabIndex = 2;
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
            this.demoNumericUpDown.Location = new System.Drawing.Point(60, 271);
            this.demoNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.demoNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoNumericUpDown.Name = "demoNumericUpDown";
            this.demoNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.demoNumericUpDown.TabIndex = 3;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.minimumLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 0, 3);
            this.mobjTLP.Controls.Add(this.minimumNumericUpDown, 0, 1);
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "tableLayoutPanel1";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 4;
            // 
            // MinimumPropertypage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "MinimumPropertypage";
            this.Load += new System.EventHandler(this.MinimumPropertypage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minimumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label minimumLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown minimumNumericUpDown;
        private Gizmox.WebGUI.Forms.Label demoNumericUpDownLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown demoNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}