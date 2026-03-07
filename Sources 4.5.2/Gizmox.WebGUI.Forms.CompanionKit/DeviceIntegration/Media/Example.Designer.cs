using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Media
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

            this.components = new System.ComponentModel.Container();
            this.mobjSeekBack = new Gizmox.WebGUI.Forms.Button();
            this.mobjPause = new Gizmox.WebGUI.Forms.Button();
            this.mobjPlay = new Gizmox.WebGUI.Forms.Button();
            this.mobjStop = new Gizmox.WebGUI.Forms.Button();
            this.mobjSeekForward = new Gizmox.WebGUI.Forms.Button();
            this.mobjProgress = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjLengthLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPositionLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();

            // 
            // mobjSeekBack
            // 
            this.mobjSeekBack.Enabled = false;
            this.mobjSeekBack.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjSeekBack.Image"));
            this.mobjSeekBack.Location = new System.Drawing.Point(35, 17);
            this.mobjSeekBack.Name = "mobjSeekBack";
            this.mobjSeekBack.Size = new System.Drawing.Size(50, 50);
            this.mobjSeekBack.TabIndex = 0;
            this.mobjSeekBack.Click += new System.EventHandler(this.mobjSeekBack_Click);
            // 
            // mobjPause
            // 
            this.mobjPause.Enabled = false;
            this.mobjPause.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPause.Image"));
            this.mobjPause.Location = new System.Drawing.Point(85, 17);
            this.mobjPause.Name = "mobjPause";
            this.mobjPause.Size = new System.Drawing.Size(50, 50);
            this.mobjPause.TabIndex = 0;
            this.mobjPause.Click += new System.EventHandler(this.mobjPause_Click);
            // 
            // mobjPlay
            // 
            this.mobjPlay.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPlay.Image"));
            this.mobjPlay.Location = new System.Drawing.Point(135, 17);
            this.mobjPlay.Name = "mobjPlay";
            this.mobjPlay.Size = new System.Drawing.Size(50, 50);
            this.mobjPlay.TabIndex = 0;
            this.mobjPlay.Click += new System.EventHandler(this.mobjPlay_Click);
            // 
            // mobjStop
            // 
            this.mobjStop.Enabled = false;
            this.mobjStop.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjStop.Image"));
            this.mobjStop.Location = new System.Drawing.Point(185, 17);
            this.mobjStop.Name = "mobjStop";
            this.mobjStop.Size = new System.Drawing.Size(50, 50);
            this.mobjStop.TabIndex = 0;
            this.mobjStop.Click += new System.EventHandler(this.mobjStop_Click);
            // 
            // mobjSeekForward
            // 
            this.mobjSeekForward.Enabled = false;
            this.mobjSeekForward.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjSeekForward.Image"));
            this.mobjSeekForward.Location = new System.Drawing.Point(235, 17);
            this.mobjSeekForward.Name = "mobjSeekForward";
            this.mobjSeekForward.Size = new System.Drawing.Size(50, 50);
            this.mobjSeekForward.TabIndex = 0;
            this.mobjSeekForward.Click += new System.EventHandler(this.mobjSeekForward_Click);
            // 
            // mobjProgress
            // 
            this.mobjProgress.Enabled = false;
            this.mobjProgress.Location = new System.Drawing.Point(35, 71);
            this.mobjProgress.Name = "mobjProgress";
            this.mobjProgress.Size = new System.Drawing.Size(250, 23);
            this.mobjProgress.TabIndex = 1;
            // 
            // mobjLengthLabel
            // 
            this.mobjLengthLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjLengthLabel.Location = new System.Drawing.Point(285, 71);
            this.mobjLengthLabel.Name = "mobjLengthLabel";
            this.mobjLengthLabel.Size = new System.Drawing.Size(35, 23);
            this.mobjLengthLabel.TabIndex = 2;
            this.mobjLengthLabel.Text = "--:--";
            this.mobjLengthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mobjPositionLabel
            // 
            this.mobjPositionLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPositionLabel.Location = new System.Drawing.Point(0, 71);
            this.mobjPositionLabel.Name = "mobjPositionLabel";
            this.mobjPositionLabel.Size = new System.Drawing.Size(35, 23);
            this.mobjPositionLabel.TabIndex = 2;
            this.mobjPositionLabel.Text = "--:--";
            this.mobjPositionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Example
            // 
            this.Controls.Add(this.mobjPositionLabel);
            this.Controls.Add(this.mobjLengthLabel);
            this.Controls.Add(this.mobjProgress);
            this.Controls.Add(this.mobjPlay);
            this.Controls.Add(this.mobjStop);
            this.Controls.Add(this.mobjSeekForward);
            this.Controls.Add(this.mobjPause);
            this.Controls.Add(this.mobjSeekBack);            
            this.Size = new System.Drawing.Size(323, 411);
            this.Load += new System.EventHandler(this.Example_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button mobjSeekBack;
        private Button mobjPause;
        private Button mobjPlay;
        private Button mobjStop;
        private Button mobjSeekForward;
        private ProgressBar mobjProgress;
        private Label mobjLengthLabel;
        private Label mobjPositionLabel;
    }
}