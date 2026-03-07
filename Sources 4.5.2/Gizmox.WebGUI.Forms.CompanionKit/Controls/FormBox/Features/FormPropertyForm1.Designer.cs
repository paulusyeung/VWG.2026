using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    partial class FormPropertyForm1
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
            this.btnShowFormType = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowFormType
            // 
            this.btnShowFormType.Location = new System.Drawing.Point(200, 89);
            this.btnShowFormType.Name = "btnShowFormType";
            this.btnShowFormType.Size = new System.Drawing.Size(150, 23);
            this.btnShowFormType.TabIndex = 0;
            this.btnShowFormType.Text = "Show Form Type";
            this.btnShowFormType.UseVisualStyleBackColor = true;
            this.btnShowFormType.Click += new System.EventHandler(this.btnShowFormType_Click);
            // 
            // FormPropertyForm1
            // 
            this.Controls.Add(this.btnShowFormType);
            this.Size = new System.Drawing.Size(550, 200);
            this.Text = "FormPropertyForm1";
            this.Load += new System.EventHandler(this.FormPropertyForm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnShowFormType;



    }
}