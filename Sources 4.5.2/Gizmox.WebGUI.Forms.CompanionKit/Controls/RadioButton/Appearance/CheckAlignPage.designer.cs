namespace CompanionKit.Controls.RadioButton.Appearance
{
    partial class CheckAlignPage
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
            this.mobjRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRadioLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjRadioButton
            // 
            this.mobjRadioButton.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Blue);
            this.mobjRadioButton.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjRadioButton.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRadioButton.Location = new System.Drawing.Point(114, 27);
            this.mobjRadioButton.Name = "mobjRadioButton";
            this.mobjRadioButton.Size = new System.Drawing.Size(342, 81);
            this.mobjRadioButton.TabIndex = 0;
            this.mobjRadioButton.Text = "Test Check Alignment";
            // 
            // mobjRadioComboBox
            // 
            this.mobjRadioComboBox.AllowDrag = false;
            this.mobjRadioComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioComboBox.FormattingEnabled = true;
            this.mobjRadioComboBox.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "MiddleLeft",
            "MiddleCenter",
            "MiddleRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight"});
            this.mobjRadioComboBox.Location = new System.Drawing.Point(116, 38);
            this.mobjRadioComboBox.Name = "mobjRadioComboBox";
            this.mobjRadioComboBox.Size = new System.Drawing.Size(141, 30);
            this.mobjRadioComboBox.TabIndex = 1;
            this.mobjRadioComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjRadioComboBox_SelectedIndexChanged);
            // 
            // mobjTextComboBox
            // 
            this.mobjTextComboBox.AllowDrag = false;
            this.mobjTextComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTextComboBox.FormattingEnabled = true;
            this.mobjTextComboBox.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "MiddleLeft",
            "MiddleCenter",
            "MiddleRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight"});
            this.mobjTextComboBox.Location = new System.Drawing.Point(116, 95);
            this.mobjTextComboBox.Name = "mobjTextComboBox";
            this.mobjTextComboBox.Size = new System.Drawing.Size(141, 30);
            this.mobjTextComboBox.TabIndex = 2;
            this.mobjTextComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjTextComboBox_SelectedIndexChanged);
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTextLabel.AutoSize = true;
            this.mobjTextLabel.Location = new System.Drawing.Point(113, 17);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjTextLabel.TabIndex = 3;
            this.mobjTextLabel.Text = "Text";
            // 
            // mobjRadioLabel
            // 
            this.mobjRadioLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRadioLabel.AutoSize = true;
            this.mobjRadioLabel.Location = new System.Drawing.Point(113, 72);
            this.mobjRadioLabel.Name = "mobjRadioLabel";
            this.mobjRadioLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjRadioLabel.TabIndex = 4;
            this.mobjRadioLabel.Text = "Radio Box";
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjRadioComboBox);
            this.mobjGroupBox.Controls.Add(this.mobjTextLabel);
            this.mobjGroupBox.Controls.Add(this.mobjRadioLabel);
            this.mobjGroupBox.Controls.Add(this.mobjTextComboBox);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(114, 128);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(190, 103);
            this.mobjGroupBox.TabIndex = 5;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Alignment";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupBox, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjRadioButton, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(571, 293);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // CheckAlignPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(571, 293);
            this.Text = "CheckAlignPage";
            this.Load += new System.EventHandler(this.CheckAlignPage_Load);
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.RadioButton mobjRadioButton;
        private Gizmox.WebGUI.Forms.ComboBox mobjRadioComboBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjTextComboBox;
        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjRadioLabel;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
