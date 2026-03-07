using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Capture
{
    partial class ImageExample
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
            this.mobjCaptureDetails = new CompanionKit.DeviceIntegration.Capture.CaptureDetails();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjCaptureDetails
            // 
            this.mobjCaptureDetails.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjCaptureDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCaptureDetails.Location = new System.Drawing.Point(0, 23);
            this.mobjCaptureDetails.Name = "mobjCaptureDetails";
            this.mobjCaptureDetails.Size = new System.Drawing.Size(390, 332);
            this.mobjCaptureDetails.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(390, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Capture Image";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageExample
            // 
            this.Controls.Add(this.mobjCaptureDetails);
            this.Controls.Add(this.button1);
            this.Size = new System.Drawing.Size(390, 355);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private CaptureDetails mobjCaptureDetails;
    }
}