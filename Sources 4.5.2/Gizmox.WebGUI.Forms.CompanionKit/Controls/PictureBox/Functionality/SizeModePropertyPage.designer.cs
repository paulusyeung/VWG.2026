namespace CompanionKit.Controls.PictureBox.Functionality
{
    partial class SizeModePropertyPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SizeModePropertyPage));
            this.mobjPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjSizeModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSizeModeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPictureBox
            // 
            this.mobjPictureBox.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.BackgroundImage"));
            this.mobjTLP.SetColumnSpan(this.mobjPictureBox, 2);
            this.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"));
            this.mobjPictureBox.Location = new System.Drawing.Point(10, 90);
            this.mobjPictureBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjPictureBox.Name = "mobjPictureBox";
            this.mobjPictureBox.Size = new System.Drawing.Size(300, 300);
            this.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
            this.mobjPictureBox.TabIndex = 0;
            this.mobjPictureBox.TabStop = false;
            // 
            // mobjSizeModeLabel
            // 
            this.mobjSizeModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSizeModeLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSizeModeLabel.Name = "mobjSizeModeLabel";
            this.mobjSizeModeLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjSizeModeLabel.Size = new System.Drawing.Size(160, 80);
            this.mobjSizeModeLabel.TabIndex = 1;
            this.mobjSizeModeLabel.Text = "Size mode for the PictureBox";
            this.mobjSizeModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjSizeModeComboBox
            // 
            this.mobjSizeModeComboBox.AllowDrag = false;
            this.mobjSizeModeComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjSizeModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjSizeModeComboBox.Location = new System.Drawing.Point(160, 29);
            this.mobjSizeModeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjSizeModeComboBox.Name = "mobjSizeModeComboBox";
            this.mobjSizeModeComboBox.Size = new System.Drawing.Size(160, 25);
            this.mobjSizeModeComboBox.TabIndex = 2;
            this.mobjSizeModeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjSizeModeComboBox_SelectedIndexChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjSizeModeLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjPictureBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjSizeModeComboBox, 1, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 3;
            // 
            // SizeModePropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "SizeModePropertyPage";
            this.Load += new System.EventHandler(this.SizeModePropertyPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PictureBox mobjPictureBox;
        private Gizmox.WebGUI.Forms.Label mobjSizeModeLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjSizeModeComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}