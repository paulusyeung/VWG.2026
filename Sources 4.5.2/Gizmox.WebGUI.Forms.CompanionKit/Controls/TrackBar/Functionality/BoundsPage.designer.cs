namespace CompanionKit.Controls.TrackBar.Functionality
{
    partial class BoundsPage
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
            this.mobjDemoTrackBar = new Gizmox.WebGUI.Forms.TrackBar();
            this.mobjMinBoundLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMinBoundNumUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjMaxBoundLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaxBoundNumUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjTrackBarToolTip = new Gizmox.WebGUI.Forms.ToolTip();
            this.mobjValueTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinBoundNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxBoundNumUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoTrackBar
            // 
            this.mobjDemoTrackBar.AllowDrag = false;
            this.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDemoTrackBar.Location = new System.Drawing.Point(0, 0);
            this.mobjDemoTrackBar.Maximum = 255;
            this.mobjDemoTrackBar.Minimum = -255;
            this.mobjDemoTrackBar.Name = "mobjDemoTrackBar";
            this.mobjDemoTrackBar.Size = new System.Drawing.Size(490, 42);
            this.mobjDemoTrackBar.TabIndex = 0;
            this.mobjDemoTrackBar.TickFrequency = 10;
            this.mobjTrackBarToolTip.SetToolTip(this.mobjDemoTrackBar, null);
            this.mobjDemoTrackBar.ValueChanged += new System.EventHandler(this.mobjDemoTrackBar_ValueChanged);
            // 
            // mobjMinBoundLabel
            // 
            this.mobjMinBoundLabel.AutoSize = true;
            this.mobjMinBoundLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMinBoundLabel.Location = new System.Drawing.Point(105, 64);
            this.mobjMinBoundLabel.Name = "mobjMinBoundLabel";
            this.mobjMinBoundLabel.Size = new System.Drawing.Size(245, 13);
            this.mobjMinBoundLabel.TabIndex = 1;
            this.mobjMinBoundLabel.Text = "Minimum value";
            this.mobjTrackBarToolTip.SetToolTip(this.mobjMinBoundLabel, null);
            // 
            // mobjMinBoundNumUpDown
            // 
            this.mobjMinBoundNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMinBoundNumUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMinBoundNumUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMinBoundNumUpDown.Location = new System.Drawing.Point(350, 64);
            this.mobjMinBoundNumUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMinBoundNumUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMinBoundNumUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.mobjMinBoundNumUpDown.Name = "mobjMinBoundNumUpDown";
            this.mobjMinBoundNumUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjMinBoundNumUpDown.TabIndex = 2;
            this.mobjTrackBarToolTip.SetToolTip(this.mobjMinBoundNumUpDown, null);
            this.mobjMinBoundNumUpDown.ValueChanged += new System.EventHandler(this.mobjMinBoundNumUpDown_ValueChanged);
            // 
            // mobjMaxBoundLabel
            // 
            this.mobjMaxBoundLabel.AutoSize = true;
            this.mobjMaxBoundLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaxBoundLabel.Location = new System.Drawing.Point(105, 104);
            this.mobjMaxBoundLabel.Name = "mobjMaxBoundLabel";
            this.mobjMaxBoundLabel.Size = new System.Drawing.Size(245, 13);
            this.mobjMaxBoundLabel.TabIndex = 3;
            this.mobjMaxBoundLabel.Text = "Maximum value";
            this.mobjTrackBarToolTip.SetToolTip(this.mobjMaxBoundLabel, null);
            // 
            // mobjMaxBoundNumUpDown
            // 
            this.mobjMaxBoundNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMaxBoundNumUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMaxBoundNumUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaxBoundNumUpDown.Location = new System.Drawing.Point(350, 104);
            this.mobjMaxBoundNumUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.mobjMaxBoundNumUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaxBoundNumUpDown.Name = "mobjMaxBoundNumUpDown";
            this.mobjMaxBoundNumUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjMaxBoundNumUpDown.TabIndex = 4;
            this.mobjTrackBarToolTip.SetToolTip(this.mobjMaxBoundNumUpDown, null);
            this.mobjMaxBoundNumUpDown.ValueChanged += new System.EventHandler(this.mobjMaxBoundNumUpDown_ValueChanged);
            // 
            // mobjValueTrackBarLabel
            // 
            this.mobjValueTrackBarLabel.AutoSize = true;
            this.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjValueTrackBarLabel.Location = new System.Drawing.Point(105, 24);
            this.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel";
            this.mobjValueTrackBarLabel.Size = new System.Drawing.Size(245, 13);
            this.mobjValueTrackBarLabel.TabIndex = 6;
            this.mobjValueTrackBarLabel.Text = "TrackBar Value";
            this.mobjTrackBarToolTip.SetToolTip(this.mobjValueTrackBarLabel, null);
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBox.Location = new System.Drawing.Point(353, 27);
            this.mobjTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.ReadOnly = true;
            this.mobjTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjTextBox.TabIndex = 7;
            this.mobjTrackBarToolTip.SetToolTip(this.mobjTextBox, null);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxBoundNumUpDown, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxBoundLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueTrackBarLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinBoundLabel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinBoundNumUpDown, 2, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(700, 208);
            this.mobjLayoutPanel.TabIndex = 8;
            // 
            // mobjPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPanel, 2);
            this.mobjPanel.Controls.Add(this.mobjDemoTrackBar);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(105, 144);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(490, 40);
            this.mobjPanel.TabIndex = 0;
            // 
            // BoundsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(700, 208);
            this.Text = "BoundsPage";
            this.mobjTrackBarToolTip.SetToolTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinBoundNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxBoundNumUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TrackBar mobjDemoTrackBar;
        private Gizmox.WebGUI.Forms.Label mobjMinBoundLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMinBoundNumUpDown;
        private Gizmox.WebGUI.Forms.Label mobjMaxBoundLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMaxBoundNumUpDown;
        private Gizmox.WebGUI.Forms.ToolTip mobjTrackBarToolTip;
        private Gizmox.WebGUI.Forms.Label mobjValueTrackBarLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
