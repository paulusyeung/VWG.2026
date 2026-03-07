namespace CompanionKit.Controls.Form.Features
{
    partial class MDIChildForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Location = new System.Drawing.Point(0, 28);
            this.mobjLabel.Name = "label1";
            this.mobjLabel.Size = new System.Drawing.Size(268, 43);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "This is Enable MDI Child Form #";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Location = new System.Drawing.Point(72, 108);
            this.mobjButton.Name = "button1";
            this.mobjButton.Size = new System.Drawing.Size(115, 43);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Click Me!";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // MDIChildForm
            // 
            this.Controls.Add(this.mobjButton);
            this.Controls.Add(this.mobjLabel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(268, 160);
            this.Text = "New Child Form #";
            this.EnabledChanged += new System.EventHandler(this.MDIChildForm_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion
        public static int idxChildForm = 1;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Button mobjButton;


    }
}