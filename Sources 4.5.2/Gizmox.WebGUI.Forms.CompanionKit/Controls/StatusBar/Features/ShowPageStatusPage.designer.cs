namespace CompanionKit.Controls.StatusBar.Features
{
    partial class ShowPageStatusPage
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
            this.components = new System.ComponentModel.Container();
            this.mobjUpdateStatusBarTimer = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.mobjDemoStatusBar = new Gizmox.WebGUI.Forms.StatusBar();
            this.mobjProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjUpdateStatusBarTimer
            // 
            this.mobjUpdateStatusBarTimer.Enabled = true;
            this.mobjUpdateStatusBarTimer.Interval = 500;
            this.mobjUpdateStatusBarTimer.Tick += new System.EventHandler(this.updateStatusBarTimer_Tick);
            // 
            // mobjDemoStatusBar
            // 
            this.mobjDemoStatusBar.Location = new System.Drawing.Point(0, 149);
            this.mobjDemoStatusBar.Name = "mobjDemoStatusBar";
            this.mobjDemoStatusBar.Size = new System.Drawing.Size(391, 22);
            this.mobjDemoStatusBar.TabIndex = 1;
            this.mobjDemoStatusBar.Text = "Starting";
            // 
            // mobjProgressBar
            // 
            this.mobjProgressBar.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjProgressBar.Location = new System.Drawing.Point(38, 81);
            this.mobjProgressBar.Name = "mobjProgressBar";
            this.mobjProgressBar.Size = new System.Drawing.Size(317, 23);
            this.mobjProgressBar.TabIndex = 2;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(35, 57);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 3;
            this.mobjLabel.Text = "Loading, please wait...";
            // 
            // ShowPageStatusPage
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjProgressBar);
            this.Controls.Add(this.mobjDemoStatusBar);
            this.Size = new System.Drawing.Size(390, 171);
            this.Text = "ShowPageStatusPage";
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.mobjUpdateStatusBarTimer};
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Timer mobjUpdateStatusBarTimer;
        private Gizmox.WebGUI.Forms.StatusBar mobjDemoStatusBar;
        private Gizmox.WebGUI.Forms.ProgressBar mobjProgressBar;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}
