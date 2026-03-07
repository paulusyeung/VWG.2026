namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsCS
{
    partial class ChatForm
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
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjChatTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjMessageTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjNameTextBox = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mobjSendButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTLP
            // 
            this.mobjTLP.BackColor = System.Drawing.Color.Ivory;
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.Controls.Add(this.mobjChatTextBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjMessageTextBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjNameTextBox, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjSendButton, 1, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(561, 432);
            this.mobjTLP.TabIndex = 0;
            // 
            // mobjChatTextBox
            // 
            this.mobjChatTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChatTextBox.Location = new System.Drawing.Point(10, 74);
            this.mobjChatTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjChatTextBox.Multiline = true;
            this.mobjChatTextBox.Name = "mobjChatTextBox";
            this.mobjChatTextBox.ReadOnly = true;
            this.mobjChatTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.mobjChatTextBox.Size = new System.Drawing.Size(372, 239);
            this.mobjChatTextBox.TabIndex = 0;
            // 
            // mobjMessageTextBox
            // 
            this.mobjMessageTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMessageTextBox.Location = new System.Drawing.Point(10, 333);
            this.mobjMessageTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjMessageTextBox.Multiline = true;
            this.mobjMessageTextBox.Name = "mobjMessageTextBox";
            this.mobjMessageTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.mobjMessageTextBox.Size = new System.Drawing.Size(372, 89);
            this.mobjMessageTextBox.TabIndex = 0;
            this.mobjMessageTextBox.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.mobjSendButton_Click);
            // 
            // mobjNameTextBox
            // 
            this.mobjNameTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjNameTextBox.CustomStyle = "Watermark";
            this.mobjNameTextBox.Location = new System.Drawing.Point(10, 22);
            this.mobjNameTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3);
            this.mobjNameTextBox.Message = "Enter your nickname";
            this.mobjNameTextBox.Name = "mobjNameTextBox";
            this.mobjNameTextBox.Size = new System.Drawing.Size(372, 30);
            this.mobjNameTextBox.TabIndex = 0;
            // 
            // mobjSendButton
            // 
            this.mobjSendButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mobjSendButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSendButton.Location = new System.Drawing.Point(402, 333);
            this.mobjSendButton.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjSendButton.Name = "mobjSendButton";
            this.mobjSendButton.Size = new System.Drawing.Size(149, 89);
            this.mobjSendButton.TabIndex = 0;
            this.mobjSendButton.Text = "SEND";
            this.mobjSendButton.Click += new System.EventHandler(this.mobjSendButton_Click);
            // 
            // ChatPage
            // 
            this.Load += new System.EventHandler(ChatPage_Load);
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(400, 400);
            this.Text = "ChatPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        public Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        public Gizmox.WebGUI.Forms.TextBox mobjChatTextBox;
        public Gizmox.WebGUI.Forms.TextBox mobjMessageTextBox;
        public Gizmox.WebGUI.Forms.WatermarkTextBox mobjNameTextBox;
        public Gizmox.WebGUI.Forms.Button mobjSendButton;
    }
}