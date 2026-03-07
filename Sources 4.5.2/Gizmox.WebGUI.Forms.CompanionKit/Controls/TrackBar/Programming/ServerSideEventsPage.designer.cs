namespace CompanionKit.Controls.TrackBar.Programming
{
    partial class ServerSideEventsPage
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
            this.mobjValueTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoTrackBar = new Gizmox.WebGUI.Forms.TrackBar();
            this.mobjValueTrackBarNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjValueTrackBarNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjValueTrackBarLabel
            // 
            this.mobjValueTrackBarLabel.AutoSize = true;
            this.mobjValueTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjValueTrackBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjValueTrackBarLabel.Name = "mobjValueTrackBarLabel";
            this.mobjValueTrackBarLabel.Size = new System.Drawing.Size(78, 13);
            this.mobjValueTrackBarLabel.TabIndex = 1;
            this.mobjValueTrackBarLabel.Text = "TrackBar value";
            // 
            // mobjDemoTrackBar
            // 
            this.mobjDemoTrackBar.AllowDrag = false;
            this.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoTrackBar.Location = new System.Drawing.Point(74, 132);
            this.mobjDemoTrackBar.Maximum = 100;
            this.mobjDemoTrackBar.Name = "mobjDemoTrackBar";
            this.mobjDemoTrackBar.Size = new System.Drawing.Size(347, 40);
            this.mobjDemoTrackBar.TabIndex = 3;
            this.mobjDemoTrackBar.TickFrequency = 5;
            this.mobjDemoTrackBar.ValueChanged += new System.EventHandler(this.mobjDemoTrackBar_ValueChanged);
            // 
            // mobjValueTrackBarNumericUpDown
            // 
            this.mobjValueTrackBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjValueTrackBarNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjValueTrackBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjValueTrackBarNumericUpDown.Location = new System.Drawing.Point(0, 39);
            this.mobjValueTrackBarNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTrackBarNumericUpDown.Name = "mobjValueTrackBarNumericUpDown";
            this.mobjValueTrackBarNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjValueTrackBarNumericUpDown.TabIndex = 4;
            this.mobjValueTrackBarNumericUpDown.ValueChanged += new System.EventHandler(this.mobjValueTrackBarNumericUpDown_ValueChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoTrackBar, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(497, 225);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjValueTrackBarLabel);
            this.mobjPanel.Controls.Add(this.mobjValueTrackBarNumericUpDown);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(74, 52);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(347, 60);
            this.mobjPanel.TabIndex = 0;
            // 
            // ServerSideEventsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(497, 225);
            this.Text = "ServerSideEventsPage";
            this.Load += new System.EventHandler(this.ServerSideEventsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjValueTrackBarNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjValueTrackBarLabel;
        private Gizmox.WebGUI.Forms.TrackBar mobjDemoTrackBar;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjValueTrackBarNumericUpDown;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
