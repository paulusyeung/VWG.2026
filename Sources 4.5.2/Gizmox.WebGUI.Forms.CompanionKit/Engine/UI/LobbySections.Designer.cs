namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
	partial class LobbySections
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
			this.mobjCmbStyle = new Gizmox.WebGUI.Forms.ComboBox();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmdPreTextCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdConCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdTitleCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjPreText = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjTxtTitle = new Gizmox.WebGUI.Forms.TextBox();
			this.label4 = new Gizmox.WebGUI.Forms.Label();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.mobjColumns = new Gizmox.WebGUI.Forms.NumericUpDown();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.mobjButtonOk = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjCmdDelete = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdAdd = new Gizmox.WebGUI.Forms.Button();
			this.mobjLstSections = new Gizmox.WebGUI.Forms.ListBox();
			this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmdClearCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjEditorTitle = new Gizmox.WebGUI.Forms.Button();
			this.mobjEditorText = new Gizmox.WebGUI.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mobjColumns)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.mobjEditorText);
			this.groupBox1.Controls.Add(this.mobjEditorTitle);
			this.groupBox1.Controls.Add(this.mobjCmbStyle);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.mobjCmdPreTextCss);
			this.groupBox1.Controls.Add(this.mobjCmdConCss);
			this.groupBox1.Controls.Add(this.mobjCmdTitleCss);
			this.groupBox1.Controls.Add(this.mobjPreText);
			this.groupBox1.Controls.Add(this.mobjTxtTitle);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.mobjColumns);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(9, 172);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(557, 234);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Section details";
			// 
			// mobjCmbStyle
			// 
			this.mobjCmbStyle.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjCmbStyle.FormattingEnabled = true;
			this.mobjCmbStyle.Location = new System.Drawing.Point(149, 18);
			this.mobjCmbStyle.MaxDropDownItems = 8;
			this.mobjCmbStyle.Name = "mobjCmdStyle";
			this.mobjCmbStyle.Size = new System.Drawing.Size(121, 21);
			this.mobjCmbStyle.TabIndex = 10;
			this.mobjCmbStyle.SelectedIndexChanged += new System.EventHandler(this.mobjCmbStyle_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Style:";
			// 
			// mobjCmdPreTextCss
			// 
			this.mobjCmdPreTextCss.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdPreTextCss.Location = new System.Drawing.Point(509, 125);
			this.mobjCmdPreTextCss.Name = "mobjCmdPreTextCss";
			this.mobjCmdPreTextCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdPreTextCss.TabIndex = 8;
			this.mobjCmdPreTextCss.Text = "CSS";
			this.mobjCmdPreTextCss.UseVisualStyleBackColor = true;
			this.mobjCmdPreTextCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjCmdConCss
			// 
			this.mobjCmdConCss.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdConCss.Location = new System.Drawing.Point(509, 41);
			this.mobjCmdConCss.Name = "mobjCmdConCss";
			this.mobjCmdConCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdConCss.TabIndex = 2;
			this.mobjCmdConCss.Text = "CSS";
			this.mobjCmdConCss.UseVisualStyleBackColor = true;
			this.mobjCmdConCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjCmdTitleCss
			// 
			this.mobjCmdTitleCss.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjCmdTitleCss.Location = new System.Drawing.Point(509, 82);
			this.mobjCmdTitleCss.Name = "mobjCmdTitleCss";
			this.mobjCmdTitleCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdTitleCss.TabIndex = 5;
			this.mobjCmdTitleCss.Text = "CSS";
			this.mobjCmdTitleCss.UseVisualStyleBackColor = true;
			this.mobjCmdTitleCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjPreText
			// 
			this.mobjPreText.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjPreText.Location = new System.Drawing.Point(14, 126);
			this.mobjPreText.Multiline = true;
			this.mobjPreText.Name = "mobjPreText";
			this.mobjPreText.Size = new System.Drawing.Size(460, 100);
			this.mobjPreText.TabIndex = 7;
			this.mobjPreText.TextChanged += new System.EventHandler(this.Text_Changed);
			// 
			// mobjTxtTitle
			// 
			this.mobjTxtTitle.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
						| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjTxtTitle.Location = new System.Drawing.Point(14, 83);
			this.mobjTxtTitle.Multiline = true;
			this.mobjTxtTitle.Name = "mobjTxtTitle";
			this.mobjTxtTitle.Size = new System.Drawing.Size(460, 20);
			this.mobjTxtTitle.TabIndex = 4;
			this.mobjTxtTitle.TextChanged += new System.EventHandler(this.Text_Changed);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Title:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Text preceding to elements:";
			// 
			// mobjColumns
			// 
			this.mobjColumns.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.mobjColumns.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjColumns.CurrentValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.mobjColumns.CurrentValueChanged = false;
			this.mobjColumns.Location = new System.Drawing.Point(149, 43);
			this.mobjColumns.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.mobjColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.mobjColumns.Name = "mobjColumns";
			this.mobjColumns.Size = new System.Drawing.Size(61, 20);
			this.mobjColumns.TabIndex = 1;
			this.mobjColumns.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.mobjColumns.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
			this.mobjColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.mobjColumns.ValueChanged += new System.EventHandler(this.mobjColumns_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Number of columns:";
			// 
			// mobjButtonOk
			// 
			this.mobjButtonOk.Location = new System.Drawing.Point(410, 417);
			this.mobjButtonOk.Name = "mobjButtonOk";
			this.mobjButtonOk.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonOk.TabIndex = 2;
			this.mobjButtonOk.Text = "Ok";
			this.mobjButtonOk.UseVisualStyleBackColor = true;
			this.mobjButtonOk.Click += new System.EventHandler(this.mobjButtonOk_Click);
			// 
			// mobjButtonCancel
			// 
			this.mobjButtonCancel.Location = new System.Drawing.Point(491, 417);
			this.mobjButtonCancel.Name = "mobjButtonCancel";
			this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonCancel.TabIndex = 3;
			this.mobjButtonCancel.Text = "Cancel";
			this.mobjButtonCancel.UseVisualStyleBackColor = true;
			this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.mobjCmdDelete);
			this.groupBox2.Controls.Add(this.mobjCmdAdd);
			this.groupBox2.Controls.Add(this.mobjLstSections);
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(9, 9);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(557, 163);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Lobby sections";
			// 
			// mobjCmdDelete
			// 
			this.mobjCmdDelete.Location = new System.Drawing.Point(214, 44);
			this.mobjCmdDelete.Name = "mobjCmdDelete";
			this.mobjCmdDelete.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdDelete.TabIndex = 0;
			this.mobjCmdDelete.Text = "Delete";
			this.mobjCmdDelete.UseVisualStyleBackColor = true;
			this.mobjCmdDelete.Click += new System.EventHandler(this.mobjCmdAddDelete);
			// 
			// mobjCmdAdd
			// 
			this.mobjCmdAdd.Location = new System.Drawing.Point(214, 17);
			this.mobjCmdAdd.Name = "mobjCmdAdd";
			this.mobjCmdAdd.Size = new System.Drawing.Size(75, 23);
			this.mobjCmdAdd.TabIndex = 2;
			this.mobjCmdAdd.Text = "Add";
			this.mobjCmdAdd.UseVisualStyleBackColor = true;
			this.mobjCmdAdd.Click += new System.EventHandler(this.mobjCmdAddDelete);
			// 
			// mobjLstSections
			// 
			this.mobjLstSections.Location = new System.Drawing.Point(14, 17);
			this.mobjLstSections.Name = "mobjLstSections";
			this.mobjLstSections.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
			this.mobjLstSections.Size = new System.Drawing.Size(196, 134);
			this.mobjLstSections.TabIndex = 1;
			this.mobjLstSections.SelectedIndexChanged += new System.EventHandler(this.mobjLstSections_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(51, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(124, 21);
			this.textBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name";
			// 
			// mobjCmdClearCss
			// 
			this.mobjCmdClearCss.Location = new System.Drawing.Point(9, 417);
			this.mobjCmdClearCss.Name = "mobjCmdClearCss";
			this.mobjCmdClearCss.Size = new System.Drawing.Size(118, 23);
			this.mobjCmdClearCss.TabIndex = 22;
			this.mobjCmdClearCss.Text = "Clear All CSS";
			this.mobjCmdClearCss.UseVisualStyleBackColor = true;
			this.mobjCmdClearCss.Click += new System.EventHandler(this.mobjCmdClearCss_Click);
			// 
			// mobjEditorTitle
			// 
			this.mobjEditorTitle.Location = new System.Drawing.Point(477, 82);
			this.mobjEditorTitle.Name = "mobjEditorTitle";
			this.mobjEditorTitle.Size = new System.Drawing.Size(30, 21);
			this.mobjEditorTitle.TabIndex = 20;
			this.mobjEditorTitle.Text = "...";
			this.mobjEditorTitle.UseVisualStyleBackColor = true;
			this.mobjEditorTitle.Click += new System.EventHandler(this.mobjEditorText_Click);
			// 
			// mobjEditorText
			// 
			this.mobjEditorText.Location = new System.Drawing.Point(477, 125);
			this.mobjEditorText.Name = "mobjEditorText";
			this.mobjEditorText.Size = new System.Drawing.Size(30, 21);
			this.mobjEditorText.TabIndex = 20;
			this.mobjEditorText.Text = "...";
			this.mobjEditorText.UseVisualStyleBackColor = true;
			this.mobjEditorText.Click += new System.EventHandler(this.mobjEditorText_Click);
			// 
			// LobbySections
			// 
			this.Controls.Add(this.mobjCmdClearCss);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.mobjButtonCancel);
			this.Controls.Add(this.mobjButtonOk);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
			this.Size = new System.Drawing.Size(579, 455);
			this.Text = "LobbySettings";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mobjColumns)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GroupBox groupBox1;
		private TextBox mobjPreText;
		private TextBox mobjTxtTitle;
		private Label label4;
		private Label label3;
		private NumericUpDown mobjColumns;
		private Label label1;
		private Button mobjCmdPreTextCss;
		private Button mobjCmdConCss;
		private Button mobjCmdTitleCss;
		private Button mobjButtonOk;
		private Button mobjButtonCancel;
		private GroupBox groupBox2;
		private Button mobjCmdDelete;
		private Button mobjCmdAdd;
		private ListBox mobjLstSections;
		private TextBox textBox1;
		private Label label2;
		private Label label5;
		private ComboBox mobjCmbStyle;
		private Button mobjCmdClearCss;
		private Button mobjEditorText;
		private Button mobjEditorTitle;


	}
}