namespace CompanionKit.Controls.ProgressBar.Functionality
{
    partial class MinimumPropertyPage
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
            this.mobjDemoMin0ProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjDemoMin75ProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjDemoProgressBarMin0label = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoProgressBarMin75label = new Gizmox.WebGUI.Forms.Label();
            this.mobjIncrementTimer = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoMin0ProgressBar
            // 
            this.mobjDemoMin0ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoMin0ProgressBar.Location = new System.Drawing.Point(0, 10);
            this.mobjDemoMin0ProgressBar.Name = "mobjDemoMin0ProgressBar";
            this.mobjDemoMin0ProgressBar.Size = new System.Drawing.Size(518, 20);
            this.mobjDemoMin0ProgressBar.Step = 5;
            this.mobjDemoMin0ProgressBar.TabIndex = 0;
            // 
            // mobjDemoMin75ProgressBar
            // 
            this.mobjDemoMin75ProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoMin75ProgressBar.Location = new System.Drawing.Point(0, 10);
            this.mobjDemoMin75ProgressBar.Minimum = 75;
            this.mobjDemoMin75ProgressBar.Name = "mobjDemoMin75ProgressBar";
            this.mobjDemoMin75ProgressBar.Size = new System.Drawing.Size(518, 20);
            this.mobjDemoMin75ProgressBar.Step = 5;
            this.mobjDemoMin75ProgressBar.TabIndex = 1;
            this.mobjDemoMin75ProgressBar.Value = 75;
            // 
            // mobjDemoProgressBarMin0label
            // 
            this.mobjDemoProgressBarMin0label.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBarMin0label, 2);
            this.mobjDemoProgressBarMin0label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarMin0label.Location = new System.Drawing.Point(111, 22);
            this.mobjDemoProgressBarMin0label.Name = "mobjDemoProgressBarMin0label";
            this.mobjDemoProgressBarMin0label.Size = new System.Drawing.Size(629, 50);
            this.mobjDemoProgressBarMin0label.TabIndex = 2;
            this.mobjDemoProgressBarMin0label.Text = "Demonstrated ProgressBar(Minimum - 0)";
            // 
            // mobjDemoProgressBarMin75label
            // 
            this.mobjDemoProgressBarMin75label.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBarMin75label, 2);
            this.mobjDemoProgressBarMin75label.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarMin75label.Location = new System.Drawing.Point(111, 122);
            this.mobjDemoProgressBarMin75label.Name = "mobjDemoProgressBarMin75label";
            this.mobjDemoProgressBarMin75label.Size = new System.Drawing.Size(629, 50);
            this.mobjDemoProgressBarMin75label.TabIndex = 3;
            this.mobjDemoProgressBarMin75label.Text = "Demonstrated ProgressBar(Minimum - 75)";
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
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarMin0label, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarMin75label, 1, 4);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(818, 221);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjDemoMin0ProgressBar);
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
            this.mobjBottomPanel.Controls.Add(this.mobjDemoMin75ProgressBar);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.Top = 10;
            this.mobjBottomPanel.Location = new System.Drawing.Point(111, 172);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0);
            this.mobjBottomPanel.Size = new System.Drawing.Size(518, 30);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // MinimumPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(740, 225);
            this.Text = "MinimumPropertyPage";
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.mobjIncrementTimer};
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoMin0ProgressBar;
        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoMin75ProgressBar;
        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarMin0label;
        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarMin75label;
        private Gizmox.WebGUI.Forms.Timer mobjIncrementTimer;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;

    }
}