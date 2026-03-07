#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.ScheduleBox
{
	public partial class Appearence : UserControl
	{
		private Gizmox.WebGUI.Forms.ScheduleBox mobjScheduleBox;
		
		public Appearence()
		{
			InitializeComponent();
		}

		public Gizmox.WebGUI.Forms.ScheduleBox ScheduleBox
		{
			get { return mobjScheduleBox; }
			set { mobjScheduleBox = value; }
		}

		public void SetInitial_Common()
		{
			this.ScheduleBox.HourFormat = ScheduleBoxHourFormat.Clock24H;
			this.ScheduleBox.WorkEndHour = 17;
			this.ScheduleBox.WorkStartHour = 9;
			this.ScheduleBox.FirstDayOfWeek = Day.Monday;
			this.calendarDate.Value =
				this.ScheduleBox.FirstDate = this.ScheduleBox.Events[0].Start;
		}

		public void SetInitial_1()
		{
			SetInitial_Common();
			
			viewWeek.Checked = true;
			workStart.Value = 8;
		}

		public void SetInitial_2()
		{
			viewMonth.Checked = true;
			workStart.Value = 7;

			SetInitial_Common();
		}

		public void SetInitial_3()
		{
			this.ScheduleBox.View = ScheduleBoxView.FullWeek;
			SetInitial_Common();
		}

		public void SetInitial_4()
		{
			viewDay.Checked = true;
			workStart.Value = 9;

			SetInitial_Common();
		}

        /// <summary>
        /// View changed
        /// </summary>
        private void Views_Changed(object sender, EventArgs e)
        {
			if(this.ScheduleBox != null)
            this.ScheduleBox.View = (ScheduleBoxView)Enum.Parse(typeof(ScheduleBoxView),(sender as Control).Tag as string);
        }

        /// <summary>
        /// Hour format changed
        /// </summary>
        private void hourFormat_CheckedChanged(object sender, EventArgs e)
        {
			if(this.ScheduleBox != null)
            this.ScheduleBox.HourFormat = (ScheduleBoxHourFormat)Enum.Parse(typeof(ScheduleBoxHourFormat),(sender as Control).Tag as string);
        }

        /// <summary>
        /// First day of the week changed
        /// </summary>
        private void firstDateOfWeek_CheckedChanged(object sender, EventArgs e)
        {
			if(this.ScheduleBox != null)
            this.ScheduleBox.FirstDayOfWeek = (Day)Enum.Parse(typeof(Day),(sender as Control).Tag as string);
        }

        /// <summary>
        /// Date changed
        /// </summary>
        private void firstDateDate_ValueChanged(object sender, EventArgs e)
        {
			if(this.ScheduleBox != null)
            this.ScheduleBox.FirstDate = calendarDate.Value;
        }

		private void workHours_ValueChanged(object sender, EventArgs e)
		{
			if (this.ScheduleBox != null)
			{
				if (sender == workEnd)
				{
					this.ScheduleBox.WorkEndHour = workEnd.Value;
					this.lblEndWork.Text = workEnd.Value.ToString();
				}
				else if (sender == workStart)
				{
					this.ScheduleBox.WorkStartHour = workStart.Value;
					this.lblStartWork.Text = workStart.Value.ToString();
				}
				this.ScheduleBox.Update();
			}
		}

	}
}