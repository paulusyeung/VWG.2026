namespace CompanionKit.Controls.HeaderedPanel.Features
{
    partial class HeaderedPanelIconPropertyPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeaderedPanelIconPropertyPage));
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjHeaderedPanel = new Gizmox.WebGUI.Forms.HeaderedPanel();
            this.mobjRadioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton3 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjHeaderedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(63, 93);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Panel content";
            // 
            // mobjHeaderedPanel
            // 
            this.mobjHeaderedPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjHeaderedPanel.Controls.Add(this.mobjLabel);
            this.mobjHeaderedPanel.CustomStyle = "HeaderedPanel";
            this.mobjHeaderedPanel.Location = new System.Drawing.Point(11, 15);
            this.mobjHeaderedPanel.Name = "mobjHeaderedPanel";
            this.mobjHeaderedPanel.Size = new System.Drawing.Size(200, 200);
            this.mobjHeaderedPanel.TabIndex = 0;
            // 
            // mobjRadioButton1
            // 
            this.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton1.Image"));
            this.mobjRadioButton1.Location = new System.Drawing.Point(223, 15);
            this.mobjRadioButton1.Name = "mobjRadioButton1";
            this.mobjRadioButton1.Size = new System.Drawing.Size(120, 40);
            this.mobjRadioButton1.TabIndex = 1;
            this.mobjRadioButton1.Text = "Image 1";
            this.mobjRadioButton1.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.mobjRadioButton1.UseVisualStyleBackColor = true;
            this.mobjRadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjRadioButton2
            // 
            this.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton2.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton2.Image"));
            this.mobjRadioButton2.Location = new System.Drawing.Point(223, 82);
            this.mobjRadioButton2.Name = "mobjRadioButton2";
            this.mobjRadioButton2.Size = new System.Drawing.Size(120, 40);
            this.mobjRadioButton2.TabIndex = 1;
            this.mobjRadioButton2.Text = "Image 2";
            this.mobjRadioButton2.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.mobjRadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjRadioButton3
            // 
            this.mobjRadioButton3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton3.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton3.Image"));
            this.mobjRadioButton3.Location = new System.Drawing.Point(223, 143);
            this.mobjRadioButton3.Name = "mobjRadioButton3";
            this.mobjRadioButton3.Size = new System.Drawing.Size(120, 40);
            this.mobjRadioButton3.TabIndex = 1;
            this.mobjRadioButton3.Text = "Image 3";
            this.mobjRadioButton3.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.mobjRadioButton3.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // HeaderedPanelIconPropertyPage
            // 
            this.Controls.Add(this.mobjRadioButton3);
            this.Controls.Add(this.mobjRadioButton2);
            this.Controls.Add(this.mobjRadioButton1);
            this.Controls.Add(this.mobjHeaderedPanel);
            this.Size = new System.Drawing.Size(372, 290);
            this.Text = "HeaderedPanelIconPropertyPage";
            this.mobjHeaderedPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.HeaderedPanel mobjHeaderedPanel;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton2;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton3;



    }
}