namespace CompanionKit.Controls.Form.Features
{
    partial class BorderStyleForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjOkButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjOkButton
            // 
            this.mobjOkButton.Location = new System.Drawing.Point(100, 106);
            this.mobjOkButton.Name = "mobjOkButton";
            this.mobjOkButton.Size = new System.Drawing.Size(116, 44);
            this.mobjOkButton.TabIndex = 8;
            this.mobjOkButton.Text = "Ok";
            this.mobjOkButton.UseVisualStyleBackColor = true;
            this.mobjOkButton.Click += new System.EventHandler(this.mobjOkButton_Click);
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Location = new System.Drawing.Point(95, 62);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(121, 30);
            this.mobjComboBox.TabIndex = 11;
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Location = new System.Drawing.Point(54, 25);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(210, 22);
            this.mobjLabel.TabIndex = 12;
            this.mobjLabel.Text = "Select a form border style:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BorderStyleForm
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjComboBox);
            this.Controls.Add(this.mobjOkButton);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(334, 165);
            this.Text = "BorderStyle Form";
            this.Load += new System.EventHandler(this.BorderStyleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

		protected global::Gizmox.WebGUI.Forms.Button mobjOkButton;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private global::Gizmox.WebGUI.Forms.Label mobjLabel;


    }
}