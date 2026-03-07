using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    partial class ExamplePauseResume
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
            this.mobjTitleLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjEventsLogPanel = new Gizmox.WebGUI.Forms.Panel();
            this.SuspendLayout();
            // 
            // mobjTitleLabel
            // 
            this.mobjTitleLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTitleLabel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.mobjTitleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTitleLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjTitleLabel.Location = new System.Drawing.Point(5, 5);
            this.mobjTitleLabel.Name = "mobjTitleLabel";
            this.mobjTitleLabel.Size = new System.Drawing.Size(665, 82);
            this.mobjTitleLabel.TabIndex = 0;
            this.mobjTitleLabel.Text = "To test the pause/resume events, exit the app (by clicking the \'home\' button for " +
    "example) and then come back to the app.";
            // 
            // mobjEventsLogPanel
            // 
            this.mobjEventsLogPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjEventsLogPanel.DockPadding.All = 5;
            this.mobjEventsLogPanel.Location = new System.Drawing.Point(5, 87);
            this.mobjEventsLogPanel.Name = "mobjEventsLogPanel";
            this.mobjEventsLogPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjEventsLogPanel.Size = new System.Drawing.Size(665, 469);
            this.mobjEventsLogPanel.TabIndex = 1;
            // 
            // ExamplePauseResume
            // 
            this.Controls.Add(this.mobjEventsLogPanel);
            this.Controls.Add(this.mobjTitleLabel);
            this.DockPadding.All = 5;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.Size = new System.Drawing.Size(675, 561);
            this.ResumeLayout(false);

        }

        #endregion

        private Label mobjTitleLabel;
        private Panel mobjEventsLogPanel;
    }
}