namespace CompanionKit.Controls.ProgressBar.Features
{
    partial class SetValuePage
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
            this.mobjDemoProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjChangevalueTrackBar = new Gizmox.WebGUI.Forms.TrackBar();
            this.mobjDemoProgressBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeValueLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTrackBarPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjProgressBarPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjChangevalueTrackBar)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjProgressBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoProgressBar
            // 
            this.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBar.Location = new System.Drawing.Point(122, 70);
            this.mobjDemoProgressBar.Maximum = 200;
            this.mobjDemoProgressBar.Name = "mobjDemoProgressBar";
            this.mobjDemoProgressBar.Size = new System.Drawing.Size(570, 30);
            this.mobjDemoProgressBar.TabIndex = 0;
            // 
            // mobjChangevalueTrackBar
            // 
            this.mobjChangevalueTrackBar.AllowDrag = false;
            this.mobjChangevalueTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangevalueTrackBar.Location = new System.Drawing.Point(122, 170);
            this.mobjChangevalueTrackBar.Name = "mobjChangevalueTrackBar";
            this.mobjChangevalueTrackBar.Size = new System.Drawing.Size(570, 30);
            this.mobjChangevalueTrackBar.TabIndex = 1;
            this.mobjChangevalueTrackBar.ValueChanged += new System.EventHandler(this.mobjChangevalueTrackBar_ValueChanged);
            // 
            // mobjDemoProgressBarLabel
            // 
            this.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel";
            this.mobjDemoProgressBarLabel.Size = new System.Drawing.Size(130, 13);
            this.mobjDemoProgressBarLabel.TabIndex = 2;
            this.mobjDemoProgressBarLabel.Text = "Demonstrate ProgressBar";
            this.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjChangeValueLabel
            // 
            this.mobjChangeValueLabel.AutoSize = true;
            this.mobjChangeValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeValueLabel.Location = new System.Drawing.Point(122, 120);
            this.mobjChangeValueLabel.Name = "mobjChangeValueLabel";
            this.mobjChangeValueLabel.Size = new System.Drawing.Size(570, 50);
            this.mobjChangeValueLabel.TabIndex = 4;
            this.mobjChangeValueLabel.Text = "Change value of the ProgressBar";
            this.mobjChangeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBar, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangevalueTrackBar, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjTrackBarPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeValueLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjProgressBarPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(815, 222);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjTrackBarPanel
            // 
            this.mobjTrackBarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTrackBarPanel.Location = new System.Drawing.Point(122, 170);
            this.mobjTrackBarPanel.Name = "mobjTrackBarPanel";
            this.mobjTrackBarPanel.Size = new System.Drawing.Size(570, 30);
            this.mobjTrackBarPanel.TabIndex = 0;
            // 
            // mobjProgressBarPanel
            // 
            this.mobjProgressBarPanel.Controls.Add(this.mobjDemoProgressBarLabel);
            this.mobjProgressBarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjProgressBarPanel.Location = new System.Drawing.Point(122, 20);
            this.mobjProgressBarPanel.Name = "mobjProgressBarPanel";
            this.mobjProgressBarPanel.Size = new System.Drawing.Size(570, 50);
            this.mobjProgressBarPanel.TabIndex = 0;
            // 
            // SetValuePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(815, 222);
            this.Text = "SetValuePage";
            this.Load += new System.EventHandler(this.SetValuePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjChangevalueTrackBar)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjProgressBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoProgressBar;
        private Gizmox.WebGUI.Forms.TrackBar mobjChangevalueTrackBar;
        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarLabel;
        private Gizmox.WebGUI.Forms.Label mobjChangeValueLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTrackBarPanel;
        private Gizmox.WebGUI.Forms.Panel mobjProgressBarPanel;



    }
}