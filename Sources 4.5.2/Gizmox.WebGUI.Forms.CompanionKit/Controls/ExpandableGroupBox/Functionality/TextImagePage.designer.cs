namespace CompanionKit.Controls.ExpandableGroupBox.Functionality
{
    partial class TextImagePage
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
            this.mobjExpandableGroupBox = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjIsSpreadCheck = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjImageBeforeRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTextBeforeRB = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTIRelationGB = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox)).BeginInit();
            this.mobjTIRelationGB.SuspendLayout();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjExpandableGroupBox
            // 
            this.mobjExpandableGroupBox.CustomStyle = "X";
            this.mobjExpandableGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjExpandableGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjExpandableGroupBox.Location = new System.Drawing.Point(0, 70);
            this.mobjExpandableGroupBox.Name = "mobjExpandableGroupBox";
            this.mobjExpandableGroupBox.Size = new System.Drawing.Size(320, 100);
            this.mobjExpandableGroupBox.TabIndex = 0;
            this.mobjExpandableGroupBox.Text = "ExpandableGroupBox";
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 70);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "Change IsTextImageSpread and TextImageRelation property:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjIsSpreadCheck
            // 
            this.mobjIsSpreadCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjIsSpreadCheck.Location = new System.Drawing.Point(85, 292);
            this.mobjIsSpreadCheck.Name = "mobjIsSpreadCheck";
            this.mobjIsSpreadCheck.Size = new System.Drawing.Size(150, 45);
            this.mobjIsSpreadCheck.TabIndex = 2;
            this.mobjIsSpreadCheck.Text = "Is Text Image Spread";
            this.mobjIsSpreadCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjIsSpreadCheck.CheckedChanged += new System.EventHandler(this.mobjIsSpreadCheck_CheckedChanged);
            // 
            // mobjImageBeforeRB
            // 
            this.mobjImageBeforeRB.AutoSize = true;
            this.mobjImageBeforeRB.Checked = true;
            this.mobjImageBeforeRB.Location = new System.Drawing.Point(12, 30);
            this.mobjImageBeforeRB.Name = "mobjImageBeforeRB";
            this.mobjImageBeforeRB.Size = new System.Drawing.Size(120, 17);
            this.mobjImageBeforeRB.TabIndex = 5;
            this.mobjImageBeforeRB.Text = "ImageBeforeText";
            this.mobjImageBeforeRB.CheckedChanged += new System.EventHandler(this.mobjImageBeforeRB_CheckedChanged);
            // 
            // mobjTextBeforeRB
            // 
            this.mobjTextBeforeRB.AutoSize = true;
            this.mobjTextBeforeRB.Location = new System.Drawing.Point(12, 65);
            this.mobjTextBeforeRB.Name = "mobjTextBeforeRB";
            this.mobjTextBeforeRB.Size = new System.Drawing.Size(120, 17);
            this.mobjTextBeforeRB.TabIndex = 6;
            this.mobjTextBeforeRB.Text = "TextBeforeImage";
            this.mobjTextBeforeRB.CheckedChanged += new System.EventHandler(this.mobjTextBeforeRB_CheckedChanged);
            // 
            // mobjTIRelationGB
            // 
            this.mobjTIRelationGB.Controls.Add(this.mobjImageBeforeRB);
            this.mobjTIRelationGB.Controls.Add(this.mobjTextBeforeRB);
            this.mobjTIRelationGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTIRelationGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjTIRelationGB.Location = new System.Drawing.Point(0, 175);
            this.mobjTIRelationGB.Name = "mobjTIRelationGB";
            this.mobjTIRelationGB.Size = new System.Drawing.Size(320, 105);
            this.mobjTIRelationGB.TabIndex = 7;
            this.mobjTIRelationGB.TabStop = false;
            this.mobjTIRelationGB.Text = "TextImageRelation:";
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjTIRelationGB, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjIsSpreadCheck, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjExpandableGroupBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 8;
            // 
            // TextImagePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "TextImagePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox)).EndInit();
            this.mobjTIRelationGB.ResumeLayout(false);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ExpandableGroupBox mobjExpandableGroupBox;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsSpreadCheck;
        private Gizmox.WebGUI.Forms.RadioButton mobjImageBeforeRB;
        private Gizmox.WebGUI.Forms.RadioButton mobjTextBeforeRB;
        private Gizmox.WebGUI.Forms.GroupBox mobjTIRelationGB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;

    }
}