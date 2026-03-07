namespace CompanionKit.Controls.FormBox.Features
{
    partial class ArgumentsPropertyPage
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
            this.aspPageBox = new Gizmox.WebGUI.Forms.Hosts.AspPageBox();
            this.SuspendLayout();
            // 
            // aspPageBox
            // 
            this.aspPageBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.aspPageBox.Location = new System.Drawing.Point(0, 0);
            this.aspPageBox.Name = "aspPageBox";
            this.aspPageBox.Path = "Controls\\FormBox\\Features\\ArgumentsPropertyWebForm.aspx";
            this.aspPageBox.Size = new System.Drawing.Size(391, 306);
            this.aspPageBox.TabIndex = 0;
            // 
            // ArgumentsPropertyPage
            // 
            this.Controls.Add(this.aspPageBox);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ArgumentsPropertyPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.AspPageBox aspPageBox;



    }
}