namespace CompanionKit.Controls.Form.Programming
{
    partial class OrientationChangedPage
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
            this.mobjOpenButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjOpenButton
            // 
            this.mobjOpenButton.AccessibleDescription = "";
            this.mobjOpenButton.AccessibleName = "";
            this.mobjOpenButton.Location = new System.Drawing.Point(77, 89);
            this.mobjOpenButton.Name = "mobjOpenButton";
            this.mobjOpenButton.Size = new System.Drawing.Size(169, 57);
            this.mobjOpenButton.TabIndex = 0;
            this.mobjOpenButton.Text = "Open Form";
            this.mobjOpenButton.Click += new System.EventHandler(this.mobjOpenButton_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(419, 65);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Click button to open form and then rotate the device to see event fire:";
            // 
            // OrientationChangedPage
            // 
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjOpenButton);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "OrientationChangedPage";
            this.ResumeLayout(false);

        }

        #endregion


        private Gizmox.WebGUI.Forms.Button mobjOpenButton;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;

    }
}