namespace CompanionKit.Controls.Form.Features
{
    partial class WindowTypeForm
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
            this.mobjCloseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjCloseButton
            // 
            this.mobjCloseButton.AccessibleDescription = "";
            this.mobjCloseButton.AccessibleName = "";
            this.mobjCloseButton.Location = new System.Drawing.Point(126, 93);
            this.mobjCloseButton.Name = "closeButton";
            this.mobjCloseButton.Size = new System.Drawing.Size(132, 42);
            this.mobjCloseButton.TabIndex = 0;
            this.mobjCloseButton.Text = "Close";
            this.mobjCloseButton.UseVisualStyleBackColor = true;
            this.mobjCloseButton.Click += new System.EventHandler(this.mobjCloseButton_Click);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Location = new System.Drawing.Point(2, 9);
            this.mobjLabel.Name = "label1";
            this.mobjLabel.Size = new System.Drawing.Size(376, 62);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "This is Modaless form. Click on button for closing it.";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindowTypeForm
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjCloseButton);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(378, 153);
            this.Text = "Window Type Form";
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Button mobjCloseButton;
        private global::Gizmox.WebGUI.Forms.Label mobjLabel;


    }
}