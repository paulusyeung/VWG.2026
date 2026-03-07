using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.DeviceIntegration.Accelerometer
{
    partial class Example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Example));
            this.accelerationPanel1 = new CompanionKit.DeviceIntegration.Accelerometer.AccelerationPanel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjWatchAccelerationButton = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accelerationPanel1
            // 
            this.accelerationPanel1.CustomStyle = "AccelerationPanelSkin";
            this.accelerationPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.accelerationPanel1.Location = new System.Drawing.Point(0, 46);
            this.accelerationPanel1.Name = "accelerationPanel1";
            this.accelerationPanel1.Size = new System.Drawing.Size(760, 361);
            this.accelerationPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjWatchAccelerationButton);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 55);
            this.panel1.TabIndex = 1;
            // 
            // mobjWatchAccelerationButton
            // 
            this.mobjWatchAccelerationButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWatchAccelerationButton.Image =  new ImageResourceHandle("Off.png");
            this.mobjWatchAccelerationButton.Location = new System.Drawing.Point(0, 0);
            this.mobjWatchAccelerationButton.Name = "mobjWatchAccelerationButton";
            this.mobjWatchAccelerationButton.Size = new System.Drawing.Size(55, 55);
            this.mobjWatchAccelerationButton.TabIndex = 0;
            this.mobjWatchAccelerationButton.Click += new System.EventHandler(this.btnWatchAcceleration_Click);
            // 
            // Example
            // 
            this.Controls.Add(this.accelerationPanel1);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(760, 407);
            this.Text = "Offline";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AccelerationPanel accelerationPanel1;
        private Panel panel1;
        private Button mobjWatchAccelerationButton;

    }
}