namespace CompanionKit.Concepts.ClientAPI.LoadingIcon
{
    partial class LoadingIconPage
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
            this.objButton = new Gizmox.WebGUI.Forms.Button();
            this.objNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.objLabel = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // objButton
            // 
            this.objButton.AccessibleDescription = "";
            this.objButton.AccessibleName = "";
            this.objButton.Location = new System.Drawing.Point(29, 126);
            this.objButton.Name = "objButton";
            this.objButton.Size = new System.Drawing.Size(116, 23);
            this.objButton.TabIndex = 0;
            this.objButton.Text = "Show Loading Icon";
            this.objButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objButton_ClientClick);
            // 
            // objNumericUpDown
            // 
            this.objNumericUpDown.AccessibleDescription = "";
            this.objNumericUpDown.AccessibleName = "";
            this.objNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.objNumericUpDown.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.objNumericUpDown.ClientId = "nud";
            this.objNumericUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.objNumericUpDown.Location = new System.Drawing.Point(29, 73);
            this.objNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.objNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.objNumericUpDown.Name = "objNumericUpDown";
            this.objNumericUpDown.Size = new System.Drawing.Size(120, 17);
            this.objNumericUpDown.TabIndex = 1;
            this.objNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // objLabel
            // 
            this.objLabel.AccessibleDescription = "";
            this.objLabel.AccessibleName = "";
            this.objLabel.AutoSize = true;
            this.objLabel.Location = new System.Drawing.Point(26, 50);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 2;
            this.objLabel.Text = "Duration, sec";
            // 
            // LoadingIconPage
            // 
            this.Controls.Add(this.objLabel);
            this.Controls.Add(this.objNumericUpDown);
            this.Controls.Add(this.objButton);
            this.MaximumSize = new System.Drawing.Size(315, 225);
            this.Size = new System.Drawing.Size(315, 225);
            this.Text = "LoadingIconPage";
            ((System.ComponentModel.ISupportInitialize)(this.objNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button objButton;
        private Gizmox.WebGUI.Forms.NumericUpDown objNumericUpDown;
        private Gizmox.WebGUI.Forms.Label objLabel;



    }
}