using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.DeviceInfo
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
            this.mobjTitle = new Gizmox.WebGUI.Forms.Label();
            this.mobjGetInfoButton = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjVersion = new Gizmox.WebGUI.Forms.Label();
            this.mobjUUIDLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPlatformLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCordovaLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameText = new Gizmox.WebGUI.Forms.Label();
            this.mobjCordovaText = new Gizmox.WebGUI.Forms.Label();
            this.mobjPlatformText = new Gizmox.WebGUI.Forms.Label();
            this.mobjUUIDText = new Gizmox.WebGUI.Forms.Label();
            this.mobjVersionText = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTitle
            // 
            this.mobjTitle.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjTitle.Location = new System.Drawing.Point(0, 0);
            this.mobjTitle.Name = "mobjTitle";
            this.mobjTitle.Size = new System.Drawing.Size(450, 46);
            this.mobjTitle.TabIndex = 0;
            this.mobjTitle.Text = "Click the button to see the device info";
            this.mobjTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjGetInfoButton
            // 
            this.mobjGetInfoButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjGetInfoButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjGetInfoButton.Image"));
            this.mobjGetInfoButton.Location = new System.Drawing.Point(30, 0);
            this.mobjGetInfoButton.Name = "mobjGetInfoButton";
            this.mobjGetInfoButton.Size = new System.Drawing.Size(50, 50);
            this.mobjGetInfoButton.TabIndex = 1;
            this.mobjGetInfoButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjGetInfoButton_ClientClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjGetInfoButton);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.DockPadding.Left = 30;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Gizmox.WebGUI.Forms.Padding(30, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(450, 50);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mobjVersion);
            this.panel2.Controls.Add(this.mobjUUIDLabel);
            this.panel2.Controls.Add(this.mobjPlatformLabel);
            this.panel2.Controls.Add(this.mobjCordovaLabel);
            this.panel2.Controls.Add(this.mobjNameLabel);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.DockPadding.Left = 5;
            this.panel2.DockPadding.Right = 5;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Gizmox.WebGUI.Forms.Padding(5, 0, 5, 0);
            this.panel2.Size = new System.Drawing.Size(139, 431);
            this.panel2.TabIndex = 3;
            // 
            // mobjVersion
            // 
            this.mobjVersion.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjVersion.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjVersion.Location = new System.Drawing.Point(5, 168);
            this.mobjVersion.Name = "mobjVersion";
            this.mobjVersion.Size = new System.Drawing.Size(129, 42);
            this.mobjVersion.TabIndex = 0;
            this.mobjVersion.Text = "Version:";
            this.mobjVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjUUIDLabel
            // 
            this.mobjUUIDLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjUUIDLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjUUIDLabel.Location = new System.Drawing.Point(5, 126);
            this.mobjUUIDLabel.Name = "mobjUUIDLabel";
            this.mobjUUIDLabel.Size = new System.Drawing.Size(129, 42);
            this.mobjUUIDLabel.TabIndex = 0;
            this.mobjUUIDLabel.Text = "UUID:";
            this.mobjUUIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjPlatformLabel
            // 
            this.mobjPlatformLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPlatformLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPlatformLabel.Location = new System.Drawing.Point(5, 84);
            this.mobjPlatformLabel.Name = "mobjPlatformLabel";
            this.mobjPlatformLabel.Size = new System.Drawing.Size(129, 42);
            this.mobjPlatformLabel.TabIndex = 0;
            this.mobjPlatformLabel.Text = "Platform:";
            this.mobjPlatformLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjCordovaLabel
            // 
            this.mobjCordovaLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCordovaLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjCordovaLabel.Location = new System.Drawing.Point(5, 42);
            this.mobjCordovaLabel.Name = "mobjCordovaLabel";
            this.mobjCordovaLabel.Size = new System.Drawing.Size(129, 42);
            this.mobjCordovaLabel.TabIndex = 0;
            this.mobjCordovaLabel.Text = "Cordova:";
            this.mobjCordovaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjNameLabel
            // 
            this.mobjNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjNameLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjNameLabel.Location = new System.Drawing.Point(5, 0);
            this.mobjNameLabel.Name = "mobjNameLabel";
            this.mobjNameLabel.Size = new System.Drawing.Size(129, 42);
            this.mobjNameLabel.TabIndex = 0;
            this.mobjNameLabel.Text = "Name:";
            this.mobjNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjNameText
            // 
            this.mobjNameText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjNameText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjNameText.Location = new System.Drawing.Point(139, 96);
            this.mobjNameText.Name = "mobjNameText";
            this.mobjNameText.Size = new System.Drawing.Size(311, 42);
            this.mobjNameText.TabIndex = 0;
            this.mobjNameText.Text = "--";
            this.mobjNameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCordovaText
            // 
            this.mobjCordovaText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCordovaText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjCordovaText.Location = new System.Drawing.Point(139, 138);
            this.mobjCordovaText.Name = "mobjCordovaText";
            this.mobjCordovaText.Size = new System.Drawing.Size(311, 42);
            this.mobjCordovaText.TabIndex = 0;
            this.mobjCordovaText.Text = "--";
            this.mobjCordovaText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjPlatformText
            // 
            this.mobjPlatformText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPlatformText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPlatformText.Location = new System.Drawing.Point(139, 180);
            this.mobjPlatformText.Name = "mobjPlatformText";
            this.mobjPlatformText.Size = new System.Drawing.Size(311, 42);
            this.mobjPlatformText.TabIndex = 0;
            this.mobjPlatformText.Text = "--";
            this.mobjPlatformText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjUUIDText
            // 
            this.mobjUUIDText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjUUIDText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjUUIDText.Location = new System.Drawing.Point(139, 222);
            this.mobjUUIDText.Name = "mobjUUIDText";
            this.mobjUUIDText.Size = new System.Drawing.Size(311, 42);
            this.mobjUUIDText.TabIndex = 0;
            this.mobjUUIDText.Text = "--";
            this.mobjUUIDText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjVersionText
            // 
            this.mobjVersionText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjVersionText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjVersionText.Location = new System.Drawing.Point(139, 264);
            this.mobjVersionText.Name = "mobjVersionText";
            this.mobjVersionText.Size = new System.Drawing.Size(311, 42);
            this.mobjVersionText.TabIndex = 0;
            this.mobjVersionText.Text = "--";
            this.mobjVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Example
            // 
            this.Controls.Add(this.mobjVersionText);
            this.Controls.Add(this.mobjUUIDText);
            this.Controls.Add(this.mobjPlatformText);
            this.Controls.Add(this.mobjCordovaText);
            this.Controls.Add(this.mobjNameText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mobjTitle);
            this.Size = new System.Drawing.Size(450, 527);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label mobjTitle;
        private Button mobjGetInfoButton;
        private Panel panel1;
        private Panel panel2;
        private Label mobjNameLabel;
        private Label mobjVersion;
        private Label mobjUUIDLabel;
        private Label mobjPlatformLabel;
        private Label mobjCordovaLabel;
        private Label mobjNameText;
        private Label mobjCordovaText;
        private Label mobjPlatformText;
        private Label mobjUUIDText;
        private Label mobjVersionText;
    }
}