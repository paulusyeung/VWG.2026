namespace CompanionKit.Controls.HeaderedPanel.Features
{
    partial class HeaderDemonstrationPage
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
            this.mobjHeaderedPanel = new Gizmox.WebGUI.Forms.HeaderedPanel();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjButtonRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjCheckBoxRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTextIconRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTextRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjHeaderedPanel
            // 
            this.mobjHeaderedPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjHeaderedPanel.CustomStyle = "HeaderedPanel";
            this.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHeaderedPanel.Location = new System.Drawing.Point(106, 37);
            this.mobjHeaderedPanel.Name = "mobjHeaderedPanel";
            this.mobjHeaderedPanel.Size = new System.Drawing.Size(212, 167);
            this.mobjHeaderedPanel.TabIndex = 0;
            this.mobjHeaderedPanel.Text = "Text";
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjButtonRadioButton);
            this.mobjGroupBox.Controls.Add(this.mobjCheckBoxRadioButton);
            this.mobjGroupBox.Controls.Add(this.mobjTextIconRadioButton);
            this.mobjGroupBox.Controls.Add(this.mobjTextRadioButton);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 15);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(212, 133);
            this.mobjGroupBox.TabIndex = 1;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "HeaderType";
            // 
            // mobjButtonRadioButton
            // 
            this.mobjButtonRadioButton.AutoSize = true;
            this.mobjButtonRadioButton.Location = new System.Drawing.Point(44, 108);
            this.mobjButtonRadioButton.Name = "mobjButtonRadioButton";
            this.mobjButtonRadioButton.Size = new System.Drawing.Size(57, 17);
            this.mobjButtonRadioButton.TabIndex = 3;
            this.mobjButtonRadioButton.Text = "Button";
            this.mobjButtonRadioButton.CheckedChanged += new System.EventHandler(this.mobjButtonRadioButton_CheckedChanged);
            // 
            // mobjCheckBoxRadioButton
            // 
            this.mobjCheckBoxRadioButton.AutoSize = true;
            this.mobjCheckBoxRadioButton.Location = new System.Drawing.Point(44, 80);
            this.mobjCheckBoxRadioButton.Name = "mobjCheckBoxRadioButton";
            this.mobjCheckBoxRadioButton.Size = new System.Drawing.Size(72, 17);
            this.mobjCheckBoxRadioButton.TabIndex = 2;
            this.mobjCheckBoxRadioButton.Text = "CheckBox";
            this.mobjCheckBoxRadioButton.CheckedChanged += new System.EventHandler(this.mobjCheckBoxRadioButton_CheckedChanged);
            // 
            // mobjTextIconRadioButton
            // 
            this.mobjTextIconRadioButton.AutoSize = true;
            this.mobjTextIconRadioButton.Location = new System.Drawing.Point(44, 53);
            this.mobjTextIconRadioButton.Name = "mobjTextIconRadioButton";
            this.mobjTextIconRadioButton.Size = new System.Drawing.Size(82, 17);
            this.mobjTextIconRadioButton.TabIndex = 1;
            this.mobjTextIconRadioButton.Text = "Text + Icon";
            this.mobjTextIconRadioButton.CheckedChanged += new System.EventHandler(this.mobjTextIconRadioButton_CheckedChanged);
            // 
            // mobjTextRadioButton
            // 
            this.mobjTextRadioButton.AutoSize = true;
            this.mobjTextRadioButton.Checked = true;
            this.mobjTextRadioButton.Location = new System.Drawing.Point(44, 26);
            this.mobjTextRadioButton.Name = "mobjTextRadioButton";
            this.mobjTextRadioButton.Size = new System.Drawing.Size(47, 17);
            this.mobjTextRadioButton.TabIndex = 0;
            this.mobjTextRadioButton.Text = "Text";
            this.mobjTextRadioButton.CheckedChanged += new System.EventHandler(this.mobjTextRadioButton_CheckedChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjHeaderedPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerPanel, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(425, 372);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.Controls.Add(this.mobjGroupBox);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.DockPadding.Bottom = 20;
            this.mobjContainerPanel.DockPadding.Top = 15;
            this.mobjContainerPanel.Location = new System.Drawing.Point(106, 204);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 15, 0, 20);
            this.mobjContainerPanel.Size = new System.Drawing.Size(212, 168);
            this.mobjContainerPanel.TabIndex = 0;
            // 
            // HeaderDemonstrationPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(425, 372);
            this.Text = "HeaderDemonstrationPage";
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.HeaderedPanel mobjHeaderedPanel;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjButtonRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjCheckBoxRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjTextIconRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjTextRadioButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;



    }
}