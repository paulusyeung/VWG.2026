namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    partial class MaxSizePage
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
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjSetMaxSizeFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaxSizeFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSetMaxSizeFontNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjSetMaxSizeFontNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjSetMaxSizeFontLabel
            // 
            this.mobjSetMaxSizeFontLabel.AutoSize = true;
            this.mobjSetMaxSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSetMaxSizeFontLabel.Location = new System.Drawing.Point(58, 172);
            this.mobjSetMaxSizeFontLabel.Name = "mobjSetMaxSizeFontLabel";
            this.mobjSetMaxSizeFontLabel.Size = new System.Drawing.Size(291, 50);
            this.mobjSetMaxSizeFontLabel.TabIndex = 1;
            this.mobjSetMaxSizeFontLabel.Text = "Maximum font size for label";
            // 
            // mobjMaxSizeFontLabel
            // 
            this.mobjMaxSizeFontLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjMaxSizeFontLabel, 2);
            this.mobjMaxSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaxSizeFontLabel.Location = new System.Drawing.Point(58, 82);
            this.mobjMaxSizeFontLabel.Name = "mobjMaxSizeFontLabel";
            this.mobjMaxSizeFontLabel.Size = new System.Drawing.Size(465, 50);
            this.mobjMaxSizeFontLabel.TabIndex = 3;
            this.mobjMaxSizeFontLabel.Text = "Font selected in the dialog:";
            // 
            // mobjChangeFontButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjChangeFontButton, 2);
            this.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeFontButton.Location = new System.Drawing.Point(58, 242);
            this.mobjChangeFontButton.Name = "mobjChangeFontButton";
            this.mobjChangeFontButton.Size = new System.Drawing.Size(465, 50);
            this.mobjChangeFontButton.TabIndex = 4;
            this.mobjChangeFontButton.Text = "Open FontDialog to change font of the label";
            this.mobjChangeFontButton.UseVisualStyleBackColor = true;
            this.mobjChangeFontButton.Click += new System.EventHandler(this.mobjChangeFontButton_Click);
            // 
            // mobjSetMaxSizeFontNumericUpDown
            // 
            this.mobjSetMaxSizeFontNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjSetMaxSizeFontNumericUpDown.CurrentValue = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.mobjSetMaxSizeFontNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSetMaxSizeFontNumericUpDown.Location = new System.Drawing.Point(349, 172);
            this.mobjSetMaxSizeFontNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.mobjSetMaxSizeFontNumericUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.mobjSetMaxSizeFontNumericUpDown.Name = "mobjSetMaxSizeFontNumericUpDown";
            this.mobjSetMaxSizeFontNumericUpDown.Size = new System.Drawing.Size(174, 21);
            this.mobjSetMaxSizeFontNumericUpDown.TabIndex = 5;
            this.mobjSetMaxSizeFontNumericUpDown.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxSizeFontLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeFontButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetMaxSizeFontNumericUpDown, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetMaxSizeFontLabel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(583, 374);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // MaxSizePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(583, 374);
            this.Text = "MaxSizePage";
            this.Load += new System.EventHandler(this.MaxSizePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjSetMaxSizeFontNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.Label mobjSetMaxSizeFontLabel;
        private Gizmox.WebGUI.Forms.Label mobjMaxSizeFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeFontButton;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjSetMaxSizeFontNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
