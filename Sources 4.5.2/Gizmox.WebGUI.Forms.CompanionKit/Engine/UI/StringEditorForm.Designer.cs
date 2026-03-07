namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	partial class StringEditorForm
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
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjTxtEdited = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjCmdCancel = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdOK = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdClear = new Gizmox.WebGUI.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.mobjTxtEdited);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(9, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(384, 194);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// mobjTxtEdited
			// 
			this.mobjTxtEdited.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjTxtEdited.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjTxtEdited.Location = new System.Drawing.Point(3, 17);
			this.mobjTxtEdited.Multiline = true;
			this.mobjTxtEdited.Name = "textBox1";
			this.mobjTxtEdited.Size = new System.Drawing.Size(378, 174);
			this.mobjTxtEdited.TabIndex = 0;
			// 
			// mobjCmdCancel
			// 
			this.mobjCmdCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdCancel.Location = new System.Drawing.Point(315, 210);
			this.mobjCmdCancel.Name = "mobjCmdCancel";
			this.mobjCmdCancel.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdCancel.TabIndex = 2;
			this.mobjCmdCancel.Text = "Cancel";
			this.mobjCmdCancel.UseVisualStyleBackColor = true;
			this.mobjCmdCancel.Click += new System.EventHandler(this.mobjCmdCancel_Click);
			// 
			// mobjCmdOK
			// 
			this.mobjCmdOK.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdOK.Location = new System.Drawing.Point(237, 210);
			this.mobjCmdOK.Name = "mobjCmdOK";
			this.mobjCmdOK.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdOK.TabIndex = 1;
			this.mobjCmdOK.Text = "OK";
			this.mobjCmdOK.UseVisualStyleBackColor = true;
			this.mobjCmdOK.Click += new System.EventHandler(this.mobjCmdOK_Click);
			// 
			// mobjCmdClear
			// 
			this.mobjCmdClear.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjCmdClear.Location = new System.Drawing.Point(12, 210);
			this.mobjCmdClear.Name = "mobjCmdClear";
			this.mobjCmdClear.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdClear.TabIndex = 1;
			this.mobjCmdClear.Text = "Clear";
			this.mobjCmdClear.UseVisualStyleBackColor = true;
			this.mobjCmdClear.Click += new System.EventHandler(this.mobjCmdClear_Click);
			// 
			// StringEditorForm
			// 
			this.Controls.Add(this.mobjCmdClear);
			this.Controls.Add(this.mobjCmdOK);
			this.Controls.Add(this.mobjCmdCancel);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.SizableToolWindow;
			this.Size = new System.Drawing.Size(402, 242);
			this.Text = "StringEditorForm";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox1;
		private TextBox mobjTxtEdited;
		private Button mobjCmdCancel;
		private Button mobjCmdOK;
		private Button mobjCmdClear;


	}
}