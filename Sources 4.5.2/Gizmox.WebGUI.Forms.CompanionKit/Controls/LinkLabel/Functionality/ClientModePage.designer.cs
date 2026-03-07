namespace CompanionKit.Controls.LinkLabel.Functionality
{
    partial class ClientModePage
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
            this.mobjLinkLabel = new Gizmox.WebGUI.Forms.LinkLabel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjStatusLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLinkLabel
            // 
            this.mobjLinkLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.mobjLinkLabel.Location = new System.Drawing.Point(85, 325);
            this.mobjLinkLabel.Name = "mobjLinkLabel";
            this.mobjLinkLabel.Size = new System.Drawing.Size(150, 50);
            this.mobjLinkLabel.TabIndex = 0;
            this.mobjLinkLabel.TabStop = true;
            this.mobjLinkLabel.Text = "VisualWebGui";
            this.mobjLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjLinkLabel.Url = "http://www.visualwebgui.com/";
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 100);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Click the LinkLabel to open external URL resource on mouse click:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox.Location = new System.Drawing.Point(100, 225);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(120, 50);
            this.mobjCheckBox.TabIndex = 1;
            this.mobjCheckBox.Text = "Use Client mode";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjStatusLabel
            // 
            this.mobjStatusLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStatusLabel.Location = new System.Drawing.Point(0, 100);
            this.mobjStatusLabel.Name = "mobjStatusLabel";
            this.mobjStatusLabel.Size = new System.Drawing.Size(320, 100);
            this.mobjStatusLabel.TabIndex = 2;
            this.mobjStatusLabel.Text = "Current client-mode status: False";
            this.mobjStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjLinkLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjStatusLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 3;
            // 
            // ClientModePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ClientModePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }        

        #endregion

        private Gizmox.WebGUI.Forms.LinkLabel mobjLinkLabel;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjStatusLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
