namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ErrorView
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
            this.mobjTextError = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mobjTextError
            // 
            this.mobjTextError.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTextError.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjTextError.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextError.Location = new System.Drawing.Point(0, 0);
            this.mobjTextError.Multiline = true;
            this.mobjTextError.Name = "mobjTextError";
            this.mobjTextError.Size = new System.Drawing.Size(391, 306);
            this.mobjTextError.TabIndex = 0;
            // 
            // ErrorView
            // 
            this.Controls.Add(this.mobjTextError);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ErrorView";
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox mobjTextError;


    }
}