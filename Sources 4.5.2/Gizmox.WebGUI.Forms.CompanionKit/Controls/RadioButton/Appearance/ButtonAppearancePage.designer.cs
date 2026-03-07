namespace CompanionKit.Controls.RadioButton.Appearance
{
    partial class ButtonAppearancePage
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
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjRadioButton3 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjGroupBox.Controls.Add(this.mobjRadioButton3);
            this.mobjGroupBox.Controls.Add(this.mobjRadioButton1);
            this.mobjGroupBox.Controls.Add(this.mobjRadioButton2);
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(28, 93);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(163, 123);
            this.mobjGroupBox.TabIndex = 0;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "RadioButtons";
            // 
            // mobjRadioButton3
            // 
            this.mobjRadioButton3.AutoSize = true;
            this.mobjRadioButton3.Location = new System.Drawing.Point(25, 85);
            this.mobjRadioButton3.Name = "mobjRadioButton3";
            this.mobjRadioButton3.Size = new System.Drawing.Size(87, 17);
            this.mobjRadioButton3.TabIndex = 5;
            this.mobjRadioButton3.Text = "radioButton3";
            // 
            // mobjRadioButton1
            // 
            this.mobjRadioButton1.AutoSize = true;
            this.mobjRadioButton1.Checked = true;
            this.mobjRadioButton1.Location = new System.Drawing.Point(25, 29);
            this.mobjRadioButton1.Name = "mobjRadioButton1";
            this.mobjRadioButton1.Size = new System.Drawing.Size(87, 17);
            this.mobjRadioButton1.TabIndex = 3;
            this.mobjRadioButton1.Text = "radioButton1";
            // 
            // mobjRadioButton2
            // 
            this.mobjRadioButton2.AutoSize = true;
            this.mobjRadioButton2.Location = new System.Drawing.Point(25, 57);
            this.mobjRadioButton2.Name = "mobjRadioButton2";
            this.mobjRadioButton2.Size = new System.Drawing.Size(87, 17);
            this.mobjRadioButton2.TabIndex = 4;
            this.mobjRadioButton2.Text = "radioButton2";
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Normal",
            "Button"});
            this.mobjComboBox.Location = new System.Drawing.Point(28, 48);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(111, 30);
            this.mobjComboBox.TabIndex = 1;
            this.mobjComboBox.Text = "Normal";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.objComboBox_SelectedIndexChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(25, 26);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "ButtonAppearance:";
            // 
            // ButtonAppearancePage
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjComboBox);
            this.Controls.Add(this.mobjGroupBox);
            this.Size = new System.Drawing.Size(217, 238);
            this.Text = "ButtonAppearancePage";
            this.mobjGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton3;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton2;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}