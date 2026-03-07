namespace CompanionKit.Controls.ProgressBar.Functionality
{
    partial class PerformStepPage
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
                mobjIncrementTimer.Stop();
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
            this.mobjDemoProgressBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjStepNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjStepProgressBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjIncrementTimer = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjStepNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoProgressBarLabel
            // 
            this.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel";
            this.mobjDemoProgressBarLabel.Size = new System.Drawing.Size(136, 13);
            this.mobjDemoProgressBarLabel.TabIndex = 0;
            this.mobjDemoProgressBarLabel.Text = "Demonstrated ProgressBar";
            this.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoProgressBar
            // 
            this.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBar.Location = new System.Drawing.Point(112, 79);
            this.mobjDemoProgressBar.Name = "mobjDemoProgressBar";
            this.mobjDemoProgressBar.Size = new System.Drawing.Size(525, 30);
            this.mobjDemoProgressBar.TabIndex = 1;
            // 
            // mobjStepNumericUpDown
            // 
            this.mobjStepNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjStepNumericUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjStepNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStepNumericUpDown.Location = new System.Drawing.Point(112, 179);
            this.mobjStepNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mobjStepNumericUpDown.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjStepNumericUpDown.Name = "mobjStepNumericUpDown";
            this.mobjStepNumericUpDown.Size = new System.Drawing.Size(200, 21);
            this.mobjStepNumericUpDown.TabIndex = 2;
            this.mobjStepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjStepNumericUpDown.ValueChanged += new System.EventHandler(this.stepNumericUpDown_ValueChanged);
            // 
            // mobjStepProgressBarLabel
            // 
            this.mobjStepProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStepProgressBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjStepProgressBarLabel.Name = "mobjStepProgressBarLabel";
            this.mobjStepProgressBarLabel.Size = new System.Drawing.Size(125, 13);
            this.mobjStepProgressBarLabel.TabIndex = 3;
            this.mobjStepProgressBarLabel.Text = "Step of the ProgressBar ";
            this.mobjStepProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjIncrementTimer
            // 
            this.mobjIncrementTimer.Enabled = true;
            this.mobjIncrementTimer.Interval = 500;
            this.mobjIncrementTimer.Tick += new System.EventHandler(this.incrementTimer_Tick);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBar, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjStepNumericUpDown, 1, 5);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 52F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(751, 237);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjDemoProgressBarLabel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(112, 27);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(525, 52);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjStepProgressBarLabel);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(112, 129);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(525, 50);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // PerformStepPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(751, 237);
            this.Text = "PerformStepPage";
            this.Load += new System.EventHandler(this.PerformStepPage_Load);
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.mobjIncrementTimer};
            ((System.ComponentModel.ISupportInitialize)(this.mobjStepNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarLabel;
        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoProgressBar;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjStepNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjStepProgressBarLabel;
        private Gizmox.WebGUI.Forms.Timer mobjIncrementTimer;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;



    }
}