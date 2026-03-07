namespace CompanionKit.Controls.RadioButton.Functionality
{
    partial class CheckedPage
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
            this.mobjRadioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjRadioPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjRadioPanel.SuspendLayout();
            this.mobjInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjRadioButton1
            // 
            this.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton1.AutoSize = true;
            this.mobjRadioButton1.Location = new System.Drawing.Point(45, 18);
            this.mobjRadioButton1.Name = "mobjRadioButton1";
            this.mobjRadioButton1.Size = new System.Drawing.Size(90, 17);
            this.mobjRadioButton1.TabIndex = 0;
            this.mobjRadioButton1.Text = "RadioButton1";
            // 
            // mobjRadioButton2
            // 
            this.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioButton2.AutoSize = true;
            this.mobjRadioButton2.Location = new System.Drawing.Point(45, 48);
            this.mobjRadioButton2.Name = "mobjRadioButton2";
            this.mobjRadioButton2.Size = new System.Drawing.Size(90, 17);
            this.mobjRadioButton2.TabIndex = 1;
            this.mobjRadioButton2.Text = "RadioButton2";
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(301, 64);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(150, 80);
            this.mobjButton.TabIndex = 2;
            this.mobjButton.Text = "Check the state of the RB1";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(401, 60);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "label1";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjRadioPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoPanel, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(503, 268);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjRadioPanel
            // 
            this.mobjRadioPanel.Controls.Add(this.mobjRadioButton1);
            this.mobjRadioPanel.Controls.Add(this.mobjRadioButton2);
            this.mobjRadioPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRadioPanel.Location = new System.Drawing.Point(50, 64);
            this.mobjRadioPanel.Name = "mobjRadioPanel";
            this.mobjRadioPanel.Size = new System.Drawing.Size(251, 80);
            this.mobjRadioPanel.TabIndex = 0;
            // 
            // mobjInfoPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjInfoPanel, 2);
            this.mobjInfoPanel.Controls.Add(this.mobjInfoLabel);
            this.mobjInfoPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoPanel.Location = new System.Drawing.Point(50, 144);
            this.mobjInfoPanel.Name = "mobjInfoPanel";
            this.mobjInfoPanel.Size = new System.Drawing.Size(401, 60);
            this.mobjInfoPanel.TabIndex = 0;
            // 
            // CheckedPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(503, 268);
            this.Text = "CheckedPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjRadioPanel.ResumeLayout(false);
            this.mobjInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButton2;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjRadioPanel;
        private Gizmox.WebGUI.Forms.Panel mobjInfoPanel;



    }
}
