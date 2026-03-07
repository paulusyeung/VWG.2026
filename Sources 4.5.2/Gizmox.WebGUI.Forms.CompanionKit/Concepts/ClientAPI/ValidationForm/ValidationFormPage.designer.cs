namespace CompanionKit.Concepts.ClientAPI.ValidationForm
{
    partial class ValidationFormPage
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
            this.objMailTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.objPasswordTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.objLoginButton = new Gizmox.WebGUI.Forms.Button();
            this.objMailLabel = new Gizmox.WebGUI.Forms.Label();
            this.objPasswordLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // objMailTextBox
            // 
            this.objMailTextBox.AllowDrag = false;
            this.objMailTextBox.ClientId = "email";
            this.objMailTextBox.Location = new System.Drawing.Point(115, 31);
            this.objMailTextBox.Name = "objMailTextBox";
            this.objMailTextBox.Size = new System.Drawing.Size(187, 20);
            this.objMailTextBox.TabIndex = 0;
            // 
            // objPasswordTextBox
            // 
            this.objPasswordTextBox.AllowDrag = false;
            this.objPasswordTextBox.ClientId = "password";
            this.objPasswordTextBox.Location = new System.Drawing.Point(115, 87);
            this.objPasswordTextBox.Name = "objPasswordTextBox";
            this.objPasswordTextBox.Size = new System.Drawing.Size(187, 20);
            this.objPasswordTextBox.TabIndex = 1;
            this.objPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // objLoginButton
            // 
            this.objLoginButton.Location = new System.Drawing.Point(115, 153);
            this.objLoginButton.Name = "objLoginButton";
            this.objLoginButton.Size = new System.Drawing.Size(187, 23);
            this.objLoginButton.TabIndex = 2;
            this.objLoginButton.Text = "Login";
            this.objLoginButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.objLoginButton_ClientClick);
            // 
            // objMailLabel
            // 
            this.objMailLabel.AutoSize = true;
            this.objMailLabel.Location = new System.Drawing.Point(45, 34);
            this.objMailLabel.Name = "objMailLabel";
            this.objMailLabel.Size = new System.Drawing.Size(35, 13);
            this.objMailLabel.TabIndex = 3;
            this.objMailLabel.Text = "E-mail";
            // 
            // objPasswordLabel
            // 
            this.objPasswordLabel.AutoSize = true;
            this.objPasswordLabel.Location = new System.Drawing.Point(27, 90);
            this.objPasswordLabel.Name = "objPasswordLabel";
            this.objPasswordLabel.Size = new System.Drawing.Size(35, 13);
            this.objPasswordLabel.TabIndex = 4;
            this.objPasswordLabel.Text = "Password";
            // 
            // ValidationFormPage
            // 
            this.ClientId = "form";
            this.Controls.Add(this.objPasswordLabel);
            this.Controls.Add(this.objMailLabel);
            this.Controls.Add(this.objLoginButton);
            this.Controls.Add(this.objPasswordTextBox);
            this.Controls.Add(this.objMailTextBox);
            this.Size = new System.Drawing.Size(331, 239);
            this.Text = "ValidationFormPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox objMailTextBox;
        private Gizmox.WebGUI.Forms.TextBox objPasswordTextBox;
        private Gizmox.WebGUI.Forms.Button objLoginButton;
        private Gizmox.WebGUI.Forms.Label objMailLabel;
        private Gizmox.WebGUI.Forms.Label objPasswordLabel;



    }
}