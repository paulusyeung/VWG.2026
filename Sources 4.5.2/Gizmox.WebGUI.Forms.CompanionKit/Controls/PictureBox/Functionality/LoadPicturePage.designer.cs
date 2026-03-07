namespace CompanionKit.Controls.PictureBox.Functionality
{
    partial class LoadPicturePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadPicturePage));
            this.mobjPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPictureBox
            // 
            this.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"));
            this.mobjPictureBox.Location = new System.Drawing.Point(10, 10);
            this.mobjPictureBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjPictureBox.Name = "mobjPictureBox";
            this.mobjPictureBox.Size = new System.Drawing.Size(300, 380);
            this.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.mobjPictureBox.TabIndex = 0;
            this.mobjPictureBox.TabStop = false;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjPictureBox, 0, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 1;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 1;
            // 
            // LoadPicturePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "LoadPicturePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PictureBox mobjPictureBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}