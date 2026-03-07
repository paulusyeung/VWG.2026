namespace CompanionKit.Controls.TrackBar.Functionality
{
    partial class OrientationPage
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
            this.mobjOrientationTrackBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjOrientationTrackBarComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjOrientationPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjHorizontalPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjVerticalPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjOrientationPanel.SuspendLayout();
            this.mobjHorizontalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoTrackBar
            // 
            this.mobjDemoTrackBar.AllowDrag = false;
            this.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoTrackBar.Location = new System.Drawing.Point(0, 0);
            this.mobjDemoTrackBar.Maximum = 100;
            this.mobjDemoTrackBar.Name = "mobjDemoTrackBar";
            this.mobjDemoTrackBar.Size = new System.Drawing.Size(250, 40);
            this.mobjDemoTrackBar.TabIndex = 0;
            this.mobjDemoTrackBar.TickFrequency = 5;
            // 
            // mobjOrientationTrackBarLabel
            // 
            this.mobjOrientationTrackBarLabel.AutoSize = true;
            this.mobjOrientationTrackBarLabel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.mobjOrientationTrackBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjOrientationTrackBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjOrientationTrackBarLabel.Name = "mobjOrientationTrackBarLabel";
            this.mobjOrientationTrackBarLabel.Size = new System.Drawing.Size(104, 13);
            this.mobjOrientationTrackBarLabel.TabIndex = 1;
            this.mobjOrientationTrackBarLabel.Text = "TrackBar orientation";
            // 
            // mobjOrientationTrackBarComboBox
            // 
            this.mobjOrientationTrackBarComboBox.AllowDrag = false;
            this.mobjOrientationTrackBarComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjOrientationTrackBarComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjOrientationTrackBarComboBox.Location = new System.Drawing.Point(0, 39);
            this.mobjOrientationTrackBarComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjOrientationTrackBarComboBox.Name = "mobjOrientationTrackBarComboBox";
            this.mobjOrientationTrackBarComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjOrientationTrackBarComboBox.TabIndex = 3;
            this.mobjOrientationTrackBarComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjOrientationTrackBarComboBox_SelectedIndexChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 250F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjOrientationPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjHorizontalPanel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjVerticalPanel, 3, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(580, 306);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjOrientationPanel
            // 
            this.mobjOrientationPanel.Controls.Add(this.mobjOrientationTrackBarLabel);
            this.mobjOrientationPanel.Controls.Add(this.mobjOrientationTrackBarComboBox);
            this.mobjOrientationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOrientationPanel.Location = new System.Drawing.Point(130, 123);
            this.mobjOrientationPanel.Name = "mobjOrientationPanel";
            this.mobjOrientationPanel.Size = new System.Drawing.Size(250, 60);
            this.mobjOrientationPanel.TabIndex = 0;
            // 
            // mobjHorizontalPanel
            // 
            this.mobjHorizontalPanel.Controls.Add(this.mobjDemoTrackBar);
            this.mobjHorizontalPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHorizontalPanel.Location = new System.Drawing.Point(130, 203);
            this.mobjHorizontalPanel.Name = "mobjHorizontalPanel";
            this.mobjHorizontalPanel.Size = new System.Drawing.Size(250, 40);
            this.mobjHorizontalPanel.TabIndex = 0;
            // 
            // mobjVerticalPanel
            // 
            this.mobjVerticalPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjVerticalPanel.Location = new System.Drawing.Point(400, 63);
            this.mobjVerticalPanel.Name = "mobjVerticalPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjVerticalPanel, 5);
            this.mobjVerticalPanel.Size = new System.Drawing.Size(50, 180);
            this.mobjVerticalPanel.TabIndex = 0;
            // 
            // OrientationPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(580, 306);
            this.Text = "OrientationPage";
            this.Load += new System.EventHandler(this.OrientationPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjOrientationPanel.ResumeLayout(false);
            this.mobjHorizontalPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TrackBar mobjDemoTrackBar;
        private Gizmox.WebGUI.Forms.Label mobjOrientationTrackBarLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjOrientationTrackBarComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjOrientationPanel;
        private Gizmox.WebGUI.Forms.Panel mobjHorizontalPanel;
        private Gizmox.WebGUI.Forms.Panel mobjVerticalPanel;



    }
}
