namespace CompanionKit.Concepts.ClientAPI.DomainUpDown
{
    partial class DomainUpDownPage
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
            this.mobjDomainUpDown = new Gizmox.WebGUI.Forms.DomainUpDown();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabelSelectedIndex = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjDomainUpDown
            // 
            this.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDomainUpDown.ClientId = "dud";
            this.mobjDomainUpDown.Items.Add("1");
            this.mobjDomainUpDown.Items.Add("2");
            this.mobjDomainUpDown.Items.Add("3");
            this.mobjDomainUpDown.Items.Add("4");
            this.mobjDomainUpDown.Items.Add("5");
            this.mobjDomainUpDown.Items.Add("6");
            this.mobjDomainUpDown.Location = new System.Drawing.Point(31, 139);
            this.mobjDomainUpDown.Name = "mobjDomainUpDown";
            this.mobjDomainUpDown.Size = new System.Drawing.Size(130, 20);
            this.mobjDomainUpDown.TabIndex = 0;
            this.mobjDomainUpDown.Text = "-";
            this.mobjDomainUpDown.ClientSelectedItemChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjDomainUpDown_ClientSelectedItemChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 15, 0, 0);
            this.mobjLabel.Size = new System.Drawing.Size(419, 88);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Change item in ComboBox to change value in DomainUpDown:";
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.ClientId = "cb";
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3",
            "item4",
            "item5",
            "item6"});
            this.mobjComboBox.Location = new System.Drawing.Point(31, 96);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(130, 21);
            this.mobjComboBox.TabIndex = 2;
            this.mobjComboBox.Text = "-";
            this.mobjComboBox.ClientSelectedIndexChanged += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjComboBox_ClientSelectedIndexChanged);
            // 
            // mobjLabelSelectedIndex
            // 
            this.mobjLabelSelectedIndex.ClientId = "lbl";
            this.mobjLabelSelectedIndex.Location = new System.Drawing.Point(28, 181);
            this.mobjLabelSelectedIndex.Name = "mobjLabelSelectedIndex";
            this.mobjLabelSelectedIndex.Size = new System.Drawing.Size(165, 28);
            this.mobjLabelSelectedIndex.TabIndex = 3;
            this.mobjLabelSelectedIndex.Text = "Selected Index: ";
            // 
            // DomainUpDownPage
            // 
            this.Controls.Add(this.mobjLabelSelectedIndex);
            this.Controls.Add(this.mobjComboBox);
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjDomainUpDown);
            this.Size = new System.Drawing.Size(419, 306);
            this.Text = "DomainUpDownPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DomainUpDown mobjDomainUpDown;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjLabelSelectedIndex;



    }
}