namespace CompanionKit.Controls.ProgressBar.ApplicationScenarios
{
    partial class ChangeValuePage
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
            this.mobjIncrementTimer.Stop();
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
            this.mobjIncrementTimer = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoProgressBarLabel
            // 
            this.mobjDemoProgressBarLabel.AutoSize = true;
            this.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarLabel.Location = new System.Drawing.Point(122, 45);
            this.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel";
            this.mobjDemoProgressBarLabel.Size = new System.Drawing.Size(569, 50);
            this.mobjDemoProgressBarLabel.TabIndex = 0;
            this.mobjDemoProgressBarLabel.Text = "Demonstrated ProgressBar";
            this.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoProgressBar
            // 
            this.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBar.Location = new System.Drawing.Point(122, 95);
            this.mobjDemoProgressBar.Name = "mobjDemoProgressBar";
            this.mobjDemoProgressBar.Size = new System.Drawing.Size(569, 30);
            this.mobjDemoProgressBar.TabIndex = 1;
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
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBar, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarLabel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(814, 170);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // ChangeValuePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(814, 170);
            this.Text = "ChangeValuePage";
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
            this.mobjIncrementTimer};
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarLabel;
        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoProgressBar;
        private Gizmox.WebGUI.Forms.Timer mobjIncrementTimer;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}