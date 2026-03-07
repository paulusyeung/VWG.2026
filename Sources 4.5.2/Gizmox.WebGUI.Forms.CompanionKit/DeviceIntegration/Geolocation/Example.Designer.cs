using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.DeviceIntegration.Geolocation
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
            this.googleMap = new Gizmox.WebGUI.Forms.Google.GoogleMap();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjGetPositionButton = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // googleMap
            // 
            this.googleMap.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.googleMap.Location = new System.Drawing.Point(0, 55);
            this.googleMap.MapControlMaps = new Gizmox.WebGUI.Forms.Google.GoogleMapMapTypes(true, false, false, false);
            this.googleMap.Name = "googleMap";
            this.googleMap.Size = new System.Drawing.Size(784, 609);
            this.googleMap.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjGetPositionButton);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 55);
            this.panel1.TabIndex = 5;
            // 
            // mobjGetPositionButton
            // 
            this.mobjGetPositionButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjGetPositionButton.Image = new ImageResourceHandle("GPS.png");
            this.mobjGetPositionButton.Name = "mobjGetPositionButton";
            this.mobjGetPositionButton.Size = new System.Drawing.Size(55, 55);
            this.mobjGetPositionButton.TabIndex = 0;
            this.mobjGetPositionButton.Click += new System.EventHandler(this.GetPositionButton_Click);
            // 
            // Example
            // 
            this.Controls.Add(this.googleMap);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(784, 664);
            this.Text = "Online";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Google.GoogleMap googleMap;
        private Panel panel1;
        private Button mobjGetPositionButton;

    }
}