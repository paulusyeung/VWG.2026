namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class AddingToFormPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingToFormPage));
            this.mobjRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mobjRichTextBox
            // 
            this.mobjRichTextBox.AccessibleDescription = "";
            this.mobjRichTextBox.AccessibleName = "";
            this.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRichTextBox.Html = resources.GetString("mobjRichTextBox.Html");
            this.mobjRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.mobjRichTextBox.Name = "mobjRichTextBox";
            this.mobjRichTextBox.Size = new System.Drawing.Size(391, 306);
            this.mobjRichTextBox.TabIndex = 0;
            // 
            // AddingToFormPage
            // 
            this.Controls.Add(this.mobjRichTextBox);
            this.Size = new System.Drawing.Size(320, 300);
            this.Text = "AddingToFormPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RichTextBox mobjRichTextBox;

    }
}