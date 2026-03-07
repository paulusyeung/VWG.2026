using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.Button.Functionality
{
    partial class CustomDialogForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNoButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjYesButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.AccessibleDescription = "";
            this.mobjLayoutPanel.AccessibleName = "";
            this.mobjLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel);
            this.mobjLayoutPanel.Controls.Add(this.mobjNoButton);
            this.mobjLayoutPanel.Controls.Add(this.mobjYesButton);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.Size = new System.Drawing.Size(338, 119);
            this.mobjLayoutPanel.TabIndex = 0;
            this.mobjLayoutPanel.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect(15);
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.Controls.Add(this.mobjLabel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(338, 75);
            this.mobjPanel.TabIndex = 3;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.ForeColor = System.Drawing.Color.White;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLabel.Size = new System.Drawing.Size(338, 75);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Please, press any of those buttons.";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjNoButton
            // 
            this.mobjNoButton.AccessibleDescription = "";
            this.mobjNoButton.AccessibleName = "";
            this.mobjNoButton.Location = new System.Drawing.Point(243, 75);
            this.mobjNoButton.Name = "mobjNoButton";
            this.mobjNoButton.Size = new System.Drawing.Size(75, 23);
            this.mobjNoButton.TabIndex = 1;
            this.mobjNoButton.Text = "No";
            // 
            // mobjYesButton
            // 
            this.mobjYesButton.AccessibleDescription = "";
            this.mobjYesButton.AccessibleName = "";
            this.mobjYesButton.Location = new System.Drawing.Point(28, 75);
            this.mobjYesButton.Name = "mobjYesButton";
            this.mobjYesButton.Size = new System.Drawing.Size(75, 23);
            this.mobjYesButton.TabIndex = 0;
            this.mobjYesButton.Text = "Yes";
            // 
            // CustomDialogForm
            // 
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.All = 10;
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(358, 139);
            this.Text = "CustomDialogForm";
            this.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Button mobjNoButton;
        private Gizmox.WebGUI.Forms.Button mobjYesButton;
        private Label mobjLabel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;


    }
}