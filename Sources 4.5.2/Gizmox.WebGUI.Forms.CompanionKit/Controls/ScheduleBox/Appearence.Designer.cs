namespace CompanionKit.Controls.ScheduleBox
{
	partial class Appearence
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
			this.calendarDate = new Gizmox.WebGUI.Forms.MonthCalendar();
			this.groupBox5 = new Gizmox.WebGUI.Forms.GroupBox();
			this.daySunday = new Gizmox.WebGUI.Forms.RadioButton();
			this.dayMonday = new Gizmox.WebGUI.Forms.RadioButton();
			this.groupBox4 = new Gizmox.WebGUI.Forms.GroupBox();
			this.hour12 = new Gizmox.WebGUI.Forms.RadioButton();
			this.hour24 = new Gizmox.WebGUI.Forms.RadioButton();
			this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
			this.viewDay = new Gizmox.WebGUI.Forms.RadioButton();
			this.viewMonth = new Gizmox.WebGUI.Forms.RadioButton();
			this.viewFullMonth = new Gizmox.WebGUI.Forms.RadioButton();
			this.viewFullWeek = new Gizmox.WebGUI.Forms.RadioButton();
			this.viewWeek = new Gizmox.WebGUI.Forms.RadioButton();
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.lblEndWork = new Gizmox.WebGUI.Forms.Label();
			this.lblStartWork = new Gizmox.WebGUI.Forms.Label();
			this.workEnd = new Gizmox.WebGUI.Forms.TrackBar();
			this.workStart = new Gizmox.WebGUI.Forms.TrackBar();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.workEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.workStart)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// calendarDate
			// 
			this.calendarDate.Location = new System.Drawing.Point(14, 24);
			this.calendarDate.Name = "calendarDate";
			this.calendarDate.Size = new System.Drawing.Size(150, 155);
			this.calendarDate.TabIndex = 14;
			this.calendarDate.Value = new System.DateTime(2010, 12, 2, 15, 15, 46, 622);
			this.calendarDate.DateChanged += new System.EventHandler(this.firstDateDate_ValueChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.calendarDate);
			this.groupBox5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox5.Location = new System.Drawing.Point(4, 403);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(170, 187);
			this.groupBox5.TabIndex = 15;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Date";
			// 
			// daySunday
			// 
			this.daySunday.AutoSize = true;
			this.daySunday.Location = new System.Drawing.Point(17, 19);
			this.daySunday.Name = "daySunday";
			this.daySunday.Size = new System.Drawing.Size(61, 17);
			this.daySunday.TabIndex = 0;
			this.daySunday.Tag = "Sunday";
			this.daySunday.Text = "Sunday";
			this.daySunday.CheckedChanged += new System.EventHandler(this.firstDateOfWeek_CheckedChanged);
			// 
			// dayMonday
			// 
			this.dayMonday.AutoSize = true;
			this.dayMonday.Checked = true;
			this.dayMonday.Location = new System.Drawing.Point(17, 42);
			this.dayMonday.Name = "dayMonday";
			this.dayMonday.Size = new System.Drawing.Size(63, 17);
			this.dayMonday.TabIndex = 0;
			this.dayMonday.Tag = "Monday";
			this.dayMonday.Text = "Monday";
			this.dayMonday.CheckedChanged += new System.EventHandler(this.firstDateOfWeek_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.daySunday);
			this.groupBox4.Controls.Add(this.dayMonday);
			this.groupBox4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox4.Location = new System.Drawing.Point(4, 217);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(170, 69);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "First day of week";
			// 
			// hour12
			// 
			this.hour12.AutoSize = true;
			this.hour12.Location = new System.Drawing.Point(17, 19);
			this.hour12.Name = "hour12";
			this.hour12.Size = new System.Drawing.Size(68, 17);
			this.hour12.TabIndex = 0;
			this.hour12.Tag = "Clock12H";
			this.hour12.Text = "12 Hours";
			this.hour12.CheckedChanged += new System.EventHandler(this.hourFormat_CheckedChanged);
			// 
			// hour24
			// 
			this.hour24.AutoSize = true;
			this.hour24.Checked = true;
			this.hour24.Location = new System.Drawing.Point(17, 42);
			this.hour24.Name = "hour24";
			this.hour24.Size = new System.Drawing.Size(68, 17);
			this.hour24.TabIndex = 0;
			this.hour24.Tag = "Clock24H";
			this.hour24.Text = "24 Hours";
			this.hour24.CheckedChanged += new System.EventHandler(this.hourFormat_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.hour12);
			this.groupBox3.Controls.Add(this.hour24);
			this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox3.Location = new System.Drawing.Point(4, 144);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(170, 70);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Hour format";
			// 
			// viewDay
			// 
			this.viewDay.AutoSize = true;
			this.viewDay.Checked = true;
			this.viewDay.Location = new System.Drawing.Point(17, 111);
			this.viewDay.Name = "viewDay";
			this.viewDay.Size = new System.Drawing.Size(44, 17);
			this.viewDay.TabIndex = 0;
			this.viewDay.Tag = "Day";
			this.viewDay.Text = "Day";
			this.viewDay.CheckedChanged += new System.EventHandler(this.Views_Changed);
			// 
			// viewMonth
			// 
			this.viewMonth.AutoSize = true;
			this.viewMonth.Location = new System.Drawing.Point(17, 88);
			this.viewMonth.Name = "viewMonth";
			this.viewMonth.Size = new System.Drawing.Size(55, 17);
			this.viewMonth.TabIndex = 0;
			this.viewMonth.Tag = "Month";
			this.viewMonth.Text = "Month";
			this.viewMonth.CheckedChanged += new System.EventHandler(this.Views_Changed);
			// 
			// viewFullMonth
			// 
			this.viewFullMonth.AutoSize = true;
			this.viewFullMonth.Location = new System.Drawing.Point(17, 65);
			this.viewFullMonth.Name = "viewFullMonth";
			this.viewFullMonth.Size = new System.Drawing.Size(71, 17);
			this.viewFullMonth.TabIndex = 0;
			this.viewFullMonth.Tag = "FullMonth";
			this.viewFullMonth.Text = "FullMonth";
			this.viewFullMonth.CheckedChanged += new System.EventHandler(this.Views_Changed);
			// 
			// viewFullWeek
			// 
			this.viewFullWeek.AutoSize = true;
			this.viewFullWeek.Location = new System.Drawing.Point(17, 42);
			this.viewFullWeek.Name = "viewFullWeek";
			this.viewFullWeek.Size = new System.Drawing.Size(68, 17);
			this.viewFullWeek.TabIndex = 0;
			this.viewFullWeek.Tag = "FullWeek";
			this.viewFullWeek.Text = "FullWeek";
			this.viewFullWeek.CheckedChanged += new System.EventHandler(this.Views_Changed);
			// 
			// viewWeek
			// 
			this.viewWeek.AutoSize = true;
			this.viewWeek.Location = new System.Drawing.Point(17, 19);
			this.viewWeek.Name = "viewWeek";
			this.viewWeek.Size = new System.Drawing.Size(52, 17);
			this.viewWeek.TabIndex = 0;
			this.viewWeek.Tag = "Week";
			this.viewWeek.Text = "Week";
			this.viewWeek.UseVisualStyleBackColor = true;
			this.viewWeek.CheckedChanged += new System.EventHandler(this.Views_Changed);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.viewDay);
			this.groupBox2.Controls.Add(this.viewMonth);
			this.groupBox2.Controls.Add(this.viewFullMonth);
			this.groupBox2.Controls.Add(this.viewFullWeek);
			this.groupBox2.Controls.Add(this.viewWeek);
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(4, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(170, 136);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "ScheduleBox view mode";
			// 
			// lblEndWork
			// 
			this.lblEndWork.AutoSize = true;
			this.lblEndWork.Location = new System.Drawing.Point(150, 76);
			this.lblEndWork.Name = "lblEndWork";
			this.lblEndWork.Size = new System.Drawing.Size(13, 13);
			this.lblEndWork.TabIndex = 11;
			this.lblEndWork.Text = "17";
			this.lblEndWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStartWork
			// 
			this.lblStartWork.AutoSize = true;
			this.lblStartWork.Location = new System.Drawing.Point(151, 25);
			this.lblStartWork.Name = "lblStartWork";
			this.lblStartWork.Size = new System.Drawing.Size(13, 13);
			this.lblStartWork.TabIndex = 11;
			this.lblStartWork.Text = "9";
			this.lblStartWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// workEnd
			// 
			this.workEnd.Location = new System.Drawing.Point(8, 71);
			this.workEnd.Maximum = 23;
			this.workEnd.Minimum = 16;
			this.workEnd.Name = "workEnd";
			this.workEnd.Size = new System.Drawing.Size(130, 35);
			this.workEnd.TabIndex = 10;
			this.workEnd.Value = 17;
			this.workEnd.ValueChanged += new System.EventHandler(this.workHours_ValueChanged);
			// 
			// workStart
			// 
			this.workStart.Location = new System.Drawing.Point(8, 20);
			this.workStart.Maximum = 12;
			this.workStart.Minimum = 7;
			this.workStart.Name = "workStart";
			this.workStart.Size = new System.Drawing.Size(130, 48);
			this.workStart.TabIndex = 10;
			this.workStart.Value = 9;
			this.workStart.ValueChanged += new System.EventHandler(this.workHours_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblEndWork);
			this.groupBox1.Controls.Add(this.lblStartWork);
			this.groupBox1.Controls.Add(this.workEnd);
			this.groupBox1.Controls.Add(this.workStart);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(4, 289);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 111);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Work hours [start/end]";
			// 
			// Appearence
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox5);
			this.Size = new System.Drawing.Size(187, 611);
			this.Text = "Appearence";
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.workEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.workStart)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Gizmox.WebGUI.Forms.MonthCalendar calendarDate;
		private Gizmox.WebGUI.Forms.GroupBox groupBox5;
		private Gizmox.WebGUI.Forms.RadioButton daySunday;
		private Gizmox.WebGUI.Forms.RadioButton dayMonday;
		private Gizmox.WebGUI.Forms.GroupBox groupBox4;
		private Gizmox.WebGUI.Forms.RadioButton hour12;
		private Gizmox.WebGUI.Forms.RadioButton hour24;
		private Gizmox.WebGUI.Forms.GroupBox groupBox3;
		private Gizmox.WebGUI.Forms.RadioButton viewDay;
		private Gizmox.WebGUI.Forms.RadioButton viewMonth;
		private Gizmox.WebGUI.Forms.RadioButton viewFullMonth;
		private Gizmox.WebGUI.Forms.RadioButton viewFullWeek;
		private Gizmox.WebGUI.Forms.RadioButton viewWeek;
		private Gizmox.WebGUI.Forms.GroupBox groupBox2;
		private Gizmox.WebGUI.Forms.Label lblEndWork;
		private Gizmox.WebGUI.Forms.Label lblStartWork;
		private Gizmox.WebGUI.Forms.TrackBar workEnd;
		private Gizmox.WebGUI.Forms.TrackBar workStart;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;


	}
}