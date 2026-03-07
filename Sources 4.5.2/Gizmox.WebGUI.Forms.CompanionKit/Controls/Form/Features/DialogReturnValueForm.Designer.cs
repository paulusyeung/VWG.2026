namespace CompanionKit.Controls.Form.Features
{
    partial class DialogReturnValueForm
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
            this.mobjUserFirstNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjUserFirstNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjUserLastNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjUserLastNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPhoneLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPhoneTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjEmailLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjEmailTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSaveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCancelButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjUserFirstNameLabel
            // 
            this.mobjUserFirstNameLabel.AutoSize = true;
            this.mobjUserFirstNameLabel.Location = new System.Drawing.Point(12, 19);
            this.mobjUserFirstNameLabel.Name = "userFirstNameLabel";
            this.mobjUserFirstNameLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjUserFirstNameLabel.TabIndex = 0;
            this.mobjUserFirstNameLabel.Text = "User First Name";
            // 
            // mobjUserFirstNameTextBox
            // 
            this.mobjUserFirstNameTextBox.AllowDrag = false;
            this.mobjUserFirstNameTextBox.Location = new System.Drawing.Point(15, 39);
            this.mobjUserFirstNameTextBox.Name = "textBox1";
            this.mobjUserFirstNameTextBox.Size = new System.Drawing.Size(130, 30);
            this.mobjUserFirstNameTextBox.TabIndex = 1;
            // 
            // mobjUserLastNameLabel
            // 
            this.mobjUserLastNameLabel.AutoSize = true;
            this.mobjUserLastNameLabel.Location = new System.Drawing.Point(169, 19);
            this.mobjUserLastNameLabel.Name = "label2";
            this.mobjUserLastNameLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjUserLastNameLabel.TabIndex = 2;
            this.mobjUserLastNameLabel.Text = "User Last Name";
            // 
            // mobjUserLastNameTextBox
            // 
            this.mobjUserLastNameTextBox.AllowDrag = false;
            this.mobjUserLastNameTextBox.Location = new System.Drawing.Point(172, 39);
            this.mobjUserLastNameTextBox.Name = "textBox2";
            this.mobjUserLastNameTextBox.Size = new System.Drawing.Size(130, 30);
            this.mobjUserLastNameTextBox.TabIndex = 3;
            // 
            // mobjPhoneLabel
            // 
            this.mobjPhoneLabel.AutoSize = true;
            this.mobjPhoneLabel.Location = new System.Drawing.Point(12, 82);
            this.mobjPhoneLabel.Name = "label3";
            this.mobjPhoneLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjPhoneLabel.TabIndex = 4;
            this.mobjPhoneLabel.Text = "Phone";
            // 
            // mobjPhoneTextBox
            // 
            this.mobjPhoneTextBox.AllowDrag = false;
            this.mobjPhoneTextBox.Location = new System.Drawing.Point(12, 102);
            this.mobjPhoneTextBox.Name = "phoneTextBox";
            this.mobjPhoneTextBox.Size = new System.Drawing.Size(130, 30);
            this.mobjPhoneTextBox.TabIndex = 5;
            // 
            // mobjEmailLabel
            // 
            this.mobjEmailLabel.AutoSize = true;
            this.mobjEmailLabel.Location = new System.Drawing.Point(169, 82);
            this.mobjEmailLabel.Name = "emailLabel";
            this.mobjEmailLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjEmailLabel.TabIndex = 6;
            this.mobjEmailLabel.Text = "E-mail";
            // 
            // mobjEmailTextBox
            // 
            this.mobjEmailTextBox.AllowDrag = false;
            this.mobjEmailTextBox.Location = new System.Drawing.Point(172, 102);
            this.mobjEmailTextBox.Name = "emailTextBox";
            this.mobjEmailTextBox.Size = new System.Drawing.Size(130, 30);
            this.mobjEmailTextBox.TabIndex = 7;
            // 
            // mobjSaveButton
            // 
            this.mobjSaveButton.Location = new System.Drawing.Point(12, 153);
            this.mobjSaveButton.Name = "saveButton";
            this.mobjSaveButton.Size = new System.Drawing.Size(130, 43);
            this.mobjSaveButton.TabIndex = 8;
            this.mobjSaveButton.Text = "Save...";
            this.mobjSaveButton.UseVisualStyleBackColor = true;
            this.mobjSaveButton.Click += new System.EventHandler(this.mobjSaveButton_Click);
            // 
            // mobjCancelButton
            // 
            this.mobjCancelButton.Location = new System.Drawing.Point(172, 153);
            this.mobjCancelButton.Name = "cancelButton";
            this.mobjCancelButton.Size = new System.Drawing.Size(130, 43);
            this.mobjCancelButton.TabIndex = 9;
            this.mobjCancelButton.Text = "Cancel...";
            this.mobjCancelButton.UseVisualStyleBackColor = true;
            this.mobjCancelButton.Click += new System.EventHandler(this.mobjCancelButton_Click);
            // 
            // DialogReturnValueForm
            // 
            this.Controls.Add(this.mobjCancelButton);
            this.Controls.Add(this.mobjSaveButton);
            this.Controls.Add(this.mobjEmailTextBox);
            this.Controls.Add(this.mobjEmailLabel);
            this.Controls.Add(this.mobjPhoneTextBox);
            this.Controls.Add(this.mobjPhoneLabel);
            this.Controls.Add(this.mobjUserLastNameTextBox);
            this.Controls.Add(this.mobjUserLastNameLabel);
            this.Controls.Add(this.mobjUserFirstNameTextBox);
            this.Controls.Add(this.mobjUserFirstNameLabel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(316, 205);
            this.Text = "Dialog Return Value";
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjUserFirstNameLabel;
        private global::Gizmox.WebGUI.Forms.TextBox mobjUserFirstNameTextBox;
        private global::Gizmox.WebGUI.Forms.Label mobjUserLastNameLabel;
        private global::Gizmox.WebGUI.Forms.TextBox mobjUserLastNameTextBox;
        private global::Gizmox.WebGUI.Forms.Label mobjPhoneLabel;
        private global::Gizmox.WebGUI.Forms.TextBox mobjPhoneTextBox;
        private global::Gizmox.WebGUI.Forms.Label mobjEmailLabel;
        private global::Gizmox.WebGUI.Forms.TextBox mobjEmailTextBox;
        protected global::Gizmox.WebGUI.Forms.Button mobjSaveButton;
        protected global::Gizmox.WebGUI.Forms.Button mobjCancelButton;


    }
}