using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.ScheduleBox
{
    public partial class EventForm : Gizmox.WebGUI.Forms.Form
    {
        /// <summary>
        /// Handled event object.
        /// </summary>
        private ScheduleBoxEvent mobjEvent = null;
        
        public EventForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets subject of event
        /// </summary>
        public string SubjectEvent
        {
            get
            {
                return this.subjectTextBox.Text;
            }
            set
            {
                this.subjectTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets start time of the event
        /// </summary>
        public DateTime StartTimeEvent
        {
            get
            {
                return this.startDateDateTimePicker.Value;
            }

            set
            {
                this.startDateDateTimePicker.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets end time of the event
        /// </summary>
        public DateTime EndTimeEvent
        {
            get
            {
                return this.endDateDateTimePicker.Value;
            }
            set
            {
                this.endDateDateTimePicker.Value = value;
            }
        }

        /// <summary>
        /// Sets or gets shortcut on the opened event.
        /// </summary>
        public ScheduleBoxEvent TargetEvent
        {
            get
            {
                return mobjEvent;
            }
            set
            {
                mobjEvent = value;

				SubjectEvent	= mobjEvent.Subject;
				StartTimeEvent	= mobjEvent.Start;
				EndTimeEvent	= mobjEvent.End;
				EventTag		= mobjEvent.Tag != null ? mobjEvent.Tag.ToString() : "";
            }
        }

        /// <summary>
        /// Sets or gets tag of the event
        /// </summary>
        public string EventTag
        {
            get
            {
                return this.tagTextBox.Text;
            }

            set
            {
                this.tagTextBox.Text = value;
            }
        }

        /// <summary>
        /// Cancel button pressed.
        /// </summary>
        private void cancelEventButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Ok button pressed
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
			if (subjectTextBox.Text.Trim().Length ==0)
			{
				errorProvider1.SetError(subjectTextBox, "The subject can't be empty");
			}
			else
			{
				errorProvider1.SetError(subjectTextBox, "");
				this.DialogResult = DialogResult.OK;
				mobjEvent.Subject = SubjectEvent;
				mobjEvent.Start = StartTimeEvent;
				mobjEvent.End = EndTimeEvent;
				mobjEvent.Tag = EventTag;
                
			}
        }

        /// <summary>
        /// Start date/time changed, it will be a minimal for the end of the edited event.
        /// </summary>
        private void startDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.endDateDateTimePicker.MinDate = this.startDateDateTimePicker.Value;
        }

		/// <summary>
		/// Fill the form with some experimental data
		/// </summary>
		private void testButton_Click(object sender, EventArgs e)
		{
			this.subjectTextBox.Text = "Experimental event subject";
			this.startDateDateTimePicker.Value = new DateTime(2010,12,01,11,00,00);
			this.endDateDateTimePicker.Value = new DateTime(2010,12,01,12,00,00);
			this.tagTextBox.Text = "An additional event details and description";
		}
    }
}