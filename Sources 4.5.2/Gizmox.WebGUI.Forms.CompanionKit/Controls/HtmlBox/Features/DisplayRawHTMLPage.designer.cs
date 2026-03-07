namespace CompanionKit.Controls.HtmlBox.Features
{
    partial class DisplayRawHTMLPage
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
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjHtmlBox = new Gizmox.WebGUI.Forms.HtmlBox();
            this.mobjGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjHtmlBox);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(576, 250);
            this.mobjGroupBox.TabIndex = 0;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "HtmlBox with raw HTML";
            // 
            // mobjHtmlBox
            // 
            this.mobjHtmlBox.ContentType = "text/html";
            this.mobjHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHtmlBox.Html = "<HTML></HTML>";
            this.mobjHtmlBox.Location = new System.Drawing.Point(3, 17);
            this.mobjHtmlBox.Name = "mobjHtmlBox";
            this.mobjHtmlBox.Size = new System.Drawing.Size(570, 230);
            this.mobjHtmlBox.TabIndex = 0;
            // 
            // DisplayRawHTMLPage
            // 
            this.Controls.Add(this.mobjGroupBox);
            this.Size = new System.Drawing.Size(576, 250);
            this.Text = "DisplayRawHTMLPage";
            this.mobjGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private global::Gizmox.WebGUI.Forms.HtmlBox mobjHtmlBox;



    }
}
