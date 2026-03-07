using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.ExtendedToolTip.Functionality
{
    partial class DemoPage
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
            this.mobjExtendedToolTip = new Gizmox.WebGUI.Forms.ExtendedToolTip();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjIsExtended = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjContentText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjContentLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSetButton = new Gizmox.WebGUI.Forms.Button();
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
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 78);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Hover the button to see ExtendedToolTip. Content Html can be partly changed:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.Location = new System.Drawing.Point(5, 111);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(150, 50);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Hover me";
            // 
            // mobjIsExtended
            // 
            this.mobjIsExtended.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjIsExtended.Checked = true;
            this.mobjIsExtended.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjIsExtended.Location = new System.Drawing.Point(190, 111);
            this.mobjIsExtended.Name = "mobjIsExtended";
            this.mobjIsExtended.Size = new System.Drawing.Size(100, 50);
            this.mobjIsExtended.TabIndex = 2;
            this.mobjIsExtended.Text = "Extended";
            this.mobjIsExtended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjIsExtended.CheckedChanged += new System.EventHandler(this.mobjIsExtended_CheckedChanged);
            // 
            // mobjContentText
            // 
            this.mobjContentText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContentText.Location = new System.Drawing.Point(3, 256);
            this.mobjContentText.Multiline = true;
            this.mobjContentText.Name = "mobjContentText";
            this.mobjContentText.Size = new System.Drawing.Size(154, 131);
            this.mobjContentText.TabIndex = 3;
            this.mobjContentText.Text = "<h2 style = \"color:#A31947\">\r\nExtended ToolTip\r\n</h2>\r\n<p>Text</p>\r\n";
            // 
            // mobjContentLabel
            // 
            this.mobjContentLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContentLabel.Location = new System.Drawing.Point(0, 195);
            this.mobjContentLabel.Name = "mobjContentLabel";
            this.mobjContentLabel.Size = new System.Drawing.Size(160, 58);
            this.mobjContentLabel.TabIndex = 4;
            this.mobjContentLabel.Text = "Content Html:";
            this.mobjContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjSetButton
            // 
            this.mobjSetButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjSetButton.Location = new System.Drawing.Point(185, 281);
            this.mobjSetButton.Name = "mobjSetButton";
            this.mobjSetButton.Size = new System.Drawing.Size(110, 80);
            this.mobjSetButton.TabIndex = 5;
            this.mobjSetButton.Text = "Set";
            this.mobjSetButton.Click += new System.EventHandler(this.mobjSetButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjSetButton, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjContentLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjIsExtended, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjContentText, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 390);
            this.mobjTLP.TabIndex = 6;
            // 
            // DemoPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 390);
            this.Text = "DemoPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ExtendedToolTip mobjExtendedToolTip;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsExtended;
        private Gizmox.WebGUI.Forms.TextBox mobjContentText;
        private Gizmox.WebGUI.Forms.Label mobjContentLabel;
        private Gizmox.WebGUI.Forms.Button mobjSetButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}