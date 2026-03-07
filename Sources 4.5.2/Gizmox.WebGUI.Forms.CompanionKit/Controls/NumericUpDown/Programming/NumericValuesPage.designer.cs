namespace CompanionKit.Controls.NumericUpDown.Programming
{
    partial class NumericValuesPage
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
            this.currentValueLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoNumericUpDownLabel
            // 
            this.demoNumericUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoNumericUpDownLabel.Location = new System.Drawing.Point(0, 0);
            this.demoNumericUpDownLabel.Name = "demoNumericUpDownLabel";
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
            0,
            0,
            0,
            0});
            this.demoNumericUpDown.Location = new System.Drawing.Point(170, 49);
            this.demoNumericUpDown.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.demoNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoNumericUpDown.Name = "numericUpDown1";
            this.demoNumericUpDown.Size = new System.Drawing.Size(140, 21);
            this.demoNumericUpDown.TabIndex = 1;
            this.demoNumericUpDown.ValueChanged += new System.EventHandler(this.demoNumericUpDown_ValueChanged);
            // 
            // currentValueLabel
            // 
            this.mobjTLP.SetColumnSpan(this.currentValueLabel, 2);
            this.currentValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.currentValueLabel.Location = new System.Drawing.Point(0, 120);
            this.currentValueLabel.Name = "currentValueLabel";
            this.currentValueLabel.Size = new System.Drawing.Size(320, 280);
            this.currentValueLabel.TabIndex = 2;
            this.currentValueLabel.Text = "Current value - ";
            this.currentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.demoNumericUpDownLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.demoNumericUpDown, 1, 0);
            this.mobjTLP.Controls.Add(this.currentValueLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 3;
            // 
            // NumericValuesPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "NumericValuesPage";
            this.Load += new System.EventHandler(this.NumericValuesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demoNumericUpDown)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label demoNumericUpDownLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown demoNumericUpDown;
        private Gizmox.WebGUI.Forms.Label currentValueLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}