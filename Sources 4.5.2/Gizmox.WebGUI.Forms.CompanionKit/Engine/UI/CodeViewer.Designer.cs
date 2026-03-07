namespace Gizmox.WebGUI.Forms.CompanionKit.Engine
{
	partial class CodeViewer
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

		#region Visual WebGui Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.objCodeBox = new Gizmox.WebGUI.Forms.HtmlBox();
			this.SuspendLayout();
			// 
			// objCodeBox
			// 
			this.objCodeBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.objCodeBox.ContentType = "text/html";
			this.objCodeBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.objCodeBox.Expires = -1;
			this.objCodeBox.Html = "<HTML>Loading file ...</HTML>";
			this.objCodeBox.Location = new System.Drawing.Point(0, 0);
			this.objCodeBox.Name = "objCodeBox";
			this.objCodeBox.Size = new System.Drawing.Size(419, 466);
			this.objCodeBox.TabIndex = 0;
			// 
			// CodeViewer
			// 
			this.Controls.Add(this.objCodeBox);
			this.Size = new System.Drawing.Size(419, 466);
			this.Text = "CodeViewer";
			this.ResumeLayout(false);

		}

		#endregion

		private HtmlBox objCodeBox;


	}
}