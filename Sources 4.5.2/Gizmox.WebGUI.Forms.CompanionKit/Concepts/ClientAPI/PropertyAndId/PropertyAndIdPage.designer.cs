namespace CompanionKit.Concepts.ClientAPI.PropertyAndId
{
    partial class PropertyAndIdPage
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
            this.mobjTestButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPrintButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPrintPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTextBoxPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjGroupPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPrintPanel.SuspendLayout();
            this.mobjTextBoxPanel.SuspendLayout();
            this.mobjGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTestButton
            // 
            this.mobjTestButton.AccessibleDescription = "";
            this.mobjTestButton.AccessibleName = "";
            this.mobjTestButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTestButton.ClientId = "button";
            this.mobjTestButton.Location = new System.Drawing.Point(19, 80);
            this.mobjTestButton.Name = "mobjTestButton";
            this.mobjTestButton.Size = new System.Drawing.Size(130, 81);
            this.mobjTestButton.TabIndex = 1;
            this.mobjTestButton.Text = "Normal";
            this.mobjTestButton.Click += new System.EventHandler(this.mobjTestButton_Click);
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AccessibleDescription = "";
            this.mobjTextBox.AccessibleName = "";
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.ClientId = "text";
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextBox.Location = new System.Drawing.Point(20, 5);
            this.mobjTextBox.Multiline = true;
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(146, 93);
            this.mobjTextBox.TabIndex = 2;
            // 
            // mobjPrintButton
            // 
            this.mobjPrintButton.AccessibleDescription = "";
            this.mobjPrintButton.AccessibleName = "";
            this.mobjPrintButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPrintButton.Location = new System.Drawing.Point(20, 5);
            this.mobjPrintButton.MaximumSize = new System.Drawing.Size(0, 90);
            this.mobjPrintButton.Name = "mobjPrintButton";
            this.mobjPrintButton.Size = new System.Drawing.Size(146, 70);
            this.mobjPrintButton.TabIndex = 3;
            this.mobjPrintButton.Text = "PrintProperties";
            this.mobjPrintButton.Click += new System.EventHandler(this.mobjPrintButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.AccessibleDescription = "";
            this.mobjLayoutPanel.AccessibleName = "";
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPrintPanel, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBoxPanel, 2, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.15624F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.68752F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.15624F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(571, 306);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjPrintPanel
            // 
            this.mobjPrintPanel.AccessibleDescription = "";
            this.mobjPrintPanel.AccessibleName = "";
            this.mobjPrintPanel.Controls.Add(this.mobjPrintButton);
            this.mobjPrintPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPrintPanel.DockPadding.Bottom = 5;
            this.mobjPrintPanel.DockPadding.Left = 20;
            this.mobjPrintPanel.DockPadding.Right = 5;
            this.mobjPrintPanel.DockPadding.Top = 5;
            this.mobjPrintPanel.Location = new System.Drawing.Point(285, 61);
            this.mobjPrintPanel.Name = "mobjPrintPanel";
            this.mobjPrintPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20, 5, 5, 5);
            this.mobjPrintPanel.Size = new System.Drawing.Size(171, 80);
            this.mobjPrintPanel.TabIndex = 0;
            // 
            // mobjTextBoxPanel
            // 
            this.mobjTextBoxPanel.AccessibleDescription = "";
            this.mobjTextBoxPanel.AccessibleName = "";
            this.mobjTextBoxPanel.Controls.Add(this.mobjTextBox);
            this.mobjTextBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextBoxPanel.DockPadding.Bottom = 5;
            this.mobjTextBoxPanel.DockPadding.Left = 20;
            this.mobjTextBoxPanel.DockPadding.Right = 5;
            this.mobjTextBoxPanel.DockPadding.Top = 5;
            this.mobjTextBoxPanel.Location = new System.Drawing.Point(285, 141);
            this.mobjTextBoxPanel.Name = "mobjTextBoxPanel";
            this.mobjTextBoxPanel.Padding = new Gizmox.WebGUI.Forms.Padding(20, 5, 5, 5);
            this.mobjTextBoxPanel.Size = new System.Drawing.Size(171, 103);
            this.mobjTextBoxPanel.TabIndex = 0;
            // 
            // mobjGroupPanel
            // 
            this.mobjGroupPanel.AccessibleDescription = "";
            this.mobjGroupPanel.AccessibleName = "";
            this.mobjGroupPanel.Controls.Add(this.mobjTestButton);
            this.mobjGroupPanel.Controls.Add(this.mobjLabel);
            this.mobjGroupPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupPanel.DockPadding.All = 5;
            this.mobjGroupPanel.Location = new System.Drawing.Point(114, 61);
            this.mobjGroupPanel.Name = "mobjGroupPanel";
            this.mobjGroupPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjLayoutPanel.SetRowSpan(this.mobjGroupPanel, 2);
            this.mobjGroupPanel.Size = new System.Drawing.Size(171, 183);
            this.mobjGroupPanel.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(5, 5);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(161, 70);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Click on button to change its Button Style:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PropertyAndIdPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(571, 306);
            this.Text = "PropertyAndIdPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPrintPanel.ResumeLayout(false);
            this.mobjTextBoxPanel.ResumeLayout(false);
            this.mobjGroupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Gizmox.WebGUI.Forms.Button mobjTestButton;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Button mobjPrintButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPrintPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTextBoxPanel;
        private Gizmox.WebGUI.Forms.Panel mobjGroupPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;

        #endregion
    }
}