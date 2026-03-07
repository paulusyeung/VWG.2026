namespace CompanionKit.Controls.Form.Programming
{
    partial class LoadEventForm
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
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "label1";
            this.mobjLabel.Size = new System.Drawing.Size(296, 91);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "This is form with registered handler of load event.";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Location = new System.Drawing.Point(78, 101);
            this.mobjButton.Name = "button1";
            this.mobjButton.Size = new System.Drawing.Size(144, 50);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Close";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // LoadEventForm
            // 
            this.Controls.Add(this.mobjButton);
            this.Controls.Add(this.mobjLabel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(296, 166);
            this.Text = "LoadEventForm";
            this.Load += new System.EventHandler(this.LoadEventForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjLabel;
        private global::Gizmox.WebGUI.Forms.Button mobjButton;


    }
}