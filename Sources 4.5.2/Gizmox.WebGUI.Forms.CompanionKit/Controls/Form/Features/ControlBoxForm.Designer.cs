namespace CompanionKit.Controls.Form.Features
{
    partial class ControlBoxForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCloseButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AccessibleDescription = "";
            this.mobjCheckBox.AccessibleName = "";
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Checked = true;
            this.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjCheckBox.Location = new System.Drawing.Point(89, 50);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(134, 17);
            this.mobjCheckBox.TabIndex = 0;
            this.mobjCheckBox.Text = "Show ControlBox";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjCloseButton
            // 
            this.mobjCloseButton.AccessibleDescription = "";
            this.mobjCloseButton.AccessibleName = "";
            this.mobjCloseButton.Location = new System.Drawing.Point(89, 86);
            this.mobjCloseButton.Name = "mobjCloseButton";
            this.mobjCloseButton.Size = new System.Drawing.Size(134, 50);
            this.mobjCloseButton.TabIndex = 1;
            this.mobjCloseButton.Text = "Close dialog";
            this.mobjCloseButton.Visible = false;
            this.mobjCloseButton.Click += new System.EventHandler(this.mobjCloseButton_Click);
            // 
            // ControlBoxForm
            // 
            this.Controls.Add(this.mobjCloseButton);
            this.Controls.Add(this.mobjCheckBox);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(316, 155);
            this.Text = "ControlBox Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjCloseButton;


    }
}