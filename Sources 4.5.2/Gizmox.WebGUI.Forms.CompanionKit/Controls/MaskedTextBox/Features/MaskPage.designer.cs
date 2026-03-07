namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class MaskPage
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
            this.mobjMaskLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaskComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjMaskedTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaskLabel
            // 
            this.mobjMaskLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaskLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjMaskLabel.Name = "mobjMaskLabel";
            this.mobjMaskLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjMaskLabel.Size = new System.Drawing.Size(160, 200);
            this.mobjMaskLabel.TabIndex = 0;
            this.mobjMaskLabel.Text = "Select mask";
            this.mobjMaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjMaskComboBox
            // 
            this.mobjMaskComboBox.AllowDrag = false;
            this.mobjMaskComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMaskComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMaskComboBox.Location = new System.Drawing.Point(160, 89);
            this.mobjMaskComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaskComboBox.Name = "mobjMaskComboBox";
            this.mobjMaskComboBox.Size = new System.Drawing.Size(160, 25);
            this.mobjMaskComboBox.TabIndex = 1;
            this.mobjMaskComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjMaskComboBox_SelectedIndexChanged);
            // 
            // mobjMaskedTextBox
            // 
            this.mobjMaskedTextBox.AllowDrag = false;
            this.mobjMaskedTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMaskedTextBox.CustomStyle = "Masked";
            this.mobjMaskedTextBox.Location = new System.Drawing.Point(163, 287);
            this.mobjMaskedTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaskedTextBox.Name = "mobjMaskedTextBox";
            this.mobjMaskedTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjMaskedTextBox.TabIndex = 2;
            // 
            // mobjMaskedTextLabel
            // 
            this.mobjMaskedTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaskedTextLabel.Location = new System.Drawing.Point(0, 200);
            this.mobjMaskedTextLabel.Name = "mobjMaskedTextLabel";
            this.mobjMaskedTextLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjMaskedTextLabel.Size = new System.Drawing.Size(160, 200);
            this.mobjMaskedTextLabel.TabIndex = 3;
            this.mobjMaskedTextLabel.Text = "Enter masked text";
            this.mobjMaskedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjMaskLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjMaskedTextBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjMaskedTextLabel, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjMaskComboBox, 1, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 4;
            // 
            // MaskPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "MaskPage";
            this.Load += new System.EventHandler(this.MaskPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjMaskLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjMaskComboBox;
        private Gizmox.WebGUI.Forms.MaskedTextBox mobjMaskedTextBox;
        private Gizmox.WebGUI.Forms.Label mobjMaskedTextLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}