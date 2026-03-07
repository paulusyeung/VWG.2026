namespace Gizmox.WebGUI.Forms.Access
{
	partial class Logon
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logon));
			this.mobjtxtUsername = new Gizmox.WebGUI.Forms.TextBox();
			this.lblUsername = new Gizmox.WebGUI.Forms.Label();
			this.lblPassword = new Gizmox.WebGUI.Forms.Label();
			this.mobjtxtPassword = new Gizmox.WebGUI.Forms.TextBox();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.mobjChkRemember = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjCmdCancel = new Gizmox.WebGUI.Forms.Button();
			this.lblError = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmdLogon = new Gizmox.WebGUI.Forms.Button();
			this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjtxtUsername
			// 
			this.mobjtxtUsername.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjtxtUsername.Location = new System.Drawing.Point(118, 88);
			this.mobjtxtUsername.Name = "mobjtxtUsername";
			this.mobjtxtUsername.Size = new System.Drawing.Size(259, 20);
			this.mobjtxtUsername.TabIndex = 1;
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.Location = new System.Drawing.Point(42, 91);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(35, 13);
			this.lblUsername.TabIndex = 0;
			this.lblUsername.Text = "Username";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(42, 117);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(35, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Password";
			// 
			// mobjtxtPassword
			// 
			this.mobjtxtPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjtxtPassword.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.F12;
			this.mobjtxtPassword.Location = new System.Drawing.Point(118, 114);
			this.mobjtxtPassword.Name = "mobjtxtPassword";
			this.mobjtxtPassword.PasswordChar = '*';
			this.mobjtxtPassword.Size = new System.Drawing.Size(259, 20);
			this.mobjtxtPassword.TabIndex = 3;
			this.mobjtxtPassword.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.mobjtxtPassword_EnterKeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.mobjChkRemember);
			this.groupBox1.Controls.Add(this.mobjCmdCancel);
			this.groupBox1.Controls.Add(this.lblError);
			this.groupBox1.Controls.Add(this.mobjCmdLogon);
			this.groupBox1.Controls.Add(this.lblPassword);
			this.groupBox1.Controls.Add(this.mobjtxtPassword);
			this.groupBox1.Controls.Add(this.mobjtxtUsername);
			this.groupBox1.Controls.Add(this.lblUsername);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(9, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(442, 282);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
			this.pictureBox1.Location = new System.Drawing.Point(45, 34);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(27, 29);
			this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label1.Location = new System.Drawing.Point(114, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Management section logon";
			// 
			// mobjChkRemember
			// 
			this.mobjChkRemember.AutoSize = true;
			this.mobjChkRemember.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjChkRemember.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjChkRemember.Location = new System.Drawing.Point(118, 141);
			this.mobjChkRemember.Name = "mobjChkRemember";
			this.mobjChkRemember.Size = new System.Drawing.Size(177, 18);
			this.mobjChkRemember.TabIndex = 7;
			this.mobjChkRemember.Text = "Remember me on this computer";
			this.mobjChkRemember.UseVisualStyleBackColor = true;
			// 
			// mobjCmdCancel
			// 
			this.mobjCmdCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjCmdCancel.Location = new System.Drawing.Point(198, 209);
			this.mobjCmdCancel.Name = "mobjCmdCancel";
			this.mobjCmdCancel.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdCancel.TabIndex = 6;
			this.mobjCmdCancel.Text = "Cancel";
			this.toolTip1.SetToolTip(this.mobjCmdCancel, "Press to come back to CompanionKit");
			this.mobjCmdCancel.UseVisualStyleBackColor = true;
			this.mobjCmdCancel.Click += new System.EventHandler(this.mobjCmdCancel_Click);
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(115, 174);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(35, 13);
			this.lblError.TabIndex = 4;
			this.lblError.Text = "...";
			this.lblError.Visible = false;
			// 
			// mobjCmdLogon
			// 
			this.mobjCmdLogon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mobjCmdLogon.Location = new System.Drawing.Point(118, 209);
			this.mobjCmdLogon.Name = "mobjCmdLogon";
			this.mobjCmdLogon.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdLogon.TabIndex = 5;
			this.mobjCmdLogon.Text = "Logon";
			this.toolTip1.SetToolTip(this.mobjCmdLogon, "Press to logon into CompanionKit management section");
			this.mobjCmdLogon.UseVisualStyleBackColor = true;
			this.mobjCmdLogon.Click += new System.EventHandler(this.mobjCmdLogon_Click);
			// 
			// Logon
			// 
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
			this.Size = new System.Drawing.Size(462, 300);
			this.Text = "Logon";
			this.Load += new System.EventHandler(this.Logon_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private TextBox mobjtxtUsername;
		private Label lblUsername;
		private Label lblPassword;
		private TextBox mobjtxtPassword;
		private GroupBox groupBox1;
		private Button mobjCmdLogon;
		private Label lblError;
		private Button mobjCmdCancel;
		private CheckBox mobjChkRemember;
		private PictureBox pictureBox1;
		private Label label1;
		private ToolTip toolTip1;


	}
}