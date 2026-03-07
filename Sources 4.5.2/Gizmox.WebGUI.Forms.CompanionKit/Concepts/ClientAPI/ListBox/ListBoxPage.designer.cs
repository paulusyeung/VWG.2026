namespace CompanionKit.Concepts.ClientAPI.ListBox
{
    partial class ListBoxPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFillButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCheckBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjClearButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCheckBox2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckBox3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.ClientId = "lbox";
            this.mobjListBox.Location = new System.Drawing.Point(18, 82);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(175, 186);
            this.mobjListBox.TabIndex = 0;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Padding = new Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0);
            this.mobjInfoLabel.Size = new System.Drawing.Size(391, 81);
            this.mobjInfoLabel.TabIndex = 2;
            this.mobjInfoLabel.Text = "Click button to fill ListBox with tagNames of checked CheckBoxes:";
            // 
            // mobjFillButton
            // 
            this.mobjFillButton.Location = new System.Drawing.Point(18, 281);
            this.mobjFillButton.Name = "mobjFillButton";
            this.mobjFillButton.Size = new System.Drawing.Size(80, 23);
            this.mobjFillButton.TabIndex = 3;
            this.mobjFillButton.Text = "Fill";
            this.mobjFillButton.Click += new System.EventHandler(this.mobjFillButton_Click);
            // 
            // mobjCheckBox1
            // 
            this.mobjCheckBox1.AutoSize = true;
            this.mobjCheckBox1.ClientId = "chb1";
            this.mobjCheckBox1.Location = new System.Drawing.Point(208, 122);
            this.mobjCheckBox1.Name = "mobjCheckBox1";
            this.mobjCheckBox1.Size = new System.Drawing.Size(59, 17);
            this.mobjCheckBox1.TabIndex = 5;
            this.mobjCheckBox1.Text = "check1";
            // 
            // mobjClearButton
            // 
            this.mobjClearButton.Location = new System.Drawing.Point(113, 281);
            this.mobjClearButton.Name = "mobjClearButton";
            this.mobjClearButton.Size = new System.Drawing.Size(80, 23);
            this.mobjClearButton.TabIndex = 7;
            this.mobjClearButton.Text = "Clear";
            this.mobjClearButton.Click += new System.EventHandler(this.mobjClearButton_Click);
            // 
            // mobjCheckBox2
            // 
            this.mobjCheckBox2.AutoSize = true;
            this.mobjCheckBox2.ClientId = "chb2";
            this.mobjCheckBox2.Location = new System.Drawing.Point(208, 155);
            this.mobjCheckBox2.Name = "mobjCheckBox2";
            this.mobjCheckBox2.Size = new System.Drawing.Size(59, 17);
            this.mobjCheckBox2.TabIndex = 8;
            this.mobjCheckBox2.Text = "check2";
            // 
            // mobjCheckBox3
            // 
            this.mobjCheckBox3.AutoSize = true;
            this.mobjCheckBox3.ClientId = "chb3";
            this.mobjCheckBox3.Location = new System.Drawing.Point(208, 188);
            this.mobjCheckBox3.Name = "mobjCheckBox3";
            this.mobjCheckBox3.Size = new System.Drawing.Size(59, 17);
            this.mobjCheckBox3.TabIndex = 9;
            this.mobjCheckBox3.Text = "check3";
            // 
            // ListBoxPage
            // 
            this.ClientId = "uc";
            this.Controls.Add(this.mobjCheckBox3);
            this.Controls.Add(this.mobjCheckBox2);
            this.Controls.Add(this.mobjClearButton);
            this.Controls.Add(this.mobjCheckBox1);
            this.Controls.Add(this.mobjFillButton);
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjListBox);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ListBoxPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Button mobjFillButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox1;
        private Gizmox.WebGUI.Forms.Button mobjClearButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox2;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox3;

    }
}