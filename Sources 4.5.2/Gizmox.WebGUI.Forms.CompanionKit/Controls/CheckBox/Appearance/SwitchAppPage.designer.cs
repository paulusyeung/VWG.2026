namespace CompanionKit.Controls.CheckBox.Appearance
{
    partial class SwitchAppPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjSwitchRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjNormalRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjCheckedLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Use RadioBoxes to swith between Button and Normal Appearance:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox.Location = new System.Drawing.Point(113, 257);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(94, 26);
            this.mobjCheckBox.TabIndex = 1;
            this.mobjCheckBox.Text = "Test";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjSwitchRB);
            this.mobjGroupBox.Controls.Add(this.mobjNormalRB);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 52);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(320, 192);
            this.mobjGroupBox.TabIndex = 2;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "CheckBox Appearance:";
            // 
            // mobjSwitchRB
            // 
            this.mobjSwitchRB.Location = new System.Drawing.Point(16, 78);
            this.mobjSwitchRB.Name = "mobjSwitchRB";
            this.mobjSwitchRB.Size = new System.Drawing.Size(100, 40);
            this.mobjSwitchRB.TabIndex = 1;
            this.mobjSwitchRB.Text = "Button";
            // 
            // mobjNormalRB
            // 
            this.mobjNormalRB.Checked = true;
            this.mobjNormalRB.Location = new System.Drawing.Point(16, 38);
            this.mobjNormalRB.Name = "mobjNormalRB";
            this.mobjNormalRB.Size = new System.Drawing.Size(100, 40);
            this.mobjNormalRB.TabIndex = 0;
            this.mobjNormalRB.Text = "Normal";
            this.mobjNormalRB.CheckedChanged += new System.EventHandler(this.mobjNormalRB_CheckedChanged);
            // 
            // mobjCheckedLabel
            // 
            this.mobjCheckedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckedLabel.Location = new System.Drawing.Point(0, 296);
            this.mobjCheckedLabel.Name = "mobjCheckedLabel";
            this.mobjCheckedLabel.Size = new System.Drawing.Size(320, 54);
            this.mobjCheckedLabel.TabIndex = 3;
            this.mobjCheckedLabel.Text = "Unchecked";
            this.mobjCheckedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjCheckedLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjGroupBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 4;
            // 
            // SwitchAppPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "SwitchAppPage";
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjSwitchRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjNormalRB;
        private Gizmox.WebGUI.Forms.Label mobjCheckedLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}