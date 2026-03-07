namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class HtmlTextPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjHtmlButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTextButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Click appropriate button to set Html or Text property:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTLP.SetColumnSpan(this.mobjTextBox, 2);
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextBox.Location = new System.Drawing.Point(5, 65);
            this.mobjTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjTextBox.Multiline = true;
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(310, 130);
            this.mobjTextBox.TabIndex = 1;
            this.mobjTextBox.Text = "<b>This is bold text</b>\r\n<ol>\r\n  <li>This is</li>\r\n  <li>ordered</li>\r\n  <li>lis" +
    "t</li>\r\n</ol>";
            // 
            // mobjRichTextBox
            // 
            this.mobjTLP.SetColumnSpan(this.mobjRichTextBox, 2);
            this.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRichTextBox.Location = new System.Drawing.Point(5, 265);
            this.mobjRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjRichTextBox.Name = "mobjRichTextBox";
            this.mobjRichTextBox.Size = new System.Drawing.Size(310, 130);
            this.mobjRichTextBox.TabIndex = 2;
            // 
            // mobjHtmlButton
            // 
            this.mobjHtmlButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHtmlButton.Location = new System.Drawing.Point(5, 205);
            this.mobjHtmlButton.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjHtmlButton.MaximumSize = new System.Drawing.Size(0, 80);
            this.mobjHtmlButton.Name = "mobjHtmlButton";
            this.mobjHtmlButton.Size = new System.Drawing.Size(150, 50);
            this.mobjHtmlButton.TabIndex = 3;
            this.mobjHtmlButton.Text = "Set as Html";
            this.mobjHtmlButton.Click += new System.EventHandler(this.mobjHtmlButton_Click);
            // 
            // mobjTextButton
            // 
            this.mobjTextButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextButton.Location = new System.Drawing.Point(165, 205);
            this.mobjTextButton.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjTextButton.MaximumSize = new System.Drawing.Size(0, 80);
            this.mobjTextButton.Name = "mobjTextButton";
            this.mobjTextButton.Size = new System.Drawing.Size(150, 50);
            this.mobjTextButton.TabIndex = 4;
            this.mobjTextButton.Text = "Set as Text";
            this.mobjTextButton.Click += new System.EventHandler(this.mobjTextButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjTextButton, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjTextBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjHtmlButton, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjRichTextBox, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 5;
            // 
            // HtmlTextPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "HtmlTextPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.RichTextBox mobjRichTextBox;
        private Gizmox.WebGUI.Forms.Button mobjHtmlButton;
        private Gizmox.WebGUI.Forms.Button mobjTextButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
  

    }
}