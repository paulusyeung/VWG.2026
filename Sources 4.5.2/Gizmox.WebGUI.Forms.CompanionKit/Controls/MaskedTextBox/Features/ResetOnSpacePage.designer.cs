namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class ResetOnSpacePage
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
            this.mobjMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mobjMaskedTextBox
            // 
            this.mobjMaskedTextBox.AccessibleDescription = "";
            this.mobjMaskedTextBox.AccessibleName = "";
            this.mobjMaskedTextBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjMaskedTextBox.CustomStyle = "Masked";
            this.mobjMaskedTextBox.Location = new System.Drawing.Point(31, 50);
            this.mobjMaskedTextBox.Mask = "000-LLL-CCC";
            this.mobjMaskedTextBox.Name = "mobjMaskedTextBox";
            this.mobjMaskedTextBox.Size = new System.Drawing.Size(128, 30);
            this.mobjMaskedTextBox.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(28, 23);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "MaskedTextBox:";
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AccessibleDescription = "";
            this.mobjCheckBox.AccessibleName = "";
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Checked = true;
            this.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjCheckBox.Location = new System.Drawing.Point(31, 104);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(100, 17);
            this.mobjCheckBox.TabIndex = 2;
            this.mobjCheckBox.Text = "ResetOnSpace ";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // ResetOnSpacePage
            // 
            this.Controls.Add(this.mobjCheckBox);
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjMaskedTextBox);
            this.Size = new System.Drawing.Size(191, 150);
            this.Text = "ResetOnSpacePage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MaskedTextBox mobjMaskedTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;



    }
}