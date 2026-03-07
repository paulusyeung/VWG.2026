namespace CompanionKit.Controls.ScheduleBox.Appearance
{
    partial class ScheduleBoxViewPropertiesPage
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
			this.demoScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.objAppearance = new CompanionKit.Controls.ScheduleBox.Appearence();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// demoScheduleBox
			// 
			this.demoScheduleBox.DisplayMonthHeader = true;
			this.demoScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.demoScheduleBox.FirstDate = new System.DateTime(2010, 5, 31, 11, 29, 51, 227);
			this.demoScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
			this.demoScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock24H;
			this.demoScheduleBox.Location = new System.Drawing.Point(0, 0);
			this.demoScheduleBox.Name = "demoScheduleBox";
			this.demoScheduleBox.Size = new System.Drawing.Size(470, 672);
			this.demoScheduleBox.TabIndex = 0;
			this.demoScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day;
			this.demoScheduleBox.WorkEndHour = 17;
			this.demoScheduleBox.WorkStartHour = 9;
			this.demoScheduleBox.EventDoubleClick += new Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventHandler(this.EventDoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.objAppearance);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 672);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.demoScheduleBox);
			this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(180, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(470, 672);
			this.panel2.TabIndex = 3;
			// 
			// objAppearance
			// 
			this.objAppearance.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.objAppearance.Location = new System.Drawing.Point(0, 0);
			this.objAppearance.Name = "objAppearance";
			this.objAppearance.ScheduleBox = null;
			this.objAppearance.Size = new System.Drawing.Size(181, 616);
			this.objAppearance.TabIndex = 1;
			this.objAppearance.Text = "Appearence";
			// 
			// ScheduleBoxViewPropertiesPage
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Size = new System.Drawing.Size(650, 672);
			this.Text = "ScheduleBoxViewPropertiesPage";
			this.Load += new System.EventHandler(this.ScheduleBoxViewPropertiesPage_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox;
		private Appearence objAppearance;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Panel panel2;
    }
}