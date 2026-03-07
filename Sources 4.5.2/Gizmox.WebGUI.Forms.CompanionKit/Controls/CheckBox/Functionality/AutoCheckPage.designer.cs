namespace CompanionKit.Controls.CheckBox.Functionality
{
    partial class AutoCheckPage
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

        private void InitializeComponent()
		{
            this.mobjChkApprove = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMinScore = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjTxtScore = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLbl1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLbl2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjSetAutoCheck = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinScore)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjChkApprove
            // 
            this.mobjChkApprove.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjChkApprove.AutoCheck = false;
            this.mobjTLP.SetColumnSpan(this.mobjChkApprove, 2);
            this.mobjChkApprove.Location = new System.Drawing.Point(35, 80);
            this.mobjChkApprove.Name = "mobjChkApprove";
            this.mobjChkApprove.Size = new System.Drawing.Size(250, 50);
            this.mobjChkApprove.TabIndex = 1;
            this.mobjChkApprove.Text = "Approve the loan [auto check - False]";
            this.mobjChkApprove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjChkApprove.UseVisualStyleBackColor = true;
            this.mobjChkApprove.Click += new System.EventHandler(this.mobjChkApprove_Click);
            // 
            // mobjMinScore
            // 
            this.mobjMinScore.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMinScore.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMinScore.CurrentValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mobjMinScore.Location = new System.Drawing.Point(170, 304);
            this.mobjMinScore.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjMinScore.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mobjMinScore.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMinScore.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.mobjMinScore.Name = "numericUpDown1";
            this.mobjMinScore.Size = new System.Drawing.Size(140, 21);
            this.mobjMinScore.TabIndex = 2;
            this.mobjMinScore.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // mobjTxtScore
            // 
            this.mobjTxtScore.AllowDrag = false;
            this.mobjTxtScore.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTxtScore.Location = new System.Drawing.Point(170, 232);
            this.mobjTxtScore.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3);
            this.mobjTxtScore.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTxtScore.Name = "textBox1";
            this.mobjTxtScore.ReadOnly = true;
            this.mobjTxtScore.Size = new System.Drawing.Size(140, 25);
            this.mobjTxtScore.TabIndex = 3;
            this.mobjTxtScore.Text = "5";
            // 
            // mobjLbl1
            // 
            this.mobjLbl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLbl1.Location = new System.Drawing.Point(0, 210);
            this.mobjLbl1.Name = "mobjLbl1";
            this.mobjLbl1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLbl1.Size = new System.Drawing.Size(160, 70);
            this.mobjLbl1.TabIndex = 4;
            this.mobjLbl1.Text = "Credit history score";
            this.mobjLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjLbl2
            // 
            this.mobjLbl2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLbl2.Location = new System.Drawing.Point(0, 280);
            this.mobjLbl2.Name = "mobjLbl2";
            this.mobjLbl2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLbl2.Size = new System.Drawing.Size(160, 70);
            this.mobjLbl2.TabIndex = 4;
            this.mobjLbl2.Text = "Minimal score";
            this.mobjLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjSetAutoCheck
            // 
            this.mobjSetAutoCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTLP.SetColumnSpan(this.mobjSetAutoCheck, 2);
            this.mobjSetAutoCheck.Location = new System.Drawing.Point(75, 150);
            this.mobjSetAutoCheck.Name = "mobjSetAutoCheck";
            this.mobjSetAutoCheck.Size = new System.Drawing.Size(170, 50);
            this.mobjSetAutoCheck.TabIndex = 5;
            this.mobjSetAutoCheck.Text = "Toggle auto check";
            this.mobjSetAutoCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjSetAutoCheck.UseVisualStyleBackColor = true;
            this.mobjSetAutoCheck.Click += new System.EventHandler(this.mobjSetAutoCheck_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 70);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "CheckBox with changing AutoCheck property:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjMinScore, 1, 4);
            this.mobjTLP.Controls.Add(this.mobjTxtScore, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjLbl2, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjSetAutoCheck, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjLbl1, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjChkApprove, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 6;
            // 
            // AutoCheckPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinScore)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

		private Gizmox.WebGUI.Forms.CheckBox mobjChkApprove;
		private Gizmox.WebGUI.Forms.NumericUpDown mobjMinScore;
		private Gizmox.WebGUI.Forms.TextBox mobjTxtScore;
		private Gizmox.WebGUI.Forms.Label mobjLbl1;
		private Gizmox.WebGUI.Forms.Label mobjLbl2;
        private Gizmox.WebGUI.Forms.CheckBox mobjSetAutoCheck;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}
