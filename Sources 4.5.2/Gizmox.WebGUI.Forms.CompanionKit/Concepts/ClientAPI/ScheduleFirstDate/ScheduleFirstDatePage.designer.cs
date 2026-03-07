namespace CompanionKit.Concepts.ClientAPI.ScheduleFirstDate
{
    partial class ScheduleFirstDatePage
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
            this.mobjScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButtonBack = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonForward = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjScheduleBox
            // 
            this.mobjScheduleBox.ClientId = "schedule";
            this.mobjScheduleBox.DisplayMonthHeader = false;
            this.mobjScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjScheduleBox.FirstDate = new System.DateTime(2013, 8, 7, 17, 44, 43, 983);
            this.mobjScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
            this.mobjScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H;
            this.mobjScheduleBox.Location = new System.Drawing.Point(15, 15);
            this.mobjScheduleBox.Name = "mobjScheduleBox";
            this.mobjScheduleBox.Size = new System.Drawing.Size(404, 256);
            this.mobjScheduleBox.TabIndex = 0;
            this.mobjScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day;
            this.mobjScheduleBox.WorkEndHour = 17;
            this.mobjScheduleBox.WorkStartHour = 9;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjScheduleBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanel.DockPadding.All = 15;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjPanel.Size = new System.Drawing.Size(434, 286);
            this.mobjPanel.TabIndex = 1;
            // 
            // mobjButtonBack
            // 
            this.mobjButtonBack.ClientId = "btnBack";
            this.mobjButtonBack.Location = new System.Drawing.Point(15, 307);
            this.mobjButtonBack.Name = "mobjButtonBack";
            this.mobjButtonBack.Size = new System.Drawing.Size(60, 23);
            this.mobjButtonBack.TabIndex = 2;
            this.mobjButtonBack.Text = "<<";
            this.mobjButtonBack.Click += new System.EventHandler(this.mobjButtonBack_Click);
            // 
            // mobjButtonForward
            // 
            this.mobjButtonForward.ClientId = "btnForward";
            this.mobjButtonForward.Location = new System.Drawing.Point(179, 307);
            this.mobjButtonForward.Name = "mobjButtonForward";
            this.mobjButtonForward.Size = new System.Drawing.Size(60, 23);
            this.mobjButtonForward.TabIndex = 3;
            this.mobjButtonForward.Text = ">>";
            this.mobjButtonForward.Click += new System.EventHandler(this.mobjButtonForward_Click);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Location = new System.Drawing.Point(75, 302);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(104, 32);
            this.mobjLabel.TabIndex = 4;
            this.mobjLabel.Text = "First Date";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduleFirstDatePage
            // 
            this.Controls.Add(this.mobjLabel);
            this.Controls.Add(this.mobjButtonForward);
            this.Controls.Add(this.mobjButtonBack);
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(434, 415);
            this.Text = "ScheduleFirstDatePage";
            this.Load += new System.EventHandler(this.ScheduleFirstDatePage_Load);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ScheduleBox mobjScheduleBox;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Button mobjButtonBack;
        private Gizmox.WebGUI.Forms.Button mobjButtonForward;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}