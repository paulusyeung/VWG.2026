namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class EditView
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.mobjButtonDelete = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonSave = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.cmdCommentHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdDescriptionHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdDisplayName = new Gizmox.WebGUI.Forms.Button();
			this.cmdTitleName = new Gizmox.WebGUI.Forms.Button();
			this.cmdNameHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdSiteMapHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdTypeHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdParentHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdStatusHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdOrderHelp = new Gizmox.WebGUI.Forms.Button();
			this.cmdKeywordsHelp = new Gizmox.WebGUI.Forms.Button();
			this.label10 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextComment = new Gizmox.WebGUI.Forms.TextBox();
			this.label9 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextKeywords = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjTextDescription = new Gizmox.WebGUI.Forms.TextBox();
			this.label8 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCheckBoxSiteMap = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjComboStatus = new Gizmox.WebGUI.Forms.ComboBox();
			this.label7 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextName = new Gizmox.WebGUI.Forms.TextBox();
			this.label6 = new Gizmox.WebGUI.Forms.Label();
			this.mobjPanelType = new Gizmox.WebGUI.Forms.Panel();
			this.mobjRadioLobby = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjRadioPage = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjRadioFolder = new Gizmox.WebGUI.Forms.RadioButton();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.mobjComboParent = new Gizmox.WebGUI.Forms.CompanionKit.UI.NavigationCombo();
			this.label4 = new Gizmox.WebGUI.Forms.Label();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextDisplayName = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjTextOrder = new Gizmox.WebGUI.Forms.TextBox();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextTitle = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjErrors = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
			this.mobjPanelContent = new Gizmox.WebGUI.Forms.Panel();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.mobjPanelType.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.mobjButtonDelete);
			this.panel1.Controls.Add(this.mobjButtonSave);
			this.panel1.Controls.Add(this.mobjButtonCancel);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 603);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(672, 52);
			this.panel1.TabIndex = 2;
			// 
			// mobjButtonDelete
			// 
			this.mobjButtonDelete.Enabled = false;
			this.mobjButtonDelete.Location = new System.Drawing.Point(86, 14);
			this.mobjButtonDelete.Name = "mobjButtonDelete";
			this.mobjButtonDelete.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonDelete.TabIndex = 1;
			this.mobjButtonDelete.Text = "Delete";
			this.mobjButtonDelete.UseVisualStyleBackColor = true;
			this.mobjButtonDelete.Click += new System.EventHandler(this.mobjButtonDelete_Click);
			// 
			// mobjButtonSave
			// 
			this.mobjButtonSave.Location = new System.Drawing.Point(5, 14);
			this.mobjButtonSave.Name = "mobjButtonSave";
			this.mobjButtonSave.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonSave.TabIndex = 0;
			this.mobjButtonSave.Text = "Save";
			this.mobjButtonSave.UseVisualStyleBackColor = true;
			this.mobjButtonSave.Click += new System.EventHandler(this.mobjButtonSave_Click);
			// 
			// mobjButtonCancel
			// 
			this.mobjButtonCancel.Location = new System.Drawing.Point(167, 14);
			this.mobjButtonCancel.Name = "mobjButtonCancel";
			this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonCancel.TabIndex = 2;
			this.mobjButtonCancel.Text = "Cancel";
			this.mobjButtonCancel.UseVisualStyleBackColor = true;
			this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Title:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdCommentHelp);
			this.groupBox1.Controls.Add(this.cmdDescriptionHelp);
			this.groupBox1.Controls.Add(this.cmdDisplayName);
			this.groupBox1.Controls.Add(this.cmdTitleName);
			this.groupBox1.Controls.Add(this.cmdNameHelp);
			this.groupBox1.Controls.Add(this.cmdSiteMapHelp);
			this.groupBox1.Controls.Add(this.cmdTypeHelp);
			this.groupBox1.Controls.Add(this.cmdParentHelp);
			this.groupBox1.Controls.Add(this.cmdStatusHelp);
			this.groupBox1.Controls.Add(this.cmdOrderHelp);
			this.groupBox1.Controls.Add(this.cmdKeywordsHelp);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.mobjTextComment);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.mobjTextKeywords);
			this.groupBox1.Controls.Add(this.mobjTextDescription);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.mobjCheckBoxSiteMap);
			this.groupBox1.Controls.Add(this.mobjComboStatus);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.mobjTextName);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.mobjPanelType);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.mobjComboParent);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.mobjTextDisplayName);
			this.groupBox1.Controls.Add(this.mobjTextOrder);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.mobjTextTitle);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(672, 476);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General";
			// 
			// cmdCommentHelp
			// 
			this.cmdCommentHelp.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdCommentHelp.Location = new System.Drawing.Point(587, 210);
			this.cmdCommentHelp.Name = "button1";
			this.cmdCommentHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdCommentHelp.TabIndex = 26;
			this.cmdCommentHelp.Tag = "Comment";
			this.cmdCommentHelp.Text = "Help";
			this.cmdCommentHelp.UseVisualStyleBackColor = true;
			this.cmdCommentHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdDescriptionHelp
			// 
			this.cmdDescriptionHelp.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdDescriptionHelp.Location = new System.Drawing.Point(587, 97);
			this.cmdDescriptionHelp.Name = "button1";
			this.cmdDescriptionHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdDescriptionHelp.TabIndex = 24;
			this.cmdDescriptionHelp.Tag = "Description";
			this.cmdDescriptionHelp.Text = "Help";
			this.cmdDescriptionHelp.UseVisualStyleBackColor = true;
			this.cmdDescriptionHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdDisplayName
			// 
			this.cmdDisplayName.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdDisplayName.Location = new System.Drawing.Point(587, 69);
			this.cmdDisplayName.Name = "button1";
			this.cmdDisplayName.Size = new System.Drawing.Size(75, 23);
			this.cmdDisplayName.TabIndex = 23;
			this.cmdDisplayName.Tag = "DisplayName";
			this.cmdDisplayName.Text = "Help";
			this.cmdDisplayName.UseVisualStyleBackColor = true;
			this.cmdDisplayName.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdTitleName
			// 
			this.cmdTitleName.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdTitleName.Location = new System.Drawing.Point(587, 43);
			this.cmdTitleName.Name = "button1";
			this.cmdTitleName.Size = new System.Drawing.Size(75, 23);
			this.cmdTitleName.TabIndex = 22;
			this.cmdTitleName.Tag = "Title";
			this.cmdTitleName.Text = "Help";
			this.cmdTitleName.UseVisualStyleBackColor = true;
			this.cmdTitleName.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdNameHelp
			// 
			this.cmdNameHelp.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdNameHelp.Location = new System.Drawing.Point(587, 16);
			this.cmdNameHelp.Name = "button1";
			this.cmdNameHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdNameHelp.TabIndex = 21;
			this.cmdNameHelp.Tag = "Name";
			this.cmdNameHelp.Text = "Help";
			this.cmdNameHelp.UseVisualStyleBackColor = true;
			this.cmdNameHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdSiteMapHelp
			// 
			this.cmdSiteMapHelp.Location = new System.Drawing.Point(320, 432);
			this.cmdSiteMapHelp.Name = "button4";
			this.cmdSiteMapHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdSiteMapHelp.TabIndex = 31;
			this.cmdSiteMapHelp.Tag = "Sitemap";
			this.cmdSiteMapHelp.Text = "Help";
			this.cmdSiteMapHelp.UseVisualStyleBackColor = true;
			this.cmdSiteMapHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdTypeHelp
			// 
			this.cmdTypeHelp.Location = new System.Drawing.Point(320, 375);
			this.cmdTypeHelp.Name = "cmdOrderHelp";
			this.cmdTypeHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdTypeHelp.TabIndex = 30;
			this.cmdTypeHelp.Tag = "Type";
			this.cmdTypeHelp.Text = "Help";
			this.cmdTypeHelp.UseVisualStyleBackColor = true;
			this.cmdTypeHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdParentHelp
			// 
			this.cmdParentHelp.Location = new System.Drawing.Point(320, 340);
			this.cmdParentHelp.Name = "cmdOrderHelp";
			this.cmdParentHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdParentHelp.TabIndex = 29;
			this.cmdParentHelp.Tag = "Parent";
			this.cmdParentHelp.Text = "Help";
			this.cmdParentHelp.UseVisualStyleBackColor = true;
			this.cmdParentHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdStatusHelp
			// 
			this.cmdStatusHelp.Location = new System.Drawing.Point(320, 283);
			this.cmdStatusHelp.Name = "cmdOrderHelp";
			this.cmdStatusHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdStatusHelp.TabIndex = 27;
			this.cmdStatusHelp.Tag = "Status";
			this.cmdStatusHelp.Text = "Help";
			this.cmdStatusHelp.UseVisualStyleBackColor = true;
			this.cmdStatusHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdOrderHelp
			// 
			this.cmdOrderHelp.Location = new System.Drawing.Point(320, 312);
			this.cmdOrderHelp.Name = "cmdOrderHelp";
			this.cmdOrderHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdOrderHelp.TabIndex = 28;
			this.cmdOrderHelp.Tag = "Order";
			this.cmdOrderHelp.Text = "Help";
			this.cmdOrderHelp.UseVisualStyleBackColor = true;
			this.cmdOrderHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// cmdKeywordsHelp
			// 
			this.cmdKeywordsHelp.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
			this.cmdKeywordsHelp.Location = new System.Drawing.Point(587, 163);
			this.cmdKeywordsHelp.Name = "button1";
			this.cmdKeywordsHelp.Size = new System.Drawing.Size(75, 23);
			this.cmdKeywordsHelp.TabIndex = 25;
			this.cmdKeywordsHelp.Tag = "Keywords";
			this.cmdKeywordsHelp.Text = "Help";
			this.cmdKeywordsHelp.UseVisualStyleBackColor = true;
			this.cmdKeywordsHelp.Click += new System.EventHandler(this.cmdHelp_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(14, 211);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Comment:";
			// 
			// mobjTextComment
			// 
			this.mobjTextComment.Location = new System.Drawing.Point(94, 212);
			this.mobjTextComment.Multiline = true;
			this.mobjTextComment.Name = "textBox1";
			this.mobjTextComment.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
			this.mobjTextComment.Size = new System.Drawing.Size(461, 58);
			this.mobjTextComment.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(14, 165);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Keywords:";
			// 
			// mobjTextKeywords
			// 
			this.mobjTextKeywords.Location = new System.Drawing.Point(94, 163);
			this.mobjTextKeywords.Multiline = true;
			this.mobjTextKeywords.Name = "textBox1";
			this.mobjTextKeywords.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
			this.mobjTextKeywords.Size = new System.Drawing.Size(461, 41);
			this.mobjTextKeywords.TabIndex = 9;
			// 
			// mobjTextDescription
			// 
			this.mobjTextDescription.Location = new System.Drawing.Point(94, 97);
			this.mobjTextDescription.Multiline = true;
			this.mobjTextDescription.Name = "mobjTextDescription";
			this.mobjTextDescription.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
			this.mobjTextDescription.Size = new System.Drawing.Size(461, 58);
			this.mobjTextDescription.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 99);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Description:";
			// 
			// mobjCheckBoxSiteMap
			// 
			this.mobjCheckBoxSiteMap.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjCheckBoxSiteMap.Location = new System.Drawing.Point(95, 435);
			this.mobjCheckBoxSiteMap.Name = "mobjCheckBoxSiteMap";
			this.mobjCheckBoxSiteMap.Size = new System.Drawing.Size(187, 18);
			this.mobjCheckBoxSiteMap.TabIndex = 20;
			this.mobjCheckBoxSiteMap.Text = "Site Map";
			// 
			// mobjComboStatus
			// 
			this.mobjComboStatus.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjComboStatus.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjComboStatus.Location = new System.Drawing.Point(94, 285);
			this.mobjComboStatus.MaxDropDownItems = 8;
			this.mobjComboStatus.Name = "mobjComboStatus";
			this.mobjComboStatus.Size = new System.Drawing.Size(112, 21);
			this.mobjComboStatus.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 287);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Status:";
			// 
			// mobjTextName
			// 
			this.mobjTextName.Location = new System.Drawing.Point(94, 18);
			this.mobjTextName.Name = "mobjTextName";
			this.mobjTextName.Size = new System.Drawing.Size(461, 20);
			this.mobjTextName.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Name:";
			// 
			// mobjPanelType
			// 
			this.mobjPanelType.Controls.Add(this.mobjRadioLobby);
			this.mobjPanelType.Controls.Add(this.mobjRadioPage);
			this.mobjPanelType.Controls.Add(this.mobjRadioFolder);
			this.mobjPanelType.Location = new System.Drawing.Point(90, 375);
			this.mobjPanelType.Name = "panel2";
			this.mobjPanelType.Size = new System.Drawing.Size(192, 52);
			this.mobjPanelType.TabIndex = 19;
			// 
			// mobjRadioLobby
			// 
			this.mobjRadioLobby.AutoSize = true;
			this.mobjRadioLobby.Location = new System.Drawing.Point(5, 29);
			this.mobjRadioLobby.Name = "mobjRadioLobby";
			this.mobjRadioLobby.Size = new System.Drawing.Size(54, 17);
			this.mobjRadioLobby.TabIndex = 1;
			this.mobjRadioLobby.Text = "Lobby";
			// 
			// mobjRadioPage
			// 
			this.mobjRadioPage.AutoSize = true;
			this.mobjRadioPage.Location = new System.Drawing.Point(90, 6);
			this.mobjRadioPage.Name = "mobjRadioPage";
			this.mobjRadioPage.Size = new System.Drawing.Size(49, 17);
			this.mobjRadioPage.TabIndex = 2;
			this.mobjRadioPage.Text = "Page";
			// 
			// mobjRadioFolder
			// 
			this.mobjRadioFolder.AutoSize = true;
			this.mobjRadioFolder.Location = new System.Drawing.Point(5, 6);
			this.mobjRadioFolder.Name = "mobjRadioFolder";
			this.mobjRadioFolder.Size = new System.Drawing.Size(55, 17);
			this.mobjRadioFolder.TabIndex = 0;
			this.mobjRadioFolder.Text = "Folder";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 382);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Type:";
			// 
			// mobjComboParent
			// 
			this.mobjComboParent.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjComboParent.FoldersOnly = true;
			this.mobjComboParent.IncludeRoot = true;
			this.mobjComboParent.Location = new System.Drawing.Point(94, 342);
			this.mobjComboParent.MaxDropDownItems = 8;
			this.mobjComboParent.Name = "mobjComboParent";
			this.mobjComboParent.Size = new System.Drawing.Size(192, 21);
			this.mobjComboParent.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Parent:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Display Name:";
			// 
			// mobjTextDisplayName
			// 
			this.mobjTextDisplayName.Location = new System.Drawing.Point(94, 71);
			this.mobjTextDisplayName.Name = "textBox1";
			this.mobjTextDisplayName.Size = new System.Drawing.Size(461, 20);
			this.mobjTextDisplayName.TabIndex = 5;
			// 
			// mobjTextOrder
			// 
			this.mobjTextOrder.Location = new System.Drawing.Point(94, 314);
			this.mobjTextOrder.Name = "mobjTextOrder";
			this.mobjTextOrder.Size = new System.Drawing.Size(112, 20);
			this.mobjTextOrder.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 316);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Order:";
			// 
			// mobjTextTitle
			// 
			this.mobjTextTitle.Location = new System.Drawing.Point(94, 45);
			this.mobjTextTitle.Name = "mobjTextTitle";
			this.mobjTextTitle.Size = new System.Drawing.Size(461, 20);
			this.mobjTextTitle.TabIndex = 3;
			// 
			// mobjErrors
			// 
			this.mobjErrors.BlinkRate = 3;
			this.mobjErrors.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.NeverBlink;
			// 
			// mobjPanelContent
			// 
			this.mobjPanelContent.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjPanelContent.Location = new System.Drawing.Point(3, 479);
			this.mobjPanelContent.Name = "mobjPanelContent";
			this.mobjPanelContent.Size = new System.Drawing.Size(672, 10);
			this.mobjPanelContent.TabIndex = 1;
			// 
			// EditView
			// 
			this.Controls.Add(this.mobjPanelContent);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Padding = new Gizmox.WebGUI.Forms.Padding(3, 3, 3, 0);
			this.Size = new System.Drawing.Size(678, 655);
			this.Text = "EditView";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.mobjPanelType.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button mobjButtonSave;
        private Button mobjButtonCancel;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox mobjTextOrder;
        private Label label2;
        protected TextBox mobjTextTitle;
        private Label label3;
        private TextBox mobjTextDisplayName;
        private Label label4;
        private Panel mobjPanelType;
        private RadioButton mobjRadioPage;
        private RadioButton mobjRadioFolder;
        private Label label5;
        private ErrorProvider mobjErrors;
        private Label label6;
        protected Panel mobjPanelContent;
        protected NavigationCombo mobjComboParent;
        protected TextBox mobjTextName;
        private RadioButton mobjRadioLobby;
        protected Button mobjButtonDelete;
        protected ComboBox mobjComboStatus;
        private Label label7;
        private CheckBox mobjCheckBoxSiteMap;
        private TextBox mobjTextDescription;
        private Label label8;
        private Label label9;
        private TextBox mobjTextKeywords;
        private Label label10;
        private TextBox mobjTextComment;
        private Button cmdKeywordsHelp;
        private Button cmdSiteMapHelp;
        private Button cmdTypeHelp;
        private Button cmdParentHelp;
        private Button cmdStatusHelp;
        private Button cmdOrderHelp;
        private Button cmdDescriptionHelp;
        private Button cmdDisplayName;
        private Button cmdTitleName;
        private Button cmdNameHelp;
        private Button cmdCommentHelp;


    }
}
