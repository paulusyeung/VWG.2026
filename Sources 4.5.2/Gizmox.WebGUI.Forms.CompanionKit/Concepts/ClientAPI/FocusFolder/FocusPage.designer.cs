namespace CompanionKit.Concepts.ClientAPI.FocusFolder
{
    partial class FocusPage
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
            this.objCustomFocusableTextBox1 = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox();
            this.objCustomFocusableTextBox2 = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox();
            this.objCustomFocusableTextBox3 = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objCustomFocusableTextBox1
            // 
            this.objCustomFocusableTextBox1.AllowDrag = false;
            this.objCustomFocusableTextBox1.CustomStyle = "CustomFocusableTextBoxSkin";
            this.objCustomFocusableTextBox1.Location = new System.Drawing.Point(96, 70);
            this.objCustomFocusableTextBox1.Name = "objCustomFocusableTextBox1";
            this.objCustomFocusableTextBox1.Size = new System.Drawing.Size(100, 20);
            this.objCustomFocusableTextBox1.TabIndex = 0;
            // 
            // objCustomFocusableTextBox2
            // 
            this.objCustomFocusableTextBox2.AllowDrag = false;
            this.objCustomFocusableTextBox2.CustomStyle = "CustomFocusableTextBoxSkin";
            this.objCustomFocusableTextBox2.Location = new System.Drawing.Point(96, 120);
            this.objCustomFocusableTextBox2.Name = "objCustomFocusableTextBox2";
            this.objCustomFocusableTextBox2.Size = new System.Drawing.Size(100, 20);
            this.objCustomFocusableTextBox2.TabIndex = 1;
            // 
            // objCustomFocusableTextBox3
            // 
            this.objCustomFocusableTextBox3.AllowDrag = false;
            this.objCustomFocusableTextBox3.CustomStyle = "CustomFocusableTextBoxSkin";
            this.objCustomFocusableTextBox3.Location = new System.Drawing.Point(96, 170);
            this.objCustomFocusableTextBox3.Name = "objCustomFocusableTextBox3";
            this.objCustomFocusableTextBox3.Size = new System.Drawing.Size(100, 20);
            this.objCustomFocusableTextBox3.TabIndex = 2;
            // 
            // objLabel
            // 
            this.objLabel.AutoSize = true;
            this.objLabel.Location = new System.Drawing.Point(81, 16);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 3;
            this.objLabel.Text = "Hover on textbox to focus";
            // 
            // FocusPage
            // 
            this.Controls.Add(this.objLabel);
            this.Controls.Add(this.objCustomFocusableTextBox3);
            this.Controls.Add(this.objCustomFocusableTextBox2);
            this.Controls.Add(this.objCustomFocusableTextBox1);
            this.Size = new System.Drawing.Size(300, 271);
            this.Text = "FocusPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox objCustomFocusableTextBox1;
        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox objCustomFocusableTextBox2;
        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder.CustomFocusableTextBox objCustomFocusableTextBox3;
        private Gizmox.WebGUI.Forms.Label objLabel;



    }
}