namespace CompanionKit.Controls.Button.Functionality
{
    partial class TextImageRelationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextImageRelationPage));
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextImageLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjImageLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextImageCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjImageCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTLP.SetColumnSpan(this.mobjButton, 2);
            this.mobjButton.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjButton.Image"));
            this.mobjButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.mobjButton.Location = new System.Drawing.Point(92, 89);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(135, 65);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "button";
            this.mobjButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.mobjButton.UseVisualStyleBackColor = true;
            // 
            // mobjLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjLabel, 2);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Button with text and image:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextImageLbl
            // 
            this.mobjTextImageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextImageLbl.Location = new System.Drawing.Point(0, 192);
            this.mobjTextImageLbl.Name = "mobjTextImageLbl";
            this.mobjTextImageLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextImageLbl.Size = new System.Drawing.Size(160, 52);
            this.mobjTextImageLbl.TabIndex = 2;
            this.mobjTextImageLbl.Text = "Text Image Relation";
            this.mobjTextImageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjImageLbl
            // 
            this.mobjImageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjImageLbl.Location = new System.Drawing.Point(0, 244);
            this.mobjImageLbl.Name = "mobjImageLbl";
            this.mobjImageLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjImageLbl.Size = new System.Drawing.Size(160, 52);
            this.mobjImageLbl.TabIndex = 3;
            this.mobjImageLbl.Text = "Image Align";
            this.mobjImageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextLbl
            // 
            this.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLbl.Location = new System.Drawing.Point(0, 296);
            this.mobjTextLbl.Name = "mobjTextLbl";
            this.mobjTextLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextLbl.Size = new System.Drawing.Size(160, 54);
            this.mobjTextLbl.TabIndex = 4;
            this.mobjTextLbl.Text = "Text Align";
            this.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextImageCB
            // 
            this.mobjTextImageCB.AllowDrag = false;
            this.mobjTextImageCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextImageCB.FormattingEnabled = true;
            this.mobjTextImageCB.Location = new System.Drawing.Point(160, 207);
            this.mobjTextImageCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextImageCB.Name = "mobjTextImageCB";
            this.mobjTextImageCB.Size = new System.Drawing.Size(160, 25);
            this.mobjTextImageCB.TabIndex = 5;
            this.mobjTextImageCB.SelectedIndexChanged += new System.EventHandler(this.mobjTextImageCB_SelectedIndexChanged);
            // 
            // mobjImageCB
            // 
            this.mobjImageCB.AllowDrag = false;
            this.mobjImageCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjImageCB.FormattingEnabled = true;
            this.mobjImageCB.Location = new System.Drawing.Point(160, 259);
            this.mobjImageCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjImageCB.Name = "mobjImageCB";
            this.mobjImageCB.Size = new System.Drawing.Size(160, 25);
            this.mobjImageCB.TabIndex = 6;
            this.mobjImageCB.SelectedIndexChanged += new System.EventHandler(this.mobjImageCB_SelectedIndexChanged);
            // 
            // mobjTextCB
            // 
            this.mobjTextCB.AllowDrag = false;
            this.mobjTextCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextCB.FormattingEnabled = true;
            this.mobjTextCB.Location = new System.Drawing.Point(160, 312);
            this.mobjTextCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextCB.Name = "mobjTextCB";
            this.mobjTextCB.Size = new System.Drawing.Size(160, 25);
            this.mobjTextCB.TabIndex = 7;
            this.mobjTextCB.SelectedIndexChanged += new System.EventHandler(this.mobjTextCB_SelectedIndexChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjTextCB, 1, 4);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjImageCB, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjTextImageLbl, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjTextImageCB, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjImageLbl, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjTextLbl, 0, 4);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 8;
            // 
            // TextImageRelationPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "TextImageRelationPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Label mobjTextImageLbl;
        private Gizmox.WebGUI.Forms.Label mobjImageLbl;
        private Gizmox.WebGUI.Forms.Label mobjTextLbl;
        private Gizmox.WebGUI.Forms.ComboBox mobjTextImageCB;
        private Gizmox.WebGUI.Forms.ComboBox mobjImageCB;
        private Gizmox.WebGUI.Forms.ComboBox mobjTextCB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
