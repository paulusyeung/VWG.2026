namespace CompanionKit.Controls.ProgressBar.Functionality
{
    partial class MaximumPropertyPage
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                this.mobjIncrementTimer.Stop();
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
            this.components = new System.ComponentModel.Container();
            this.mobjDemoMax100ProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjDemoMax25ProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjDemoProgressBarMax100label = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoProgressBarMax25label = new Gizmox.WebGUI.Forms.Label();
            this.mobjIncrementTimer = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoMax100ProgressBar
            // 
            this.mobjDemoMax100ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoMax100ProgressBar.Location = new System.Drawing.Point(0, 10);
            this.mobjDemoMax100ProgressBar.Name = "mobjDemoMax100ProgressBar";
            this.mobjDemoMax100ProgressBar.Size = new System.Drawing.Size(518, 20);
            this.mobjDemoMax100ProgressBar.TabIndex = 0;
            // 
            // mobjDemoMax25ProgressBar
            // 
            this.mobjDemoMax25ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoMax25ProgressBar.Location = new System.Drawing.Point(0, 10);
            this.mobjDemoMax25ProgressBar.Maximum = 25;
            this.mobjDemoMax25ProgressBar.Name = "mobjDemoMax25ProgressBar";
            this.mobjDemoMax25ProgressBar.Size = new System.Drawing.Size(518, 20);
            this.mobjDemoMax25ProgressBar.TabIndex = 1;
            // 
            // mobjDemoProgressBarMax100label
            // 
            this.mobjDemoProgressBarMax100label.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBarMax100label, 2);
            this.mobjDemoProgressBarMax100label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarMax100label.Location = new System.Drawing.Point(111, 22);
            this.mobjDemoProgressBarMax100label.Name = "mobjDemoProgressBarMax100label";
            this.mobjDemoProgressBarMax100label.Size = new System.Drawing.Size(629, 50);
            this.mobjDemoProgressBarMax100label.TabIndex = 2;
            this.mobjDemoProgressBarMax100label.Text = "Demonstrated ProgressBar(Maximum - 100)";
            // 
            // mobjDemoProgressBarMax25label
            // 
            this.mobjDemoProgressBarMax25label.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBarMax25label, 2);
            this.mobjDemoProgressBarMax25label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarMax25label.Location = new System.Drawing.Point(111, 122);
            this.mobjDemoProgressBarMax25label.Name = "mobjDemoProgressBarMax25label";
            this.mobjDemoProgressBarMax25label.Size = new System.Drawing.Size(629, 50);
            this.mobjDemoProgressBarMax25label.TabIndex = 3;
            this.mobjDemoProgressBarMax25label.Text = "Demonstrated ProgressBar(Maximum - 25)";
            // 
            // mobjIncrementTimer
            // 
            this.mobjIncrementTimer.Enabled = true;
            this.mobjIncrementTimer.Interval = 500;
            this.mobjIncrementTimer.Tick += new System.EventHandler(this.mobjIncrementTimer_Tick);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarMax25label, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarMax100label, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 5);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(738, 221);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjDemoMax100ProgressBar);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.DockPadding.Top = 10;
            this.mobjTopPanel.Location = new System.Drawing.Point(111, 72);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0);
            this.mobjTopPanel.Size = new System.Drawing.Size(518, 30);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjDemoMax25ProgressBar);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.Top = 10;
            this.mobjBottomPanel.Location = new System.Drawing.Point(111, 172);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0);
            this.mobjBottomPanel.Size = new System.Drawing.Size(518, 30);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // MaximumPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(740, 225);
            this.Text = "MaximumPropertyPage";
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.mobjIncrementTimer};
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoMax100ProgressBar;
        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoMax25ProgressBar;
        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarMax100label;
        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarMax25label;
        private Gizmox.WebGUI.Forms.Timer mobjIncrementTimer;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;



    }
}