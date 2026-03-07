namespace CompanionKit.Controls.UserControlFolder.ApplicationScenario
{
    partial class PasswordStrengthCheckerPage
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
            this.mobjPasswordStrengthChecker1 = new Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario.ucPasswordStrengthChecker();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPasswordStrengthChecker2 = new Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario.ucPasswordStrengthChecker();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabelPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjInfoLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPasswordStrengthChecker1
            // 
            this.mobjPasswordStrengthChecker1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjPasswordStrengthChecker1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))));
            this.mobjPasswordStrengthChecker1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPasswordStrengthChecker1.Location = new System.Drawing.Point(0, 22);
            this.mobjPasswordStrengthChecker1.Name = "mobjPasswordStrengthChecker1";
            this.mobjPasswordStrengthChecker1.Size = new System.Drawing.Size(300, 75);
            this.mobjPasswordStrengthChecker1.TabIndex = 0;
            this.mobjPasswordStrengthChecker1.Text = "ucPasswordStrengthChecker";
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(512, 50);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "Use UserControl below to check password strength";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjPasswordStrengthChecker2
            // 
            this.mobjPasswordStrengthChecker2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjPasswordStrengthChecker2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))));
            this.mobjPasswordStrengthChecker2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPasswordStrengthChecker2.Location = new System.Drawing.Point(96, 81);
            this.mobjPasswordStrengthChecker2.Name = "mobjPasswordStrengthChecker2";
            this.mobjPasswordStrengthChecker2.Size = new System.Drawing.Size(315, 118);
            this.mobjPasswordStrengthChecker2.TabIndex = 0;
            this.mobjPasswordStrengthChecker2.Text = "ucPasswordStrengthChecker";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 320F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPasswordStrengthChecker2, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoLabelPanel, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 120F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(512, 232);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // mobjInfoLabelPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjInfoLabelPanel, 3);
            this.mobjInfoLabelPanel.Controls.Add(this.mobjDescriptionLabel);
            this.mobjInfoLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabelPanel.Location = new System.Drawing.Point(0, 31);
            this.mobjInfoLabelPanel.Name = "mobjInfoLabelPanel";
            this.mobjInfoLabelPanel.Size = new System.Drawing.Size(512, 50);
            this.mobjInfoLabelPanel.TabIndex = 0;
            // 
            // PasswordStrengthCheckerPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(512, 232);
            this.Text = "PasswordStrengthCheckerPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjInfoLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario.ucPasswordStrengthChecker mobjPasswordStrengthChecker1;
        private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.CompanionKit.Controls.UserControlFolder.ApplicationScenario.ucPasswordStrengthChecker mobjPasswordStrengthChecker2;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjInfoLabelPanel;



    }
}