namespace CompanionKit.Concepts.ClientAPI.BackgroundImage
{
    partial class BackgroundImagePage
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(467, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click on Panel to change background image:";
            // 
            // BackgroundImagePage
            // 
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(467, 418);
            this.Text = "BackgroundImagePage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;



    }
}