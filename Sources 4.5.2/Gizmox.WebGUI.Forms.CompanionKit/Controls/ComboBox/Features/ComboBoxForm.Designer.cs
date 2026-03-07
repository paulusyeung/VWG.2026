namespace CompanionKit.Controls.ComboBox.Features
{
    partial class ComboBoxForm
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.mobjButton.Location = new System.Drawing.Point(91, 51);
            this.mobjButton.Name = "button1";
            this.mobjButton.Size = new System.Drawing.Size(75, 23);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Click Me!";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComboBoxForm
            // 
            this.Controls.Add(this.mobjButton);
            this.Size = new System.Drawing.Size(257, 124);
            this.Text = "ComboBoxForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;


    }
}
