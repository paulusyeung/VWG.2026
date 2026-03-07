namespace CompanionKit.Controls.RadioButton.Programming
{
    partial class CheckStateChangedPage
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
            this.mobjRadioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckBox2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mobjRadioButton1
            // 
            this.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton1.AutoSize = true;
            this.mobjRadioButton1.Location = new System.Drawing.Point(24, 25);
            this.mobjRadioButton1.Name = "mobjRadioButton1";
            this.mobjRadioButton1.Size = new System.Drawing.Size(90, 17);
            this.mobjRadioButton1.TabIndex = 0;
            this.mobjRadioButton1.Text = "RadioButton1";
            this.mobjRadioButton1.CheckedChanged += new System.EventHandler(this.mobjRadioButton1_CheckedChanged);
            // 
            // mobjRadioButton2
            // 
            this.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton2.AutoSize = true;
            this.mobjRadioButton2.Location = new System.Drawing.Point(24, 127);
            this.mobjRadioButton2.Name = "mobjRadioButton2";
            this.mobjRadioButton2.Size = new System.Drawing.Size(90, 17);
            this.mobjRadioButton2.TabIndex = 1;
            this.mobjRadioButton2.Text = "RadioButton2";
            this.mobjRadioButton2.CheckedChanged += new System.EventHandler(this.mobjRadioButton2_CheckedChanged);
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel1.AutoSize = true;
            this.mobjLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjLabel1.Location = new System.Drawing.Point(19, 69);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel1.TabIndex = 2;
            this.mobjLabel1.Text = "label1";
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjLabel2.AutoSize = true;
            this.mobjLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjLabel2.Location = new System.Drawing.Point(19, 171);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel2.TabIndex = 3;
            this.mobjLabel2.Text = "label2";
            // 
            // mobjCheckBox1
            // 
            this.mobjCheckBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox1.AutoSize = true;
            this.mobjCheckBox1.Location = new System.Drawing.Point(177, 25);
            this.mobjCheckBox1.Name = "mobjCheckBox1";
            this.mobjCheckBox1.Size = new System.Drawing.Size(89, 17);
            this.mobjCheckBox1.TabIndex = 4;
            this.mobjCheckBox1.Text = "RB1 Checked";
            this.mobjCheckBox1.CheckedChanged += new System.EventHandler(this.mobjCheckBox1_CheckedChanged);
            // 
            // mobjCheckBox2
            // 
            this.mobjCheckBox2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjCheckBox2.AutoSize = true;
            this.mobjCheckBox2.Location = new System.Drawing.Point(177, 127);
            this.mobjCheckBox2.Name = "mobjCheckBox2";
            this.mobjCheckBox2.Size = new System.Drawing.Size(89, 17);
            this.mobjCheckBox2.TabIndex = 5;
            this.mobjCheckBox2.Text = "RB2 Checked";
            this.mobjCheckBox2.CheckedChanged += new System.EventHandler(this.mobjCheckBox2_CheckedChanged);
            // 
            // CheckStateChangedPage
            // 
            this.Controls.Add(this.mobjCheckBox2);
            this.Controls.Add(this.mobjCheckBox1);
            this.Controls.Add(this.mobjLabel2);
            this.Controls.Add(this.mobjLabel1);
            this.Controls.Add(this.mobjRadioButton2);
            this.Controls.Add(this.mobjRadioButton1);
            this.Size = new System.Drawing.Size(323, 215);
            this.Text = "CheckStateChangedPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton2;
        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox1;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox2;


    }
}
