namespace CompanionKit.Controls.MessageBoxControl.ApplicationScenario
{
    partial class MessageBoxBuilderPage
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
            this.mobjButtonShow = new Gizmox.WebGUI.Forms.Button();
            this.mobjComboIcon = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjIconLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboButtons = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjButtonsLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextMessage = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjMessageLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextTitle = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTitleLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButtonShow
            // 
            this.mobjButtonShow.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)));
            this.mobjButtonShow.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjButtonShow.Location = new System.Drawing.Point(150, 360);
            this.mobjButtonShow.Name = "mobjButtonShow";
            this.mobjButtonShow.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonShow.TabIndex = 9;
            this.mobjButtonShow.Text = "Show";
            this.mobjButtonShow.Click += new System.EventHandler(this.mobjButtonShow_Click);
            // 
            // mobjComboIcon
            // 
            this.mobjComboIcon.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjComboIcon.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjComboIcon.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboIcon.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboIcon.Location = new System.Drawing.Point(10, 329);
            this.mobjComboIcon.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjComboIcon.Name = "mobjComboIcon";
            this.mobjComboIcon.Size = new System.Drawing.Size(380, 25);
            this.mobjComboIcon.TabIndex = 8;
            // 
            // mobjIconLbl
            // 
            this.mobjIconLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjIconLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjIconLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjIconLbl.Location = new System.Drawing.Point(0, 280);
            this.mobjIconLbl.Name = "mobjIconLbl";
            this.mobjIconLbl.Size = new System.Drawing.Size(400, 40);
            this.mobjIconLbl.TabIndex = 7;
            this.mobjIconLbl.Text = "Icon";
            this.mobjIconLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjComboButtons
            // 
            this.mobjComboButtons.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjComboButtons.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjComboButtons.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboButtons.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboButtons.Location = new System.Drawing.Point(10, 249);
            this.mobjComboButtons.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjComboButtons.Name = "mobjComboButtons";
            this.mobjComboButtons.Size = new System.Drawing.Size(380, 25);
            this.mobjComboButtons.TabIndex = 6;
            // 
            // mobjButtonsLbl
            // 
            this.mobjButtonsLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjButtonsLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButtonsLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjButtonsLbl.Location = new System.Drawing.Point(0, 200);
            this.mobjButtonsLbl.Name = "mobjButtonsLbl";
            this.mobjButtonsLbl.Size = new System.Drawing.Size(400, 40);
            this.mobjButtonsLbl.TabIndex = 5;
            this.mobjButtonsLbl.Text = "Buttons";
            this.mobjButtonsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextMessage
            // 
            this.mobjTextMessage.AcceptsTab = true;
            this.mobjTextMessage.AllowDrag = false;
            this.mobjTextMessage.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextMessage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjTextMessage.Location = new System.Drawing.Point(10, 127);
            this.mobjTextMessage.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3);
            this.mobjTextMessage.Multiline = true;
            this.mobjTextMessage.Name = "mobjTextMessage";
            this.mobjTextMessage.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextMessage.Size = new System.Drawing.Size(380, 65);
            this.mobjTextMessage.TabIndex = 3;
            this.mobjTextMessage.Text = "MessageBox Line1\r\nMessageBox Line2";
            this.mobjTextMessage.WordWrap = false;
            // 
            // mobjMessageLbl
            // 
            this.mobjMessageLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjMessageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMessageLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjMessageLbl.Location = new System.Drawing.Point(0, 80);
            this.mobjMessageLbl.Name = "mobjMessageLbl";
            this.mobjMessageLbl.Size = new System.Drawing.Size(400, 40);
            this.mobjMessageLbl.TabIndex = 2;
            this.mobjMessageLbl.Text = "Message";
            this.mobjMessageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTextTitle
            // 
            this.mobjTextTitle.AcceptsTab = true;
            this.mobjTextTitle.AllowDrag = false;
            this.mobjTextTitle.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextTitle.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjTextTitle.Location = new System.Drawing.Point(10, 47);
            this.mobjTextTitle.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3);
            this.mobjTextTitle.Name = "mobjTextTitle";
            this.mobjTextTitle.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextTitle.Size = new System.Drawing.Size(380, 25);
            this.mobjTextTitle.TabIndex = 1;
            this.mobjTextTitle.Text = "MessageBox Title";
            this.mobjTextTitle.WordWrap = false;
            // 
            // mobjTitleLbl
            // 
            this.mobjTitleLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjTitleLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTitleLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjTitleLbl.Location = new System.Drawing.Point(0, 0);
            this.mobjTitleLbl.Name = "mobjTitleLbl";
            this.mobjTitleLbl.Size = new System.Drawing.Size(400, 40);
            this.mobjTitleLbl.TabIndex = 0;
            this.mobjTitleLbl.Text = "Title";
            this.mobjTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjTitleLbl, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjButtonShow, 0, 8);
            this.mobjTLP.Controls.Add(this.mobjComboIcon, 0, 7);
            this.mobjTLP.Controls.Add(this.mobjIconLbl, 0, 6);
            this.mobjTLP.Controls.Add(this.mobjComboButtons, 0, 5);
            this.mobjTLP.Controls.Add(this.mobjButtonsLbl, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjMessageLbl, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjTextTitle, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjTextMessage, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 9;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.Size = new System.Drawing.Size(400, 400);
            this.mobjTLP.TabIndex = 10;
            // 
            // MessageBoxBuilderPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(400, 400);
            this.Text = "MessageBoxBuilderPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButtonShow;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboIcon;
        private Gizmox.WebGUI.Forms.Label mobjIconLbl;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboButtons;
        private Gizmox.WebGUI.Forms.Label mobjButtonsLbl;
        private Gizmox.WebGUI.Forms.TextBox mobjTextMessage;
        private Gizmox.WebGUI.Forms.Label mobjMessageLbl;
        private Gizmox.WebGUI.Forms.TextBox mobjTextTitle;
        private Gizmox.WebGUI.Forms.Label mobjTitleLbl;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}