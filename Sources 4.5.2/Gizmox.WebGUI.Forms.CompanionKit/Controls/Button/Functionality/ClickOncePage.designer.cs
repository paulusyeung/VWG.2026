namespace CompanionKit.Controls.Button.Functionality
{
    partial class ClickOncePage
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAllowCheckOnceCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.ClickOnce = true;
            this.mobjButton.Location = new System.Drawing.Point(85, 129);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(149, 73);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Click Once";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjAllowCheckOnceCheckBox
            // 
            this.mobjAllowCheckOnceCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAllowCheckOnceCheckBox.Location = new System.Drawing.Point(50, 289);
            this.mobjAllowCheckOnceCheckBox.Name = "mobjAllowCheckOnceCheckBox";
            this.mobjAllowCheckOnceCheckBox.Size = new System.Drawing.Size(220, 50);
            this.mobjAllowCheckOnceCheckBox.TabIndex = 1;
            this.mobjAllowCheckOnceCheckBox.Text = "Allow ClickOnce for the Button";
            this.mobjAllowCheckOnceCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjAllowCheckOnceCheckBox.UseVisualStyleBackColor = true;
            this.mobjAllowCheckOnceCheckBox.CheckedChanged += new System.EventHandler(this.mobjAllowCheckOnceCheckBox_CheckedChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Turn on/off \'click once\' for the button:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjAllowCheckOnceCheckBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 3;
            // 
            // ClickOncePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "ClickOncePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjAllowCheckOnceCheckBox;
        internal Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
