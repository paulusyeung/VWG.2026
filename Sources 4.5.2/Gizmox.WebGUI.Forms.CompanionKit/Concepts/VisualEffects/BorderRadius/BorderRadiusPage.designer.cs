namespace CompanionKit.Concepts.VisualEffects.BorderRadius
{
    partial class BorderRadiusPage
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
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabelInfo = new Gizmox.WebGUI.Forms.Label();
            this.mobjMinusButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjPlusButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AccessibleDescription = "";
            this.mobjTextBox.AccessibleName = "";
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Location = new System.Drawing.Point(21, 39);
            this.mobjTextBox.Multiline = true;
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(250, 143);
            this.mobjTextBox.TabIndex = 0;
            // 
            // mobjLabelInfo
            // 
            this.mobjLabelInfo.AccessibleDescription = "";
            this.mobjLabelInfo.AccessibleName = "";
            this.mobjLabelInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelInfo.Location = new System.Drawing.Point(330, 85);
            this.mobjLabelInfo.Name = "mobjLabelInfo";
            this.mobjLabelInfo.Size = new System.Drawing.Size(479, 36);
            this.mobjLabelInfo.TabIndex = 1;
            this.mobjLabelInfo.Text = "Use buttons to change radius:";
            // 
            // mobjMinusButton
            // 
            this.mobjMinusButton.AccessibleDescription = "";
            this.mobjMinusButton.AccessibleName = "";
            this.mobjMinusButton.Location = new System.Drawing.Point(21, 204);
            this.mobjMinusButton.Name = "mobjMinusButton";
            this.mobjMinusButton.Size = new System.Drawing.Size(120, 40);
            this.mobjMinusButton.TabIndex = 2;
            this.mobjMinusButton.Text = "Radius -5px";
            this.mobjMinusButton.Click += new System.EventHandler(this.mobjMinusButton_Click);
            // 
            // mobjPlusButton
            // 
            this.mobjPlusButton.AccessibleDescription = "";
            this.mobjPlusButton.AccessibleName = "";
            this.mobjPlusButton.Location = new System.Drawing.Point(151, 204);
            this.mobjPlusButton.Name = "mobjPlusButton";
            this.mobjPlusButton.Size = new System.Drawing.Size(120, 40);
            this.mobjPlusButton.TabIndex = 3;
            this.mobjPlusButton.Text = "Radius +5px";
            this.mobjPlusButton.Click += new System.EventHandler(this.mobjPlusButton_Click);
            // 
            // BorderRadiusPage
            // 
            this.Controls.Add(this.mobjPlusButton);
            this.Controls.Add(this.mobjMinusButton);
            this.Controls.Add(this.mobjLabelInfo);
            this.Controls.Add(this.mobjTextBox);
            this.Size = new System.Drawing.Size(479, 353);
            this.Text = "BorderRadiusPage";
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabelInfo;
        private Gizmox.WebGUI.Forms.Button mobjMinusButton;
        private Gizmox.WebGUI.Forms.Button mobjPlusButton;



    }
}