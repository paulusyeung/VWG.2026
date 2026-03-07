using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Splashscreen
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
            this.mobjButtonAction = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjButtonAction
            // 
            this.mobjButtonAction.Location = new System.Drawing.Point(31, 37);
            this.mobjButtonAction.Name = "mobjButtonAction";
            this.mobjButtonAction.Size = new System.Drawing.Size(192, 60);
            this.mobjButtonAction.TabIndex = 0;
            this.mobjButtonAction.Text = "Show splash screen (for 3 seconds)";
            // 
            // Example
            // 
            this.Controls.Add(this.mobjButtonAction);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Example";
            this.ResumeLayout(false);

        }

        #endregion

        private Button mobjButtonAction;


    }
}