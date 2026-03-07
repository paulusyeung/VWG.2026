namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	partial class ResourceLinkForm
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
			this.mobjResources = new Gizmox.WebGUI.Forms.CheckedListBox();
			this.mobjItemsTree = new Gizmox.WebGUI.Forms.CompanionKit.UI.NavigationTree();
			this.mobjBtnLink = new Gizmox.WebGUI.Forms.Button();
			this.mobjBtnCancel = new Gizmox.WebGUI.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.mobjResources);
			this.groupBox1.Controls.Add(this.mobjItemsTree);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(9, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(683, 419);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select item and check resources to link:";
			// 
			// mobjResources
			// 
			this.mobjResources.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjResources.Location = new System.Drawing.Point(278, 18);
			this.mobjResources.Name = "mobjResources";
			this.mobjResources.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
			this.mobjResources.Size = new System.Drawing.Size(392, 388);
			this.mobjResources.TabIndex = 1;
			// 
			// mobjItemsTree
			// 
			this.mobjItemsTree.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjItemsTree.Location = new System.Drawing.Point(7, 19);
			this.mobjItemsTree.Name = "mobjItemsTree";
			this.mobjItemsTree.Size = new System.Drawing.Size(266, 388);
			this.mobjItemsTree.TabIndex = 0;
			// 
			// mobjBtnLink
			// 
			this.mobjBtnLink.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjBtnLink.Location = new System.Drawing.Point(529, 438);
			this.mobjBtnLink.Name = "mobjBtnLink";
			this.mobjBtnLink.Size = new System.Drawing.Size(75, 23);
			this.mobjBtnLink.TabIndex = 1;
			this.mobjBtnLink.Text = "Link";
			this.mobjBtnLink.UseVisualStyleBackColor = true;
			this.mobjBtnLink.Click += new System.EventHandler(this.BtnOKCancel_Click);
			// 
			// mobjBtnCancel
			// 
			this.mobjBtnCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjBtnCancel.Location = new System.Drawing.Point(604, 438);
			this.mobjBtnCancel.Name = "mobjBtnCancel";
			this.mobjBtnCancel.Size = new System.Drawing.Size(75, 23);
			this.mobjBtnCancel.TabIndex = 2;
			this.mobjBtnCancel.Text = "Cancel";
			this.mobjBtnCancel.UseVisualStyleBackColor = true;
			this.mobjBtnCancel.Click += new System.EventHandler(this.BtnOKCancel_Click);
			// 
			// ResourceLinkForm
			// 
			this.AcceptButton = this.mobjBtnLink;
			this.CancelButton = this.mobjBtnCancel;
			this.Controls.Add(this.mobjBtnCancel);
			this.Controls.Add(this.mobjBtnLink);
			this.Controls.Add(this.groupBox1);
			this.Size = new System.Drawing.Size(709, 470);
			this.Text = "ResourceLinkForm";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox1;
		private CheckedListBox mobjResources;
		private Gizmox.WebGUI.Forms.CompanionKit.UI.NavigationTree mobjItemsTree;
		private Button mobjBtnLink;
		private Button mobjBtnCancel;



	}
}