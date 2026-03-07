namespace CompanionKit.Controls.GroupBox.Features
{
	partial class BackgroundPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundPage));
            this.mobjGroupColor = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjSnow = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjMoccasin = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTransparent = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjGroupColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjGroupColor
            // 
            this.mobjGroupColor.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjGroupColor.Controls.Add(this.mobjSnow);
            this.mobjGroupColor.Controls.Add(this.mobjMoccasin);
            this.mobjGroupColor.Controls.Add(this.mobjTransparent);
            this.mobjGroupColor.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupColor.Location = new System.Drawing.Point(70, 50);
            this.mobjGroupColor.Name = "mobjGroupColor";
            this.mobjGroupColor.Size = new System.Drawing.Size(267, 183);
            this.mobjGroupColor.TabIndex = 0;
            this.mobjGroupColor.TabStop = false;
            this.mobjGroupColor.Text = "Background color";
            // 
            // mobjSnow
            // 
            this.mobjSnow.AutoSize = true;
            this.mobjSnow.Location = new System.Drawing.Point(15, 75);
            this.mobjSnow.Name = "mobjSnow";
            this.mobjSnow.Size = new System.Drawing.Size(221, 18);
            this.mobjSnow.TabIndex = 0;
            this.mobjSnow.Text = "Snow";
            this.mobjSnow.CheckedChanged += new System.EventHandler(this.Color_Changed);
            // 
            // mobjMoccasin
            // 
            this.mobjMoccasin.AutoSize = true;
            this.mobjMoccasin.Location = new System.Drawing.Point(15, 51);
            this.mobjMoccasin.Name = "mobjMoccasin";
            this.mobjMoccasin.Size = new System.Drawing.Size(221, 18);
            this.mobjMoccasin.TabIndex = 0;
            this.mobjMoccasin.Text = "Moccasin";
            this.mobjMoccasin.CheckedChanged += new System.EventHandler(this.Color_Changed);
            // 
            // mobjTransparent
            // 
            this.mobjTransparent.AutoSize = true;
            this.mobjTransparent.Checked = true;
            this.mobjTransparent.Location = new System.Drawing.Point(15, 27);
            this.mobjTransparent.Name = "mobjTransparent";
            this.mobjTransparent.Size = new System.Drawing.Size(221, 18);
            this.mobjTransparent.TabIndex = 0;
            this.mobjTransparent.Text = "Transparent";
            this.mobjTransparent.UseVisualStyleBackColor = true;
            this.mobjTransparent.CheckedChanged += new System.EventHandler(this.Color_Changed);
            // 
            // mobjPictureBox
            // 
            this.mobjPictureBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjPictureBox.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.mobjPictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"));
            this.mobjPictureBox.Location = new System.Drawing.Point(82, 154);
            this.mobjPictureBox.Name = "mobjPictureBox";
            this.mobjPictureBox.Size = new System.Drawing.Size(243, 70);
            this.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.mobjPictureBox.TabIndex = 2;
            this.mobjPictureBox.TabStop = false;
            // 
            // BackgroundPage
            // 
            this.Controls.Add(this.mobjGroupColor);
            this.Controls.Add(this.mobjPictureBox);
            this.Name = "BackgoundPage";
            this.Size = new System.Drawing.Size(400, 291);
            this.Text = "UserControl1";
            this.mobjGroupColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Gizmox.WebGUI.Forms.GroupBox mobjGroupColor;
		private Gizmox.WebGUI.Forms.RadioButton mobjSnow;
		private Gizmox.WebGUI.Forms.RadioButton mobjMoccasin;
		private Gizmox.WebGUI.Forms.RadioButton mobjTransparent;
        private Gizmox.WebGUI.Forms.PictureBox mobjPictureBox;


	}
}