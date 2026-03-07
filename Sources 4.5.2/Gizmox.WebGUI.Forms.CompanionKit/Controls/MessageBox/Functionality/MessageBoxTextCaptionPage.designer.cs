namespace CompanionKit.Controls.MessageBoxControl.Functionality
{
    partial class MessageBoxTextCaptionPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCaptionText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTextLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjShowModalMask = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjShowButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjResultLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjCaptionLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "Enter Caption and Text to display within the MessageBox window:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCaptionText
            // 
            this.mobjCaptionText.AllowDrag = false;
            this.mobjTLP.SetColumnSpan(this.mobjCaptionText, 2);
            this.mobjCaptionText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCaptionText.Location = new System.Drawing.Point(3, 103);
            this.mobjCaptionText.Name = "mobjCaptionText";
            this.mobjCaptionText.Size = new System.Drawing.Size(314, 34);
            this.mobjCaptionText.TabIndex = 4;
            this.mobjCaptionText.Text = "Caption text";
            // 
            // mobjText
            // 
            this.mobjText.AllowDrag = false;
            this.mobjTLP.SetColumnSpan(this.mobjText, 2);
            this.mobjText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjText.Location = new System.Drawing.Point(3, 183);
            this.mobjText.Multiline = true;
            this.mobjText.Name = "mobjText";
            this.mobjText.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.mobjText.Size = new System.Drawing.Size(314, 94);
            this.mobjText.TabIndex = 5;
            this.mobjText.Text = "Message text";
            // 
            // mobjTextLbl
            // 
            this.mobjTLP.SetColumnSpan(this.mobjTextLbl, 2);
            this.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjTextLbl.Location = new System.Drawing.Point(0, 140);
            this.mobjTextLbl.Name = "mobjTextLbl";
            this.mobjTextLbl.Size = new System.Drawing.Size(320, 40);
            this.mobjTextLbl.TabIndex = 6;
            this.mobjTextLbl.Text = "Text";
            this.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjShowModalMask
            // 
            this.mobjShowModalMask.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjShowModalMask.Checked = true;
            this.mobjShowModalMask.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjShowModalMask.Location = new System.Drawing.Point(5, 295);
            this.mobjShowModalMask.Name = "mobjShowModalMask";
            this.mobjShowModalMask.Size = new System.Drawing.Size(150, 50);
            this.mobjShowModalMask.TabIndex = 7;
            this.mobjShowModalMask.Text = "Show Modal Mask";
            this.mobjShowModalMask.UseVisualStyleBackColor = true;
            // 
            // mobjShowButton
            // 
            this.mobjShowButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjShowButton.Location = new System.Drawing.Point(190, 295);
            this.mobjShowButton.Name = "mobjShowButton";
            this.mobjShowButton.Size = new System.Drawing.Size(100, 50);
            this.mobjShowButton.TabIndex = 8;
            this.mobjShowButton.Text = "Show";
            this.mobjShowButton.UseVisualStyleBackColor = true;
            this.mobjShowButton.Click += new System.EventHandler(this.mobjShowButton_Click);
            // 
            // mobjResultLbl
            // 
            this.mobjTLP.SetColumnSpan(this.mobjResultLbl, 2);
            this.mobjResultLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjResultLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjResultLbl.Location = new System.Drawing.Point(0, 360);
            this.mobjResultLbl.Name = "mobjResultLbl";
            this.mobjResultLbl.Size = new System.Drawing.Size(320, 40);
            this.mobjResultLbl.TabIndex = 10;
            this.mobjResultLbl.Text = "Result";
            this.mobjResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCaptionLbl
            // 
            this.mobjTLP.SetColumnSpan(this.mobjCaptionLbl, 2);
            this.mobjCaptionLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCaptionLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjCaptionLbl.Location = new System.Drawing.Point(0, 60);
            this.mobjCaptionLbl.Name = "label1";
            this.mobjCaptionLbl.Size = new System.Drawing.Size(320, 40);
            this.mobjCaptionLbl.TabIndex = 6;
            this.mobjCaptionLbl.Text = "Caption";
            this.mobjCaptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjResultLbl, 0, 6);
            this.mobjTLP.Controls.Add(this.mobjCaptionLbl, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjShowButton, 1, 5);
            this.mobjTLP.Controls.Add(this.mobjCaptionText, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjShowModalMask, 0, 5);
            this.mobjTLP.Controls.Add(this.mobjTextLbl, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjText, 0, 4);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 7;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 11;
            // 
            // MessageBoxTextCaptionPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "MessageBoxTextCaptionPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjCaptionText;
        private Gizmox.WebGUI.Forms.TextBox mobjText;
        private Gizmox.WebGUI.Forms.Label mobjTextLbl;
        private Gizmox.WebGUI.Forms.CheckBox mobjShowModalMask;
        private Gizmox.WebGUI.Forms.Button mobjShowButton;
        private Gizmox.WebGUI.Forms.Label mobjResultLbl;
        private Gizmox.WebGUI.Forms.Label mobjCaptionLbl;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
    }
}