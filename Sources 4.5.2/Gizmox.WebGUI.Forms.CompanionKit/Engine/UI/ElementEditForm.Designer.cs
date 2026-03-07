namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ElementEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementEditForm));
			this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonOk = new Gizmox.WebGUI.Forms.Button();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextTitle = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjTextBody = new Gizmox.WebGUI.Forms.TextBox();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmdNoImage = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdTitleCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdImageCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmdBodyCss = new Gizmox.WebGUI.Forms.Button();
			this.label6 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmdContainerCss = new Gizmox.WebGUI.Forms.Button();
			this.mobjResources = new Gizmox.WebGUI.Forms.ComboBox();
			this.mobjCmdNoLink = new Gizmox.WebGUI.Forms.Button();
			this.mobjCmbSections = new Gizmox.WebGUI.Forms.ComboBox();
			this.mobjError = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
			this.mobjLinkGroup = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjEditorLink = new Gizmox.WebGUI.Forms.Button();
			this.mobjRadioTypeNoLink = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjChkNewWindow = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjTxtHyperLink = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjRadioTypeHyper = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjRadioTypeInner = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjEditorText = new Gizmox.WebGUI.Forms.Button();
			this.mobjEditorTitle = new Gizmox.WebGUI.Forms.Button();
			this.mobjToolTip = new Gizmox.WebGUI.Forms.ToolTip(this.components);
			this.mobjCmdGetSectionElements = new Gizmox.WebGUI.Forms.Button();
			this.mobjMenuElements = new Gizmox.WebGUI.Forms.ContextMenu();
			this.mobjToolbar = new Gizmox.WebGUI.Forms.ToolBar();
			this.mobjBtnNew = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnDelete = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.separator1 = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnCopyCSS = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnPasteCSS = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnClearCSS = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.Separator2 = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnFirst = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnPrevious = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnNext = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnLast = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.Separator3 = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.mobjBtnList = new Gizmox.WebGUI.Forms.ToolBarButton();
			this.label4 = new Gizmox.WebGUI.Forms.Label();
			this.label7 = new Gizmox.WebGUI.Forms.Label();
			this.label8 = new Gizmox.WebGUI.Forms.Label();
			this.mobjCmbLink = new Gizmox.WebGUI.Forms.CompanionKit.UI.NavigationCombo();
			this.mobjLinkGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjButtonCancel
			// 
			this.mobjButtonCancel.Location = new System.Drawing.Point(395, 404);
			this.mobjButtonCancel.Name = "mobjButtonCancel";
			this.mobjButtonCancel.Size = new System.Drawing.Size(66, 27);
			this.mobjButtonCancel.TabIndex = 19;
			this.mobjButtonCancel.Text = "Cancel";
			this.mobjButtonCancel.UseVisualStyleBackColor = true;
			this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
			// 
			// mobjButtonOk
			// 
			this.mobjButtonOk.Location = new System.Drawing.Point(329, 404);
			this.mobjButtonOk.Name = "mobjButtonOk";
			this.mobjButtonOk.Size = new System.Drawing.Size(66, 27);
			this.mobjButtonOk.TabIndex = 18;
			this.mobjButtonOk.Text = "Ok";
			this.mobjButtonOk.UseVisualStyleBackColor = true;
			this.mobjButtonOk.Click += new System.EventHandler(this.mobjButtonOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 107);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Title:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 185);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Text:";
			// 
			// mobjTextTitle
			// 
			this.mobjTextTitle.Location = new System.Drawing.Point(94, 104);
			this.mobjTextTitle.Multiline = true;
			this.mobjTextTitle.Name = "mobjTextTitle";
			this.mobjTextTitle.Size = new System.Drawing.Size(285, 20);
			this.mobjTextTitle.TabIndex = 5;
			// 
			// mobjTextBody
			// 
			this.mobjTextBody.Location = new System.Drawing.Point(94, 182);
			this.mobjTextBody.Multiline = true;
			this.mobjTextBody.Name = "mobjTextBody";
			this.mobjTextBody.Size = new System.Drawing.Size(285, 122);
			this.mobjTextBody.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Section:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Image:";
			// 
			// mobjCmdNoImage
			// 
			this.mobjCmdNoImage.Location = new System.Drawing.Point(382, 155);
			this.mobjCmdNoImage.Name = "mobjCmdNoImage";
			this.mobjCmdNoImage.Size = new System.Drawing.Size(30, 21);
			this.mobjCmdNoImage.TabIndex = 11;
			this.mobjCmdNoImage.Text = "X";
			this.mobjToolTip.SetToolTip(this.mobjCmdNoImage, "Click to disable showing image");
			this.mobjCmdNoImage.UseVisualStyleBackColor = true;
			this.mobjCmdNoImage.Click += new System.EventHandler(this.mobjCmdNoImage_Click);
			// 
			// mobjCmdTitleCss
			// 
			this.mobjCmdTitleCss.Location = new System.Drawing.Point(422, 103);
			this.mobjCmdTitleCss.Name = "mobjCmdTitleCss";
			this.mobjCmdTitleCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdTitleCss.TabIndex = 6;
			this.mobjCmdTitleCss.Text = "CSS";
			this.mobjCmdTitleCss.UseVisualStyleBackColor = true;
			this.mobjCmdTitleCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjCmdImageCss
			// 
			this.mobjCmdImageCss.Location = new System.Drawing.Point(422, 155);
			this.mobjCmdImageCss.Name = "mobjImageCss";
			this.mobjCmdImageCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdImageCss.TabIndex = 12;
			this.mobjCmdImageCss.Text = "CSS";
			this.mobjCmdImageCss.UseVisualStyleBackColor = true;
			this.mobjCmdImageCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjCmdBodyCss
			// 
			this.mobjCmdBodyCss.Location = new System.Drawing.Point(422, 181);
			this.mobjCmdBodyCss.Name = "mobjBodyCss";
			this.mobjCmdBodyCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdBodyCss.TabIndex = 15;
			this.mobjCmdBodyCss.Text = "CSS";
			this.mobjCmdBodyCss.UseVisualStyleBackColor = true;
			this.mobjCmdBodyCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Element Container (TD):";
			// 
			// mobjCmdContainerCss
			// 
			this.mobjCmdContainerCss.Location = new System.Drawing.Point(422, 37);
			this.mobjCmdContainerCss.Name = "mobjCmdContainerCss";
			this.mobjCmdContainerCss.Size = new System.Drawing.Size(39, 21);
			this.mobjCmdContainerCss.TabIndex = 1;
			this.mobjCmdContainerCss.Text = "CSS";
			this.mobjCmdContainerCss.UseVisualStyleBackColor = true;
			this.mobjCmdContainerCss.Click += new System.EventHandler(this.mobjCmdCss_Click);
			// 
			// mobjResources
			// 
			this.mobjResources.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjResources.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjResources.Location = new System.Drawing.Point(94, 156);
			this.mobjResources.MaxDropDownItems = 8;
			this.mobjResources.Name = "mobjResources";
			this.mobjResources.Size = new System.Drawing.Size(285, 21);
			this.mobjResources.TabIndex = 10;
			// 
			// mobjCmdNoLink
			// 
			this.mobjCmdNoLink.Location = new System.Drawing.Point(377, 16);
			this.mobjCmdNoLink.Name = "mobjCmdNoLink";
			this.mobjCmdNoLink.Size = new System.Drawing.Size(30, 21);
			this.mobjCmdNoLink.TabIndex = 2;
			this.mobjCmdNoLink.Text = "X";
			this.mobjCmdNoLink.UseVisualStyleBackColor = true;
			this.mobjCmdNoLink.Click += new System.EventHandler(this.mobjCmdNoLink_Click);
			// 
			// mobjCmbSections
			// 
			this.mobjCmbSections.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjCmbSections.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjCmbSections.FormattingEnabled = true;
			this.mobjCmbSections.Location = new System.Drawing.Point(94, 73);
			this.mobjCmbSections.MaxDropDownItems = 8;
			this.mobjCmbSections.Name = "mobjCmbSections";
			this.mobjCmbSections.Size = new System.Drawing.Size(285, 21);
			this.mobjCmbSections.TabIndex = 3;
			// 
			// mobjError
			// 
			this.mobjError.BlinkRate = 3;
			this.mobjError.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
			// 
			// mobjLinkGroup
			// 
			this.mobjLinkGroup.Controls.Add(this.mobjEditorLink);
			this.mobjLinkGroup.Controls.Add(this.mobjRadioTypeNoLink);
			this.mobjLinkGroup.Controls.Add(this.mobjChkNewWindow);
			this.mobjLinkGroup.Controls.Add(this.mobjTxtHyperLink);
			this.mobjLinkGroup.Controls.Add(this.mobjRadioTypeHyper);
			this.mobjLinkGroup.Controls.Add(this.mobjRadioTypeInner);
			this.mobjLinkGroup.Controls.Add(this.mobjCmbLink);
			this.mobjLinkGroup.Controls.Add(this.mobjCmdNoLink);
			this.mobjLinkGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLinkGroup.Location = new System.Drawing.Point(5, 307);
			this.mobjLinkGroup.Name = "mobjLinkGroup";
			this.mobjLinkGroup.Size = new System.Drawing.Size(455, 90);
			this.mobjLinkGroup.TabIndex = 16;
			this.mobjLinkGroup.TabStop = false;
			this.mobjLinkGroup.Text = "Link";
			// 
			// mobjEditorLink
			// 
			this.mobjEditorLink.Location = new System.Drawing.Point(377, 40);
			this.mobjEditorLink.Name = "mobjEditorLink";
			this.mobjEditorLink.Size = new System.Drawing.Size(30, 21);
			this.mobjEditorLink.TabIndex = 20;
			this.mobjEditorLink.Text = "...";
			this.mobjToolTip.SetToolTip(this.mobjEditorLink, "Open a window to edit the text");
			this.mobjEditorLink.UseVisualStyleBackColor = true;
			this.mobjEditorLink.Click += new System.EventHandler(this.mobjEditorText_Click);
			// 
			// mobjRadioTypeNoLink
			// 
			this.mobjRadioTypeNoLink.AutoSize = true;
			this.mobjRadioTypeNoLink.Location = new System.Drawing.Point(14, 65);
			this.mobjRadioTypeNoLink.Name = "mobjRadioTypeNoLink";
			this.mobjRadioTypeNoLink.Size = new System.Drawing.Size(56, 17);
			this.mobjRadioTypeNoLink.TabIndex = 6;
			this.mobjRadioTypeNoLink.Text = "No link";
			this.mobjRadioTypeNoLink.UseVisualStyleBackColor = true;
			this.mobjRadioTypeNoLink.Click += new System.EventHandler(this.mobjRadioType_Click);
			// 
			// mobjChkNewWindow
			// 
			this.mobjChkNewWindow.AutoSize = true;
			this.mobjChkNewWindow.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjChkNewWindow.Location = new System.Drawing.Point(220, 65);
			this.mobjChkNewWindow.Name = "mobjChkNewWindow";
			this.mobjChkNewWindow.Size = new System.Drawing.Size(154, 17);
			this.mobjChkNewWindow.TabIndex = 5;
			this.mobjChkNewWindow.Text = "Open in a new window/tab";
			this.mobjChkNewWindow.UseVisualStyleBackColor = true;
			// 
			// mobjTxtHyperLink
			// 
			this.mobjTxtHyperLink.Location = new System.Drawing.Point(90, 41);
			this.mobjTxtHyperLink.Name = "mobjTxtHyperLink";
			this.mobjTxtHyperLink.Size = new System.Drawing.Size(284, 20);
			this.mobjTxtHyperLink.TabIndex = 4;
			// 
			// mobjRadioTypeHyper
			// 
			this.mobjRadioTypeHyper.Location = new System.Drawing.Point(14, 41);
			this.mobjRadioTypeHyper.Name = "mobjRadioTypeHyper";
			this.mobjRadioTypeHyper.Size = new System.Drawing.Size(75, 17);
			this.mobjRadioTypeHyper.TabIndex = 3;
			this.mobjRadioTypeHyper.Text = "Hyper Link";
			this.mobjRadioTypeHyper.Click += new System.EventHandler(this.mobjRadioType_Click);
			// 
			// mobjRadioTypeInner
			// 
			this.mobjRadioTypeInner.Checked = true;
			this.mobjRadioTypeInner.Location = new System.Drawing.Point(14, 18);
			this.mobjRadioTypeInner.Name = "mobjRadioTypeInner";
			this.mobjRadioTypeInner.Size = new System.Drawing.Size(76, 17);
			this.mobjRadioTypeInner.TabIndex = 0;
			this.mobjRadioTypeInner.Text = "Inner Item";
			this.mobjRadioTypeInner.UseVisualStyleBackColor = true;
			this.mobjRadioTypeInner.Click += new System.EventHandler(this.mobjRadioType_Click);
			// 
			// mobjEditorText
			// 
			this.mobjEditorText.Location = new System.Drawing.Point(382, 181);
			this.mobjEditorText.Name = "mobjEditorText";
			this.mobjEditorText.Size = new System.Drawing.Size(30, 21);
			this.mobjEditorText.TabIndex = 20;
			this.mobjEditorText.Text = "...";
			this.mobjToolTip.SetToolTip(this.mobjEditorText, "Open a window to edit the text");
			this.mobjEditorText.UseVisualStyleBackColor = true;
			this.mobjEditorText.Click += new System.EventHandler(this.mobjEditorText_Click);
			// 
			// mobjEditorTitle
			// 
			this.mobjEditorTitle.Location = new System.Drawing.Point(382, 103);
			this.mobjEditorTitle.Name = "mobjEditorTitle";
			this.mobjEditorTitle.Size = new System.Drawing.Size(30, 21);
			this.mobjEditorTitle.TabIndex = 20;
			this.mobjEditorTitle.Text = "...";
			this.mobjToolTip.SetToolTip(this.mobjEditorTitle, "Open a window to edit the text");
			this.mobjEditorTitle.UseVisualStyleBackColor = true;
			this.mobjEditorTitle.Click += new System.EventHandler(this.mobjEditorText_Click);
			// 
			// mobjCmdGetSectionElements
			// 
			this.mobjCmdGetSectionElements.Location = new System.Drawing.Point(382, 72);
			this.mobjCmdGetSectionElements.Name = "mobjCmdGetSectionElements";
			this.mobjCmdGetSectionElements.Size = new System.Drawing.Size(30, 21);
			this.mobjCmdGetSectionElements.TabIndex = 20;
			this.mobjCmdGetSectionElements.Text = ">";
			this.mobjToolTip.SetToolTip(this.mobjCmdGetSectionElements, "Edit elements of the section");
			this.mobjCmdGetSectionElements.UseVisualStyleBackColor = true;
			this.mobjCmdGetSectionElements.Click += new System.EventHandler(this.GetElements_Click);
			// 
			// mobjToolbar
			// 
			this.mobjToolbar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
			this.mobjToolbar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.mobjBtnNew,
            this.mobjBtnDelete,
            this.separator1,
            this.mobjBtnCopyCSS,
            this.mobjBtnPasteCSS,
            this.mobjBtnClearCSS,
            this.Separator2,
            this.mobjBtnFirst,
            this.mobjBtnPrevious,
            this.mobjBtnNext,
            this.mobjBtnLast,
            this.Separator3,
            this.mobjBtnList});
			this.mobjToolbar.DragHandle = true;
			this.mobjToolbar.DropDownArrows = true;
			this.mobjToolbar.ImageSize = new System.Drawing.Size(16, 16);
			this.mobjToolbar.Location = new System.Drawing.Point(0, 0);
			this.mobjToolbar.MenuHandle = true;
			this.mobjToolbar.Name = "mobjToolbar";
			this.mobjToolbar.ShowToolTips = true;
			this.mobjToolbar.Size = new System.Drawing.Size(469, 36);
			this.mobjToolbar.TabIndex = 24;
			// 
			// mobjBtnNew
			// 
			this.mobjBtnNew.CustomStyle = "";
			this.mobjBtnNew.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnNew.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnNew.Image"));
			this.mobjBtnNew.Name = "mobjBtnNew";
			this.mobjBtnNew.Size = 24;
			this.mobjBtnNew.ToolTipText = "Create new element";
			this.mobjBtnNew.Click += new System.EventHandler(this.CmdNewDeleteElement_Click);
			// 
			// mobjBtnDelete
			// 
			this.mobjBtnDelete.CustomStyle = "";
			this.mobjBtnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnDelete.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnDelete.Image"));
			this.mobjBtnDelete.Name = "mobjBtnDelete";
			this.mobjBtnDelete.Size = 24;
			this.mobjBtnDelete.ToolTipText = "Delete the element ...";
			this.mobjBtnDelete.Click += new System.EventHandler(this.CmdNewDeleteElement_Click);
			// 
			// separator1
			// 
			this.separator1.CustomStyle = "";
			this.separator1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.separator1.Name = "separator1";
			this.separator1.Size = 24;
			this.separator1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
			this.separator1.ToolTipText = "";
			// 
			// mobjBtnCopyCSS
			// 
			this.mobjBtnCopyCSS.CustomStyle = "";
			this.mobjBtnCopyCSS.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnCopyCSS.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnCopyCSS.Image"));
			this.mobjBtnCopyCSS.Name = "mobjBtnCopyCSS";
			this.mobjBtnCopyCSS.Size = 24;
			this.mobjBtnCopyCSS.ToolTipText = "Copy CSS styling";
			this.mobjBtnCopyCSS.Click += new System.EventHandler(this.CopyPasteCSS_Click);
			// 
			// mobjBtnPasteCSS
			// 
			this.mobjBtnPasteCSS.CustomStyle = "";
			this.mobjBtnPasteCSS.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnPasteCSS.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnPasteCSS.Image"));
			this.mobjBtnPasteCSS.Name = "mobjBtnPasteCSS";
			this.mobjBtnPasteCSS.Size = 24;
			this.mobjBtnPasteCSS.ToolTipText = "Apply copied CSS styling";
			this.mobjBtnPasteCSS.Click += new System.EventHandler(this.CopyPasteCSS_Click);
			// 
			// mobjBtnClearCSS
			// 
			this.mobjBtnClearCSS.CustomStyle = "";
			this.mobjBtnClearCSS.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnClearCSS.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnClearCSS.Image"));
			this.mobjBtnClearCSS.Name = "mobjBtnClearCSS";
			this.mobjBtnClearCSS.Size = 24;
			this.mobjBtnClearCSS.ToolTipText = "Clear CSS styling";
			this.mobjBtnClearCSS.Click += new System.EventHandler(this.mobjCmdClearCss_Click);
			// 
			// Separator2
			// 
			this.Separator2.CustomStyle = "";
			this.Separator2.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.Separator2.Name = "Separator2";
			this.Separator2.Size = 24;
			this.Separator2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
			this.Separator2.ToolTipText = "";
			// 
			// mobjBtnFirst
			// 
			this.mobjBtnFirst.CustomStyle = "";
			this.mobjBtnFirst.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnFirst.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnFirst.Image"));
			this.mobjBtnFirst.Name = "mobjBtnFirst";
			this.mobjBtnFirst.Size = 24;
			this.mobjBtnFirst.ToolTipText = "Move to first element";
			this.mobjBtnFirst.Click += new System.EventHandler(this.MoveToElement_Click);
			// 
			// mobjBtnPrevious
			// 
			this.mobjBtnPrevious.CustomStyle = "";
			this.mobjBtnPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnPrevious.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnPrevious.Image"));
			this.mobjBtnPrevious.Name = "mobjBtnPrevious";
			this.mobjBtnPrevious.Size = 24;
			this.mobjBtnPrevious.ToolTipText = "Move to previous element";
			this.mobjBtnPrevious.Click += new System.EventHandler(this.MoveToElement_Click);
			// 
			// mobjBtnNext
			// 
			this.mobjBtnNext.CustomStyle = "";
			this.mobjBtnNext.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnNext.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnNext.Image"));
			this.mobjBtnNext.Name = "mobjBtnNext";
			this.mobjBtnNext.Size = 24;
			this.mobjBtnNext.ToolTipText = "Move to next element";
			this.mobjBtnNext.Click += new System.EventHandler(this.MoveToElement_Click);
			// 
			// mobjBtnLast
			// 
			this.mobjBtnLast.CustomStyle = "";
			this.mobjBtnLast.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnLast.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnLast.Image"));
			this.mobjBtnLast.Name = "mobjBtnLast";
			this.mobjBtnLast.Size = 24;
			this.mobjBtnLast.ToolTipText = "Move to last element";
			this.mobjBtnLast.Click += new System.EventHandler(this.MoveToElement_Click);
			// 
			// Separator3
			// 
			this.Separator3.CustomStyle = "";
			this.Separator3.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.Separator3.Name = "Separator3";
			this.Separator3.Size = 24;
			this.Separator3.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
			this.Separator3.ToolTipText = "";
			// 
			// mobjBtnList
			// 
			this.mobjBtnList.CustomStyle = "";
			this.mobjBtnList.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.mobjBtnList.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjBtnList.Image"));
			this.mobjBtnList.Name = "mobjBtnList";
			this.mobjBtnList.Size = 24;
			this.mobjBtnList.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.DropDownButton;
			this.mobjBtnList.ToolTipText = "Show the list of elements";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 416);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "The element will be saved on move to next one";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(414, 75);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "*";
			this.mobjToolTip.SetToolTip(this.label7, "The element will be saved on move to next one");
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(8, 416);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 26;
			this.label8.Text = "*";
			// 
			// mobjCmbLink
			// 
			this.mobjCmbLink.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjCmbLink.FoldersOnly = false;
			this.mobjCmbLink.IncludeRoot = false;
			this.mobjCmbLink.Location = new System.Drawing.Point(90, 17);
			this.mobjCmbLink.MaxDropDownItems = 8;
			this.mobjCmbLink.Name = "mobjComboLink";
			this.mobjCmbLink.Size = new System.Drawing.Size(284, 21);
			this.mobjCmbLink.TabIndex = 1;
			// 
			// ElementEditForm
			// 
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.mobjToolbar);
			this.Controls.Add(this.mobjCmdGetSectionElements);
			this.Controls.Add(this.mobjEditorTitle);
			this.Controls.Add(this.mobjEditorText);
			this.Controls.Add(this.mobjLinkGroup);
			this.Controls.Add(this.mobjCmbSections);
			this.Controls.Add(this.mobjResources);
			this.Controls.Add(this.mobjCmdContainerCss);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.mobjCmdBodyCss);
			this.Controls.Add(this.mobjCmdImageCss);
			this.Controls.Add(this.mobjCmdTitleCss);
			this.Controls.Add(this.mobjCmdNoImage);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.mobjTextBody);
			this.Controls.Add(this.mobjTextTitle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mobjButtonOk);
			this.Controls.Add(this.mobjButtonCancel);
			this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
			this.Size = new System.Drawing.Size(469, 441);
			this.Text = "ElementEditForm";
			this.mobjLinkGroup.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Button mobjButtonCancel;
        private Button mobjButtonOk;
        private Label label1;
        private Label label2;
        private TextBox mobjTextTitle;
        private TextBox mobjTextBody;
		private Label label3;
		private NavigationCombo mobjCmbLink;
		private Label label5;
		private Button mobjCmdNoImage;
		private Button mobjCmdTitleCss;
		private Button mobjCmdImageCss;
		private Button mobjCmdBodyCss;
		private Label label6;
		private Button mobjCmdContainerCss;
		private ComboBox mobjResources;
		private Button mobjCmdNoLink;
		private ComboBox mobjCmbSections;
		private ErrorProvider mobjError;
		private GroupBox mobjLinkGroup;
		private TextBox mobjTxtHyperLink;
		private RadioButton mobjRadioTypeHyper;
		private RadioButton mobjRadioTypeInner;
		private CheckBox mobjChkNewWindow;
		private RadioButton mobjRadioTypeNoLink;
		private Button mobjEditorText;
		private Button mobjEditorTitle;
		private ToolTip mobjToolTip;
		private Button mobjEditorLink;
		private ContextMenu mobjMenuElements;
		private Button mobjCmdGetSectionElements;
		private ToolBar mobjToolbar;
		private ToolBarButton mobjBtnClearCSS;
		private ToolBarButton mobjBtnCopyCSS;
		private ToolBarButton mobjBtnPasteCSS;
		private ToolBarButton separator1;
		private ToolBarButton mobjBtnNew;
		private ToolBarButton mobjBtnDelete;
		private ToolBarButton Separator2;
		private ToolBarButton mobjBtnFirst;
		private ToolBarButton mobjBtnPrevious;
		private ToolBarButton mobjBtnNext;
		private ToolBarButton mobjBtnLast;
		private ToolBarButton Separator3;
		private ToolBarButton mobjBtnList;
		private Label label4;
		private Label label7;
		private Label label8;
    }
}
