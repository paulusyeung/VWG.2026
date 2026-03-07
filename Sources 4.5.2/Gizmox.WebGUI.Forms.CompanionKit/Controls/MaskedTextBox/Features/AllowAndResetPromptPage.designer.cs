namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class AllowAndResetPromptPage
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
            this.mobjResetCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjAllowCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mobjResetCheckBox
            // 
            this.mobjResetCheckBox.AccessibleDescription = "";
            this.mobjResetCheckBox.AccessibleName = "";
            this.mobjResetCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjResetCheckBox.AutoSize = true;
            this.mobjResetCheckBox.Checked = true;
            this.mobjResetCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjResetCheckBox.Location = new System.Drawing.Point(31, 104);
            this.mobjResetCheckBox.Name = "mobjResetCheckBox";
            this.mobjResetCheckBox.Size = new System.Drawing.Size(102, 17);
            this.mobjResetCheckBox.TabIndex = 2;
            this.mobjResetCheckBox.Text = "ResetOnPrompt";
            this.mobjResetCheckBox.CheckedChanged += new System.EventHandler(this.mobjResetCheckBox_CheckedChanged);
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
            // mobjMaskedTextBox
            // 
            this.mobjMaskedTextBox.AccessibleDescription = "";
            this.mobjMaskedTextBox.AccessibleName = "";
            this.mobjMaskedTextBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjMaskedTextBox.CustomStyle = "Masked";
            this.mobjMaskedTextBox.Location = new System.Drawing.Point(31, 50);
            this.mobjMaskedTextBox.Mask = "000-LLL-CCC";
            this.mobjMaskedTextBox.Name = "mobjMaskedTextBox";
            this.mobjMaskedTextBox.Size = new System.Drawing.Size(152, 30);
            this.mobjMaskedTextBox.TabIndex = 0;
            // 
            // mobjAllowCheckBox
            // 
            this.mobjAllowCheckBox.AccessibleDescription = "";
            this.mobjAllowCheckBox.AccessibleName = "";
            this.mobjAllowCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAllowCheckBox.AutoSize = true;
            this.mobjAllowCheckBox.Checked = true;
            this.mobjAllowCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjAllowCheckBox.Location = new System.Drawing.Point(31, 133);
            this.mobjAllowCheckBox.Name = "mobjAllowCheckBox";
            this.mobjAllowCheckBox.Size = new System.Drawing.Size(123, 17);
            this.mobjAllowCheckBox.TabIndex = 3;
            this.mobjAllowCheckBox.Text = "AllowPromptAsInput";
            this.mobjAllowCheckBox.CheckedChanged += new System.EventHandler(this.mobjAllowCheckBox_CheckedChanged);
            // 
            // AllowAndResetPromptPage
            // 
            this.Controls.Add(this.mobjAllowCheckBox);
            this.Controls.Add(this.mobjMaskedTextBox);
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjResetCheckBox);
            this.Size = new System.Drawing.Size(222, 191);
            this.Text = "AllowAndResetPromptPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjResetCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.MaskedTextBox mobjMaskedTextBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjAllowCheckBox;



    }
}