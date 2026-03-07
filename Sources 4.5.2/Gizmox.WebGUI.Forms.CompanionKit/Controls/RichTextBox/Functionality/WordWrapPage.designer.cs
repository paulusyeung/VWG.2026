namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class WordWrapPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordWrapPage));
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjIsWordWrap = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 80);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Change WordWrap property of RichTextBox:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjRichTextBox
            // 
            this.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRichTextBox.Html = resources.GetString("mobjRichTextBox.Html");
            this.mobjRichTextBox.Location = new System.Drawing.Point(10, 90);
            this.mobjRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjRichTextBox.Name = "mobjRichTextBox";
            this.mobjRichTextBox.Size = new System.Drawing.Size(300, 180);
            this.mobjRichTextBox.TabIndex = 2;
            // 
            // mobjIsWordWrap
            // 
            this.mobjIsWordWrap.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjIsWordWrap.Checked = true;
            this.mobjIsWordWrap.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjIsWordWrap.Location = new System.Drawing.Point(100, 315);
            this.mobjIsWordWrap.Name = "mobjIsWordWrap";
            this.mobjIsWordWrap.Size = new System.Drawing.Size(120, 50);
            this.mobjIsWordWrap.TabIndex = 6;
            this.mobjIsWordWrap.Text = "WordWrap";
            this.mobjIsWordWrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjIsWordWrap.CheckedChanged += new System.EventHandler(this.mobjIsWordWrap_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjIsWordWrap, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjRichTextBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 7;
            // 
            // WordWrapPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "WordWrapPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.RichTextBox mobjRichTextBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsWordWrap;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}