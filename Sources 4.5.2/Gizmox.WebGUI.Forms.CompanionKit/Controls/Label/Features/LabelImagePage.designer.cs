namespace CompanionKit.Controls.LabelFolder.Features
{
    partial class LabelImagePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelImagePage));
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.cmbImageAlignment = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjLabel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.mobjLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTLP.SetColumnSpan(this.mobjLabel, 2);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjLabel.Image"));
            this.mobjLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjLabel.Location = new System.Drawing.Point(10, 10);
            this.mobjLabel.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(300, 155);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Tabel Text";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbImageAlignment
            // 
            this.cmbImageAlignment.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.cmbImageAlignment.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbImageAlignment.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageAlignment.FormattingEnabled = true;
            this.cmbImageAlignment.Location = new System.Drawing.Point(160, 252);
            this.cmbImageAlignment.MaximumSize = new System.Drawing.Size(200, 0);
            this.cmbImageAlignment.Name = "cmbImageAlignment";
            this.cmbImageAlignment.Size = new System.Drawing.Size(160, 25);
            this.cmbImageAlignment.TabIndex = 1;
            this.cmbImageAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbImageAlignment_SelectedIndexChanged);
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 175);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjInfoLabel.Size = new System.Drawing.Size(160, 175);
            this.mobjInfoLabel.TabIndex = 2;
            this.mobjInfoLabel.Text = "Image alignment";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.cmbImageAlignment, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 3;
            // 
            // LabelImagePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "LabelImagePage";
            this.Load += new System.EventHandler(this.LabelImagePage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ComboBox cmbImageAlignment;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}