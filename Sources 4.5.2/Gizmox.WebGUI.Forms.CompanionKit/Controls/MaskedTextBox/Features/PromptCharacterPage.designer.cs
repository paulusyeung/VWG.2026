namespace CompanionKit.Controls.MaskedTextBox.Features
{
    partial class PromptCharacterPage
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
            this.mobjMaskedTextBox = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.mobjPromptCharsLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPromptCharsComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjMaskedTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaskedTextBox
            // 
            this.mobjMaskedTextBox.AllowDrag = false;
            this.mobjMaskedTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMaskedTextBox.CustomStyle = "Masked";
            this.mobjMaskedTextBox.Location = new System.Drawing.Point(203, 287);
            this.mobjMaskedTextBox.Mask = "00/00/0000 90:00";
            this.mobjMaskedTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaskedTextBox.Name = "mobjMaskedTextBox";
            this.mobjMaskedTextBox.PromptChar = '*';
            this.mobjMaskedTextBox.Size = new System.Drawing.Size(194, 25);
            this.mobjMaskedTextBox.TabIndex = 0;
            this.mobjMaskedTextBox.Text = "**/**/**** **:**";
            // 
            // mobjPromptCharsLabel
            // 
            this.mobjPromptCharsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPromptCharsLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjPromptCharsLabel.Name = "mobjPromptCharsLabel";
            this.mobjPromptCharsLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjPromptCharsLabel.Size = new System.Drawing.Size(200, 200);
            this.mobjPromptCharsLabel.TabIndex = 1;
            this.mobjPromptCharsLabel.Text = "Select Prompt Character";
            this.mobjPromptCharsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjPromptCharsComboBox
            // 
            this.mobjPromptCharsComboBox.AllowDrag = false;
            this.mobjPromptCharsComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjPromptCharsComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjPromptCharsComboBox.Location = new System.Drawing.Point(200, 89);
            this.mobjPromptCharsComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjPromptCharsComboBox.Name = "mobjPromptCharsComboBox";
            this.mobjPromptCharsComboBox.Size = new System.Drawing.Size(200, 25);
            this.mobjPromptCharsComboBox.TabIndex = 2;
            this.mobjPromptCharsComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjPromptCharsComboBox_SelectedIndexChanged);
            // 
            // mobjMaskedTextLabel
            // 
            this.mobjMaskedTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaskedTextLabel.Location = new System.Drawing.Point(0, 200);
            this.mobjMaskedTextLabel.Name = "mobjMaskedTextLabel";
            this.mobjMaskedTextLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjMaskedTextLabel.Size = new System.Drawing.Size(200, 200);
            this.mobjMaskedTextLabel.TabIndex = 3;
            this.mobjMaskedTextLabel.Text = "Enter masked text";
            this.mobjMaskedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjPromptCharsLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjMaskedTextBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjPromptCharsComboBox, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjMaskedTextLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(400, 400);
            this.mobjTLP.TabIndex = 4;
            // 
            // PromptCharacterPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(400, 400);
            this.Text = "PromptCharacterPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MaskedTextBox mobjMaskedTextBox;
        private Gizmox.WebGUI.Forms.Label mobjPromptCharsLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjPromptCharsComboBox;
        private Gizmox.WebGUI.Forms.Label mobjMaskedTextLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}