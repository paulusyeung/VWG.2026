using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario
{
    partial class ucPasswordStrengthChecker
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
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.tbPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.lblResult = new Gizmox.WebGUI.Forms.Label();
            this.btnCheck = new Gizmox.WebGUI.Forms.Button();
            this.btnHelp = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Enter your password";
            // 
            // tbPassword
            // 
            this.tbPassword.AllowDrag = false;
            this.tbPassword.Location = new System.Drawing.Point(14, 35);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(175, 30);
            this.tbPassword.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.lblResult.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lblResult.Location = new System.Drawing.Point(14, 73);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(175, 30);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Visible = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(202, 35);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(106, 30);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(202, 73);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(106, 30);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ucPasswordStrengthChecker
            // 
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblDescription);
            this.Size = new System.Drawing.Size(318, 126);
            this.Text = "ucPasswordStrengthChecker";
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblDescription;
        private TextBox tbPassword;
        private Label lblResult;
        private Button btnCheck;
        private Button btnHelp;


    }
}