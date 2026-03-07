namespace CompanionKit.Controls.Form.Features
{
    partial class MinimumSizeForm
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
            this.mobjBorderPanel = new Gizmox.WebGUI.Forms.Panel();
            this.SuspendLayout();
            // 
            // objBorderPanel
            // 
            this.mobjBorderPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.mobjBorderPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed;
            this.mobjBorderPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjBorderPanel.Name = "objBorderPanel";
            this.mobjBorderPanel.Size = new System.Drawing.Size(0, 0);
            this.mobjBorderPanel.TabIndex = 4;
            // 
            // MinimumSizeForm
            // 
            this.Controls.Add(this.mobjBorderPanel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(342, 140);
            this.Text = "Form with MinimumSize\'s border";
            this.ResumeLayout(false);

        }

        #endregion

        public Gizmox.WebGUI.Forms.Panel mobjBorderPanel;


    }
}