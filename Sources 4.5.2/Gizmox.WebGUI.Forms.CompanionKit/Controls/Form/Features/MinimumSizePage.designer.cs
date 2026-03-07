namespace CompanionKit.Controls.Form.Features
{
    partial class MinimumSizePage
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
            this.mobjWidthNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjHeightNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjOpenDialogButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBorderButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBorderPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjWidthLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjHeightLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAdditionalLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjWidthPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjHeightPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjContainerBorderPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjDialogPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjMinPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjWidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjHeightNUD)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjAdditionalLayoutPanel.SuspendLayout();
            this.mobjWidthPanel.SuspendLayout();
            this.mobjHeightPanel.SuspendLayout();
            this.mobjContainerBorderPanel.SuspendLayout();
            this.mobjDialogPanel.SuspendLayout();
            this.mobjMinPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWidthNUD
            // 
            this.mobjWidthNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjWidthNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjWidthNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjWidthNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjWidthNUD.Location = new System.Drawing.Point(0, 29);
            this.mobjWidthNUD.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.mobjWidthNUD.Name = "objWidthNUD";
            this.mobjWidthNUD.Size = new System.Drawing.Size(288, 17);
            this.mobjWidthNUD.TabIndex = 0;
            this.mobjWidthNUD.ValueChanged += new System.EventHandler(this.mobjWidthNUD_ValueChanged);
            // 
            // mobjHeightNUD
            // 
            this.mobjHeightNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjHeightNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjHeightNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjHeightNUD.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjHeightNUD.Location = new System.Drawing.Point(0, 29);
            this.mobjHeightNUD.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.mobjHeightNUD.Name = "objHeightNUD";
            this.mobjHeightNUD.Size = new System.Drawing.Size(288, 17);
            this.mobjHeightNUD.TabIndex = 1;
            this.mobjHeightNUD.ValueChanged += new System.EventHandler(this.mobjHeightNUD_ValueChanged);
            // 
            // mobjOpenDialogButton
            // 
            this.mobjOpenDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenDialogButton.Location = new System.Drawing.Point(5, 5);
            this.mobjOpenDialogButton.Name = "mobjOpenDialogButton";
            this.mobjOpenDialogButton.Size = new System.Drawing.Size(278, 70);
            this.mobjOpenDialogButton.TabIndex = 2;
            this.mobjOpenDialogButton.Text = "Open dialog";
            this.mobjOpenDialogButton.Click += new System.EventHandler(this.mobjOpenDialogButton_Click);
            // 
            // mobjBorderButton
            // 
            this.mobjBorderButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBorderButton.Location = new System.Drawing.Point(5, 5);
            this.mobjBorderButton.Name = "mobjBorderButton";
            this.mobjBorderButton.Size = new System.Drawing.Size(278, 70);
            this.mobjBorderButton.TabIndex = 3;
            this.mobjBorderButton.Text = "Show minimum size border";
            this.mobjBorderButton.Click += new System.EventHandler(this.mobjBorderButton_Click);
            // 
            // mobjBorderPanel
            // 
            this.mobjBorderPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.mobjBorderPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed;
            this.mobjBorderPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjBorderPanel.Location = new System.Drawing.Point(18, 13);
            this.mobjBorderPanel.Name = "objBorderPanel";
            this.mobjBorderPanel.Size = new System.Drawing.Size(0, 0);
            this.mobjBorderPanel.TabIndex = 4;
            this.mobjBorderPanel.Visible = false;
            // 
            // mobjWidthLabel
            // 
            this.mobjWidthLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWidthLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjWidthLabel.Name = "objWidthLabel";
            this.mobjWidthLabel.Size = new System.Drawing.Size(288, 29);
            this.mobjWidthLabel.TabIndex = 5;
            this.mobjWidthLabel.Text = "MIN width";
            this.mobjWidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mobjHeightLabel
            // 
            this.mobjHeightLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjHeightLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjHeightLabel.Name = "objHeightLabel";
            this.mobjHeightLabel.Size = new System.Drawing.Size(288, 29);
            this.mobjHeightLabel.TabIndex = 5;
            this.mobjHeightLabel.Text = "MIN height";
            this.mobjHeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerBorderPanel, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDialogPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinPanel, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(742, 285);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjAdditionalLayoutPanel);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(20, 60);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(288, 100);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjAdditionalLayoutPanel
            // 
            this.mobjAdditionalLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjAdditionalLayoutPanel.ColumnCount = 1;
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjAdditionalLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjWidthPanel, 0, 0);
            this.mobjAdditionalLayoutPanel.Controls.Add(this.mobjHeightPanel, 0, 1);
            this.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAdditionalLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel";
            this.mobjAdditionalLayoutPanel.RowCount = 2;
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAdditionalLayoutPanel.Size = new System.Drawing.Size(288, 100);
            this.mobjAdditionalLayoutPanel.TabIndex = 6;
            // 
            // mobjWidthPanel
            // 
            this.mobjWidthPanel.Controls.Add(this.mobjWidthLabel);
            this.mobjWidthPanel.Controls.Add(this.mobjWidthNUD);
            this.mobjWidthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWidthPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjWidthPanel.Name = "mobjWidthPanel";
            this.mobjWidthPanel.Size = new System.Drawing.Size(288, 50);
            this.mobjWidthPanel.TabIndex = 0;
            // 
            // mobjHeightPanel
            // 
            this.mobjHeightPanel.Controls.Add(this.mobjHeightLabel);
            this.mobjHeightPanel.Controls.Add(this.mobjHeightNUD);
            this.mobjHeightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHeightPanel.Location = new System.Drawing.Point(0, 50);
            this.mobjHeightPanel.Name = "mobjHeightPanel";
            this.mobjHeightPanel.Size = new System.Drawing.Size(288, 50);
            this.mobjHeightPanel.TabIndex = 0;
            // 
            // mobjContainerBorderPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjContainerBorderPanel, 2);
            this.mobjContainerBorderPanel.Controls.Add(this.mobjBorderPanel);
            this.mobjContainerBorderPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerBorderPanel.Location = new System.Drawing.Point(308, 60);
            this.mobjContainerBorderPanel.Name = "mobjBorderPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjContainerBorderPanel, 5);
            this.mobjContainerBorderPanel.Size = new System.Drawing.Size(434, 340);
            this.mobjContainerBorderPanel.TabIndex = 0;
            // 
            // mobjDialogPanel
            // 
            this.mobjDialogPanel.Controls.Add(this.mobjOpenDialogButton);
            this.mobjDialogPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDialogPanel.DockPadding.All = 5;
            this.mobjDialogPanel.Location = new System.Drawing.Point(20, 180);
            this.mobjDialogPanel.Name = "mobjDialogPanel";
            this.mobjDialogPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjDialogPanel.Size = new System.Drawing.Size(288, 80);
            this.mobjDialogPanel.TabIndex = 0;
            // 
            // mobjMinPanel
            // 
            this.mobjMinPanel.Controls.Add(this.mobjBorderButton);
            this.mobjMinPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMinPanel.DockPadding.All = 5;
            this.mobjMinPanel.Location = new System.Drawing.Point(20, 260);
            this.mobjMinPanel.Name = "mobjMinPanel";
            this.mobjMinPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjMinPanel.Size = new System.Drawing.Size(288, 80);
            this.mobjMinPanel.TabIndex = 0;
            // 
            // MinimumSizePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(742, 400);
            this.Text = "MinimumSizePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjWidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjHeightNUD)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjAdditionalLayoutPanel.ResumeLayout(false);
            this.mobjWidthPanel.ResumeLayout(false);
            this.mobjHeightPanel.ResumeLayout(false);
            this.mobjContainerBorderPanel.ResumeLayout(false);
            this.mobjDialogPanel.ResumeLayout(false);
            this.mobjMinPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.NumericUpDown mobjWidthNUD;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjHeightNUD;
        private Gizmox.WebGUI.Forms.Button mobjOpenDialogButton;
        private Gizmox.WebGUI.Forms.Button mobjBorderButton;
        private Gizmox.WebGUI.Forms.Panel mobjBorderPanel;
        private Gizmox.WebGUI.Forms.Label mobjWidthLabel;
        private Gizmox.WebGUI.Forms.Label mobjHeightLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerBorderPanel;
        private Gizmox.WebGUI.Forms.Panel mobjDialogPanel;
        private Gizmox.WebGUI.Forms.Panel mobjMinPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjAdditionalLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjWidthPanel;
        private Gizmox.WebGUI.Forms.Panel mobjHeightPanel;



    }
}