namespace CompanionKit.Controls.TrackBar.Functionality
{
    partial class SettingValueAndRangePage
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
            this.mobjValueTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueTrackBarNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjMinTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMaxTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjMinTrackBarNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjMaxTrackBarNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjValueTrackBarNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinTrackBarNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxTrackBarNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoTrackBar
            // 
            this.mobjDemoTrackBar.AllowDrag = false;
            this.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoTrackBar.Location = new System.Drawing.Point(0, 0);
            this.mobjDemoTrackBar.Maximum = 100;
            this.mobjDemoTrackBar.Name = "mobjDemoTrackBar";
            this.mobjDemoTrackBar.Size = new System.Drawing.Size(454, 40);
            this.mobjDemoTrackBar.TabIndex = 0;
            this.mobjDemoTrackBar.TickFrequency = 5;
            this.mobjDemoTrackBar.TickStyle = Gizmox.WebGUI.Forms.TickStyle.Both;
            this.mobjDemoTrackBar.ValueChanged += new System.EventHandler(this.mobjDemoTrackBar_ValueChanged);
            // 
            // mobjValueTrackBarLabel
            // 
            this.mobjValueTrackBarLabel.AutoSize = true;
            this.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjValueTrackBarLabel.Location = new System.Drawing.Point(97, 26);
            this.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel";
            this.mobjValueTrackBarLabel.Size = new System.Drawing.Size(227, 13);
            this.mobjValueTrackBarLabel.TabIndex = 2;
            this.mobjValueTrackBarLabel.Text = "TrackBar value";
            // 
            // mobjValueTrackBarNumericUpDown
            // 
            this.mobjValueTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjValueTrackBarNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjValueTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjValueTrackBarNumericUpDown.Location = new System.Drawing.Point(324, 26);
            this.mobjValueTrackBarNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTrackBarNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.mobjValueTrackBarNumericUpDown.Name = "mobjValueTrackBarNumericUpDown";
            this.mobjValueTrackBarNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjValueTrackBarNumericUpDown.TabIndex = 3;
            this.mobjValueTrackBarNumericUpDown.ValueChanged += new System.EventHandler(this.mobjValueTrackBarNumericUpDown_ValueChanged);
            // 
            // mobjMinTrackBarLabel
            // 
            this.mobjMinTrackBarLabel.AutoSize = true;
            this.mobjMinTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMinTrackBarLabel.Location = new System.Drawing.Point(97, 66);
            this.mobjMinTrackBarLabel.Name = "mobjMinTrackBarLabel";
            this.mobjMinTrackBarLabel.Size = new System.Drawing.Size(227, 13);
            this.mobjMinTrackBarLabel.TabIndex = 4;
            this.mobjMinTrackBarLabel.Text = "Minimum value";
            // 
            // mobjMaxTrackBarLabel
            // 
            this.mobjMaxTrackBarLabel.AutoSize = true;
            this.mobjMaxTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaxTrackBarLabel.Location = new System.Drawing.Point(97, 106);
            this.mobjMaxTrackBarLabel.Name = "mobjMaxTrackBarLabel";
            this.mobjMaxTrackBarLabel.Size = new System.Drawing.Size(227, 13);
            this.mobjMaxTrackBarLabel.TabIndex = 5;
            this.mobjMaxTrackBarLabel.Text = "Maximum value";
            // 
            // mobjMinTrackBarNumericUpDown
            // 
            this.mobjMinTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMinTrackBarNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMinTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMinTrackBarNumericUpDown.Location = new System.Drawing.Point(324, 66);
            this.mobjMinTrackBarNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMinTrackBarNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.mobjMinTrackBarNumericUpDown.Name = "mobjMinTrackBarNumericUpDown";
            this.mobjMinTrackBarNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjMinTrackBarNumericUpDown.TabIndex = 6;
            this.mobjMinTrackBarNumericUpDown.ValueChanged += new System.EventHandler(this.mobjMinTrackBarNumericUpDown_ValueChanged);
            // 
            // mobjMaxTrackBarNumericUpDown
            // 
            this.mobjMaxTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjMaxTrackBarNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjMaxTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMaxTrackBarNumericUpDown.Location = new System.Drawing.Point(324, 106);
            this.mobjMaxTrackBarNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMaxTrackBarNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.mobjMaxTrackBarNumericUpDown.Name = "mobjMaxTrackBarNumericUpDown";
            this.mobjMaxTrackBarNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjMaxTrackBarNumericUpDown.TabIndex = 7;
            this.mobjMaxTrackBarNumericUpDown.ValueChanged += new System.EventHandler(this.mobjMaxTrackBarNumericUpDown_ValueChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxTrackBarNumericUpDown, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueTrackBarLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinTrackBarLabel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxTrackBarLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjMinTrackBarNumericUpDown, 2, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueTrackBarNumericUpDown, 2, 1);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(650, 212);
            this.mobjLayoutPanel.TabIndex = 8;
            // 
            // mobjPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPanel, 2);
            this.mobjPanel.Controls.Add(this.mobjDemoTrackBar);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(97, 146);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(454, 40);
            this.mobjPanel.TabIndex = 0;
            // 
            // SettingValueAndRangePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(650, 212);
            this.Text = "SettingValueAndRangePage";
            this.Load += new System.EventHandler(this.SettingValueAndRangePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjValueTrackBarNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMinTrackBarNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMaxTrackBarNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TrackBar mobjDemoTrackBar;
        private Gizmox.WebGUI.Forms.Label mobjValueTrackBarLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjValueTrackBarNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjMinTrackBarLabel;
        private Gizmox.WebGUI.Forms.Label mobjMaxTrackBarLabel;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMinTrackBarNumericUpDown;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjMaxTrackBarNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
