namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    partial class MinSizePage
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
            this.mobjSetMinSizeFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMinSizeFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjSetMinSizeFontNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjSetMinSizeFontNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjSetMinSizeFontLabel
            // 
            this.mobjSetMinSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSetMinSizeFontLabel.Location = new System.Drawing.Point(59, 101);
            this.mobjSetMinSizeFontLabel.Name = "mobjSetMinSizeFontLabel";
            this.mobjSetMinSizeFontLabel.Size = new System.Drawing.Size(298, 50);
            this.mobjSetMinSizeFontLabel.TabIndex = 1;
            this.mobjSetMinSizeFontLabel.Text = "Minimum font size for label";
            // 
            // mobjMinSizeFontLabel
            // 
            this.mobjMinSizeFontLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjMinSizeFontLabel, 2);
            this.mobjMinSizeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMinSizeFontLabel.Location = new System.Drawing.Point(59, 11);
            this.mobjMinSizeFontLabel.Name = "mobjMinSizeFontLabel";
            this.mobjMinSizeFontLabel.Size = new System.Drawing.Size(477, 50);
            this.mobjMinSizeFontLabel.TabIndex = 3;
            this.mobjMinSizeFontLabel.Text = "Font selected in the dialog: ";
            // 
            // mobjChangeFontButton
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjChangeFontButton, 2);
            this.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeFontButton.Location = new System.Drawing.Point(59, 171);
            this.mobjChangeFontButton.Name = "mobjChangeFontButton";
            this.mobjChangeFontButton.Size = new System.Drawing.Size(477, 50);
            this.mobjChangeFontButton.TabIndex = 4;
            this.mobjChangeFontButton.Text = "Open FontDialog to change font of the label";
            this.mobjChangeFontButton.UseVisualStyleBackColor = true;
            this.mobjChangeFontButton.Click += new System.EventHandler(this.mobjChangeFontButton_Click);
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjSetMinSizeFontNumericUpDown
            // 
            this.mobjSetMinSizeFontNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjSetMinSizeFontNumericUpDown.CurrentValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mobjSetMinSizeFontNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSetMinSizeFontNumericUpDown.Location = new System.Drawing.Point(357, 101);
            this.mobjSetMinSizeFontNumericUpDown.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.mobjSetMinSizeFontNumericUpDown.Name = "mobjSetMinSizeFontNumericUpDown";
            this.mobjSetMinSizeFontNumericUpDown.Size = new System.Drawing.Size(179, 21);
            this.mobjSetMinSizeFontNumericUpDown.TabIndex = 5;
            this.mobjSetMinSizeFontNumericUpDown.Value = new decimal(new int[] {
            20,
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
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeFontButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetMinSizeFontNumericUpDown, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetMinSizeFontLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinSizeFontLabel, 1, 1);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(597, 232);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // MinSizePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(583, 374);
            this.Text = "MinSizePage";
            this.Load += new System.EventHandler(this.MinSizePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjSetMinSizeFontNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjSetMinSizeFontLabel;
        private Gizmox.WebGUI.Forms.Label mobjMinSizeFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeFontButton;
        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjSetMinSizeFontNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
