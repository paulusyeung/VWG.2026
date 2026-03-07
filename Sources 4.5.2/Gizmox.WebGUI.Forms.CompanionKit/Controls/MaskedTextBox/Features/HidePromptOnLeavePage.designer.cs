namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class HidePromptOnLeavePage
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
            this.demoMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.hidePromptOnLeaveCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.demoMaskedTextBox2 = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoMaskedTextBox
            // 
            this.demoMaskedTextBox.AllowDrag = false;
            this.demoMaskedTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.demoMaskedTextBox.CustomStyle = "Masked";
            this.demoMaskedTextBox.Location = new System.Drawing.Point(163, 177);
            this.demoMaskedTextBox.Mask = "00/00/0000 90:00";
            this.demoMaskedTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoMaskedTextBox.Name = "demoMaskedTextBox";
            this.demoMaskedTextBox.Size = new System.Drawing.Size(154, 25);
            this.demoMaskedTextBox.TabIndex = 2;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 120);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel1.Size = new System.Drawing.Size(160, 140);
            this.mobjLabel1.TabIndex = 1;
            this.mobjLabel1.Text = "Enter text [1]";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hidePromptOnLeaveCheckBox
            // 
            this.hidePromptOnLeaveCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTLP.SetColumnSpan(this.hidePromptOnLeaveCheckBox, 2);
            this.hidePromptOnLeaveCheckBox.Location = new System.Drawing.Point(75, 35);
            this.hidePromptOnLeaveCheckBox.Name = "hidePromptOnLeaveCheckBox";
            this.hidePromptOnLeaveCheckBox.Size = new System.Drawing.Size(170, 50);
            this.hidePromptOnLeaveCheckBox.TabIndex = 0;
            this.hidePromptOnLeaveCheckBox.Text = "Hide prompt on leave";
            this.hidePromptOnLeaveCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hidePromptOnLeaveCheckBox.UseVisualStyleBackColor = true;
            this.hidePromptOnLeaveCheckBox.CheckedChanged += new System.EventHandler(this.hidePromptOnLeaveCheckBox_CheckedChanged);
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 260);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel2.Size = new System.Drawing.Size(160, 140);
            this.mobjLabel2.TabIndex = 3;
            this.mobjLabel2.Text = "Enter text [2]";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // demoMaskedTextBox2
            // 
            this.demoMaskedTextBox2.AllowDrag = false;
            this.demoMaskedTextBox2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.demoMaskedTextBox2.CustomStyle = "Masked";
            this.demoMaskedTextBox2.Location = new System.Drawing.Point(163, 317);
            this.demoMaskedTextBox2.Mask = "00/00/0000 90:00";
            this.demoMaskedTextBox2.MaximumSize = new System.Drawing.Size(200, 0);
            this.demoMaskedTextBox2.Name = "demoMaskedTextBox2";
            this.demoMaskedTextBox2.Size = new System.Drawing.Size(154, 25);
            this.demoMaskedTextBox2.TabIndex = 4;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.hidePromptOnLeaveCheckBox, 0, 0);
            this.mobjTLP.Controls.Add(this.demoMaskedTextBox2, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjLabel1, 0, 1);
            this.mobjTLP.Controls.Add(this.demoMaskedTextBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjLabel2, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 5;
            // 
            // HidePromptOnLeavePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "HidePromptOnLeavePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MaskedTextBox demoMaskedTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.CheckBox hidePromptOnLeaveCheckBox;
		private Gizmox.WebGUI.Forms.Label mobjLabel2;
		private Gizmox.WebGUI.Forms.MaskedTextBox demoMaskedTextBox2;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}