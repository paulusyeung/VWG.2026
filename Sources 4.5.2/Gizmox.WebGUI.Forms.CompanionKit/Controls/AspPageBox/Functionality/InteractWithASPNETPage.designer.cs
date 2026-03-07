namespace CompanionKit.Controls.AspPageBox.Functionality
{
    partial class InteractWithASPNETPage
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
            this.demoAspPageBox = new MyAspPageBox();
            this.SuspendLayout();
            // 
            // demoAspPageBox
            // 
            this.demoAspPageBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoAspPageBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoAspPageBox.Location = new System.Drawing.Point(0, 0);
            this.demoAspPageBox.Name = "demoAspPageBox";
            this.demoAspPageBox.Path = null;
            this.demoAspPageBox.Size = new System.Drawing.Size(391, 306);
            this.demoAspPageBox.TabIndex = 0;
            // 
            // InteractWithASPNETPage
            // 
            this.Controls.Add(this.demoAspPageBox);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "InteractWithASPNETPage";
            this.Load += new System.EventHandler(this.InteractWithASPNETPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyAspPageBox demoAspPageBox;



    }
}