namespace CompanionKit.Concepts.ClientAPI.ColorAndText
{
    partial class ColorAndTextPage
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
            this.objCustomStateButton = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.ColorAndText.CustomStateButton();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objCustomStateButtonCS
            // 
            this.objCustomStateButton.CustomStyle = "CustomStateButtonSkin";
            this.objCustomStateButton.Location = new System.Drawing.Point(24, 84);
            this.objCustomStateButton.Name = "objCustomStateButton";
            this.objCustomStateButton.Size = new System.Drawing.Size(150, 150);
            this.objCustomStateButton.TabIndex = 0;
            this.objCustomStateButton.Text = "Undefined";
            // 
            // objLabel
            // 
            this.objLabel.AutoSize = true;
            this.objLabel.Location = new System.Drawing.Point(21, 21);
            this.objLabel.Name = "label1";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 1;
            this.objLabel.Text = "Press the button to change state:";
            // 
            // ColorAndTextPage
            // 
            this.Controls.Add(this.objLabel);
            this.Controls.Add(this.objCustomStateButton);
            this.Size = new System.Drawing.Size(202, 277);
            this.Text = "ColorAndTextPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.ColorAndText.CustomStateButton objCustomStateButton;
        private Gizmox.WebGUI.Forms.Label objLabel;



    }
}