namespace CompanionKit.Controls.CheckBox.Appearance
{
    partial class CheckAlignPage
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
            this.mobjTextCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCheckCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
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
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 77);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "CheckBox with changing Check Align and Text Align properties:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextCB
            // 
            this.mobjTextCB.AllowDrag = false;
            this.mobjTextCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextCB.FormattingEnabled = true;
            this.mobjTextCB.Location = new System.Drawing.Point(170, 221);
            this.mobjTextCB.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjTextCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextCB.Name = "mobjTextCB";
            this.mobjTextCB.Size = new System.Drawing.Size(140, 25);
            this.mobjTextCB.TabIndex = 2;
            this.mobjTextCB.SelectedIndexChanged += new System.EventHandler(this.mobjTextCB_SelectedIndexChanged);
            // 
            // mobjCheckCB
            // 
            this.mobjCheckCB.AllowDrag = false;
            this.mobjCheckCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjCheckCB.FormattingEnabled = true;
            this.mobjCheckCB.Location = new System.Drawing.Point(170, 299);
            this.mobjCheckCB.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjCheckCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjCheckCB.Name = "mobjCheckCB";
            this.mobjCheckCB.Size = new System.Drawing.Size(140, 25);
            this.mobjCheckCB.TabIndex = 3;
            this.mobjCheckCB.SelectedIndexChanged += new System.EventHandler(this.mobjCheckCB_SelectedIndexChanged);
            // 
            // mobjTextLbl
            // 
            this.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLbl.Location = new System.Drawing.Point(0, 193);
            this.mobjTextLbl.Name = "mobjTextLbl";
            this.mobjTextLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextLbl.Size = new System.Drawing.Size(160, 77);
            this.mobjTextLbl.TabIndex = 4;
            this.mobjTextLbl.Text = "Text Align";
            this.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjCheckLbl
            // 
            this.mobjCheckLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckLbl.Location = new System.Drawing.Point(0, 270);
            this.mobjCheckLbl.Name = "mobjCheckLbl";
            this.mobjCheckLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjCheckLbl.Size = new System.Drawing.Size(160, 80);
            this.mobjCheckLbl.TabIndex = 5;
            this.mobjCheckLbl.Text = "Check Align";
            this.mobjCheckLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Teal);
            this.mobjCheckBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTLP.SetColumnSpan(this.mobjCheckBox, 2);
            this.mobjCheckBox.Location = new System.Drawing.Point(75, 110);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(170, 50);
            this.mobjCheckBox.TabIndex = 6;
            this.mobjCheckBox.Text = "Test Text Alignment";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjCheckCB, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjCheckLbl, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjTextCB, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjTextLbl, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 7;
            // 
            // CheckAlignPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "CheckAlignPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjTextCB;
        private Gizmox.WebGUI.Forms.ComboBox mobjCheckCB;
        private Gizmox.WebGUI.Forms.Label mobjTextLbl;
        private Gizmox.WebGUI.Forms.Label mobjCheckLbl;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
