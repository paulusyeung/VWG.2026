using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms
{
    partial class DataGridViewGroupingHeader
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
            this.mobjHeaderLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjHeaderLabel
            // 
            this.mobjHeaderLabel.BackColor = System.Drawing.Color.Gray;
            this.mobjHeaderLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjHeaderLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjHeaderLabel.Name = "mobjHeaderLabel";
            this.mobjHeaderLabel.Size = new System.Drawing.Size(296, 40);
            this.mobjHeaderLabel.TabIndex = 0;
            // 
            // DataGridViewGroupingHeader
            // 
            this.Controls.Add(this.mobjHeaderLabel);
            this.Size = new System.Drawing.Size(296, 40);
            this.Text = "DataGridViewGroupingHeader";
            this.ResumeLayout(false);

        }

        #endregion

        private Label mobjHeaderLabel;
    }
}