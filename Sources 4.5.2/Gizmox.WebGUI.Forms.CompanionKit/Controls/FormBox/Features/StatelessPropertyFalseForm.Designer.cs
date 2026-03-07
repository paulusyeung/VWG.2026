using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    partial class StatelessPropertyFalseForm
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
            this.cmbDaysOfWeek = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnSet = new Gizmox.WebGUI.Forms.Button();
            this.lblDayofWeek = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDaysOfWeek
            // 
            this.cmbDaysOfWeek.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbDaysOfWeek.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbDaysOfWeek.FormattingEnabled = true;
            this.cmbDaysOfWeek.Location = new System.Drawing.Point(40, 9);
            this.cmbDaysOfWeek.MaxDropDownItems = 8;
            this.cmbDaysOfWeek.Name = "cmbDaysOfWeek";
            this.cmbDaysOfWeek.Size = new System.Drawing.Size(121, 21);
            this.cmbDaysOfWeek.TabIndex = 0;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(40, 40);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(121, 23);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "Set Value to Label";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblDayofWeek
            // 
            this.lblDayofWeek.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.lblDayofWeek.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lblDayofWeek.Location = new System.Drawing.Point(40, 74);
            this.lblDayofWeek.Name = "lblDayofWeek";
            this.lblDayofWeek.Size = new System.Drawing.Size(121, 23);
            this.lblDayofWeek.TabIndex = 2;
            this.lblDayofWeek.Text = "Day of Week";
            this.lblDayofWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatelessPropertyFalseForm
            // 
            this.Controls.Add(this.lblDayofWeek);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cmbDaysOfWeek);
            this.Size = new System.Drawing.Size(200, 150);
            this.Text = "StatelessPropertyForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbDaysOfWeek;
        private Button btnSet;
        private Label lblDayofWeek;


    }
}