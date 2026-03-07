using System.IO;
using System.Web;
namespace CompanionKit.Controls.FlashBox.Programming
{
    partial class ProvideParametersPage
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
            this.demoFlashBox = new Gizmox.WebGUI.Forms.Hosts.FlashBox();
            this.SuspendLayout();
            // 
            // demoFlashBox
            // 
            this.demoFlashBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.demoFlashBox.CodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0" +
                ",0";
            this.demoFlashBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.demoFlashBox.Location = new System.Drawing.Point(0, 0);
            this.demoFlashBox.Name = "demoFlashBox";
            this.demoFlashBox.Size = new System.Drawing.Size(391, 452);
            this.demoFlashBox.TabIndex = 0;
            // 
            // ProvideParametersPage
            // 
            this.Controls.Add(this.demoFlashBox);
            this.Size = new System.Drawing.Size(391, 450);
            this.Text = "ProvideParametersPage";
            this.Load += new System.EventHandler(this.ProvideParametersPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.FlashBox demoFlashBox;



    }
}