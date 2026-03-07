namespace CompanionKit.Controls.Form.Features
{
    partial class WindowStateForm
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
            this.mobjCommonLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaximizeCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjMinimizeCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCloseButton = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjCommonLabel
            // 
            this.mobjCommonLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCommonLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLabel.Name = "label1";
            this.mobjCommonLabel.Size = new System.Drawing.Size(372, 89);
            this.mobjCommonLabel.TabIndex = 0;
            this.mobjCommonLabel.Text = "Check button that will be have this form and select window state for this form an" +
    "d click on button.";
            this.mobjCommonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjMaximizeCheckBox
            // 
            this.mobjMaximizeCheckBox.AutoSize = true;
            this.mobjMaximizeCheckBox.Location = new System.Drawing.Point(133, 78);
            this.mobjMaximizeCheckBox.Name = "maximizeBtnCheckBox";
            this.mobjMaximizeCheckBox.Size = new System.Drawing.Size(104, 17);
            this.mobjMaximizeCheckBox.TabIndex = 1;
            this.mobjMaximizeCheckBox.Text = "Maximize button";
            this.mobjMaximizeCheckBox.UseVisualStyleBackColor = true;
            this.mobjMaximizeCheckBox.CheckedChanged += new System.EventHandler(this.mobjMaximizeBtnCheckBox_CheckedChanged);
            // 
            // mobjMinimizeCheckBox
            // 
            this.mobjMinimizeCheckBox.AutoSize = true;
            this.mobjMinimizeCheckBox.Location = new System.Drawing.Point(133, 108);
            this.mobjMinimizeCheckBox.Name = "checkBox2";
            this.mobjMinimizeCheckBox.Size = new System.Drawing.Size(100, 17);
            this.mobjMinimizeCheckBox.TabIndex = 2;
            this.mobjMinimizeCheckBox.Text = "Minimize button";
            this.mobjMinimizeCheckBox.UseVisualStyleBackColor = true;
            this.mobjMinimizeCheckBox.CheckedChanged += new System.EventHandler(this.mobjMinimizeBtnCheckBox_CheckedChanged);
            // 
            // mobjStateLabel
            // 
            this.mobjStateLabel.Location = new System.Drawing.Point(0, 127);
            this.mobjStateLabel.Name = "label2";
            this.mobjStateLabel.Size = new System.Drawing.Size(380, 31);
            this.mobjStateLabel.TabIndex = 3;
            this.mobjStateLabel.Text = "Select window state for opened form";
            this.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.Location = new System.Drawing.Point(103, 158);
            this.mobjComboBox.Name = "comboBox1";
            this.mobjComboBox.Size = new System.Drawing.Size(175, 30);
            this.mobjComboBox.TabIndex = 4;
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjCloseButton
            // 
            this.mobjCloseButton.Location = new System.Drawing.Point(48, 195);
            this.mobjCloseButton.Name = "closeButton";
            this.mobjCloseButton.Size = new System.Drawing.Size(288, 38);
            this.mobjCloseButton.TabIndex = 5;
            this.mobjCloseButton.Text = "Close";
            this.mobjCloseButton.UseVisualStyleBackColor = true;
            this.mobjCloseButton.Click += new System.EventHandler(this.mobjCloseButton_Click);
            // 
            // WindowStateForm
            // 
            this.Controls.Add(this.mobjCloseButton);
            this.Controls.Add(this.mobjComboBox);
            this.Controls.Add(this.mobjStateLabel);
            this.Controls.Add(this.mobjMinimizeCheckBox);
            this.Controls.Add(this.mobjMaximizeCheckBox);
            this.Controls.Add(this.mobjCommonLabel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(372, 242);
            this.Text = "Window State Form";
            this.Load += new System.EventHandler(this.WindowStateForm_Load);
            this.Resize += new System.EventHandler(this.WindowStateForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjCommonLabel;
        private global::Gizmox.WebGUI.Forms.CheckBox mobjMaximizeCheckBox;
        private global::Gizmox.WebGUI.Forms.CheckBox mobjMinimizeCheckBox;
        private global::Gizmox.WebGUI.Forms.Label mobjStateLabel;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private global::Gizmox.WebGUI.Forms.Button mobjCloseButton;


    }
}