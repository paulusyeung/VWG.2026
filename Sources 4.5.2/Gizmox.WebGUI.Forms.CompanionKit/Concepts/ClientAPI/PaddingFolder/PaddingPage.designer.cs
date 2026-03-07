namespace CompanionKit.Concepts.ClientAPI.PaddingFolder
{
    partial class PaddingPage
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
            this.objCustomPaddingButton = new Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.PaddingFolder.CustomPaddingButton();
            this.objPaddingGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            this.objPaddingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // objCustomPaddingButton
            // 
            this.objCustomPaddingButton.CustomStyle = "CustomPaddingButtonSkin";
            this.objCustomPaddingButton.Location = new System.Drawing.Point(105, 136);
            this.objCustomPaddingButton.Name = "objCustomPaddingButton";
            this.objCustomPaddingButton.Size = new System.Drawing.Size(123, 59);
            this.objCustomPaddingButton.TabIndex = 1;
            this.objCustomPaddingButton.Text = "Long test text string";
            // 
            // objPaddingGroupBox
            // 
            this.objPaddingGroupBox.Controls.Add(this.objLabel);
            this.objPaddingGroupBox.Controls.Add(this.objCustomPaddingButton);
            this.objPaddingGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objPaddingGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objPaddingGroupBox.Location = new System.Drawing.Point(15, 15);
            this.objPaddingGroupBox.Name = "objPaddingGroupBox";
            this.objPaddingGroupBox.Size = new System.Drawing.Size(278, 318);
            this.objPaddingGroupBox.TabIndex = 0;
            this.objPaddingGroupBox.TabStop = false;
            this.objPaddingGroupBox.Text = "Padding";
            // 
            // objLabel
            // 
            this.objLabel.AutoSize = true;
            this.objLabel.Location = new System.Drawing.Point(15, 30);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 2;
            this.objLabel.Text = "Click to button by left (to increase)\r\nor right (to decrease) mouse button\r\nto ch" +
    "ange padding value\r\n";
            // 
            // PaddingPage
            // 
            this.Controls.Add(this.objPaddingGroupBox);
            this.DockPadding.All = 15;
            this.MaximumSize = new System.Drawing.Size(370, 348);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(370, 348);
            this.Text = "PaddingPage";
            this.objPaddingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.PaddingFolder.CustomPaddingButton objCustomPaddingButton; 
        private Gizmox.WebGUI.Forms.GroupBox objPaddingGroupBox;
        private Gizmox.WebGUI.Forms.Label objLabel;



    }
}