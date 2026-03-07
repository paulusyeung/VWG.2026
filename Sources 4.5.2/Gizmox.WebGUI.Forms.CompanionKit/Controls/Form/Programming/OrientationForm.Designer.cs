namespace CompanionKit.Controls.Form.Programming
{
    partial class OrientationForm
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
            this.mobjOrientationLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCloseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjOrientationLabel
            // 
            this.mobjOrientationLabel.AccessibleDescription = "";
            this.mobjOrientationLabel.AccessibleName = "";
            this.mobjOrientationLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjOrientationLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjOrientationLabel.Name = "mobjOrientationLabel";
            this.mobjOrientationLabel.Size = new System.Drawing.Size(419, 112);
            this.mobjOrientationLabel.TabIndex = 0;
            this.mobjOrientationLabel.Text = "Orientation (device support only)";
            this.mobjOrientationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCloseButton
            // 
            this.mobjCloseButton.AccessibleDescription = "";
            this.mobjCloseButton.AccessibleName = "";
            this.mobjCloseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCloseButton.Location = new System.Drawing.Point(70, 0);
            this.mobjCloseButton.Name = "mobjCloseButton";
            this.mobjCloseButton.Size = new System.Drawing.Size(279, 30);
            this.mobjCloseButton.TabIndex = 1;
            this.mobjCloseButton.Text = "Close Form";
            this.mobjCloseButton.Click += new System.EventHandler(this.mobjCloseButton_Click);
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.Controls.Add(this.mobjCloseButton);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel.DockPadding.Left = 70;
            this.mobjPanel.DockPadding.Right = 70;
            this.mobjPanel.Location = new System.Drawing.Point(0, 112);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(70, 0, 70, 0);
            this.mobjPanel.Size = new System.Drawing.Size(419, 30);
            this.mobjPanel.TabIndex = 2;
            // 
            // Form
            // 
            this.Controls.Add(this.mobjPanel);
            this.Controls.Add(this.mobjOrientationLabel);
            this.Size = new System.Drawing.Size(419, 466);
            this.OrientationChanged += new Gizmox.WebGUI.Forms.Form.OrientationChangedEventHandler(this.FormOrientationChanged);
            this.mobjPanel.ResumeLayout(false);
            this.Text = "OrientationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjOrientationLabel;
        private Gizmox.WebGUI.Forms.Button mobjCloseButton;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
    }
}