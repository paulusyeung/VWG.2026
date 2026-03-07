namespace CompanionKit.Controls.RichTextBox.Functionality
{
    partial class ControlPropertiesPage
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
            this.mobjFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFontRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjSelectionFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectionFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSelectionFontRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjMultiLineCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMultiLineRichTextBox = new Gizmox.WebGUI.Forms.RichTextBox();
            this.mobjFontRichTExtBoxGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTLP1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjSelectionFontRichTExtBoxGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTLP2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjMultiLineRichTExtBoxGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTLP3 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLPMain = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjFontRichTExtBoxGroupBox.SuspendLayout();
            this.mobjTLP1.SuspendLayout();
            this.mobjSelectionFontRichTExtBoxGroupBox.SuspendLayout();
            this.mobjTLP2.SuspendLayout();
            this.mobjMultiLineRichTExtBoxGroupBox.SuspendLayout();
            this.mobjTLP3.SuspendLayout();
            this.mobjTLPMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjFontLabel
            // 
            this.mobjFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontLabel.Location = new System.Drawing.Point(31, 74);
            this.mobjFontLabel.Name = "fontLabel";
            this.mobjFontLabel.Size = new System.Drawing.Size(172, 36);
            this.mobjFontLabel.TabIndex = 0;
            this.mobjFontLabel.Text = "Font";
            this.mobjFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjFontButton
            // 
            this.mobjFontButton.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjFontButton.Location = new System.Drawing.Point(172, 6);
            this.mobjFontButton.Name = "fontButton";
            this.mobjFontButton.Size = new System.Drawing.Size(322, 23);
            this.mobjFontButton.TabIndex = 1;
            this.mobjFontButton.Text = "Change Font...";
            this.mobjFontButton.UseVisualStyleBackColor = true;
            this.mobjFontButton.Click += new System.EventHandler(this.mobjFontButton_Click);
            // 
            // mobjFontRichTextBox
            // 
            this.mobjTLP1.SetColumnSpan(this.mobjFontRichTextBox, 2);
            this.mobjFontRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontRichTextBox.Location = new System.Drawing.Point(10, 46);
            this.mobjFontRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjFontRichTextBox.Name = "demoFontRichTextBox";
            this.mobjFontRichTextBox.Size = new System.Drawing.Size(474, 90);
            this.mobjFontRichTextBox.TabIndex = 2;
            // 
            // mobjSelectionFontLabel
            // 
            this.mobjSelectionFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectionFontLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSelectionFontLabel.Name = "selectionFontLabel";
            this.mobjSelectionFontLabel.Size = new System.Drawing.Size(172, 36);
            this.mobjSelectionFontLabel.TabIndex = 3;
            this.mobjSelectionFontLabel.Text = "Selection font:";
            this.mobjSelectionFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjSelectionFontButton
            // 
            this.mobjSelectionFontButton.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjSelectionFontButton.Location = new System.Drawing.Point(172, 6);
            this.mobjSelectionFontButton.Name = "selectionFontButton";
            this.mobjSelectionFontButton.Size = new System.Drawing.Size(322, 23);
            this.mobjSelectionFontButton.TabIndex = 4;
            this.mobjSelectionFontButton.Text = "Change selection font...";
            this.mobjSelectionFontButton.UseVisualStyleBackColor = true;
            this.mobjSelectionFontButton.Click += new System.EventHandler(this.mobjSelectionFontButton_Click);
            // 
            // mobjSelectionFontRichTextBox
            // 
            this.mobjTLP2.SetColumnSpan(this.mobjSelectionFontRichTextBox, 2);
            this.mobjSelectionFontRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectionFontRichTextBox.Location = new System.Drawing.Point(10, 46);
            this.mobjSelectionFontRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjSelectionFontRichTextBox.Name = "demoSelectionFontRichTextBox";
            this.mobjSelectionFontRichTextBox.Size = new System.Drawing.Size(474, 90);
            this.mobjSelectionFontRichTextBox.TabIndex = 5;
            // 
            // mobjMultiLineCheckBox
            // 
            this.mobjMultiLineCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjMultiLineCheckBox.Location = new System.Drawing.Point(197, 0);
            this.mobjMultiLineCheckBox.Name = "multiLineCheckBox";
            this.mobjMultiLineCheckBox.Size = new System.Drawing.Size(200, 37);
            this.mobjMultiLineCheckBox.TabIndex = 6;
            this.mobjMultiLineCheckBox.Text = "Allow multiline for RichTextBox";
            this.mobjMultiLineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjMultiLineCheckBox.UseVisualStyleBackColor = true;
            this.mobjMultiLineCheckBox.CheckedChanged += new System.EventHandler(this.mobjMultiLineCheckBox_CheckedChanged);
            // 
            // mobjMultiLineRichTextBox
            // 
            this.mobjMultiLineRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMultiLineRichTextBox.Location = new System.Drawing.Point(10, 47);
            this.mobjMultiLineRichTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjMultiLineRichTextBox.Name = "demoMultiLineRichTextBox";
            this.mobjMultiLineRichTextBox.Size = new System.Drawing.Size(474, 91);
            this.mobjMultiLineRichTextBox.TabIndex = 7;
            // 
            // mobjFontRichTExtBoxGroupBox
            // 
            this.mobjFontRichTExtBoxGroupBox.Controls.Add(this.mobjTLP1);
            this.mobjFontRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjFontRichTExtBoxGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjFontRichTExtBoxGroupBox.Name = "demoFontRichTExtBoxGroupBox";
            this.mobjFontRichTExtBoxGroupBox.Size = new System.Drawing.Size(500, 166);
            this.mobjFontRichTExtBoxGroupBox.TabIndex = 8;
            this.mobjFontRichTExtBoxGroupBox.TabStop = false;
            this.mobjFontRichTExtBoxGroupBox.Text = "Changing Font property for RichTextBox";
            // 
            // mobjTLP1
            // 
            this.mobjTLP1.ColumnCount = 2;
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP1.Controls.Add(this.mobjFontLabel, 0, 0);
            this.mobjTLP1.Controls.Add(this.mobjFontButton, 1, 0);
            this.mobjTLP1.Controls.Add(this.mobjFontRichTextBox, 0, 1);
            this.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP1.Location = new System.Drawing.Point(3, 17);
            this.mobjTLP1.Name = "mobjTLP1";
            this.mobjTLP1.RowCount = 2;
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75F));
            this.mobjTLP1.Size = new System.Drawing.Size(494, 146);
            this.mobjTLP1.TabIndex = 12;
            // 
            // mobjSelectionFontRichTExtBoxGroupBox
            // 
            this.mobjSelectionFontRichTExtBoxGroupBox.Controls.Add(this.mobjTLP2);
            this.mobjSelectionFontRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectionFontRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjSelectionFontRichTExtBoxGroupBox.Location = new System.Drawing.Point(0, 166);
            this.mobjSelectionFontRichTExtBoxGroupBox.Name = "demoSelectionFontRichTExtBoxGroupBox";
            this.mobjSelectionFontRichTExtBoxGroupBox.Size = new System.Drawing.Size(500, 166);
            this.mobjSelectionFontRichTExtBoxGroupBox.TabIndex = 9;
            this.mobjSelectionFontRichTExtBoxGroupBox.TabStop = false;
            this.mobjSelectionFontRichTExtBoxGroupBox.Text = "Changing selection Font property for RichTextBox";
            // 
            // mobjTLP2
            // 
            this.mobjTLP2.ColumnCount = 2;
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP2.Controls.Add(this.mobjSelectionFontButton, 1, 0);
            this.mobjTLP2.Controls.Add(this.mobjSelectionFontLabel, 0, 0);
            this.mobjTLP2.Controls.Add(this.mobjSelectionFontRichTextBox, 0, 1);
            this.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP2.Location = new System.Drawing.Point(3, 17);
            this.mobjTLP2.Name = "mobjTLP2";
            this.mobjTLP2.RowCount = 2;
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75F));
            this.mobjTLP2.Size = new System.Drawing.Size(494, 146);
            this.mobjTLP2.TabIndex = 12;
            // 
            // mobjMultiLineRichTExtBoxGroupBox
            // 
            this.mobjMultiLineRichTExtBoxGroupBox.Controls.Add(this.mobjTLP3);
            this.mobjMultiLineRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMultiLineRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjMultiLineRichTExtBoxGroupBox.Location = new System.Drawing.Point(0, 332);
            this.mobjMultiLineRichTExtBoxGroupBox.Name = "demoMultiLineRichTExtBoxGroupBox";
            this.mobjMultiLineRichTExtBoxGroupBox.Size = new System.Drawing.Size(500, 168);
            this.mobjMultiLineRichTExtBoxGroupBox.TabIndex = 10;
            this.mobjMultiLineRichTExtBoxGroupBox.TabStop = false;
            this.mobjMultiLineRichTExtBoxGroupBox.Text = "Changing selection property for RichTextBox";
            // 
            // mobjTLP3
            // 
            this.mobjTLP3.ColumnCount = 1;
            this.mobjTLP3.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP3.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP3.Controls.Add(this.mobjMultiLineRichTextBox, 0, 1);
            this.mobjTLP3.Controls.Add(this.mobjMultiLineCheckBox, 0, 0);
            this.mobjTLP3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP3.Location = new System.Drawing.Point(3, 17);
            this.mobjTLP3.Name = "mobjTLP3";
            this.mobjTLP3.RowCount = 2;
            this.mobjTLP3.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP3.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75F));
            this.mobjTLP3.Size = new System.Drawing.Size(494, 148);
            this.mobjTLP3.TabIndex = 12;
            // 
            // mobjTLPMain
            // 
            this.mobjTLPMain.ColumnCount = 1;
            this.mobjTLPMain.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLPMain.Controls.Add(this.mobjFontRichTExtBoxGroupBox, 0, 0);
            this.mobjTLPMain.Controls.Add(this.mobjMultiLineRichTExtBoxGroupBox, 0, 2);
            this.mobjTLPMain.Controls.Add(this.mobjSelectionFontRichTExtBoxGroupBox, 0, 1);
            this.mobjTLPMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLPMain.Location = new System.Drawing.Point(0, 0);
            this.mobjTLPMain.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLPMain.Name = "mobjTLPMain";
            this.mobjTLPMain.RowCount = 3;
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLPMain.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLPMain.Size = new System.Drawing.Size(500, 500);
            this.mobjTLPMain.TabIndex = 11;
            // 
            // ControlPropertiesPage
            // 
            this.Controls.Add(this.mobjTLPMain);
            this.Size = new System.Drawing.Size(500, 500);
            this.Text = "ControlPropertiesPage";
            this.mobjFontRichTExtBoxGroupBox.ResumeLayout(false);
            this.mobjTLP1.ResumeLayout(false);
            this.mobjSelectionFontRichTExtBoxGroupBox.ResumeLayout(false);
            this.mobjTLP2.ResumeLayout(false);
            this.mobjMultiLineRichTExtBoxGroupBox.ResumeLayout(false);
            this.mobjTLP3.ResumeLayout(false);
            this.mobjTLPMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjFontButton;
        private Gizmox.WebGUI.Forms.RichTextBox mobjFontRichTextBox;
        private Gizmox.WebGUI.Forms.Label mobjSelectionFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjSelectionFontButton;
        private Gizmox.WebGUI.Forms.RichTextBox mobjSelectionFontRichTextBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjMultiLineCheckBox;
        private Gizmox.WebGUI.Forms.RichTextBox mobjMultiLineRichTextBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjFontRichTExtBoxGroupBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjSelectionFontRichTExtBoxGroupBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjMultiLineRichTExtBoxGroupBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLPMain;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP2;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP3;



    }
}