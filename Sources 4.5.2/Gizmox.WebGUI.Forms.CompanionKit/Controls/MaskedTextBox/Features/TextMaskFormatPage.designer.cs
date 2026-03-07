namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class TextMaskFormatPage
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
            this.mobjMaskValuesLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjMaskValuesComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextMaskFormatLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextMaskFormatComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueOfTextPropertyLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaskValuesLabel
            // 
            this.mobjMaskValuesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaskValuesLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjMaskValuesLabel.Name = "mobjMaskValuesLabel";
            this.mobjMaskValuesLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjMaskValuesLabel.Size = new System.Drawing.Size(160, 100);
            this.mobjMaskValuesLabel.TabIndex = 0;
            this.mobjMaskValuesLabel.Text = "Select mask:";
            this.mobjMaskValuesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjMaskedTextBox
            // 
            this.mobjMaskedTextBox.AllowDrag = false;
            this.mobjMaskedTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMaskedTextBox.CustomStyle = "Masked";
            this.mobjMaskedTextBox.Location = new System.Drawing.Point(163, 237);
            this.mobjMaskedTextBox.Mask = "00000";
            this.mobjMaskedTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaskedTextBox.Name = "mobjMaskedTextBox";
            this.mobjMaskedTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjMaskedTextBox.TabIndex = 1;
            this.mobjMaskedTextBox.TextChanged += new System.EventHandler(this.mobjMaskedTextBox_TextChanged);
            // 
            // mobjMaskValuesComboBox
            // 
            this.mobjMaskValuesComboBox.AllowDrag = false;
            this.mobjMaskValuesComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMaskValuesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMaskValuesComboBox.Location = new System.Drawing.Point(160, 39);
            this.mobjMaskValuesComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaskValuesComboBox.Name = "mobjMaskValuesComboBox";
            this.mobjMaskValuesComboBox.Size = new System.Drawing.Size(160, 25);
            this.mobjMaskValuesComboBox.TabIndex = 2;
            this.mobjMaskValuesComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjMaskValuesComboBox_SelectedIndexChanged);
            // 
            // mobjTextMaskFormatLabel
            // 
            this.mobjTextMaskFormatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextMaskFormatLabel.Location = new System.Drawing.Point(0, 100);
            this.mobjTextMaskFormatLabel.Name = "mobjTextMaskFormatLabel";
            this.mobjTextMaskFormatLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextMaskFormatLabel.Size = new System.Drawing.Size(160, 100);
            this.mobjTextMaskFormatLabel.TabIndex = 3;
            this.mobjTextMaskFormatLabel.Text = "Select Text Mask Format:";
            this.mobjTextMaskFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextMaskFormatComboBox
            // 
            this.mobjTextMaskFormatComboBox.AllowDrag = false;
            this.mobjTextMaskFormatComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextMaskFormatComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTextMaskFormatComboBox.Location = new System.Drawing.Point(160, 139);
            this.mobjTextMaskFormatComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextMaskFormatComboBox.Name = "mobjTextMaskFormatComboBox";
            this.mobjTextMaskFormatComboBox.Size = new System.Drawing.Size(160, 25);
            this.mobjTextMaskFormatComboBox.TabIndex = 4;
            this.mobjTextMaskFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjTextMaskFormatComboBox_SelectedIndexChanged);
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLabel.Location = new System.Drawing.Point(0, 200);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextLabel.Size = new System.Drawing.Size(160, 100);
            this.mobjTextLabel.TabIndex = 5;
            this.mobjTextLabel.Text = "Enter masked text:";
            this.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjValueOfTextPropertyLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjValueOfTextPropertyLabel, 2);
            this.mobjValueOfTextPropertyLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueOfTextPropertyLabel.Location = new System.Drawing.Point(0, 300);
            this.mobjValueOfTextPropertyLabel.Name = "mobjValueOfTextPropertyLabel";
            this.mobjValueOfTextPropertyLabel.Size = new System.Drawing.Size(320, 100);
            this.mobjValueOfTextPropertyLabel.TabIndex = 6;
            this.mobjValueOfTextPropertyLabel.Text = "Value of MaskedTextBox Text property:";
            this.mobjValueOfTextPropertyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjMaskValuesLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjMaskedTextBox, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjTextMaskFormatComboBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjValueOfTextPropertyLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjMaskValuesComboBox, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjTextMaskFormatLabel, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjTextLabel, 0, 2);
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
            this.mobjTLP.TabIndex = 7;
            // 
            // TextMaskFormatPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "TextMaskFormatPage";
            this.Load += new System.EventHandler(this.TextMaskFormatPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjMaskValuesLabel;
        private Gizmox.WebGUI.Forms.MaskedTextBox mobjMaskedTextBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjMaskValuesComboBox;
        private Gizmox.WebGUI.Forms.Label mobjTextMaskFormatLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjTextMaskFormatComboBox;
        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjValueOfTextPropertyLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}