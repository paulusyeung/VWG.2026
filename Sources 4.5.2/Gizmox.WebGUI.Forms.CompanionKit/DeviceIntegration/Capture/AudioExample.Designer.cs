using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Capture
{
    partial class AudioExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioExample));
            this.mobjCaptureDetails = new CompanionKit.DeviceIntegration.Capture.CaptureDetails();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.mobjPlay = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCaptureDetails
            // 
            this.mobjCaptureDetails.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjCaptureDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCaptureDetails.Location = new System.Drawing.Point(0, 0);
            this.mobjCaptureDetails.Name = "mobjCaptureDetails";
            this.mobjCaptureDetails.Size = new System.Drawing.Size(390, 362);
            this.mobjCaptureDetails.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(390, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Capture Audio";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mobjPlay
            // 
            this.mobjPlay.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjPlay.Enabled = false;
            this.mobjPlay.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPlay.Image"));
            this.mobjPlay.Location = new System.Drawing.Point(0, 36);
            this.mobjPlay.Name = "mobjPlay";
            this.mobjPlay.Size = new System.Drawing.Size(50, 46);
            this.mobjPlay.TabIndex = 1;
            this.mobjPlay.Click += new System.EventHandler(this.mobjPlay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.mobjPlay);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 50);
            this.panel1.TabIndex = 2;
            // 
            // AudioExample
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.mobjCaptureDetails);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(390, 412);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private CaptureDetails mobjCaptureDetails;
        private Button mobjPlay;
        private Panel panel1;
    }
}