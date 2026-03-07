namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class HandlingEventsPage
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
            this.mobjDemoRTB = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjSaverRTB = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjSendButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSavedLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 42);
            this.mobjInfoLabel.TabIndex = 4;
            this.mobjInfoLabel.Text = "Press button to save changed text:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjDemoRTB
            // 
            this.mobjDemoRTB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoRTB.Location = new System.Drawing.Point(10, 52);
            this.mobjDemoRTB.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjDemoRTB.Name = "mobjDemoRTB";
            this.mobjDemoRTB.Size = new System.Drawing.Size(300, 106);
            this.mobjDemoRTB.TabIndex = 5;
            this.mobjDemoRTB.HtmlChanged += new System.EventHandler(this.mobjDemoRTB_HtmlChanged);
            // 
            // mobjSaverRTB
            // 
            this.mobjSaverRTB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSaverRTB.Location = new System.Drawing.Point(10, 283);
            this.mobjSaverRTB.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjSaverRTB.Name = "mobjSaverRTB";
            this.mobjSaverRTB.ReadOnly = true;
            this.mobjSaverRTB.Size = new System.Drawing.Size(300, 107);
            this.mobjSaverRTB.TabIndex = 6;
            // 
            // mobjSendButton
            // 
            this.mobjSendButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSendButton.Location = new System.Drawing.Point(10, 178);
            this.mobjSendButton.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjSendButton.MaximumSize = new System.Drawing.Size(0, 50);
            this.mobjSendButton.Name = "mobjSendButton";
            this.mobjSendButton.Size = new System.Drawing.Size(300, 43);
            this.mobjSendButton.TabIndex = 7;
            this.mobjSendButton.Text = "Send";
            this.mobjSendButton.Click += new System.EventHandler(this.mobjSendButton_Click);
            // 
            // mobjSavedLabel
            // 
            this.mobjSavedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSavedLabel.Location = new System.Drawing.Point(0, 231);
            this.mobjSavedLabel.Name = "label1";
            this.mobjSavedLabel.Size = new System.Drawing.Size(320, 42);
            this.mobjSavedLabel.TabIndex = 8;
            this.mobjSavedLabel.Text = "Saved text:";
            this.mobjSavedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjSendButton, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjSavedLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjDemoRTB, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjSaverRTB, 0, 4);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.52632F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 31.57895F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.78947F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.52632F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 31.57895F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 9;
            // 
            // HandlingEventsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "HandlingEventsPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.RichTextBox mobjDemoRTB;
        private Gizmox.WebGUI.Forms.RichTextBox mobjSaverRTB;
        private Gizmox.WebGUI.Forms.Button mobjSendButton;
        private Gizmox.WebGUI.Forms.Label mobjSavedLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
