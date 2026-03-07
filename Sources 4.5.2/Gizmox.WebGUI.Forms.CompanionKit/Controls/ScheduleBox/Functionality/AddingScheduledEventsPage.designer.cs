namespace CompanionKit.Controls.ScheduleBox.Functionality
{
    partial class AddingScheduledEventsPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingScheduledEventsPage));
			this.objAppearance = new CompanionKit.Controls.ScheduleBox.Appearence();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.demoScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.objAddNew = new Gizmox.WebGUI.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
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
			// panel1
			// 
			this.panel1.Controls.Add(this.objAddNew);
			this.panel1.Controls.Add(this.objAppearance);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 670);
			this.panel1.TabIndex = 2;
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
			this.demoScheduleBox.Size = new System.Drawing.Size(470, 670);
			this.demoScheduleBox.TabIndex = 0;
			this.demoScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day;
			this.demoScheduleBox.WorkEndHour = 17;
			this.demoScheduleBox.WorkStartHour = 9;
			this.demoScheduleBox.EventDoubleClick += new Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventHandler(this.EventDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.demoScheduleBox);
			this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(180, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(470, 670);
			this.panel2.TabIndex = 3;
			// 
			// objAddNew
			// 
			this.objAddNew.AutoSize = true;
			this.objAddNew.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("objAddNew.Image"));
			this.objAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.objAddNew.Location = new System.Drawing.Point(2, 602);
			this.objAddNew.Name = "objAddNew";
			this.objAddNew.Padding = new Gizmox.WebGUI.Forms.Padding(15, 5, 5, 5);
			this.objAddNew.Size = new System.Drawing.Size(172, 43);
			this.objAddNew.TabIndex = 2;
			this.objAddNew.Text = "Add new event ...";
			this.objAddNew.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
			this.objAddNew.UseVisualStyleBackColor = true;
			this.objAddNew.Click += new System.EventHandler(this.AddNewEvent);
			// 
			// AddingScheduledEventsPage
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Size = new System.Drawing.Size(650, 670);
			this.Text = "AddingScheduledEventsPage";
			this.Load += new System.EventHandler(this.AddingScheduledEventsPage_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }


        #endregion

		private Appearence objAppearance;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox;
		private Gizmox.WebGUI.Forms.Panel panel2;
		private Gizmox.WebGUI.Forms.Button objAddNew;




    }
}