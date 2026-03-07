namespace CompanionKit.Concepts.ClientAPI.NumericUpDown
{
    partial class NumericUpDownPage
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
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjSelectedInfo = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.ClientId = "nud";
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.Location = new System.Drawing.Point(16, 235);
            this.mobjNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mobjNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.Name = "mobjNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.mobjNumericUpDown.TabIndex = 0;
            this.mobjNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjNumericUpDown.ValueChanged += new System.EventHandler(this.mobjNumericUpDown_ValueChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0);
            this.mobjLabel.Size = new System.Drawing.Size(404, 56);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Select item in ListBox to change NumericUpDown value:";
            // 
            // mobjListBox
            // 
            this.mobjListBox.ClientId = "lb";
            this.mobjListBox.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3",
            "item4",
            "item5",
            "item6"});
            this.mobjListBox.Location = new System.Drawing.Point(16, 64);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(171, 160);
            this.mobjListBox.TabIndex = 2;
            this.mobjListBox.SelectedIndexChanged += new System.EventHandler(this.mobjListBox_SelectedIndexChanged);
            // 
            // mobjSelectedInfo
            // 
            this.mobjSelectedInfo.ClientId = "info";
            this.mobjSelectedInfo.Location = new System.Drawing.Point(146, 235);
            this.mobjSelectedInfo.Name = "mobjSelectedInfo";
            this.mobjSelectedInfo.Size = new System.Drawing.Size(76, 21);
            this.mobjSelectedInfo.TabIndex = 3;
            this.mobjSelectedInfo.Text = "value: 1";
            this.mobjSelectedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericUpDownPage
            // 
            this.Controls.Add(this.mobjSelectedInfo);
            this.Controls.Add(this.mobjListBox);
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjNumericUpDown);
            this.Size = new System.Drawing.Size(404, 400);
            this.Text = "NumericUpDownPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjSelectedInfo;



    }
}