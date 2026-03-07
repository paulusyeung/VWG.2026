using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ScheduleBox.Functionality
{
    public partial class AddingScheduledEventsPage : UserControl
    {
        public AddingScheduledEventsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example's UserControl. 
        /// </summary>
        void AddingScheduledEventsPage_Load(object sender, System.EventArgs e)
        {
			this.objAppearance.ScheduleBox = this.demoScheduleBox;

			// Fill the ScheduleBox events
			foreach (ScheduleBoxEvent currEvent in Events.GetEvents())
			{
			    this.demoScheduleBox.Events.Add(currEvent);
			}
			
			// Initialize view settings
			this.objAppearance.SetInitial_4();
        }


        /// <summary>
        /// Opens clicked event for editing.
        /// </summary>
		private void EventDoubleClick(object sender, Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs e)
		{
			Events.ProcessOpenEvent(demoScheduleBox, e.Event);
		}

		/// <summary>
		/// Opens an editing form and adds new event to demoScheduleBox if user confirmed. 
		/// </summary>
		private void AddNewEvent(object sender, EventArgs e)
		{
			Events.ProcessAddEvent(demoScheduleBox, null, false, null);
		}
    }
}