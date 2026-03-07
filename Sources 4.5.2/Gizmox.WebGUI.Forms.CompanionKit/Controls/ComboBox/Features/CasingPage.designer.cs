namespace CompanionKit.Controls.ComboBox.Features
{
    partial class CasingPage
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
            this.mobjTestComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCasingComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjCasingLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTestLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTestComboBox
            // 
            this.mobjTestComboBox.AllowDrag = false;
            this.mobjTestComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTestComboBox.FormattingEnabled = true;
            this.mobjTestComboBox.Items.AddRange(new object[] {
            "aBcD",
            "BcDa",
            "cDaB",
            "DaBc"});
            this.mobjTestComboBox.Location = new System.Drawing.Point(103, 63);
            this.mobjTestComboBox.Name = "objComboBox";
            this.mobjTestComboBox.Size = new System.Drawing.Size(150, 21);
            this.mobjTestComboBox.TabIndex = 0;
            // 
            // mobjCasingComboBox
            // 
            this.mobjCasingComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCasingComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjCasingComboBox.FormattingEnabled = true;
            this.mobjCasingComboBox.Items.AddRange(new object[] {
            "Normal",
            "Upper",
            "Lower"});
            this.mobjCasingComboBox.Location = new System.Drawing.Point(103, 153);
            this.mobjCasingComboBox.Name = "S";
            this.mobjCasingComboBox.Size = new System.Drawing.Size(150, 21);
            this.mobjCasingComboBox.TabIndex = 1;
            this.mobjCasingComboBox.Text = "Normal";
            this.mobjCasingComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjCasingComboBox_SelectedIndexChanged);
            // 
            // mobjCasingLabel
            // 
            this.mobjCasingLabel.AutoSize = true;
            this.mobjCasingLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCasingLabel.Location = new System.Drawing.Point(103, 113);
            this.mobjCasingLabel.Name = "objCasingLabel";
            this.mobjCasingLabel.Size = new System.Drawing.Size(150, 40);
            this.mobjCasingLabel.TabIndex = 2;
            this.mobjCasingLabel.Text = "Casing";
            this.mobjCasingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTestLabel
            // 
            this.mobjTestLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjTestLabel, 2);
            this.mobjTestLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTestLabel.Location = new System.Drawing.Point(103, 23);
            this.mobjTestLabel.Name = "objTestLabel";
            this.mobjTestLabel.Size = new System.Drawing.Size(253, 40);
            this.mobjTestLabel.TabIndex = 3;
            this.mobjTestLabel.Text = "Test ComboBox";
            this.mobjTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 150F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTestLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjCasingComboBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjCasingLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjTestComboBox, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(356, 206);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // CasingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(356, 206);
            this.Text = "CasingPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjTestComboBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjCasingComboBox;
        private Gizmox.WebGUI.Forms.Label mobjCasingLabel;
        private Gizmox.WebGUI.Forms.Label mobjTestLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}